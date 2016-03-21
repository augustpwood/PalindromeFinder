using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PalindromeFinder
{
    public static class PalindromeHelper
    {
        /// <summary>
        /// Get a given number of the longest palindromes from a string.
        /// </summary>
        /// <param name="text">The text to search</param>
        /// <param name="numberToProvide">The number of palindromes to provide</param>
        /// <param name="charactersToIgnore">Any characters to ignore when looking for palindromes</param>
        /// <returns>A list of the longest palindromes</returns>
        public static List<Palindrome> GetLongestPalindromesFromString(string text, int numberToProvide, HashSet<char> charactersToIgnore = null)
        {
            // Validate arguments
            if (text.Length < 2) throw new ArgumentException("Text must be two characters or longer to find a palindrome.");

            Dictionary<string, Palindrome> palindromes = new Dictionary<string, Palindrome>();

            int shortestLength = int.MaxValue;

            if (charactersToIgnore == null) charactersToIgnore = new HashSet<char>();

            // Filter out ignorable characters
            Dictionary<int, int> cleanedIndexToOriginalIndex = new Dictionary<int, int>();
            string filteredText = GenerateCleanedTextAndMap(text, cleanedIndexToOriginalIndex, charactersToIgnore);

            // Look for even and odd palindromes
            for (int i = 1; i < text.Length; i++)
            {
                Palindrome longestEvenPalindrome = GetLongestEvenPalindromeFromInflectionPoint(filteredText, i, cleanedIndexToOriginalIndex);
                if (longestEvenPalindrome != null && 
                    (palindromes.Count < numberToProvide || 
                    longestEvenPalindrome.Length > shortestLength))
                {
                    palindromes[longestEvenPalindrome.Text] = longestEvenPalindrome;
                    if (longestEvenPalindrome.Length < shortestLength) shortestLength = longestEvenPalindrome.Length;
                }
                Palindrome longestOddPalindrome = GetLongestOddPalindromeFromInflectionPoint(filteredText, i, cleanedIndexToOriginalIndex);
                if (longestOddPalindrome != null &&
                    (palindromes.Count < numberToProvide ||
                    longestOddPalindrome.Length > shortestLength))
                {
                    palindromes[longestOddPalindrome.Text] = longestOddPalindrome;
                    if (longestOddPalindrome.Length < shortestLength) shortestLength = longestOddPalindrome.Length;
                }
            }

            List<Palindrome> longestPalindromes = palindromes.Values.Where(p => p.Length >= shortestLength).OrderByDescending(p => p.Length).Take(numberToProvide).ToList();

            // If not enough palindromes were found, fill out to appropriate number with nulls
            if (longestPalindromes.Count < numberToProvide)
            {
                for (int i = longestPalindromes.Count; i < numberToProvide; i++) longestPalindromes.Add(null);
            }

            return longestPalindromes;
        }

        /// <summary>
        /// Gets the longest even palindrome (of the format abba) centered on the given inflection point.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="inflectionPoint">The inflection points to center around.</param>
        /// <param name="filteredIndexToOriginalIndex">The map to get the original index from the text index.</param>
        /// <returns>The palindrome.</returns>
        public static Palindrome GetLongestEvenPalindromeFromInflectionPoint(string text, int inflectionPoint, Dictionary<int, int> filteredIndexToOriginalIndex)
        {
            // Find palindrome
            int lowIndex = inflectionPoint - 1;
            int highIndex = inflectionPoint;
            bool palindromePresent = false;

            if (lowIndex >= 0 && highIndex < text.Length && text[lowIndex] == text[highIndex])
            {
                palindromePresent = true;
                int nextLowIndex = lowIndex - 1;
                int nextHighIndex = highIndex + 1;
                while (nextLowIndex >= 0 && nextHighIndex < text.Length
                    && text[nextLowIndex] == text[nextHighIndex])
                {
                    lowIndex = nextLowIndex;
                    highIndex = nextHighIndex;
                    nextLowIndex--;
                    nextHighIndex++;
                }
            }

            // Build palindrome
            if (palindromePresent)
            {
                return new Palindrome(text.Substring(lowIndex, highIndex - lowIndex + 1), filteredIndexToOriginalIndex[lowIndex], highIndex - lowIndex + 1);
            }
            else return null;
        }

        /// <summary>
        /// Gets the longest odd palindrome (of the format abcba) centered on the given inflection point.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="inflectionPoint">The inflection points to center around.</param>
        /// <param name="filteredIndexToOriginalIndex">The map to get the original index from the text index.</param>
        /// <returns>The palindrome.</returns>
        public static Palindrome GetLongestOddPalindromeFromInflectionPoint(string text, int inflectionPoint, Dictionary<int, int> filteredIndexToOriginalIndex)
        {
            // Find palindrome
            int lowIndex = inflectionPoint - 1;
            int highIndex = inflectionPoint + 1;
            bool palindromePresent = false;

            if (lowIndex >= 0 && highIndex < text.Length && text[lowIndex] == text[highIndex])
            {
                palindromePresent = true;
                int nextLowIndex = lowIndex - 1;
                int nextHighIndex = highIndex + 1;
                while (nextLowIndex >= 0 && nextHighIndex < text.Length
                    && text[nextLowIndex] == text[nextHighIndex])
                {
                    lowIndex = nextLowIndex;
                    highIndex = nextHighIndex;
                    nextLowIndex--;
                    nextHighIndex++;
                }
            }

            // Build palindrome
            if (palindromePresent)
            {
                return new Palindrome(text.Substring(lowIndex, highIndex - lowIndex + 1), filteredIndexToOriginalIndex[lowIndex], highIndex - lowIndex + 1);
            }
            else return null;
        }

        /// <summary>
        /// Clean the text provided of any ignorable characters and update the map with the
        /// mapping so that the resulting Palindrome can be indexed to the original string
        /// </summary>
        /// <param name="originalText">The unclean text.</param>
        /// <param name="filteredToOriginalMap">The map to populate.</param>
        /// <param name="charactersToIgnore">The set of ignorable characters.</param>
        /// <returns>The cleaned string.</returns>
        public static string GenerateCleanedTextAndMap(string originalText, Dictionary<int,int> filteredToOriginalMap, HashSet<char> charactersToIgnore)
        {
            StringBuilder cleanString = new StringBuilder();
            int cleanStringIndex = 0;
            for (int originalStringIndex = 0; originalStringIndex < originalText.Length; originalStringIndex++)
            {
                if (!(charactersToIgnore.Contains(originalText[originalStringIndex])))
                {
                    cleanString.Append(originalText[originalStringIndex]);
                    filteredToOriginalMap[cleanStringIndex] = originalStringIndex;
                    cleanStringIndex++;
                }
            }

            return cleanString.ToString();
        }
    }
}