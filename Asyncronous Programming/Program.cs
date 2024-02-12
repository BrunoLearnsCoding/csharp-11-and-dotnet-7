using MathClassLib;
namespace Asyncronous_Programming;

/// <summary>
/// I wanted to learn how to execute a synchronous method asynchronously. Using await Task.Run(() => { [ Synchronus Code ] }), 
/// you can run synchronous code and await for the result.
/// </summary>

class Program
{
    static async Task Main(string[] args)
    {
        var primes = await FindPrimesAsync(10000);
        System.Console.WriteLine("Hello from Asynchronus!");
        PrintNumbers(primes);           


    }

    private static void PrintNumbers(List<int> numbers)
    {
        foreach (var number in numbers)
        {
            System.Console.WriteLine(number);

        }
    }

    static async Task<List<int>> FindPrimesAsync(int max) {
        List<int> primes = new();
        await Task.Run(() => {                      // This makes it possible to await for a synchronus block of code.
            primes = PrimeHelper.GetPrimeNumbersLessThanOrEqual(max);
        });
        return primes ;


    }
}
