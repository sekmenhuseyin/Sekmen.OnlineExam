using Microsoft.EntityFrameworkCore;
using Sekmen.OnlineExam.Exams;
using System.Linq;

namespace Sekmen.OnlineExam.EntityFrameworkCore.Seed.Host
{
    public class DefaultExamCreator
    {
        private readonly OnlineExamDbContext _context;

        public DefaultExamCreator(OnlineExamDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateExams();
        }

        private void CreateExams()
        {
            //check exams
            var exam = _context.Exams.IgnoreQueryFilters().AsNoTracking().FirstOrDefault();
            if (exam == null)
            {
                exam = new Exam("Deneme Sınavı", "Açıklama", 0);
                _context.Exams.Add(exam);
                _context.SaveChanges();

                //Questions
                var question1 = new Question(exam, "Select 1", 1);
                _context.Questions.Add(question1);
                var question2 = new Question(exam, "Select 2", 2);
                _context.Questions.Add(question2);
                _context.SaveChanges();

                //Answers
                _context.Answers.Add(new Answer(question1, "1", true, 1));
                _context.Answers.Add(new Answer(question1, "2", false, 2));
                _context.Answers.Add(new Answer(question1, "3", false, 3));
                _context.Answers.Add(new Answer(question1, "4", false, 4));
                _context.Answers.Add(new Answer(question2, "1", false, 1));
                _context.Answers.Add(new Answer(question2, "2", true, 2));
                _context.Answers.Add(new Answer(question2, "3", false, 3));
                _context.Answers.Add(new Answer(question2, "4", false, 4));
                _context.SaveChanges();
            }
        }
    }
}
