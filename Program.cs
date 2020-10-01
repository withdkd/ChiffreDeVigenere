using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiffreDeVigenere
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter source string: ");
            string unencrypted = Console.ReadLine().ToUpper();
            Console.Write("Enter key: ");
            string key = Console.ReadLine().ToUpper();
            Prepare(unencrypted, ref key);           
            IEnumerable<string> encrypt = Vigenere.Encrypt(Preprocess(unencrypted), key);
            Console.WriteLine($"Results: {unencrypted} + {key} -> {encrypt.FirstOrDefault()}");

            Console.Write("Enter encrypt string: ");
            string encrypted = Console.ReadLine().ToUpper();
            Console.Write("Enter key: ");
            key = Console.ReadLine().ToUpper();
            Prepare(encrypted, ref key);
            IEnumerable<string> decrypt = Vigenere.Decrypt(Preprocess(encrypted), key);
            Console.WriteLine($"Results: {encrypted} + {key} -> {decrypt.FirstOrDefault()}");

            Console.ReadKey();
        }

        public static IEnumerable<string> Preprocess(string unencrypted)
        {
            yield return unencrypted;
        }
        private static void Prepare(string source, ref string key)
        {
            if (source.Length < key.Length)
            {
                key = key.Substring(0, source.Length);
            }
            if (source.Length > key.Length)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(key);
                int j = 0;
                while (source.Length != builder.Length)
                {
                    builder.Append(key[j % key.Length]);
                    j++;
                }
                key = builder.ToString();
            }
        }
    }
}
