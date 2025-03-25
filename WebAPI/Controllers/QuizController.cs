using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.api.v1.quizzes
{
    [ApiController]
    [Route("api/v1/quizzes")]
    public class QuizController : Controller
    {
        IQuizUserService _service;
        public QuizController(IQuizUserService quizUserService)
        {
            _service = quizUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            var quiz = _service.FindQuizById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            QuizDto quizDto = QuizDto.of(quiz);
            return Ok(quizDto);
        }
        [HttpGet]
        public IEnumerable<QuizDto> FindAll()
        {
            return _service.FindAllQuizzes().Select(QuizDto.of);
        }
        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public void SaveAnswer([FromBody] QuizItemAnswerDto dto, int quizId, int itemId)
        {
            _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);
        }
        [HttpGet]
        [Route("{quizId}/users/{userId}")]
        public ActionResult<QuizAnswerResultDto> GetCorrectAnswersForUser(int quizId, int userId)
        {
            int result = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId);

            QuizAnswerResultDto quizAnswerResultDto = new QuizAnswerResultDto
            {
                QuizId = quizId,
                UserId = userId,
                CorrectAnswersCount = result
            };

            return Ok(quizAnswerResultDto);
        }
    }
}