using System;

namespace PalindromeFinder
{
    public class Palindrome
    {
        public int Index { get; }
        public int Length { get; }
        public string Text { get; }

        /// <summary>
        /// Generate a representation of a palindrome from its consituent pieces
        /// </summary>
        /// <param name="text">The text of the palindrome</param>
        /// <param name="index">The index of the palindrome in its source string</param>
        /// <param name="length">The length of the palindrome</param>
        public Palindrome(string text, int index, int length)
        {
            this.Text = text;
            this.Index = index;
            this.Length = length;
        }
    }
}