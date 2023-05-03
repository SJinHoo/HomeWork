﻿namespace ShortestPathPractice
{
    internal class Program
    {
        const int INF = 99999;
        static void Main(string[] args)
        {
            int[,] graph = new int[9, 9]
            {
                {   0, INF,   1,   7, INF, INF, INF,   5, INF},
                { INF,   0, INF, INF, INF,   4, INF, INF, INF},
                { INF, INF,   0, INF, INF, INF, INF, INF, INF},
                {   5, INF, INF,   0, INF, INF, INF, INF, INF},
                { INF, INF,   9, INF,   0, INF, INF, INF,   2},
                {   1, INF, INF, INF, INF,   0, INF,   6, INF},
                { INF, INF, INF, INF, INF, INF,   0, INF, INF},
                {   1, INF, INF, INF,   4, INF, INF,   0, INF},
                { INF,   5, INF,   2, INF, INF, INF, INF,   0}
            };

            int[] cost;
            int[] path;
            Dijkstra.ShortestPath(graph, 0, out cost, out path);
            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(cost, path);
        }
        private static void PrintDijkstra(int[] cost, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("cost");
            Console.Write("\t");
            Console.WriteLine("path");

            for (int i = 0; i < cost.Length; i++)
            {
                Console.Write("{0,3}", i);
                Console.Write("\t");
                if (cost[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,3}", cost[i]);
                Console.Write("\t");
                if (path[i] < 0)
                    Console.WriteLine("  X ");
                else
                    Console.WriteLine("{0,3}", path[i]);
            }
        }
    }
}