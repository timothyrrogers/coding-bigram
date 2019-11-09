# The Requirements:
## Bigram Parsing

Create an application that can take as input any text (either a file or as a string) and output a histogram of the bigrams in the text.

A bigram is any two adjacent words in the text. A histogram is a kind of graphical representation of numerical data. 

A well-formed submission will be executable and accompanied by tests. You may do this in any language and use any framework or data structures to read files, build the output, and run tests. The submission should be your own work; specifically, you should implement your own Bigram parsing and handling logic. Great candidates go above and beyond the problem statement and think about edge cases and failure.

Example: Given the text “The quick brown fox and the quick blue hare.”

The bigrams and their counts would be:

* “the quick”: 2
* “quick brown”: 1
* “brown fox”: 1
* “fox and”: 1
* “and the”: 1
* “quick blue”: 1
* “blue hare”: 1

## Comments:

In this project I started by created each test first and then creating the code to fit the test.  I created tests for looking at one sentence with a period to more complex with punctuation like comma, semi-colon, exclamiation and question marks.  Two sentences were also tested and if needed could have done a whole paragraph.

This would only create bigrams after the first word of each sentence.  The delimiter that was used was a space for each word.

This doesn't take into account special characters in the word or at the beginning or end of the word.  This doesn't take into account apostrophes or hyphens.
