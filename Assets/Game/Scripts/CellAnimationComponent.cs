using UnityEngine;
using DG.Tweening;
using System;

namespace TestAmayaQuiz
{
    public class CellAnimationComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private ParticleSystem _starsParticles;
        private Vector3 _localScale;

        private void Awake()
        {
            _localScale = _transform.localScale;
        }

        public void PlayWrongAnswerAnim()
        {
            _transform.DOPunchPosition(Vector3.right * 0.3f, 0.4f).SetEase(Ease.InBounce).OnComplete(() => _transform.DOLocalMoveX(0, 0.1f));
        }

        public void PlayRightAnswerAnimation(Action onAnimationEnded = null)
        {
            _transform.DOKill();
            _transform.DOScale(_localScale * 1.5f, 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() => onAnimationEnded?.Invoke());
            _starsParticles.Play();
        }
    }
}
