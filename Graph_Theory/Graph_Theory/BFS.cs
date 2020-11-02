using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    class BFS
    {
        public int[,] maTran = new int[100, 100];
        public int soDinh = 0;
        public const int MAX = 100;
        public const int voCuc = -1;

        public int[] luuVet = new int[MAX];
        public int[] visited = new int[MAX];

        public int[] ketQua = new int[MAX];
        public int index = 0;

        public void doc_Ma_Tran(int[,] _maTran, int _soDinh)
        {
            soDinh = _soDinh;
            for (int i = 0; i < soDinh; ++i)
            {
                for (int j = 0; j < soDinh; ++j)
                {
                    maTran[i, j] = _maTran[i, j];
                }
            }
        }

        public void Bfs(int dinhDau)
        {
            Queue<int> q = new Queue<int>(0);
            q.Enqueue(dinhDau);

            while (q.Count != 0)
            {
                dinhDau = q.Dequeue();

                visited[dinhDau] = 1;
                for (int i = 0; i < soDinh; i++)
                {
                    if (visited[i] == 0 && maTran[dinhDau, i] != 0)
                    {
                        q.Enqueue(i);
                        luuVet[i] = dinhDau;
                    }
                }
            }
        }
        public void duyetBFS(int dinhDau, int dinhCuoi)
        {
            for (int i = 0; i < soDinh; ++i)
            {
                visited[i] = 0;
                luuVet[i] = voCuc;
            }

            Bfs(dinhDau);

            if (visited[dinhCuoi] == 1)
            {
                int j = dinhCuoi;

                while (j != dinhDau)
                {
                    ketQua[index] = j;
                    j = luuVet[j];
                    index++;
                }

                ketQua[index] = dinhDau;
                ++index;
            }
        }

    }
}
