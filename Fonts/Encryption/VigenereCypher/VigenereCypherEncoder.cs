using Encryption.Abstraction;
using Encryption.Helper;
using Encryption.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.VigenereCypher
{
    public sealed class VigenereCypherEncoder : CoderWithKey, IEncoder
    {
        private string Key { get; set; }

        public VigenereCypherEncoder(string key) : base(key)
        {
        }

        public string Encode(string plainText)
        {
            ValidateText(plainText, "Plain text");

            var keyIndex = 0;
            var returnString = "";

            foreach (char c in plainText)
            {
                var encodingChar = c;
                var isCapitalLetter = char.IsUpper(encodingChar);

                if (isCapitalLetter)
                    encodingChar = char.ToLower(c);

                if (c == ' ')
                {
                    returnString += ' ';
                    continue;
                }

                var keyChar = GetNextKeyChar(keyIndex);
                var encodedChar = EncodeChar(encodingChar, keyChar);

                if (isCapitalLetter)
                    encodedChar = char.ToUpper(encodedChar);

                returnString += encodedChar;
                keyIndex++;
            }

            return returnString;
        }

        private char EncodeChar(char c, char keyChar)
        {
            var keyCharIndex = CharHelper.GetCharIndex(keyChar);
            var encodedCharIndex = (int)c + keyCharIndex;

            if (encodedCharIndex > 'z')
                encodedCharIndex -= 26;

            return (char)encodedCharIndex;
        }
    }
}
