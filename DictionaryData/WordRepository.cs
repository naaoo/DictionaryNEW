using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;

namespace DictionaryData
{
    public class WordRepository
    {
        /// <summary>
        /// contains words in dictionary
        /// </summary>
        public Dictionary<Word, List<Word>> wordsDict = new Dictionary<Word, List<Word>>();

        private string filePath;

        /// <summary>
        /// contains connection information
        /// </summary>
        static string connString;

        /// <summary>
        ///  fetches dictionary from database
        /// </summary>
        /// <returns></returns>
        public Dictionary<Word, List<Word>> FetchWords(Language keyLang)
        {
            Dictionary<Word, List<Word>> words = new Dictionary<Word, List<Word>>();
            var keyWords = FetchKeys(keyLang);
            foreach (var key in keyWords)
            {
                var transWords = FetchTrans(key, keyLang);
                words.Add(key, transWords);
            }
            wordsDict = words;
            return words;
        }

        /// <summary>
        /// fetches keyWords from Database
        /// </summary>
        /// <returns></returns>
        private static List<Word> FetchKeys(Language keyLang)
        {
            // 'DE' should be kept flexible later on (acquired over language selection field)
            string queryKey = "SELECT * FROM words WHERE lang = '" + keyLang.ToString() + "'";
            List<Word> keyWords = GetKeys(queryKey);
            return keyWords;
        }

        /// <summary>
        /// fetches translations from Database
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static List<Word> FetchTrans(Word key, Language keyLang)
        {
            string queryTrans = $"SELECT word1, word2, lang FROM words_words " +
                $"INNER JOIN words ON words_words.word1 = words.word " +
                $"OR words_words.word2 = words.word " +
                $"WHERE lang != '{keyLang.ToString()}' AND word1 = '{key.word}' OR word2 = '{key.word}'";
            List<Word> transWords = GetTrans(queryTrans, key.word);
            return transWords;
        }

        /// <summary>
        /// makes keyquery and returns a List<Word>
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private static List<Word> GetKeys(string query)
        {
            MySqlConnection con = new MySqlConnection(connString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Word> words = ConvertToKeyWords(dataReader);
            dataReader.Close();
            con.Close();
            return words;
        }

        /// <summary>
        /// makes a transquery and returns a List<Word>
        /// </summary>
        /// <param name="query"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static List<Word> GetTrans(string query, string key)
        {
            MySqlConnection con = new MySqlConnection(connString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Word> words = ConvertToTransWords(dataReader, key);
            dataReader.Close();
            con.Close();
            return words;
        }

        /// <summary>
        /// // converts dataReader (Keys) to List<Word>
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private static List<Word> ConvertToKeyWords (MySqlDataReader dataReader)
        {
            List<Word> wordList = new List<Word>();
            foreach (var item in dataReader)
            {
                var word = dataReader["word"].ToString();
                Language lang;
                Enum.TryParse(dataReader["lang"].ToString(), out lang);
                wordList.Add(new Word(word, lang));
            }
            return wordList;
        }

        private static List<Word> ConvertToTransWords (MySqlDataReader dataReader, string key)
        {
            List<Word> wordList = new List<Word>();
            foreach (var item in dataReader)
            {
                if (dataReader["word1"].ToString() == key)
                {
                    Language lang;
                    Enum.TryParse(dataReader["lang"].ToString(), out lang);
                    Word word = new Word(dataReader["word2"].ToString(), lang);
                    wordList.Add(word);
                }
                else if (dataReader["word2"].ToString() == key)
                {
                    Language lang;
                    Enum.TryParse(dataReader["lang"].ToString(), out lang);
                    Word word = new Word(dataReader["word1"].ToString(), lang);
                    wordList.Add(word);
                }
            }
            return wordList;
        }

        /// <summary>
        /// inserts word to database
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public void InsertWord(Word word)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connString);
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = $"INSERT INTO words (word, lang) VALUES ('{word.word}', '{word.lang}');";
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
            }

        }

        /// <summary>
        /// inserts relation to database
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        public void InsertRelation(Word word1, Word word2)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connString);
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = $"INSERT INTO words_words (word1, word2) VALUES ('{word1.word}', '{word2.word}');";
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
            }
        }

        public List<List<string>> SelectAllRelations()
        {
            List<List<string>> relations = new List<List<string>>();
            try
            {
                MySqlConnection con = new MySqlConnection(connString);
                con.Open();
                string query = "SELECT word1, word2 FROM words_words";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                foreach (var wordString in dataReader)
                {
                    var wordList = new List<string>();
                    wordList.Add(dataReader["word1"].ToString());
                    wordList.Add(dataReader["word2"].ToString());
                    relations.Add(wordList);
                }
                dataReader.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
            }
            return relations;
        }

        /// <summary>
        /// Exports all words (ordered in current key language) to a textfile
        /// </summary>
        /// some words are exported twice...
        public void WriteToCSV()
        {
            List<string> exportStrings = new List<string>();
            foreach (var entry in wordsDict)
            {
                var wordString = entry.Key.word;
                foreach (var trans in entry.Value)
                {
                    wordString = wordString + ";" + trans.word;
                }
                exportStrings.Add(wordString);
            }
            File.WriteAllLines(filePath, exportStrings);
        }

        public void SetAppConfigs(string conn, string path)
        {
            connString = conn;
            filePath = path;
        }

    }
}
