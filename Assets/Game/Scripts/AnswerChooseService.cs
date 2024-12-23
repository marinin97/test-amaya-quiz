using System.Collections.Generic;
using System.Linq;
using TestAmayaQuiz.Data;
using UnityEngine;

//Это сервис для выбора задания на каждый уровень
namespace TestAmayaQuiz
{
    public class AnswerChooseService
    {
        public delegate void OnAnswerChosenDelegate(string answer, AnswersData answersData, bool firstTime);
        public event OnAnswerChosenDelegate OnAnswerChosen;

        private readonly CellsGeneratorService _cellsGenerator;
        private readonly Dictionary<AnswersData, Dictionary<string, SpriteWithRotation>> _usedAnswersDict;

        public AnswerChooseService(List<AnswersData> answersDataList, CellsGeneratorService cellsGenerator)
        {
            _cellsGenerator = cellsGenerator;
            _usedAnswersDict = new Dictionary<AnswersData, Dictionary<string, SpriteWithRotation>>();

            foreach (var answersData in answersDataList)
            {
                _usedAnswersDict[answersData] = new Dictionary<string, SpriteWithRotation>();
            }

            _cellsGenerator.OnCellsCreated += ChooseAnswer;
        }

        private void ChooseAnswer(Cell[] cells, bool firstTime)
        {
            //Наборы данных фильтруются и остаются те, которые соответствуют двум условиям:
            //1) в наборе еще должны оставаться не использованные ранее ответы
            //2) общего количества ответов в наборе должно хватать для всех ячеек 
            var remainedAnswersDatas =
                _usedAnswersDict.Where(pair => pair.Key.AnswersDict.Count >= cells.Length && pair.Key.AnswersDict.Count > pair.Value.Count);
            //Выбирается случайный набор
            var randomAnswersData = remainedAnswersDatas.ElementAt(Random.Range(0, remainedAnswersDatas.Count()));
            //Исключаются ответы, которые были ранее использованы в наборе
            var remainedAnswers = randomAnswersData.Key.AnswersDict.Except(randomAnswersData.Value);
            //Выбирается случайный ответ и добавляется в словарь использованных
            var randomAnswer = remainedAnswers.ElementAt(Random.Range(0, remainedAnswers.Count()));
            _usedAnswersDict[randomAnswersData.Key].Add(randomAnswer.Key, randomAnswer.Value);
            OnAnswerChosen?.Invoke(randomAnswer.Key, randomAnswersData.Key, firstTime);
        }
    }
}
