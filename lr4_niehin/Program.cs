using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int K = 5;
        int N = (int)(20 + 0.6 * K);

        int[] array = new int[N];
        Random rnd = new Random();

        for (int i = 0; i < N; i++)
        {
            array[i] = rnd.Next(10, 101);
        }

        Console.WriteLine("Вихідний масив:");
        PrintArray(array);

        QuickSort(array, 0, array.Length - 1);

        Console.WriteLine("\nВідсортований масив (Швидке сортування):");
        PrintArray(array);

        Console.Write("\nВведіть ключове значення для пошуку (від 10 до 100): ");
        if (int.TryParse(Console.ReadLine(), out int key))
        {
            int count = CountOccurrencesBinary(array, key);
            Console.WriteLine($"Значення {key} зустрічається в масиві {count} раз(ів).");
        }
        else
        {
            Console.WriteLine("Некоректний ввід!");
        }

        Console.WriteLine("\nДля виходу натисніть будь-яку клавішу...");
        Console.ReadKey();
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);
            QuickSort(arr, left, pivotIndex);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[(left + right) / 2];
        int i = left - 1;
        int j = right + 1;

        while (true)
        {
            do { i++; } while (arr[i] < pivot);
            do { j--; } while (arr[j] > pivot);

            if (i >= j) return j;

            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    static int CountOccurrencesBinary(int[] arr, int key)
    {
        int index = BinarySearchFirst(arr, key);
        if (index == -1) return 0;

        int count = 0;
        int tempIndex = index;
        while (tempIndex >= 0 && arr[tempIndex] == key)
        {
            count++;
            tempIndex--;
        }

        tempIndex = index + 1;
        while (tempIndex < arr.Length && arr[tempIndex] == key)
        {
            count++;
            tempIndex++;
        }

        return count;
    }

    static int BinarySearchFirst(int[] arr, int key)
    {
        int left = 0;
        int right = arr.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == key)
            {
                result = mid;
                right = mid - 1;
            }
            else if (arr[mid] < key)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return result;
    }
}