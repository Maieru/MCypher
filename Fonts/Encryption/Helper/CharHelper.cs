using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Helper
{
    public static class CharHelper
    {
        private const char FIRST_CHAR = 'a';
        private const char LAST_CHAR = 'z';

        public static int GetCharIndex(char c) => c - FIRST_CHAR;

        public static char AddCharIndex(char c, int index)
        {
            var newIndex = c + index;

            if (newIndex > LAST_CHAR)
                newIndex -= 26;

            return (char)newIndex;
        }

        public static char SubtractCharIndex(char c, int index)
        {
            var newIndex = c - index;

            if (newIndex < FIRST_CHAR)
                newIndex += 26;

            return (char)newIndex;
        }

        public static List<int> GetCharOrder(string text)
        {
            var tuples = text.Select((c, i) => Tuple.Create(c, i)).OrderBy(t => t.Item1).ToList();


            var returnList = new List<int>();

            for (var i = 0; i < text.Length; i++)
            {
                var tuple = tuples.Find(t => t.Item2 == i);
                var tupleIndex = tuples.IndexOf(tuple);
                returnList.Add(tupleIndex);
            }

            return returnList;
        }
    }
}
