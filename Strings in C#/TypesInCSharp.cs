using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class TypesInCSharp
{

    private static string[] types = {"byte", "sbyte", "short", "ushort", "int", "uint", "long", "ulong", "float", "double", "decimal"};

    public static void DisplayTypeTable()
    {
        WriteLine(new string('-', 100));
        WriteLine("{0,-10}{1,-20}{2,-35}{3,-35}", "Type", "Byte(s) of memory", "Min Value", "Max Value");
        WriteLine(new string('-', 100));
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:N0}{3,-35:N0}","sbyte",sizeof(sbyte),sbyte.MinValue,sbyte.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:N0}{3,-35:N0}","short",sizeof(short),short.MinValue,short.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:N0}{3,-35:N0}","byte",sizeof(byte),byte.MinValue,byte.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:N0}{3,-35:N0}","ushort",sizeof(ushort),ushort.MinValue,ushort.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:N0}{3,-35:N0}","int",sizeof(int),int.MinValue,int.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:N0}{3,-35:N0}","uint",sizeof(uint),uint.MinValue,uint.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:N0}{3,-35:N0}","long",sizeof(long),long.MinValue,long.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:N0}{3,-35:N0}","ulong",sizeof(ulong),ulong.MinValue,ulong.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:E}{3,-35:E}","float",sizeof(float),float.MinValue,float.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:E}{3,-35:E}","double",sizeof(double),double.MinValue,double.MaxValue);
        WriteLine("{0,-10:N}{1,-20:N0}{2,-35:E}{3,-35:E}","decimal",sizeof(decimal),decimal.MinValue,decimal.MaxValue); 
    }

}
