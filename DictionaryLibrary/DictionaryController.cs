using DictionaryData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace DictionaryLogic
{
    public class DictionaryController
    {
        /// <summary>
        /// contains word-list and methods to fetch and write data
        /// </summary>
        public WordRepository wordRepository = new WordRepository();

        
        /// <summary>
        /// filters the dictionary and returns a list
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="hasToStartWith"></param>
        /// <returns></returns>
        public List<string> FindResults(string filterString, bool hasToStartWith)
        {
            var list = new List<string>();
            if (filterString == "All")
            {
                list = wordRepository.wordsDict.Select(x => x.Key.word).ToList();
            }
            else
            {
                if (hasToStartWith)
                {
                    list = wordRepository.wordsDict.Where(x => x.Key.word.StartsWith(filterString))
                        .Select(x => x.Key.word).ToList();
                }
                else
                {
                    list = wordRepository.wordsDict.Where(x => x.Key.word.Contains(filterString))
                        .Select(x => x.Key.word).ToList();
                }
            }
            
            return list;
        }

        /// <summary>
        /// returns the alphabet for the filtering
        /// </summary>
        /// <returns></returns>
        public List<string> GetAlphabet()
        {
            List<string> alphabet = new List<string>()
        {
            "All","A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
            return alphabet;
        }

        public List<string> UpdatedTranslations()
        {
            return wordRepository.wordsDict.OrderBy(word => word.Key.word).Select(x => $"{x.Key.word}").ToList();
        }

        public void AddWord(Word germanWord, Word englishWord, Word spanishWord)
        {
            var insDE = wordRepository.InsertWord(germanWord);
            var insEN = wordRepository.InsertWord(englishWord);
            var insES = wordRepository.InsertWord(spanishWord);
            if (germanWord.IsValid && englishWord.IsValid)
            {
                wordRepository.InsertRelation(germanWord, englishWord);
            }
            if (insDE && insES)
            {
                wordRepository.InsertRelation(germanWord, spanishWord);
            }
            if (insEN && insES)
            {
                wordRepository.InsertRelation(englishWord, spanishWord);
            }
            wordRepository.FetchWords();
        }
    }
}
