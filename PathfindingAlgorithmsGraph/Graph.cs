using System.Collections.Generic;

namespace PathfindingAlgorithmsGraph
{
    public class GraphEdge // Ребро графа
    {
        public GraphVertex ConnectedVertex { get; }

        public int EdgeWeight { get; }

        public GraphEdge(GraphVertex connectedVertex, int weight)
        {
            ConnectedVertex = connectedVertex; // Связанная вершина
            EdgeWeight = weight; // Вес ребра
        }
    }

    public class GraphVertex // Вершина графа
    {
        public string Name { get; }

        public List<GraphEdge> Edges { get; }

        public GraphVertex(string vertexName)
        {
            Name = vertexName; // Название вершины
            Edges = new List<GraphEdge>();
        }

        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge); // Ребро
        }

        // vertex - вершина
        // edgeWeight - вес
        public void AddEdge(GraphVertex vertex, int edgeWeight)
        {
            AddEdge(new GraphEdge(vertex, edgeWeight));
        }

        // Преобразование в строку имя вершины
        public override string ToString() => Name;
    }

    public class Graph // Граф
    {
        public List<GraphVertex> Vertices { get; } // Список вершин графа

        public Graph()
        {
            Vertices = new List<GraphVertex>();
        }

        // Добавление вершины
        public void AddVertex(string vertexName)
        {
            Vertices.Add(new GraphVertex(vertexName));
        }

        // Поиск вершины
        public GraphVertex FindVertex(string vertexName)
        {
            foreach (var v in Vertices)
            {
                if (v.Name.Equals(vertexName))
                {
                    return v;
                }
            }
            return null;
        }

        // Добавление ребра
        public void AddEdge(string firstName, string secondName, int weight)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }
    }

    public class GraphVertexInfo
    {
        public GraphVertex Vertex { get; set; }

        // Не посещенная вершина
        public bool IsUnvisited { get; set; }

        // Сумма весов ребер
        public int EdgesWeightSum { get; set; }

        // Предыдущая вершина
        public GraphVertex PreviousVertex { get; set; }

        public GraphVertexInfo(GraphVertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            EdgesWeightSum = int.MaxValue;
            PreviousVertex = null;
        }
    }
}