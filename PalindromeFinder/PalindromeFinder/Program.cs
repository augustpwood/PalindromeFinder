using System;
using System.Collections.Generic;
using System.Configuration;

namespace PalindromeFinder
{
    public interface IConfiguration
    {
        int NumberOfPalindromesToReport { get; set; }
        HashSet<char> IgnorableCharacters { get; set; }
    }

    public class Configuration : IConfiguration
    {
        public int NumberOfPalindromesToReport { get; set; }
        public HashSet<char> IgnorableCharacters { get; set; }

        public Configuration()
        {
            NumberOfPalindromesToReport = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfPalindromesToReport"));
            IgnorableCharacters = new HashSet<char>(ConfigurationManager.AppSettings.Get("IgnorableCharacters").ToLower().ToCharArray());
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            try {
                //Get config
                Configuration config = new Configuration();

                DoWork(config);
            } catch (Exception e)
            {
                Console.WriteLine("Error encountered:{0}{1}:{2}", Environment.NewLine, e.GetType().ToString(), e.Message);
            }
        }

        public static void DoWork(IConfiguration config)
        {
            //Get user input
            Console.WriteLine("Please enter text to search for palindromes:");
            string userInput = Console.ReadLine().ToLower();

            if (userInput.Length < 2) Console.WriteLine("At least two characters are needed to find any palindromes.");
            else
            {
                //Get palindromes list
                List<Palindrome> palindromes = PalindromeHelper.GetLongestPalindromesFromString(userInput, config.NumberOfPalindromesToReport, config.IgnorableCharacters);

                //Report palindromes
                bool atLeastOnePalindromePrinted = false;
                foreach (Palindrome p in palindromes)
                {
                    if (p != null)
                    {
                        Console.WriteLine(string.Format("Text: {0}, Index: {1}, Length: {2}", p.Text, p.Index, p.Length));
                        atLeastOnePalindromePrinted = true;
                    }
                }
                if (!atLeastOnePalindromePrinted) Console.WriteLine("No palindromes found in input.");
            }
        }
    }
}
