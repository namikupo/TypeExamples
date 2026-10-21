using System;
using Microsoft.VisualBasic;

public static class Result
{
    public static T ErrorResult<T>(T value)
    {
        if (value.GetType() == typeof(string))
        {
            Console.WriteLine("Fejl: Ugyldigt input. Søgeord/tekst var tom.");
            Environment.Exit(1);
        }
        
        return (T)value;
    }
}