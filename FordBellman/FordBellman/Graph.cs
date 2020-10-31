using System;
using System.Collections.Generic;
using System.Linq;
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
        public int [,] _iMatrix;

        public void setValue(int so_dinh, int[,] ma_tran)
        {
            _iDinh = so_dinh;
            _iMatrix = ma_tran;
        }

        public void getDFS()
        {

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
                        iKhoanCach[v] = iKhoanCach[u] + _iTrongSo;
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
                    return;
                }
            }
        }

    }
}
