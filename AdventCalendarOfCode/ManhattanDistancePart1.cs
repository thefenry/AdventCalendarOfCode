using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventCalendarOfCode
{
    public static class ManhattanDistancePart1
    {
        public static string CalculateDistanceBasedOnNumber(int input)
        {
            double sqRoot = Math.Ceiling(Math.Sqrt(input));

            while (sqRoot % 2 == 0)
            {
                sqRoot = sqRoot + 1;
            }


            int matrixDimension = sqRoot % 1 == 0 ? (int)sqRoot : (int)Math.Floor(sqRoot + 2);

            int center = matrixDimension / 2;

            int[,] array = new int[matrixDimension, matrixDimension];

            int coordinateValue = 1;

            array[center, center] = coordinateValue;

            bool stopBuilding = false;

            int movementAmount = 1;

            int x = center, y = center;

            int[] matchingCoordinate = new int[] { center, center };

            Days direction = Days.Right;

            while (!stopBuilding && input > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < movementAmount; j++)
                    {
                        switch (direction)
                        {
                            case Days.Right:
                                array[x, ++y] = ++coordinateValue;
                                if (j == movementAmount - 1)
                                {
                                    direction = Days.Up;
                                }
                                break;
                            case Days.Up:
                                array[--x, y] = ++coordinateValue;
                                if (j == movementAmount - 1)
                                {
                                    direction = Days.Left;
                                }
                                break;
                            case Days.Left:
                                array[x, --y] = ++coordinateValue;
                                if (j == movementAmount - 1)
                                {
                                    direction = Days.Down;
                                }
                                break;
                            case Days.Down:
                                array[++x, y] = ++coordinateValue;
                                if (j == movementAmount - 1)
                                {
                                    direction = Days.Right;
                                }
                                break;
                        }

                        if (coordinateValue == input)
                        {
                            matchingCoordinate[0] = x;
                            matchingCoordinate[1] = y;
                        }

                        if (x == matrixDimension - 1 && y == matrixDimension - 1)
                        {
                            i = 2;
                            break;
                        }
                    }
                    if (i >= 1)
                    {
                        movementAmount++;
                    }
                }

                if (x == matrixDimension - 1 && y == matrixDimension - 1)
                {
                    stopBuilding = true;
                }
            }

            var numberOfSteps = Math.Abs(center - matchingCoordinate[0]) + Math.Abs(center - matchingCoordinate[1]);

            return numberOfSteps.ToString();
        }

        public static string CalculateDistanceOnAnAdditiveSpiral(int input)
        {
            double sqRoot = Math.Ceiling(Math.Sqrt(input));

            while (sqRoot % 2 == 0)
            {
                sqRoot = sqRoot + 1;
            }


            int matrixDimension = sqRoot % 1 == 0 ? (int)sqRoot : (int)Math.Floor(sqRoot + 2);

            int center = matrixDimension / 2;

            int[,] array = new int[matrixDimension, matrixDimension];

            int coordinateValue = 1;

            array[center, center] = coordinateValue;

            bool stopBuilding = false;

            int movementAmount = 1;

            int x = center, y = center;

            int[] matchingCoordinate = new int[] { center, center };

            Days direction = Days.Right;

            while (!stopBuilding && input > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < movementAmount; j++)
                    {
                        switch (direction)
                        {
                            case Days.Right:
                               coordinateValue = GetAdjancentValueSum(array, x, ++y);
                                array[x, y] = coordinateValue;
                                if (j == movementAmount - 1)
                                {
                                    direction = Days.Up;
                                }
                                break;
                            case Days.Up:
                                coordinateValue = GetAdjancentValueSum(array, --x, y);
                                array[x, y] = coordinateValue;
                                if (j == movementAmount - 1)
                                {
                                    direction = Days.Left;
                                }
                                break;
                            case Days.Left:
                                coordinateValue = GetAdjancentValueSum(array, x, --y);
                                array[x, y] = coordinateValue;
                                if (j == movementAmount - 1)
                                {
                                    direction = Days.Down;
                                }
                                break;
                            case Days.Down:
                                coordinateValue = GetAdjancentValueSum(array, ++x, y);
                                array[x, y] = coordinateValue;
                                if (j == movementAmount - 1)
                                {
                                    direction = Days.Right;
                                }
                                break;
                        }

                        if (coordinateValue > input)
                        {
                            i = 2;
                            break;
                        }                     
                    }
                    if (i >= 1)
                    {
                        movementAmount++;
                    }
                }

                if (coordinateValue > input)
                {
                    stopBuilding = true;
                }
            }

            return coordinateValue.ToString();          
        }

        private static int GetAdjancentValueSum(int[,] array, int row, int column)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            List<int> neighborValues = new List<int>();

            for (int j = row - 1; j <= row + 1; j++)
            {
                for (int i = column - 1; i <= column + 1; i++)
                {
                    if (i >= 0 && j >= 0 && i < columns && j < rows && !(j == row && i == column))
                    {
                        neighborValues.Add(array[j, i]);
                    }
                }
            }

            return neighborValues.Sum();
        }

        enum Days { Right, Up, Left, Down }
    }
}
