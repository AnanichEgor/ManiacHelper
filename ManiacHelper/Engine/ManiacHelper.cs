using System;
using System.Collections.Generic;
using System.Text;

namespace ManiacHelper.Engine
{
    class ManiacHelper
    {
        IDictionary<string, int> _resource;
        StringBuilder _stringAll;
        public ManiacHelper(IDictionary<string, int> resource, StringBuilder stringAll = null)
        {
            _resource = resource;
            _stringAll = stringAll;
        }

        private bool Checked(string[] arrayWords)
        {
            if (arrayWords?.Length > 0)
            {
                foreach (var word in arrayWords)
                {
                    if (_resource.TryGetValue(word, out int count))
                    {
                        if (count > 1)
                        {
                            count--;
                        }
                        else
                        {
                            _resource.Remove(word);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }


        public bool PhraseCheck(string phrase)
        {
            if (phrase?.Length > 0)
            {
                string[] arrayWords = Resources.GetWords(phrase);
                return Checked(arrayWords);
            }
            else
            {
                throw new ArgumentException("Input string is empty!");
            }
        }

        public bool PhraseCheck2(string phrase)
        {
            if (_stringAll != null)
            {
                string[] arrayWords = Resources.GetWords(phrase);
                foreach (string word in arrayWords)
                {
                    int i = _stringAll.ToString().IndexOf(word);
                    if (i > -1)
                    {
                        _stringAll.Remove(i, word.Length);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
