using Encryption.Abstraction;
using Encryption.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.CeaserCypher
{
    public class CeaserCypherDecoder : IDecoder
    {
        private readonly int _shift;

        public CeaserCypherDecoder(int shift) => _shift = shift;

        public string Decode(string encodedText)
        {
            EncryptionTextValidationHelper.ValidateText(encodedText, "Encoded text");

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

                var decodedChar = DecodeChar(decodingChar);

                if (isCapitalLetter)
                    decodedChar = char.ToUpper(decodedChar);

                returnString += decodedChar;
            }

            return returnString;
        }

        private char DecodeChar(char decodingChar)
        {
            if (_shift == 0)
                return decodingChar;

            if (_shift > 0)
                return CharHelper.SubtractCharIndex(decodingChar, _shift);

            return CharHelper.AddCharIndex(decodingChar, Math.Abs(_shift));
        }
    }
}
