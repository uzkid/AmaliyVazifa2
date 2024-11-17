using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a program:");
        Console.WriteLine("1. Check if a number is prime");
        Console.WriteLine("2. Find divisors of a number between 2 and 10");
        Console.WriteLine("3. Calculate the power of a number");
        Console.WriteLine("4. Calculate the sum of multiple values");
        Console.WriteLine("5. Check if a number is an Armstrong number");
        Console.WriteLine("6. Find the number of proper divisors of a number");
        Console.Write("Enter the program number: ");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (IsPrime(number))
                    Console.WriteLine("Prime");
                else
                    Console.WriteLine("Not Prime");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        else if (choice == "2")
        {
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                List<int> divisors = FindDivisors(number);
                Console.WriteLine("Divisors: " + string.Join(", ", divisors));
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        else if (choice == "3")
        {
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int baseNumber))
            {
                Console.Write("Enter the power: ");
                if (int.TryParse(Console.ReadLine(), out int power) && power >= 0)
                {
                    Console.WriteLine($"Result: {Math.Pow(baseNumber, power)}");
                }
                else
                {
                    Console.WriteLine("Invalid input for power.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        else if (choice == "4")
        {
            Console.Write("Enter numbers separated by spaces: ");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int sum = 0;

            foreach (var num in numbers)
            {
                if (int.TryParse(num, out int value))
                {
                    sum += value;
                }
                else
                {
                    Console.WriteLine("Invalid input in the list.");
                    return;
                }
            }

            Console.WriteLine($"Sum: {sum}");
        }
        else if (choice == "5")
        {
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (IsArmstrong(number))
                    Console.WriteLine($"{number} is an Armstrong number.");
                else
                    Console.WriteLine($"{number} is not an Armstrong number.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        else if (choice == "6")
        {
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                int properDivisors = CountProperDivisors(number);
                Console.WriteLine($"Number of proper divisors: {properDivisors}");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        else
        {
            Console.WriteLine("Invalid program choice.");
        }
    }

    static bool IsPrime(int num)
    {
        if (num <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    static List<int> FindDivisors(int num)
    {
        List<int> divisors = new List<int>();
        for (int i = 2; i <= 10; i++)
        {
            if (num % i == 0)
                divisors.Add(i);
        }
        return divisors;
    }

    static bool IsArmstrong(int num)
    {
        int sum = 0, temp = num;
        int digits = num.ToString().Length;
        while (temp > 0)
        {
            int digit = temp % 10;
            sum += (int)Math.Pow(digit, digits);
            temp /= 10;
        }
        return sum == num;
    }

    static int CountProperDivisors(int num)
    {
        int count = 0;
        for (int i = 1; i <= num / 2; i++)
        {
            if (num % i == 0)
                count++;
        }
        return count;
    }
}
