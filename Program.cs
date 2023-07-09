Console.Clear();
Random rnd = new Random();

int[,] calculateSpider(int[,] mat, int m, int n)
{
    int[,] intMat;
    if (m <= 2 || n <= 2)
    {

        if (m == 2 && n == 2)
        {
            int[,] t = new int[m, n];
            t[0, 0] = mat[0, 0];
            t[0, 1] = mat[0, 1];
            t[1, 0] = mat[1, 1];
            t[1, 1] = mat[1, 0];
            return t;
        }
        else if (m == 2)
        {
            int[,] t = new int[m, n];
            for (int i = 0; i < n; i++)
            {
                t[0, i] = mat[0, i];
                t[1, n - 1 - i] = mat[1, i];
            }
            return t;
        }
        else if (n == 2)
        {
            int[,] t = new int[m, n];
            int[] stMat = new int[m * n];
            int c = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    stMat[c] = mat[i, j];
                    c++;
                }
            }
            c = 0;
            for (int i = 0; i < n; i++)
            {
                t[0, i] = stMat[c];
                c++;
            }
            for (int i = 1; i < m; i++)
            {
                t[i, 1] = stMat[c];
                c++;
            }
            if (m > 1) t[m - 1, 0] = stMat[c];
            c++;
            for (int i = m - 2; i >= 1; i--)
            {
                t[i, 0] = stMat[c];
                c++;
            }
            return t;
        }
        else return mat;
    }


    intMat = new int[m - 2, n - 2];
    int[,] internalMatrix = new int[m - 2, n - 2]; //internal matrix
    for (int i = 0; i < ((m - 2) * (n - 2)); i++)
    {
        internalMatrix[(m - 2) - 1 - i / (n - 2), (n - 2) - 1 - i % (n - 2)] = mat[m - 1 - (i / n), n - 1 - (i % n)];
    }
    intMat = calculateSpider(internalMatrix, m - 2, n - 2);

    int[,] retMat = new int[m, n]; //return matrix
                                   //copy some characters to a single dimentional array
    int[] tempMat = new int[(m * n) - ((m - 2) * (n - 2))];
    for (int i = 0; i < (m * n) - ((m - 2) * (n - 2)); i++)
    {
        tempMat[i] = mat[i / n, i % n];
    }
    int count = 0;
    //copy fist row
    for (int i = 0; i < n; i++)
    {
        retMat[0, i] = tempMat[count];
        count++;
    }
    //copy last column
    for (int i = 1; i < m; i++)
    {
        retMat[i, n - 1] = tempMat[count];
        count++;
    }
    //copy last row
    for (int i = n - 2; i >= 0; i--)
    {
        retMat[m - 1, i] = tempMat[count];
        count++;
    }
    //copy first column
    for (int i = m - 2; i >= 1; i--)
    {
        retMat[i, 0] = tempMat[count];
        count++;
    }
    //copy others
    for (int i = 1; i < m - 1; i++)
    {
        for (int j = 1; j < n - 1; j++)
        {
            retMat[i, j] = intMat[i - 1, j - 1];
        }
    }
    return retMat;
}

int[,] initMatrix(int m, int n, int start, int step)
{
    int[,] ret = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            ret[i, j] = start;
            start += step;
        }
    }
    return ret;
}

void displayMatrix(int[,] mat, int m, int n)
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write("\t{0}", mat[i, j]);
        }
        Console.WriteLine();
    }
}

int[,,] CreateArray3(int x, int y, int z)
{
    int[,,] buf = new int[x, y, z];
    int[] usedNum = new int[x * y * z];
    int test = rnd.Next(10, 100);
    int counter = 0;

    for (int j = 0; j < x * y * z; j++)
    {
        usedNum[j] = rnd.Next(10, 100);
    }
    for (int ox = 0; ox < x; ox++)
    {
        for (int oy = 0; oy < y; oy++)
        {
            for (int oz = 0; oz < z; oz++)
            {
                counter++;
                int temp = rnd.Next(10, 100);
                for (int i = 0; i < counter; i++)
                {
                    if (temp == usedNum[i])
                    {
                        System.Console.WriteLine("!!!");
                        temp = rnd.Next(10, 100);
                        usedNum[i] = temp;
                    }
                    else
                    {

                    }
                }
                buf[ox, oy, oz] = temp;
            }
        }
    }


    return buf;
}

void PrintArray3(int[,,] arr)
{
    int x = arr.GetLength(0);
    int y = arr.GetLength(1);
    int z = arr.GetLength(2);


    for (int ox = 0; ox < x; ox++)
    {
        for (int oy = 0; oy < y; oy++)
        {
            for (int oz = 0; oz < z; oz++)
            {
                // 66(0,0,0) 25(0,1,0)
                // 34(1,0,0) 41(1,1,0)
                // 27(0,0,1) 90(0,1,1)
                // 26(1,0,1) 55(1,1,1)
                arr[ox, oy, oz] = rnd.Next(10, 100);
                System.Console.Write($"{arr[ox, oy, oz]} ({ox},{oy},{oz}) ");
            }
            System.Console.WriteLine();
        }
    }
}

int EnterNumber(string message)
{
    System.Console.Write(message + " ");
    return Convert.ToInt32(Console.ReadLine());
}

int[,] CreateArray(int column, int row, int min, int max)
{
    int[,] array = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    int row = array.GetLength(1);

    int column = array.GetLength(0);

    for (int i = 0; i < column; i++)
    {
        for (int j = 0; j < row; j++)
        {
            System.Console.Write(array[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

void Loading(int time)
{
    for (int i = 1; i < 50; i++)
    {
        System.Console.Write(".");
        System.Threading.Thread.Sleep(1000 / i * time);
    }
    System.Console.Write(" Успешно завершено!");
}

int[,] FilterArray(int[,] array)
{
    int row = array.GetLength(1);
    int[] buf = new int[row];
    int column = array.GetLength(0);
    int[,] filteredArray = new int[column, row];

    for (int i = 0; i < column; i++)
    {
        for (int j = 0; j < row; j++)
        {
            buf[j] = array[i, j];
        }

        buf = SortArray(buf);
        for (int k = 0; k < row; k++)
        {
            filteredArray[i, k] = buf[k];
        }
    }
    return filteredArray;
}

int[] SortArray(int[] arr)
{
    int size = arr.Length;
    for (int i = 0; i < size; i++)
    {
        for (int j = 1; j < size; j++)
        {
            if (arr[i] > arr[j])
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
    for (int i = 0; i < size - 1; i++)
    {
        int temp = arr[i];
        arr[i] = arr[i + 1];
        arr[i + 1] = temp;
    }
    return arr;
}

int[] CalculateRow(int[,] array)
{
    int row = array.GetLength(0);

    int column = array.GetLength(1);
    int[] buf = new int[row];
    for (int i = 0; i < row; i++)
    {
        int sum = 0;
        for (int j = 0; j < column; j++)
        {
            sum += array[i, j];
        }
        buf[i] = sum;
    }
    return buf;
}

int FindMinElement(int[] array)
{
    int minIndex = 0;
    int minEl = array[0];
    for (int i = 0; i < array.Length - 1; i++)
    {
        if (minEl > array[i + 1])
        {
            minEl = array[i + 1];
            minIndex = i + 1;
        }
    }
    return minIndex;
}

bool CheckArrays(int[,] arr1, int[,] arr2)
{
    int height1 = arr1.GetLength(0), height2 = arr2.GetLength(0);
    int width1 = arr1.GetLength(1), width2 = arr2.GetLength(1);
    if (height1 == width2 && width1 == height2) return true;
    return false;
}

int[,] RevertArray(int[,] array)
{
    int width = array.GetLength(1);//столбцы
    int height = array.GetLength(0);//строки
    // System.Console.WriteLine(width);
    // System.Console.WriteLine(height);
    int[,] buf = new int[width, height];
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            buf[j, i] = array[i, j];
        }
    }

    return buf;
}

int[,] MultiArray(int[,] a, int[,] b)
{
    int height1 = a.GetLength(0), height2 = b.GetLength(0);
    // System.Console.WriteLine("height1=" + height1 + " height2=" + height2);
    int width1 = a.GetLength(1), width2 = b.GetLength(1);
    // System.Console.WriteLine("width1=" + width1 + " width2=" + width2);

    int[,] buf = new int[height1, width2];
    for (int i = 0; i < height1; i++)
    {
        for (int j = 0; j < width2; j++)
        {
            for (int k = 0; k < height2; k++)
            {
                buf[i, j] += a[i, k] * b[k, j];
            }
        }
    }
    return buf;
}


// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

// int m = EnterNumber("Введите количество столбцов массива:");
// int n = EnterNumber("Введите количество строк массива:");

// int[,] array = CreateArray(m, n, 1, 9);
// PrintArray(array);
// int[,] resultArr = FilterArray(array);
// System.Console.WriteLine();
// PrintArray(resultArr);

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

// int m = EnterNumber("Введите количество столбцов массива:");
// int n = EnterNumber("Введите количество строк массива:");

// int[,] array = CreateArray(m, n, 1, 9);
// PrintArray(array);
// int[] result = CalculateRow(array);
// int answer = FindMinElement(result);
// System.Console.WriteLine($"{answer + 1} строка с наименьшей суммой элементов");

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// int m = EnterNumber("Введите количество столбцов массива:");
// int n = EnterNumber("Введите количество строк массива:");

// int[,] array = CreateArray(m, n, 1, 9);
// PrintArray(array);

// int m2 = EnterNumber("Введите количество столбцов массива:");
// int n2 = EnterNumber("Введите количество строк массива:");

// int[,] array2 = CreateArray(m2, n2, 1, 9);
// PrintArray(array2);

// bool check = CheckArrays(array, array2);
// System.Console.WriteLine();
// if (check)
// {
//     System.Console.WriteLine("Сейчас перемножу!");
//     int[,] result = MultiArray(array, array2);
//     PrintArray(result);
// }
// else
// {
//     System.Console.WriteLine("Перемножение не возможно!");
// }
// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// int x = EnterNumber("Введите x массива:");
// int y = EnterNumber("Введите y массива:");
// int z = EnterNumber("Введите z массива:");

// int CountNumbers = x * y * z;

// System.Console.WriteLine($"Количество ячеек = {CountNumbers}");
// if (CountNumbers < 100)
// {
//     System.Console.WriteLine("Массив двухзначных чисел - возможен!");
//     int[,,] array3 = CreateArray3(x, y, z);
//     PrintArray3(array3);
// }
// else
// {
//     System.Console.WriteLine("Массив из двухзначных неповторяющихся чисел - невозможен");
// }


// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04 
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07


int m = 0, n = 0, start = 0, step = 0;
bool errorOcured = false;
try
{
    Console.Write("Введите количество строк: ");
    m = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество колонок: ");
    n = Convert.ToInt32(Console.ReadLine());

    Console.Write("Введите начальное число: ");
    start = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите шаг: ");
    step = Convert.ToInt32(Console.ReadLine());
    if (m < 0 || n < 0 || start < 0 || step < 0) throw new FormatException();
}
catch (FormatException e)
{
    Console.WriteLine("Ошибка при вводе! [Details: {0}]", e.Message);
    errorOcured = true;
}

if (!errorOcured)
{
    int[,] mat = new int[m, n];
    mat = initMatrix(m, n, start, step);

    Console.WriteLine("\nIntial matrix generated is:");
    displayMatrix(mat, m, n);

    Console.WriteLine("\nSpiral Matrix generated is:");
    mat = calculateSpider(mat, m, n);
    displayMatrix(mat, m, n);
}