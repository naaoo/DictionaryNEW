using DictionaryData;
using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace DictionaryLogic
{
    
    public class DictionaryController
    {
        public Language KeyLang;
        public Language TransLang1;
        public Language TransLang2;
        public Language TransLang3;

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

        /// <summary>
        /// adds all words and relations to database
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <param name="word3"></param>
        /// <param name="word4"></param>
        public void AddAllWords(List<Word> words)
        {
            var relations = wordRepository.SelectAllRelations();
            // adds words
            foreach (var word in words)
            {
                wordRepository.InsertWord(word);
                // add relations
                foreach (var relWord in words)
                {
                    if (relWord != word)
                    {
                        bool relationExists = false;
                        foreach (var relation in relations)
                        {
                            if ((relation[0] == relWord.word || relation[1] == relWord.word) 
                                && (relation[0] == word.word || relation[1] == word.word))
                            {
                                relationExists = true;
                            }
                        }
                        if (!relationExists)
                        {
                            wordRepository.InsertRelation(word, relWord);
                        }
                    }
                }
            }
            wordRepository.FetchWords(KeyLang);
        }

        public void SetLanguages(string langString, string target)
        {
            Language lang;
            Enum.TryParse(langString, out lang);
            switch (target)
            {
                case "key" :
                    KeyLang = lang; break;
                case "trans1":
                    TransLang1 = lang; break;
                case "trans2":
                    TransLang1 = lang; break;
                case "trans3":
                    TransLang1 = lang; break;
            }
        }

        public string GetLabel(string lang, string keylang)
        {
            if (keylang == lang)
            {
                lang = "";
            }
            return lang;
        }

        public void ExportAll()
        {
            wordRepository.WriteToCSV();
        }
    }
}
