# TicTacToe MistakeProof in C#

This example is inspired by Tony Morris' post on [Understanding Practical API Design, Static Typing and Functional Programming](http://blog.tmorris.net/posts/understanding-practical-api-design-static-typing-and-functional-programming/).
It is a partly implemented API of the game of Tic-Tac-Toe. We were exploring options for creating a mistake-proof API. We focused on the design, much internal logic is missing.

## Functional Requirements

In the post Tony gives the assignment to write the API for the game of [Tic-Tac-Toe](http://en.wikipedia.org/wiki/Tic-tac-toe):

* The game:
    * There is a 3x3 board.
    * X plays first
    * O plays second
    * Implement a two player game.
    * Determine who is the winner.

* The API alloes to:
    * I can start a new game
    * I should be able to call various functions on a game board that is in any state of play, e.g. `IsPositionOccupied` or `HasEnded`.
    * I can make a move.
    * I can take back a move.
    * In case of a won game, I can ask who has won.

## Tony's Constraint to make the API Mistake Proof

So I set some rules, but without further explanation of why these rules existed:
* If you write a function, I must be able to call it with the same arguments and always get the same results, forever.
* If I, as a client of your API, call one of your functions, I should always get a sensible result. Not null or an exception or other backdoors that cause the death of millions of kittens worldwide.
* If I call move on a tic-tac-toe board, but the game has finished, I should get a compile-time type-error. In other words, calling move on inappropriate game states (i.e. move doesn't make sense) is disallowed by the types.
* If I call `takeMoveBack` on a tic-tac-toe board, but no moves have yet been made, I get a compile-time type-error.
* If I call `whoWonOrDraw` on a tic-tac-toe board, but the game hasn't yet finished, I get a compile-time type-error.
* I should be able to call various functions on a game board that is in any state of play e.g. `isPositionOccupied` works for in-play and completed games.
* It is not possible to play out of turn.

## Code

* This repository contains the C# (.NET Core) code.
* Refer to [Peter's Bitbucket for a Java version](https://bitbucket.org/pkofler/tictactoe-mistakeproof-java).

### License
[New BSD License](http://opensource.org/licenses/bsd-license.php), see `license.txt` in repository.
