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
            this.tbKeyWord = new System.Windows.Forms.TextBox();
            this.tbTrans1 = new System.Windows.Forms.TextBox();
            this.lBoxKeyWords = new System.Windows.Forms.ListBox();
            this.tbTransWord1 = new System.Windows.Forms.TextBox();
            this.tbTrans2 = new System.Windows.Forms.TextBox();
            this.tbTransWord2 = new System.Windows.Forms.TextBox();
            this.lbTrans1 = new System.Windows.Forms.Label();
            this.lbTrans2 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lBoxAlphabet = new System.Windows.Forms.ListBox();
            this.cBoxKey = new System.Windows.Forms.ComboBox();
            this.lbTranslationSpanish = new System.Windows.Forms.Label();
            this.lbTranslation = new System.Windows.Forms.Label();
            this.cBoxTrans2 = new System.Windows.Forms.ComboBox();
            this.cBoxTrans1 = new System.Windows.Forms.ComboBox();
            this.cBoxTrans3 = new System.Windows.Forms.ComboBox();
            this.tbTrans3 = new System.Windows.Forms.TextBox();
            this.lbTrans3 = new System.Windows.Forms.Label();
            this.tbTransWord3 = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(132, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 37);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbKeyWord
            // 
            this.tbKeyWord.Location = new System.Drawing.Point(132, 71);
            this.tbKeyWord.Name = "tbKeyWord";
            this.tbKeyWord.Size = new System.Drawing.Size(265, 22);
            this.tbKeyWord.TabIndex = 2;
            // 
            // tbTrans1
            // 
            this.tbTrans1.Location = new System.Drawing.Point(493, 71);
            this.tbTrans1.Name = "tbTrans1";
            this.tbTrans1.Size = new System.Drawing.Size(265, 22);
            this.tbTrans1.TabIndex = 4;
            // 
            // lBoxKeyWords
            // 
            this.lBoxKeyWords.FormattingEnabled = true;
            this.lBoxKeyWords.ItemHeight = 16;
            this.lBoxKeyWords.Location = new System.Drawing.Point(90, 245);
            this.lBoxKeyWords.Name = "lBoxKeyWords";
            this.lBoxKeyWords.Size = new System.Drawing.Size(307, 180);
            this.lBoxKeyWords.TabIndex = 12;
            this.lBoxKeyWords.SelectedIndexChanged += new System.EventHandler(this.lBoxKeyWords_SelectedIndexChanged);
            this.lBoxKeyWords.DoubleClick += new System.EventHandler(this.lBoxKeyWords_DoubleClick);
            // 
            // tbTransWord1
            // 
            this.tbTransWord1.Location = new System.Drawing.Point(427, 245);
            this.tbTransWord1.Name = "tbTransWord1";
            this.tbTransWord1.Size = new System.Drawing.Size(331, 22);
            this.tbTransWord1.TabIndex = 13;
            // 
            // tbTrans2
            // 
            this.tbTrans2.Location = new System.Drawing.Point(493, 111);
            this.tbTrans2.Name = "tbTrans2";
            this.tbTrans2.Size = new System.Drawing.Size(265, 22);
            this.tbTrans2.TabIndex = 6;
            // 
            // tbTransWord2
            // 
            this.tbTransWord2.Location = new System.Drawing.Point(427, 307);
            this.tbTransWord2.Name = "tbTransWord2";
            this.tbTransWord2.Size = new System.Drawing.Size(331, 22);
            this.tbTransWord2.TabIndex = 14;
            // 
            // lbTrans1
            // 
            this.lbTrans1.AutoSize = true;
            this.lbTrans1.Location = new System.Drawing.Point(424, 225);
            this.lbTrans1.Name = "lbTrans1";
            this.lbTrans1.Size = new System.Drawing.Size(0, 17);
            this.lbTrans1.TabIndex = 11;
            // 
            // lbTrans2
            // 
            this.lbTrans2.AutoSize = true;
            this.lbTrans2.Location = new System.Drawing.Point(424, 287);
            this.lbTrans2.Name = "lbTrans2";
            this.lbTrans2.Size = new System.Drawing.Size(0, 17);
            this.lbTrans2.TabIndex = 12;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(90, 213);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(307, 22);
            this.tbSearch.TabIndex = 11;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(87, 193);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(53, 17);
            this.lbSearch.TabIndex = 14;
            this.lbSearch.Text = "Search";
            // 
            // lBoxAlphabet
            // 
            this.lBoxAlphabet.FormattingEnabled = true;
            this.lBoxAlphabet.ItemHeight = 16;
            this.lBoxAlphabet.Location = new System.Drawing.Point(25, 213);
            this.lBoxAlphabet.Name = "lBoxAlphabet";
            this.lBoxAlphabet.Size = new System.Drawing.Size(49, 212);
            this.lBoxAlphabet.TabIndex = 10;
            this.lBoxAlphabet.SelectedIndexChanged += new System.EventHandler(this.lBoxAlphabet_SelectedIndexChanged);
            // 
            // cBoxKey
            // 
            this.cBoxKey.FormattingEnabled = true;
            this.cBoxKey.Location = new System.Drawing.Point(71, 71);
            this.cBoxKey.Name = "cBoxKey";
            this.cBoxKey.Size = new System.Drawing.Size(55, 24);
            this.cBoxKey.TabIndex = 1;
            this.cBoxKey.SelectedIndexChanged += new System.EventHandler(this.cBoxKey_SelectedIndexChanged);
            // 
            // lbTranslationSpanish
            // 
            this.lbTranslationSpanish.AutoSize = true;
            this.lbTranslationSpanish.Location = new System.Drawing.Point(490, 40);
            this.lbTranslationSpanish.Name = "lbTranslationSpanish";
            this.lbTranslationSpanish.Size = new System.Drawing.Size(25, 17);
            this.lbTranslationSpanish.TabIndex = 9;
            this.lbTranslationSpanish.Text = "To";
            // 
            // lbTranslation
            // 
            this.lbTranslation.AutoSize = true;
            this.lbTranslation.Location = new System.Drawing.Point(80, 43);
            this.lbTranslation.Name = "lbTranslation";
            this.lbTranslation.Size = new System.Drawing.Size(40, 17);
            this.lbTranslation.TabIndex = 3;
            this.lbTranslation.Text = "From";
            // 
            // cBoxTrans2
            // 
            this.cBoxTrans2.FormattingEnabled = true;
            this.cBoxTrans2.Location = new System.Drawing.Point(427, 111);
            this.cBoxTrans2.Name = "cBoxTrans2";
            this.cBoxTrans2.Size = new System.Drawing.Size(55, 24);
            this.cBoxTrans2.TabIndex = 5;
            this.cBoxTrans2.SelectedIndexChanged += new System.EventHandler(this.cBoxTrans2_SelectedIndexChanged);
            // 
            // cBoxTrans1
            // 
            this.cBoxTrans1.FormattingEnabled = true;
            this.cBoxTrans1.Location = new System.Drawing.Point(427, 71);
            this.cBoxTrans1.Name = "cBoxTrans1";
            this.cBoxTrans1.Size = new System.Drawing.Size(55, 24);
            this.cBoxTrans1.TabIndex = 3;
            this.cBoxTrans1.SelectedIndexChanged += new System.EventHandler(this.cBoxTrans1_SelectedIndexChanged);
            // 
            // cBoxTrans3
            // 
            this.cBoxTrans3.FormattingEnabled = true;
            this.cBoxTrans3.Location = new System.Drawing.Point(427, 155);
            this.cBoxTrans3.Name = "cBoxTrans3";
            this.cBoxTrans3.Size = new System.Drawing.Size(55, 24);
            this.cBoxTrans3.TabIndex = 7;
            this.cBoxTrans3.SelectedIndexChanged += new System.EventHandler(this.cBoxTrans3_SelectedIndexChanged);
            // 
            // tbTrans3
            // 
            this.tbTrans3.Location = new System.Drawing.Point(493, 155);
            this.tbTrans3.Name = "tbTrans3";
            this.tbTrans3.Size = new System.Drawing.Size(265, 22);
            this.tbTrans3.TabIndex = 8;
            // 
            // lbTrans3
            // 
            this.lbTrans3.AutoSize = true;
            this.lbTrans3.Location = new System.Drawing.Point(424, 351);
            this.lbTrans3.Name = "lbTrans3";
            this.lbTrans3.Size = new System.Drawing.Size(0, 17);
            this.lbTrans3.TabIndex = 23;
            // 
            // tbTransWord3
            // 
            this.tbTransWord3.Location = new System.Drawing.Point(427, 371);
            this.tbTransWord3.Name = "tbTransWord3";
            this.tbTransWord3.Size = new System.Drawing.Size(331, 22);
            this.tbTransWord3.TabIndex = 15;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(640, 419);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(118, 37);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Export All";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 509);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lbTrans3);
            this.Controls.Add(this.tbTransWord3);
            this.Controls.Add(this.cBoxTrans3);
            this.Controls.Add(this.tbTrans3);
            this.Controls.Add(this.cBoxTrans1);
            this.Controls.Add(this.cBoxTrans2);
            this.Controls.Add(this.cBoxKey);
            this.Controls.Add(this.lBoxAlphabet);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbTrans2);
            this.Controls.Add(this.lbTrans1);
            this.Controls.Add(this.tbTransWord2);
            this.Controls.Add(this.lbTranslationSpanish);
            this.Controls.Add(this.tbTrans2);
            this.Controls.Add(this.tbTransWord1);
            this.Controls.Add(this.lBoxKeyWords);
            this.Controls.Add(this.lbTranslation);
            this.Controls.Add(this.tbTrans1);
            this.Controls.Add(this.tbKeyWord);
            this.Controls.Add(this.btnAdd);
            this.Name = "DictionaryForm";
            this.Text = "Dictionary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbKeyWord;
        private System.Windows.Forms.TextBox tbTrans1;
        private System.Windows.Forms.ListBox lBoxKeyWords;
        private System.Windows.Forms.TextBox tbTransWord1;
        private System.Windows.Forms.TextBox tbTrans2;
        private System.Windows.Forms.TextBox tbTransWord2;
        private System.Windows.Forms.Label lbTrans1;
        private System.Windows.Forms.Label lbTrans2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.ListBox lBoxAlphabet;
        private System.Windows.Forms.ComboBox cBoxKey;
        private System.Windows.Forms.Label lbTranslationSpanish;
        private System.Windows.Forms.Label lbTranslation;
        private System.Windows.Forms.ComboBox cBoxTrans2;
        private System.Windows.Forms.ComboBox cBoxTrans1;
        private System.Windows.Forms.ComboBox cBoxTrans3;
        private System.Windows.Forms.TextBox tbTrans3;
        private System.Windows.Forms.Label lbTrans3;
        private System.Windows.Forms.TextBox tbTransWord3;
        private System.Windows.Forms.Button btnExport;
    }
}

