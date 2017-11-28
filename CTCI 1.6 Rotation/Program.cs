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

            int[,] array2D = new int[4, 4] { {1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,16} };

            Console.WriteLine("Original:");
            Console.WriteLine();
            PrintArray(array2D);

            rotate90(array2D);            

            Console.ReadLine();
        }

        private static void PrintArray(int[,] array2D)
        {
            for (int x = 0; x < array2D.GetLength(0); ++x)
            {
                for (int y = 0; y < array2D.GetLength(0); ++y)
                {
                    if (array2D[x, y] < 10)
                        Console.Write(" ");

                    Console.Write(array2D[x, y]);
                    Console.Write(", ");
                }
                Console.WriteLine();
            }
        }

        private static void rotate90(int[,] array2D)
        {
            int X_currentposition = 0;
            int Y_currentposition = 0;
            int X_oneLayerBack = 0;
            int Y_oneLayerBack = 0;

            for (int layer = 0; layer < array2D.GetLength(0) / 2; ++layer)
            {
                for (int index = layer; index < (array2D.GetLength(0) - layer); ++index)
                {
                    for (int side = 0; side < 4; ++side)
                    {
                        switch (side)
                        {
                            case 0:                            
                                X_currentposition = index;
                                Y_currentposition = layer;
                                X_oneLayerBack = array2D.GetLength(0) - 1 - index;
                                Y_oneLayerBack = array2D.GetLength(0) - 1 - layer;

                                // write one layer backwards
                                array2D[X_oneLayerBack, Y_oneLayerBack] = array2D[X_currentposition, Y_currentposition];
                                break;

                            case 1:                            
                                X_currentposition = array2D.GetLength(0) - 1 - layer;
                                Y_currentposition = index;
                                X_oneLayerBack = index;
                                Y_oneLayerBack = layer;

                                // write one layer backwards
                                array2D[X_oneLayerBack, Y_oneLayerBack] = array2D[X_currentposition, Y_currentposition];
                                break;

                            case 2:                            
                                X_currentposition = layer;
                                Y_currentposition = array2D.GetLength(0) - 1 - index;
                                X_oneLayerBack = array2D.GetLength(0) - 1 - layer;
                                Y_oneLayerBack = index;

                                // write one layer backwards
                                array2D[X_oneLayerBack, Y_oneLayerBack] = array2D[X_currentposition, Y_currentposition];
                                break;

                            case 3:                            
                                X_currentposition = array2D.GetLength(0) - 1 - index;
                                Y_currentposition = array2D.GetLength(0) - 1 - layer;
                                X_oneLayerBack = layer;
                                Y_oneLayerBack = array2D.GetLength(0) - 1 - index;

                                // write one layer backwards
                                array2D[X_oneLayerBack, Y_oneLayerBack] = array2D[X_currentposition, Y_currentposition];
                                break;

                            default:
                                throw new InvalidOperationException("This method can only handle 2-dimensional arrays.");
                                break;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Rotated:");
            PrintArray(array2D);
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }   
}
