using System;

class Number
{
    public int Value { get; set; }

    public Number(int value)
    {
        Value = value;
    }

    public static bool operator ==(Number n1, Number n2)
    {
        if (ReferenceEquals(n1, n2)) return true;
        if (n1 is null || n2 is null) return false;
        return n1.Value == n2.Value;
    }

    public static bool operator !=(Number n1, Number n2)
    {
        return !(n1 == n2);
    }

    public override bool Equals(object obj)
    {
        return obj is Number number && Value == number.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}

class BoolWrapper
{
    public bool Value { get; set; }

    public BoolWrapper(bool value)
    {
        Value = value;
    }

    public static bool operator true(BoolWrapper bw)
    {
        return bw.Value;
    }

    public static bool operator false(BoolWrapper bw)
    {
        return !bw.Value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Number num1 = new Number(10);
        Number num2 = new Number(10);
        Number num3 = new Number(20);

        Console.WriteLine($"num1 == num2: {num1 == num2}");
        Console.WriteLine($"num1 != num2: {num1 != num2}");
        Console.WriteLine($"num1 == num3: {num1 == num3}");
        Console.WriteLine($"num1 != num3: {num1 != num3}");

        BoolWrapper trueWrapper = new BoolWrapper(true);
        BoolWrapper falseWrapper = new BoolWrapper(false);

        if (trueWrapper)
        {
            Console.WriteLine("trueWrapper имеет значение true");
        }

        if (!falseWrapper)
        {
            Console.WriteLine("falseWrapper имеет значение false");
        }
    }
}