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
            var request = httpClient.GetAsync("http:koapp2:5555/kvrlp/ko/offices");
            var rawResponse = request.Result.Content.ReadAsStringAsync().Result;
            var response = rawResponse.Split(';');

            //rename?
            string userInput1 = string.Empty;
           
            //redundant?
            while (!response.Any(x => x.ToString() == userInput1))
            {
                System.Console.WriteLine("Welches Büro sitzen Sie derzeit?");
                userInput1 = System.Console.ReadLine();
            }

            string userInput2 = string.Empty;

            while (!response.Any(x => x.ToString() == userInput2))
            {
                System.Console.WriteLine("Welches Büro sollen Sie sitzen?");
                userInput2 = System.Console.ReadLine();
            }

            System.Console.WriteLine("Benötigen Sie Hilfe beim Umzug(ja/nein)?");
            var needHelp = System.Console.ReadLine();

            //string compare
            if (needHelp == "ja" || needHelp.ToLower() == "ja")
            {
                System.Console.WriteLine("Wie viele Helfer schätzen benötigen Sie?");
                var countHelp = System.Console.ReadLine(); //noch welche da?
            }
            
            System.Console.WriteLine("Wann möchten Sie umziehen (Wunschtermin)?");
            var wishDate = System.Console.ReadLine();

            System.Console.WriteLine("Zu welcher Uhrzeit möchten Sie umziehen (Wunschtermin)?");
            var wishTime = System.Console.ReadLine(); //zu dieser zeit noch hilfe da?

            System.Console.WriteLine("Wie viel Kartons benötigen Sie?");
            var countBoxes = System.Console.ReadLine(); //noch welche da für diesen Tag wie groß ist das gesammt Volumen?

            System.Console.WriteLine("Haben Sie Infos für die Umzugshelfer?");
            var infos = System.Console.ReadLine();

            //Zusammenfassung
            System.Console.WriteLine("Ok hier ihre zusammenfassung!");
            //...
        }
    }
}
