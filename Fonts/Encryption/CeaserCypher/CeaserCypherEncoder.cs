using Encryption.Helper;
using Encryption.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.CeaserCypher
{
    public class CeaserCypherEncoder : IEncoder
    {
        private readonly int _shift;

        public CeaserCypherEncoder(int shift) => _shift = shift;

        public string Encode(string plainText)
        {
            EncryptionTextValidationHelper.ValidateText(plainText, "Encoded text");

            var returnString = "";

            foreach (char c in plainText)
            {
                if (c == ' ')
                {
                    returnString += ' ';
                    continue;
                }

                var encodingChar = c;
                var isCapitalLetter = char.IsUpper(encodingChar);

                if (isCapitalLetter)
                    encodingChar = char.ToLower(c);

                var encodedChar = EncodeChar(encodingChar);

                if (isCapitalLetter)
                    encodedChar = char.ToUpper(encodedChar);

                returnString += encodedChar;
            }

            return returnString;
        }

        private char EncodeChar(char encodingChar)
        {
            if (_shift == 0)
                return encodingChar;

            if (_shift > 0)
                return CharHelper.AddCharIndex(encodingChar, _shift);

            return CharHelper.SubtractCharIndex(encodingChar, Math.Abs(_shift));
        }
    }
}
