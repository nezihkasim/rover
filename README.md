# Mars Rover Problem

A program that handles the deployment of rovers and their movement commands. This program have limitations on whether the rovers went off bounds or collided with each other.

That is, the program detects when a movement command will result in

- The rover to go off the bounds of the plateau
- The rover to collide with an already existing rover

And if one of these is the case, the program tells the user that the command is invalid, and asks the user for the input again.

## Tests

### Out of bounds:

#### Input:
```
5 5
1 3 N
MMM
```

#### Output:
```
Out of bounds at (1, 4). Please try a different command.
```

### Rover collision:

#### Input:
```
5 5
1 2 N
LM
0 3 E
RMM
```

#### Output:
```
There is already a rover at (0, 2). Please try a different command.
```
