﻿using System;
using System.Runtime.CompilerServices;
using System.Threading;

//[InternalsVisibleTo("Palindrom.Tests")]

namespace Palindrom
{

    public class Transform
    {
        private const int LowerLimit = 1;
        private const int UpperLimit = 10000;
        private const int UpperCandiateLimit = 1000000000;
        private const int NotFound = -1;

        public (int foundPalindrom, int cyle) palindrome(int toTransform)
        {
            if (toTransform < LowerLimit || toTransform > UpperLimit)
                throw new ArgumentOutOfRangeException(nameof(toTransform));

            //20min schon gemacht! 21:10
            var cylce = 1;
            var result = this.CalculatePalindrom(toTransform, ref cylce);

            return (result, cylce);
        }

        private int CalculatePalindrom(int toTransform, ref int cyle)
        {
            if (toTransform > UpperCandiateLimit)
                return NotFound;

            if (this.IsPalindrom(toTransform))
                return toTransform;

            var reversed = Helper.Reverse(toTransform);
            var candidate = toTransform + reversed;
            cyle++;

            return this.CalculatePalindrom(candidate, ref cyle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toProof"></param>
        /// <returns></returns>
        /// <remarks>
        /// https://en.wikipedia.org/wiki/Palindromic_number
        /// </remarks>
        public bool IsPalindrom(int toProof)
        {
            if (Helper.GetDigest(toProof) == 1)
                return true;

            var reversed = Helper.Reverse(toProof);

            return toProof == reversed;
        }       
    }
}
