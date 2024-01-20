using Encryption.Abstraction;
using Encryption.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.VigenereCypher
{
    public class VigenereCypherDecoder : CoderWithKey, IDecoder
    {
        private string Key { get; set; }

        public VigenereCypherDecoder(string key) : base(key)
        {
        }

        public string Decode(string encodedText)
        {
            ValidateText(encodedText, "Encoded text");

            var keyIndex = 0;
            var returnString = "";

            foreach (var c in encodedText)
            {
                var decodingChar = c;
                var isCapitalLetter = char.IsUpper(decodingChar);

                if (isCapitalLetter)
                    decodingChar = char.ToLower(c);

                if (c == ' ')
                {
                    returnString += ' ';
                    continue;
                }

                var keyChar = GetNextKeyChar(keyIndex);
                var decodedChar = DecodeChar(decodingChar, keyChar);

                if (isCapitalLetter)
                    decodedChar = char.ToUpper(decodedChar);

                returnString += decodedChar;
                keyIndex++;
            }

            return returnString;
        }

        private char DecodeChar(char c, char keyChar)
        {
            var keyCharIndex = CharHelper.GetCharIndex(keyChar);
            var encodedCharIndex = (int)c - keyCharIndex;

            if (encodedCharIndex < 'a')
                encodedCharIndex += 26;

            return (char)encodedCharIndex;
        }
    }
}
