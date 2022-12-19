using Xunit;

namespace FastMultiply.Tests
{
    public class MultithreadedProductTests
    {
        [Fact]
        public void MultithreadedProduct_should_produce_correct_result_0()
        {
            var a = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var b = new Matrix(new int[,] { { 7, 8 }, { 9, 10 }, { 11, 12 } });
            Assert.Equal(a * b, Matrix.FastMultiply(a, b));
        }

        [Fact]
        public void MultithreadedProduct_should_produce_correct_result_1()
        {
            var a = new Matrix(new int[,] { { 5, 8, -4 }, { 6, 9, -5 }, { 4, 7, -2 } });
            var b = new Matrix(new int[,] { { 2 }, { -3 }, { 1 } });
            Assert.Equal(a * b, Matrix.FastMultiply(a, b));
        }
    }
}
