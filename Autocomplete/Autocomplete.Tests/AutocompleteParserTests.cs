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
                            {"Name", "Musterman Heinz"},
                            {"Ort", "Abc"},
                            {"PLZ", "33222"}
                        } },
                };
            }

        }

        public static IEnumerable<object[]> ProposeData
        {
            get
            {
                return new[] 
                {
                    new object[] {
                        "Name Musterman Heinz ", 
                        new string[]{"Name Musterman Heinz LANR", 
                                     "Name Musterman Heinz Ort", 
                                     "Name Musterman Heinz PLZ",
                                     "Name Musterman Heinz Geburtsdatum", 
                                     "Name Musterman Heinz Stichtag"}
                    },

                     new object[] {
                        "", 
                        new string[]{"LANR", 
                                     "Name", 
                                     "Ort", 
                                     "PLZ",
                                     "Geburtsdatum", 
                                     "Stichtag"}
                     },

                     new object[] {
                        " ", 
                        new string[]{"LANR", 
                                     "Name", 
                                     "Ort", 
                                     "PLZ",
                                     "Geburtsdatum", 
                                     "Stichtag"}
                     },

                     new object[] {
                        "la", 
                        new string[]{"LANR", 
                                     "Name la", 
                                     "Ort la"
                        }
                    }

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
            Assert.Equal(expected.ToList(), result.ToList());
        }

        [Theory(DisplayName = "Ermittelt ob eine Wortvorschlag in der Richtigen Reihenfolge korrekt zurück gegeben würde."), MemberData("ProposeData")]
        public void CheckPropose(string input, IEnumerable<string> expectedProposals)
        {
            //arrange
            var target = new AutocompleteParser();

            //act
            var result = target.Propose(input);

            //assert
            Assert.Equal(expectedProposals, result);
            
        }

    }
}
