using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Interfaces
{
    public interface IEncoder
    {
        string Encode(string plainText);
    }
}
