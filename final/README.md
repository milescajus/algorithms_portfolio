## Final: Ultimate Tic-Tac-Toe

<img src="https://user-images.githubusercontent.com/80205080/146646153-b52d8ba0-afd9-4948-ada9-cf30f476c834.mp4" alt="demo" width="400"/>

### How To Run
```console
$ python3 ttt.py
```

### Progress
- successfully implemented multiplayer U3T with improved terminal interface, complete with proper win-checking and playfield selection
- implemented better singleplayer opponent, able to win subgames and lookahead when choosing a playfield itself
- switched to numpad-layout input

### Next Steps
- further improve singleplayer opponent by avoiding sending the player to advantageous positions

### Concept

https://en.wikipedia.org/wiki/Ultimate_tic-tac-toe

*Language:* Python3

*Goals:*
- Create playable U3T field
	+ Tile placement
	+ Local win-checking
	+ Global win-checking
- Create a reasonable AI opponent
	+ Naïve solution
	+ Minimax
	+ Monte Carlo
- If time allows, create visual interface
	+ Python: Tkinter
	+ Worst case: CLI but with pretty colors

*Constraints:*
- Time (4 week project: 2 for game + 2 for AI)
- Learning (Minimax, Monte Carlo Tree-Search Algorithm)
- Priority given to functional game over functional AI


This final project will be an attempt to create at least a functional/playable implementation of Ultimate Tic-Tac-Toe, which is a variation on the traditional game where each field is a subgame, and moves played within those games determine the next field where a move can be made. The game is significantly more complex than the original, for which an ideal opponent can easily be coded, and requires a more complex algorithmic approach to build a computer opponent. This would be the second and more impressive goal: to learn how to do this and successfully implement either a minimax or Monte Carlo-based AI opponent.

For this project I intend to use Python, as it is a highly flexible language that I have worked with for many years and allows for fast prototyping due to the flexible syntax. My primary constraints are the time needed for the implementation, for which I am giving myself 2 weeks for the game itself and a further 2 for the AI, as well as the learning requirements for how to implement the game-solving algorithms. I am giving priority to having a functional game field that can be played by humans over successfully creating a computer opponent, though I would love to manage both.

### References

https://en.wikipedia.org/wiki/Ultimate_tic-tac-toe
https://web.archive.org/web/20210729033030/https://www.cs.huji.ac.il/~ai/projects/2013/UlitmateTic-Tac-Toe/files/report.pdf
http://blog.theofekfoundation.org/artificial-intelligence/2016/06/27/what-is-the-monte-carlo-tree-search/
