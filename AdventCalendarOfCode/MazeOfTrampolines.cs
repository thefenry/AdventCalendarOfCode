using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventCalendarOfCode
{
    internal class MazeOfTrampolines
    {
        private static int _numberOfMoves;
        private static int _newPosition = 0;
        private static int _moveLocation;

        public static string GetNumberOfStepsToExitMaze()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ProblemsInputs\MazeOfTrampolines.txt");
            List<int> mazeInstructions = File.ReadLines(path).Select(x => int.Parse(x)).ToList();

            _moveLocation = mazeInstructions.First();
            do
            {
                MoveInMaze(_newPosition, mazeInstructions);
                _numberOfMoves = _numberOfMoves + 1;


            } while (_newPosition < mazeInstructions.Count);


            return _numberOfMoves.ToString();
        }

        public static string GetNumberOfStepsToExitMazeDecreasingOn3orMore()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ProblemsInputs\MazeOfTrampolines.txt");
            List<int> mazeInstructions = File.ReadLines(path).Select(x => int.Parse(x)).ToList();

            _moveLocation = mazeInstructions.First();
            do
            {
                MoveInMaze(_newPosition, mazeInstructions);
                _numberOfMoves = _numberOfMoves + 1;


            } while (_newPosition < mazeInstructions.Count);


            return _numberOfMoves.ToString();
        }

        private static void MoveInMaze(int currentPosition, List<int> mazeInstructions)
        {

            _moveLocation = mazeInstructions[_newPosition];

            _newPosition = currentPosition + _moveLocation;

            int positionValue = mazeInstructions[currentPosition];
            if (positionValue > 2)
            {
                mazeInstructions[currentPosition] = mazeInstructions[currentPosition] - 1;
            }
            else
            {
                mazeInstructions[currentPosition] = mazeInstructions[currentPosition] + 1;
            }


        }
    }
}
