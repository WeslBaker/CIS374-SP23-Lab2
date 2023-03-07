using System;
using System.Linq;

namespace Lab2
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] array;
        private const int initialSize = 8;

        public int Count { get; private set; }

        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;

        public MinHeap(T[] initialArray = null)
        {
            array = new T[initialSize];

            if (initialArray == null)
            {
                Count = 0;
                return;
            }

            foreach (var item in initialArray)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Returns the min item but does NOT remove it.
        /// Time complexity: O(1)
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            return array[0];
        }

        // TODO
        /// <summary>
        /// Adds given item to the heap.
        /// Time complexity: O(?)
        /// </summary>
        public void Add(T item)
        {
            int nextEmptyIndex = Count;

            array[nextEmptyIndex] = item;

            TrickleUp(nextEmptyIndex);

            Count++;

            // resize if full
            if (Count == Capacity)
            {
                DoubleArrayCapacity();
            }
        }

        public T Extract()
        {
            return ExtractMin();
        }

        // TODO
        /// <summary>
        /// Removes and returns the max item in the min-heap.
        /// Time complexity: O( N )
        /// </summary>
        public T ExtractMax()
        {
            if(IsEmpty)
            {
                throw new Exception("Empty Heap");
            }
            // linear search
            var max = array[0];
            int maxIndex = 0;
            for(int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    maxIndex = i;
                    max = array[i];
                }
            }
            // remove max
            Swap(maxIndex, Count - 1);
            Count--;
            return max;
        }

        // TODO
        /// <summary>
        /// Removes and returns the min item in the min-heap.
        /// Time complexity: O( log(n) )
        /// </summary>
        public T ExtractMin()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T min = array[0];

            // swap root (first) and last element
            Swap(0, Count - 1);

            // "remove" last
            Count--;

            // trickle down from root (first)
            TrickleDown(0);

            return min;
        }

        // TODO
        /// <summary>
        /// Returns true if the heap contains the given value; otherwise false.
        /// Time complexity: O( N )
        /// </summary>
        public bool Contains(T value)
        {
            // linear search

            for(int i=0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // TODO
        /// <summary>
        /// Updates the first element with the given value from the heap.
        /// Time complexity: O( n )
        /// </summary>
        public void Update(T oldValue, T newValue)
        {
            if(IsEmpty)
            {
                throw new Exception("Empty Heap");
            }    
            else if(Contains(oldValue))
            {
                //linear search
                for (int i = 0; i < Count; i++)
                {
                    if (array[i].CompareTo(oldValue) == 0)
                    {
                        array[i] = newValue;
                        TrickleDown(i);
                        TrickleUp(i);
                    }
                }
            }
            else
            {
                throw new Exception("Value not found");
            }

        }

        // TODO
        /// <summary>
        /// Removes the first element with the given value from the heap.
        /// Time complexity: O( ? )
        /// </summary>
        public void Remove(T value)
        {
            if(Contains(value))
            {
                for(int i = 0; i < Count; i ++)
                {
                    if (array[i].CompareTo(value) == 0)
                    {
                        Swap(i, Count - 1);
                        TrickleUp(i);
                        Count--;
                    }
                }
            }
            else
            {
                throw new Exception("Empty Heap/value not found");
            }
        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleUp(int index)
        {
            if (array[Parent(index)].CompareTo(array[index]) <= 0)
            {
                return;
            }
            else
            {
                Swap(index, Parent(index));
                TrickleUp(Parent(index));
                TrickleDown(index);
            }
            return;
        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleDown(int index)
        {

            int leftIndex = LeftChild(index);
            int rightIndex = RightChild(index);

            if ((leftIndex >= Count && rightIndex >= Count) || (array[leftIndex].CompareTo(array[index]) >= 0 && array[rightIndex].CompareTo(array[index]) >= 0))
            {
                return;
            }

            if (array[leftIndex].CompareTo(array[index]) <= 0 && leftIndex < Count)
            {
                Swap(index, leftIndex);
                TrickleDown(leftIndex);
                TrickleUp(index);
            }
            else if(array[rightIndex].CompareTo(array[index]) <= 0 && rightIndex < Count)
            {
                Swap(index, rightIndex);
                TrickleDown(rightIndex);
                TrickleUp(index);
            }
            return;
        }

        // TODO
        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {
            if(position == 1)
            {
                return 0;
            }
            else if(position % 2 == 0)
            {
                return position / 2;
            }
            return (position + 1) / 2;
        }

        // TODO
        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
            return position * 2 + 1;
        }

        // TODO
        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
            if(position == 0)
            {
                return 2;
            }
            return position * 2;
        }

        private void Swap(int index1, int index2)
        {
            var temp = array[index1];

            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void DoubleArrayCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }
    }
}


