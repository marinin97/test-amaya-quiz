using System.Collections.Generic;
using DG.Tweening;
using TestAmayaQuiz.Data;
using UnityEngine.UI;

namespace TestAmayaQuiz
{
    public class LevelChangerService
    {
        public delegate void OnLevelChangedDelegate(LevelData levelData, bool firstLevel = false);
        public event OnLevelChangedDelegate OnLevelChanged;

        private readonly List<LevelData> _levelDataList;
        private int _levelIndexToLoad;
        private readonly Image _loadingScreen;
        private readonly Button _reloadButton;

        public LevelChangerService(List<LevelData> levelDataList, Image loadingScreen, Button reloadButton)
        {
            _levelDataList = levelDataList;
            _loadingScreen = loadingScreen;
            _reloadButton = reloadButton;
            _reloadButton.onClick.AddListener(() =>
                {
                    Sequence sequence = DOTween.Sequence();
                    sequence.Append(_loadingScreen.DOFade(1, 0.3f).OnComplete(() => ChangeLevel(0)));
                    sequence.Append(_loadingScreen.DOFade(0, 0.3f));
                    sequence.Play();
                    _reloadButton.transform.DOScale(0f, 0.3f);
                });
        }

        public void ChangeLevel(int? levelIndexToLoad = null)
        {
            if (levelIndexToLoad != null)
            {
                _levelIndexToLoad = levelIndexToLoad.Value;
            }
            if (_levelIndexToLoad >= _levelDataList.Count)
            {
                _loadingScreen.DOFade(0.7f, 0.5f);
                _reloadButton.transform.DOScale(1, 0.5f);
                return;
            }
            OnLevelChanged?.Invoke(_levelDataList[_levelIndexToLoad], _levelIndexToLoad == 0);
            _levelIndexToLoad++;
        }
    }
}
