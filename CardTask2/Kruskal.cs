using System;
using System.Collections.Generic;

namespace CardTask2
{
    // Алгоритм Краскала
    class Kruskal
    {
        static int[] parent;
        static int infinity = int.MaxValue;
            
        // Ищет набор вершин i
        static int Find(int i)
        {
            while (parent[i] != i)
                i = parent[i];
            return i;
        }

        // Объединение i и j. Возвращает false, если i и j уже находятся в одном наборе
        static void Union(int i, int j)
        {
            int a = Find(i);
            int b = Find(j);
            parent[a] = b;
        }

        static List<int[]> result = new();
        // Находит минимальное остовое дерево
        public static int KruskalAlgorithm(int[,] graph)
        {
            int vertexs = (int)Math.Sqrt(graph.Length);
            parent = new int[vertexs];
            int minLength = 0, edge_count = 0;
            for (int i = 0; i < vertexs; i++)
                parent[i] = i;
            while (edge_count < vertexs - 1)
            {
                // a и b - необходимые вершины ребра graph[i, j]
                int min = infinity, a = -1, b = -1;
                for (int i = 0; i < vertexs; i++)
                {
                    for (int j = 0; j < vertexs; j++)
                    {
                        if (Find(i) != Find(j) && graph[i, j] < min)
                        {
                            min = graph[i, j];
                            a = i;
                            b = j;
                        }
                    }
                }
                Union(a, b);
                edge_count++;
                result.Add(new int[3]{ a, b, min });
                minLength += min;
            }
            return minLength;
        }

        public static void Info()
        {
            int k = 0;
            foreach (var item in result)
            {
                Console.Write($"Ребро {++k}: ({item[0]}, {item[1]}), длина: {item[2]}\n");
            }
        }
    }
}
