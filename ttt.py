grid = [" " for i in range(9)]
did_win = ""
turn = True
player = ["\033[91mO\033[0m","\033[92mX\033[0m"]
while did_win == "":
	for i in range(len(grid)): print("[" + grid[i] + "]", end="\n" if i % 3 == 2 else "")							# print grid
	user = int(input(": ")
	if user in range(len(grid)) and grid[user] == " ": grid[user] = player[1 if turn else 0]						# check if move is valid and place tile
	turn = not turn																									# change turns
	for seq in [[0,1,2],[3,4,5],[6,7,8],[0,3,6],[1,4,7],[2,5,8],[0,4,8],[2,4,6]]:
		if len(set([grid[seq[i]] for i in range(len(seq))])) == 1 and grid[seq[0]] != " ": did_win = grid[seq[0]]	# check for wins
print(did_win))
