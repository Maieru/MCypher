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

        public static int GetCharIndex(char c) => c - FIRST_CHAR;        
    }
}
