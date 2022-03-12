using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr3
{

    public partial class Form1 : Form
    {
        char[] _alpEng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] _alpEngLow = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        char[] _alpRus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
        char[] _alpRusLow = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        char[] _currentAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
        public Form1()
        {
            InitializeComponent();
            cmbAlgorythm.Items.Add("Аддитивный моноалфавитный шифр (шифр Цезаря)");
            cmbAlgorythm.Items.Add("Аддитивный шифр (полиалфавитный/моноалфавитный) с перемешанным алфавитом");
            cmbAlgorythm.Items.Add("Мультипликативный шифр");
            cmbAlgorythm.Items.Add("Шифр Плейфеера");
            cmbAlgorythm.SelectedIndex = 0;
        }
        int _selectedCipher = -1;
        private void btnShowSettings_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
                splitContainer1.Panel1Collapsed = false;
            else
                splitContainer1.Panel1Collapsed = true;
        }

        private void cmbAlgorythm_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCipher = cmbAlgorythm.SelectedIndex;

            cAddSym.Enabled = true;
            cRegister.Enabled = true;
            bSaveToFile.Enabled = true;
            bLoadFromFile.Enabled = true;
            bGenAlphabet.Enabled = true;
            cAddSym.Text = "Дополнительные символы";

            switch (_selectedCipher)
            {
                case 0:
                    cAddSym.Checked = false;
                    cRegister.Checked = false;
                    cRegister.Enabled = false;
                    bSaveToFile.Enabled = false;
                    bLoadFromFile.Enabled = false;
                    bGenAlphabet.Enabled = false;
                    bAttack.Visible = true;
                    cAddSym.Text = "Кодовое слово";
                    break;
                case 1:
                    bAttack.Visible = false;
                    break;
                case 2:
                    cAddSym.Enabled = false;
                    cAddSym.Checked = false;
                    cRegister.Checked = false;
                    cRegister.Enabled = false;
                    bSaveToFile.Enabled = false;
                    bLoadFromFile.Enabled = false;
                    bGenAlphabet.Enabled = false;
                    bAttack.Visible = false;
                    break;
                case 3:
                    cAddSym.Enabled = false;
                    cAddSym.Checked = false;
                    cRegister.Checked = false;
                    cRegister.Enabled = false;
                    bSaveToFile.Enabled = false;
                    bLoadFromFile.Enabled = false;
                    bGenAlphabet.Enabled = false;
                    bAttack.Visible = false;
                    break;
            }
        }
        private void cRuAlp_CheckedChanged(object sender, EventArgs e)
        {
            if (!cRuAlp.Checked && !cEngAlp.Checked)
            {
                MessageBox.Show("Не выбрано ни одного алфавита."
                    + Environment.NewLine
                    + "Установлен алфавит по умолчанию.");
                cRuAlp.Checked = true;
                _currentAlphabet = _alpRus;
            }

            switch (_selectedCipher)
            {
                case 0:
                    if (cEngAlp.Checked && cRuAlp.Checked)
                    {
                        cEngAlp.Checked = false;
                        cRuAlp.Checked = true;
                        _currentAlphabet = _alpRus;
                    }
                        
                    break;
                case 1:
                    break;
                case 2:
                    if (cEngAlp.Checked && cRuAlp.Checked)
                    {
                        cEngAlp.Checked = false;
                        cRuAlp.Checked = true;
                        _currentAlphabet = _alpRus;
                    }
                    break;
            }

        }
        private void cAddSym_CheckedChanged(object sender, EventArgs e)
        {
            if (cAddSym.Checked)
            {
                txbSym.ReadOnly = false;
            }
            else
            {
                txbSym.Clear();
                txbSym.ReadOnly = true;
            }
        }
        private void cEngAlp_CheckedChanged(object sender, EventArgs e)
        {
            if (!cRuAlp.Checked && !cEngAlp.Checked)
            {
                MessageBox.Show("Не выбрано ни одного алфавита."
                + Environment.NewLine
                + "Установлен алфавит по умолчанию.");
                cRuAlp.Checked = true;
                _currentAlphabet = _alpRus;
            }

            switch (_selectedCipher)
            {
                case 0:
                    if (cEngAlp.Checked && cRuAlp.Checked)
                    {
                        cEngAlp.Checked = true;
                        cRuAlp.Checked = false;
                        _currentAlphabet = _alpEng;
                    }

                    break;
                case 1:
                    break;
                case 2:
                    if (cEngAlp.Checked && cRuAlp.Checked)
                    {
                        cEngAlp.Checked = true;
                        cRuAlp.Checked = false;
                        _currentAlphabet = _alpEng;
                    }
                    break;
                case 3:
                    if (cEngAlp.Checked && cRuAlp.Checked)
                    {
                        cEngAlp.Checked = true;
                        cRuAlp.Checked = false;
                        _currentAlphabet = _alpEng;
                    }
                    break;
            }

        }
        Random rand = new Random();
        int _addKey = 0;
        void CheckKey()
        {
            if (string.IsNullOrEmpty(txbKey.Text))
            {
                _addKey = rand.Next(1000);
                txbKey.Text = _addKey.ToString();
            }
            else
            {
                if (!int.TryParse(txbKey.Text, out _addKey))
                {

                    _addKey = rand.Next(1000);
                    MessageBox.Show($"Ключ был изменен на {_addKey}");

                    txbKey.Text = _addKey.ToString();
                }

            }
            if (cAddSym.Checked)
            {
                bool allLetters = true;
                foreach(char letter in txbSym.Text)
                {
                    if (!char.IsLetter(letter))
                        allLetters = false;
                }
                List<char> lett = new List<char>();
                if (allLetters)
                {
                    foreach (char letter in txbSym.Text)
                    {
                        if (!lett.Contains(char.ToUpper(letter)))
                        {
                            lett.Add(char.ToUpper(letter));
                        }
                          
                    }
                    foreach(char letter in _currentAlphabet)
                    {
                        if (!lett.Contains(char.ToUpper(letter)))
                        {
                            lett.Add(char.ToUpper(letter));
                        }
                    }
                    _currentAlphabet = lett.ToArray();
                }
            }
        }
        private void bEncrypt_Click(object sender, EventArgs e)
        {
            switch (_selectedCipher)
            {
                case 0:
                    CheckKey();
                    txbResult.Text = CipherController.EncryptCaesar(_currentAlphabet, _addKey, txbInput.Text);

                    break;
                case 1:
                    CheckKey();
                    txbResult.Text = CipherController.EncryptAdditive(_currentAlphabet, _addKey, txbInput.Text, cRegister.Checked);
                    break;
                case 2:
                    Dictionary<int, int> keys = new Dictionary<int, int>();
                    for (int i = 0; i < _currentAlphabet.Length; i++)
                    {
                        for (int j = 0; j < _currentAlphabet.Length; j++)
                        {
                            if ((i * j) % _currentAlphabet.Length == 1)
                                keys.Add(i, j);
                        }
                    }
                    if (!keys.ContainsKey(_addKey))
                    {
                        MessageBox.Show("Ключ задан не верно!");
                        return;
                    }
                    txbResult.Text = CipherController.EncryptMultiplicative(_currentAlphabet, _addKey, txbInput.Text);
                    break;
                case 3:
                    PlayfairMatrix matrix=null;
                    if (cEngAlp.Checked)
                        matrix = new PlayfairMatrix(_currentAlphabet,txbKey.Text,txbInput.Text,'X');
                    else
                        matrix = new PlayfairMatrix(_currentAlphabet, txbKey.Text, txbInput.Text, 'Х');
                    matrix.Show();
                    matrix.Encrypt();
                    txbResult.Text = matrix.ENCRYPTED;
                    break;
            }

            
            txbResult.Text+= PrintAlphabet(_currentAlphabet);

        }
        private string PrintAlphabet(char[] alphabet)
        {
            string res = "";
            res = Environment.NewLine+Environment.NewLine + "##### Текущий алфавит #####"+Environment.NewLine;
            foreach(char sym in alphabet)
            {
                res += sym;
            }
            return res;
        }

        private void bDecrypt_Click(object sender, EventArgs e)
        {
            switch (_selectedCipher)
            {
                case 0:
                    if (string.IsNullOrEmpty(txbKey.Text))
                    {
                        MessageBox.Show("Не задан ключ!");
                        return;
                    }
                    else
                    {
                        if (!int.TryParse(txbKey.Text, out _addKey))
                        {
                            MessageBox.Show("Ключ задан не верно!");

                            txbKey.Clear();
                            return;
                        }

                    }
                    txbResult.Text = CipherController.DecryptCaesar(_currentAlphabet, _addKey, txbInput.Text);

                    break;
                case 1:
                    if (string.IsNullOrEmpty(txbKey.Text))
                    {
                        MessageBox.Show("Не задан ключ!");
                        return;
                    }
                    else
                    {
                        if (!int.TryParse(txbKey.Text, out _addKey))
                        {
                            MessageBox.Show("Ключ задан не верно!");

                            txbKey.Clear();
                            return;
                        }

                    }
                    txbResult.Text = CipherController.DecryptAdditive(_currentAlphabet, _addKey, txbInput.Text, cRegister.Checked);
                    
                    break;
                case 2:
                    Dictionary<int, int> keys = new Dictionary<int, int>();
                    for(int i = 0; i < _currentAlphabet.Length; i++)
                    {
                        for (int j = 0; j < _currentAlphabet.Length; j++)
                        {
                            if ((i * j) % _currentAlphabet.Length == 1)
                                keys.Add(i, j);
                        }
                    }
                    if (!keys.ContainsKey(_addKey))
                    {
                        MessageBox.Show("Ключ задан не верно!");
                        return;
                    }

                    txbResult.Text = CipherController.DecryptMultiplicative(_currentAlphabet, keys[_addKey], txbInput.Text);
                    break;
                case 3:
                    PlayfairMatrix matrix = null;
                    if (cEngAlp.Checked)
                        matrix = new PlayfairMatrix(_currentAlphabet, txbKey.Text, txbInput.Text, 'X');
                    else
                        matrix = new PlayfairMatrix(_currentAlphabet, txbKey.Text, txbInput.Text, 'Х');
                    matrix.Show();
                    matrix.Decrypt(txbInput.Text);
                    txbResult.Text = matrix.DECRYPTED;
                    break;
            }


            txbResult.Text += PrintAlphabet(_currentAlphabet);

        }

        private void cRegister_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bGenAlphabet_Click(object sender, EventArgs e)
        {
            if (cRegister.Checked)
            {
                if (cRuAlp.Checked && cEngAlp.Checked)
                {
                    _currentAlphabet = _alpRus.Concat(_alpRusLow).Concat(_alpEng).Concat(_alpEngLow).ToArray();
                }
                else if (cRuAlp.Checked)
                {
                    _currentAlphabet = _alpRus.Concat(_alpRusLow).ToArray();
                }
                else if (cEngAlp.Checked)
                {
                    _currentAlphabet = _alpEng.Concat(_alpEngLow).ToArray();
                }
            }
            else
            {
                if (cRuAlp.Checked && cEngAlp.Checked)
                {
                    _currentAlphabet = _alpRus.Concat(_alpEng).ToArray();
                }
                else if (cRuAlp.Checked)
                {
                    _currentAlphabet = _alpRus;
                }
                else if (cEngAlp.Checked)
                {
                    _currentAlphabet = _alpEng;
                }
            }

            if (cAddSym.Checked)
                _currentAlphabet= _currentAlphabet.Concat(txbSym.Text.ToCharArray()).ToArray();

            _currentAlphabet = CipherController.Shuffle(_currentAlphabet);

            MessageBox.Show("Был сгенерирован алфавит:"+Environment.NewLine+PrintAlphabet(_currentAlphabet));
        }

        private void bSaveToFile_Click(object sender, EventArgs e)
        {
            //157
            string toFile = new string(_currentAlphabet);
            using(System.IO.StreamWriter sw=new System.IO.StreamWriter("Alphabet.alp"))
            {
                sw.WriteLine(toFile);
                sw.WriteLine(cRegister.Checked);
            }
            MessageBox.Show("Алфавит сохранён.");
        }

        private void bLoadFromFile_Click(object sender, EventArgs e)
        {
            //"Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*""
            openFileDialog1.Title = "Выберите файл алфавита (.alp)";
            openFileDialog1.Filter = "Файлы алфавита (*.alp)|*.alp";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Алфавит не установлен.");
                return;
            }
                
            using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName))
            {
                _currentAlphabet= sr.ReadLine().ToCharArray();
                cRegister.Checked= bool.Parse(sr.ReadLine());
            }
            MessageBox.Show("Был установлен алфавит:" + Environment.NewLine + PrintAlphabet(_currentAlphabet));
        }

        private void bAttack_Click(object sender, EventArgs e)
        {
            AttackOnCipher attackForm = new AttackOnCipher(txbInput.Text,_currentAlphabet);
            attackForm.Show();
        }

        private void bLoadText_Click(object sender, EventArgs e)
        {
            string text = "";
            using (System.IO.StreamReader sr = new System.IO.StreamReader("Sample.txt"))
            {
                while (!sr.EndOfStream)
                {
                    text += sr.ReadLine() + Environment.NewLine;
                }
            }
            txbInput.Text = text;
        }
    }
}
