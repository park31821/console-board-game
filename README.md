# Console Board Game

A console board game (Connect Four) using C# was implemented to applying the concept of object-oriented programming and design principles.

# Implementation

  1. Two different modes of play (Player vs Player or Computer vs Player)
  2. Checking the validity of moves for human players.
  3. Two different difficulties (Easy and Hard), where easy mode randomly selects a legal move and hard mode select the best move at current state without       considering future consequences
  4. Saving game at any position and loading the game
  5. Undo moves and redo if needed during the game, which is also available to the saved game
  6. Help system that assists users with the rules by opening an online resource during the game

# Class diagram

![스크린샷 2022-03-24 오후 3 07 12](https://user-images.githubusercontent.com/74476122/159846224-94eb3cbd-fc64-4d50-8bf1-453f3979f856.png)

# Design principles and patterns

Three design patterns were implemented:

## Template method

The aim of the project was the provide a reuseable framework for different 2-player board games, hence most classes should be reusable when a different game is made. The main game of this project is Connect Four, but there is another game option of Checkers, which was not implemented in this project. 

Template method applies to following classes:

* ___Game___
* ___Requirements___
* ___Player___
* ___IBoard___

These classes should inherit to concrete classes to be used

## Singleton pattern

Singleton pattern enables a class to have only one instance withing the program

Singleton pattern was applies to following classes:

* ___ConnectFourReq___, a concrete subclass of ___Requirements___ 
  * Instead of creating a new instance in class ___Computer___, it was more efficient to create only one instance and connecting it with the class ___Computer___ as its methods ___MakeMove()___ returns ___CalculateMoves()___ of ___Requirements___
  
* ___History___
  * Contains funcionalities of saving and loading the game, and undoing and restoring moves during the gameplay
  * ___History___ should be sharing one file system, creating insatnce only on the first use to prevent save files or saved moves being overriden or duplicate

## Command pattern

Following methods of ___History___ used the command pattern:

* ___UndoMove()___
* ___RedoMove()___
* ___SaveGame()___
* ___LoadGame()___

These methods could be used in the client through ___Invoker___ due to command pattern. In order to use a command pattern, an interface ___ICommand___ was created, which contained methods ___Execute()___ and ___Undo()___, and different command classes (___LoadCommand, SaveCommand and UndoCommand___) were created using an inheritance from __ICommand__. These command classes were implemented by storing in class __History__ based on its function, and these classes were implemented to class ___Invoker___ to be called from the client. Therefore, it is possible to encapsulate all the information needed for execution, such as method patterns and the name of the method.



