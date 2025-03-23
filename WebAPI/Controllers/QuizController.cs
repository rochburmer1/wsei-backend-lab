using Microsoft.AspNetCore.Mvc;
using BackendLab01.Dto;
using BackendLab01;
using ApplicationCore.Models.QuizAggregate;

namespace BackendLab01.Controllers
{
    [ApiController]
    [Route("api/v1/quizzes")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizUserService _service;

        public QuizController(IQuizUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            Quiz? quiz = _service.FindQuizById(id);

            if (quiz != null)
            {
                QuizDto quizDto = QuizDto.of(quiz);
                return Ok(quizDto); // Zwraca 200 OK z quizDto
            }

            return NotFound(); // Zwraca 404 Not Found, jeśli quiz nie istnieje
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindQuizById(int id)
        {
            var quiz = _service.FindQuizById(id);

            if (quiz != null)
            {
                var quizDto = QuizDto.of(quiz);
                return Ok(quizDto);
            }

            return NotFound();
        }
        [HttpGet]
        public IEnumerable<QuizDto> FindAll()
        {
            var quizzes = _service.FindAllQuizzes();
            return quizzes.Select(QuizDto.of);
        }
        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public IActionResult SaveAnswer(int quizId, int itemId, [FromBody] QuizItemAnswerDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid request body");
            }

            _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);

            return NoContent(); // 204 No Content - odpowiedź została zapisana
        }
        [HttpGet]
        [Route("{quizId}/users/{userId}/result")]
        public ActionResult<QuizUserResultDto> GetUserQuizResult(int quizId, int userId)
        {
            int correctAnswers = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId);

            var resultDto = new QuizUserResultDto(userId, quizId, correctAnswers);

            return Ok(resultDto);
        }

    }
}