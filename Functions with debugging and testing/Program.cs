
using MathClassLib;

namespace Functions_with_debugging_and_testing;

partial class Program
{
    static void Main(string[] args)
    {
        var s = PrimeHelper.GetPrimeFactorsInText(10);
        System.Console.WriteLine(PrimeHelper.GetPrimeFactorsInText(39541));
        // System.Console.WriteLine(PrimeHelper.GetPrimeFactorsInText(4650));
        // System.Console.WriteLine(PrimeHelper.GetPrimeFactorsInText(4));
        // System.Console.WriteLine(PrimeHelper.GetPrimeFactorsInText(78921));
        
    }
}
