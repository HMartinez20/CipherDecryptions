
using System;

namespace EncryptDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            //String plaintext = "This is a private encrypted message";
            String cCiphertext = "HDUILPGT HTRJGXIN XH WPGS";
            char[,] tCiphertext = { {'I','E','U','B','O','I','P','I'},
                                    {'N','S','C','L','F','S','O','B'},
                                    {'D','T','T','E','T','I','S','L'},
                                    {'E','R','A','S','W','M','S','E'} };
            String sCiphertext = "SZXPVIH ZIV GVMZXRLFH";
            String vCiphertext = "LLGLV BQ QQHVG GF JUTSBLY";

            // KEYS
            char[] subAlphabet = { 'Z', 'Y', 'X', 'W', 'V', 'U', 'T', 'S', 'R', 'Q', 'P', 'O', 'N', 'M', 'L', 'K', 'J', 'I', 'H', 'G', 'F', 'E', 'D', 'C', 'A', 'B' };
            String vKey = "SECURITY";
            String vAnswer = "THERE TX SYDTM PX QWBOZRH       ";

            static int charToIndex(char[] alpha, char c)
            {
                for (int x = 0; x < alpha.Length; x++)
                    if (Char.ToUpper(c) == alpha[x]) return x;
                return 99;
            }
            static char indexToChar(char[] alpha, int i)
            {
                if (i >= 0 && i <= 25) return alpha[i];
                else return ' ';
            }

            /** CAESAR CIPHER **/
            string caesarDecrypted = "";
            for (int i = 0; i < cCiphertext.Length; i++)
            {
                int index = charToIndex(alphabet, cCiphertext[i]);

                if (0 <= index && index <= 25)
                    if (index <= 15 - 1)
                        caesarDecrypted = string.Concat(caesarDecrypted, indexToChar(alphabet, 26 + ((index - 15) % 26)));
                    else
                        caesarDecrypted = string.Concat(caesarDecrypted, indexToChar(alphabet, (index - 15) % 26));
                else
                    caesarDecrypted = string.Concat(caesarDecrypted, ' ');
            }

            Console.WriteLine("Original Message:                {0}", cCiphertext);
            Console.WriteLine("Caesar Cipher, Decrypted:        {0}\n", caesarDecrypted);

            /** TRANSPOSITION CIPHER **/
            Console.Write("Transposition Cipher, Decrypted: ");
            for (int y = 0; y < 8; y++)
            {
                for(int x = 0; x < 4; x++)
                    Console.Write(tCiphertext[x,y]);
            }
            Console.WriteLine("\n");

            /** SUBSTITUTION CIPHER **/
            string subDecrypted = "";
            for (int i = 0; i < sCiphertext.Length; i++)
            {
                int index = charToIndex(subAlphabet, sCiphertext[i]);

                if (0 <= index && index <= 25)
                    subDecrypted = string.Concat(subDecrypted, indexToChar(alphabet, index));
                else
                    subDecrypted = string.Concat(subDecrypted, ' ');
            }
            Console.WriteLine("Original Message:                {0}", sCiphertext);
            Console.WriteLine("Substitution Cipher, Decrypted:  {0}\n", subDecrypted);

            /** VIGNERE CIPHER **/
            string vigDecrypted = "";
            int keyMarker = 0;
            for (int i = 0; i < vCiphertext.Length; i++)
            {
                int keyIndex = charToIndex(alphabet, vKey[keyMarker % vKey.Length]);
                int cipherIndex = charToIndex(alphabet, vCiphertext[i]);
                if (0 <= cipherIndex && cipherIndex <= 25)
                {
                    Console.WriteLine("Pairs: {0},{1} : {2},{3}",
                        vKey[keyMarker % vKey.Length], vCiphertext[i],
                        keyIndex, cipherIndex);
                    if (cipherIndex - keyIndex < 0)
                        vigDecrypted = string.Concat(vigDecrypted, indexToChar(alphabet, (cipherIndex - keyIndex) + 26));
                    else
                        vigDecrypted = string.Concat(vigDecrypted, indexToChar(alphabet, cipherIndex - keyIndex));
                    keyMarker++;
                }
                else
                    vigDecrypted = string.Concat(vigDecrypted, " ");
            }
            Console.WriteLine("Original Message:                {0}", vCiphertext);
            Console.WriteLine("Vignere Cipher, Decrypted:       {0}", vigDecrypted);
            Console.WriteLine("Vignere Decryption Answer?:      {0}", vAnswer);
        }
    }
}