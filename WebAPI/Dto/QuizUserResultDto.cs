namespace BackendLab01.Dto
{
    public class QuizUserResultDto
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int CorrectAnswersCount { get; set; }

        public QuizUserResultDto(int userId, int quizId, int correctAnswersCount)
        {
            UserId = userId;
            QuizId = quizId;
            CorrectAnswersCount = correctAnswersCount;
        }
    }
}