using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autocomplete
{
    public class AutocompleteParser
    {
        private Regex FragmentRegex;
        private List<Keyword> Keywords { get; set; }

        public AutocompleteParser()
        {
            this.Keywords = new List<Keyword>();

            foreach (var item in new string[] { "Name", "Ort", "PLZ", "Geburtsdatum","Stichtag", "LANR" })
            {
                this.Keywords.Add(new Keyword(item));
            }

            var pattern = string.Format( "({0})(.*?)(?={0}|$)", string.Join("|", this.Keywords.Select(x=> x.Key)));
            this.FragmentRegex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public Dictionary<string, string> Parse(string input)
        {
            var matching = FragmentRegex.Matches(input);
            var result = new Dictionary<string, string>();

            foreach (var item in matching)
            {
                var key = ((System.Text.RegularExpressions.Match)item).Groups[1].Value;
                var value = ((System.Text.RegularExpressions.Match)item).Groups[2].Value;

                result.Add(key, value.Trim());
            }

            return result;

        }

        public IEnumerable<string> Propose(string input)
        {
            input = input.Trim();
            var proposeList = new List<string>();
            
            foreach (var item in this.Keywords)
            {
                if (item.IsContained(input))
                    continue;

                proposeList.Add(string.Concat(input, " ", item.Key));       
            }

            return proposeList;
        }
    }
}
