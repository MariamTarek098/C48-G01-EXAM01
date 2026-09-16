using System;

namespace Exam
{
    internal class Subject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public Exam Exam { get; set; }

        public Exam CreateExam(ExamType examType)
        {
            if (examType == ExamType.Final)
            {
                Exam = new FinalExam();
            }
            else
            {
                Exam = new PracticalExam();
            }

            return Exam;
        }
    }
}
