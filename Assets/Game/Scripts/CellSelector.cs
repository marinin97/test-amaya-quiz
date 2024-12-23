using System;
using TestAmayaQuiz.Data;
using TestAmayaQuiz.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;


//Класс для выбора ячеек по нажатию
namespace TestAmayaQuiz
{
    public class CellSelector : IDisposable
    {
        private readonly Controls _controls;
        private readonly LevelChangerService _levelChangerService;
        private readonly AnswerComparerService _answererComparerService;
        private readonly Camera _camera;
        private readonly RaycastHit2D[] _hits = new RaycastHit2D[1];
        private Action _onAnimationComplete;

        public CellSelector(LevelChangerService levelChangerService, AnswerComparerService answerComparerService, Camera camera)
        {
            _levelChangerService = levelChangerService;
            _answererComparerService = answerComparerService;
            _camera = camera;

            _controls = new Controls();
            _controls.Enable();

            _controls.PlayerMap.Select.performed += CheckCell;
        }

        private void CheckCell(InputAction.CallbackContext context)
        {
            Ray ray = _camera.ScreenPointToRay(_controls.PlayerMap.Position.ReadValue<Vector2>());
            Physics2D.RaycastNonAlloc(ray.origin, ray.direction, _hits, Mathf.Infinity);
            if (_hits.Length > 0)
            {
                var selectedCell = _hits[0].collider.GetComponent<Cell>();
                if (_answererComparerService.IsRightAnswer(selectedCell.Answer))
                {
                    _onAnimationComplete += ChangeLevel;
                    selectedCell.PlayRightAnswerAnim(_onAnimationComplete);
                    //Возможность нажатия отключается до смены уровня во избежания многократного выбора
                    _controls.Disable();
                }
                else
                {
                    selectedCell.PlayWrongAnswerAnim();
                }
            }
        }

        private void ChangeLevel()
        {
            _onAnimationComplete -= ChangeLevel;
            _levelChangerService.OnLevelChanged += OnLevelChanged;
            _levelChangerService.ChangeLevel();
        }
        private void OnLevelChanged(LevelData _, bool firstLevel = false)
        {
            _levelChangerService.OnLevelChanged -= OnLevelChanged;
            _controls.Enable();
        }

        public void Dispose()
        {
            _controls?.Dispose();
        }
    }
}
