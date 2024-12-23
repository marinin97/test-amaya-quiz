namespace TestAmayaQuiz
{
    public class AnswerComparerService
    {
        private string _rightAnswer;

        public AnswerComparerService(AnswerChooseService answerChooseService)
        {
            answerChooseService.OnAnswerChosen += (answer, _, firstTime) => _rightAnswer = answer;
        }

        public bool IsRightAnswer(string selectedAnswer) => _rightAnswer.Equals(selectedAnswer);
    }
}
