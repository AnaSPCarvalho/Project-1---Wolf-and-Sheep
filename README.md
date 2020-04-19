# Project1-WolfandSheep

## Authors

* Afonso Teixeira (a21803282)
* Ana Carvalho (a21802128)
* Joana Silva (a21805651)

## Who did what
|        Ana Carvalho         |         Afonso Teixeira            |                  Joana Silva                      |
|-----------------------------|------------------------------------|---------------------------------------------------|
|Wolf and Sheep movement      |Board printing                      |Project start and wolf and sheep starting positions|
|Sheep movement correction    |Win conditions for wolf and sheep   |Wolf and Sheep turns, check for possible moves     |
|XML Documentation            |Instructions                        |Board modifications                                |
|Flowchart                    |Flowchart                           |Flowchart                                          |
|Report                       |Report                              |Report                                             |


# Used git repository
https://github.com/AnaSPCarvalho/Project-1---Wolf-and-Sheep

## Arquitetura da solução

The code starts by verifying if there is a winner. 
For that, it will first check if the piece Wolf is at the bottom of the board if the piece's y equals 7, it means it is at the end and in that case, it means the wolf wins. 
Secondly, it will check if the wolf is surrounded by a wall or a sheep. If that is the case and the wolf cannot make any other move than that means the sheep win.
In case there is no winner, then the code will proceed with the game and print the instructions, followed by the board impression.

After that, the Wolf piece and Sheep pieces are placed at their starting positions.
Being the wolf piece at the top of the board and the sheep pieces at the bottom of the board with a free house between them.

Then it's time to check which turn is it. 

In the sheep's turn, the player will be asked which sheep he wants to move from 1 to 4.  
In case the player inputs other numbers, the same will be warned and given the chance to make another input. 
There is also the chance for the player to chose another sheep aside from the previous if he inputs "q" or" Q".
After the player chooses one of the sheep pieces, then the possible moves will be displayed.

If it's the wolf's turn, the possible moves appear right at the moment.
The player will then be asked to chose a move, so that the piece can be moved to another position.

If the input is denied there might be some reasons why:
* starting with the input not having two arguments;
* it can also be due to the input not be an integer (int);
* because there might be a wall, an enemy or a white house(non-playable house).
In all of the situations, the player will be warned about it until he makes a valid move.
When the player inputs a valid move, it will then print the updated board with the chosen move.

After that it loops, if it's the first time, it sets the initial positions of the pieces, after that it just verifies their positions.



## Flowchart
![Flowchart](/Images/Flowchart.png)

## Referencies

UTF-8:
* It was discussed with a colleague, about the possibilitie of inserting diferent symbols on the code, so that we could draw the game board. The advice was for us to try UTF-8, that would allow us to work with diferent characters. Since we did not know exactly what it was about, we had to do some research to find out it was related to unicode. After some time we come across a question symilar to ours in stackoverflow, wihch we decide to try and were able to work around. 
	* [stackoverflow](https://stackoverflow.com/questions/5750203/how-to-write-unicode-characters-to-the-console)
```csharp
   Console.OutputEncoding = System.Text.Encoding.UTF8
```