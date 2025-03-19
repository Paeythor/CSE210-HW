using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
      
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }


        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
               
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");

        
        int smallestPositive = int.MaxValue;  // Start with the largest possible integer
        
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;  // Found a smaller positive number
            }
        }

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        numbers.Sort();  // This sorts the list in ascending order
        
        Console.WriteLine("The sorted list of numbers is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
