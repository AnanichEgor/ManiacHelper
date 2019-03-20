using System;
using System.Collections.Generic;

namespace ManiacHelper.Engine
{
    class ManiacHelper
    {
        IDictionary<string, int> _resource;
        public ManiacHelper(IDictionary<string, int> resource)
        {
            _resource = resource;
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
    }
}
