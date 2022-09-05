// В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.
void FillArray(int[,] array, int maxRndNumber)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(maxRndNumber + 1);
        }
    }
}
void PrintArray(int[,] array)
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
int[,] FindPositionSmallElement(int[,] array, int[,] position)
{
    int temp = array[0, 0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] <= temp)
            {
                position[0, 0] = i;
                position[0, 1] = j;
                temp = array[i, j];
            }
        }
    }
    Console.WriteLine($"\nMинимальный элемент: {temp}");
    return position;
}
void DeleteLines(int[,] array, int[,] positionSmallElement, int[,] arrayWithoutLines)
{
    int k = 0, l = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (positionSmallElement[0, 0] != i && positionSmallElement[0, 1] != j)
            {
                arrayWithoutLines[k, l] = array[i, j];
                l++;
            }
        }
        l = 0;
        if (positionSmallElement[0, 0] != i)
        {
            k++;
        }
    }
}
int InputNumbers(string input)
{
    Console.Write(input);
    int output = Convert.ToInt32(Console.ReadLine());
    return output;
}

Console.Clear();
Console.WriteLine($"Введите размер массива i x j и диапазон случайных значений: ");
int i = InputNumbers("\nВведите i: ");
int j = InputNumbers("\nВведите j: ");
int range = InputNumbers("\nВведите диапазон: от 1 до ");

int[,] array = new int[i, j];
FillArray(array, range);
PrintArray(array);

int[,] positionSmallElement = new int[1, 2];
positionSmallElement = FindPositionSmallElement(array, positionSmallElement);
Console.Write($"Позиция элемента: \n");
PrintArray(positionSmallElement);

int[,] arrayWithoutLines = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
DeleteLines(array, positionSmallElement, arrayWithoutLines);
Console.WriteLine($"\nПолучившийся массив:");
PrintArray(arrayWithoutLines);