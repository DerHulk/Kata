using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmzugsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();
            var validator = new InputValidator(server);

            var validOffices = server.GetOffice();
            string currentOffice = string.Empty;
            string futureOffice = string.Empty;
            Func<string> input = ()=> System.Console.ReadLine();
            Action<string> output = (x) => System.Console.WriteLine(x);

            currentOffice = EnsureValidOffice(input ,()=> output("Welches Büro sitzen Sie derzeit?"), validator);
            futureOffice = EnsureValidOffice(input, ()=> output("Welches Büro sollen Sie sitzen?"), validator);

            System.Console.WriteLine("Wann möchten Sie umziehen (Wunschtermin)?");
            var wishDate = System.Console.ReadLine();

            System.Console.WriteLine("Zu welcher Uhrzeit möchten Sie umziehen (Wunschtermin)?");
            var wishTime = System.Console.ReadLine(); //zu dieser zeit noch hilfe da?

            System.Console.WriteLine("Benötigen Sie Hilfe beim Umzug?");
            var needHelp = System.Console.ReadLine();

            System.Console.WriteLine("Wie viele Helfer schätzen benötigen Sie?");
            var countHelp = System.Console.ReadLine(); //noch welche da?

            System.Console.WriteLine("Wie viel Kartons benötigen Sie?");
            var countBoxes = System.Console.ReadLine(); //noch welche da für diesen Tag wie groß ist das gesammt Volumen?

            System.Console.WriteLine("Haben Sie Infos für die Umzugshelfer?");
            var infos = System.Console.ReadLine();

            //Zusammenfassung
            System.Console.WriteLine("Ok hier ihre zusammenfassung!");
            //...
        }

        private static string EnsureValidOffice(IEnumerable<int> validOffices, string question)
        {
            var userInput = string.Empty;
            while (!validOffices.Any(x => x.ToString() == userInput))
            {
                System.Console.WriteLine(question);
                userInput = System.Console.ReadLine();
            }
            return userInput;
        }

        private static string EnsureValidOffice(Func<string> input, Action output, InputValidator validator)
        {
            var userInput = string.Empty;
            while (!validator.IsValidOffice(userInput))
            {
                output.Invoke();
                userInput = input.Invoke();
            }
            return userInput;
        }

    }
}
