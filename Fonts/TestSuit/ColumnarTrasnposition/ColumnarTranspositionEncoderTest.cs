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
    public class ColumnarTranspositionEncoderTest
    {
        [Theory]
        [InlineData("key", "test", "etts")]
        [InlineData("KEY", "test", "etts")]
        [InlineData("key", "Test", "eTts")]
        [InlineData("key", "Testing", "eiTtgsn")]
        [InlineData("key", "this is my text", "h   xtssyeiimtt")]
        [InlineData("MYKEY", "test", "tste")]
        [InlineData("MYKEYISMUCHLONGERTHANMYTEXT", "this is my text", "yst iitt xesmh ")]
        [InlineData("a", "this is my text", "this is my text")]
        [InlineData("B", "this is my text", "this is my text")]
        [InlineData("ba", "i think i like developing encoders", " hn  iedvlpn noesitikilk eeoigecdr")]
        [InlineData("ABCDEFG", "decoding this will be painful", "dgw le ipctlaohlidi nisbfn eu")]
        [InlineData("Pain", "I was right", "  hwrtaiIsg")]
        public void Encode_GivenPlainText_ReturnsEncodedText(string key, string plainText, string expectedResult)
        {
            var encoder = new ColumnarTranspositionEncoder(key);
            var result = encoder.Encode(plainText);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WhenCalledWithInvalidKey_ThrowsArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(() => new ColumnarTranspositionEncoder(key));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("!@#")]
        [InlineData("abc123")]
        public void Constructor_WhenCalledWithNonLetterKey_ThrowsArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(() => new ColumnarTranspositionEncoder(key));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Encode_WhenCalledWithInvalidPlainText_ThrowsArgumentException(string plainText)
        {
            var encoder = new ColumnarTranspositionEncoder("validkey");
            Assert.Throws<ArgumentException>(() => encoder.Encode(plainText));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("!@#")]
        [InlineData("abc123")]
        public void Encode_WhenCalledWithNonLetterPlainText_ThrowsArgumentException(string plainText)
        {
            var encoder = new ColumnarTranspositionEncoder("validkey");
            Assert.Throws<ArgumentException>(() => encoder.Encode(plainText));
        }
    }
}
