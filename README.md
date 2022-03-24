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

* __Game__
* __Requirements__
* __Player__
* __IBoard__

These classes should inherit to concrete classes to be used.

## Singleton pattern

Singleton pattern enables a class to have only one instance withing the progeam

Singleton pattern was applies to following classes:

* __ConnectFourReq__, a concrete subclass of __Requirements__ 
  * It was more efficient to create only one instance since it had to be connected with the class __Computer__ as its methods __MakeMove()__ returns __CalculateMoves()__ of __Requirements__
* __History__

- Command pattern

