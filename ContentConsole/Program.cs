using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;
using CommandLine.Text;
using ContentLibrary;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var typedArgs = Parser.Default.ParseArguments<CommandOptions>(args);

                if (typedArgs.Errors != null && typedArgs.Errors.Any())
                {
                    var help = HelpText.AutoBuild<CommandOptions>(typedArgs);
                    Console.WriteLine(help.ToString());
                    return;
                }
                // new List<string> { "swine", "bad", "nasty", "horrible" }
                INegativeWords wordInterface = new NegativeWords(typedArgs.Value.NegativeWords);
                WordProcessor p = new WordProcessor(wordInterface);
                p.User = typedArgs.Value.UserTypeId;

                RunApplication(p, Console.Out, typedArgs.Value);
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

        private static void RunApplication(WordProcessor p, TextWriter console, CommandOptions typedArgs)
        {
            int count;
            switch (typedArgs.Task)
            {
                default:
                case 0:
                    console.WriteLine("Running Existing code: ");
                    p.ExistingCode(console);
                    break;
                case 1:
                    console.WriteLine("Running Story 1");
                    count = p.CountNegativeWords(typedArgs.InputText);
                    Console.WriteLine("Story 1 result = {0}", count);
                    break;
                case 2:
                    console.WriteLine("Running Story 2");
                    if (typedArgs.UserTypeId != UserType.Administrator)
                    {
                        throw new UnauthorizedAccessException("You need to be an administrator to perform this action");
                    }
                    p.Words.Words.Clear();
                    p.Words.Words.AddRange(typedArgs.NegativeWords);
                    Console.WriteLine("Negative Words Set");
                    break;
                case 3:
                    console.WriteLine("Running Story 3");
                    var story3 = p.FilterNegativeWords(typedArgs.InputText);
                    console.WriteLine("Story 3 result = {0}", story3);
                    break;
                case 4:
                    console.WriteLine("Running Story 4");
                    p.DisableFiltering = (typedArgs.DisableFiltering);
                    var story4 = p.FilterNegativeWords(typedArgs.InputText);
                    console.WriteLine("Story 4 result = {0}", story4);
                    break;
            }
        }
    }

}
