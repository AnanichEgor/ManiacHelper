using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ManiacHelper
{
    class Resources
    {
        public Dictionary<string, IWordModel> ArrayDictionary { get; } = new Dictionary<string, IWordModel>();

        public Resources(string filePath)
        {
            ReadFile(filePath);
        }

        static public string[] GetWords(string line)
        {
            if (line != null)
            {
                string pattern = "[^A-Za-zА-Яа-я]+";
                return Regex.Split(line, pattern, RegexOptions.IgnorePatternWhitespace);
            }
            else
            {
                return null;
            }

        }

        private void AddWords(string[] arrayWords)
        {
            if (arrayWords?.Length > 0)
            {
                foreach (string word in arrayWords)
                {
                    IWordModel model;
                    if (ArrayDictionary.TryGetValue(word, out model))
                    {
                        model.count++;
                    }
                    else
                    {
                        var item = new WordModel { count = 1, word = word };
                        ArrayDictionary.Add(word, item);
                    }
                }
            }
        }

        private void ReadFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader textReader = new StreamReader(path))
                {
                    string strLine = "";
                    while (strLine != null)
                    {
                        strLine = textReader.ReadLine();
                        AddWords(GetWords(strLine));
                    }
                }
            }
        }
    }
}

