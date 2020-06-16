using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryData
{
    public enum Language
    {
        DE,
        EN,
        ES
    }

    public class Word
    {
        public string word;
        public Language lang;

        public Word(string word, Language lang)
        {
            this.word = word;
            this.lang = lang;
        }

        public bool IsValid => !string.IsNullOrEmpty(word);
    }
}
