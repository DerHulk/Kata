using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static RPM.Core.Calculator;

namespace RPM.Tests
{
    public class CalculationStepsTests
    {
        [Fact(DisplayName ="Checks that the parameters goes to the correct properties.")]
        public void ctor01()
        {
            //arrange
            var left = 99;
            var right = 101;

            //act
            var result = new CalculationStep(left, right);

            //assert
            Assert.Equal(left, result.LeftHand);
            Assert.Equal(right, result.RightHand);
        }

        [Theory]
        [InlineData(1,true)]
        [InlineData(2, false)]
        [InlineData(-1, false)]
        public void IsLastStep01(int leftHand, bool expected)
        {
            //arrange
            var target = new CalculationStep(leftHand, 99);

            //act
            var result = target.IsLastStep();

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(31, false)]
        [InlineData(2, true)]
        [InlineData(16, true)]        
        public void IsLeftHandEven(int leftHand, bool expected)
        {
            //arrange
            var target = new CalculationStep(leftHand, 324);

            //act
            var result = target.IsLeftHandEven();

            //assert
            Assert.Equal(result, expected);
        }

        [Fact(DisplayName = "Checks if the next step has the correct values.")]
        public void GetNextStep01()
        {
            //arrange
            var target = new CalculationStep(2, 11);
            var expected = new CalculationStep(1, 22);

            //act
            var result = target.GetNextStep();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Checks if the current step is the last we return null.")]
        public void GetNextStep02()
        {
            //arrange            
            var target = new CalculationStep(1, 22);

            //act
            var result = target.GetNextStep();

            //assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "Checks that two objects with same value are equal and the hashcode is the same.")]
        public void Equal01()
        {
            //arrange
            var targetA = new CalculationStep(2, 11);
            var targetB = new CalculationStep(2, 11);

            //act
            var result = targetA.Equals(targetB);

            //assert
            Assert.True(result);
            Assert.Equal(targetA.GetHashCode(), targetB.GetHashCode());
        }

        [Fact(DisplayName = "Checks that two objects with different value are not equal and the hashcode is not the same.")]
        public void Equal02()
        {
            //arrange
            var targetA = new CalculationStep(2, 11);
            var targetB = new CalculationStep(1, 11);

            //act
            var result = targetA.Equals(targetB);

            //assert
            Assert.False(result);
            Assert.NotEqual(targetA.GetHashCode(), targetB.GetHashCode());
        }

    }
}
