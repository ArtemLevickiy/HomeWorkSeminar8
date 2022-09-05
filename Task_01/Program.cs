// Найти произведение двух матриц
void MultiplyMatrix(int[,] firstMartrix, int[,] secondMatrix, int[,] resultMatrix)
{
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < firstMartrix.GetLength(1); k++)
            {
                sum += firstMartrix[i, k] * secondMatrix[k, j];
            }
            resultMatrix[i, j] = sum;
        }
    }
}
void CreateArray(int[,] array,int maxRndNumber)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(maxRndNumber);
        }
    }
}
void WriteArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}
int InputNumbers(string input)
{
    Console.Write(input);
    int output = Convert.ToInt32(Console.ReadLine());
    return output;
}

Console.Clear();
Console.WriteLine($"Сразу зададим матрицу, которую можно перемножить, т.е. количество столбцов первой равно количеству строк второй.");
int a = InputNumbers("\nВведите количество строк 1-й матрицы: ");
int b = InputNumbers("\nВведите количество столбцов 1-й матрицы (и строк 2-й): ");
int c = InputNumbers("\nВведите количество столбцов 2-й матрицы: ");
int range = InputNumbers("\nВведите диапазон случайных чисел: от 1 до ");

int[,] firstMartrix = new int[a, b];
CreateArray(firstMartrix,range);
Console.WriteLine($"\nПервая матрица:");
WriteArray(firstMartrix);

int[,] secondMatrix = new int[b, c];
CreateArray(secondMatrix,range);
Console.WriteLine($"\nВторая матрица:");
WriteArray(secondMatrix);

int[,] resultMatrix = new int[a, c];

MultiplyMatrix(firstMartrix, secondMatrix, resultMatrix);
Console.WriteLine($"\nПроизведение первой и второй матриц:");
WriteArray(resultMatrix);