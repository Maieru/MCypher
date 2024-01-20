using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Helper
{
    public static class MatrixHelper
    {
        private const char FILLING_CHAR = (char)234;

        public static char[,] CreateMatrixWithFilling(int columns, int rows)
        {
            var returnMatrix = new char[columns, rows];

            foreach (var column in Enumerable.Range(0, columns))
                foreach (var row in Enumerable.Range(0, rows))
                    returnMatrix[column, row] = FILLING_CHAR;

            return returnMatrix;
        }

        public static string ReadMatrixByColumns(char[,] matrix)
        {
            var returnString = string.Empty;

            foreach (var column in Enumerable.Range(0, matrix.GetLength(0)))
            {
                foreach (var row in Enumerable.Range(0, matrix.GetLength(1)))
                {
                    if (matrix[column, row] != FILLING_CHAR)
                        returnString += matrix[column, row];
                }
            }

            return returnString;
        }

        public static string ReadMatrixByRows(char[,] matrix)
        {
            var returnString = string.Empty;

            foreach (var row in Enumerable.Range(0, matrix.GetLength(1)))
            {
                foreach (var column in Enumerable.Range(0, matrix.GetLength(0)))
                {
                    if (matrix[column, row] != FILLING_CHAR)
                        returnString += matrix[column, row];
                }
            }

            return returnString;
        }
    }
}
