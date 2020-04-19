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
|Flowchart                    |                                    |Flowchart                                          |
|Report                       |                                    |                                                   |


o	Indicação do repositório público Git utilizado. Esta indicação é opcional, pois podem preferir desenvolver o projeto num repositório privado.

## Arquitetura da solução

>	Descrição da solução, com breve explicação de como o programa foi organizado, indicação dos métodos/funções e enumerações criadas.
>	Um fluxograma mostrando a sequência do programa.

##Flowchart
![Flowchart](/Images/Flowchart.png)

## Referencies

UTF-8:
* It was discussed with a colleague, about the possibilitie of inserting diferent symbols on the code, so that we could draw the game board. The advice was for us to try UTF-8, that would allow us to work with diferent characters. Since we did not know exactly what it was about, we had to do some research to find out it was related to unicode. After some time we come across a question symilar to ours in stackoverflow, wihch we decide to try and were able to work around. 
** [stackoverflow](https://stackoverflow.com/questions/5750203/how-to-write-unicode-characters-to-the-console)
```csharp
   Console.OutputEncoding = System.Text.Encoding.UTF8
```

Piece movements:
* To better understand how to place the pieces on the board and how to show the possible moves, we whatched a tutorial video on how to make a chess board in c#, to get and idea on how we could aplie in our project.
** [C# Chess Board 03 next legal moves](https://www.youtube.com/watch?v=iV9hBTi-QB8&list=PLhPyEFL5u-i0YDRW6FLMd1PavZp9RcYdF&index=3)
** [C# Chess Board 06 place piece](https://www.youtube.com/watch?v=qV1ib7dfXvk&list=PLhPyEFL5u-i0YDRW6FLMd1PavZp9RcYdF&index=6)
