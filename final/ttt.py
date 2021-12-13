class Game:
    def __init__(self):
        self.grid = [" " for i in range(9)]
        # self.grid = [str(i) for i in range(9)]
        self.did_win = ""
        self.turn = True
        self.player = ["\033[91mO\033[0m", "\033[92mX\033[0m"]

    def play(self):
        while self.did_win == "":
            self.print()
            user = int(input(": "))
            if user in range(len(self.grid)) and self.grid[user] == " ":
                self.grid[user] = self.player[1 if self.turn else 0]                                # check if move is valid and place tile
            self.turn = not self.turn                                                               # change turns
            self.check_win()

    def make_move(self, player):
        move = int(input("Make a move (" + player + "): "))
        while not (move in range(len(self.grid)) and self.grid[move] == " "):
            move = int(input("Invalid move (enter number from 0-8): "))
        self.grid[move] = player
        if self.check_win():
            self.grid = [player for i in range(9)]
        return move

    def check_win(self):
        for seq in [[0, 1, 2], [3, 4, 5], [6, 7, 8],
                    [0, 3, 6], [1, 4, 7], [2, 5, 8],
                    [0, 4, 8], [2, 4, 6]]:

            if len(set([self.grid[seq[i]] for i in range(len(seq))])) == 1 and self.grid[seq[0]] != " ":
                self.did_win = self.grid[seq[0]]                                                    # check for wins
                return True
        return False

    def print(self):
        for i in range(len(self.grid)):
            print("[" + self.grid[i] + "]", end="\n" if i % 3 == 2 else "")                         # print self.grid


class Ultimate:
    def __init__(self):
        self.metagrid = [Game() for i in range(9)]
        self.turn = True
        self.player = ["\033[91mO\033[0m", "\033[92mX\033[0m"]
        self.playfield = 0

    def print(self, fields=False):
        print("\033[2J\033[H", end='')  # clear screen

        splits = ((0, 3), (3, 6), (6, 9))

        for s in splits:
            for ss in splits:
                for g in self.metagrid[s[0]:s[1]]:
                    for e in g.grid[ss[0]:ss[1]]:
                        if fields:
                            print('[' + str(self.metagrid.index(g)) + ']', end='')
                        elif self.metagrid.index(g) == self.playfield:
                            print("\033[93m[\033[0m" + e + "\033[93m]\033[0m", end='')
                        else:
                            print('[' + e + ']', end='')
                    print('\t', end='')
                print()
            print()

    def play(self):
        self.print(fields=True)
        self.playfield = int(input("Choose a playfield: "))
        while not (self.playfield in range(len(self.metagrid))):
            self.playfield = int(input("Invalid playfield (enter number from 0-8): "))
        while not self.check_win():
            self.print()
            self.playfield = self.metagrid[self.playfield].make_move(self.player[self.turn])
            self.turn = not self.turn

    def check_win(self):
        for seq in [[0, 1, 2], [3, 4, 5], [6, 7, 8],
                    [0, 3, 6], [1, 4, 7], [2, 5, 8],
                    [0, 4, 8], [2, 4, 6]]:

            # TODO: FIX
            if len(set([self.metagrid[seq[i]] for i in range(len(seq))])) == 1 and type(self.metagrid[seq[0]]) is str:
                self.did_win = self.metagrid[seq[0]]                                                    # check for wins
                return True
        return False


u = Ultimate()
u.play()
