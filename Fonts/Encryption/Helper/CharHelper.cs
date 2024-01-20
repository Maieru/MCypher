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
    }
}
