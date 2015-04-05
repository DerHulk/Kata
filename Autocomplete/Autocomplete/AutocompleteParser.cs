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
            Func<string,bool> defaultValidator = (x) => true;

            this.Keywords.Add(new Keyword("LANR", defaultValidator, 1));
            this.Keywords.Add(new Keyword("Name", defaultValidator, 2));
            this.Keywords.Add(new Keyword("Ort", defaultValidator,3 ));
            this.Keywords.Add(new Keyword("PLZ", defaultValidator, 3));
            this.Keywords.Add(new Keyword("Geburtsdatum", defaultValidator, 4));
            this.Keywords.Add(new Keyword("Stichtag", defaultValidator, 5));

            var pattern = string.Format( "({0})(.*?)(?={0}|$)", string.Join("|", this.Keywords.Select(x=> x.Key)));
            this.FragmentRegex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public Dictionary<string, string> Parse(string input)
        {
            var matching = FragmentRegex.Matches(input);
            var result = new List<KeywordValue>();

            foreach (var item in matching)
            {
                
                var key = ((System.Text.RegularExpressions.Match)item).Groups[1].Value;
                var value = ((System.Text.RegularExpressions.Match)item).Groups[2].Value;

                var keyword = this.Keywords.Where(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (keyword != null)
                {
                    var keywordValue = new KeywordValue(keyword, value);
                    result.Add(keywordValue);
                }
            }

            return result.OrderBy(x=> x.Keyword.Order).ToDictionary(x=> x.Keyword.Key, x=> x.Value);

        }

        public IEnumerable<string> Propose(string input)
        {
            input = input.Trim();
            var proposeList = new List<string>();
            
            foreach (var item in this.Keywords)
            {
                if (item.IsContained(input))
                    continue;

                if (input.StartsWith(item.Key))
                { }

                proposeList.Add(string.Concat(input, " ", item.Key));       
            }

            return proposeList;
        }
    }
}
