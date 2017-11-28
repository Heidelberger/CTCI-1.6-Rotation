using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            int[,] array2D_4 = new int[4, 4] {{00,01,02,03},{10,11,12,13},{20,21,22,23},{30,31,32,33}};

            int[,] array2D_6 = new int[6, 6] {{00,01,02,03,04,05},{10,11,12,13,14,15},{20,21,22,23,24,25},{30,31,32,33,34,35},{40,41,42,43,44,45},{50,51,52,53,54,55}};

            Console.WriteLine("Original:");
            PrintArray(array2D_4);

            rotate90_CTCI(array2D_4);

            rotate90(array2D_4);

            Console.WriteLine("Original:");
            PrintArray(array2D_6);

            rotate90_CTCI(array2D_6);

            rotate90(array2D_6);

            Console.ReadLine();
        }

        private static void rotate90(int[,] array2D)
        {
            Stopwatch sw = Stopwatch.StartNew();

            int temp = 0;            

            int n = array2D.GetLength(0);

            // add a layer for every odd number of elements. Ie: 1 element  = 1 layer
            //                                                   2 elements = 1 layer
            //                                                   3 elements = 2 layers
            //                                                   4 elements = 2 layers
            //                                                   5 elements = 3 layers etc
            for (int layer = 0; layer < (int)Math.Ceiling( n / 2.0); ++layer)
            {
                // index shrinks from both sides (!) as the layer moves inward
                for (int index = layer; index < (n - layer - 1); ++index)
                {
                    // Side 0
                    // X_currentposition = index;
                    // Y_currentposition = layer;
                    // X_oneLayerBack = n - 1 - layer;
                    // Y_oneLayerBack = index;
                    temp = array2D[index, layer];
                    array2D[index, layer] = array2D[n - 1 - layer, index];

                    // Side 1
                    // X_currentposition = n - 1 - layer;
                    // Y_currentposition = index;
                    // X_oneLayerBack = n - 1 - index;
                    // Y_oneLayerBack = n - 1 - layer;                    
                    array2D[n - 1 - layer, index] = array2D[n - 1 - index, n - 1 - layer];

                    // Side 2
                    // X_currentposition = n - 1 - index;
                    // Y_currentposition = n - 1 - layer;
                    // X_oneLayerBack = layer; 
                    // Y_oneLayerBack = n - 1 - index;                    
                    array2D[n - 1 - index, n - 1 - layer] = array2D[layer, n - 1 - index];

                    // Side 3
                    // X_currentposition = layer;
                    // Y_currentposition = n - 1 - index;
                    array2D[layer, n - 1 - index] = temp;
                }
            }        

            sw.Stop();
            
            Console.WriteLine("Rotated (my solution): " + sw.ElapsedTicks + " ticks");
            PrintArray(array2D);
        }

        /////////////////////////////////////////////////////////////
        //        
        // Below is the book's solution.
        //
        // Complexity: O(N^2)
        //             The algorithm must touch all N^2 elements, so it's the best we can do
        //
        private static void rotate90_CTCI(int[,] array2D)
        {
            Stopwatch sw = Stopwatch.StartNew();

            int n = array2D.GetLength(0);

            for (int layer = 0; layer < (int)Math.Ceiling(n / 2.0); ++layer)            
                {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; ++i)
                {
                    int offset = i - first;
                    
                    // save top
                    int top = array2D[first, i];

                    // left -> top
                    array2D[first, i] = array2D[last - offset, first];

                    // bottom -> left
                    array2D[last - offset, first] = array2D[last, last - offset];

                    // right -> bottom
                    array2D[last, last - offset] = array2D[i, last];

                    // top -> right
                    array2D[i, last] = top;
                }
            }

            sw.Stop();

            Console.WriteLine("Rotated (book solution): " + sw.ElapsedTicks + " ticks");
            PrintArray(array2D);
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
