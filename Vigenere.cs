using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiffreDeVigenere
{
    public static class Vigenere
    {
        private static Dictionary<int, char> Alphabet = new Dictionary<int, char>()
        {
            { 0, 'A' }, { 1, 'B' }, { 2, 'C' }, { 3, 'D' }, { 4, 'E' }, { 5, 'F' },
            { 6, 'G' }, { 7, 'H' }, { 8, 'I' }, { 9, 'J' }, { 10, 'K' }, { 11, 'L' }, { 12, 'M' },
            { 13, 'N' }, { 14, 'O' }, { 15, 'P' }, { 16, 'Q' }, { 17, 'R' }, { 18, 'S' } , { 19, 'T' },
            { 20, 'U' }, { 21, 'V' }, { 22, 'W' }, { 23, 'X' }, { 24, 'Y' }, { 25, 'Z' }
        };
        public static IEnumerable<string> Decrypt(IEnumerable<string> encrypt, string key)
        {
            StringBuilder decrypt = new StringBuilder();
            for (int i = 0; i < key.Length; i++)
            {
                char element = encrypt.FirstOrDefault()[i];
                int code = (
                    Alphabet.FirstOrDefault(x => x.Value == element).Key 
                    + Alphabet.Count 
                    - Alphabet.FirstOrDefault(x => x.Value == key[i]).Key
                    ) % Alphabet.Count;
                char word;
                Alphabet.TryGetValue(code, out word);
                decrypt.Append(word);
            }
            yield return decrypt.ToString();
        }
        public static IEnumerable<string> Encrypt(IEnumerable<string> source, string key)
        {
            StringBuilder encrypt = new StringBuilder();
            for (int i = 0; i < key.Length; i++)
            {
                char element = source.FirstOrDefault()[i];
                int code = (
                    Alphabet.FirstOrDefault(x => x.Value == element).Key
                    + Alphabet.FirstOrDefault(x => x.Value == key[i]).Key
                    ) % Alphabet.Count;
                char word;
                Alphabet.TryGetValue(code, out word);
                encrypt.Append(word);
            }
            yield return encrypt.ToString();
        }
    }
}
