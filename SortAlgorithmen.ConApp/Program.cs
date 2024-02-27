namespace SortAlgorithmen.ConApp
{
    using System.Diagnostics;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sort-Algorithmen!");

            int[] array = CreateRandomArray(20);

            PrintArray(array);
            BubbleSort(array);
            PrintArray("BubbleSort:", array);

            // Performance
            Stopwatch sw = new Stopwatch();
            int[] parray1 = CreateRandomArray(100_000);
            int[] parray2 = (int[])parray1.Clone();

            Console.WriteLine($"{nameof(BubbleSort)}(0...{parray1.Length})");
            sw.Start();
            BubbleSort(parray1);
            sw.Stop();
            Console.WriteLine($"Zeitmessung: {sw.ElapsedMilliseconds} ms");

            Console.WriteLine($"Array.Sort(0...{parray1.Length})");
            sw.Restart();
            Array.Sort(parray2);
            sw.Stop();
            Console.WriteLine($"Zeitmessung: {sw.ElapsedMilliseconds} ms");

            Console.ReadLine();
        }

        private static void PrintArray(string title, int[] array)
        {
            Console.WriteLine(title);
            PrintArray(array);
        }
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                {
                    Console.Write(" ");
                }
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }

        private static void BubbleSort(int[] array)
        {
            bool exchange;
            int length = array.Length;

            do
            {
                exchange = false;
                for (int i = 0; i < length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        //Swap(ref array[i], ref array[i + 1]);
                        int tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                        exchange = true;
                    }
                }
                length--;
            } while (exchange);
        }

        private static void Swap(ref int v1, ref int v2)
        {
            int tmp = v1;

            v1 = v2;
            v2 = tmp;
        }

        private static int[] CreateRandomArray(int size)
        {
            return CreateRandomArray(size, 0, size);
        }
        private static int[] CreateRandomArray(int size, int min, int max)
        {
            int[] result = new int[size];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Random.Shared.Next(min, max);
            }
            return result;
        }
    }
}