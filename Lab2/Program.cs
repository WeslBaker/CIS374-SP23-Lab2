using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();

            heap1.Add(4);
            heap1.Add(3);
            heap1.Add(2);
            heap1.Add(1);
            heap1.Add(0);
            Console.WriteLine(heap1.Count);

            Console.WriteLine(heap1.ExtractMax());

            MinHeap<int> heap2 = new MinHeap<int>();
            int Temp1;
            int Temp2;

            heap2.Add(5);
            heap2.Add(7);
            heap2.Add(10);
            heap2.Add(13);
            heap2.Add(14);
            heap2.Add(16);
            heap2.Add(47);
            heap2.Add(82);
            heap2.Add(1769);

            Temp1 = heap2.ExtractMin();

            while (heap2.IsEmpty == false)
            {
                Temp2 = heap2.ExtractMin();
                Console.WriteLine(Temp2 > Temp1);
                Temp1 = Temp2;
            }
        }
    }
}

