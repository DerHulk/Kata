using System;
using System.Collections.Generic;
using System.Text;

namespace Palindrom
{
    public class Helper
    {
        /// <summary>
        /// Reverse a int.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://stackoverflow.com/questions/2040702/how-to-reverse-a-number-as-an-integer-and-not-as-a-string
        /// </remarks>
        public static int Reverse(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }

        /// <summary>
        /// Returns the digets of a number.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://stackoverflow.com/questions/4483886/how-can-i-get-a-count-of-the-total-number-of-digits-in-a-number
        /// </remarks>
        public static int GetDigest(int num)
        {
            return (int) Math.Floor(Math.Log10(num) + 1);
        }
    }
}
