using System;

namespace Palindrom.SimpleApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Enter a number to get the matching palindrom for it:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var number))
            {
                var transfomer = new Palindrom.Transform();
                var result = transfomer.palindrome(number);

                Console.WriteLine($"Palindrom is {result}");                
            }
            else
                Console.WriteLine("Invalid input.");

            Console.WriteLine($"Enter any key to exit.");
            Console.ReadLine();
        }
    }
}
