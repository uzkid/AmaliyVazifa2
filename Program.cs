using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a task to run (1, 2, 3, or 4):");
        Console.WriteLine("1 - Time Calculator");
        Console.WriteLine("2 - Age Category");
        Console.WriteLine("3 - Average Score");
        Console.WriteLine("4 - Guess the Number Game");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                TimeCalculator();
                break;
            case "2":
                AgeCategory();
                break;
            case "3":
                AverageScore();
                break;
            case "4":
                GuessTheNumber();
                break;
            default:
                Console.WriteLine("Invalid choice. Please run the program again.");
                break;
        }
    }

    static void TimeCalculator()
    {
        Console.Write("Enter the number of minutes: ");
        int minutes = int.Parse(Console.ReadLine());

        int hours = minutes / 60; 
        int remainingMinutes = minutes % 60; 

        Console.WriteLine($"Time: {hours}:{remainingMinutes:D2}");
    }

    static void AgeCategory()
    {
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        string category;

        if (age >= 0 && age <= 12)
        {
            category = "Child";
        }
        else if (age >= 13 && age <= 19)
        {
            category = "Teenager";
        }
        else if (age >= 20 && age <= 59)
        {
            category = "Adult";
        }
        else if (age >= 60)
        {
            category = "Senior";
        }
        else
        {
            category = "Invalid age.";
        }

        Console.WriteLine($"You are classified as: {category}");
    }

    static void AverageScore()
    {
        Console.Write("Enter your first subject score (0-100): ");
        int score1 = int.Parse(Console.ReadLine());
        Console.Write("Enter your second subject score (0-100): ");
        int score2 = int.Parse(Console.ReadLine());
        Console.Write("Enter your third subject score (0-100): ");
        int score3 = int.Parse(Console.ReadLine());

        double average = (score1 + score2 + score3) / 3.0;

        string result = average switch
        {
            >= 80 and <= 100 => "Excellent",
            >= 60 and < 80 => "Good",
            >= 40 and < 60 => "Satisfactory",
            < 40 => "Unsatisfactory",
            _ => "Invalid input"
        };

        Console.WriteLine($"Your average score is {average:F2}, which is: {result}");
    }

    static void GuessTheNumber()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int guess;
        Console.WriteLine("Guess the number between 1 and 100!");

        do
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());

            if (guess > secretNumber)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the correct number.");
            }
        } while (guess != secretNumber);
    }
}
