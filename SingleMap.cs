using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class SingleMap
    {
        public List<Pair>[] road { get; set; } 
        public int NumberNode { get; set; }
        public int NumberRoad { get; set; }

        public SingleMap(int numberNode, int numberRoad)
        {
            NumberNode = numberNode;
            NumberRoad = numberRoad;
            road = new List<Pair>[numberNode + 2];

            for (int i = 0; i < road.Length; i++)
            {
                road[i] = new List<Pair>();
            }
        }
        public void AddRoad(int direction, int startPoint, int endPoint, double value)
        {
            Pair pair1 = new Pair(endPoint, value);

            road[startPoint].Add(pair1);

            if (direction == 2)
            {
                Pair pair2 = new Pair(startPoint, value);
                road[endPoint].Add(pair2);
            }
        }

        private void TraceRoad(int[] trace, int index, int endPoint)
        {
            if (index == 0) return ;
            TraceRoad(trace, trace[index], endPoint);
            if (index != endPoint) Console.Write("{0} -> ", index);
            else Console.WriteLine(" {0}", index);
        }

        // selectFrom 
        private double Dijkstra(int startPoint, int endPoint)
        {
            
            double[] dp = new double[NumberNode + 5]; // Dynamic programming
            int[] trace = new int[NumberNode + 5];
            const double POSITIVE_INFINITY = 41000; // ~circumference of the earth
            
            for (int i = 0; i <= NumberNode; i++)
            {
                dp[i] = POSITIVE_INFINITY;
                trace[i] = -1;
            }
            trace[startPoint] = 0;
            dp[startPoint] = 0;
            MinHeap heap = new MinHeap();
            heap.Add(index: startPoint, value: 0);

            while (!heap.Empty())
            {
                Pair pair = heap.Take();
                int currentNode = pair.Index;
                double currentValue = pair.Value;

                if (currentValue != dp[currentNode]) continue;

                for (int i = 0; i < road[currentNode].Count; i++)
                {
                    int nextNode = road[currentNode][i].Index;
                    double roadValue = road[currentNode][i].Value;

                    if (dp[nextNode] > currentValue + roadValue)
                    {
                        trace[nextNode] = currentNode;
                        dp[nextNode] = currentValue + roadValue;
                        heap.Add(index: nextNode, value: dp[nextNode]);
                    }
                }
            }
            Console.WriteLine("The fastest way to go to the place of sale of products");
            TraceRoad(trace, endPoint, endPoint);
            Console.WriteLine();
            return dp[endPoint];
        }

        public double FindShortestPath(int startPoint, int endPoint)
        {
            return Dijkstra(startPoint, endPoint);
        }
    }
}
