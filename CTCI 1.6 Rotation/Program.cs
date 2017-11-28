using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_1._6_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMsg(1, 6, "Rotation");

            int[,] array2D = new int[4, 4] {{00,01,02,03},{10,11,12,13},{20,21,22,23},{30,31,32,33}};

            int[,] array2D_6 = new int[6, 6] {{00,01,02,03,04,05},{10,11,12,13,14,15},{20,21,22,23,24,25},{30,31,32,33,34,35},{40,41,42,43,44,45},{50,51,52,53,54,55}};
            
            rotate90(array2D);

            rotate90(array2D_6);

            Console.ReadLine();
        }

        private static void PrintArray(int[,] array2D)
        {
            for (int y = array2D.GetLength(0) - 1; y >= 0; --y)
            {
                for (int x = 0; x < array2D.GetLength(0); ++x)
                {
                    if (array2D[x, y] < 10)
                        Console.Write("0");

                    Console.Write(array2D[x, y]);
                    Console.Write(", ");
                }
                Console.WriteLine();
            }
        }

        private static void rotate90(int[,] array2D)
        {
            Console.WriteLine("Original:");            
            PrintArray(array2D);

            int temp = 0;
            int X_currentposition = 0;
            int Y_currentposition = 0;
            int X_oneLayerBack = 0;
            int Y_oneLayerBack = 0;

            // add a layer for every odd number of elements. Ie: 1 element  = 1 layer
            //                                                   2 elements = 1 layer
            //                                                   3 elements = 2 layers
            //                                                   4 elements = 2 layers
            //                                                   5 elements = 3 layers etc
            for (int layer = 0; layer < (int)Math.Ceiling( array2D.GetLength(0) / 2.0); ++layer)
            {
                // index shrinks from both sides (!) as the layer moves inward
                for (int index = layer; index < (array2D.GetLength(0) - layer - 1); ++index)
                {
                    for (int side = 0; side < 4; ++side)
                    {
                        switch (side)
                        {
                            case 0:                            
                                X_currentposition = index;
                                Y_currentposition = layer;
                                X_oneLayerBack = array2D.GetLength(0) - 1 - layer;
                                Y_oneLayerBack = index;

                                temp = array2D[X_currentposition, Y_currentposition];
                                array2D[X_currentposition, Y_currentposition] = array2D[X_oneLayerBack, Y_oneLayerBack];
                                break;  

                            case 1:                            
                                X_currentposition = array2D.GetLength(0) - 1 - layer;
                                Y_currentposition = index;
                                X_oneLayerBack = array2D.GetLength(0) - 1 - index;
                                Y_oneLayerBack = array2D.GetLength(0) - 1 - layer;

                                // write one layer backwards
                                array2D[X_currentposition, Y_currentposition] = array2D[X_oneLayerBack, Y_oneLayerBack];
                                break;

                            case 2:                            
                                X_currentposition = array2D.GetLength(0) - 1 - index;
                                Y_currentposition = array2D.GetLength(0) - 1 - layer;
                                X_oneLayerBack = layer; 
                                Y_oneLayerBack = array2D.GetLength(0) - 1 - index;

                                // write one layer backwards
                                array2D[X_currentposition, Y_currentposition] = array2D[X_oneLayerBack, Y_oneLayerBack];
                                break;

                            case 3:
                            default:
                                X_currentposition = layer;
                                Y_currentposition = array2D.GetLength(0) - 1 - index;

                                // write one layer backwards
                                array2D[X_currentposition, Y_currentposition] = temp;
                                break;                                
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Rotated:");
            PrintArray(array2D);
            Console.WriteLine();
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }   
}
