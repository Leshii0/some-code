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
    public partial class PlayfairMatrix : Form
    {
        char[] _currentAlphabet = null;
        char[] _key = null;
        char[,] _matrix = null;
        char[] _symbols = new char[] { '0','1','2','3','4','5','6','7','8','9' };
        string _message = "";
        //eng - ru
        char _spLetter = 'X';
        public PlayfairMatrix(char[] Alphabet,string key,string text,char sp)
        {
            InitializeComponent();
            _currentAlphabet = Alphabet;
            _key = key.ToUpper().ToCharArray();
            _message = new string(text.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray()); 
            _spLetter = sp;
            SetupDatagrid();
        }
        int _dgvColWidth = 50;
        int _dgvRowHeight = 50;
        string _encrypted = "";
        string _decrypted = "";
        public string ENCRYPTED
        {
            get
            {
                return _encrypted;
            }
        }
        public string DECRYPTED
        {
            get
            {
                return _decrypted;
            }
        }
        int columns = 0;
        int rows = 0;
        public void Encrypt()
        {
            List<string> bigrams = new List<string>();

            for (int i = 0; i < _message.Length; i++)
            {
                char first = _message[i];
                char second = 'X';
                if (i + 1 == _message.Length)
                {
                    second = _spLetter;
                }
                else
                {
                    second = _message[i + 1];
                }


                if (first == second)
                {
                    second = _spLetter;
                }
                else
                {
                    i++;
                }
                string bigram = first.ToString() + second.ToString();
                bigrams.Add(bigram);
            }

            List<string> encrypted = new List<string>();

            foreach (string bigr in bigrams)
            {
                int firstRow = 0;
                int firstColumn = 0;
                int secondRow = 0;
                int secondColumn = 0;

                string newBigram = "";

                for (int i = 0; i < columns; i++)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        if (bigr[0] == _matrix[k, i])
                        {
                            firstRow = k;
                            firstColumn = i;
                        }
                        else if (bigr[1] == _matrix[k, i])
                        {
                            secondRow = k;
                            secondColumn = i;
                        }

                    }
                }

                if (firstRow == secondRow)
                {

                    firstColumn++;
                    secondColumn++;
                    if (firstColumn >= rows)
                        firstColumn = 0;

                    if (secondColumn >= rows)
                        secondColumn = 0;
                }
                else if (firstColumn == secondColumn)
                {
                    firstRow++;
                    secondRow++;
                    if (firstRow >= columns)
                        firstRow = 0;

                    if (secondRow >= columns)
                        secondRow = 0;
                }
                else
                {
                    int temp = firstColumn;
                    firstColumn = secondColumn;
                    secondColumn = temp;
                }

                string bigram = _matrix[secondRow, secondColumn].ToString() + _matrix[firstRow, firstColumn].ToString();
                encrypted.Add(bigram);


            }

            foreach (string bigr in encrypted)
            {
                _encrypted += bigr;
            }
        }

        public void Decrypt(string encrypt)
        {
            List<string> bigrams = new List<string>();

            for (int i = 0; i < encrypt.Length-1; i+=2)
            {
                char first = _message[i];
                char second = _message[i + 1];

                string bigram = first.ToString() + second.ToString();
                bigrams.Add(bigram);
            }

            List<string> decrypted = new List<string>();

            foreach (string bigr in bigrams)
            {
                int firstRow = 0;
                int firstColumn = 0;
                int secondRow = 0;
                int secondColumn = 0;

                for (int i = 0; i < columns; i++)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        if (bigr[0] == _matrix[k, i])
                        {
                            firstRow = k;
                            firstColumn = i;
                        }
                        else if (bigr[1] == _matrix[k, i])
                        {
                            secondRow = k;
                            secondColumn = i;
                        }

                    }
                }

                if (firstRow == secondRow)
                {

                    firstColumn--;
                    secondColumn--;
                    if (firstColumn < 0)
                        firstColumn = rows-1;

                    if (secondColumn < 0)
                        secondColumn = rows-1;
                }
                else if (firstColumn == secondColumn)
                {
                    firstRow--;
                    secondRow--;
                    if (firstRow <0 )
                        firstRow = columns-1;

                    if (secondRow < 0)
                        secondRow = columns-1;
                }
                else
                {
                    int temp = firstColumn;
                    firstColumn = secondColumn;
                    secondColumn = temp;
                }

                string bigram = _matrix[secondRow, secondColumn].ToString() + _matrix[firstRow, firstColumn].ToString();
                decrypted.Add(bigram);


            }

            foreach (string bigr in decrypted)
            {
                _decrypted += bigr;
            }
            string withoutSpecial= new string(_decrypted.ToCharArray().Where(c => c != _spLetter).ToArray());
            _decrypted += Environment.NewLine + withoutSpecial;
        }

        private void SetupDatagrid()
        {
            List<char> lettersInKey = new List<char>();

            foreach(char letter in _key)
            {
                if (!lettersInKey.Contains(letter) && _currentAlphabet.Contains(letter))
                    lettersInKey.Add(letter);
            }

            foreach(char letter in _currentAlphabet)
            {
                if (!lettersInKey.Contains(letter))
                    lettersInKey.Add(letter);
            }

            rows = 0;
            columns = 0;
            int _alpCount = _currentAlphabet.Length;

            if(_alpCount>25 && _alpCount < 36)
            {
                rows = columns = 6;
            }
            else if (_alpCount <= 25)
            {
                rows = columns = 5;
            }
            else if (_alpCount >= 36 && _alpCount<49)
            {
                rows = columns = 7;
            }
            int difference = rows * columns - _alpCount;
            lettersInKey.AddRange(_symbols.Take(difference));



            dgvMatrix.Width = _dgvColWidth * columns;
            dgvMatrix.Height = _dgvRowHeight * rows;
            dgvMatrix.Location = new Point(0, 0);
            this.Height = dgvMatrix.Height+37;
            this.Width = dgvMatrix.Width+18;

            dgvMatrix.RowTemplate.Height = _dgvRowHeight;

            for (int i = 0; i < columns; i++)
            {
                dgvMatrix.Columns.Add("c" + i,"h");
                dgvMatrix.Columns["c" + i].Width = _dgvColWidth;
            }
            for (int i = 0; i < rows; i++)
            {
                dgvMatrix.Rows.Add();
            }

            int index = 0;
            _matrix = new char[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int k = 0; k < rows; k++)
                {
                    dgvMatrix[k, i].Value = lettersInKey[index];
                    _matrix[k, i] = lettersInKey[index];
                    index++;
                }
            }
            

        }
    }
}
