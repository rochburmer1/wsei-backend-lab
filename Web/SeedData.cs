using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            
            //TODO Utwórz trzy pytania typu QuizItem
            //TODO Dodaj je do quizItemRepo
            //TODO Utwórz obiekt klasy Quiz z kolekcją pytań dodanych do quizItemRepo
            //TODO Dodaj Quiz do quizRepo
            
            QuizItem item1 = new QuizItem(id:1, question: "2+4", correctAnswer: "6", incorrectAnswers: ["5","7", "8"]);
            QuizItem item2 = new QuizItem(id:1, question: "2*4", correctAnswer: "8", incorrectAnswers: ["4","6", "9"]);
            QuizItem item3 = new QuizItem(id:1, question: "8/2", correctAnswer: "4", incorrectAnswers: ["5","7", "8"]);
            quizItemRepo?.Add(item1);
            quizItemRepo?.Add(item2);
            quizItemRepo?.Add(item3);
            Quiz quiz = new(id: 1, title: "Matematyka", items: [item1, item2, item3]);
            quizRepo?.Add(quiz);
            
            QuizItem geoItem1 = quizItemRepo.Add(new QuizItem(0, "Stolica Francji?", ["Berlin", "Madryt", "Londyn"], "Paryż"));
            QuizItem geoItem2 = quizItemRepo.Add(new QuizItem(0, "Największy kontynent?", ["Europa", "Ameryka Północna", "Australia"], "Azja"));
            QuizItem geoItem3 = quizItemRepo.Add(new QuizItem(0, "Morze Bałtyckie jest...?", ["Słone", "Słodkie", "Kwaśne"], "Słone"));
            quizItemRepo?.Add(geoItem1);
            quizItemRepo?.Add(geoItem2);
            quizItemRepo?.Add(geoItem3);
            // Tworzenie quizu "Geografia"
            Quiz geoQuiz = new(id:0, title: "Geografia", items: [geoItem1, geoItem2, geoItem3]);
        }
    }
}