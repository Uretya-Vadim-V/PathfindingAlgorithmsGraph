using System;

namespace PathfindingAlgorithmsGraph
{
    // 1.3. Опасный маршрут
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество зданий и количество улиц соединяющих здания (1 <= N <= 100, 1 <= M <= N(N - 1)/2) (через пробел)");
            string[] temp = Console.ReadLine().Split(' ');
            int n = int.Parse(temp[0]);
            int m = int.Parse(temp[1]);
            Console.WriteLine("Введите номер дома, в котором живёт профессор и номер дома, в котором находится университет соответственно (через пробел)");
            temp = Console.ReadLine().Split(' ');
            string s = temp[0];
            string e = temp[1];
            Console.WriteLine("Введите 3 целых числа s_i, e_i, p_i (через пробел) - здания, в которых начинается и заканчивается дорога и вероятность в процентах быть ограбленным" +
                "пройдя по дороге соответственно (1 <= s_i, e_i <= N, 0 <= p_i <= 100, дороги двунаправленные)");
            var graph = new Graph();
            for (int i = 1; i <= n; i++)
                graph.AddVertex(i.ToString());
            for (int i = 0; i < m; i++)
            {
                temp = Console.ReadLine().Split(' ');
                graph.AddEdge(temp[0], temp[1], int.Parse(temp[2]));
            }
            var dijkstra = new Dijkstra(graph);
            Console.WriteLine($"\nМинимальная возможная вероятность быть ограбленным = {dijkstra.Chance(dijkstra.FindShortestPath(s, e))}");
        }
    }
}
