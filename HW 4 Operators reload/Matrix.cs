using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Operators_reload
{
    public class Matrix
    {
        public int[,] matrix;

        private int numberOfRows { get; set; }

        private int numberOfColumns { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < this.numberOfRows; i++)
            {
                for (int j = 0; j< this.numberOfColumns; j++)
                {
                   sb.Append(this.matrix[i, j].ToString());
                   sb.Append("  ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void Show()
        {
            Console.WriteLine(this);
        }

        public Matrix(int numberOfRows, int numberOfColumns)
        {
            matrix = new int[numberOfRows, numberOfColumns];

            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {

            if (a.numberOfRows != b.numberOfRows || a.numberOfColumns != b.numberOfColumns)
            {
                throw new ArithmeticException();
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

        public static Matrix operator *(Matrix a, Matrix b)
        {

            //if (a == null || b == null)
            //{
            //    throw new ArgumentNullException();
            //}

            if (a.numberOfColumns != b.numberOfRows)
            {
                throw new ArgumentOutOfRangeException();
            }

            Matrix result = new Matrix(a.numberOfRows, b.numberOfColumns);
            for (int i = 0; i < result.numberOfRows; i++)
            {
                for (int j = 0; j < result.numberOfColumns; j++)
                {
                    int res = 0;
                    for (int k = 0; k < a.numberOfColumns; k++)
                    {
                            res += a.matrix[i, k] * b.matrix[k,j];
                    }
                    result.matrix[i, j] = res;
                }
            }
            return result;
        }

        public static bool operator ==(Matrix a, Matrix b)
        {

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
