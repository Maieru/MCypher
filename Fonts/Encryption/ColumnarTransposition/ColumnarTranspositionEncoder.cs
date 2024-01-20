using Encryption.Abstraction;
using Encryption.Helper;
using Encryption.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.ColumnarTransposition
{
    public class ColumnarTranspositionEncoder : CoderWithKey, IEncoder
    {
        public ColumnarTranspositionEncoder(string key) : base(key)
        {
        }

        public string Encode(string plainText)
        {
            EncryptionTextValidationHelper.ValidateText(plainText, "Plain text");

            var charMatrix = CreateCharMatrix(plainText);
            var columnsOrder = CharHelper.GetCharOrder(_key);
            var keyIndex = 0;

            foreach (var c in plainText)
            {
                var column = columnsOrder[keyIndex % _key.Length];
                var row = (int)Math.Floor((double)(keyIndex / _key.Length));

                charMatrix[column, row] = c;
                keyIndex++;
            }

            return MatrixHelper.ReadMatrixByColumns(charMatrix);
        }

        private char[,] CreateCharMatrix(string plainText)
        {
            var numberOfColumns = _key.Length;
            var numberOfRows = (int)Math.Ceiling((double)plainText.Length / (double)_key.Length);

            return MatrixHelper.CreateMatrixWithFilling(numberOfColumns, numberOfRows);
        }
    }
}
