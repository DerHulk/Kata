using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmzugsApp
{
    public class InputValidator
    {
        private readonly Server _Server;
        public int[] ValidOffices { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="server">Der Server der verwendet wird.</param>
        public InputValidator(Server server)
        {
            if (server == null)
                throw new ArgumentNullException("server");

            this._Server = server;
            this.ValidOffices = this._Server.GetOffice().ToArray();
        }

        public bool IsValidOffice(string userInput)
        {
            if (string.Equals(userInput, string.Empty))
                return false;

            return this.ValidOffices.Any(x => x.ToString() == userInput);
        }

    }
}
