using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    public class LienThong
    {
        public int[,] maTran = new int[100, 100];
        public int n_SoDinh = 0;
        public int[] visited = new int[100]; // visited[0] = 1, visited[1] = 1, visited[3] = 2
        public int n_SoMienLienThong = 0;

        public void doc_Ma_Tran (int[,] _MaTran , int soDinh)
        {
            n_SoDinh = soDinh;
            
            for(int i = 0; i < n_SoDinh; ++i)
            {
                for(int j = 0; j < n_SoDinh; ++j)
                {
                    maTran[i, j] = _MaTran[i, j];
                }
            }
        }
        public void visit(int i, int nLabel)
        {
            visited[i] = nLabel;
            
            for(int j = 0; j < n_SoDinh; ++j)
            {
                if(visited[j] == 0 && maTran[i, j] != 0)
                {
                    visit(j, nLabel);
                }
            }
        }
        public void xet_Thanh_Phan_Lien_Thong ()
        {
            for(int i = 0; i < n_SoDinh; ++i)
            {
                visited[i] = 0;
            }

            for(int i = 0; i < n_SoDinh; ++i)
            {
                if(visited[i] == 0)
                {
                    ++n_SoMienLienThong;
                    visit(i, n_SoMienLienThong);
                }
            }
        }
    }
}
