using Microsoft.AspNetCore.Mvc.RazorPages;
using 
namespace BackendLab01.Pages;

public class List : PageModel
{
    private readonly IQuizUserService _quizService;

    public List<Quiz> Quizzes { get; private set; } = new List<Quiz>();
    
    public List(IQuizUserService quizService)
    {
        _quizService = quizService ?? throw new ArgumentNullException(nameof(quizService));
    }
    
    public void OnGet()
    {
        Quizzes = _quizService.GetAllQuizzes();
    }
}