using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;


[assembly:InternalsVisibleTo("RPM.Tests")]
namespace RPM.Core
{
    public class Calculator : ICalculator
    {
        public int Mul(int x, int y)
        {
            if (x < 1)
                throw new ArgumentOutOfRangeException(nameof(x), "x must be >= 1");

            var step = new CalculationStep(x, y);
            var steps = new List<CalculationStep>();
            
            while (!step.IsLastStep())
            {
                steps.Add(step);
                step = step.GetNextStep();
            }
            steps.Add(step);

            var sum = steps.Where(s => !s.IsLeftHandEven()).Sum(s => s.RightHand);
            return sum;
        }

        [System.Diagnostics.DebuggerDisplay("L:{LeftHand} R:{RightHand}")]
        internal class CalculationStep
        {
            public int LeftHand { get; }

            public int RightHand { get; }

            public CalculationStep(int leftHand, int rightHand)
            {
                LeftHand = leftHand;
                RightHand = rightHand;
            }

            public bool IsLastStep()
            {
                return this.LeftHand == 1;
            }

            public bool IsLeftHandEven()
            {
                return this.LeftHand % 2 == 0;
            }

            /// <summary>
            /// Returns the next calculation-step.
            /// If this step is the last Null will be returned.
            /// </summary>
            /// <returns></returns>
            public CalculationStep GetNextStep()
            {
                if (this.IsLastStep())
                    return null;

                return new CalculationStep((int)Math.Floor(this.LeftHand / 2d), this.RightHand * 2);
            }

            public override bool Equals(object obj)
            {                
                if (!(obj is CalculationStep objA))
                    return false;

                return objA?.LeftHand == this.LeftHand && objA?.RightHand == this.RightHand;                
            }

            /// <summary>
            /// Get the HashCode for this Object.
            /// </summary>
            /// <returns></returns>
            /// <remarks>
            /// https://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
            /// </remarks>
            public override int GetHashCode()
            {
                unchecked
                {
                    var result = 0;
                    result = (result * 397) ^ this.LeftHand;
                    result = (result * 397) ^ this.RightHand;                    
                    return result;
                }
            }
        }
        
    }
}
