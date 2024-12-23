using DG.Tweening;
using TestAmayaQuiz.Data;
using UnityEngine;

namespace TestAmayaQuiz
{
    //Сервис для создания сетки ячеек
    public class CellsGeneratorService
    {
        public delegate void OnCellsCreatedDelegate(Cell[] cells, bool firstTime);
        public event OnCellsCreatedDelegate OnCellsCreated;

        private readonly Transform _cellsContainer;
        private readonly Cell _cellPrefab;

        private Cell[] _cells;
        private readonly LevelChangerService _levelChanger;

        public CellsGeneratorService(LevelChangerService levelChanger, Transform cellsContainer, Cell cellPrefab)
        {
            _cellsContainer = cellsContainer;
            _cellPrefab = cellPrefab;
            _levelChanger = levelChanger;
            _levelChanger.OnLevelChanged += GenerateCells;
        }

        public void GenerateCells(LevelData levelData, bool firstTime)
        {
            ClearCells();

            _cellsContainer.position = Vector3.zero;
            //Создается массив ячеек с размером, полученным из LevelData
            _cells = new Cell[levelData.Rows * levelData.Columns];
            int cellIndex = 0;

            
            //В цикле ячейки создаются и сдвигаются, создавая сетку
            for (int rowIndex = 0; rowIndex < levelData.Rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < levelData.Columns; columnIndex++)
                {
                    Cell newCell = GameObject.Instantiate(_cellPrefab, _cellsContainer);
                    Transform cellTransfrom = newCell.transform;
                    cellTransfrom.Translate(
                        Vector3.right * (newCell.Size.x * columnIndex * cellTransfrom.localScale.x) +
                        Vector3.down * (newCell.Size.y * rowIndex * cellTransfrom.localScale.y));

                    _cells[cellIndex] = newCell;
                    cellIndex++;
                }
            }

            //Контейнер для ячеек сдвигается на центр экрана
            _cellsContainer.Translate(_cellsContainer.position -
                (_cells[0].transform.position + _cells[_cells.Length - 1].transform.position) / 2);

            if (firstTime)
            {
                _cellsContainer.localScale = Vector3.zero;
                _cellsContainer.DOScale(1, 0.5f);
            }

            OnCellsCreated?.Invoke(_cells, firstTime);
        }

        public void ClearCells()
        {
            if (_cells != null && _cells.Length > 0)
            {
                foreach (Cell cell in _cells)
                {
                    GameObject.Destroy(cell.gameObject);
                }
            }
        }
    }
}
