using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Springertour.Model
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
    public class Tour
    {

         List<Position> tour = new List<Position>();

        int[,] fieldsArray = new int[8, 8];

        int counter = 0;

        public Tour(int x, int y)
        {
            AddField(x, y);
            FirstStepIssue(x,y);
        }
        public void StartTour()
        {
            while (counter < 64) 
            {
                int zahl = 9;
                foreach (Position p in tour) 
                {
                    int temp = PossibleMovesFromTheNextPosition(p);
                    if (temp < zahl)
                    {
                        zahl = temp;
                    }
                }
                foreach (Position p in tour)
                {
                    int temp = PossibleMovesFromTheNextPosition(p);
                    if (temp == zahl)
                    {
                        AddField(p.X, p.Y);
                        break;
                    }
                }

                if(tour.Count == 0)
                {
                    break;
                }

            }
        }
        public void PrintList()
        {
            foreach (Position pos in tour)
            {
                Console.WriteLine($"{pos.X} {pos.Y}");
            } 
        }
        public void AddField(int x, int y)
        {
           
            counter++;
            fieldsArray[x, y] = counter;
            tour = new List<Position>();
            ListOfPossibleMoves(x, y);
        }
        public void FirstStepIssue(int x, int y)
        {
            if(x == 0 && y == 2)
            {
                AddField(x+2, y+1);
            }
        }

        public int GetCounter()
        {
            return counter;
        }

        public int[,] GetFields()
        {
            return fieldsArray;
        }
        public int PossibleMovesFromTheNextPosition(Position position)
        {
            int x = position.X;
            int y = position.Y;
            int possibleMoves = 0;
            if (x + 2 < 8 && y + 1 < 8)
            {
                if (fieldsArray[x + 2, y + 1] == 0)
                {
                    possibleMoves++;
                }

            }
            if (x + 2 < 8 && y - 1 >= 0)
            {
                if (fieldsArray[x + 2, y - 1] == 0)
                {
                    possibleMoves++;
                }

            }
            if (x + 1 < 8 && y + 2 < 8)
            {
                if (fieldsArray[x + 1, y + 2] == 0)
                {
                    possibleMoves++;
                }
            }
            if (x + 1 < 8 && y - 2 >= 0)
            {
                if (fieldsArray[x + 1, y - 2] == 0)
                {
                    possibleMoves++;
                }
            }

            if (x - 2 >= 0 && y + 1 < 8)
            {
                if (fieldsArray[x - 2, y + 1] == 0)
                {
                    possibleMoves++;
                }
            }
            if (x - 2 >= 0 && y - 1 >= 0)
            {
                if (fieldsArray[x - 2, y - 1] == 0)
                {
                    possibleMoves++;
                }

            }
            if (x - 1 >= 0 && y + 2 < 8)
            {
                if (fieldsArray[x - 1, y + 2] == 0)
                {
                    possibleMoves++;
                }

            }
            if (x - 1 >= 0 && y - 2 >= 0)
            {
                if (fieldsArray[x - 1, y - 2] == 0)
                {
                    possibleMoves++;
                }
            }

            return possibleMoves;
        }
        public void ListOfPossibleMoves(int x, int y) 
        {

            if (x + 2 < 8 && y + 1 < 8)
            {
                if (fieldsArray[x + 2, y + 1] == 0)
                {
                    tour.Add(new Position(x + 2, y + 1));
                }

            }
            if (x + 2 < 8 && y - 1 >= 0)
            {
                if (fieldsArray[x + 2, y - 1] == 0)
                {
                    tour.Add(new Position(x + 2, y - 1));
                }
                
            }
            if (x + 1 < 8 && y + 2 < 8)
            {
                if (fieldsArray[x + 1, y + 2] == 0)
                {
                    tour.Add(new Position(x + 1, y + 2));
                }
            }
            if (x + 1 < 8 && y - 2 >= 0)
            {
                if (fieldsArray[x + 1, y - 2] == 0)
                {
                    tour.Add(new Position(x + 1, y - 2));

                }
            }

            if (x - 2 >= 0 && y + 1 < 8)
            {
                if (fieldsArray[x - 2, y + 1] == 0)
                {
                    tour.Add(new Position(x - 2, y + 1));

                }
            }
            if (x - 2 >= 0 && y - 1 >= 0)
            {
                if (fieldsArray[x - 2, y - 1] == 0)
                {
                    tour.Add(new Position(x - 2, y - 1));
                }

            }
            if (x - 1 >= 0 && y + 2 < 8)
            {
                if (fieldsArray[x - 1, y + 2] == 0)
                {
                    tour.Add(new Position(x - 1, y + 2));
                }

            }
            if (x - 1 >= 0 && y - 2 >= 0)
            {
                if (fieldsArray[x - 1, y - 2] == 0)
                {
                    tour.Add(new Position(x - 1, y - 2));
                }
            }


        }

        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < fieldsArray.GetLength(0); i++)
            {

                Console.WriteLine($"  |----|----|----|----|----|----|----|----|");
                Console.Write($"{8 - i} ");
                for (int j = 0; j < fieldsArray.GetLength(1); j++)
                {
                    Console.Write($"| {fieldsArray[i, j],2} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  |----|----|----|----|----|----|----|----|");
            Console.WriteLine("  |----|----|----|----|----|----|----|----|");
            Console.WriteLine("  |  A |  B |  C |  D |  E |  F |  G |  H |");

        }


    }
}
