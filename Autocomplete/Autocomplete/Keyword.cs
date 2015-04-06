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
        public static readonly Keyword Empty = new Keyword();
        private readonly Regex IsContainedRegex;

        public string Key { get; private set; 
        }
        public bool IsContained(string input)
        {
            if (this.IsContainedRegex == null)
                return false;

            return IsContainedRegex.IsMatch(input);
        }
        public bool IsKey(string input)
        {
            return string.Equals(this.Key, input, StringComparison.OrdinalIgnoreCase);
        }
        public bool IsEmptyKey()
        {
            return this.Key.Equals(Empty);
        }

        public Func< string, bool> Validator { get; private set; }
        public int Order { get; private set; }

        public Keyword(string value, Func<string, bool> validator, int order = 0 ) 
        {
            var pattern = string.Format(@"({0})(\s)", value);
            this.IsContainedRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            this.Key = value;
            this.Validator = validator;
            this.Order = order;
        }

        public Keyword(string value)
            : this(value, (x)=> true)
        {
         
        }

        private Keyword()
        {
            this.Key = string.Empty;
            this.Validator = (x) => false;
            this.Order = 0;
            this.IsContainedRegex = null;
        }
    }
}
