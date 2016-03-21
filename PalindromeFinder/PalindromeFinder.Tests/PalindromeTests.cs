using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PalindromeFinder.Tests
{
    [TestClass]
    public class PalindromeTests
    {
        [TestMethod]
        public void PalindromeConstructorTest()
        {
            string text = "aba";
            int index = 0;
            int length = 1;

            var testPalindrome = new Palindrome(text, index, length);
            Assert.AreEqual(text, testPalindrome.Text, "Expected text set not present in object");
            Assert.AreEqual(index, testPalindrome.Index, "Expected index set not present in object");
            Assert.AreEqual(length, testPalindrome.Length, "Expected length set not present in object");
        }

        
    }
}
