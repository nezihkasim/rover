using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace project2_nezih
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;  // holds the number of rovers
            char direction_inp;  // to get the initial direction of the rover
              
            Console.WriteLine("Type the map size as two integers with a space between them (X,Y):"); // we're typing the map SIZE and lower-left corner is (0,0) 
            var plateauSize = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int[,] roverCoordinates = new int[plateauSize[0], plateauSize[1]];  // Represents the plateau. Used to store the rover locations.  (1st D: x coordinates, 2nd D: y coordinates)
            //var plateauSize = Convert.plateauSize.Select(t => Regex.Replace(t, @"\s+", "")).ToList();  // TRIED TO REMOVE WHITE SPACES WITH REGEX
            //Console.WriteLine("x: {0}  y: {1}", plateauSize[0], plateauSize[1]);     //  TEST LINE

            Console.WriteLine("\nPress 'Enter' to start:");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.WriteLine("\nType the initial location of the {0}th rover as two integers (X,Y) and direction (N,E,S,W):", k + 1);
                var initialLocation = Console.ReadLine().ToUpper().Trim().Split(' '); //  !!!!!  INPUT IS GıVEN WITH SPACES   !!!!  TRIED TO REMOVE THE WHITESPACES WITH REGEX, BUT FAILED :(
                direction_inp = char.ToUpper(char.Parse(initialLocation[2])); 

                Console.WriteLine("\nType the commands (L,R,M): ");
                string inputs = Console.ReadLine().ToUpper();   // reading orders from user and converting all of the characters to upper-case

                Rover rover = new Rover(k+1, int.Parse(initialLocation[0]), int.Parse(initialLocation[1]), inputs, direction_inp); // defining a new rover with ID, coordinates, orders, and direction

                rover.Action(plateauSize, inputs, roverCoordinates); // map size, orders, and rover locations are given to Action method
                if (rover.out_bound == 1) // checking the boundary flag
                {
                    continue;  // not to increment the paramater k and not to save the wrong coordinates
                }
                Console.WriteLine("\nThe last location of the {0}th rover after the move: ", k + 1);
                //Console.WriteLine($"{rover.location_x} {rover.location_y} {rover.direction}");
                rover.Info_rover(); // the method writing the ID, the coordinates, and the direction of the rover
                roverCoordinates[rover.location_x, rover.location_y] = 1;  // putting 1 where the rover stops to check later.
                k++;

                Console.WriteLine("Press 'ESC' button to quit: ");
            }
            

            Console.WriteLine("\n\n\n PProgram is closing...");  // why doesn't show the first 'P'?
            Thread.Sleep(3000);
            
        }
    }
}
