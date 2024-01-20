using Encryption.Helper;
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
        public readonly string _key;

        public CoderWithKey(string key)
        {
            EncryptionTextValidationHelper.ValidateText(key, "Key");
            _key = key.Replace(" ", "").ToLower();
        }

        protected char GetNextKeyChar(int nextIndex)
        {
            return _key[nextIndex % _key.Length];
        }
    }
}
