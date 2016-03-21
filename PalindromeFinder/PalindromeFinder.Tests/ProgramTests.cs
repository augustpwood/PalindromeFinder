using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace PalindromeFinder.Tests
{
    public class MockConfiguration : IConfiguration
    {
        public int NumberOfPalindromesToReport { get; set; }
        public HashSet<char> IgnorableCharacters { get; set; }

        public MockConfiguration()
        {
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void DoWorkProducesAcceptanceCriteriaForSampleInput()
        {
            using (StringReader input = new StringReader("sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop"))
            using (StringWriter output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);

                MockConfiguration testConfig = new MockConfiguration();
                testConfig.IgnorableCharacters = new HashSet<char>();
                testConfig.NumberOfPalindromesToReport = 3;

                Program.DoWork(testConfig);

                string expectedOutput = string.Format("Please enter text to search for palindromes:{0}Text: hijkllkjih, Index: 23, Length: 10{0}Text: defggfed, Index: 13, Length: 8{0}Text: abccba, Index: 5, Length: 6{0}", Environment.NewLine);
                string actualOutput = output.ToString();
                Assert.AreEqual<string>(expectedOutput, actualOutput);
            }
        }

        [TestMethod]
        public void DoWorkReportsNoPalindromesFoundWhenNoPalindromesInInput()
        {
            using (StringReader input = new StringReader("abcdef"))
            using (StringWriter output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);

                MockConfiguration testConfig = new MockConfiguration();
                testConfig.IgnorableCharacters = new HashSet<char>();
                testConfig.NumberOfPalindromesToReport = 0;

                Program.DoWork(testConfig);

                string expectedOutput = string.Format("Please enter text to search for palindromes:{0}No palindromes found in input.{0}", Environment.NewLine);
                string actualOutput = output.ToString();
                Assert.AreEqual<string>(expectedOutput, actualOutput);
            }
        }

        [TestMethod]
        public void DoWorkReportsAllDiscoveredPalindromesWhenThereAreLessThanTheNumberToReport()
        {
            using (StringReader input = new StringReader("abcbab"))
            using (StringWriter output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);

                MockConfiguration testConfig = new MockConfiguration();
                testConfig.IgnorableCharacters = new HashSet<char>();
                testConfig.NumberOfPalindromesToReport = 3;

                Program.DoWork(testConfig);

                string expectedOutput = string.Format("Please enter text to search for palindromes:{0}Text: abcba, Index: 0, Length: 5{0}Text: bab, Index: 3, Length: 3{0}", Environment.NewLine);
                string actualOutput = output.ToString();
                Assert.AreEqual<string>(expectedOutput, actualOutput);
            }
        }
    }
}
