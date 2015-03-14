using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmzugsApp
{
    public class Server
    {
        public IEnumerable<int> GetOffice()
        {
            return Enumerable.Range(1, 500).ToArray();
        }
        public IEnumerable<int> GetCountBoxes(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetCountHelp(DateTime date)
        {
            throw new NotImplementedException();
        }

    }
}
