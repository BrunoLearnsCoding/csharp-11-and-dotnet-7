// TODO: Analyze how Buuble sort algorithm from ChatGPT works.
// TODO: Compare execution times of two bubble sort methods.
// TODO : Create a method to sort an array of integers using selection sort algorithm
// TODO : Create a method to sort an array of integers using merge sort algorithm
// TODO: Compare sort algorithm's performance
internal enum PrintDirection {
    Vertical,
    Horizontal
}

internal class Program
{
    internal static void Main(string[] args)
    {
        int[] numbers = { 1400, 45, 180, 62, 23, 150 };
        PrintArray(BubbleSortA(numbers));
        var a = GetArrayWithRandomIntegers(size:500, min:1, max:1000);
        PrintArray(BubbleSortA(a));
        PrintArray(BubbleSortB(a));


    }

    /// <summary>
    /// This is my implementation of bubble sort algorithm. 
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    internal static int[] BubbleSortA(int[] arr)
    {
        int loops = 0;
        bool scrumbled = true;
        while (scrumbled)
        {
            scrumbled = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    var temp = arr[i];
                    arr[i] = arr[i+1];
                    arr[i+1] = temp;
                    scrumbled = true;
                }
                loops++;
            }

        }
        System.Console.WriteLine($"The for-loop executed {loops} time(s)");
        return arr;
    }
    /// <summary>
    /// This is the bubble sort implementation from ChatGPT
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    internal static int[] BubbleSortB(int[] arr) {
        int n = arr.Length;
        int loops = 0;
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - i - 1; j++ ) {
                    var temp = arr[i];
                    arr[i] = arr[i+1];
                    arr[i+1] = temp;
                    loops++;
            }
        }
        System.Console.WriteLine($"The for-loop executed {loops} time(s)");

        return arr;
    }


    internal static void PrintArray(int[] arr, PrintDirection direction = PrintDirection.Horizontal)
    {
        for (int i = 0; i <= arr.GetUpperBound(0); i++)
        {
            switch (direction)
            {
                case PrintDirection.Vertical: 
                    Console.WriteLine(arr[i]);
                    break;
                default:
                    Console.Write(arr[i] + " ");
                    break;
            }            
        }
        Console.WriteLine(new string('-', 50));
    }

    internal static int[] GetArrayWithRandomIntegers(int size, int min = 1, int max = 100_000) {
        int[] arr = new int[size];
        for (int i = 0; i <= size-1; i++) {
            arr[i] = Random.Shared.Next(min, max);
        }
        return arr;
    }


}