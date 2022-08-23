using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class MinHeap
    {
        public int Size { get; set; } // Note: Size begins from 1 but ListHeap begins from 0
    
        private List<Pair> ListHeap {get; set; }
        public MinHeap()
        {
            Size = 0;
            ListHeap = new List<Pair>();
        }
        public bool Empty()
        {
            if (Size <= 0) return true;
            return false;
        }
        private void AddElementInListHeap(int index)
        {
            int parent = (index - 1) / 2;
            if (parent < 0) return;

            if (ListHeap[parent].Value < ListHeap[index].Value)
            {
                Pair pair = ListHeap[parent];
                ListHeap[parent] = ListHeap[index];
                ListHeap[index] = pair;
                AddElementInListHeap(parent);
            }
        }
        public void Add(int index, double value)
        {
            Pair pair = new Pair(index, value);

            Size++;
            ListHeap.Add(pair);

            AddElementInListHeap(Size - 1);
        }
        private void Heapify(int index)
        {
            int minIndex = index;
            int left = index * 2 + 1;
            int right = index * 2 + 2;

            if (left < Size && ListHeap[left].Value < ListHeap[minIndex].Value)
                minIndex = left;
            if (right < Size && ListHeap[right].Value < ListHeap[minIndex].Value)
                minIndex = right;

            if (minIndex != index)
            {
                Pair pair = ListHeap[index];
                ListHeap[index] = ListHeap[minIndex];
                ListHeap[minIndex] = pair;

                Heapify(minIndex);
            }
        }
        public Pair Take()
        {
            Pair pair = ListHeap[0];
            ListHeap[0] = ListHeap[Size - 1];
            ListHeap.RemoveAt(Size - 1);
            Size--;
            Heapify(0);
            return pair;
        }
    }
}
