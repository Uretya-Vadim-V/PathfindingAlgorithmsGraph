using System;
using System.Collections.Generic;

namespace CardTask2
{
    // Алгоритм Прима
    class Prim
    {
        static int vertexs;
        // Поиск вершины с минимальным значением из набора вершин
        static int MinKey(int[] key, bool[] set)
        {
            int min = int.MaxValue, min_index = -1;
            for (int i = 0; i < vertexs; i++)
                if (set[i] == false && key[i] < min)
                {
                    min = key[i];
                    min_index = i;
                }
            return min_index;
        }

        static List<int[]> result = new();
        // Находит минимальное остовое дерево
        public static int PrimAlgorithm(int[,] graph)
        {
            vertexs = (int)Math.Sqrt(graph.Length);
            int[] parent = new int[vertexs];  // Массив для хранения построенного дерева
            int[] key = new int[vertexs]; // Значения для выбора ребра минимальной длины
            bool[] set = new bool[vertexs];
            int minLength = 0;
            for (int i = 0; i < vertexs; i++)
            {
                key[i] = int.MaxValue;
                set[i] = false;
            }
            key[0] = 0;
            parent[0] = -1;
            for (int count = 0; count < vertexs - 1; count++)
            {
                int v = MinKey(key, set); // Выбрать минимальную ключевую вершину из набора вершин, еще не включенных в дерево
                set[v] = true; // Добавить выбранную вершину в набор
                for (int i = 0; i < vertexs; i++)
                    if (graph[v, i] != 0 && set[i] == false && graph[v, i] < key[i])
                    {
                        parent[i] = v;
                        key[i] = graph[v, i];
                    }
            }
            for (int i = 1; i < vertexs; i++)
            {
                minLength += graph[i, parent[i]];
                result.Add(new int[3] { parent[i], i, graph[i, parent[i]] });
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
