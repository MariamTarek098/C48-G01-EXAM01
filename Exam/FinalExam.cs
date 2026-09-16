using System;

namespace Exam
{
    internal class FinalExam : Exam
    {
        public override void ShowExam()
        {
            int totalGrade = 0;
            int maxGrade = 0;

            Console.WriteLine("================ Final Exam ================");
            Console.WriteLine();

            int questionNumber = 1;

            foreach (Question question in Questions)
            {
                Console.WriteLine($"Question ({questionNumber}):");

                ShowQuestion(question, true);

                maxGrade += question.Mark;

                if (question.UserAnswer == question.RightAnswer)
                {
                    totalGrade += question.Mark;
                }

                questionNumber++;
            }

            Console.WriteLine("================ Exam Results ================");

            questionNumber = 1;

            foreach (Question question in Questions)
            {
                Console.WriteLine(
                    $"Q{questionNumber}) {question.Body}: {question.UserAnswer.AnswerText}"
                );

                questionNumber++;
            }

            Console.WriteLine();
            Console.WriteLine(
                $"Your Grade is {totalGrade} from {maxGrade}"
            );
        }
    }
}