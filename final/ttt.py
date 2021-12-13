from random import randrange
from random import sample


class Game:
    """ NOTE: INPUT IS NOW 1-9 WHICH GETS CORRECTED TO INDEX FORM 0-8 """

    def __init__(self, multiplayer=True):
        self.grid = [" " for i in range(9)]
        self.player = ["\033[91mO\033[0m", "\033[92mX\033[0m"]
        self.multiplayer = multiplayer
        self.win_seq = [[0, 1, 2], [3, 4, 5], [6, 7, 8],
                        [0, 3, 6], [1, 4, 7], [2, 5, 8],
                        [0, 4, 8], [2, 4, 6]]

    def make_move(self, player, full_games):
        move = -1

        if player == self.player[0] and not self.multiplayer:
            # player is 'O' and must be controlled by code
            move = self.best_move(full_games)
        else:
            # either player is 'X' which is the user, or it is multiplayer mode
            move = int(input("Make a move: ")) - 1
            while not (move in range(len(self.grid)) and self.grid[move] == " "):
                move = int(input("Invalid move, try again: ")) - 1

        self.grid[move] = player

        if self.check_win():
            # subgame won, fill the field with winner
            self.grid = [player for i in range(9)]

        return move

    def check_win(self):
        for seq in self.win_seq:
            # check for completed winning sequence
            if len(set([self.grid[n] for n in seq])) == 1 and self.grid[seq[0]] != " ":
                return True

        return False

    def winning_seq(self):
        # check if any win sequence is one move away from completion
        for seq in self.win_seq:
            grid_seq = [self.grid[n] for n in seq]

            if len(set(grid_seq)) == 2 and grid_seq.count(" ") == 1:
                return seq

        return None

    def best_move(self, full_games):
        # TODO: AVOID NEXT PLAYFIELD BEING NEAR-WIN

        # check if any player has a near-win
        w_seq = self.winning_seq()      # looks like [0, 1, 2] or None
        if w_seq is not None:           # there exists a winning move
            for n in w_seq:
                if self.grid[n] == " " and n not in full_games:
                    return n            # could be offensive or defensive

        # build list of next best moves and return first valid
        corners = sample([n for n in sample([0, 2], 2)] + [n for n in sample([6, 8], 2)], 2)
        strat = [n for n in corners] + [4] + sample([1, 3, 5, 7], 4)  # list of strategic moves in decreasing priority

        for n in strat:
            if self.grid[n] == " " and n not in full_games:
                return n

        return None

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
        self.win_seq = [[0, 1, 2], [3, 4, 5], [6, 7, 8],
                        [0, 3, 6], [1, 4, 7], [2, 5, 8],
                        [0, 4, 8], [2, 4, 6]]

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

    def is_full(self, n):
        return self.game_grid[n].grid.count(" ") == 0       # no tiles are empty -> field is full

    def is_uniform(self, n):
        return len(set(self.game_grid[n].grid)) == 1        # all tiles are the same -> field is either empty or won

    def best_move(self):
        for idx, g in enumerate(self.game_grid):
            if g.winning_seq() is not None:
                # check if moving here would allow a winning move
                return idx

        return randrange(len(self.game_grid))

    def get_valid_playfield(self):
        if not self.turn and not self.multiplayer:
            # player is 'O' and must be controlled by code
            playfield = self.best_move()
        else:
            # either player is 'X' which is the user, or it is multiplayer mode
            playfield = int(input("Choose a playfield: ")) - 1

        valid = playfield in range(len(self.game_grid)) and not self.is_full(playfield)

        if not valid:
            print("Invalid playfield, try again.\n")
            return self.get_valid_playfield()

        return playfield

    def play(self):
        self.print(fields=True)
        self.playfield = self.get_valid_playfield()

        # main game loop
        while not self.check_win():
            self.print()

            if self.is_full(self.playfield):  # next move is at 'full' game, player gets to choose next field
                self.playfield = self.get_valid_playfield()

            full_games = []     # to pass to Game() for opponent to avoid
            for i in range(len(self.game_grid)):
                if self.is_full(i):
                    full_games.append(i)

            self.playfield = self.game_grid[self.playfield].make_move(self.player[self.turn], full_games)

            self.turn = not self.turn

        self.print()
        print("Congratulations", self.player[not self.turn] + '!')  # congratulate the previous player as they actually won

    def check_win(self):
        for seq in self.win_seq:
            # if seq exists that is entirely full and uniform, win has occurred
            if [self.is_full(n) for n in seq].count(False) == 0 and [self.is_uniform(n) for n in seq].count(False) == 0:
                if len(set([g.grid[0] for g in self.game_grid])) == 1:  # sequence itself is uniform (i.e. not X-X-O)
                    return True

        return False


u = Ultimate()
u.play()
