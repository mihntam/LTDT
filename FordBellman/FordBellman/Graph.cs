using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace FordBellman
{
    class Graph
    {
        public int iCountVetices { get; set; }
        public int iCountEdges { get; set; }
        Edge[] edgeArray;

        Graph(int numOfVetices, int numOfEdges)
        {
            iCountVetices = numOfEdges;
            iCountEdges = numOfVetices;
            edgeArray = new Edge[iCountEdges];

            for (int i = 0; i < iCountEdges; i++)
            {
                edgeArray[i] = new Edge();
            }
        }

        /// <summary>
        /// Hàm tìm đường đi ngắn nhất tới các đỉnh còn lại bằng Ford Bellman
        /// Trả về trọng số âm nếu có
        /// </summary>
        /// <param name="g"></param> Đồ thị
        /// <param name="sourceVertex"></param> Đỉnh được xét
        private static void BellmanFord(Graph g, int sourceVertex, int distanceVertex)
        {
            int[] distance = new int[g.iCountVetices];
            // Khởi tạo giá trị độ dài vô cực
            for (int i = 0; i < g.iCountVetices; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[sourceVertex] = 0;


            for (int i = 0; i < g.iCountVetices; i++)
            {
                for (int j = 0; j < g.iCountEdges; i++)
                {
                    int u = g.edgeArray[j].iSource; //Đỉnh ra u
                    int v = g.edgeArray[j].iDetination; //Đỉnh vào v
                    int weight = g.edgeArray[j].iWeight;
                    if (distance[u] != int.MaxValue && ( distance[u] + weight) < distance[v])
                    {
                        distance[v] = distance[u] + weight;
                    }
                }
            }

            for (int j = 0; j < g.iCountEdges; j++)
            {
                int u = g.edgeArray[j].iSource; //Đỉnh ra u
                int v = g.edgeArray[j].iDetination; //Đỉnh vào v
                int weight = g.edgeArray[j].iWeight;
                if (distance[u] != int.MaxValue && (distance[u] + weight) < distance[v])
                {
                    // Ham xu ly th chu trinh am
                }
            }

            // ham xu ly de lay kq
        }
    }
}
