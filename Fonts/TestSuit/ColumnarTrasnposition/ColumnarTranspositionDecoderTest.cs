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
        [InlineData("key", "eiTtgsn", "Testing")]
        [InlineData("kEy", "h   xtssyeiimtt", "this is my text")]
        [InlineData("MYKEY", "tste", "test")]
        [InlineData("MYKEYISMUCHLONGERTHANMYTEXT", "yst iitt xesmh ", "this is my text")]
        [InlineData("a", "this is my text", "this is my text")]
        [InlineData("B", "this is my text", "this is my text")]
        [InlineData("ba", " hn  iedvlpn noesitikilk eeoigecdr", "i think i like developing encoders")]
        [InlineData("ABCDEFG", "dgw le ipctlaohlidi nisbfn eu", "decoding this will be painful")]
        [InlineData("MyKey", "oectDete ds", "Decode test")]
        [InlineData("Pain", "  hwrtaiIsg", "I was right")]
        public void Decoder_GivenPlainText_ReturnsEncodedText(string key, string encodedText, string expectedResult)
        {
            var encoder = new ColumnarTranspositionDecoder(key);
            var result = encoder.Decode(encodedText);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WhenCalledWithInvalidKey_ThrowsArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(() => new VigenereCypherDecoder(key));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("!@#")]
        [InlineData("abc123")]
        public void Constructor_WhenCalledWithNonLetterKey_ThrowsArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(() => new VigenereCypherDecoder(key));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Decode_WhenCalledWithInvalidPlainText_ThrowsArgumentException(string plainText)
        {
            var encoder = new VigenereCypherDecoder("validkey");
            Assert.Throws<ArgumentException>(() => encoder.Decode(plainText));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("!@#")]
        [InlineData("abc123")]
        public void Decode_WhenCalledWithNonLetterPlainText_ThrowsArgumentException(string plainText)
        {
            var encoder = new VigenereCypherDecoder("validkey");
            Assert.Throws<ArgumentException>(() => encoder.Decode(plainText));
        }
    }
}
