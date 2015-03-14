using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UmzugsApp
{
    public class Server : UmzugsApp.IServer
    {
        public IEnumerable<string> GetOffice()
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("http:koapp2:5555/kvrlp/ko/offices");
            var rawResponse = request.Result.Content.ReadAsStringAsync().Result;
            var response = rawResponse.Split(';');

            return response;
        }
    }
}
