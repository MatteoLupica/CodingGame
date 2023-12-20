using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split();
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int count = int.Parse(Console.ReadLine());
        bool odd = count % 2 == 0;

        char[][] chars = new char[height][];

        for (int i = 0; i < height; i++)
        {
            chars[i] = Console.ReadLine().ToCharArray();
        }

        for (int j = 0; j < count; j++)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = chars[i].OrderByDescending(c => c).ToArray();
            }

            chars = Transpose(chars);
        }

        foreach (char[] rast in chars)
        {
            Console.WriteLine(new string(rast));
        }
    }

    static T[][] Transpose<T>(T[][] matrix)
    {
        int rowCount = matrix.Length;
        int colCount = matrix[0].Length;
        T[][] result = new T[colCount][];

        for (int i = 0; i < colCount; i++)
        {
            result[i] = new T[rowCount];
            for (int j = 0; j < rowCount; j++)
            {
                result[i][j] = matrix[j][i];
            }
        }

        return result;
    }
}
