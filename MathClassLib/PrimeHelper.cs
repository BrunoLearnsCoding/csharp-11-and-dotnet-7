namespace MathClassLib;

// A prime number (or a prime) is a natural number greater than 1 that is not a product of two smaller natural numbers. 
// A natural number greater than 1 that is not prime is called a composite number.

public class PrimeHelper
{
    public static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        if (number == 2)
        {
            return true;
        }
        if (number % 2 == 0)
        {
            return false;
        }
        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)              // for-loop skips even numbers and hence reduces number of loop execution. 
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    public static List<int> GetPrimeNumbersLessThanOrEqual(int number)
    {
        var result = new List<int>();
        for (int i = 1; i <= number; i++)
        {
            if (IsPrime(i))
            {
                result.Add(i);
            }
        }
        return result;

    }

    public static string GetPrimeFactorsInText(int number)
    {
        string result = string.Empty;
        var primes = PrimeHelper.GetPrimeNumbersLessThanOrEqual(number);
        var r = number;
        foreach (var p in primes)
        {
            if (r == 1) { break; }
            while (true)
            {
                if (r % p == 0)
                {
                    r = r / p;
                    result = result == string.Empty ? p.ToString() : result + " x " + p.ToString();
                }
                else
                {
                    break;
                }
            }
        }
        return result;

    }

}
