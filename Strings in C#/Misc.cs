using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
namespace first_project
{
    public class Calculator
    {
        public static async Task<int[]> GetOddNumbersAsync(int number)
        {
            int[] oddNumbers = Array.Empty<int>();
            int counter = 0;
            oddNumbers[counter] = 1;
            await Task.Run(() =>
            {
                for (int i = 2; i <= number; i++)
                {
                    for (int j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0) break;
                        WriteLine(i);
                    }
                }
            });
            return oddNumbers;
        }
    }

    public class BinaryHelper
    {

        public static void DisplayNumbersInBinary(int maxNumber)
        {
            const int space = -15;
            for (int i = 0; i <= maxNumber; i = i + 5)
            {
                WriteLine($"{i,-5} {Convert.ToString(i, 2).PadLeft(8,'0'),space} {Convert.ToString(i+1, 2).PadLeft(8,'0'),space} {Convert.ToString(i+2, 2).PadLeft(8,'0'),space} {Convert.ToString(i+3, 2).PadLeft(8,'0'),space} {Convert.ToString(i + 4, 2).PadLeft(8,'0'),space}" );
            }
        }

        public static int BitwiseAddNumber(int a, int b)
        {
            if (b == 0) return a;
            int carry = (a & b) << 1;
            int result = a ^ b;
            return BitwiseAddNumber(result, carry);
        }

   }
    public class RecursiveFunctionsHelper
    {

        public static void DisplayNumbersAscending(int to, int from = 1) 
        {
            if (from > to) return;
            Write($"{from} ");
            DisplayNumbersAscending(to, from + 1);
        }
        public static void DisplayNumbersDescending(int a)
        {
            if (a == 0) return;
            Write($"{a} ");
            DisplayNumbersDescending(a - 1);
        }

        public static bool IsPrime(int number) {
            return CheckForPrime(number);
        }

        private static bool CheckForPrime(int number, int divisor = 2) {
            if (number == 1) return true;
            if (divisor > number / 2 ) return true;
            if (number % divisor == 0) {
                WriteLine($"{number} is divisable by {divisor}");
                return false;
            }
            return CheckForPrime(number, divisor + 1);
        }
        /** <summery>
        Permutation means : each of several possible ways in which a set or number of things can be ordered or arranged.
        This method generates all possible permutations of numbers in an array and returns it in an array. 
        </summery> */
        public static int[]? GetAllPossiblePermutations(int[] array) {
            if (array.Length == 0) return result;

        }
    }

}
