namespace Dictionary
{
    partial class DictionaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbGermanWord = new System.Windows.Forms.TextBox();
            this.tbEnglishWord = new System.Windows.Forms.TextBox();
            this.lbTranslation = new System.Windows.Forms.Label();
            this.lBoxGermanWords = new System.Windows.Forms.ListBox();
            this.tbENTranslation = new System.Windows.Forms.TextBox();
            this.tbSpanishWord = new System.Windows.Forms.TextBox();
            this.lbTranslationSpanish = new System.Windows.Forms.Label();
            this.tbESTranslation = new System.Windows.Forms.TextBox();
            this.lbEnglishTranslation = new System.Windows.Forms.Label();
            this.lbSpanishTranslation = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lBoxAlphabet = new System.Windows.Forms.ListBox();
            this.cBoxLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(688, 90);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 37);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbGermanWord
            // 
            this.tbGermanWord.Location = new System.Drawing.Point(151, 67);
            this.tbGermanWord.Name = "tbGermanWord";
            this.tbGermanWord.Size = new System.Drawing.Size(191, 22);
            this.tbGermanWord.TabIndex = 1;
            // 
            // tbEnglishWord
            // 
            this.tbEnglishWord.Location = new System.Drawing.Point(453, 67);
            this.tbEnglishWord.Name = "tbEnglishWord";
            this.tbEnglishWord.Size = new System.Drawing.Size(213, 22);
            this.tbEnglishWord.TabIndex = 2;
            // 
            // lbTranslation
            // 
            this.lbTranslation.AutoSize = true;
            this.lbTranslation.Location = new System.Drawing.Point(363, 70);
            this.lbTranslation.Name = "lbTranslation";
            this.lbTranslation.Size = new System.Drawing.Size(70, 17);
            this.lbTranslation.TabIndex = 3;
            this.lbTranslation.Text = "DE <> EN";
            // 
            // lBoxGermanWords
            // 
            this.lBoxGermanWords.FormattingEnabled = true;
            this.lBoxGermanWords.ItemHeight = 16;
            this.lBoxGermanWords.Location = new System.Drawing.Point(90, 226);
            this.lBoxGermanWords.Name = "lBoxGermanWords";
            this.lBoxGermanWords.Size = new System.Drawing.Size(307, 180);
            this.lBoxGermanWords.TabIndex = 4;
            this.lBoxGermanWords.SelectedIndexChanged += new System.EventHandler(this.lBoxGermanWords_SelectedIndexChanged);
            // 
            // tbENTranslation
            // 
            this.tbENTranslation.Location = new System.Drawing.Point(427, 256);
            this.tbENTranslation.Name = "tbENTranslation";
            this.tbENTranslation.Size = new System.Drawing.Size(331, 22);
            this.tbENTranslation.TabIndex = 5;
            // 
            // tbSpanishWord
            // 
            this.tbSpanishWord.Location = new System.Drawing.Point(453, 105);
            this.tbSpanishWord.Name = "tbSpanishWord";
            this.tbSpanishWord.Size = new System.Drawing.Size(213, 22);
            this.tbSpanishWord.TabIndex = 3;
            // 
            // lbTranslationSpanish
            // 
            this.lbTranslationSpanish.AutoSize = true;
            this.lbTranslationSpanish.Location = new System.Drawing.Point(363, 110);
            this.lbTranslationSpanish.Name = "lbTranslationSpanish";
            this.lbTranslationSpanish.Size = new System.Drawing.Size(69, 17);
            this.lbTranslationSpanish.TabIndex = 9;
            this.lbTranslationSpanish.Text = "DE <> ES";
            // 
            // tbESTranslation
            // 
            this.tbESTranslation.Location = new System.Drawing.Point(427, 323);
            this.tbESTranslation.Name = "tbESTranslation";
            this.tbESTranslation.Size = new System.Drawing.Size(331, 22);
            this.tbESTranslation.TabIndex = 6;
            // 
            // lbEnglishTranslation
            // 
            this.lbEnglishTranslation.AutoSize = true;
            this.lbEnglishTranslation.Location = new System.Drawing.Point(424, 226);
            this.lbEnglishTranslation.Name = "lbEnglishTranslation";
            this.lbEnglishTranslation.Size = new System.Drawing.Size(54, 17);
            this.lbEnglishTranslation.TabIndex = 11;
            this.lbEnglishTranslation.Text = "English";
            // 
            // lbSpanishTranslation
            // 
            this.lbSpanishTranslation.AutoSize = true;
            this.lbSpanishTranslation.Location = new System.Drawing.Point(424, 291);
            this.lbSpanishTranslation.Name = "lbSpanishTranslation";
            this.lbSpanishTranslation.Size = new System.Drawing.Size(62, 17);
            this.lbSpanishTranslation.TabIndex = 12;
            this.lbSpanishTranslation.Text = "Espaniol";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(90, 194);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(307, 22);
            this.tbSearch.TabIndex = 13;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(87, 160);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(53, 17);
            this.lbSearch.TabIndex = 14;
            this.lbSearch.Text = "Search";
            // 
            // lBoxAlphabet
            // 
            this.lBoxAlphabet.FormattingEnabled = true;
            this.lBoxAlphabet.ItemHeight = 16;
            this.lBoxAlphabet.Location = new System.Drawing.Point(25, 194);
            this.lBoxAlphabet.Name = "lBoxAlphabet";
            this.lBoxAlphabet.Size = new System.Drawing.Size(49, 212);
            this.lBoxAlphabet.TabIndex = 15;
            this.lBoxAlphabet.SelectedIndexChanged += new System.EventHandler(this.lBoxAlphabet_SelectedIndexChanged);
            // 
            // cBoxLanguage
            // 
            this.cBoxLanguage.FormattingEnabled = true;
            this.cBoxLanguage.Location = new System.Drawing.Point(19, 67);
            this.cBoxLanguage.Name = "cBoxLanguage";
            this.cBoxLanguage.Size = new System.Drawing.Size(55, 24);
            this.cBoxLanguage.TabIndex = 16;
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cBoxLanguage);
            this.Controls.Add(this.lBoxAlphabet);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbSpanishTranslation);
            this.Controls.Add(this.lbEnglishTranslation);
            this.Controls.Add(this.tbESTranslation);
            this.Controls.Add(this.lbTranslationSpanish);
            this.Controls.Add(this.tbSpanishWord);
            this.Controls.Add(this.tbENTranslation);
            this.Controls.Add(this.lBoxGermanWords);
            this.Controls.Add(this.lbTranslation);
            this.Controls.Add(this.tbEnglishWord);
            this.Controls.Add(this.tbGermanWord);
            this.Controls.Add(this.btnAdd);
            this.Name = "DictionaryForm";
            this.Text = "Dictionary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbGermanWord;
        private System.Windows.Forms.TextBox tbEnglishWord;
        private System.Windows.Forms.Label lbTranslation;
        private System.Windows.Forms.ListBox lBoxGermanWords;
        private System.Windows.Forms.TextBox tbENTranslation;
        private System.Windows.Forms.TextBox tbSpanishWord;
        private System.Windows.Forms.Label lbTranslationSpanish;
        private System.Windows.Forms.TextBox tbESTranslation;
        private System.Windows.Forms.Label lbEnglishTranslation;
        private System.Windows.Forms.Label lbSpanishTranslation;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.ListBox lBoxAlphabet;
        private System.Windows.Forms.ComboBox cBoxLanguage;
    }
}

