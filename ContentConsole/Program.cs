using System;
using System.Collections.Generic;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                UserType user = UserType.Reader;
                if (args.Length > 0)
                {
                    user = (UserType)Convert.ToInt32(args[0]);
                }
                INegativeWords wordInterface;
                if (args.Length < 2)
                {
                    wordInterface = new NegativeWords(new List<string> { "swine", "bad", "nasty", "horrible" });
                }
                else
                {
                    wordInterface = new NegativeWords(args[1].Split(';'));
                }
                WordProcessor p = new WordProcessor(wordInterface);

                Console.WriteLine("Running Existing code: ");
                p.ExistingCode(Console.Out, args);

                Console.WriteLine("Running Story 1");
                var count = p.CountNegativeWords("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.");
                Console.WriteLine("Story 1 result = {0}", count);

                Console.WriteLine("Running Story 3");
                var story3 = p.FilterNegativeWords("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.");
                Console.WriteLine("Story 3 result = {0}", story3);

            }
            catch (Exception e)
            {
                // TODO: add better logging
                Console.Error.WriteLine("Fatal Exception caught:");
                Console.Error.WriteLine(e.ToString());
            }
            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
