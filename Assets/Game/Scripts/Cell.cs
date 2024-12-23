using System;
using UnityEngine;

namespace TestAmayaQuiz
{
    public class Cell : MonoBehaviour
    {
        public string Answer { get; private set; }
        public Vector2 Size => _collider.size;

        [SerializeField]
        private CellAnimationComponent _cellAnimationComponent;
        [SerializeField]
        private SpriteRenderer _imageRenderer;
        [SerializeField]
        private BoxCollider2D _collider;

        public void SetData(string answer, Sprite sprite, float rotationAngle = 0)
        {
            Answer = answer;
            _imageRenderer.sprite = sprite;
            _imageRenderer.transform.localEulerAngles = Vector3.zero + new Vector3(0, 0, rotationAngle);
        }

        public void PlayWrongAnswerAnim()
        {
            if (_cellAnimationComponent != null)
            {
                _cellAnimationComponent.PlayWrongAnswerAnim();
            }
        }

        public void PlayRightAnswerAnim(Action onAnimationComplete = null)
        {
            if (_cellAnimationComponent != null)
            {
                _cellAnimationComponent.PlayRightAnswerAnimation(onAnimationComplete);
            }
        }
    }
}
