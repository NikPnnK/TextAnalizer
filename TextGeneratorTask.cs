using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var output = new StringBuilder();
            output.Append(phraseBeginning);
            var splitedPhrase = phraseBeginning.Split(' ');
            var keysArray = new string[3] { "Если я забуду убрать это из кода, хотя бы преподу будет весело",
                                            "КостыльКоторый никогда не появится в словаре",
                                            splitedPhrase[splitedPhrase.Length - 1] };
            if (splitedPhrase.Length > 1)
            {
                keysArray[1] = splitedPhrase[splitedPhrase.Length - 2];
                keysArray[2] = splitedPhrase[splitedPhrase.Length - 1];
            }
            for (int i = 0; i < wordsCount; i++)
            {
                var bigrammKey = keysArray[2];
                var trigrammKey = keysArray[1] + " " + keysArray[2];
                if (!nextWords.ContainsKey(bigrammKey) && !nextWords.ContainsKey(trigrammKey))
                    break;
                if (keysArray.Length <= 2 ||
                    !nextWords.ContainsKey(keysArray[1] + " " + keysArray[2]))
                {
                    output.Append(" " + nextWords[bigrammKey]);
                    keysArray[1] = keysArray[2];
                    keysArray[2] = nextWords[bigrammKey];
                }
                else
                {
                    output.Append(" " + nextWords[trigrammKey]);
                    keysArray[1] = keysArray[2];
                    keysArray[2] = nextWords[trigrammKey];
                }
            }
            return output.ToString();
        }
    }
}