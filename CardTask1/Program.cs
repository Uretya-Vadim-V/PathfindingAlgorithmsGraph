using PathfindingAlgorithmsGraph;
using System;

namespace CardTask1
{
    class Program
    {
        static void Main()
        {
            // создаём 9 вершин
            var graph = new Graph();
            for (int i = 0; i < 9; i++)
                graph.AddVertex(i.ToString());
            // добавляем рёбра графа (вершины a, b и вес)
            graph.AddEdge("0", "2", 7);
            graph.AddEdge("0", "3", 15);
            graph.AddEdge("0", "6", 9);
            graph.AddEdge("0", "7", 5);
            graph.AddEdge("1", "2", 14);
            graph.AddEdge("1", "7", 2);
            graph.AddEdge("2", "8", 20);
            graph.AddEdge("3", "8", 10);
            graph.AddEdge("3", "4", 5);
            graph.AddEdge("4", "5", 11);
            graph.AddEdge("4", "6", 8);
            graph.AddEdge("4", "8", 7);
            graph.AddEdge("5", "6", 14);
            graph.AddEdge("5", "8", 25);
            var dijkstra = new Dijkstra(graph);
            dijkstra.FindShortestPath("1", "8");
            Console.WriteLine($"Кратчайший путь по алгоритму Дейкстры: {dijkstra}");
        }
    }
}
