
namespace Pr3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bLoadFromFile = new System.Windows.Forms.Button();
            this.bSaveToFile = new System.Windows.Forms.Button();
            this.bGenAlphabet = new System.Windows.Forms.Button();
            this.cRegister = new System.Windows.Forms.CheckBox();
            this.cAddSym = new System.Windows.Forms.CheckBox();
            this.txbSym = new System.Windows.Forms.TextBox();
            this.cEngAlp = new System.Windows.Forms.CheckBox();
            this.cRuAlp = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbResult = new System.Windows.Forms.TextBox();
            this.bDecrypt = new System.Windows.Forms.Button();
            this.bEncrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txbInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAlgorythm = new System.Windows.Forms.ComboBox();
            this.btnShowSettings = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bAttack = new System.Windows.Forms.Button();
            this.bLoadText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnShowSettings);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bLoadFromFile);
            this.groupBox2.Controls.Add(this.bSaveToFile);
            this.groupBox2.Controls.Add(this.bGenAlphabet);
            this.groupBox2.Controls.Add(this.cRegister);
            this.groupBox2.Controls.Add(this.cAddSym);
            this.groupBox2.Controls.Add(this.txbSym);
            this.groupBox2.Controls.Add(this.cEngAlp);
            this.groupBox2.Controls.Add(this.cRuAlp);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 450);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки";
            // 
            // bLoadFromFile
            // 
            this.bLoadFromFile.Location = new System.Drawing.Point(6, 366);
            this.bLoadFromFile.Name = "bLoadFromFile";
            this.bLoadFromFile.Size = new System.Drawing.Size(163, 23);
            this.bLoadFromFile.TabIndex = 8;
            this.bLoadFromFile.Text = "Прочитать из файла";
            this.bLoadFromFile.UseVisualStyleBackColor = true;
            this.bLoadFromFile.Click += new System.EventHandler(this.bLoadFromFile_Click);
            // 
            // bSaveToFile
            // 
            this.bSaveToFile.Location = new System.Drawing.Point(6, 327);
            this.bSaveToFile.Name = "bSaveToFile";
            this.bSaveToFile.Size = new System.Drawing.Size(163, 23);
            this.bSaveToFile.TabIndex = 7;
            this.bSaveToFile.Text = "Сохранить в файл";
            this.bSaveToFile.UseVisualStyleBackColor = true;
            this.bSaveToFile.Click += new System.EventHandler(this.bSaveToFile_Click);
            // 
            // bGenAlphabet
            // 
            this.bGenAlphabet.Location = new System.Drawing.Point(6, 289);
            this.bGenAlphabet.Name = "bGenAlphabet";
            this.bGenAlphabet.Size = new System.Drawing.Size(163, 23);
            this.bGenAlphabet.TabIndex = 6;
            this.bGenAlphabet.Text = "Сгенерировать алфавит";
            this.bGenAlphabet.UseVisualStyleBackColor = true;
            this.bGenAlphabet.Click += new System.EventHandler(this.bGenAlphabet_Click);
            // 
            // cRegister
            // 
            this.cRegister.AutoSize = true;
            this.cRegister.Location = new System.Drawing.Point(6, 255);
            this.cRegister.Name = "cRegister";
            this.cRegister.Size = new System.Drawing.Size(137, 17);
            this.cRegister.TabIndex = 5;
            this.cRegister.Text = "Регистрозависимый?";
            this.cRegister.UseVisualStyleBackColor = true;
            this.cRegister.CheckedChanged += new System.EventHandler(this.cRegister_CheckedChanged);
            // 
            // cAddSym
            // 
            this.cAddSym.AutoSize = true;
            this.cAddSym.Location = new System.Drawing.Point(6, 128);
            this.cAddSym.Name = "cAddSym";
            this.cAddSym.Size = new System.Drawing.Size(163, 17);
            this.cAddSym.TabIndex = 4;
            this.cAddSym.Text = "Дополнительные символы";
            this.cAddSym.UseVisualStyleBackColor = true;
            this.cAddSym.CheckedChanged += new System.EventHandler(this.cAddSym_CheckedChanged);
            // 
            // txbSym
            // 
            this.txbSym.Location = new System.Drawing.Point(6, 151);
            this.txbSym.Multiline = true;
            this.txbSym.Name = "txbSym";
            this.txbSym.ReadOnly = true;
            this.txbSym.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbSym.Size = new System.Drawing.Size(163, 82);
            this.txbSym.TabIndex = 3;
            // 
            // cEngAlp
            // 
            this.cEngAlp.AutoSize = true;
            this.cEngAlp.Location = new System.Drawing.Point(12, 78);
            this.cEngAlp.Name = "cEngAlp";
            this.cEngAlp.Size = new System.Drawing.Size(132, 17);
            this.cEngAlp.TabIndex = 1;
            this.cEngAlp.Text = "Английский алфавит";
            this.cEngAlp.UseVisualStyleBackColor = true;
            this.cEngAlp.CheckedChanged += new System.EventHandler(this.cEngAlp_CheckedChanged);
            // 
            // cRuAlp
            // 
            this.cRuAlp.AutoSize = true;
            this.cRuAlp.Checked = true;
            this.cRuAlp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cRuAlp.Location = new System.Drawing.Point(12, 38);
            this.cRuAlp.Name = "cRuAlp";
            this.cRuAlp.Size = new System.Drawing.Size(120, 17);
            this.cRuAlp.TabIndex = 0;
            this.cRuAlp.Text = "Русский алафавит";
            this.cRuAlp.UseVisualStyleBackColor = true;
            this.cRuAlp.CheckedChanged += new System.EventHandler(this.cRuAlp_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bLoadText);
            this.groupBox1.Controls.Add(this.bAttack);
            this.groupBox1.Controls.Add(this.txbKey);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbResult);
            this.groupBox1.Controls.Add(this.bDecrypt);
            this.groupBox1.Controls.Add(this.bEncrypt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbAlgorythm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(25, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 450);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txbKey
            // 
            this.txbKey.Location = new System.Drawing.Point(49, 270);
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(191, 20);
            this.txbKey.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ключ";
            // 
            // txbResult
            // 
            this.txbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbResult.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txbResult.ForeColor = System.Drawing.Color.Gold;
            this.txbResult.Location = new System.Drawing.Point(10, 306);
            this.txbResult.Multiline = true;
            this.txbResult.Name = "txbResult";
            this.txbResult.ReadOnly = true;
            this.txbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbResult.Size = new System.Drawing.Size(574, 132);
            this.txbResult.TabIndex = 7;
            // 
            // bDecrypt
            // 
            this.bDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDecrypt.Location = new System.Drawing.Point(354, 231);
            this.bDecrypt.Name = "bDecrypt";
            this.bDecrypt.Size = new System.Drawing.Size(230, 23);
            this.bDecrypt.TabIndex = 6;
            this.bDecrypt.Text = "Расшифровать";
            this.bDecrypt.UseVisualStyleBackColor = true;
            this.bDecrypt.Click += new System.EventHandler(this.bDecrypt_Click);
            // 
            // bEncrypt
            // 
            this.bEncrypt.Location = new System.Drawing.Point(10, 231);
            this.bEncrypt.Name = "bEncrypt";
            this.bEncrypt.Size = new System.Drawing.Size(230, 23);
            this.bEncrypt.TabIndex = 5;
            this.bEncrypt.Text = "Зашифровать";
            this.bEncrypt.UseVisualStyleBackColor = true;
            this.bEncrypt.Click += new System.EventHandler(this.bEncrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ввод";
            // 
            // txbInput
            // 
            this.txbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbInput.Location = new System.Drawing.Point(10, 99);
            this.txbInput.Multiline = true;
            this.txbInput.Name = "txbInput";
            this.txbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbInput.Size = new System.Drawing.Size(574, 126);
            this.txbInput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Алгоритм ";
            // 
            // cmbAlgorythm
            // 
            this.cmbAlgorythm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAlgorythm.FormattingEnabled = true;
            this.cmbAlgorythm.Location = new System.Drawing.Point(10, 36);
            this.cmbAlgorythm.Name = "cmbAlgorythm";
            this.cmbAlgorythm.Size = new System.Drawing.Size(574, 21);
            this.cmbAlgorythm.TabIndex = 1;
            this.cmbAlgorythm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorythm_SelectedIndexChanged);
            // 
            // btnShowSettings
            // 
            this.btnShowSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowSettings.Location = new System.Drawing.Point(0, 0);
            this.btnShowSettings.Name = "btnShowSettings";
            this.btnShowSettings.Size = new System.Drawing.Size(25, 450);
            this.btnShowSettings.TabIndex = 0;
            this.btnShowSettings.Text = ">";
            this.btnShowSettings.UseVisualStyleBackColor = true;
            this.btnShowSettings.Click += new System.EventHandler(this.btnShowSettings_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "fileDialog";
            // 
            // bAttack
            // 
            this.bAttack.Location = new System.Drawing.Point(354, 266);
            this.bAttack.Name = "bAttack";
            this.bAttack.Size = new System.Drawing.Size(230, 23);
            this.bAttack.TabIndex = 10;
            this.bAttack.Text = "Криптографическая атака";
            this.bAttack.UseVisualStyleBackColor = true;
            this.bAttack.Visible = false;
            this.bAttack.Click += new System.EventHandler(this.bAttack_Click);
            // 
            // bLoadText
            // 
            this.bLoadText.BackgroundImage = global::Pr3.Properties.Resources.png_transparent_load_file_computer_icons_others_miscellaneous_cdr_data;
            this.bLoadText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bLoadText.Location = new System.Drawing.Point(559, 68);
            this.bLoadText.Name = "bLoadText";
            this.bLoadText.Size = new System.Drawing.Size(25, 25);
            this.bLoadText.TabIndex = 11;
            this.bLoadText.UseVisualStyleBackColor = true;
            this.bLoadText.Click += new System.EventHandler(this.bLoadText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Шифратор/Дешифратор";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAlgorythm;
        private System.Windows.Forms.Button btnShowSettings;
        private System.Windows.Forms.CheckBox cAddSym;
        private System.Windows.Forms.TextBox txbSym;
        private System.Windows.Forms.CheckBox cEngAlp;
        private System.Windows.Forms.CheckBox cRuAlp;
        private System.Windows.Forms.TextBox txbKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbResult;
        private System.Windows.Forms.Button bDecrypt;
        private System.Windows.Forms.Button bEncrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbInput;
        private System.Windows.Forms.CheckBox cRegister;
        private System.Windows.Forms.Button bGenAlphabet;
        private System.Windows.Forms.Button bLoadFromFile;
        private System.Windows.Forms.Button bSaveToFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bAttack;
        private System.Windows.Forms.Button bLoadText;
    }
}

