using Encryption.CeaserCypher;
using Encryption.VigenereCypher;
using Microsoft.VisualStudio.CodeCoverage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuit.Ceaser
{
    public class CeaserDecoderTest
    {
        [Theory]
        [InlineData(1, "bcd", "abc")]
        [InlineData(1, "yza", "xyz")]
        [InlineData(1, "b c d", "a b c")]
        [InlineData(7, "hij", "abc")]
        [InlineData(7, "efg", "xyz")]
        [InlineData(7, "H i J", "A b C")]
        [InlineData(12, "Ftue ue m rgxx fqjf u tabq uf iadwe", "This is a full text i hope it works")]
        [InlineData(-1, "zab", "abc")]
        [InlineData(-1, "z a b", "a b c")]
        [InlineData(-7, "tuv", "abc")]
        [InlineData(-12, "Hvwg wg o tizz hslh w vcds wh kcfyg", "This is a full text i hope it works")]
        [InlineData(0, "abc", "abc")]
        [InlineData(0, "xyz", "xyz")]
        public void Decode_GivenPlainText_ReturnsDecodedText(int shift, string encodedText, string expectedResult)
        {
            var encoder = new CeaserCypherDecoder(shift);
            var result = encoder.Decode(encodedText);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Decode_WhenCalledWithInvalidPlainText_ThrowsArgumentException(string plainText)
        {
            var encoder = new CeaserCypherDecoder(3);
            Assert.Throws<ArgumentException>(() => encoder.Decode(plainText));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("!@#")]
        [InlineData("abc123")]
        public void Decode_WhenCalledWithNonLetterPlainText_ThrowsArgumentException(string plainText)
        {
            var encoder = new CeaserCypherDecoder(3);
            Assert.Throws<ArgumentException>(() => encoder.Decode(plainText));
        }
    }
}
