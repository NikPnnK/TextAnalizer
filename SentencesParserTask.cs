using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            List<List<string>> output = new List<List<string>>();
            var splitedText = text.Split(new char[] { '.', '!', '?', ':', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sentences in splitedText)
            {
                if (StringToListParser(sentences).Count != 0)
                    output.Add(StringToListParser(sentences));
            }
            return output;
        }

        public static List<string> StringToListParser(string input)
        {
            var parsedSentence = new List<string>();
            var cacheStrB = new StringBuilder();
            if (input == " " || input == null)
                return null;
            var doWordHaveLetters = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) || input[i] == '\'')
                {
                    cacheStrB.Append(input[i].ToString());
                    doWordHaveLetters = true;
                }
                else
                {
                    if (doWordHaveLetters)
                        parsedSentence.Add(cacheStrB.ToString().ToLower());
                    cacheStrB.Clear();
                    doWordHaveLetters = false;
                }
            }
            if (doWordHaveLetters)
                parsedSentence.Add(cacheStrB.ToString().ToLower());
            return parsedSentence;
        }
    }
}