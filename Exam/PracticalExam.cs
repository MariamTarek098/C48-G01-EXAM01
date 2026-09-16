using System;

namespace Exam
{
    internal class PracticalExam : Exam
    {
        public override void ShowExam()
        {
            Console.WriteLine("================ Practical Exam ================");
            Console.WriteLine();

            int questionNumber = 1;

            foreach (Question question in Questions)
            {
                Console.WriteLine(
                    $"Question ({questionNumber}):"
                );

                ShowQuestion(question, false);

                questionNumber++;
            }

            Console.WriteLine("================ Right Answers ================");

            questionNumber = 1;

            foreach (Question question in Questions)
            {
                Console.WriteLine($"Q{questionNumber}) {question.Body}");

                Console.WriteLine(
                    $"   Your Answer  : {question.UserAnswer.AnswerText}"
                );

                Console.WriteLine(
                    $"   Right Answer : {question.RightAnswer.AnswerText}"
                );

                Console.WriteLine("--------------------------------------------------");

                questionNumber++;
            }
        }
    }
}