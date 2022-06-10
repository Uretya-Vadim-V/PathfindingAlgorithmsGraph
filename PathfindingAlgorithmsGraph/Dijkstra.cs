using System;
using System.Collections.Generic;

namespace PathfindingAlgorithmsGraph
{
    // Поиск кратчайшего пути
    public class Dijkstra
    {
        Graph graph;
        List<GraphVertexInfo> info = new();
        public Dijkstra(Graph graph) { this.graph = graph; }

        // Получение информации о вершине графа
        private GraphVertexInfo GetVertexInfo(GraphVertex v)
        {
            foreach (var i in info)
            {
                if (i.Vertex.Equals(v))
                {
                    return i;
                }
            }
            return null;
        }

        // Поиск непосещенной вершины с минимальным значением суммы
        private GraphVertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = int.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (var i in info)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }
            return minVertexInfo;
        }

        // Поиск кратчайшего пути по названиям вершин
        public List<int> FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
        }

        // Поиск кратчайшего пути по вершинам
        private List<int> FindShortestPath(GraphVertex startVertex, GraphVertex finishVertex)
        {
            foreach (var v in graph.Vertices)
            {
                info.Add(new GraphVertexInfo(v));
            }
            var first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }
                SetSumToNextVertex(current);
            }
            RestorePath(startVertex, finishVertex);
            return path;
        }

        // Вычисление суммы весов ребер для следующей вершины
        private void SetSumToNextVertex(GraphVertexInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Vertex.Edges)
            {
                var nextInfo = GetVertexInfo(e.ConnectedVertex);
                var sum = info.EdgesWeightSum + e.EdgeWeight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }

        // Вычисление вероятности
        public decimal Chance(List<int> value)
        {
            decimal chance = 1;
            for (int i = 0; i < value.Count - 1; i++)
            {
                for (int j = 0; j < info.Count; j++)
                {
                    if (info[j].Vertex.Name == value[i].ToString())
                    {
                        for (int k = 0; k < info[j].Vertex.Edges.Count; k++)
                        {
                            if (value[i + 1].ToString() == info[j].Vertex.Edges[k].ConnectedVertex.Name)
                            {
                                chance *= 1 - (decimal)info[j].Vertex.Edges[k].EdgeWeight / 100;
                                break;
                            }
                        }
                    }
                }
            }
            return 1 - chance;
        }

        // Формирование пути
        List<int> path = new();
        private void RestorePath(GraphVertex startVertex, GraphVertex endVertex)
        {
            path.Add(Int32.Parse(endVertex.ToString()));
            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path.Add(Int32.Parse(endVertex.ToString()));
            }
        }

        // Вывод пути
        public override string ToString()
        {
            string restorePath = path[0].ToString();
            for (int i = 1; i < path.Count; i++)
            {
                restorePath = path[i] + " - " + restorePath;
            }
            return restorePath;
        }
    }
}