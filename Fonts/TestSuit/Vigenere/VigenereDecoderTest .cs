using Encryption.VigenereCypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuit.Vigenere
{
    public class VigenereDecoderTest
    {
        [Theory]
        [InlineData("KEY", "dlgc mq k xccx", "this is a test")]
        [InlineData("key", "dlgc mq k xccx", "this is a test")]       
        [InlineData("My key", "ffsw ge y diqf", "this is a test")]
        [InlineData("KEY", "DlGc Mq k XcCx", "ThIs Is a TeSt")]
        [InlineData("a", "this is a test", "this is a test")]
        [InlineData("This is a very long key with more characters than the text", "moqk qk a oijr", "this is a test")]
        public void Decode_GivenPlainText_ReturnsDecodedText(string key, string encodedText, string expectedResult)
        {
            var encoder = new VigenereCypherDecoder(key);
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
