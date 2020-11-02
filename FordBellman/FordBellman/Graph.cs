using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FordBellman
{
    /// <summary>
    /// Class the hien dinh dau, dinh cuoi, trong so cua canh
    /// </summary>
    class Edge
    {
        public int _iDinhGoc, _iDinhCuoi, _iTrongSo;
        public Edge()
        {
            _iDinhGoc = _iDinhCuoi = _iTrongSo = 0;
        }
    };
    /// <summary>
    /// Cai dat ma tran trong so
    /// </summary>
    class WeightMatrix
    {
        int _iDinh { get; set; }
        int[] _iLuuVet;
        int[] _iVisited;
        public int [,] _iMatrix;
        Queue<int> result = new Queue<int>(0);
        public void setValue(int so_dinh, int[,] ma_tran)
        {
            _iDinh = so_dinh;
            _iMatrix = ma_tran;
        }

        void DFS(int start)
        {
            this._iVisited[start] = 1;

            for (int i = 0; i < this._iDinh; i++)
            {
                if (this._iVisited[i] == 0 && this._iMatrix[start,i] != 0)
                {
                    this._iLuuVet[i] = start; // Luu vi tri truoc i la s
                    DFS(i);
                }
            }
        }
        /// <summary>
        /// Goi ham tra ve Queue ds DFS
        /// </summary>
        /// <param name="s"></param> Dinh dau
        /// <param name="f"></param> DInh cuoi
        /// <returns></returns>
        public Queue<int> getDFS(int s, int f)
        {
            //Khoi tao gia tri dau
            for (int i = 0; i < this._iDinh; i++)
            {
                this._iVisited[i] = 0;
                this._iLuuVet[i] = -1;
            }

            DFS(s);

            if (this._iVisited[f] == 1)
            {
                int j = f;
                while( j!= s)
                {
                    result.Enqueue(j);
                    j = this._iLuuVet[j];
                }

            }
            else
            {
                return result;
            }
            return result;
        }
        /// <summary>
        /// Thuat toam BFS
        /// </summary>
        /// <param name="s"></param> Dinh bat dau
        void BFS(int s)
        {
            Queue<int> tmp = new Queue<int>(0);
            tmp.Enqueue(s);
            
            while (tmp.Count != 0)
            {
                this._iVisited[s] = 1;
                for (int i = 0; i < this._iDinh; i++)
                {
                    if (this._iVisited[i] == 0 && this._iMatrix[s,i] != 0)
                    {
                        tmp.Enqueue(i);
                        this._iLuuVet[i] = s;
                    }
                }
            }
        }
        /// <summary>
        /// Tra ve Queu BFS
        /// </summary>
        /// <param name="s"></param> Dinh dau
        /// <param name="f"></param> Dinh cuoi
        /// <returns></returns>
        public Queue<int> getBFS(int s, int f)
        {
            for (int i = 0; i < this._iDinh; i++)
            {
                this._iLuuVet[i] = 0;
                this._iVisited[i] = -1;
            }
                BFS(s);

            if (this._iVisited[f] == 1)
            {
                int j = f;
                while (j != s)
                {
                    result.Enqueue(j);
                    j = this._iLuuVet[j];
                }
            }
            else
            {
                return result;
            }
            return result;
        }
    };
    /// <summary>
    /// Class bieu dien dua tren ma tran trong so
    /// </summary>
    class MatrixFormat
    {

        int _iSoDinh, _iSoCanh;
        Edge[] _eEdge;
        /// <summary>
        /// Ham khoi tao MatrixFormat
        /// </summary>
        /// <param name="v"></param> So dinh
        /// <param name="e"></param> So canh
        MatrixFormat(int v, int e)
        {
            _iSoDinh = v; // So dinh
            _iSoCanh = e; // So canh
            _eEdge = new Edge[e];
            for (int i = 0; i < e; ++i)
            {
                _eEdge[i] = new Edge();
            }                
        }

        /// <summary>
        /// Tim duong di ngan nhat bang Ford Bellman \
        /// Thong bao co chu trinh am neu co
        /// </summary>
        /// <param name="graph"></param> Do thi
        /// <param name="_iDinhDau"></param> Dinh bat dau
        void setBellmanFord(MatrixFormat graph, int bat_dau)
        {
            int _iSoDinh = graph._iSoDinh, _iSoCanh = graph._iSoCanh;
            int[] iKhoanCach = new int[_iSoDinh];

            // Gan gia tri khoan cach la vo cuc
            // rieng tai bat_dau = 0;
            for (int i = 0; i < _iSoDinh; ++i)
            {
                iKhoanCach[i] = int.MaxValue;
            }
            iKhoanCach[bat_dau] = 0;

            // Chay Ford Bellman
            for (int i = 1; i < _iSoDinh; ++i)
            {
                for (int j = 0; j < _iSoCanh; ++j)
                {
                    int u = graph._eEdge[j]._iDinhGoc; // dinh ra u
                    int v = graph._eEdge[j]._iDinhCuoi; // dinh vao v
                    int _iTrongSo = graph._eEdge[j]._iTrongSo;
                    if (iKhoanCach[u] != int.MaxValue && iKhoanCach[u] + _iTrongSo < iKhoanCach[v])
                    {
                        iKhoanCach[v] = iKhoanCach[u] + _iTrongSo;
                    }
                }
            }

            // Kiem tra chu trinh am
            for (int j = 0; j < _iSoCanh; ++j)
            {
                int u = graph._eEdge[j]._iDinhGoc;
                int v = graph._eEdge[j]._iDinhCuoi;
                int _iTrongSo = graph._eEdge[j]._iTrongSo;
                if (iKhoanCach[u] != int.MaxValue && iKhoanCach[u] + _iTrongSo < iKhoanCach[v])
                {
                    /// out do thi co chu trinh am;
                    return;
                }
            }
            //out list<>=
        }
    }
}
