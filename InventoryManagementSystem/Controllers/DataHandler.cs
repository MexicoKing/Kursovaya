using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    class DataReader
    {
        /*static string[] InputWords(string inputFile)
        {
            StreamReader f = new StreamReader(inputFile);

            ICipher ciphRef;
            ACipher aCipher = new ACipher();
            ciphRef = aCipher;
            string s = f.ReadToEnd();
            string[] arrWords = s.Split("  ");
            for (int i = 0; i < arrWords.Length; i++)
            {
                arrWords[i] = ciphRef.Decode(arrWords[i]);
            }

            f.Close();

            return arrWords;
        }

        static void OutputWords(string fileName, string[] arrWords, string newS)
        {
            int n = arrWords.Length;

            StreamWriter f = new StreamWriter(fileName);

            ICipher ciphRef;
            ACipher aCipher = new ACipher();
            ciphRef = aCipher;

            for (int i = 0; i < n; i++)
            {
                f.Write(ciphRef.Encode(arrWords[i]) + "  ");
            }
            f.Write(ciphRef.Encode(newS));
            f.Close();
        }*/
    }
}
