using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Palindrom.Tests
{
    public class HelperTests
    {
        [Fact()]
        public void ReverseI01()
        {
            //arrange
            var expected = 987654321;

            //act
            var result = Helper.Reverse(123456789);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(9, 1)]
        [InlineData(1234, 4)]
        [InlineData(123456789, 9)]        
        public void GetDigest01(int input, int expected)
        {
            //arrange

            //act
            var result = Helper.GetDigest(input);

            //assert
            Assert.Equal(expected, result);
        }
    }
}
