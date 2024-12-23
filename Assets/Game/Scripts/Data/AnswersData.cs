using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

namespace TestAmayaQuiz.Data
{
    [CreateAssetMenu(fileName = "AnswersData", menuName = "Data/Answers")]
    public class AnswersData : ScriptableObject
    {
        public Dictionary<string, SpriteWithRotation> AnswersDict = new Dictionary<string, SpriteWithRotation>();

        [SerializeField]
        private List<Answer> _answers;

        [Serializable]
        public class Answer
        {
            [field: SerializeField]
            public string Value { get; protected internal set; }
            [field: SerializeField]
            public SpriteWithRotation SpriteWithRot { get; private set; }

        }

        public void OnValidate()
        {
            if (_answers == null || _answers.Count <= 0)
            {
                return;
            }

            AnswersDict.Clear();

            foreach (var answer in _answers)
            {
                answer.Value = answer.Value.ToLower();

                if (String.IsNullOrEmpty(answer.Value) || answer.SpriteWithRot == null || answer.SpriteWithRot.Sprite == null)
                {
                    continue;
                }
                if (!AnswersDict.ContainsKey(answer.Value))
                {
                    AnswersDict[answer.Value] = answer.SpriteWithRot;
                }
            }

            var duplicates = _answers.GroupBy(Answer => Answer.Value).Where(group => group.Count() > 1).Select(y => y.Key);
            if (duplicates.Any())
            {
                StringBuilder duplicateKeys = new StringBuilder();
                foreach (var key in duplicates)
                {
                    duplicateKeys.Append(key);
                    duplicateKeys.Append(", ");
                }
                duplicateKeys.Replace(", ", "),", duplicateKeys.Length - 2, 2);
                Debug.LogWarning($"You have duplicates with answers ({duplicateKeys.ToString()} check and delete duplicates!");
            }
        }
    }

    [Serializable]
    public class SpriteWithRotation
    {
        [field: SerializeField]
        public Sprite Sprite { get; private set; }
        [field: SerializeField]
        public float RotationAngle { get; private set; }
    }
}
