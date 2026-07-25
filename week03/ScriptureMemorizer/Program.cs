using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            Scripture scripture = new Scripture(reference,
                "Trust in the Lord with all thine heart and lean not unto thine own understanding");

            while (true)
            {
                SafeClear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input?.ToLower() == "quit")
                    break;

                scripture.HideRandomWords();

                if (scripture.AllWordsHidden())
                {
                    SafeClear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden. Program ending...");
                    break;
                }
            }
        }

        // ✅ Safe clear method to avoid IOException
        static void SafeClear()
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                // Fallback: simulate clearing by printing blank lines
                Console.WriteLine(new string('\n', 20));
            }
        }
    }
}
