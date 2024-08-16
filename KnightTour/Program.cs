using Springertour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Springertour
{
    internal class Program
    {
        
        static void ManuallInput() 
        {
            Console.ResetColor();
            
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"  |----|----|----|----|----|----|----|----|");
                Console.Write($"{8 - i} ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"|  0 ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  |----|----|----|----|----|----|----|----|");
            Console.WriteLine("  |----|----|----|----|----|----|----|----|");
            Console.WriteLine("  |  A |  B |  C |  D |  E |  F |  G |  H |");
            Console.Write("Starposition A-H:");

            char[] array = Console.ReadLine().ToCharArray();
            int y = array[0] - 65;



            Console.Write("Starposition 1-8:");
            int x = int.Parse(Console.ReadLine());
            x = Math.Abs(x-8);

            Console.Clear();




            Tour tour = new Tour(x, y);
            tour.StartTour();
            tour.Print();
        }

        static void RandomStart()
        {
            Random rnd = new Random();

            int i = 0;
            do {
                Tour t = new Tour(rnd.Next(0, 8), rnd.Next(0, 8));
                t.StartTour();
                t.Print();
                i++;
                if(i != 8)
                {
                    Console.ForegroundColor += 1;
                    Console.WriteLine("Press any key to generate the next interation");
                    Console.WriteLine("\n\n");
                    Console.ReadKey();
                }
            } while (i<8);


        }
        static void Main(string[] args)
        {


            //ManuallInput();
            RandomStart();
            Console.WriteLine("Press any key to quit");
            Console.ReadLine();

        }
    }
}
