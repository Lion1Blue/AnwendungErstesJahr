using System;
using System.Windows.Forms;

namespace WinFormMVC.Model
{
    public class MathAlgorithm
    {
        //Normalize
        private decimal[,] Normalize(decimal[,] matrix, int round)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = Math.Round(matrix[i, j], round);
                    matrix[i, j] = matrix[i, j] / 1.000000000000000000000000000000000m;
                }
            }

            return matrix;
        }


        //checking if the two vectors have the right dimensions
        private bool dimensionsCheckedCrossProductAB(int ColumnsA, int ColumnsB, int RowsA, int RowsB)
        {
            if ((ColumnsA == 2 && ColumnsB == 2) && (RowsA == 4 && RowsB == 4))
                return true;
            else
                return false;
        }

        //checking if the matrices have the same Dimensions
        private bool dimensionsCheckedPlusAndMinus(int ColumnsA, int ColumnsB, int RowsA, int RowsB)
        {
            if ((ColumnsA == ColumnsB) && (RowsA == RowsB) && ColumnsA != 0 && ColumnsB != 0 && RowsA != 0&& RowsB != 0)
                return true;
            else
                return false;
        }

        //checking if matrices have the right Dimensions
        private bool dimensionsCheckedATimesB(int ColumnsA, int RowsB)
        {
            if (ColumnsA == RowsB)
                return true;
            else
                return false;
        }

        //checking if matrixA has the right dimensions 
        private bool dimensionsCheckedInvertA(int ColumnsA, int RowsA)
        {
            if (ColumnsA == RowsA)
                return true;
            else
                return false;
        }

        //checking if matrixGauß has the right dimensions
        private bool dimensionsCheckedGaußAlgorithm(int ColumnsGauß, int RowsGauß)
        {
            if (ColumnsGauß == RowsGauß + 1)
                return true;
            else
                return false;
        }

        //checking if Matrix A is invertable
        private bool MatrixIsInvertable(decimal[,] matrix)
        {
            //checking for zero rows
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int anzahlRowsNull = 0;
                int anzahlColumsNull = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Round(matrix[i, j]) == 0)
                        anzahlRowsNull++;
                    if (Math.Round(matrix[j, i]) == 0)
                        anzahlColumsNull++;
                }
                if ((anzahlRowsNull == matrix.GetLength(0)) || (anzahlColumsNull == matrix.GetLength(1)))
                    return false;
            }

            //checking for linear dependency 
            for (int n = 0; n < matrix.GetLength(0) - 1; n++)
            {
                for (int i = n + 1; i < matrix.GetLength(1); i++)
                {
                    int start = 0;
                    int start2 = 0;

                    //checking for zeros in nth column
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[j, n] != 0)
                        {
                            start = j;
                            break;
                        }
                    }
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[n, j] != 0)
                        {
                            start2 = j;
                            break;
                        }
                    }

                    decimal multiplier = matrix[start, i] / matrix[start, n];
                    decimal multiplier2 = matrix[i, start2] / matrix[n, start2];
                    int anzahl = 0;
                    int anzahl2 = 0;

                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (multiplier * matrix[j, n] == matrix[j, i])
                            anzahl++;
                    }
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (multiplier2 * matrix[n, j] == matrix[i, j])
                            anzahl2++;
                    }
                    if (anzahl == matrix.GetLength(0) || anzahl2 == matrix.GetLength(0))
                        return false;
                }
            }

            return true;
        }

        //A + B
        public decimal[,] APlusB(decimal[,]matrixA, decimal[,] matrixB)
        {
            decimal[,] matrixResult = new decimal[0, 0];

            if (dimensionsCheckedPlusAndMinus(matrixA.GetLength(1), matrixB.GetLength(1), matrixA.GetLength(0), matrixB.GetLength(0)))
            {
                matrixResult = new decimal[matrixA.GetLength(0), matrixA.GetLength(1)];

                for (int i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixA.GetLength(1); j++)
                    {
                        matrixResult[i, j] = matrixA[i, j] + matrixB[i, j];
                    }
                }
            }
            else
            {
                MessageBox.Show("check if the matrices have the right dimensions");
            }

            return Normalize(matrixResult, 25);
        }

        //A - B
        public decimal[,] AMinusB(decimal[,] matrixA, decimal[,] matrixB)
        {
            decimal[,] matrixResult = new decimal[0, 0];

            if (dimensionsCheckedPlusAndMinus(matrixA.GetLength(1), matrixB.GetLength(1), matrixA.GetLength(0), matrixB.GetLength(0)))
            {
                matrixResult = new decimal[matrixA.GetLength(0), matrixA.GetLength(1)];

                for (int i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixA.GetLength(1); j++)
                    {
                        matrixResult[i, j] = matrixA[i, j] - matrixB[i, j];
                    }
                }
            }
            else
            {
                MessageBox.Show("check if the matrices have the right dimensions");
            }

            return Normalize(matrixResult, 25);
        }

        //A * B
        public decimal[,] ATimesB(decimal[,] matrixA, decimal[,] matrixB)
        {
            decimal[,] matrixResult = new decimal[0, 0];

            if (dimensionsCheckedATimesB(matrixA.GetLength(1), matrixB.GetLength(0)))
            {
                matrixResult = new decimal[matrixA.GetLength(0), matrixB.GetLength(1)];

                for (int j = 0; j < matrixResult.GetLength(0); j++)
                {
                    for (int i = 0; i < matrixResult.GetLength(1); i++)
                    {
                        decimal result = 0;
                        for (int y = 0; y < matrixA.GetLength(1); y++)
                        {
                            result += matrixA[j, y] * matrixB[y, i];
                            matrixResult[j, i] = result;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("check if the matrices have the right dimensions");
            }

            return Normalize(matrixResult, 25);
        }

        //A^-1
        public decimal[,] AInverted(decimal[,] matrixA)
        {
            decimal[,] matrixAInverted = new decimal[0, 0];

            if (matrixA.GetLength(0) == matrixA.GetLength(1))
            {
                if (MatrixIsInvertable(matrixA))
                {
                    matrixAInverted = new decimal[matrixA.GetLength(0), matrixA.GetLength(1)];

                    //creating matrixAInverted
                    for (int i = 0; i < matrixAInverted.GetLength(0); i++)
                    {
                        matrixAInverted[i, i] = 1;
                    }

                    //bottom left
                    for (int startingRow = 0; startingRow < matrixA.GetLength(0); startingRow++)
                    {
                        //switchig rows
                        for (int n = 0; n < matrixA.GetLength(0) - 1; n++)
                        {
                            if (Math.Round(matrixA[n, n], 15) == 0)
                            {
                                for (int i = 1 + n; i < matrixA.GetLength(0); i++)
                                {
                                    if (Math.Round(matrixA[i, n], 15) != 0)
                                    {
                                        for (int j = 0; j < matrixA.GetLength(1); j++)
                                        {
                                            decimal tmp2 = matrixAInverted[n, j];
                                            decimal tmp1 = matrixA[n, j];

                                            matrixAInverted[n, j] = matrixAInverted[i, j];
                                            matrixA[n, j] = matrixA[i, j];

                                            matrixAInverted[i, j] = tmp2;
                                            matrixA[i, j] = tmp1;
                                        }
                                    }
                                }
                            }
                        }

                        //matrixAInverted left side = 1
                        for (int i = startingRow; i < matrixA.GetLength(0); i++)
                        {
                            if (Math.Round(matrixA[i, startingRow], 5) != 0)
                            {
                                for (int j = matrixA.GetLength(1) - 1; j >= 0; j--)
                                {
                                    matrixAInverted[i, j] = matrixAInverted[i, j] / matrixA[i, startingRow];
                                    //matrixA[i, j] = matrixA[i, j] / matrixA[i, startingRow];
                                }
                            }
                        }

                        // matrixA left side = 1
                        for (int i = startingRow; i < matrixA.GetLength(0); i++)
                        {
                            if (Math.Round(matrixA[i, startingRow], 5) != 0)
                            {
                                for (int j = matrixA.GetLength(1) - 1; j >= 0; j--)
                                {
                                    matrixA[i, j] = matrixA[i, j] / matrixA[i, startingRow];
                                }
                            }
                        }

                        //triangular shape bottom left
                        for (int i = startingRow + 1; i < matrixA.GetLength(0); i++)
                        {
                            if (Math.Round(matrixA[i, startingRow], 5) != 0)
                            {
                                for (int j = matrixA.GetLength(1) - 1; j >= 0; j--)
                                {
                                    matrixA[i, j] = matrixA[startingRow, j] - matrixA[i, j];
                                    matrixAInverted[i, j] = matrixAInverted[startingRow, j] - matrixAInverted[i, j];
                                }
                            }
                        }
                    }

                    //top right 
                    for (int startingRow = matrixA.GetLength(0) - 1; startingRow >= 0; startingRow--)
                    {
                        //matrixAInverted right side = 1
                        for (int i = 0; i < matrixA.GetLength(0); i++)
                        {
                            if (Math.Round(matrixA[i, startingRow], 5) != 0)
                            {
                                for (int j = 0; j < matrixA.GetLength(1); j++)
                                {
                                    matrixAInverted[i, j] = matrixAInverted[i, j] / matrixA[i, startingRow];
                                }
                            }
                        }

                        //matrixA right side = 1
                        for (int i = 0; i < matrixA.GetLength(0); i++)
                        {
                            if (Math.Round(matrixA[i, startingRow], 5) != 0)
                            {
                                for (int j = 0; j < matrixA.GetLength(1); j++)
                                {
                                    matrixA[i, j] = matrixA[i, j] / matrixA[i, startingRow];
                                }
                            }
                        }

                        //triangular shap top right 
                        for (int i = 0; i < startingRow; i++)
                        {
                            if (Math.Round(matrixA[i, startingRow], 5) != 0)
                            {
                                for (int j = 0; j < matrixA.GetLength(1); j++)
                                {
                                    matrixA[i, j] = matrixA[i, j] - matrixA[startingRow, j];
                                    matrixAInverted[i, j] = matrixAInverted[i, j] - matrixAInverted[startingRow, j];
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("matrix is not invertable");
                }
            }
            else
            {
                MessageBox.Show("check if the matrix has the right dimension");
            }

            return Normalize(matrixAInverted, 25);
        }

        //DotProduct AB
        public decimal[,] DotProduct(decimal[,] matrixA, decimal[,] matrixB)
        {
            decimal[,] matrixResult = new decimal[0, 0];

            if (dimensionsCheckedPlusAndMinus(matrixA.GetLength(1), matrixB.GetLength(1), matrixA.GetLength(0), matrixB.GetLength(0)))
            {
                matrixResult = new decimal[1, 1];

                for (int i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixA.GetLength(1); j++)
                    {
                        matrixResult[0, 0] += matrixA[i, j] * matrixB[i, j];
                    }
                }
            }
            else
            {
                MessageBox.Show("check if the matrices have the right dimensions");
            }

            return Normalize(matrixResult, 25);
        }

        //CrossProduct AB
        public decimal[,] CrossProduct(decimal[,] vectorA, decimal[,] vectorB)
        {
            decimal[,] vectorResult = new decimal[0, 0];

            if (dimensionsCheckedCrossProductAB(vectorA.GetLength(1), vectorB.GetLength(1), vectorA.GetLength(0), vectorB.GetLength(0)))
            {
                vectorResult = new decimal[3, 1];

                vectorResult[0, 0] = vectorA[1, 0] * vectorB[2, 0] - vectorA[2, 0] * vectorB[1, 0];
                vectorResult[1, 0] = vectorA[2, 0] * vectorB[0, 0] - vectorA[0, 0] * vectorB[2, 0];
                vectorResult[2, 0] = vectorA[0, 0] * vectorB[1, 0] - vectorA[1, 0] * vectorB[0, 0];
            }
            else
            {
                MessageBox.Show("check if the vectors have the right dimension");
            }

            return Normalize(vectorResult, 25);
        }

        //GaußAlgorithm
        public decimal[,] Gaußalgorithm(decimal[,] matrixGauß)
        {
            if (dimensionsCheckedGaußAlgorithm(matrixGauß.GetLength(1), matrixGauß.GetLength(0)))
            {
                for (int startingRow = 0; startingRow < matrixGauß.GetLength(0); startingRow++)
                {
                    //switching Rows
                    for (int n = 0; n < matrixGauß.GetLength(0) - 1; n++)
                    {
                        if (Math.Round(matrixGauß[n, n], 15) == 0)
                        {
                            for (int i = 1 + n; i < matrixGauß.GetLength(0); i++)
                            {
                                if (Math.Round(matrixGauß[i, n], 15) != 0)
                                {
                                    for (int j = 0; j < matrixGauß.GetLength(1); j++)
                                    {

                                        decimal tmp = matrixGauß[n, j];

                                        matrixGauß[n, j] = matrixGauß[i, j];

                                        matrixGauß[i, j] = tmp;
                                    }
                                }
                            }
                        }
                    }

                    
                    //diagonal entries = 1
                    for (int i = startingRow; i < matrixGauß.GetLength(0); i++)
                    {
                        for (int j = matrixGauß.GetLength(1) - 1; j >= startingRow; j--)
                        {
                            if (Math.Round(matrixGauß[i, startingRow], 15) != 0)
                            {
                                matrixGauß[i, j] = matrixGauß[i, j] / matrixGauß[i, startingRow];
                            }
                        }
                    }

                    //triangular shape
                    if (startingRow < matrixGauß.GetLength(0) - 1)
                    {
                        for (int resultrow = startingRow + 1; resultrow < matrixGauß.GetLength(0); resultrow++)
                        {
                            for (int j = matrixGauß.GetLength(1) - 1; j >= startingRow; j--)
                            {
                                if (Math.Round(matrixGauß[resultrow, startingRow], 15) != 0)
                                {
                                    matrixGauß[resultrow, j] = matrixGauß[startingRow, j] - matrixGauß[resultrow, j];

                                    if (Math.Round(matrixGauß[resultrow, j], 10) == 0)
                                    {
                                        matrixGauß[resultrow, j] = 0;
                                    }
                                }
                            }
                        }
                    }
                    else
                        break;
                }
            }
            else
            {
                matrixGauß = new decimal[0, 0];
                MessageBox.Show("check if the matrix has the right dimension");
            }

            return Normalize(matrixGauß, 25);
        }

        //Reduced GaußAlgorithm
        public decimal[,] ReducedGaußAlgorithm(decimal[,] matrixReducedGaußAlgorithm)
        {
            matrixReducedGaußAlgorithm = Gaußalgorithm(matrixReducedGaußAlgorithm);

            //Reduzierte Diagonalform Version 1
            for (int n = 1; n < matrixReducedGaußAlgorithm.GetLength(1) - 1; n++)
            {
                for (int j = 0; j < matrixReducedGaußAlgorithm.GetLength(0) - 1; j++)
                {
                    for (int i = matrixReducedGaußAlgorithm.GetLength(1) - 1; i >= j + n; i--)
                    {
                        if (j + n > matrixReducedGaußAlgorithm.GetLength(0) - 1)
                        {
                            break;
                        }
                        else
                        {
                            matrixReducedGaußAlgorithm[j, i] = matrixReducedGaußAlgorithm[j, i] - (matrixReducedGaußAlgorithm[j, j + n] * matrixReducedGaußAlgorithm[j + n, i]);

                            if (Math.Round(matrixReducedGaußAlgorithm[j, i], 10) == 0)
                            {
                                matrixReducedGaußAlgorithm[j, i] = 0;
                            }
                        }
                    }
                }
            }

            return Normalize(matrixReducedGaußAlgorithm, 20);
        }
    }
}
