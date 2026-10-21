namespace ConsoleApp_typedemo_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hvilket ord skal der søges efter: ");
            var soegeWord = Console.ReadLine();
            Console.Write("Hvilket tekst skal der søges i: ");
            string hoestakTekst = Console.ReadLine();

            int antalForekomster = WordCount(soegeWord, hoestakTekst);
            bool? countState = checkCount(antalForekomster);
            if (countState == null)
            {
                Console.WriteLine("Det søgte ord findes ikke i den angivne tekst.");
            }
            else
            {
                Console.WriteLine($"Ordet ‘{soegeWord}’ forekommer {antalForekomster} gange.");
                if ((bool)countState)
                {
                    string? input;

                    do {
                        // prompt user for file save location
                        Console.WriteLine("Hvor vil du gemme teksten?\n-Projektfolder (1)\n-Brugerfolder (2)\n");
                        input = Console.ReadLine();
                    
                        if (input == "1")
                        {
                            // get project directory
                            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
                            string directoryPath = Path.Combine(path, (@".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar));
                            string fileName = "typedemo_03.txt";

                            // save file in project folder                 
                            Saver saver = new Saver(directoryPath + fileName);
                            saver.saveFile(hoestakTekst);
                            Console.WriteLine("File saved in Project Folder");
                        }
                        else if (input == "2")
                        {
                            // save file in user folder
                            UserFolderSaver userFolderSaver = new UserFolderSaver();
                            userFolderSaver.saveFile(hoestakTekst);
                            Console.WriteLine("File saved in User/Documents Folder");
                        }
                        } while (input == null);
                }
            }
        }

        static int WordCount(string ord, string tekst)
        {
            int count = 0;
            int index = 0;

            while ((index = tekst.IndexOf(ord, index, StringComparison.OrdinalIgnoreCase)) != -1 && tekst != "")
            {
                count++;
                index += ord.Length;
            }
            return count;
        }
        static bool? checkCount(int count)
        {
            if (count == 0)
            {
                return null;
            }
            else if (count >= 1 && count < 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
