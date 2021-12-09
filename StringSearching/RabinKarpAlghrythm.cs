using System;
using System.Collections.Generic;

namespace StringSearching
{
    public class RabinKarpAlghrythm : ISubstringSearchingAlgorythms
    {
        public int[] Search(string text, string substring)
        {
            if(string.IsNullOrEmpty(text))
                throw new ArgumentOutOfRangeException("text");

            if (string.IsNullOrEmpty(substring))
                throw new ArgumentOutOfRangeException("substring");

            var retVal = new List<int>();
            ulong t = 0;

            ulong f = 0;
            const ulong q = 100007;
            const ulong d = 256;

            for (var i = 0; i < substring.Length; ++i)
            {
                // подсчёт f и t0 по схеме Горнера
                t = (t * d + text[i]) % q;
                f = (f * d + substring[i]) % q;
            }

            if (t == f)
                retVal.Add(0);

            ulong pow = 1;

            for (var k = 1; k <= substring.Length - 1; ++k) // pow = d^m–1 % q
                pow = (pow * d) % q;

            // r – возможный сдвиг
            for (var r = 1; r <= text.Length - substring.Length; ++r)
            {
                // вычисление очередного значения tr
                t = (t + q - pow * text[r - 1] % q) % q;
                t = (t * d + text[r + substring.Length - 1]) % q;

                if (t != f) continue;
                if (text.Substring(r, substring.Length) == substring)
                    retVal.Add(r); // допустимый сдвиг
                // иначе – холостое срабатывание
            }

            return retVal.ToArray();
        }
    }
}
