def sum_of_digits(n):
    return sum(map(int, str(n)))

def find_meeting_point(r1, r2):
    while r1 != r2:
        while r1 < r2:
            r1 += sum_of_digits(r1)
        while r2 < r1:
            r2 += sum_of_digits(r2)
    return r1

# Input
r1 = int(input())
r2 = int(input())

# Output
result = find_meeting_point(r1, r2)
print(result)
