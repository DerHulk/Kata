using RPM.Core;
using System;

namespace RPM.App
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine($"Lets multiplicate some values...");

            var calculator = new Calculator();
            var x = GetValidUserInput("X");
            var y = GetValidUserInput("Y");

            var result = calculator.Mul(x, y);
            System.Console.WriteLine($"Result is {result}");
            System.Console.ReadLine();
            System.Console.WriteLine($"Hit any key to exit.");
        }

        static int GetValidUserInput(string askFor)
        {
            var number = int.MaxValue;
            do
            {
                System.Console.WriteLine($"please enter {askFor}");
            } while (!int.TryParse(System.Console.ReadLine(), out number));

            return number;
        }
    }
}
