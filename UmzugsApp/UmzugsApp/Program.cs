using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UmzugsApp
{
    public class Program
    {
        private const int MaxBoxCount = 10;

        static void Main(string[] args)
        {
            IServer server = new DummyServer();
            var offices = server.GetOffice();

            AskTime();

            string currentOffice = EnsureValidOffice(offices,"Welches Büro sitzen Sie derzeit?");
            string futureOffice = EnsureValidOffice(offices, "Welches Büro sollen Sie sitzen?");

            System.Console.WriteLine("Benötigen Sie Hilfe beim Umzug(ja/nein)?");
            var needHelp = System.Console.ReadLine();

            if (string.Equals(needHelp, "ja", StringComparison.OrdinalIgnoreCase)) 
            {
                System.Console.WriteLine("Wie viele Helfer schätzen benötigen Sie?");
                var countHelp = System.Console.ReadLine(); //noch welche da?
            }

            System.Console.WriteLine("Wie viel Kartons benötigen Sie?");
            int countBoxes = 0;
            int.TryParse(System.Console.ReadLine(), out countBoxes);
          
            if (countBoxes > MaxBoxCount)
            {
                System.Console.WriteLine("Maximal können {0} Kartons pro Mitarbeiter zur verfügung gestellt werden.", MaxBoxCount);
            }

            System.Console.WriteLine("Wann möchten Sie umziehen (Wunschtermin)?");
            var wishDate = System.Console.ReadLine();

            //testen? Min: 09:00 - Max 18:30
            var wishTime = AskTime();
          
            System.Console.WriteLine("Haben Sie Infos für die Umzugshelfer?");
            var infos = System.Console.ReadLine();

            //Zusammenfassung
            System.Console.WriteLine("Ok hier ihre zusammenfassung!");
            //...
        }

        private static DateTime AskTime()
        {
            var whichTime = "Zu welcher Uhrzeit möchten Sie umziehen (Wunschtermin)?";
            System.Console.WriteLine(whichTime);
            DateTime parsed = new DateTime();

            while (!DateTime.TryParse(System.Console.ReadLine(), out parsed) && IsValidTime(parsed))
            {
                System.Console.WriteLine(whichTime);
            }

            return parsed;
        }

        public static bool IsValidTime(DateTime time)
        {
            return ((time.Hour <= 16 && time.Minute <= 30) && time.Hour >= 9);
        }

        private static string EnsureValidOffice(IEnumerable<string> offices, string question)
        {
            string currentOffice = string.Empty;

            //redundant?
            while (!offices.Any(x => x.ToString() == currentOffice))
            {
                System.Console.WriteLine(question);
                currentOffice = System.Console.ReadLine();
            }

            return currentOffice;
        }

    }
}
