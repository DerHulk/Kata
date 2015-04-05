using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocomplete
{
    public class KeywordValue
    {
        public Keyword Keyword { get; private set; }
        public string Value { get; private set; }
        public bool IsValid { get; private set; }

        public KeywordValue(Keyword key, string value)
        {
            this.Keyword = key;
            this.Value = value.Trim();
            this.IsValid = key.Validator(value);
        }
    }
}
