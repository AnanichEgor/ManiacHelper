using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ManiacHelper
{
    class Resources
    {
        private IDictionary<string, int> _arrayDictionary = new Dictionary<string, int>();
        private StringBuilder _stringAllText = new StringBuilder();
        public IDictionary<string, int> ArrayDictionary { get => _arrayDictionary; }
        public StringBuilder StringAllText { get => _stringAllText; }
        static readonly string pattern = "[^A-Za-zА-Яа-я]+";

        public Resources(string filePath)
        {
            ReadFile(filePath, true);
        }

        static public string[] GetWords(string line)
        {
            if (line != null)
            {
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
                    if (_arrayDictionary.TryGetValue(word, out int count))
                    {
                        count++;
                    }
                    else
                    {
                        _arrayDictionary.Add(word, 1);
                    }
                }
            }
        }

        private void AddWords(IDictionary<string, int> dictionaryWords)
        {
            if (dictionaryWords?.Count > 0)
            {
                _arrayDictionary = dictionaryWords;
            }
        }

        private void ReadFile(string path, bool useLINQ = false)
        {
            if (File.Exists(path))
            {
                using (StreamReader textReader = new StreamReader(path))
                {
                    string strLine = "";
                    if (useLINQ)
                    {
                        strLine = textReader.ReadToEnd();
                        _stringAllText.Append(strLine);
                        var arrayWors = Regex.Split(strLine, pattern)
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrEmpty(x))
                        .GroupBy(x => x)
                        .Select(g => new { key = g.Key, count = g.Count() })
                        .ToDictionary(pair => pair.key, pair => pair.count);
                        AddWords(arrayWors);
                    }
                    else
                    {
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
}

