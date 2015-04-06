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
            Func<string, bool> defaultValidator = (x) => true;
            Func<string, bool> dateValidator = (x) =>
            {
                var parsedDate = DateTime.Now;
                return DateTime.TryParse(x, out parsedDate);
            };

            Func<string, bool> numberValidator = (x) =>
            {
                var parsedInt = 0;
                return int.TryParse(x, out parsedInt);
            };

            this.Keywords.Add(new Keyword("LANR", numberValidator , 1));
            this.Keywords.Add(new Keyword("Name", defaultValidator, 2));
            this.Keywords.Add(new Keyword("Ort", defaultValidator, 3));
            this.Keywords.Add(new Keyword("PLZ", numberValidator, 3));
            this.Keywords.Add(new Keyword("Geburtsdatum", dateValidator, 4));
            this.Keywords.Add(new Keyword("Stichtag", dateValidator, 5));

            var pattern = string.Format("({0})(.*?)(?={0}|$)", string.Join("|", this.Keywords.Select(x => x.Key)));
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

            return result.OrderBy(x => x.Keyword.Order).ToDictionary(x => x.Keyword.Key, x => x.Value);

        }

        public IEnumerable<string> Propose(string input)
        {
            if (input.EndsWith(" "))
                return this.ProposeDefaults(input);

            return this.ProposeForLastValue(input);
        }

        private IEnumerable<string> ProposeDefaults(string input)
        {
            input = input.Trim();
            var proposeList = new List<string>();

            foreach (var item in this.Keywords)
            {
                if (item.IsContained(input))
                    continue;

                proposeList.Add(string.Concat(input, " ", item.Key).Trim());

            }

            return proposeList;
        }

        private IEnumerable<string> ProposeForLastValue(string input)
        {
            var lastValue = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            var keywordMatching = this.Keywords.Where(x => x.Key.StartsWith(lastValue, StringComparison.OrdinalIgnoreCase));
            var keyvalueMatching = this.Keywords.Where(x => x.Validator(lastValue));
            var result = Enumerable.Empty<string>();

            if (keywordMatching.Count() > 0)
            {
                result = result.Union(keywordMatching.OrderBy(x => x.Order).Select(x => input.ReplaceLastOccurrence(lastValue, x.Key)));
            }

            if (keyvalueMatching.Count() > 0)
            {
                result = result.Union(keyvalueMatching.OrderBy(x => x.Order).Select(x => input.ReplaceLastOccurrence(lastValue,
                                                                 string.Format("{0} {1}", x.Key, lastValue))));
            }

            return result.ToArray();

        }
    }
}
