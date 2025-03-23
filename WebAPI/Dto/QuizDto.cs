using ApplicationCore.Models.QuizAggregate;

namespace BackendLab01.Dto
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<QuizItemDto> Items { get; set; }

        public QuizDto(int id, string title, List<QuizItemDto> items)
        {
            Id = id;
            Title = title;
            Items = items;
        }

        public static QuizDto of(Quiz quiz)
        {
            return new QuizDto(
                quiz.Id,
                quiz.Title,
                quiz.Items.Select(QuizItemDto.of).ToList() // Konwersja każdego elementu na QuizItemDto
            );
        }
    }
}