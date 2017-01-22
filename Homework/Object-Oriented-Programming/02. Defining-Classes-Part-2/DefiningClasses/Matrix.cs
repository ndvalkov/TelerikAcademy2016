using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Matrix<T> where T : struct, IComparable<T>
    {
        private T[,] _values;

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            _values = new T[rows,cols];
        }

        public Matrix(T[,] values)
        {
            Rows = values.GetLength(0);
            Cols = values.GetLength(1);

            _values = values;
        }

        public int Rows { get; }
        public int Cols { get; }

        public T[,] GetValues()
        {
            return _values;
        }

        // indexer
        public T this[int row, int col]
        {
            get { return _values[row, col]; }
            set { _values[row, col] = value; }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (!CheckSameSize(m1, m2))
            {
                throw new InvalidOperationException("Cannot perform the operation on matrices of different size");
            }

            T[,] values1 = m1.GetValues();
            T[,] values2 = m2.GetValues();

            int rows = m1.Rows;
            int cols = m1.Cols;
            T[,] calcValues = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    
                    calcValues[i, j] = Add<T>(values1[i, j], values2[i, j]);
                }
            }

            return new Matrix<T>(calcValues);
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (!CheckSameSize(m1, m2))
            {
                throw new InvalidOperationException("Cannot perform the operation on matrices of different size");
            }

            T[,] values1 = m1.GetValues();
            T[,] values2 = m2.GetValues();

            int rows = m1.Rows;
            int cols = m1.Cols;
            T[,] calcValues = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    calcValues[i, j] = Subtract<T>(values1[i, j], values2[i, j]);
                }
            }

            return new Matrix<T>(calcValues);
        }

        /*Only value by value multiplication.*/
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (!CheckSameSize(m1, m2))
            {
                throw new InvalidOperationException("Cannot perform the operation on matrices of different size");
            }

            T[,] values1 = m1.GetValues();
            T[,] values2 = m2.GetValues();

            int rows = Math.Max(m1.Rows, m1.Cols);
            int cols = m1.Cols;
            T[,] calcValues = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    calcValues[i, j] = Multiply<T>(values1[i, j], values2[i, j]);
                }
            }

            return new Matrix<T>(calcValues);
        }

        public static explicit operator bool(Matrix<T> matrix)
        {
            foreach (var value in matrix.GetValues())
            {
                if (value.Equals(default(T)))
                {
                    return false;
                }
            }

            return true;
        }

        private static T Multiply<T>(T in1, T in2)
        {
            var d1 = Convert.ToDouble(in1);
            var d2 = Convert.ToDouble(in2);

            return (T)(dynamic)(d1 * d2);
        }

        private static T Subtract<T>(T in1, T in2)
        {
            var d1 = Convert.ToDouble(in1);
            var d2 = Convert.ToDouble(in2);

            return (T)(dynamic)(d1 - d2);
        }

        private static T Add<T>(T in1, T in2)
        {
            var d1 = Convert.ToDouble(in1);
            var d2 = Convert.ToDouble(in2);

            return (T)(dynamic)(d1 + d2);
        }

        private static bool CheckSameSize(Matrix<T> m1, Matrix<T> m2)
        {
            return m1.Rows == m2.Rows && m1.Cols == m2.Cols;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sb.Append(_values[i,j]);
                    sb.Append("\t");

                    if (j == Cols - 1)
                    {
                        sb.Append("\n");
                    }
                }
            }

            return sb.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
