using System;
using Xunit;

namespace FastMultiply.Tests
{
    public class EqualityTests
    {
        [Fact]
        public void Matrix_should_be_equal_to_itself()
        {
            var a = new Matrix(new int[,] { { 1, 2 }, { 2, 4 }});
            Assert.Equal(a, a);
            Assert.Equal(new Matrix(new int[,] {{1,2}, {2,4}}), new Matrix(new int[,] {{1,2},{2,4}}));
        }

        [Fact]
        public void Equal_matrixes_shoul_be_equal()
        {
            var a = new Matrix(new int[,] { { 1, 2, 3 }, { 2, 4, 3 } });
            var b = new Matrix(new int[,] { { 1, 2, 3 }, { 2, 4, 3 } });
            Assert.Equal(a, b);
        }

        [Fact]
        public void Different_matrixes_shoul_not_be_equal()
        {
            var a = new Matrix(new int[,] { { 1, 2, 3 }, { 2, 4, 3 } });
            var b = new Matrix(new int[,] { { 1, 65, 3 }, { 2, 4, 3 } });
            Assert.NotEqual(a, b);
        }

        [Fact]
        public void Default_matrix_should_be_zeroed()
        {
            var zero = Matrix.Zero(2,2);
            Assert.Equal(zero, new Matrix(new int[2,2]));
        }
    }
}