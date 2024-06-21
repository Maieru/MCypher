using Encryption.Abstraction;
using Encryption.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.ColumnarTransposition
{
    public class ColumnarTranspositionDecoder : CoderWithKey, IDecoder
    {
        public ColumnarTranspositionDecoder(string key) : base(key)
        {
        }

        public string Decode(string encodedText)
        {
            EncryptionTextValidationHelper.ValidateText(encodedText, "Encoded text");

            var encodedMatrix = CreateCharMatrix(encodedText);
            FillMatrixWithText(encodedMatrix, encodedText);
            var decodedMatrix = DecodeMatrix(encodedMatrix);

            return MatrixHelper.ReadMatrixByRows(decodedMatrix);
        }

        private char[,] CreateCharMatrix(string encodedText)
        {
            var numberOfColumns = _key.Length;
            var numberOfRows = (int)Math.Ceiling((double)encodedText.Length / (double)_key.Length);

            return MatrixHelper.CreateMatrixWithFilling(numberOfColumns, numberOfRows);
        }

        private void FillMatrixWithText(char[,] matrix, string encodedText)
        {
            var numberOfColumns = matrix.GetLength(0);
            var numberOfRows = matrix.GetLength(1);
            var remainingText = encodedText;

            foreach (var column in Enumerable.Range(0, numberOfColumns))
            {
                foreach (var row in Enumerable.Range(0, numberOfRows))
                {
                    if (remainingText.Length == 0)
                        break;

                    if (row == 0)
                    {
                        matrix[column, row] = remainingText[0];
                        remainingText = remainingText.Remove(0, 1);
                        continue;
                    }

                    // This is a tricky one: Think like each iteration the number ask "Does the remaining text have
                    // enough characters to fill the rest of the column of the rows above me?"

                    if (remainingText.Length > row * (numberOfColumns - column - 1))
                    {
                        matrix[column, row] = remainingText[0];
                        remainingText = remainingText.Remove(0, 1);
                        continue;
                    }
                }
            }
        }

        private char[,] DecodeMatrix(char[,] encodedMatrix)
        {
            var columnOrder = CharHelper.GetCharOrder(_key);
            var decodedMatrix = MatrixHelper.CreateMatrixWithFilling(encodedMatrix.GetLength(0), encodedMatrix.GetLength(1));

            foreach (var column in Enumerable.Range(0, encodedMatrix.GetLength(0)))
            {
                foreach (var row in Enumerable.Range(0, encodedMatrix.GetLength(1)))
                {
                    decodedMatrix[column, row] = encodedMatrix[columnOrder[column], row];
                }
            }

            return decodedMatrix;
        }
    }
}
