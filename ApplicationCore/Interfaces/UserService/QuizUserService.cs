using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using ApplicationCore.Models.QuizAggregate;
using ApplicationCore.Specifications;

namespace BackendLab01;

public class QuizUserService: IQuizUserService
{
    private readonly IGenericRepository<Quiz, int> quizRepository;
    private readonly IGenericRepository<QuizItem, int> itemRepository;
    private readonly IGenericRepository<QuizItemUserAnswer, string> answerRepository;

    public QuizUserService(IGenericRepository<Quiz, int> quizRepository, IGenericRepository<QuizItemUserAnswer, string> answerRepository, IGenericRepository<QuizItem, int> itemRepository)
    {
        this.quizRepository = quizRepository;
        this.answerRepository = answerRepository;
        this.itemRepository = itemRepository;
    }

    public Quiz CreateAndGetQuizRandom(int count)
    {
        throw new NotImplementedException();
    }

    public Quiz? FindQuizById(int id)
    {
        return quizRepository.FindById(id);
    }

    public void SaveUserAnswerForQuiz(int quizId, int userId, int quizItemId, string answer)
    {
        QuizItem? item = itemRepository.FindById(quizItemId);
        if (item == null)
        {
            throw new InvalidOperationException($"Nie znaleziono pytania o ID {quizItemId}.");
        }

        var userAnswer = new QuizItemUserAnswer(quizItem: item, userId: userId, answer: answer, quizId: quizId);
        answerRepository.Add(userAnswer);
    }
    public List<Quiz> GetAllQuizzes()
    {
        return quizRepository.FindAll().ToList();
    }
    public List<QuizItemUserAnswer> GetUserAnswersForQuiz(int quizId, int userId)
    {
        // return answerRepository.FindAll()
        //     .Where(x => x.QuizId == quizId)
        //     .Where(x => x. UserId == userId)
        //     .ToList();
        var answers = answerRepository.FindBySpecification(new QuizItemsForQuizIdFilledByUser(quizId, userId)).ToList();
        
        foreach(var answer in answers)
        {
            Console.WriteLine($"QuizId: {answer.QuizId}, UserId: {answer.UserId}, Answer: {answer.Answer}, IsCorrect: {answer.IsCorrect()}");
        }
    
        return answers; 
    }
    public int CountCorrectAnswersForQuizFilledByUser(int quizId, int userId)
    {
        var userAnswers = GetUserAnswersForQuiz(quizId, userId);
        return userAnswers.Count(answer => answer.IsCorrect());
    }
}