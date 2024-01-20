using Encryption.VigenereCypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuit.Vigenere
{
    public class VigenereEncoderTest
    {
        [Theory]
        [InlineData("KEY", "this is a test", "dlgc mq k xccx")]
        [InlineData("key", "this is a test", "dlgc mq k xccx")]       
        [InlineData("My key", "this is a test", "ffsw ge y diqf")]
        [InlineData("KEY", "ThIs Is a TeSt", "DlGc Mq k XcCx")]
        [InlineData("a", "this is a test", "this is a test")]
        [InlineData("This is a very long key with more characters than the text", "this is a test", "moqk qk a oijr")]
        public void Encode_GivenPlainText_ReturnsEncodedText(string key, string plainText, string expectedResult)
        {
            var encoder = new VigenereCypherEncoder(key);
            var result = encoder.Encode(plainText);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WhenCalledWithInvalidKey_ThrowsArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(() => new VigenereCypherEncoder(key));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("!@#")]
        [InlineData("abc123")]
        public void Constructor_WhenCalledWithNonLetterKey_ThrowsArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(() => new VigenereCypherEncoder(key));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Encode_WhenCalledWithInvalidPlainText_ThrowsArgumentException(string plainText)
        {
            var encoder = new VigenereCypherEncoder("validkey");
            Assert.Throws<ArgumentException>(() => encoder.Encode(plainText));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("!@#")]
        [InlineData("abc123")]
        public void Encode_WhenCalledWithNonLetterPlainText_ThrowsArgumentException(string plainText)
        {
            var encoder = new VigenereCypherEncoder("validkey");
            Assert.Throws<ArgumentException>(() => encoder.Encode(plainText));
        }
    }
}
