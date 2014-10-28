using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Flower.CS
{
    public class RC4
    {
        byte[] S = new byte[256];

        int x = 0;
        int y = 0;

        public RC4(byte[] key)
        {
            init(key);
        }

        // Key-Scheduling Algorithm 
        // Алгоритм ключевого расписания 
        private void init(byte[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 256;
                S.Swap(i, j);
            }
        }

        public byte[] Encode(byte[] dataB, int size)
        {
            byte[] data = dataB.Take(size).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (byte)(data[m] ^ keyItem());
            }

            return cipher;
        }
        public byte[] Decode(byte[] dataB, int size)
        {
            return Encode(dataB, size);
        }

        // Pseudo-Random Generation Algorithm 
        // Генератор псевдослучайной последовательности 
        private byte keyItem()
        {
            x = (x + 1) % 256;
            y = (y + S[x]) % 256;

            S.Swap(x, y);

            return S[(S[x] + S[y]) % 256];
        }
        public static string Encript_string(string to_cript, string s_key)
        {
            byte[] key = ASCIIEncoding.ASCII.GetBytes(s_key);
            RC4 encoder = new RC4(key);            
            byte[] byte_to_cript = ASCIIEncoding.ASCII.GetBytes(to_cript);
            byte[] cripted = encoder.Encode(byte_to_cript, byte_to_cript.Length);
            return ASCIIEncoding.ASCII.GetString(cripted); 
        }
        public static string Descript_string(string to_descript,string s_key)
        {
            byte[] key = ASCIIEncoding.ASCII.GetBytes(s_key);
            RC4 encoder = new RC4(key);
            byte[] byte_to_descript = ASCIIEncoding.ASCII.GetBytes(to_descript);
            byte[] descripted = encoder.Encode(byte_to_descript, byte_to_descript.Length);
            return ASCIIEncoding.ASCII.GetString(descripted); 
        }
        
    }

    static class SwapExt
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
   
}
