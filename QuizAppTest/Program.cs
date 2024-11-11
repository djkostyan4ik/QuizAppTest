namespace QuizAppTest;
internal class Program
{
    static void Main(string[] args)
    {
        var questions = new Question[]
        {
            new Question("What is the capital of Germany?",
            new string[] {"Paris","Berlin","London","Madrid"},1
            ),
            new Question("What is 2+2*2?",
            new string[] {"3","5","4","6"},3
            ),
            new Question("Who wrote 'Hamblet'?",
            new string[] {"Gouethe", "Austen", "Shakespeare", "Dickens"},2
            ),
        };

        var quiz = new Quiz(questions);
        quiz.StartQuiz();
        Console.ReadLine();
    }
}

