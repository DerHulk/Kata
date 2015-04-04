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
        private static string[] Keywords = new string[] { "Name", "Ort", "PLZ" };
        private static Regex FragmentRegex = new Regex("(Name|Ort|PLZ)(.*?)(?=Name|ort|Plz|$)", RegexOptions.IgnoreCase);

        public AutocompleteParser()
        {
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
            
            foreach (var item in AutocompleteParser.Keywords)
            {
                var pattern = string.Format( @"({0})(\s)", item);
                var existKeyword = new Regex( pattern , RegexOptions.IgnoreCase);

                if (existKeyword.IsMatch(input))
                    continue;

                proposeList.Add(string.Concat(input, " ", item));       
            }

            return proposeList;
        }
    }
}
