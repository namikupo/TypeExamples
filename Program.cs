namespace ConsoleApp_typedemo_01
{
    internal class Program
    {
    
    // Dynamics kan blive set som at være farlige, da programmet fortolker input automatisk til output.
    // Dette kunne føre til sikkerhedsbrister i form af code-injection, hvor at bestemt input
    // fører til remote-code-execution. 

        static void Main(string[] args)
        {
            Console.WriteLine(dynamicReturnType(123));
            Console.WriteLine(dynamicReturnType("The quick fox jumped over the lazy dog"));
            Console.WriteLine(dynamicReturnType(true));
            Console.WriteLine(dynamicReturnType(new DateTime().DayOfWeek));
        }

        public static dynamic dynamicReturnType<T>(T value)
        {
            if (value.GetType() == typeof(int))
            {
                return (Convert.ToInt32(value) + 100);
            }
            else if (value.GetType() == typeof(string))
            {
                return $"Følgende tekst modtaget: " + value;
            }
            else
            {
                return false;
            }
        }
    }
}