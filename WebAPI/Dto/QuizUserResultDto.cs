namespace WebAPI.Dto
{
    public class QuizAnswerResultDto
    {
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public int CorrectAnswersCount { get; set; }
    }
}