using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmzugsApp
{
    public class DummyServer : IServer
    {
        public IEnumerable<string> GetOffice()
        {
            return Enumerable.Range(1, 500).Select(x=> x.ToString());
        }
    }
}
