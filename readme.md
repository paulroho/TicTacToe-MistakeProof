> Refer to https://bitbucket.org/pkofler/tictactoe-mistakeproof-java for a **Java** version.

This example is inspired by ﻿http://blog.tmorris.net/posts/understanding-practical-api-design-static-typing-and-functional-programming/

## Constraints

So I set some rules, but without further explanation of why these rules existed:

* If you write a function, I must be able to call it with the same arguments and always get the same results, forever.
	* Pure
	* Easy to test
	* State has to pushed to the client
* If I, as a client of your API, call one of your functions, I should always get a sensible result. Not null or an exception or other backdoors that cause the death of millions of kittens worldwide.
	* How to deal with null input?
		* [NotNull] attribute?
		* Stronger language
		* Check precondition (guard clause)
	* Use maybe or optional
	* No exceptions
* If I call move on a tic-tac-toe board, but the game has finished, I should get a compile-time type-error. In other words, calling move on inappropriate game states (i.e. move doesn’t make sense) is disallowed by the types.
	* Return special board-types (sub types?)
	e.g.
	* If I call takeMoveBack on a tic-tac-toe board, but no moves have yet been made, I get a compile-time type-error.
	* If I call whoWonOrDraw on a tic-tac-toe board, but the game hasn’t yet finished, I get a compile-time type-error.
* I should be able to call various functions on a game board that is in any state of play e.g. isPositionOccupied works for in-play and completed games.
* It is not possible to play out of turn.

Further ideas
* Just allow moving to available fields


## Functional Requirements

* http://en.wikipedia.org/wiki/Tic-tac-toe
	* Board 3x3
	* X plays first
	* O plays second
	* Implement 2 Player Game
	* Determine Winner
* I can start a new game
* I should be able to call various functions on a game board that is in any state of play
	* IsPositionOccupied
	* HasEnded
* I can make a move
	* It is not possible to play out of turn.
* I can take back a move
* In case of a won game, I can ask who has won.

