using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        const int vectorSize = 1000000;
        int[][] vectors = GenerateRandomVectors(vectorSize);

        Stopwatch stopwatch_multithreaded = new Stopwatch();
        stopwatch_multithreaded.Start();
        Parallel.ForEach(vectors, vector =>
        {
            InvertVector(vector);
        });
        stopwatch_multithreaded.Stop();
        Console.WriteLine($"Multithreaded inversion of {vectorSize} vectors took {stopwatch_multithreaded.ElapsedMilliseconds} milliseconds.");

        Stopwatch stopwatch_singlethreaded = new Stopwatch();
        stopwatch_singlethreaded.Start();
        foreach (var vector in vectors)
        {
            InvertVector(vector);
        }
        stopwatch_singlethreaded.Stop();
        Console.WriteLine($"Inversion of {vectorSize} vectors took {stopwatch_singlethreaded.ElapsedMilliseconds} milliseconds.");
}

    static int[][] GenerateRandomVectors(int vectorSize)
    {
        Random random = new Random();
        int[][] vectors = new int[vectorSize][];

        for (int i = 0; i < vectorSize; i++)
        {
            vectors[i] = new int[10];
            for (int j = 0; j < 10; j++)
            {
                vectors[i][j] = random.Next(1, 100);
            }
        }

        return vectors;
    }

    static void InvertVector(int[] vector)
    {
        int length = vector.Length;
        int mid = length / 2;

        for (int i = 0; i < mid; i++)
        {
            int temp = vector[i];
            vector[i] = vector[length - i - 1];
            vector[length - i - 1] = temp;
        }
    }
}
