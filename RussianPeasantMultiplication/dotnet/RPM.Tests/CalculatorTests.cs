using RPM.Core;
using System;
using Xunit;

namespace RPM.Tests
{
    public class CalculatorTests
    {

        private Calculator Target {get;}

        public CalculatorTests()
        {
            this.Target = new Calculator();
        }

        [Theory(DisplayName = "Check if the multiplication is correct.")]
        [InlineData(47,42, 1974)]
        [InlineData(11, 2, 22)]
        [InlineData(4, 4, 16)]
        [InlineData(1, 5, 5)]
        [InlineData(1, 1, 1)]
        [InlineData(10, -1, -10)]
        [InlineData(11334, 93420, 1058822280)]
        public void Mul01(int left, int right, int expected)
        {
            //arrange                        

            //act
            var result = this.Target.Mul(left, right);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "Checks that the left hand must be > 1.")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-1932034)]
        public void Mul02(int left)
        {
            //arrange

            //act
            Assert.Throws<ArgumentOutOfRangeException>(() => this.Target.Mul(left, 99));

            //assert
        }
    }
}
