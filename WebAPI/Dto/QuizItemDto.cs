using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Models.QuizAggregate;

namespace BackendLab01.Dto
{
    public class QuizItemDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }

        public QuizItemDto(int id, string question, List<string> options)
        {
            Id = id;
            Question = question;
            Options = options;
        }
        
        public static QuizItemDto of(QuizItem quiz)
        {
            List<string> allOptions = new List<string>(quiz.IncorrectAnswers) { quiz.CorrectAnswer };
            
            Random random = new Random();
            allOptions = allOptions.OrderBy(_ => random.Next()).ToList();

            return new QuizItemDto(quiz.Id, quiz.Question, allOptions);
        }
    }
}