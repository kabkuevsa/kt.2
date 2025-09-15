using System;

public class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public static bool operator ==(Fraction f1, Fraction f2)
    {
        if (ReferenceEquals(f1, f2)) return true;
        if (f1 is null || f2 is null) return false;
        return f1.Numerator * f2.Denominator == f2.Numerator * f1.Denominator;
    }

    public static bool operator !=(Fraction f1, Fraction f2)
    {
        return !(f1 == f2);
    }

    public override bool Equals(object obj)
    {
        return obj is Fraction fraction && this == fraction;
    }

    public override int GetHashCode()
    {
        return (Numerator, Denominator).GetHashCode();
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

public class UserAccount
{
    public string Username { get; set; }
    public bool IsActive { get; set; }

    public UserAccount(string username, bool isActive)
    {
        Username = username;
        IsActive = isActive;
    }

    public static bool operator true(UserAccount account)
    {
        return account.IsActive;
    }

    public static bool operator false(UserAccount account)
    {
        return !account.IsActive;
    }

    public static UserAccount operator &(UserAccount left, UserAccount right)
    {
        return new UserAccount($"{left.Username}&{right.Username}", left.IsActive && right.IsActive);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var fraction1 = new Fraction(1, 2);
        var fraction2 = new Fraction(2, 4);
        var fraction3 = new Fraction(3, 4);

        Console.WriteLine($"Дроби {fraction1} == {fraction2}: {fraction1 == fraction2}");
        Console.WriteLine($"Дроби {fraction1} != {fraction2}: {fraction1 != fraction2}");
        Console.WriteLine($"Дроби {fraction1} == {fraction3}: {fraction1 == fraction3}");
        Console.WriteLine($"Дроби {fraction1} != {fraction3}: {fraction1 != fraction3}");

        var activeUser = new UserAccount("john_doe", true);
        var inactiveUser = new UserAccount("jane_smith", false);

        if (activeUser)
        {
            Console.WriteLine($"{activeUser.Username} активен");
        }

        if (inactiveUser)
        {
            Console.WriteLine($"{inactiveUser.Username} активен");
        }
        else
        {
            Console.WriteLine($"{inactiveUser.Username} неактивен");
        }

        var combinedUsers = activeUser & inactiveUser;
        Console.WriteLine($"Комбинация пользователей: {combinedUsers.Username}, Активен: {combinedUsers.IsActive}");
    }
}
