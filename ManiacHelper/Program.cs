using System;

namespace ManiacHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var resource = new Resources(@"C:\Users\Yahor_Ananich\source\repos\ManiacHelper\ManiacHelper\Resources\GK.txt");
            var testPhrase = new Engine.ManiacHelper(resource.ArrayDictionary);
            Console.WriteLine(testPhrase.PhraseCheck("Национальный реестр правовых актов ребенока"));
            Console.ReadKey();
        }
    }
}
