from random import randrange
from random import shuffle


class Game:
    """ NOTE: INPUT IS NOW 1-9 WHICH GETS CORRECTED TO INDEX FORM 0-8 """

    def __init__(self, multiplayer=True):
        self.grid = [" " for i in range(9)]
        self.player = ["\033[91mO\033[0m", "\033[92mX\033[0m"]
        self.multiplayer = multiplayer

    def make_move(self, player):
        move = -1
        if player == self.player[0] and not self.multiplayer:
            # player is 'O' and must be controlled by code
            move = self.best_move()
        else:
            # either player is 'X' which is the user, or it is multiplayer mode
            move = int(input("Make a move: ")) - 1
            while not (move in range(len(self.grid)) and self.grid[move] == " "):
                move = int(input("Invalid move, try again: ")) - 1
        self.grid[move] = player
        if self.check_win(self.grid):
            self.grid = [player for i in range(9)]
        return move

    def check_win(self, grid):
        for seq in [[0, 1, 2], [3, 4, 5], [6, 7, 8],
                    [0, 3, 6], [1, 4, 7], [2, 5, 8],
                    [0, 4, 8], [2, 4, 6]]:
            # check for wins
            if len(set([grid[n] for n in seq])) == 1 and grid[seq[0]] != " ":
                return True
        return False

    def best_move(self):
        grid = self.grid
        corners = shuffle([shuffle([0, 2]), shuffle([6, 8])])
        strat = [n for n in corners] + [4] + shuffle([1, 3, 5, 7])  # list of strategic moves in decreasing priority
        move = -1

        # brute force check for winning moves
        for tile in grid:
            if tile == " ":
                tile = self.player[0]
                if self.check_win(grid):
                    # this move would win, return immediately
                    return move
                else:
                    tile = " "
                    continue

        # no winning moves found, choose from priority list
        for i in range(len(strat)):
            if grid[i] == " ":
                return strat[i]

        return move

    def print(self):
        for i in range(len(self.grid)):
            print("[" + self.grid[i] + "]", end="\n" if i % 3 == 2 else "")


class Ultimate:
    """ NOTE: INPUT IS NOW 1-9 WHICH GETS CORRECTED TO INDEX FORM 0-8 """

    def __init__(self):
        print("\033[2J\033[H", end='')  # clear screen
        self.multiplayer = True if int(input("[1] Single-player\n[2] Multi-player\n: ")) == 2 else False
        self.game_grid = [Game(self.multiplayer) for i in range(9)]
        self.turn = True
        self.player = ["\033[91mO\033[0m", "\033[92mX\033[0m"]
        self.playfield = 0

    def print(self, fields=False):
        print("\033[2J\033[H", end='')
        print("Mode:", "Multi-player" if self.multiplayer else "Single-player")
        print("Turn:", self.player[self.turn], '\n')

        splits = ((0, 3), (3, 6), (6, 9))

        for s in splits:
            for ss in splits:
                for g in self.game_grid[s[0]:s[1]]:
                    for e in g.grid[ss[0]:ss[1]]:
                        if fields:
                            print('[' + str(self.game_grid.index(g) + 1) + ']', end='')
                        elif self.game_grid.index(g) == self.playfield:
                            print("\033[93m[\033[0m" + e + "\033[93m]\033[0m", end='')
                        else:
                            print('[' + e + ']', end='')
                    print('\t', end='')
                print()
            print()

    def get_valid_playfield(self):
        """ maybe this method should be recursive? """

        if not self.turn and not self.multiplayer:
            # player is 'O' and must be controlled by code
            playfield = randrange(len(self.game_grid))
        else:
            # either player is 'X' which is the user, or it is multiplayer mode
            playfield = int(input("Choose a playfield: ")) - 1

        uniform = len(set(self.game_grid[playfield].grid)) == 1
        full = uniform and self.game_grid[playfield].grid[0] != " "
        valid = playfield in range(len(self.game_grid)) and not full

        while not valid:
            if not self.turn and not self.multiplayer:
                playfield = randrange(len(self.game_grid))
            else:
                playfield = int(input("Invalid playfield, try again: ")) - 1

        return playfield

    def play(self):
        self.print(fields=True)
        self.playfield = self.get_valid_playfield()

        # main game loop
        while not self.check_win():
            self.print()

            if len(set(self.game_grid[self.playfield].grid)) == 1 and self.game_grid[self.playfield].grid[0] != " ":
                # next move is at 'full' game, player gets to choose next field
                self.playfield = self.get_valid_playfield()

            self.playfield = self.game_grid[self.playfield].make_move(self.player[self.turn])
            self.turn = not self.turn

        self.print()
        print("Congratulations", self.player[not self.turn] + '!')  # congratulate the previous player as they actually won

    def check_win(self):
        for seq in [[0, 1, 2], [3, 4, 5], [6, 7, 8],
                    [0, 3, 6], [1, 4, 7], [2, 5, 8],
                    [0, 4, 8], [2, 4, 6]]:

            if len(set([self.game_grid[n].grid[0] for n in seq])) == 1 and self.game_grid[seq[0]].grid[0] != " ":
                self.did_win = self.game_grid[seq[0]]
                return True
        return False


u = Ultimate()
u.play()
