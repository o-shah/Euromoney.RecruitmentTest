﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContentLibrary
{
    public class WordProcessor
    {
        public WordProcessor(INegativeWords wordInterface)
        {
            User = UserType.Reader;
            // Todo: convert to Ninjected processor or something similar.
            Words = wordInterface;
        }

        public UserType User { get; set; }
        public INegativeWords Words { get; set; }
        public bool DisableFiltering
        {
            get
            {
                return disableFiltering;
            }
            set
            {
                if (User != UserType.Administrator && User != UserType.Curator)
                {
                    throw new UnauthorizedAccessException("You do not have the rights to perform this action.");
                }
                disableFiltering = value;
            }
        }
        private bool disableFiltering;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "This is old code that was present in the original version")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is old code that was present in the original version")]
        public void ExistingCode(TextWriter console)
        {
            string bannedWord1 = "swine";
            string bannedWord2 = "bad";
            string bannedWord3 = "nasty";
            string bannedWord4 = "horrible";

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            int badWords = 0;
            if (content.Contains(bannedWord1))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord2))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord3))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord4))
            {
                badWords = badWords + 1;
            }

            console.WriteLine("Scanned the text:");
            console.WriteLine(content);
            console.WriteLine("Total Number of negative words: " + badWords);
        }

        public int CountNegativeWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("input is invalid", "input", null);
            }

            // Skip validation for usertype here.
            IList<string> negativeWords = this.Words.Words;
            var inputSentence = input.Split(new[] { ' ', '.', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);

            var result = inputSentence.Count(c => negativeWords.Any(d => d.Equals(c, StringComparison.CurrentCultureIgnoreCase)));
            return result;
        }

        public string FilterNegativeWords(string input)
        {
            // Skip validation for usertype here.
            if (this.DisableFiltering)
            {
                return input;
            }
            // an old verison of this function had two bugs: punctuation is lost. you forgot to do ## ing. No time to sort

            IList<string> negativeWords = this.Words.Words;
            var inputSentence = input;

            foreach (var word in negativeWords)
            {
                var replacementWord = word.First() + new string('#', word.Length - 2) + word.Last();
                inputSentence = inputSentence.Replace(word, replacementWord);
            }
            return inputSentence;
        }
    }
}
