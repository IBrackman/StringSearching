using System;
using System.Collections.Generic;


namespace StringSearching
{
    public class KnuthMorrisPrattAlgorythm : ISubstringSearchingAlgorythms
    {
        private static void ComputePrefixArray(string substring, ref int[] result)
        {
            var len = 0;
            var i = 1;

            result[0] = 0;

            while (i < substring.Length)
            {
                if (substring[i] == substring[len])
                {
                    len++;
                    result[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = result[len - 1];
                    }
                    else
                    {
                        result[i] = 0;
                        i++;
                    }
                }
            }
        }

        public int[] Search(string text, string substring)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentOutOfRangeException("text");

            if (string.IsNullOrEmpty(substring))
                throw new ArgumentOutOfRangeException("substring");

            var retVal = new List<int>();
            var i = 0;
            var j = 0;
            var prefix = new int[substring.Length]; // массив значений префикс-функции

            ComputePrefixArray(substring, ref prefix);

            while (i < text.Length)
            {
                if (substring[j] == text[i])
                {
                    j++;
                    i++;
                }

                if (j == substring.Length)
                {
                    retVal.Add(i - j); // допустимый сдвиг
                    j = prefix[j - 1];
                }

                else if (i < text.Length && substring[j] != text[i])
                {
                    if (j != 0)
                        j = prefix[j - 1];
                    else
                        i = i + 1;
                }
            }

            return retVal.ToArray();
        }
    }
}
