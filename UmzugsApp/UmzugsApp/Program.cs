using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UmzugsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //interface&abstract&test?
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("http://koapp2:5555/kvrlp/ko/offices");
            var rawResponse = request.Result.Content.ReadAsStringAsync().Result;
            var response = rawResponse.Split(';');

            //rename?
            string userInput1 = string.Empty;
           
            //redundant?
            while (!response.Any(x => x.ToString() == userInput1))
            {
                System.Console.WriteLine("In welchem Büro sitzen Sie derzeit?");
                userInput1 = System.Console.ReadLine();
            }

            string userInput2 = string.Empty;

            while (!response.Any(x => x.ToString() == userInput2))
            {
                System.Console.WriteLine("In welchem Büro sollen Sie sitzen?");
                userInput2 = System.Console.ReadLine();
            }

            System.Console.WriteLine("Benötigen Sie Hilfe beim Umzug(ja/nein)?");
            var needHelp = System.Console.ReadLine();

            //string compare
            if (needHelp == "ja" || needHelp.ToLower() == "ja")
            {
                System.Console.WriteLine("Wie viele Helfer schätzen Sie, werden Sie benötigen?");
                var countHelp = System.Console.ReadLine(); //noch welche da?
            }

            //sicheres parsen...mit tryPattern
            System.Console.WriteLine("Wie viele Kartons benötigen Sie?");
            int countBoxes = 0;

            try
            {
                countBoxes = int.Parse(System.Console.ReadLine()); //noch welche da für diesen Tag wie groß ist das gesammt Volumen?
            }
            catch (Exception)
            {}
          
            //magic numbers?
            if (countBoxes > 10)
            {
                System.Console.WriteLine("Maximal können 10 Kartons pro Mitarbeiter zur verfügung gestellt werden.");
            }

            System.Console.WriteLine("Wann möchten Sie umziehen (Wunschtermin)?");
            var wishDate = System.Console.ReadLine();

            //testen? Min: 09:00 - Max 18:30
            System.Console.WriteLine("Zu welcher Uhrzeit möchten Sie umziehen (Wunschtermin)?");
            var wishTime = System.Console.ReadLine(); //zu dieser zeit noch hilfe da?

            System.Console.WriteLine("Haben Sie Infos für die Umzugshelfer?");
            var infos = System.Console.ReadLine();

            //Zusammenfassung
            System.Console.WriteLine("Hier Ihre Zusammenfassung!");
            //...
        }
    }
}
