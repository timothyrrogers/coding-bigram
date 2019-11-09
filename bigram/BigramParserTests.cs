using NUnit.Framework;
using BigramParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigramParser.Tests
{
    [TestFixture()]
    public class BigramParserTests
    {
        [Test]
        public void WithNoWordThrowException()
        {
            BigramParser parser = new BigramParser();

            Exception ex = Assert.Throws<Exception>(() => parser.Parse(""));
            Assert.That(ex.Message, Is.EqualTo("A string needs to be supplied!"));
        }

        [Test]
        public void OneWordThrowException()
        {
            BigramParser parser = new BigramParser();

            Exception ex = Assert.Throws<Exception>(() => parser.Parse("I"));
            Assert.That(ex.Message, Is.EqualTo("A complete string needs to be supplied!"));
        }

        [Test]
        public void WithTwoWordsThatReturnsDictionaryWithCount1()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I am");
            Assert.AreEqual(i["I am"], 1);
        }

        [Test]
        public void WithTwoWordsWithPeriodThatReturnsDictionaryWithCount1()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I am.");
            Assert.AreEqual(i["I am"], 1);
        }

        [Test]
        public void WithThreeWordsWithPeriodThatReturnsDictionaryWithCounts()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I am Timothy.");
            Assert.AreEqual(i["I am"], 1);
            Assert.AreEqual(i["am Timothy"], 1);
        }

        [Test]
        public void WithFullSentenceWithPeriodThatReturnsDictionaryWithCounts()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I am Timothy and love to program.");
            Assert.AreEqual(i["I am"], 1);
            Assert.AreEqual(i["am Timothy"], 1);
            Assert.AreEqual(i["Timothy and"], 1);
            Assert.AreEqual(i["and love"], 1);
            Assert.AreEqual(i["love to"], 1);
            Assert.AreEqual(i["to program"], 1);

        }

        [Test]
        public void WithFullSentenceWithPeriodThatReturnsDictionaryIamCount2()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I am Timothy and I am a programmer.");
            Assert.AreEqual(i["I am"], 2);
            Assert.AreEqual(i["am Timothy"], 1);
            Assert.AreEqual(i["Timothy and"], 1);
            Assert.AreEqual(i["and I"], 1);
            Assert.AreEqual(i["am a"], 1);
            Assert.AreEqual(i["a programmer"], 1);

        }

        [Test]
        public void WithFullSentenceWithExclamationMarkThatReturnsDictionaryCounts()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I am Timothy and I am a programmer!");
            Assert.AreEqual(i["I am"], 2);
            Assert.AreEqual(i["am Timothy"], 1);
            Assert.AreEqual(i["Timothy and"], 1);
            Assert.AreEqual(i["and I"], 1);
            Assert.AreEqual(i["am a"], 1);
            Assert.AreEqual(i["a programmer"], 1);

        }

        [Test]
        public void WithMultiSentencesWithPunctuationThatReturnsDictionaryCounts()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I am Timothy and I am a programmer! I am testing a second sentence.");
            Assert.AreEqual(i["I am"], 3);
            Assert.AreEqual(i["am Timothy"], 1);
            Assert.AreEqual(i["Timothy and"], 1);
            Assert.AreEqual(i["and I"], 1);
            Assert.AreEqual(i["am a"], 1);
            Assert.AreEqual(i["a programmer"], 1);
            Assert.AreEqual(i["am testing"], 1);
            Assert.AreEqual(i["testing a"], 1);
            Assert.AreEqual(i["a second"], 1);
            Assert.AreEqual(i["second sentence"], 1);
        }

        [Test]
        public void WithFullSentenceWithPunctuationWithPeriodInWordThatReturnsDictionaryCounts()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I am Timothy and my email is timothyrrogers@gmail.com.");
            Assert.AreEqual(i["I am"], 1);
            Assert.AreEqual(i["am Timothy"], 1);
            Assert.AreEqual(i["Timothy and"], 1);
            Assert.AreEqual(i["and my"], 1);
            Assert.AreEqual(i["my email"], 1);
            Assert.AreEqual(i["email is"], 1);
            Assert.AreEqual(i["is timothyrrogers@gmail.com"], 1);

        }

        [Test]
        public void WithFullSentenceWithPunctuationWithCommaReturnsDictionaryCounts()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("I wouldn't consider that this is going to fail, but testing anyways.");
            Assert.AreEqual(i["I wouldn't"], 1);
            Assert.AreEqual(i["wouldn't consider"], 1);
            Assert.AreEqual(i["consider that"], 1);
            Assert.AreEqual(i["that this"], 1);
            Assert.AreEqual(i["this is"], 1);
            Assert.AreEqual(i["is going"], 1);
            Assert.AreEqual(i["going to"], 1);
            Assert.AreEqual(i["to fail"], 1);
            Assert.AreEqual(i["fail but"], 1);
            Assert.AreEqual(i["but testing"], 1);
            Assert.AreEqual(i["testing anyways"], 1);
        }

        [Test]
        public void WithFullComplexSentenceWithPunctuationWithCommaSemiColonReturnsDictionaryCounts()
        {
            BigramParser parser = new BigramParser();

            Dictionary<string, int> i = parser.Parse("The conference has people who have come from Spirit Lake, Idaho; Springfield, Virgina; Alamo, Tennessee; and other places as well.");
            //check to make sure count it correct
            Assert.AreEqual(i.Count, 19);

            Assert.AreEqual(i["The conference"], 1);
            Assert.AreEqual(i["conference has"], 1);
            Assert.AreEqual(i["has people"], 1);
            Assert.AreEqual(i["people who"], 1);
            Assert.AreEqual(i["who have"], 1);
            Assert.AreEqual(i["have come"], 1);
            Assert.AreEqual(i["come from"], 1);
            Assert.AreEqual(i["from Spirit"], 1);
            Assert.AreEqual(i["Spirit Lake"], 1);
            Assert.AreEqual(i["Lake Idaho"], 1);
            Assert.AreEqual(i["Idaho Springfield"], 1);
            Assert.AreEqual(i["Springfield Virgina"], 1);
            Assert.AreEqual(i["Virgina Alamo"], 1);
            Assert.AreEqual(i["Alamo Tennessee"], 1);
            Assert.AreEqual(i["Tennessee and"], 1);
            Assert.AreEqual(i["and other"], 1);
            Assert.AreEqual(i["other places"], 1);
            Assert.AreEqual(i["places as"], 1);
            Assert.AreEqual(i["as well"], 1);

        }
    }
}