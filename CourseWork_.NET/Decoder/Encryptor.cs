using System;
using System.Linq;

namespace Decoder
{
    public class Encryptor
    {
        public string txt;
        public string keyword;
        public Encryptor()
        {
        }
        static char[] alfabet = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                                'э', 'ю', 'я' };

        int N = alfabet.Length;
        public string Encrypt(string s)
        {
            txt = s.ToLower();
            keyword = keyword.ToLower();
            string result = "";
            int keyword_index = 0;
            foreach (char symbol in txt)
            {
                if (!alfabet.Contains(symbol))
                {
                    result += symbol;
                }
                else
                {
                    int c = (Array.IndexOf(alfabet, symbol) +
                    Array.IndexOf(alfabet, keyword[keyword_index])) % N;

                    result += alfabet[c];

                    keyword_index++;

                    if (keyword_index == keyword.Length)
                        keyword_index = 0;
                }
            }
            return result;
        }
        public string Decrypt(string s)
        {
            txt = s.ToLower();
            keyword = keyword.ToLower();
            string result = "";
            int keyword_index = 0;
            foreach (char symbol in txt)
            {
                if (!alfabet.Contains(symbol))
                {
                    result += symbol;
                }
                else
                {
                    int p = (Array.IndexOf(alfabet, symbol) + N -
                    Array.IndexOf(alfabet, keyword[keyword_index])) % N;

                    result += alfabet[p];

                    keyword_index++;

                    if (keyword_index == keyword.Length)
                        keyword_index = 0;
                }
            }
            return result;
        }
    }
}
