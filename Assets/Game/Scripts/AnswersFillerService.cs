using System.Collections.Generic;
using System.Linq;
using TestAmayaQuiz.Data;
using UnityEngine;


//Сервис для заполнения ячеек вариантами ответов из набора данных
namespace TestAmayaQuiz
{
    public class AnswersFillerService
    {
        private readonly AnswerChooseService _answerChooseService;
        private readonly CellsGeneratorService _cellsGeneratorService;

        private string _rightAnswer;
        private AnswersData _answerData;

        public AnswersFillerService(AnswerChooseService answerChooseService, CellsGeneratorService cellsGeneratorService)
        {
            _answerChooseService = answerChooseService;
            _cellsGeneratorService = cellsGeneratorService;

            _cellsGeneratorService.OnCellsCreated += FillCells;
            _answerChooseService.OnAnswerChosen += (answer, answerData, _) =>
            {
                _rightAnswer = answer;
                _answerData = answerData;
            };

        }
        private void FillCells(Cell[] cells, bool _)
        {
            Dictionary<string, SpriteWithRotation> answersDict = _answerData.AnswersDict;
            //Выбираем случайную ячейку и заполняем ее правильным ответом
            int rightAnswerCellIndex = Random.Range(0, cells.Length);
            cells[rightAnswerCellIndex].SetData(_rightAnswer, answersDict[_rightAnswer].Sprite, answersDict[_rightAnswer].RotationAngle);

            //Создаем словарь использованных вариантов и добавляем туда правильный ответ
            Dictionary<string, SpriteWithRotation> usedAnswers = new Dictionary<string, SpriteWithRotation>();
            usedAnswers[_rightAnswer] = answersDict[_rightAnswer];

            
            //Заполняем оставшиеся ячеками вариантами ответов, которые не были использованы. Поворачиваем спрайты на заданный угол
            for (int i = 0; i < cells.Length; i++)
            {
                if (i == rightAnswerCellIndex)
                {
                    continue;
                }

                var remainedAnswers = answersDict.Except(usedAnswers);
                var answerVariant = remainedAnswers.ElementAt(Random.Range(0, remainedAnswers.Count()));
                cells[i].SetData(answerVariant.Key, answerVariant.Value.Sprite, answerVariant.Value.RotationAngle);
                usedAnswers[answerVariant.Key] = answerVariant.Value;
            }

            usedAnswers.Clear();
        }
    }
}