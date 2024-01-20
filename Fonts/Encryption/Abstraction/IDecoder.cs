using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Abstraction
{
    public interface IDecoder
    {
        string Decode(string encodedText);
    }
}
