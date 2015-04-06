using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocomplete
{
    public class LastFragment
    {
        public KeywordValue Value { get; private set; }
        public string Last { get; private set; }

        public LastFragment(string input, IEnumerable<Keyword> keywords)
        {
            var fragments = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var keywordIndex = from f in fragments
                               from k in keywords
                               where k.IsKey(f)
                               select new { key = k, index =  fragments.LastIndexOf(f) };

            if (keywordIndex.Count() <= 0)
                this.Value = new KeywordValue(Keyword.Empty, input);

            else
            {
                var last = keywordIndex.OrderBy(x => x.index).Last();

                this.Value = new KeywordValue(last.key, string.Join(" ", fragments.Skip(last.index + 1)));
            }

            this.Last = fragments.Last();
            
        }

    }
}
