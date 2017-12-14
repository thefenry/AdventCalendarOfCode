using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventCalendarOfCode
{
    internal class Passphrases
    {
        internal static string GetTotalValidPassphrases()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ProblemsInputs\Passphrases1.txt");
            string[] passPhrasesRows = File.ReadAllLines(path);

            int numberValidPassphrases = 0;

            for (int i = 0; i < passPhrasesRows.Length; i++)
            {
                List<string> passPhrase = passPhrasesRows[i].Split().ToList();

                bool validValues = passPhrase.Distinct().Count() == passPhrase.Count();
                if (validValues)
                {
                    numberValidPassphrases = numberValidPassphrases + 1;
                }
            }


            return numberValidPassphrases.ToString();
        }

        internal static string GetTotalValidPassphrasesWithAnagrams()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ProblemsInputs\Passphrases1.txt");
            string[] passPhrasesRows = File.ReadAllLines(path);

            int numberValidPassphrases = 0;

            for (int i = 0; i < passPhrasesRows.Length; i++)
            {
                List<string> passPhrase = passPhrasesRows[i].Split().ToList();

                for (int j = 0; j < passPhrase.Count(); j++)
                {
                    passPhrase[j] = String.Concat(passPhrase[j].OrderBy(c => c));
                }

                bool validValues = passPhrase.Distinct().Count() == passPhrase.Count();
                if (validValues)
                {
                    numberValidPassphrases = numberValidPassphrases + 1;
                }
            }


            return numberValidPassphrases.ToString();
        }
    }
}