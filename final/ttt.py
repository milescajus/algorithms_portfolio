class Game:
    def __init__(self):
        # self.grid = [" " for i in range(9)]
        self.grid = [str(i) for i in range(9)]
        self.did_win = ""
        self.turn = True
        self.player = ["\033[91mO\033[0m", "\033[92mX\033[0m"]

    def play(self):
        while self.did_win == "":
            self.print()
            user = int(input(": "))
            if user in range(len(self.grid)) and self.grid[user] == " ":
                self.grid[user] = self.player[1 if self.turn else 0]						            # check if move is valid and place tile
            self.turn = not self.turn																	# change turns
            self.check_win()

    def check_win(self):
        for seq in [[0, 1, 2], [3, 4, 5], [6, 7, 8],
                    [0, 3, 6], [1, 4, 7], [2, 5, 8],
                    [0, 4, 8], [2, 4, 6]]:

            if len(set([self.grid[seq[i]] for i in range(len(seq))])) == 1 and self.grid[seq[0]] != " ":
                self.did_win = self.grid[seq[0]]                                                    # check for wins

        return self.player.index(self.did_win)

    def print(self):
        for i in range(len(self.grid)):
            print("[" + self.grid[i] + "]", end="\n" if i % 3 == 2 else "")							# print self.grid


class Ultimate:
    def __init__(self):
        self.metagrid = [Game() for i in range(9)]
        self.turn = True
        self.player = ["\033[91mO\033[0m", "\033[92mX\033[0m"]
        self.playfield

    def print(self):
        splits = ((0, 3), (3, 6), (6, 9))

        for s in splits:
            for ss in splits:
                for g in self.metagrid[s[0]:s[1]]:
                    for e in g.grid[ss[0]:ss[1]]:
                        print('[' + e + ']', end='')
                    print('\t', end='')
                print()
            print()
