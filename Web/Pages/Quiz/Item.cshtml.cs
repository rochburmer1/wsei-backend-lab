using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BackendLab01.Pages
{

    public class QuizModel : PageModel
    {
        private readonly IQuizUserService _userService;
        private readonly ILogger<QuizModel> _logger;

        public QuizModel(IQuizUserService userService, ILogger<QuizModel> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [BindProperty] public string Question { get; set; } = string.Empty;

        [BindProperty] public List<string> Answers { get; set; } = new();

        [BindProperty] public string UserAnswer { get; set; } = string.Empty;

        [BindProperty] public int QuizId { get; set; }

        [BindProperty] public int ItemId { get; set; }

        public IActionResult OnGet(int quizId, int itemId)
        {
            QuizId = quizId;
            ItemId = itemId;

            var quiz = _userService.FindQuizById(quizId);
            if (quiz == null)
            {
                _logger.LogWarning($"Quiz with ID {quizId} not found.");
                return RedirectToPage("Error"); // Możesz przekierować na stronę błędu
            }

            if (itemId - 1 >= quiz.Items.Count || itemId < 1)
            {
                _logger.LogWarning($"Invalid question ID {itemId} for quiz {quizId}.");
                return RedirectToPage("Error");
            }

            var quizItem = quiz.Items[itemId - 1];
            Question = quizItem.Question;
            Answers = new List<string>(quizItem.IncorrectAnswers) { quizItem.CorrectAnswer };
            Answers = Answers.OrderBy(_ => Guid.NewGuid()).ToList(); // Losowa kolejność odpowiedzi

            return Page();
        }

        public IActionResult OnPost()
        {
            var quiz = _userService.FindQuizById(QuizId);
            if (quiz == null || ItemId > quiz.Items.Count)
            {
                return RedirectToPage("Error");
            }

            // Jeśli to było ostatnie pytanie, przejdź do Summary
            if (ItemId == quiz.Items.Count)
            {
                return RedirectToPage("Summary", new { quizId = QuizId });
            }

            return RedirectToPage("Item", new { quizId = QuizId, itemId = ItemId + 1 });
        }
    }
}
