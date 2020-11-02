using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    class Dijkstra
    {
        public int soDinh = 0;
        public int[,] maTran = new int[100, 100];
        public int voCuc = -1;
        public void docMaTran(int[,] _maTran, int _soDinh)
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

        public bool[] thuocT = new bool[100]; 
        public int[] length = new int[100];
        public int[] lastV = new int[100]; // lastV[3] = 2

        public void dijkstra(int dinhDau, int dinhCuoi)
        {
            int i = 0;
            --dinhDau;
            --dinhCuoi;

            for (i = 0; i < soDinh; ++i)
            {
                thuocT[i] = true;
                length[i] = voCuc;
                lastV[i] = -1;
            }

            length[dinhDau] = 0;
            thuocT[dinhDau] = false;
            lastV[dinhDau] = dinhDau;

            int v = dinhDau;
            int t = dinhDau;

            while (thuocT[dinhCuoi])
            {
                for (int k = 0; k < soDinh; ++k)
                {
                    if (maTran[v, k] != 0 && thuocT[k] == true && (length[k] == voCuc || length[k] > length[v] + maTran[v, k]))
                    {
                        length[k] = length[v] + maTran[v, k];
                        lastV[k] = v;
                    }
                }

                v = -1;

                for (i = 0; i < soDinh; ++i)
                {
                    if (thuocT[i] == true && length[i] != voCuc)
                    {
                        if (v == -1 || length[v] > length[i]) v = i;
                    }
                }
                thuocT[v] = false;
            }
        }

        public int[] duongDi = new int[100];
        public int id = 0;
        public void xuat(int dinhDau, int dinhCuoi)
        {
            --dinhDau;
            --dinhCuoi;
            int v = dinhCuoi;

            while (v != dinhDau)
            {
                duongDi[id] = v;
                v = lastV[v];
                ++id;
            }

            duongDi[id] = dinhDau;
        }
    }
}
