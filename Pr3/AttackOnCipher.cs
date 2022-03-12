using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pr3
{
    public partial class AttackOnCipher : Form
    {
        string _text = "";
        char[] _currentAlphabet = null;
        public AttackOnCipher(string text,char[] alphabet)
        {
            InitializeComponent();
            _text = text;
            _currentAlphabet = alphabet;
            txbChanged.Text = text;
            FillDict();
            SetChart();
        }
        Dictionary<char, int> _currentFreq = new Dictionary<char, int>();
        int _shift = 0;
        private void SetChart()
        {
            var sortedDictionary = from entry in _frequency orderby entry.Value descending select entry;
            foreach (var letter in sortedDictionary)
            {
                Series seria = new Series();
                seria.Name = char.ToUpper(letter.Key).ToString();
                seria.Points.Add(letter.Value*100);
                chart1.Series.Add(seria);
            }
            chart1.ChartAreas[0].AxisY.Interval = 0.5;
            chart1.ChartAreas[0].AxisX.Minimum = 0.6;
            chart1.ChartAreas[0].AxisX.Maximum = 1.4;
            chart1.Titles.Add("Статистические данные");
            var sortedDictionary2 = from entry in _currentFreq orderby entry.Value descending select entry;
            int max =Array.IndexOf(_currentAlphabet, char.ToUpper(sortedDictionary.First().Key));
            int maxCurrent = Array.IndexOf(_currentAlphabet, sortedDictionary2.First().Key);

            _shift = -(max - maxCurrent);
            txbShift.Text = _shift.ToString();

            foreach (var letter in sortedDictionary2)
            {
                Series seria = new Series();
                seria.Name = char.ToUpper(letter.Key).ToString();
                seria.Points.Add(letter.Value );
                chart2.Series.Add(seria);
            }
            chart2.ChartAreas[0].AxisX.Minimum = 0.6;
            chart2.ChartAreas[0].AxisX.Maximum = 1.4;
            chart2.Titles.Add("Текущий текст");

        }
        Dictionary<char,char> _changedLetters = new Dictionary<char, char>();
        private void FillDict()
        {
            _frequency.Add('а', 0.07998);
            _frequency.Add('б', 0.01592);
            _frequency.Add('в', 0.04533);
            _frequency.Add('г', 0.01687);
            _frequency.Add('д', 0.02977);
            _frequency.Add('е', 0.08483);
            _frequency.Add('ё', 0.00013);
            _frequency.Add('ж', 0.0094);
            _frequency.Add('з', 0.01641);
            _frequency.Add('и', 0.07367);
            _frequency.Add('й', 0.01208);
            _frequency.Add('к', 0.03486);
            _frequency.Add('л', 0.04343);
            _frequency.Add('м', 0.03203);
            _frequency.Add('н', 0.067);
            _frequency.Add('о', 0.10983);
            _frequency.Add('п', 0.02804);
            _frequency.Add('р', 0.04746);
            _frequency.Add('с', 0.05473);
            _frequency.Add('т', 0.06318);
            _frequency.Add('у', 0.02615);
            _frequency.Add('ф', 0.00267);
            _frequency.Add('х', 0.00966);
            _frequency.Add('ц', 0.00486);
            _frequency.Add('ч', 0.0145);
            _frequency.Add('ш', 0.00718);
            _frequency.Add('щ', 0.00361);
            _frequency.Add('ъ', 0.00037);
            _frequency.Add('ы', 0.01898);
            _frequency.Add('ь', 0.01735);
            _frequency.Add('э', 0.00331);
            _frequency.Add('ю', 0.00639);
            _frequency.Add('я', 0.02001);

            foreach(char letter in _text)
            {
                if (char.IsLetter(letter))
                {
                    if (_currentFreq.ContainsKey(char.ToUpper(letter)))
                    {
                        _currentFreq[char.ToUpper(letter)]++;
                    }
                    else
                    {
                        _currentFreq.Add(char.ToUpper(letter), 1);
                    }
                }

            }

            
        }

        Dictionary<char, double> _frequency = new Dictionary<char, double>();
        private void bHide_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
                splitContainer1.Panel1Collapsed = false;
            else
                splitContainer1.Panel1Collapsed = true;
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            int key = lstLetters.SelectedIndex;
            if (key >= 0)
            {
                char letter = lstLetters.Items[key].ToString()[0];
                _changedLetters.Remove(letter);
                lstLetters.Items.RemoveAt(key);
                UpdateTextbox(Color.Red);
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txbFrom.Text) && !string.IsNullOrEmpty(txbTo.Text))
            {
                char from = txbFrom.Text[0];
                char to = txbTo.Text[0];
                if (!_changedLetters.ContainsKey(char.ToUpper(from)))
                {
                    _changedLetters.Add(char.ToUpper(from), char.ToUpper(to));
                    lstLetters.Items.Add(char.ToUpper(from)+" ::: "+ char.ToUpper(to));
                } 
                else
                    MessageBox.Show("Буква уже содержится в таблице замен");
            }
            UpdateTextbox(Color.Red);
        }

        private void UpdateTextbox(Color color)
        {
            txbChanged.Clear();
            foreach(char letter in _text.ToCharArray())
            {
                if (_changedLetters.ContainsKey(char.ToUpper(letter)))
                {
                    txbChanged.AppendText(_changedLetters[char.ToUpper(letter)].ToString(), color);
                }
                else
                {
                    txbChanged.AppendText(letter.ToString(), Color.Black);
                }
            }
        }
        bool hidden = false;
        private void bHideShow_Click(object sender, EventArgs e)
        {
            Color changedColor;
            if (hidden)
            {
                changedColor = Color.Red;
                hidden = false;
            }
            else
            {
                changedColor = Color.White;
                hidden = true;
            }
                

            UpdateTextbox(changedColor);
        }

        private void bShift_Click(object sender, EventArgs e)
        {
            int key = 0;
            if(int.TryParse(txbShift.Text,out key))
            {
                string decrypt = CipherController.DecryptCaesar(_currentAlphabet, key, _text);
                txbChanged.Text = decrypt;
            }

        }

        private void bNext_Click(object sender, EventArgs e)
        {
            int key = 0;
            if (int.TryParse(txbShift.Text, out key))
            {
                key++;
                if (key == 33)
                    key = 0;
                txbShift.Text = "" + key;
                string decrypt = CipherController.DecryptCaesar(_currentAlphabet, key, _text);
                txbChanged.Text = decrypt;
            }
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
