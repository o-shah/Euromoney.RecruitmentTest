using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using ContentLibrary;

namespace ContentConsole
{
    public class CommandOptions
    {
        [Option('n', HelpText = "Provide a custom list of negative words", DefaultValue = new string[] { "swine", "bad", "nasty", "horrible" })]
        public IList<string> NegativeWords { get; set; }

        [Option('u', HelpText = "Set the current User", DefaultValue = UserType.Administrator)]
        public UserType UserTypeId { get; set; }

        [Option('t', HelpText = "Run the selected task", DefaultValue = 1)]
        public int Task { get; set; }

    }
}
