using Microsoft.AspNetCore.Mvc.RazorPages;
namespace BackendLab01.Pages;

public class SummaryModel : PageModel
{
    private readonly IQuizUserService _userService;
    public int CorrectAnswers { get; private set; }
    public int TotalQuestions { get; private set; }

    public SummaryModel(IQuizUserService userService)
    {
        _userService = userService;
    }

    public void OnGet(int quizId)
    {
        int userId = 1; // Stała wartość na razie
        CorrectAnswers = _userService.CountCorrectAnswersForQuizFilledByUser(quizId, userId);

        var quiz = _userService.FindQuizById(quizId);
        TotalQuestions = quiz?.Items.Count ?? 0;
    }
}