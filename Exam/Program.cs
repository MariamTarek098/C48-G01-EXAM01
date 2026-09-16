using System;
using System.Diagnostics;

namespace Exam
{
    internal class Program
    {
    
        static int ReadPositiveInt(string message)
        {
            int value;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine(
                    "Invalid input. Please enter a positive integer:"
                );
            }
        }

        // =========================
        // Read Choice Between Range
        // =========================

        static int ReadChoice(string message, int min, int max)
        {
            int choice;

            while (true)
            {
                Console.Write(message);

                if (
                    int.TryParse(Console.ReadLine(), out choice)
                    && choice >= min
                    && choice <= max
                )
                {
                    return choice;
                }

                Console.WriteLine(
                    $"Invalid choice. Please enter a number from {min} to {max}:"
                );
            }
        }

        // =========================
        // Create True/False Question
        // =========================

        static Question CreateTrueFalseQuestion()
        {
            Console.WriteLine("True / False Question");

            Console.Write("Please Enter Question Body: ");
            string body = Console.ReadLine();

            int mark = ReadPositiveInt(
                "Please Enter Question Mark: "
            );

            int correctAnswerId = ReadChoice(
                "Please Enter Right Answer Id (1 for True | 2 for False): ",
                1,
                2
            );

            Answer trueAnswer = new Answer
            {
                AnswerId = 1,
                AnswerText = "True"
            };

            Answer falseAnswer = new Answer
            {
                AnswerId = 2,
                AnswerText = "False"
            };

            Question question = new TrueFalseQuestion(
                "True / False Question",
                body,
                mark
            );

            question.AnswerList = new Answer[]
            {
                trueAnswer,
                falseAnswer
            };

            if (correctAnswerId == 1)
            {
                question.RightAnswer = trueAnswer;
            }
            else
            {
                question.RightAnswer = falseAnswer;
            }

            return question;
        }

        // =========================
        // Create MCQ Question
        // =========================

        static Question CreateMCQQuestion()
        {
            Console.WriteLine("Choose One Answer Question");

            Console.Write("Please Enter Question Body: ");
            string body = Console.ReadLine();

            int mark = ReadPositiveInt(
                "Please Enter Question Mark: "
            );

            int numberOfChoices = ReadPositiveInt(
                "Please Enter Number of Choices (3 or 4): "
            );

            Answer[] answers = new Answer[numberOfChoices];

            Console.WriteLine("Please Enter Choices:");

            for (int i = 0; i < numberOfChoices; i++)
            {
                Console.Write(
                    $"Please Enter Choice Number {i + 1}: "
                );

                string answerText = Console.ReadLine();

                answers[i] = new Answer
                {
                    AnswerId = i + 1,
                    AnswerText = answerText
                };
            }

            int correctAnswerId = ReadChoice(
                "Please Enter Right Answer Id: ",
                1,
                numberOfChoices
            );

            Question question = new MCQQuestion(
                "Choose One Answer Question",
                body,
                mark
            );

            question.AnswerList = answers;

            foreach (Answer answer in answers)
            {
                if (answer.AnswerId == correctAnswerId)
                {
                    question.RightAnswer = answer;
                    break;
                }
            }

            return question;
        }

        // =========================
        // Create Question  Final
        // =========================

        static Question CreateFinalQuestion()
        {
            int questionType = ReadChoice(
                "Please Choose Question Type (1 for True/False | 2 for MCQ): ",
                1,
                2
            );

            if (questionType == 1)
            {
                return CreateTrueFalseQuestion();
            }

            return CreateMCQQuestion();
        }

        // =========================
        // Create Question Practical
        // =========================

        static Question CreatePracticalQuestion()
        {
            return CreateMCQQuestion();
        }


        static void Main(string[] args)
        {
            Subject subject = new Subject();

            Console.WriteLine(
                "Please Enter Type of Exam (1 for Practical | 2 for Final):"
            );

            int examChoice = ReadChoice(
                "",
                1,
                2
            );

            ExamType examType;

            if (examChoice == 1)
            {
                examType = ExamType.Practical;
            }
            else
            {
                examType = ExamType.Final;
            }

            Exam exam = subject.CreateExam(examType);

            exam.Time = ReadPositiveInt(
                "Please Enter the Time of Exam in Minutes: "
            );

            exam.NumberOfQuestions = ReadPositiveInt(
                "Please Enter the Number of Questions: "
            );

            exam.Questions = new Question[exam.NumberOfQuestions];

            // =========================
            // Create Questions
            // =========================

            for (int i = 0; i < exam.NumberOfQuestions; i++)
            {
                Console.WriteLine();

                if (exam is PracticalExam)
                {
                    Console.WriteLine(
                        $"--- Practical Exam: Creating Question {i + 1} ---"
                    );

                    exam.Questions[i] = CreatePracticalQuestion();
                }
                else
                {
                    Console.WriteLine(
                        $"--- Final Exam: Creating Question {i + 1} ---"
                    );

                    exam.Questions[i] = CreateFinalQuestion();
                }

                Console.WriteLine("==================================================");
            }

            // =========================
            // Start Exam
            // =========================

            Console.WriteLine();

            Console.Write("Do You Want To Start The Exam (y | n): ");
            string startExam = Console.ReadLine();

            if (startExam.ToLower() != "y")
            {
                Console.WriteLine("Exam cancelled.");
                return;
            }

            Console.Clear();

            Stopwatch stopwatch = Stopwatch.StartNew();

            exam.ShowExam();

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine(
                $"Time = {stopwatch.Elapsed}"
            );
        }
    }
}