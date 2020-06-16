using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace DictionaryData
{
    public class WordRepository
    {
        /// <summary>
        /// contains words in dictionary
        /// </summary>
        public Dictionary<Word, List<Word>> wordsDict = new Dictionary<Word, List<Word>>();

        /// <summary>
        /// contains connection information
        /// </summary>
        static string connString = "Server=localhost;database=dictionary;UID=root";

        /// <summary>
        ///  fetches dictionary from database
        /// </summary>
        /// <returns></returns>
        public Dictionary<Word, List<Word>> FetchWords()
        {
            Dictionary<Word, List<Word>> words = new Dictionary<Word, List<Word>>();
            var keyWords = fetchKeys();
            foreach (var key in keyWords)
            {
                var transWords = fetchTrans(key);
                words.Add(key, transWords);
            }
            wordsDict = words;
            return words;
        }

        /// <summary>
        /// fetches keyWords from Database
        /// </summary>
        /// <returns></returns>
        private static List<Word> fetchKeys()
        {
            // 'DE' should be kept flexible later on (acquired over language selection field)
            string queryKey = "SELECT * FROM words WHERE lang = 'DE'";
            List<Word> keyWords = getKeys(queryKey);
            return keyWords;
        }

        /// <summary>
        /// fetches translations from Database
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static List<Word> fetchTrans(Word key)
        {
            string queryTrans = $"SELECT word1, word2, lang FROM words_words " +
                $"INNER JOIN words ON words_words.word1 = words.word " +
                $"OR words_words.word2 = words.word " +
                $"WHERE lang != 'DE' AND word1 = '{key.word}' OR word2 = '{key.word}'";
            List<Word> transWords = getTrans(queryTrans, key.word);
            return transWords;
        }

        /// <summary>
        /// makes keyquery and returns a List<Word>
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private static List<Word> getKeys(string query)
        {
            MySqlConnection con = new MySqlConnection(connString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Word> words = convertToKeyWords(dataReader);
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
        private static List<Word> getTrans(string query, string key)
        {
            MySqlConnection con = new MySqlConnection(connString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Word> words = convertToTransWords(dataReader, key);
            dataReader.Close();
            con.Close();
            return words;
        }

        /// <summary>
        /// // converts dataReader (Keys) to List<Word>
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private static List<Word> convertToKeyWords (MySqlDataReader dataReader)
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

        private static List<Word> convertToTransWords (MySqlDataReader dataReader, string key)
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

        public bool InsertWord(Word word)
        {
            if (word != null)
            {
                MySqlConnection con = new MySqlConnection(connString);
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = $"INSERT INTO words (word, lang) VALUES ('{word.word}', '{word.lang}');";
                command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertRelation(Word word1, Word word2)
        {
            MySqlConnection con = new MySqlConnection(connString);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = $"INSERT INTO words_words (word1, word2) VALUES ('{word1.word}', '{word2.word}');";
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
