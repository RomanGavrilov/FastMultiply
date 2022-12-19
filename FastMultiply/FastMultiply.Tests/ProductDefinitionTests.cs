using System;
using Xunit;

namespace FastMultiply.Tests
{
    public class ProductDefinitionTests
    {
        [Fact]
        public void Product_is_defined_only_when_row_count_equals_col_count()
        {
            var a = Matrix.Zero(1, 2);
            var b = Matrix.Zero(3, 2);
            Assert.Throws<ArgumentException>(() => a * b);
        }

        [Fact]
        public void Product_of_3x3matrix_3x1vector_is_defined()
        {
            var a = Matrix.Zero(3, 3);
            var b = Matrix.Zero(3, 1);
            Assert.NotNull(a * b);
        }
    }
}
