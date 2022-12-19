using FastMultiply;
 
 
var A = new Matrix(new int[,] { { 1, 2, 3}, { 4, 5, 6 } });
var B = new Matrix(new int[,] { { 7, 8 }, { 9, 10 }, { 11, 12 } });

Matrix.Print(A * B);