using UnityEngine;

namespace TestAmayaQuiz.Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level")]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField]
        public int Rows { get; private set; }
        [field: SerializeField] 
        public int Columns { get; private set; }
    }
}
