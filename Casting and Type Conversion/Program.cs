using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
                Console.WriteLine("{0,-10}{1,10}{2,25}{3,25}", "Type", "Size", "Min Value", "Max Value");
        Console.WriteLine("{0,-10}{1,10}{2,25}{3,25}", "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
        Console.WriteLine("{0,-10}{1,10}{2,25}{3,25}", "int16", sizeof(Int16), Int16.MinValue, Int16.MaxValue);
        Console.WriteLine("{0,-10}{1,10}{2,25}{3,25}", "Int32", sizeof(Int32), Int32.MinValue, Int32.MaxValue); // int is a shortcut to Int32
        Console.WriteLine("{0,-10}{1,10}{2,25}{3,25}", "Int64", sizeof(Int64), Int64.MinValue, Int64.MaxValue);
        Console.WriteLine("{0,-10}{1,10}{2,25}{3,25}", "long", sizeof(long), long.MinValue, long.MaxValue);   // long is a shortcut tp Int64



        int max = int.MaxValue;
        max = max + 1;
        System.Console.WriteLine(max);
        double doubleToDevide = 45.78;
        try
        {
            // System.Console.WriteLine(max / 0);               // Throws a DevideByZeroExeption
            System.Console.WriteLine(doubleToDevide / 0);       // Returns infinity 


        }
        catch (Exception ex) {
            System.Console.WriteLine($"A {ex.GetType()} exeption occured.");
        }

        // for (;;);                                    // No compile error


        byte b = 255;
        b += 1;                     // Overflows silently
        System.Console.WriteLine(b);


    }
}

