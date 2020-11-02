using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    public class DFS
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
            for(int i = 0; i < soDinh; ++i)
            {
                for(int j = 0; j < soDinh; ++j)
                {
                    maTran[i, j] = _maTran[i, j];
                }
            }
        }

        public void Dfs(int dinhDau)
        {
            visited[dinhDau] = 1;

            for(int i = 0; i < soDinh; ++i)
            {
                if(visited[i] == 0 && maTran[dinhDau, i] != 0)
                {
                    luuVet[i] = dinhDau;
                    Dfs(i);
                }
            }
        }
        public void duyetDFS(int dinhDau, int dinhCuoi)
        {
            for(int i = 0; i < soDinh; ++i)
            {
                visited[i] = 0;
                luuVet[i] = voCuc;
            }

            Dfs(dinhDau);

            if(visited[dinhCuoi] == 1)
            {
                int j = dinhCuoi;

                while(j != dinhDau)
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
