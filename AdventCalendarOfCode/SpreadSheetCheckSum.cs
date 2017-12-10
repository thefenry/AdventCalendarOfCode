using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventCalendarOfCode
{
    public static class SpreadSheetCheckSum
    {
        public static string GetSpreadsheetChecksum(string input)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ProblemsInputs\SpreadSheetCheckSumDay2.txt");
            string[] spreadsheetRows = File.ReadAllLines(path);

            List<int> sumPerRow = new List<int>();

            for (int i = 0; i < spreadsheetRows.Length; i++)
            {
                int[] convertedItems = Array.ConvertAll<string, int>(spreadsheetRows[i].Replace('\t', ' ').Split(' '), int.Parse);

                int maxValue =0;
                int minValue = 0;
                for (int j = 0; j < convertedItems.Length; j++)
                {
                    if (j== 0)
                    {
                        maxValue = convertedItems[j];
                        minValue = convertedItems[j];

                    }

                    if (j > 0 && convertedItems[j] > maxValue)
                    {
                        maxValue = convertedItems[j];
                    }
                  
                    if (j > 0 && convertedItems[j] < minValue)
                    {
                        minValue = convertedItems[j];
                    }
                
                }

                sumPerRow.Add(maxValue - minValue);
            }
            
            return sumPerRow.Sum().ToString();
        }

        public static string GetSpreadsheetDivisibleChecksum(string input)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ProblemsInputs\SpreadSheetCheckSumDay2.txt");
            string[] spreadsheetRows = File.ReadAllLines(path);

            List<int> sumPerRow = new List<int>();

            for (int i = 0; i < spreadsheetRows.Length; i++)
            {
                int[] convertedItems = Array.ConvertAll<string, int>(spreadsheetRows[i].Replace('\t', ' ').Split(' '), int.Parse);

                for (int j = 0; j < convertedItems.Length; j++)
                {
                    for (int k = 0; k < convertedItems.Length; k++)
                    {
                        if (j != k && convertedItems[j] % convertedItems[k] == 0)
                        {
                            sumPerRow.Add(convertedItems[j] / convertedItems[k]);
                            //break;
                        }
                    }                  

                }
              
            }

            return sumPerRow.Sum().ToString();
        }
    }
}
