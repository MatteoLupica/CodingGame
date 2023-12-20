import java.util.HashMap;
import java.util.Scanner;
// this java code scored 61%
public class MemoryRide {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int L, C, N;
        L = scanner.nextInt();
        C = scanner.nextInt();
        N = scanner.nextInt();

        int[] text = new int[N];
        int idx = 0;
        HashMap<Integer, int[]> memory = new HashMap<>();

        for (int i = 0; i < N; i++) {
            int Pi = scanner.nextInt();
            text[i] = Pi;
        }

        int num = 0;
        while (C > 0) {
            int origIdx = idx;
            int ride = 0;

            try {
                num += memory.get(idx)[0];
                idx = memory.get(idx)[1];
            } catch (NullPointerException e) {
                int Amount = 0;
                while (ride + text[idx] <= L) {
                    ride += text[idx];
                    num += text[idx];
                    Amount += text[idx];
                    idx = (idx + 1) % text.length;
                    if (idx == origIdx) {
                        break;
                    }
                }
                memory.put(origIdx, new int[]{Amount, idx});
            }
            C--;
        }

        System.out.println(num);
    }
}
