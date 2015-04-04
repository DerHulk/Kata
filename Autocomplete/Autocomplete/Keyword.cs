using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autocomplete
{
    public class Keyword
    {
        private readonly Regex IsContainedRegex;

        public string Key { get; private set; 
        }
        public bool IsContained(string input)
        {
            return IsContainedRegex.IsMatch(input);
        }

        public Keyword(string value)
        {
            var pattern = string.Format( @"({0})(\s)", value);
            this.IsContainedRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            this.Key = value;
        }
    }
}
