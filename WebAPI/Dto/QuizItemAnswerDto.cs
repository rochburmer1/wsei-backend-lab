namespace BackendLab01.Dto
{
    public class QuizItemAnswerDto
    {
        public int UserId { get; set; }
        public string Answer { get; set; }

        public QuizItemAnswerDto(int userId, string answer)
        {
            UserId = userId;
            Answer = answer;
        }
    }
}