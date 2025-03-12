using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Виберіть задачу для вирішення (1-4):");
        int task = int.Parse(Console.ReadLine());

        switch (task)
        {
            case 1:
                Task1();
                break;
            case 2:
                Task2();
                break;
            case 3:
                Task3();
                break;
            case 4:
                Task4();
                break;
            default:
                Console.WriteLine("Невірний номер задачі.");
                break;
        }
    }

    static void Task1()
    {
        Console.WriteLine("Задача 1: Введіть розмірність масиву:");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Введіть число для порівняння:");
        int x = int.Parse(Console.ReadLine());

        Console.WriteLine("Номери елементів більших за задане число:");
        for (int i = 0; i < n; i++)
        {
            if (arr[i] > x)
            {
                Console.WriteLine(i);
            }
        }

        int[,] matrix = new int[n, n];
        Console.WriteLine("Введіть елементи двовимірного масиву:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Номери елементів більших за задане число у двовимірному масиві:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] > x)
                {
                    Console.WriteLine($"Елемент на позиції ({i},{j})");
                }
            }
        }
    }

    static void Task2()
    {
        Console.WriteLine("Задача 2: Введіть розмірність масиву:");
        int n = int.Parse(Console.ReadLine());

        double[] arr = new double[n];
        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = double.Parse(Console.ReadLine());
        }

        int minIndex = 0, maxIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (arr[i] < arr[minIndex]) minIndex = i;
            if (arr[i] > arr[maxIndex]) maxIndex = i;
        }

        double temp = arr[minIndex];
        arr[minIndex] = arr[maxIndex];
        arr[maxIndex] = temp;

        Console.WriteLine("Масив після обміну:");
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }

    static void Task3()
    {
        Console.WriteLine("Задача 3: Введіть розмірність масиву (n x n):");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int[,] result = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            result[i, i] = 1;
        }

        for (int power = 0; power < n; power++)
        {
            result = MultiplyMatrices(result, matrix, n);
        }

        Console.WriteLine("Матриця A^n:");
        PrintMatrix(result, n);
    }

    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2, int size)
    {
        int[,] result = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < size; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }

    static void PrintMatrix(int[,] matrix, int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Task4()
    {
        Console.WriteLine("Задача 4: Введіть розмірність масиву:");
        int n = int.Parse(Console.ReadLine());

        int[][] stairArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введіть кількість елементів для рядка {i + 1}:");
            int m = int.Parse(Console.ReadLine());
            stairArray[i] = new int[m];
            Console.WriteLine($"Введіть елементи для рядка {i + 1}:");
            for (int j = 0; j < m; j++)
            {
                stairArray[i][j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Введіть інтервал для фільтрації:");
        Console.WriteLine("Мінімум:");
        int minVal = int.Parse(Console.ReadLine());
        Console.WriteLine("Максимум:");
        int maxVal = int.Parse(Console.ReadLine());

        int[] resultArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            foreach (var item in stairArray[i])
            {
                if (item < minVal || item > maxVal)
                {
                    sum += item;
                }
            }
            resultArray[i] = sum;
        }

        Console.WriteLine("Результати для кожного рядка:");
        foreach (var sum in resultArray)
        {
            Console.WriteLine(sum);
        }
    }
}
