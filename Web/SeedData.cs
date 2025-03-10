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
            QuizItem item2 = new QuizItem(id:2, question: "2*4", correctAnswer: "8", incorrectAnswers: ["4","6", "9"]);
            QuizItem item3 = new QuizItem(id:3, question: "8/2", correctAnswer: "4", incorrectAnswers: ["5","7", "8"]);
            quizItemRepo?.Add(item1);
            quizItemRepo?.Add(item2);
            quizItemRepo?.Add(item3);
            Quiz quiz = new(id: 1, title: "Matematyka", items: [item1, item2, item3]);
            quizRepo?.Add(quiz);
            
            QuizItem geoItem1 = new QuizItem(id:4, "Stolica Cypru?", ["Berlin", "Madryt", "Londyn"], "Nikozja");
            QuizItem geoItem2 = new QuizItem(id:5, "Największy kontynent?", ["Europa", "Ameryka Północna", "Australia"], "Azja");
            QuizItem geoItem3 = new QuizItem(id:6, "Morze Bałtyckie jest...?", ["Słone", "Słodkie", "Kwaśne"], "Słone");
            quizItemRepo?.Add(geoItem1);
            quizItemRepo?.Add(geoItem2);
            quizItemRepo?.Add(geoItem3);
            Quiz geoQuiz = new(id:0, title: "Geografia", items: [geoItem1, geoItem2, geoItem3]);
            quizRepo?.Add(geoQuiz);
            
            QuizItem histItem1 = new QuizItem(7, "Katarzyna II Wielka była cesarzową?", ["Prus", "Węgier", "Austrii"], "Rosji");
            QuizItem histItem2 = new QuizItem(8, "W którym wieku żył Gall Anonim?", ["XVI", "IX", "XII"], "XI");
            QuizItem histItem3 = new QuizItem(9, "Z którymi zwierzętami Hannibal przeprawił się przez Alpy?", ["Lwami", "Tygrysami", "Wielbłądami"], "Słoniami");
            quizItemRepo?.Add(histItem1);
            quizItemRepo?.Add(histItem2);
            quizItemRepo?.Add(histItem3);
            Quiz histQuiz = new(id:2, title: "Geografia", items: [geoItem1, geoItem2, geoItem3]);
            quizRepo?.Add(histQuiz);
        }
    }
}