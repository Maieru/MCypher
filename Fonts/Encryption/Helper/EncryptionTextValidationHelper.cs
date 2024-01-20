using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Helper
{
    public static class EncryptionTextValidationHelper
    {
        public static void ValidateText(string text, string textName = "Text")
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException($"{textName} cannot be null or empty");

            if (text.Any(c => c != ' ' && !char.IsLetter(c)))
                throw new ArgumentException($"{textName} must contain only letters");

            if (string.IsNullOrWhiteSpace(text.Trim()))
                throw new ArgumentException($"{textName} cannot be only whitespace");
        }
    }
}