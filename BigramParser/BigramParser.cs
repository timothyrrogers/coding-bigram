using System;
using System.Collections.Generic;

namespace BigramParser
{
    public class BigramParser
    {
        private Dictionary<string, int> bigramCounts = new Dictionary<string, int>();

        public BigramParser()
        {
        }

        public Dictionary<string, int> Parse(string value)
        {
            //if now string supplied throw exception
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("A string needs to be supplied!");
            }

            //seperate words by the space
            var seperatedWords = value.Split(' ');

            //if string is only 1 word long throw exception
            if (seperatedWords.Length == 1)
            {
                throw new Exception("A complete string needs to be supplied!");
            }
            else
            {
                string previousWord = "";
                int count = 0;
                foreach (string s in seperatedWords)
                {
                    if (string.IsNullOrEmpty(previousWord))
                    {
                        previousWord = s;
                    }
                    else
                    {
                        count++;
                        //check for period and remove it, should also reset previous word
                        string cleanS = s;
                        bool punctuationFound = false;
                        if (containsSentenceEndingPunctuation(s))
                        {
                            punctuationFound = true;
                            cleanS = removePunctuation(s);
                        }else if (containsNonSentenceEndingPunctionation(s))
                        {
                            cleanS = removePunctuation(s);
                        }
                        
                        string currentString = previousWord + " " + cleanS;

                        //if found in dictionary it will add to the count else add string with a count of 1
                        if (bigramCounts.ContainsKey(currentString))
                        {
                            bigramCounts[currentString]++;
                        }
                        else
                        {
                            bigramCounts.Add(currentString, count);
                        }

                        count = 0;
                        
                        previousWord = punctuationFound ? "" : cleanS;
                    }

                }
            }
            return bigramCounts;
                       
        }

        /// <summary>
        /// this will check for any non sentence ending punctuation
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool containsNonSentenceEndingPunctionation(string s)
        {
            return s.EndsWith(",") || s.EndsWith(";") || s.EndsWith(":");
        }

        /// <summary>
        /// this will check the sentence ending punctuation at the end of the word
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool containsSentenceEndingPunctuation(string s)
        {            
            return s.EndsWith(".") || s.EndsWith("!") || s.EndsWith("?");
        }

        /// <summary>
        /// this will remove the last character as it is punctuation mark
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string removePunctuation(string s)
        {
            //remove the last character as it is punctuation
            return s.Substring(0, s.Length - 1);
        }
    }
}