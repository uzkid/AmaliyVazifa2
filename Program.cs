using System;

System.Console.Write("Hello Please Enter Your Birth Year: ");
int UserAgeAsYear = System.Convert.ToInt32(Console.ReadLine());
int Year = 2024;

int UserAge = Year - UserAgeAsYear;
Console.WriteLine($"your age is {UserAge}");

int UserAgeInDays = UserAge * 365;

Console.WriteLine($"That means you lived {UserAgeInDays} Days On Earth");