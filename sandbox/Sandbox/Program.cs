using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string randomWords = "hello sandbox world!!!";
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string titleCaseWords = textInfo.ToTitleCase(randomWords);
        Console.WriteLine(titleCaseWords);
        Console.WriteLine("hello sandbox world!!!");
    }
}