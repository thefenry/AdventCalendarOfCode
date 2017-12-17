using System;

namespace AdventCalendarOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {

                //Console.WriteLine(InverseCaptcha.CheckSum(input));
                //Console.WriteLine(InverseCaptchaPart2.CheckSum(input));
                //Console.WriteLine(SpreadSheetCheckSum.GetSpreadsheetChecksum(input));
                //Console.WriteLine(SpreadSheetCheckSum.GetSpreadsheetDivisibleChecksum(input));
                //Console.WriteLine(ManhattanDistancePart1.CalculateDistanceBasedOnNumber(Convert.ToInt32(input)));
                //Console.WriteLine(ManhattanDistancePart1.CalculateDistanceOnAnAdditiveSpiral(Convert.ToInt32(input)));
                //Console.WriteLine(Passphrases.GetTotalValidPassphrases());
                //Console.WriteLine(Passphrases.GetTotalValidPassphrasesWithAnagrams());
                //Console.WriteLine(MazeOfTrampolines.GetNumberOfStepsToExitMaze());
                Console.WriteLine(MazeOfTrampolines.GetNumberOfStepsToExitMazeDecreasingOn3orMore());



                input = Console.ReadLine();
            }

        }
    }
}
