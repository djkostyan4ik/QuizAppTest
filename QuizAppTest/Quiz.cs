﻿namespace QuizAppTest;
internal class Quiz
{

    private Question[] _questions;
    private int _score;

    public Quiz(Question[] questions)
    {
        _questions = questions;
        _score = 0;
    }

    public void StartQuiz() 
    {
        Console.WriteLine("Welcome to the Quiz!");
        int questionNumber = 1; // to display question numbers

        foreach (Question question in _questions) 
        {

            Console.WriteLine($"Question {questionNumber++}");
            DisplaQuestions(question);

            int userChoice = GetUserChoice();

            if (question.IsCorrectAnswer(userChoice))
            {
                Console.WriteLine("Correct!");
                _score++;
            }
            else 
            {
                Console.WriteLine($"Incorrect. The correct answer is: {question.Answers[question.CorrectAnswerIndex]}");
            }

        }

        DisplayResults();

    }

    private void DisplayResults() 
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                 Results                                 ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine($"Quiz finished. Your score is: {_score} out of {_questions.Length}.");

        double percentage = (double)_score / _questions.Length;

        if (percentage >= 0.8)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Excellent work!");
        }
        else if (percentage >= 0.5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Good effort!");
        }
        else 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Keep practicing!");
        }
        Console.ResetColor();

    }

    private void DisplaQuestions(Question question)
    {

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                 Question                                ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine(question.QuestionText);

        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("   ");
            Console.Write(i + 1);
            Console.ResetColor();
            Console.WriteLine($". {question.Answers[i]}");
        }

    }

    private int GetUserChoice() 
    {

        Console.Write("Your answer (number): ");
        string input = Console.ReadLine();
        int choice = 0;
        while (!int.TryParse(input, out choice) || choice < 1 || choice > 4) 
        {
            Console.Write("Invalid choice. Please enter a number between 1 and 4: ");
            input = Console.ReadLine();
        }

        return choice - 1; // adjust to 0-indexed array

    }

}
