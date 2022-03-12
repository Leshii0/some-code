using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr3
{
    public static class CipherController
    {
        static Random  swap = new Random(133);
        public static string DecryptAdditive(char[] _alphabet, int key,string encrypted,bool useRegister)
        {
            string output = "";

            int _alpCount = _alphabet.Length;

            foreach (char letter in encrypted.ToCharArray())
            {
                int currentIndex = Array.IndexOf(_alphabet, char.ToUpper(letter));

                if (useRegister)
                    currentIndex = Array.IndexOf(_alphabet, letter);

                if (currentIndex != -1)
                {
                    int newPos = key - currentIndex;

                    int realShift = Math.Abs(newPos) % _alpCount;

                    if (Math.Abs(newPos) < _alpCount)
                    {
                        if (newPos < 0)
                            output += _alphabet[Math.Abs(newPos)];
                        else
                            output += _alphabet[_alpCount - newPos];
                    }
                    else
                        output += _alphabet[_alpCount - realShift];
                }
                else
                    output += letter;

            }
            return output;
        }

        public static string EncryptAdditive(char[] _alphabet, int key, string text, bool useRegister)
        {
            string output = "";

            int _alpCount = _alphabet.Length;

            foreach (char letter in text.ToCharArray())
            {
                int currentIndex = Array.IndexOf(_alphabet, char.ToUpper(letter));
                if (useRegister)
                    currentIndex = Array.IndexOf(_alphabet, letter);


                if (currentIndex != -1)
                {
                    int newPos = key + currentIndex;

                    int realShift = newPos % _alpCount;

                    output += _alphabet[realShift];
                }
                else
                    output += letter;

            }

            return output;
        }

        public static string EncryptCaesar(char[] _alphabet,int key,string text)
        {
            string output = "";

            int _alpCount = _alphabet.Length;

            foreach (char letter in text.ToCharArray())
            {
                int currentIndex = Array.IndexOf(_alphabet, char.ToUpper(letter));

                if (currentIndex != -1)
                {
                    int newPos = key + currentIndex;

                    int realShift = newPos % _alpCount;

                    if(realShift<0)
                        output += _alphabet[_alpCount+realShift];
                    else
                        output += _alphabet[realShift];
                }
                else
                    output += letter;

            }

            return output;
        }

        public static string DecryptCaesar(char[] _alphabet, int key, string encrypted)
        {
            string output = "";

            int _alpCount = _alphabet.Length;

            foreach (char letter in encrypted.ToCharArray())
            {
                int currentIndex = Array.IndexOf(_alphabet, char.ToUpper(letter));

                if (currentIndex != -1)
                {
                    int newPos = key - currentIndex;

                    int realShift = Math.Abs(newPos) % _alpCount;

                    if (Math.Abs(newPos) < _alpCount)
                    {
                        if (newPos <= 0)
                            output += _alphabet[Math.Abs(newPos)];
                        else
                            output += _alphabet[_alpCount - newPos];
                    }
                    else if (realShift == 0)
                    {
                        output += _alphabet[0];
                    }
                    else
                        output += _alphabet[_alpCount - realShift];
                }
                else
                    output += letter;

            }
            return output;
        }

        public static string DecryptMultiplicative(char[] _alphabet, int key, string encrypted)
        {
            
            string output = "";

            int _alpCount = _alphabet.Length;

            foreach (char letter in encrypted.ToCharArray())
            {
                int currentIndex = Array.IndexOf(_alphabet, char.ToUpper(letter));

                if (currentIndex != -1)
                {
                    int newPos = (currentIndex*key) %_alpCount;


                    output += _alphabet[newPos];
                }
                else
                    output += letter;

            }
            return output;
        }

        public static string EncryptMultiplicative(char[] _alphabet, int key, string text)
        {
            string output = "";

            int _alpCount = _alphabet.Length;

            foreach (char letter in text.ToCharArray())
            {
                int currentIndex = Array.IndexOf(_alphabet, char.ToUpper(letter));


                if (currentIndex != -1)
                {
                    int newPos = (key * currentIndex) % _alpCount;

                    output += _alphabet[newPos];
                }
                else
                    output += letter;

            }

            return output;
        }

        public static char[] Shuffle(char[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                char temp = array[i];
                int swapIndex = swap.Next(0, array.Length);
                array[i] = array[swapIndex];
                array[swapIndex] = temp;
            }

            return array;
        }
    }
}
