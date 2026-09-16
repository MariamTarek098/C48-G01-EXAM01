using System;

namespace Exam
{
    internal abstract class Exam
    {
        public int Time { get; set; }

        public int NumberOfQuestions { get; set; }

        public Question[] Questions { get; set; }

        public abstract void ShowExam();

        protected void ShowQuestion(Question question, bool showMark)
        {
            Console.WriteLine($"Question: {question.Header}");

            if (showMark)
            {
                Console.WriteLine($"Mark: ({question.Mark})");
            }

            Console.WriteLine(question.Body);

            foreach (Answer answer in question.AnswerList)
            {
                Console.WriteLine(
                    $"{answer.AnswerId}. {answer.AnswerText}"
                );
            }

            Console.WriteLine("--------------------------------------------------");

            int answerId;

            while (true)
            {
                Console.Write("Your Answer Id: ");

                if (!int.TryParse(Console.ReadLine(), out answerId))
                {
                    Console.WriteLine("Invalid answer. Please enter a number.");
                    continue;
                }

                bool validAnswer = false;

                foreach (Answer answer in question.AnswerList)
                {
                    if (answer.AnswerId == answerId)
                    {
                        question.UserAnswer = answer;
                        validAnswer = true;
                        break;
                    }
                }

                if (validAnswer)
                {
                    break;
                }

                Console.WriteLine("Invalid answer ID. Please try again.");
            }

            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }
}