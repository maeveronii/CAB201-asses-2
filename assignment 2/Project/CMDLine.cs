using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        string input = Console.ReadLine() ?? "";
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

    public static DateTime GetDateTime()
        {
            string input = Console.ReadLine();  
            DateTime result;
            string format = DATETIMEconst.DATETIMEFORMAT; // Expected format is "HH:mm dd/MM/yyyy"
            bool dtWorked = DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            if (!dtWorked)
            {
                displayError("Incorrect Date Format");
            }
            return result;
        }


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

    public static int GetOptionList(string title, List<string> options)
    {
        if(options.Count <=0)
        {
            return -1;
        }

        Console.WriteLine(title);
        int digitsNeeded = (int)(1 + Math.Floor(Math.Log10(options.Count)));
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{(i + 1).ToString().PadLeft(digitsNeeded)}. {options[i]}");
        }

        int option = getInt($"Please enter a choice between 1 and {options.Count}.");

        return option -1;
    }
}