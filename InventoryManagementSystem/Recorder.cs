using System.IO;

namespace InventoryManagementSystem
{
    public class Recorder
    {
        public static string[] ReadFile(string inputFile)
        {
            StreamReader f = new StreamReader(inputFile);

            string s = f.ReadToEnd();
            string[] arrWords = s.Split("///");
            f.Close();

            return arrWords;
        }

        public static void WriteToFile(string fileName, string[] arrWords, string newString)
        {
            int n = arrWords.Length;

            StreamWriter f = new StreamWriter(fileName);

            for (int i = 0; i < n; i++)
            {
                if (arrWords[i] != "")
                {
                    f.Write(arrWords[i]);
                }
            }
            f.Write(newString);

            f.Close();
        }
    }
}
