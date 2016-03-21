using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PalindromeFinder;
using System.Linq;

namespace PalindromeFinder.Tests
{
    [TestClass]
    public class PalindromeHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetLongestPalindromesFromStringErrorsWhenInputLengthIsLessThanTwo()
        {
            string inputString = "a";
            List<Palindrome> testPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, 1);
        }

        [TestMethod]
        public void GetLongestEvenPalindromeFromInflectionPointReturnsLongestPalindromeCenteredAtInflectionPoint()
        {
            string inputString = "xabccbay";
            int inflectionPoint = 4;
            Dictionary<int, int> filteredToOriginal = new Dictionary<int, int>();
            for (int i = 0; i < inputString.Length; i++) filteredToOriginal[i] = i;
            Palindrome testPalindrome = PalindromeHelper.GetLongestEvenPalindromeFromInflectionPoint(inputString, inflectionPoint, filteredToOriginal);
            Assert.AreEqual("abccba", testPalindrome.Text);
            Assert.AreEqual(6, testPalindrome.Length);
            Assert.AreEqual(1, testPalindrome.Index);
        }

        [TestMethod]
        public void GetLongestEvenPalindromeFromInflectionPointReturnsNullWhenThereIsNoEvenPalindromeAtThatPoint()
        {
            string inputString = "abbacdaba";
            int inflectionPoint = 4;
            Dictionary<int, int> filteredToOriginal = new Dictionary<int, int>();
            for (int i = 0; i < inputString.Length; i++) filteredToOriginal[i] = i;
            Palindrome testPalindrome = PalindromeHelper.GetLongestEvenPalindromeFromInflectionPoint(inputString, inflectionPoint, filteredToOriginal);
            Assert.AreEqual(null, testPalindrome);
        }

        [TestMethod]
        public void GetLongestEvenPalindromeFromInflectionPointReturnsLongestPalindrome1FromAcceptanceCriteria()
        {
            string inputString = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            int inflectionPoint = 28;
            Dictionary<int, int> filteredToOriginal = new Dictionary<int, int>();
            for (int i = 0; i < inputString.Length; i++) filteredToOriginal[i] = i;
            Palindrome testPalindrome = PalindromeHelper.GetLongestEvenPalindromeFromInflectionPoint(inputString, inflectionPoint, filteredToOriginal);
            Assert.AreEqual("hijkllkjih", testPalindrome.Text);
            Assert.AreEqual(10, testPalindrome.Length);
            Assert.AreEqual(23, testPalindrome.Index);
        }

        [TestMethod]
        public void GetLongestEvenPalindromeFromInflectionPointReturnsLongestPalindrome2FromAcceptanceCriteria()
        {
            string inputString = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            int inflectionPoint = 17;
            Dictionary<int, int> filteredToOriginal = new Dictionary<int, int>();
            for (int i = 0; i < inputString.Length; i++) filteredToOriginal[i] = i;
            Palindrome testPalindrome = PalindromeHelper.GetLongestEvenPalindromeFromInflectionPoint(inputString, inflectionPoint, filteredToOriginal);
            Assert.AreEqual("defggfed", testPalindrome.Text);
            Assert.AreEqual(8, testPalindrome.Length);
            Assert.AreEqual(13, testPalindrome.Index);
        }

        [TestMethod]
        public void GetLongestEvenPalindromeFromInflectionPointReturnsLongestPalindrome3FromAcceptanceCriteria()
        {
            string inputString = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            int inflectionPoint = 8;
            Dictionary<int, int> filteredToOriginal = new Dictionary<int, int>();
            for (int i = 0; i < inputString.Length; i++) filteredToOriginal[i] = i;
            Palindrome testPalindrome = PalindromeHelper.GetLongestEvenPalindromeFromInflectionPoint(inputString, inflectionPoint, filteredToOriginal);
            Assert.AreEqual("abccba", testPalindrome.Text);
            Assert.AreEqual(6, testPalindrome.Length);
            Assert.AreEqual(5, testPalindrome.Index);
        }

        [TestMethod]
        public void GetLongestOddPalindromeFromInflectionPointReturnsLongestPalindromeCenteredAtInflectionPoint()
        {
            string inputString = "xabcbay";
            int inflectionPoint = 3;
            Dictionary<int, int> filteredToOriginal = new Dictionary<int, int>();
            for (int i = 0; i < inputString.Length; i++) filteredToOriginal[i] = i;
            Palindrome testPalindrome = PalindromeHelper.GetLongestOddPalindromeFromInflectionPoint(inputString, inflectionPoint, filteredToOriginal);
            Assert.AreEqual("abcba", testPalindrome.Text);
            Assert.AreEqual(5, testPalindrome.Length);
            Assert.AreEqual(1, testPalindrome.Index);
        }

        [TestMethod]
        public void GetLongestOddPalindromeFromInflectionPointReturnsNullWhenThereIsNoOddPalindromeAtThatPoint()
        {
            string inputString = "abbacdaba";
            int inflectionPoint = 4;
            Dictionary<int, int> filteredToOriginal = new Dictionary<int, int>();
            for (int i = 0; i < inputString.Length; i++) filteredToOriginal[i] = i;
            Palindrome testPalindrome = PalindromeHelper.GetLongestOddPalindromeFromInflectionPoint(inputString, inflectionPoint, filteredToOriginal);
            Assert.AreEqual(null, testPalindrome);
        }


        [TestMethod]
        public void GetLongestPalindromesFromStringReturnsAcceptancePalindromesWhenAcceptanceStringProvidedAndNumberOfPalindromesIs3()
        {
            int numberToReport = 3;
            string inputString = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            List<Palindrome> longestPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, numberToReport);
            Assert.AreEqual("hijkllkjih", longestPalindromes[0].Text);
            Assert.AreEqual(23, longestPalindromes[0].Index);
            Assert.AreEqual(10, longestPalindromes[0].Length);
            Assert.AreEqual("defggfed", longestPalindromes[1].Text);
            Assert.AreEqual(13, longestPalindromes[1].Index);
            Assert.AreEqual(8, longestPalindromes[1].Length);
            Assert.AreEqual("abccba", longestPalindromes[2].Text);
            Assert.AreEqual(5, longestPalindromes[2].Index);
            Assert.AreEqual(6, longestPalindromes[2].Length);
        }

        [TestMethod]
        public void GetLongestPalindromesFromStringReturnsNullsWhenNoPalindromesAreFound()
        {
            int numberToReport = 3;
            string inputString = "abcdefg";
            List<Palindrome> longestPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, numberToReport);
            Assert.AreEqual(null, longestPalindromes[0]);
            Assert.AreEqual(null, longestPalindromes[1]);
            Assert.AreEqual(null, longestPalindromes[2]);
        }

        [TestMethod]
        public void GetLongestPalindromesFromStringReturnsEmptyListWhenNumberToReportIs0()
        {
            int numberToReport = 0;
            string inputString = "abcdefg";
            List<Palindrome> longestPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, numberToReport);
            Assert.AreEqual(0, longestPalindromes.Count);
        }

        [TestMethod]
        public void GetLongestPalindromesFromStringFillsOutToNumberToProvideWithNulls()
        {
            int numberToReport = 3;
            string inputString = "abccba";
            List<Palindrome> longestPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, numberToReport);
            Assert.AreEqual(numberToReport, longestPalindromes.Count);
            Assert.AreEqual("abccba", longestPalindromes[0].Text);
            Assert.AreEqual(0, longestPalindromes[0].Index);
            Assert.AreEqual(6, longestPalindromes[0].Length);
            Assert.AreEqual(null, longestPalindromes[1]);
            Assert.AreEqual(null, longestPalindromes[2]);
        }

        [TestMethod]
        public void GetLongestPalindromesFromStringChoosesBothOddAndEvenPalindromes()
        {
            int numberToReport = 3;
            string inputString = "abccbab";
            List<Palindrome> longestPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, numberToReport);
            Assert.AreEqual("abccba", longestPalindromes[0].Text);
            Assert.AreEqual(0, longestPalindromes[0].Index);
            Assert.AreEqual(6, longestPalindromes[0].Length);
            Assert.AreEqual("bab", longestPalindromes[1].Text);
            Assert.AreEqual(4, longestPalindromes[1].Index);
            Assert.AreEqual(3, longestPalindromes[1].Length);
            Assert.AreEqual(null, longestPalindromes[2]);
        }

        [TestMethod]
        public void GetLongestPalindromesFromStringRespectsIgnorableCharacters()
        {
            int numberToReport = 3;
            string inputString = "abccb ab";
            List<Palindrome> longestPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, numberToReport, new HashSet<char> { ' ' });
            Assert.AreEqual("abccba", longestPalindromes[0].Text);
            Assert.AreEqual(0, longestPalindromes[0].Index);
            Assert.AreEqual(6, longestPalindromes[0].Length);
            Assert.AreEqual("bab", longestPalindromes[1].Text);
            Assert.AreEqual(4, longestPalindromes[1].Index);
            Assert.AreEqual(3, longestPalindromes[1].Length);
            Assert.AreEqual(null, longestPalindromes[2]);
        }

        [TestMethod]
        public void GetLongestPalindromesFromStringRespectsIgnorableCharactersAtStartOfText()
        {
            int numberToReport = 3;
            string inputString = " abccb ab";
            List<Palindrome> longestPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, numberToReport, new HashSet<char> { ' ' });
            Assert.AreEqual("abccba", longestPalindromes[0].Text);
            Assert.AreEqual(1, longestPalindromes[0].Index);
            Assert.AreEqual(6, longestPalindromes[0].Length);
            Assert.AreEqual("bab", longestPalindromes[1].Text);
            Assert.AreEqual(5, longestPalindromes[1].Index);
            Assert.AreEqual(3, longestPalindromes[1].Length);
            Assert.AreEqual(null, longestPalindromes[2]);
        }

        [TestMethod]
        public void GetLongestPalindromesFromStringReturnsOnlyAsManyAsAskedForIfMoreWithMaximumLengthThanRequested()
        {
            int numberToReport = 3;
            string inputString = "abacdcefeghgiji";
            List<Palindrome> longestPalindromes = PalindromeHelper.GetLongestPalindromesFromString(inputString, numberToReport);
            Assert.AreEqual(numberToReport, longestPalindromes.Count());
        }
    }
}
