import math

# Read initialization data
surface_n = int(input())
surface = []
for _ in range(surface_n):
    land_x, land_y = map(int, input().split())
    surface.append((land_x, land_y))

# Game loop
while True:
    x, y, h_speed, v_speed, fuel, rotate, power = map(int, input().split())

    # Constants
    max_rotation = 15
    max_power_change = 1

    # Calculate desired rotation and power
    desired_rotate = 0
    desired_power = 3  # Default power setting

    # Determine if we need to adjust the rotation
    if v_speed <= -40:
        desired_rotate = 0
    else:
        # Calculate desired angle based on horizontal speed
        desired_rotate = math.degrees(math.atan(h_speed / (v_speed + 1)))

    # Limit rotation change
    if abs(desired_rotate - rotate) > max_rotation:
        desired_rotate = rotate + max_rotation if desired_rotate > rotate else rotate - max_rotation

    # Calculate desired power
    if v_speed < -39:
        desired_power = 4
    elif v_speed > -21:
        desired_power = 0

    # Limit power change
    if desired_power > power:
        desired_power = power + max_power_change
    elif desired_power < power:
        desired_power = power - max_power_change

    # Output the instructions
    print(f"{int(desired_rotate)} {int(desired_power)}")
