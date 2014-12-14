using System;
using System.Collections.Generic;
using System.Linq;
using ContentLibrary;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var typedArgs = CommandLine.Parser.Default.ParseArguments<CommandOptions>(args);

                if (typedArgs.Errors != null && typedArgs.Errors.Any())
                {
                    var help = CommandLine.Text.HelpText.AutoBuild<CommandOptions>(typedArgs);
                    Console.WriteLine(help.ToString());
                    return;
                }
                // new List<string> { "swine", "bad", "nasty", "horrible" }
                INegativeWords wordInterface = new NegativeWords(typedArgs.Value.NegativeWords);
                WordProcessor p = new WordProcessor(wordInterface);
                p.User = typedArgs.Value.UserTypeId;

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
