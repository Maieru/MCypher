using Encryption.ColumnarTransposition;
using Encryption.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuit.Helper
{
    public class CharHelperTest
    {
        [Theory]
        [InlineData('a', 0)]
        [InlineData('b', 1)]
        [InlineData('c', 2)]
        [InlineData('d', 3)]
        [InlineData('e', 4)]
        [InlineData('j', 9)]
        [InlineData('k', 10)]
        [InlineData('l', 11)]
        [InlineData('z', 25)]
        public void GetCharIndex_GivenValidChar_ReturnIndex(char c, int expectedResult)
        {
            var actualIndex = CharHelper.GetCharIndex(c);
            Assert.Equal(expectedResult, actualIndex);
        }

        [Theory]
        [InlineData('a', 1, 'b')]
        [InlineData('b', 1, 'c')]
        [InlineData('c', 1, 'd')]
        [InlineData('a', 3, 'd')]
        [InlineData('z', 1, 'a')]
        [InlineData('z', 2, 'b')]
        [InlineData('z', 26, 'z')]
        [InlineData('z', 28, 'b')]
        public void AddCharIndex_GivenValidChar_ReturnChar(char c, int addingIndex, char expectedResult)
        {
            var actualChar = CharHelper.AddCharIndex('a', 1);
            Assert.Equal('b', actualChar);
        }

        [Theory]
        [InlineData('a', 1, 'z')]
        [InlineData('b', 1, 'a')]
        [InlineData('c', 1, 'b')]
        [InlineData('a', 3, 'x')]
        [InlineData('z', 1, 'y')]
        [InlineData('z', 2, 'x')]
        [InlineData('z', 26, 'z')]
        [InlineData('z', 28, 'x')]
        public void SubtractCharIndex_GivenValidChar_ReturnChar(char c, int subtractingIndex, char expectedResult)
        {
            var actualChar = CharHelper.SubtractCharIndex('a', 1);
            Assert.Equal('z', actualChar);
        }

        [Theory]
        [InlineData("eyi", new int[] { 0, 2, 1 })]
        [InlineData("abc", new int[] { 0, 1, 2 })]
        [InlineData("eye", new int[] { 0, 2, 1 })]
        [InlineData("eee", new int[] { 0, 1, 2 })]
        [InlineData("e", new int[] { 0 })]
        [InlineData("ey", new int[] { 0, 1 })]
        [InlineData("azbycx", new int[] { 0, 5, 1, 4, 2, 3 })]
        [InlineData("thisisaverylongtext", new int[] { 13, 4, 5, 11, 6, 12, 0, 16, 1, 10, 18, 7, 9, 8, 3, 14, 2, 17, 15 })]
        [InlineData("MYKEYISMUCHLONGERTHANMYTEXT", new int[] { 11, 24, 9, 2, 25, 8, 18, 12, 22, 1, 6, 10, 16, 14, 5, 3, 17, 19, 7, 0, 15, 13, 26, 20, 4, 23, 21 })]
        [InlineData("THISISAMUCHLONGERTEXTWITHALOTOFTEXT", new int[] { 24, 8, 11, 22, 12, 23, 0, 16, 31, 2, 9, 14, 18, 17, 7, 3, 21, 25, 4, 33, 26, 32, 13, 27, 10, 1, 15, 19, 28, 20, 6, 29, 5, 34, 30 })]
        public void GetCharOrder_GivenValidText_ReturnOrder(string text, int[] expectedResult)
        {
            var actualList = CharHelper.GetCharOrder(text);
            Assert.Equal(expectedResult, actualList);
        }
    }
}
