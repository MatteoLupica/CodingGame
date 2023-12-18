# Read initialization data
light_x, light_y, initial_tx, initial_ty = map(int, input().split())

# Game loop
while True:
    remaining_turns = int(input())  # Read the number of remaining moves (ignore for now)

    # Calculate the direction Thor should move
    dx = light_x - initial_tx
    dy = light_y - initial_ty

    # Determine the move direction
    move = ""
    if dy > 0:
        move += "S"
        initial_ty += 1
    elif dy < 0:
        move += "N"
        initial_ty -= 1

    if dx > 0:
        move += "E"
        initial_tx += 1
    elif dx < 0:
        move += "W"
        initial_tx -= 1

    # Output the move
    print(move)
