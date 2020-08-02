# ReadMe
 
## How To Use game-settings.json
 
game-settings.json is a json file that contains the setup configuration for the game.
 
Set the Size of the board using **Size**. For example a Size set to 5 will result in 25 board positions i.e. 5 * 5
 
Set the mine count using **MineCount**. The number of mines must be proportional to the size of the board. Too many mines or too few mines are not permitted. Mines are distributed randomly across the board but cannot be placed at the start or end positions.
 
Additionally the user can optionally provide a **StartPosition** and/or an **EndPosition** giving a **XCoordinate** and **YCoordinate** for each value. As seen in the sample _game-settings.json_ provided. If no **StartPosition** or **EndPosition** are given then the Start will default to (0, 0) and End will default to (Size - 1, Size - 1)
 
The coordinates provided must be valid as in they cannot be negative or cannot extend past the provided board size. For example, for a board size of 5 positions (-1, 3) and (1, 5) are _invalid_ while positions (1,1) and (4, 4) are _valid_. Additionally the start position cannot be the same as the end position. 
 
## How To Use moves.json
 
moves.json is a json file that contains the moves that will be performed by the turtle during the game. 
 
Moves are provided in an array of values as per the provided example _moves.json_ file.
 
Valid moves are **Left**, **L**, **Right**, **R**, **Up**, **U**, **Down**, **D** or any cacing variation of the same.
 
At least **10** moves must be provided in this file for **any** board size.
 
## Output
 
The game will output to standard out. The possible outputs are
 
**Board Configuration Invalid** - The _game-settings.json_ file is invalid
 
**Move Configuration Invalid** - The _moves.json_ file is invalid
 
**Hit a Mine at (X, Y)** - The game ended in failure by hitting a mine at the given position
 
**No Moves Remaining finished at (X, Y)** - The game ended in failure as the turtle ran out of moves before reaching the end
 
**Reached The End at (X, Y)** - The game ended in success by reaching the configured end point
 
 
 
 

