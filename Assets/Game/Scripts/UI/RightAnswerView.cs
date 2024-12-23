using DG.Tweening;
using UnityEngine;
using Zenject;
using TMPro;

namespace TestAmayaQuiz
{
    public class RightAnswerView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _answerText;
        [SerializeField]
        private TMP_Text _findText;

        [Inject]
        public void Construct(AnswerChooseService answerChooseService)
        {
            answerChooseService.OnAnswerChosen += (answer, answerData, firstTime) =>
                {
                    if (firstTime)
                    {
                        Color transparentColor = _answerText.color;
                        transparentColor.a = 0;
                        _answerText.color = _findText.color = transparentColor;
                        _answerText.DOFade(1, 0.5f);
                        _findText.DOFade(1, 0.5f);
                    }
                    _answerText.text = answer;
                };
        }
    }
}
