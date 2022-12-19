namespace FastMultiply
{
    public class Matrix
    {
        private int[,] _matrix { get; set; }

        public Matrix(int[,] matrix)
        {
            _matrix = matrix;
        }

        public int RowCount => _matrix.GetLength(0);

        public int ColCount => _matrix.GetLength(1);

        public IEnumerable<int> GetColumn(int column)
        {
            for (int i = 0; i < RowCount; i++)
                yield return _matrix[i, column];
        }

        public IEnumerable<int> GetRow(int row)
        {
            for (int j = 0; j < ColCount; j++)
                yield return _matrix[row, j];
        }

        public int this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }

        public static Matrix operator * (Matrix a, Matrix b){
            if (a.ColCount != b.RowCount) 
                throw new ArgumentException("Product not defined");
             
            var result = Matrix.Zero(a.RowCount, b.ColCount);

            for (int i = 0; i < a.RowCount; i++)
            {
                for (int j = 0; j < b.ColCount; j++)
                {
                    List<int> row = a.GetRow(i).ToList();
                    List<int> col = b.GetColumn(j).ToList();
                    result[i, j] += DotProduct(row, col);
                }
            }

            return result;
        }

        public static bool operator == (Matrix a, Matrix b)
        {
            if (a._matrix.Rank != b._matrix.Rank) return false;
            if(a.ColCount != b.ColCount || a.RowCount != b.RowCount) return false;
            
            for (int i = 0; i < a.RowCount; i++)
                for (int j = 0; j < a.ColCount; j++)
                    if (a[i,j] != b[i,j]) return false;
         
            return true;
        }

        public static bool operator != (Matrix a, Matrix b) => !(a == b);

        public static void Print(Matrix m)
        {
            Console.Write("\n");
            for (int i = 0; i < m.RowCount; i++)
            {
                for (int j = 0; j < m.ColCount; j++)
                {
                    Console.Write(" " + m[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            return Equals((Matrix)obj);
        }

        public bool Equals(Matrix other) => this == other;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static Matrix Zero(int rowCount, int columnCount)
        {
            return new Matrix(new int[rowCount, columnCount]);
        }

        public static Matrix FastMultiply(Matrix A, Matrix B)
        {
            var result = Matrix.Zero(A.RowCount, B.ColCount);

            for (int i = 0; i < A.RowCount; i++)
            {
                for (int j = 0; j < B.ColCount; j++)
                {
                    List<int> row = A.GetRow(i).ToList();
                    List<int> col = B.GetColumn(j).ToList();
                    new Thread(() =>
                    {
                        result[i, j] += DotProduct(row, col);
                    }).Start();
                }
            }
            
            Thread.CurrentThread.Join();

            return result;
        }

        public static int DotProduct(List<int> A, List<int> B)
        {
            int product = 0;
            for (int r = 0; r < A.Count; r++)
                product += A[r] * B[r];

            return product;
        }
    }
}
