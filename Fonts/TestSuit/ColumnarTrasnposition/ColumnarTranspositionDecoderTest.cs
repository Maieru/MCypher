using Encryption.CeaserCypher;
using Encryption.ColumnarTransposition;
using Encryption.VigenereCypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuit.ColumnarTrasnposition
{
    public class ColumnarTranspositionDecoderTest
    {
        [Theory]
        [InlineData("key", "etts", "test")]
        [InlineData("KEY", "etts", "test")]
        [InlineData("key", "eTts", "Test")]
        [InlineData("key", "h   xtssyeiimtt", "this is my text")]
        [InlineData("MYKEY", "tste", "test")]
        [InlineData("MYKEYISMUCHLONGERTHANMYTEXT", "yst iitt xesmh ", "this is my text")]
        [InlineData("a", "this is my text", "this is my text")]
        [InlineData("B", "this is my text", "this is my text")]
        [InlineData("ba", " hn  iedvlpn noesitikilk eeoigecdr", "i think i like developing encoders")]
        [InlineData("ABCDEFG", "dgw le ipctlaohlidi nisbfn eu", "decoding this will be painful")]
        public void Decoder_GivenPlainText_ReturnsEncodedText(string key, string encodedText, string expectedResult)
        {
            var encoder = new ColumnarTranspositionDecoder(key);
            var result = encoder.Decode(encodedText);

            Assert.Equal(expectedResult, result);
        }
    }
}
