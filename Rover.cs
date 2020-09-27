using System;
using System.Collections.Generic;
using System.Text;

namespace project2_nezih
{
    class Rover
    {
        public int id { get; set; }
        public int location_x { get; set; }
        public int location_y { get; set; }
        public string orders { get; set; }
        //public string [] direction = { "W", "N", "E", "S" };  // 0=West  1=North   2=East   3=South
        public char direction { get; set; }  // 0=West  1=North   2=East   3=South
        public int out_bound { get; set; }   // flag to check boundary conditions

        public Rover(int _id, int _location_x, int _location_y, string _orders, char _direction)
        {
            this.id = _id;
            this.location_x = _location_x;
            this.location_y = _location_y;
            this.orders = _orders;
            this.direction = _direction;
        }

        public void Info_rover()
        {
            Console.WriteLine($"Rover id: {this.id}   (X,Y) = ({this.location_x}, {this.location_y}),   Direction: {this.direction}\n");
        }


        public void Action(List<int> plateauSize, string inputs, int[,] roverLocations)
        {
            int old_location_x;  // to reassign the older values of the rover when it faces with an error
            int old_location_y;
            char old_direction;

            old_location_x = this.location_x;
            old_location_y = this.location_y;
            old_direction = this.direction;

            int i = 0;           

            while (i < inputs.Length)    // processes for each order character
            {
                switch (inputs[i])
                {
                    case 'M':
                        if ((this.direction == 'N' && this.location_y + 1 < plateauSize[1]) || (this.direction == 'E' && this.location_x + 1 < plateauSize[0]) || (this.direction == 'S' && this.location_y - 1 >= 0) || (this.direction == 'W' && this.location_x - 1 >= 0))  // boundary check line
                        {
                            if (this.direction == 'N') { this.location_y += 1; }        // when boundary conditions meet, the rover moves
                            else if (this.direction == 'E') { this.location_x += 1; } 
                            else if (this.direction == 'S') { this.location_y -= 1; } 
                            else if (this.direction == 'W') { this.location_x -= 1; }

                            if (roverLocations[this.location_x, this.location_y] == 1)  // when the rover faces with another rover, it gives collision error, and gets back to the initial coordinates
                            {
                                Console.WriteLine($"\nCollision with another rover at ({this.location_x} , {this.location_y}). Please try a different command.\n");
                                this.location_x = old_location_x;
                                this.location_y = old_location_y;
                                this.direction = old_direction;
                                out_bound = 1;  // boundary flag is used to notify the error
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\nOut of bounds at ({this.location_x} , {this.location_y}). Please try a different command.\n");
                            this.location_x = old_location_x;
                            this.location_y = old_location_y;
                            this.direction = old_direction;
                            out_bound = 1;
                            break;
                        }

                        if (roverLocations[this.location_x, this.location_y] == 1)  // when the rover faces with another rover, it gives collision error, and gets back to the initial coordinates
                        {
                            Console.WriteLine($"\nCollision with another rover at ({this.location_x} , {this.location_y}). Please try a different command.\n");
                            this.location_x = old_location_x;
                            this.location_y = old_location_y;
                            this.direction = old_direction;
                            out_bound = 1;  // boundary flag is used to notify the error
                            break;
                        }
                                                
                        break;

                    case 'L':
                        if (this.direction == 'N') { this.direction = 'W'; }
                        else if (this.direction == 'E') { this.direction = 'N'; }
                        else if (this.direction == 'S') { this.direction = 'E'; }
                        else if (this.direction == 'W') { this.direction = 'S'; }
                        break;

                    case 'R':
                        if (this.direction == 'N') { this.direction = 'E'; }
                        else if (this.direction == 'E') { this.direction = 'S'; }
                        else if (this.direction == 'S') { this.direction = 'W'; }
                        else if (this.direction == 'W') { this.direction = 'N'; }
                        break;

                    default:
                        Console.WriteLine("\nInvalid Input");
                        break;
                }
                i++;
            }
        }
    }
}
