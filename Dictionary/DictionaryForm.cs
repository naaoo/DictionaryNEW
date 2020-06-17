using DictionaryData;
using DictionaryLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            controller.wordRepository.SetAppConfigs(ConfigurationManager.AppSettings.Get("databaseConnection"),
                ConfigurationManager.AppSettings.Get("filePath"));
            lBoxAlphabet.DataSource = controller.GetAlphabet();
            FillCBoxes();
            controller.wordRepository.FetchWords(controller.KeyLang);
            UpdateWords();
        }

        private void FillCBoxes()
        {
            cBoxKey.DataSource = GetLanguage();
            cBoxTrans1.DataSource = GetLanguage();
            cBoxTrans2.DataSource = GetLanguage();
            cBoxTrans3.DataSource = GetLanguage();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Word> words = new List<Word>();
            if (tbKeyWord.Text.Length > 0)
            {
                Language l;
                Enum.TryParse(cBoxKey.Text, out l);
                words.Add(new Word(tbKeyWord.Text, l));
            }
            if (tbTrans1.Text.Length > 0)
            {
                Language l;
                Enum.TryParse(cBoxTrans1.Text, out l);
                words.Add(new Word(tbTrans1.Text, l));
            }
            if (tbTrans2.Text.Length > 0)
            {
                Language l;
                Enum.TryParse(cBoxTrans2.Text, out l);
                words.Add(new Word(tbTrans2.Text, l));
            }
            if (tbTrans3.Text.Length > 0)
            {
                Language l;
                Enum.TryParse(cBoxTrans3.Text, out l);
                words.Add(new Word(tbTrans3.Text, l));
            }
            controller.AddAllWords(words);
            UpdateWords();
        }

        /// <summary>
        /// performs display of correct translations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lBoxKeyWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedWord = lBoxKeyWords.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedWord))
            {
                ResetTextBoxes();
                foreach (var item in controller.wordRepository.wordsDict)
                {
                    if (item.Key.word == selectedWord)
                    {
                        foreach (var trans in item.Value)
                        {
                            bool isEqualLanguage = trans.lang.ToString() == cBoxKey.Text;

                            if (trans.lang.ToString() == cBoxTrans1.Text && !isEqualLanguage)
                            {
                                tbTransWord1.Text = trans.word;
                            }
                            if (trans.lang.ToString() == cBoxTrans2.Text && !isEqualLanguage)
                            {
                                tbTransWord2.Text = trans.word;
                            }
                            if (trans.lang.ToString() == cBoxTrans3.Text && !isEqualLanguage)
                            {
                                tbTransWord3.Text = trans.word;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Resets all TextBoxes
        /// </summary>
        private void ResetTextBoxes()
        {
            tbKeyWord.Text = "";
            tbTransWord1.Text = "";
            tbTransWord2.Text = "";
            tbTransWord3.Text = "";
            tbTrans1.Text = "";
            tbTrans2.Text = "";
            tbTrans3.Text = "";
        }

        /// <summary>
        /// displays words in main box
        /// </summary>
        private void UpdateWords()
        {
            lBoxKeyWords.DataSource = controller.UpdatedTranslations();
        }

        /// <summary>
        /// exports to textfile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click_1(object sender, EventArgs e)
        {
            controller.ExportAll();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = tbSearch.Text;
            var results = controller.FindResults(searchText, false);
            lBoxKeyWords.DataSource = results;
            displayEmpty(results);
        }

        private void lBoxAlphabet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLetter = lBoxAlphabet.SelectedItem.ToString().ToLower();
            if (!string.IsNullOrEmpty(selectedLetter))
            {
                var results = controller.FindResults(selectedLetter, true);
                lBoxKeyWords.DataSource = results;
                displayEmpty(results);
            }
        }

        private void displayEmpty(List<string> results)
        {
            if (results.Count == 0)
            {
                tbTransWord1.Text = "";
                tbTransWord2.Text = "";
                tbTransWord3.Text = "";
            }
        }

        /// <summary>
        /// returns all available language modes
        /// </summary>
        /// <returns></returns>
        private List<string> GetLanguage()
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

        private void lBoxKeyWords_DoubleClick(object sender, EventArgs e)
        {
            tbKeyWord.Text = lBoxKeyWords.SelectedItem as string;
            tbTrans1.Text = tbTransWord1.Text;
            tbTrans2.Text = tbTransWord2.Text;
            tbTrans3.Text = tbTransWord3.Text;
        }

        private void cBoxKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            string langString = cBoxKey.Text;
            Language lang;
            Enum.TryParse(langString, out lang);
            controller.SetLanguages(langString, "key");
            controller.wordRepository.FetchWords(lang);
            UpdateWords();
        }

        private void cBoxTrans1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = cBoxTrans1.Text;
            controller.SetLanguages(lang, "trans1");
            lbTrans1.Text = controller.GetLabel(lang, cBoxKey.Text);
            UpdateWords();
        }

        private void cBoxTrans2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = cBoxTrans2.Text;
            controller.SetLanguages(lang, "trans2");
            lbTrans2.Text = controller.GetLabel(lang, cBoxKey.Text);
            UpdateWords();
        }

        private void cBoxTrans3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = cBoxTrans3.Text;
            controller.SetLanguages(lang, "trans3");
            lbTrans3.Text = controller.GetLabel(lang, cBoxKey.Text);
            UpdateWords();
        }

        
    }
}
