using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;


namespace Autocomplete.Tests
{
    public class AutocompleteParserTests
    {

        public static IEnumerable<object[]> FragmentsData
        {
            get
            {
                return new[]
                {
                    new object[] { "Name Musterman Heinz Ort Abc Plz 33222 ", 
                        new Dictionary<string,string>(){  
                            {"Name", "Musterman Heinz"}
                        } },
                };
            }

        }

        [Theory(DisplayName = "Ermitteln der Fragmente aus einem String."), MemberData("FragmentsData")]
        public void CheckFragments(string input, Dictionary<string, string> expected)
        {
            //arrange
            var target = new AutocompleteParser();
            
            //act
            var result = target.Parse(input);

            //assert
            Assert.Equal(expected, result);
        }

    }
}
