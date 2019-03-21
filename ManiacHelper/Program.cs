using System;

namespace ManiacHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var resource = new Resources(@"..\..\..\Resources\GK.txt");
            var testPhrase = new Engine.ManiacHelper(resource.ArrayDictionary);
            Console.WriteLine(testPhrase.PhraseCheck("Национальный реестр правовых актов"));

            testPhrase = new Engine.ManiacHelper(resource.ArrayDictionary, resource.StringAllText);
            Console.WriteLine(testPhrase.PhraseCheck2("Национальный реестр правовых актов"));

            testPhrase = new Engine.ManiacHelper(resource.ArrayDictionary, resource.StringAllText);
            Console.WriteLine(testPhrase.PhraseCheck2("Национальный реестр правовых актов test"));

            Console.ReadKey();
        }
    }
}
