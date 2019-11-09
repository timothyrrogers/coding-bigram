﻿using NUnit.Framework;
using BigramParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigramParser.Tests
{
    [TestFixture()]
    public class HistogramTests
    {
        [Test]
        public void SendNoValueThrowException()
        {
            Histogram histogram = new Histogram();
            Exception ex = Assert.Throws<Exception>(() => histogram.DisplayHistogram(""));
            Assert.That(ex.Message, Is.EqualTo("A string needs to be supplied!"));
        }

        [Test]
        public void SendOnlyOneWordThrowException()
        {
            Histogram histogram = new Histogram();
            Exception ex = Assert.Throws<Exception>(() => histogram.DisplayHistogram("I"));            
            Assert.That(ex.Message, Is.EqualTo("A complete string needs to be supplied!"));

        }

        [Test]
        public void SendValueOfStringAndGetHtmlOfHistogram()
        {
            Histogram histogram = new Histogram();
            
            string value = histogram.DisplayHistogram("I am the greatest.");

            Assert.AreEqual(value, SendValueOfStringAndGetHtmlOfHistogramText);
        }

        private const string SendValueOfStringAndGetHtmlOfHistogramText = @"<ul>
<li>""I am"" : 1</li>
<li>""am the"" : 1</li>
<li>""the greatest"" : 1</li>
</ul>
";

        private const string GettysburgAddressPart = @"Four score and seven years ago our fathers brought forth on this continent a new nation, conceived in Liberty, and dedicated to the proposition that all men are created equal. Now we are engaged in a great civil war, testing whether that nation or any nation so conceived and so dedicated, can long endure. We are met on a great battle-field of that war. We have come to dedicate a portion of that field, as a final resting place for those who here gave their lives that that nation might live. It is altogether fitting and proper that we should do this. But, in a larger sense, we can not dedicate—we can not consecrate—we can not hallow—this ground. The brave men, living and dead, who struggled here, have consecrated it, far above our poor power to add or detract. The world will little note, nor long remember what we say here, but it can never forget what they did here. It is for us the living, rather, to be dedicated here to the unfinished work which they who fought here have thus far so nobly advanced. It is rather for us to be here dedicated to the great task remaining before us—that from these honored dead we take increased devotion to that cause for which they gave the last full measure of devotion—that we here highly resolve that these dead shall not have died in vain—that this nation, under God, shall have a new birth of freedom—and that government of the people, by the people, for the people, shall not perish from the earth.";

        [Test]
        public void SendComplexSentencesAndGetHtmlOfHistogram()
        {
            Histogram histogram = new Histogram();

            string value = histogram.DisplayHistogram(GettysburgAddressPart);

            Assert.AreEqual(value, SendComplexSentencesAndGetHtmlOfHistogramText);
        }

        private const string SendComplexSentencesAndGetHtmlOfHistogramText = @"<ul>
<li>""Four score"" : 1</li>
<li>""score and"" : 1</li>
<li>""and seven"" : 1</li>
<li>""seven years"" : 1</li>
<li>""years ago"" : 1</li>
<li>""ago our"" : 1</li>
<li>""our fathers"" : 1</li>
<li>""fathers brought"" : 1</li>
<li>""brought forth"" : 1</li>
<li>""forth on"" : 1</li>
<li>""on this"" : 1</li>
<li>""this continent"" : 1</li>
<li>""continent a"" : 1</li>
<li>""a new"" : 2</li>
<li>""new nation"" : 1</li>
<li>""nation conceived"" : 1</li>
<li>""conceived in"" : 1</li>
<li>""in Liberty"" : 1</li>
<li>""Liberty and"" : 1</li>
<li>""and dedicated"" : 1</li>
<li>""dedicated to"" : 2</li>
<li>""to the"" : 3</li>
<li>""the proposition"" : 1</li>
<li>""proposition that"" : 1</li>
<li>""that all"" : 1</li>
<li>""all men"" : 1</li>
<li>""men are"" : 1</li>
<li>""are created"" : 1</li>
<li>""created equal"" : 1</li>
<li>""Now we"" : 1</li>
<li>""we are"" : 1</li>
<li>""are engaged"" : 1</li>
<li>""engaged in"" : 1</li>
<li>""in a"" : 2</li>
<li>""a great"" : 2</li>
<li>""great civil"" : 1</li>
<li>""civil war"" : 1</li>
<li>""war testing"" : 1</li>
<li>""testing whether"" : 1</li>
<li>""whether that"" : 1</li>
<li>""that nation"" : 2</li>
<li>""nation or"" : 1</li>
<li>""or any"" : 1</li>
<li>""any nation"" : 1</li>
<li>""nation so"" : 1</li>
<li>""so conceived"" : 1</li>
<li>""conceived and"" : 1</li>
<li>""and so"" : 1</li>
<li>""so dedicated"" : 1</li>
<li>""dedicated can"" : 1</li>
<li>""can long"" : 1</li>
<li>""long endure"" : 1</li>
<li>""We are"" : 1</li>
<li>""are met"" : 1</li>
<li>""met on"" : 1</li>
<li>""on a"" : 1</li>
<li>""great battle-field"" : 1</li>
<li>""battle-field of"" : 1</li>
<li>""of that"" : 2</li>
<li>""that war"" : 1</li>
<li>""We have"" : 1</li>
<li>""have come"" : 1</li>
<li>""come to"" : 1</li>
<li>""to dedicate"" : 1</li>
<li>""dedicate a"" : 1</li>
<li>""a portion"" : 1</li>
<li>""portion of"" : 1</li>
<li>""that field"" : 1</li>
<li>""field as"" : 1</li>
<li>""as a"" : 1</li>
<li>""a final"" : 1</li>
<li>""final resting"" : 1</li>
<li>""resting place"" : 1</li>
<li>""place for"" : 1</li>
<li>""for those"" : 1</li>
<li>""those who"" : 1</li>
<li>""who here"" : 1</li>
<li>""here gave"" : 1</li>
<li>""gave their"" : 1</li>
<li>""their lives"" : 1</li>
<li>""lives that"" : 1</li>
<li>""that that"" : 1</li>
<li>""nation might"" : 1</li>
<li>""might live"" : 1</li>
<li>""It is"" : 3</li>
<li>""is altogether"" : 1</li>
<li>""altogether fitting"" : 1</li>
<li>""fitting and"" : 1</li>
<li>""and proper"" : 1</li>
<li>""proper that"" : 1</li>
<li>""that we"" : 1</li>
<li>""we should"" : 1</li>
<li>""should do"" : 1</li>
<li>""do this"" : 1</li>
<li>""But, in"" : 1</li>
<li>""a larger"" : 1</li>
<li>""larger sense"" : 1</li>
<li>""sense we"" : 1</li>
<li>""we can"" : 1</li>
<li>""can not"" : 3</li>
<li>""not dedicate—we"" : 1</li>
<li>""dedicate—we can"" : 1</li>
<li>""not consecrate—we"" : 1</li>
<li>""consecrate—we can"" : 1</li>
<li>""not hallow—this"" : 1</li>
<li>""hallow—this ground"" : 1</li>
<li>""The brave"" : 1</li>
<li>""brave men"" : 1</li>
<li>""men living"" : 1</li>
<li>""living and"" : 1</li>
<li>""and dead"" : 1</li>
<li>""dead who"" : 1</li>
<li>""who struggled"" : 1</li>
<li>""struggled here"" : 1</li>
<li>""here have"" : 2</li>
<li>""have consecrated"" : 1</li>
<li>""consecrated it"" : 1</li>
<li>""it far"" : 1</li>
<li>""far above"" : 1</li>
<li>""above our"" : 1</li>
<li>""our poor"" : 1</li>
<li>""poor power"" : 1</li>
<li>""power to"" : 1</li>
<li>""to add"" : 1</li>
<li>""add or"" : 1</li>
<li>""or detract"" : 1</li>
<li>""The world"" : 1</li>
<li>""world will"" : 1</li>
<li>""will little"" : 1</li>
<li>""little note"" : 1</li>
<li>""note nor"" : 1</li>
<li>""nor long"" : 1</li>
<li>""long remember"" : 1</li>
<li>""remember what"" : 1</li>
<li>""what we"" : 1</li>
<li>""we say"" : 1</li>
<li>""say here"" : 1</li>
<li>""here but"" : 1</li>
<li>""but it"" : 1</li>
<li>""it can"" : 1</li>
<li>""can never"" : 1</li>
<li>""never forget"" : 1</li>
<li>""forget what"" : 1</li>
<li>""what they"" : 1</li>
<li>""they did"" : 1</li>
<li>""did here"" : 1</li>
<li>""is for"" : 1</li>
<li>""for us"" : 2</li>
<li>""us the"" : 1</li>
<li>""the living"" : 1</li>
<li>""living rather"" : 1</li>
<li>""rather to"" : 1</li>
<li>""to be"" : 2</li>
<li>""be dedicated"" : 1</li>
<li>""dedicated here"" : 1</li>
<li>""here to"" : 1</li>
<li>""the unfinished"" : 1</li>
<li>""unfinished work"" : 1</li>
<li>""work which"" : 1</li>
<li>""which they"" : 2</li>
<li>""they who"" : 1</li>
<li>""who fought"" : 1</li>
<li>""fought here"" : 1</li>
<li>""have thus"" : 1</li>
<li>""thus far"" : 1</li>
<li>""far so"" : 1</li>
<li>""so nobly"" : 1</li>
<li>""nobly advanced"" : 1</li>
<li>""is rather"" : 1</li>
<li>""rather for"" : 1</li>
<li>""us to"" : 1</li>
<li>""be here"" : 1</li>
<li>""here dedicated"" : 1</li>
<li>""the great"" : 1</li>
<li>""great task"" : 1</li>
<li>""task remaining"" : 1</li>
<li>""remaining before"" : 1</li>
<li>""before us—that"" : 1</li>
<li>""us—that from"" : 1</li>
<li>""from these"" : 1</li>
<li>""these honored"" : 1</li>
<li>""honored dead"" : 1</li>
<li>""dead we"" : 1</li>
<li>""we take"" : 1</li>
<li>""take increased"" : 1</li>
<li>""increased devotion"" : 1</li>
<li>""devotion to"" : 1</li>
<li>""to that"" : 1</li>
<li>""that cause"" : 1</li>
<li>""cause for"" : 1</li>
<li>""for which"" : 1</li>
<li>""they gave"" : 1</li>
<li>""gave the"" : 1</li>
<li>""the last"" : 1</li>
<li>""last full"" : 1</li>
<li>""full measure"" : 1</li>
<li>""measure of"" : 1</li>
<li>""of devotion—that"" : 1</li>
<li>""devotion—that we"" : 1</li>
<li>""we here"" : 1</li>
<li>""here highly"" : 1</li>
<li>""highly resolve"" : 1</li>
<li>""resolve that"" : 1</li>
<li>""that these"" : 1</li>
<li>""these dead"" : 1</li>
<li>""dead shall"" : 1</li>
<li>""shall not"" : 2</li>
<li>""not have"" : 1</li>
<li>""have died"" : 1</li>
<li>""died in"" : 1</li>
<li>""in vain—that"" : 1</li>
<li>""vain—that this"" : 1</li>
<li>""this nation"" : 1</li>
<li>""nation under"" : 1</li>
<li>""under God"" : 1</li>
<li>""God shall"" : 1</li>
<li>""shall have"" : 1</li>
<li>""have a"" : 1</li>
<li>""new birth"" : 1</li>
<li>""birth of"" : 1</li>
<li>""of freedom—and"" : 1</li>
<li>""freedom—and that"" : 1</li>
<li>""that government"" : 1</li>
<li>""government of"" : 1</li>
<li>""of the"" : 1</li>
<li>""the people"" : 3</li>
<li>""people by"" : 1</li>
<li>""by the"" : 1</li>
<li>""people for"" : 1</li>
<li>""for the"" : 1</li>
<li>""people shall"" : 1</li>
<li>""not perish"" : 1</li>
<li>""perish from"" : 1</li>
<li>""from the"" : 1</li>
<li>""the earth"" : 1</li>
</ul>
";

    }
}