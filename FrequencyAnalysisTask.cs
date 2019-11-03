using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> interimResult = new Dictionary<string, Dictionary<string, int>>();
            foreach (List<string> sentence in text)
            {
                interimResult = AddNGramm(sentence, interimResult, 2);
                interimResult = AddNGramm(sentence, interimResult, 3);
                foreach (var dictionary in interimResult)
                {
                    string maxValue = dictionary.Value.Max().Key;
                    if (!result.ContainsKey(dictionary.Key))
                        result.Add(dictionary.Key, maxValue);
                }
            }
            return result;
        }
            

        public static Dictionary<string, Dictionary<string, int>> 
        AddNGramm(List<string> sentence, Dictionary<string, Dictionary<string, int>> interimResult, int countOfSymbInKey)
        {
            for (int i = 0; i < sentence.Count - countOfSymbInKey + 1; i++)
            {
                if (sentence.Count < countOfSymbInKey)
                    break;
                string key = sentence[i];
                if (countOfSymbInKey == 3)
                    key += " " + sentence[i + 1];
                Dictionary<string, int> valueDic = new Dictionary<string, int>();
                string keyDic = sentence[i + 1];
                if (countOfSymbInKey == 3)
                    keyDic = sentence[i + 2];
                if (!valueDic.ContainsKey(keyDic))
                    valueDic.Add(keyDic, 1);
                if (!interimResult.ContainsKey(key))
                    interimResult.Add(key, valueDic);
                else
                {
                    valueDic[keyDic]++;
                    interimResult[key] = valueDic;
                }
            }
            return interimResult;
        }
    }
}