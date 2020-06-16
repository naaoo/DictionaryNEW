using DictionaryData;
using DictionaryLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class DictionaryForm : Form
    {
        /// <summary>
        /// contains logic and repository
        /// </summary>
        static DictionaryController controller = new DictionaryController();
       
        
        public DictionaryForm()
        {
            InitializeComponent();
            lBoxAlphabet.DataSource = controller.GetAlphabet();
            cBoxLanguage.DataSource = GetLanguage();
            controller.wordRepository.FetchWords();
            UpdateWords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var germanWord = new Word(tbGermanWord.Text, Language.DE);
            var englishWord = new Word(tbEnglishWord.Text, Language.EN);
            var spanishWord = new Word(tbSpanishWord.Text, Language.ES);
            controller.AddWord(germanWord, englishWord, spanishWord);
            UpdateWords();
        }

        /// <summary>
        /// performs display of correct translations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lBoxGermanWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedWord = lBoxGermanWords.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedWord))
            {
                string englishWord = "";
                string spanishWord = "";
                foreach (var item in controller.wordRepository.wordsDict)
                {
                    if (item.Key.word == selectedWord)
                    {
                        foreach (var trans in item.Value)
                        {
                            if (trans.lang == Language.EN)
                            {
                                englishWord = trans.word;
                            }
                            else if (trans.lang == Language.ES)
                            {
                                spanishWord = trans.word;
                            }
                        }
                        
                    }
                }
                tbENTranslation.Text = englishWord;
                tbESTranslation.Text = spanishWord;
            }
        }

        /// <summary>
        /// displays words in main box
        /// </summary>
        private void UpdateWords()
        {
            lBoxGermanWords.DataSource = controller.UpdatedTranslations();
        }

        /// <summary>
        /// exports to database (deprecated)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
               // deprecated
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = tbSearch.Text;
            var results = controller.FindResults(searchText, false);
            lBoxGermanWords.DataSource = results;
            if (results.Count == 0)
            {
                tbENTranslation.Text = "";
                tbESTranslation.Text = "";
            }
        }

        private void lBoxAlphabet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLetter = lBoxAlphabet.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedLetter))
            {
                var results = controller.FindResults(selectedLetter, true);
                lBoxGermanWords.DataSource = results;
                if (results.Count == 0)
                {
                    tbENTranslation.Text = "";
                    tbESTranslation.Text = "";
                }
            }
        }

        /// <summary>
        /// returns all available language modes
        /// </summary>
        /// <returns></returns>
        public List<string> GetLanguage()
        {
            List<string> lang = new List<string>();
            var languages = ConfigurationManager.AppSettings.Get("Languages");
            var langArr = languages.Split(';');
            foreach (var item in langArr)
            {
                lang.Add(item);
            }
            return lang;
        }

        
    }
}
