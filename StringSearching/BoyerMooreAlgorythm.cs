using System;
using System.Collections.Generic;

namespace StringSearching
{
    public class BoyerMooreAlgorythm : ISubstringSearchingAlgorythms
    {
        private static void BadCharHeuristic(string substring, ref int[] badChar)
        {
            for (var i = 0; i < 256; i++)
                badChar[i] = -1;

            for (var i = 0; i < substring.Length; i++)
                badChar[substring[i]] = i;
        }

        public int[] Search(string text, string substring)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentOutOfRangeException("text");

            if (string.IsNullOrEmpty(substring))
                throw new ArgumentOutOfRangeException("substring");

            var retVal = new List<int>();

            var badChar = new int[256];

            BadCharHeuristic(substring, ref badChar);

            var s = 0;
            while (s <= (text.Length - substring.Length))
            {
                var j = substring.Length - 1;

                while (j >= 0 && substring[j] == text[s + j])
                    --j;

                if (j < 0)
                {
                    retVal.Add(s); // допустимый сдвиг
                    s += (s + substring.Length < text.Length)
                        ? substring.Length - badChar[text[s + substring.Length]]
                        : 1;
                }
                else
                {
                    s += Math.Max(1, j - badChar[text[s + j]]);
                }
            }

            return retVal.ToArray();
        }
    }
}
