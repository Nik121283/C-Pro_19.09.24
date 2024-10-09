using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Operators_reload
{
    public class Matrix
    {
        public int[,] matrix;

        private int numberOfRows { get; set; }

        private int numberOfColumns { get; set; }

        public Matrix(int numberOfRows, int numberOfColumns)
        {
            matrix = new int[numberOfRows, numberOfColumns];

            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {

            if (a == null || b == null)
            {
                throw new ArgumentNullException();
            }

            Matrix result = new Matrix(a.numberOfRows, a.numberOfColumns);

            if (a.numberOfColumns==b.numberOfColumns && a.numberOfRows == b.numberOfRows)
            {
                
                for(int i = 0; i < a.numberOfRows; i++) 
                {
                    for (int j = 0; j < b.numberOfColumns; j++)
                    {
                        result.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                    }
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {

            if (a == null || b == null)
            {
                throw new ArgumentNullException();
            }

            Matrix result = new Matrix(a.numberOfRows, a.numberOfColumns);

            if (a.numberOfColumns == b.numberOfColumns && a.numberOfRows == b.numberOfRows)
            {

                for (int i = 0; i < a.numberOfRows; i++)
                {
                    for (int j = 0; j < b.numberOfColumns; j++)
                    {
                        result.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                    }
                }
            }

            return result;
        }

        public static bool operator ==(Matrix a, Matrix b)
        {

            if (a == null || b == null)
            {
                throw new ArgumentNullException();
            }

            bool result = false;

            if (a.numberOfColumns == b.numberOfColumns && a.numberOfRows == b.numberOfRows)
            {

                for (int i = 0; i < a.numberOfRows; i++)
                {
                    for (int j = 0; j < b.numberOfColumns; j++)
                    {
                        if(a.matrix[i, j] == b.matrix[i, j])
                        { result = true; }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {

            if (a == null || b == null)
            {
                throw new ArgumentNullException();
            }

            bool result = false;

            if (a.numberOfColumns == b.numberOfColumns && a.numberOfRows == b.numberOfRows)
            {

                for (int i = 0; i < a.numberOfRows; i++)
                {
                    for (int j = 0; j < b.numberOfColumns; j++)
                    {
                        if (a.matrix[i, j] != b.matrix[i, j])
                        { result = true; }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
