using System.Security.AccessControl;
using Microsoft.VisualBasic;

namespace Hospital;

class CMDLine{
    public static void displayMessage()
    {
        Console.WriteLine();
    }

    public static void displayMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    public static void displayError(string msg)
    {
        Console.WriteLine("#####");
        Console.WriteLine(msg);
        Console.WriteLine("#####");
    }

    public static string getString()
    {
        string input = Console.ReadLine();
        return input;
    }

    public static int getInt()
    {
        int i = int.Parse(Console.ReadLine());
        return i;
    }

    public static int getInt(string msg)
    {
        Console.WriteLine($"{msg}");
        int i = int.Parse(Console.ReadLine());
        return i;
    }

    public static double getDouble()
    {
        double d = double.Parse(Console.ReadLine());
        return d;
    }

    public static bool getBool()
    {
        bool b = bool.Parse(Console.ReadLine());
        return b;
    }

    //get date function

    public static int GetOption(string title, params object[] options)
    {
        if(options.Length <=0)
        {
            return -1;
        }

        Console.WriteLine(title);
        int digitsNeeded = (int)(1 + Math.Floor(Math.Log10(options.Length)));
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{(i + 1).ToString().PadLeft(digitsNeeded)}. {options[i]}");
        }

        int option = getInt($"Please enter a choice between 1 and {options.Length}.");

        return option -1;
    }
}