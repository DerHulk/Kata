using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xunit;

namespace Palindrom.Tests
{
    public class TransformTests
    {
        private Transform Target { get; }

        public TransformTests()
        {
            this.Target = new Transform();
        }

        [Theory(DisplayName = "Check that the input mus be valid (N will be between 1 and 10000).")]
        [InlineData(0)]
        [InlineData(10001)]
        public void palindrome01(int input)
        {
            //arrange            

            //act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.Target.palindrome(input));
        }

        [Theory(DisplayName = "Check some numbers which are out of the box palindroms.")]
        [ClassData(typeof(SelfPalindroms))]
        public void palindrom02(int input)
        {
            //arrange            

            //act
            var result = this.Target.IsPalindrom(input);

            //assert
            Assert.True(result, $"{input} should be a palindrom.");

        }

        [Fact(DisplayName = "If the method finds that the resultant palindrome must be greater than 1, 000, 000, 000, return the special value - 1 instead (196 has been carried out to 26, 000 digits without palindrom).")]
        public void palindrom03()
        {
            //arrange
            var expected = -1;

            //act
            var result = this.Target.palindrome(196);

            //assert
            Assert.Equal(expected, result.foundPalindrom);
        }

        [Theory(DisplayName = "Check if the given examples are matched.")]
        [ClassData(typeof(ExamplePalindroms))]
        public void palindrom04(int input, int expected)
        {
            //arrange            

            //act
            var result = this.Target.palindrome(input);

            //assert
            Assert.Equal(expected, result.foundPalindrom);

        }

        public class SelfPalindroms : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var raw = "0,1,2,3,4,5,6,7,8,9,11,22,33,44,55,66,77,88,99,101,111,121,131,141,151,161,171,181,191,202".Split(",");
                return raw.Select(x => new object[] { int.Parse(x) }).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public class ExamplePalindroms : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                //inputs/expected 
                yield return new object[] { 28, 121 };
                yield return new object[] { 51, 66};                
                yield return new object[] { 607, 4444 };                
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}
