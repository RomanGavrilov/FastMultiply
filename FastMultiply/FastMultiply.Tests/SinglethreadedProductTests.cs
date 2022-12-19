using Xunit;

namespace FastMultiply.Tests
{
    public class SingleThreadedProductTests
    {
        [Fact]
        public void SinglethreadedProduct_should_produce_correct_result_0()
        {
            var a = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var b = new Matrix(new int[,] { { 7, 8 }, { 9, 10 }, { 11, 12 } });
            var product = new Matrix(new int[,] { { 58, 64 }, { 139, 154 } });

            Assert.Equal(product, a * b);
        }

        [Fact]
        public void SinglethreadedProduct_should_produce_correct_result_1()
        {
            var a = new Matrix(new int[,] { { 5, 8, -4 }, { 6, 9, -5 }, { 4, 7, -2 } });
            var b = new Matrix(new int[,] { { 2 }, { -3 }, { 1 } });
            var ab = a * b;
            var product = new Matrix(new int[,] { { -18 }, { -20 }, { -15 }});

            Assert.Equal(product, ab);
        }
    }
}
