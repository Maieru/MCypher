using Encryption.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Abstraction
{
    public abstract class CoderWithKey
    {
        public string Key { get; set; }

        public CoderWithKey(string key)
        {
            ValidateText(key, "Key");
            Key = key.Replace(" ", "").ToLower();
        }

        protected char GetNextKeyChar(int nextIndex)
        {
            return Key[nextIndex % Key.Length];
        }

        protected void ValidateText(string text, string textName = "Text")
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
