using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;
using System.CodeDom.Compiler;

namespace Graph_Theory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point[] point_Dinh = new Point[100];
        int n_Point_Dinh = 0;
        int[,] maTran = new int[100, 100];
        String duong_Dan = "";
        Dijkstra dijkstra = new Dijkstra();
        LienThong lienThong = new LienThong();
        DFS dfs = new DFS();
        BFS bfs = new BFS();
        int temp = -1;

        bool kiem_Tra_Do_Thi_Vo_Huong()
        {
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (maTran[i, j] != maTran[j, i]) return false;
                }
            }
            return true;
        }
        bool kiem_Tra_Tinh_Hop_Le_Cua_Ma_Tran()
        {
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                if (maTran[i, i] != 0) return false;
            }
            return true;
        }
        void khoi_Tao_Ma_Tran()
        {
            for (int i = 0; i < 100; ++i)
            {
                for (int j = 0; j < 100; ++j)
                {
                    maTran[i, j] = 0;
                }
            }
            n_Point_Dinh = 0;
        }
        bool kiem_Tra_Khoang_Cach(int x, int y)
        {
            int x_Vector = 0, y_Vector = 0;
            int khoang_Cach = 0;
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                x_Vector = Math.Abs(x - point_Dinh[i].X);
                y_Vector = Math.Abs(y - point_Dinh[i].Y);
                khoang_Cach = (int)Math.Sqrt(Math.Pow(x_Vector, 2) + Math.Pow(y_Vector, 2));
                if (khoang_Cach < 50) return false;
            }
            return true;
        }
        private void pb_Bang_MouseClick(object sender, MouseEventArgs e)
        {
            string chonDinh = "";
            foreach (string item in lb_DSDinh.SelectedItems)
            {
                chonDinh = item;
            }

            if (chonDinh != "")
            {
                int index = lb_DSDinh.Items.IndexOf(chonDinh);
                if (kiem_Tra_Khoang_Cach(e.X, e.Y))
                {
                    point_Dinh[index] = new Point(e.X, e.Y);
                    pb_Bang.Refresh();
                }
            }
            else
            {
                if (kiem_Tra_Khoang_Cach(e.X, e.Y))
                {
                    point_Dinh[n_Point_Dinh] = new Point(e.X, e.Y);
                    ++n_Point_Dinh;
                    pb_Bang.Refresh();
                }
            }
        }
        private void pb_Bang_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush br_MauTrang = new SolidBrush(Color.White);
            SolidBrush br_MauXanhDuong = new SolidBrush(Color.Blue);
            SolidBrush br_MauDen = new SolidBrush(Color.Black);
            SolidBrush br_MauDo = new SolidBrush(Color.Red);
            SolidBrush[] arr_Br = { new SolidBrush(Color.Red), new SolidBrush(Color.Blue), new SolidBrush(Color.Yellow), new SolidBrush(Color.Purple), new SolidBrush(Color.Green) };
            Pen[] arr_Pen = { new Pen(Color.Red, 3), new Pen(Color.Blue, 3), new Pen(Color.Yellow, 3), new Pen(Color.Purple, 3), new Pen(Color.Green) };
            int bien_Mau = 0;

            Pen pen_Black = new Pen(Color.Black, 3);
            Pen pen_Red = new Pen(Color.Red, 3);

            lb_DSCanh.Items.Clear();
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (j > i)
                    {
                        if (maTran[i, j] != 0 && maTran[i, j] == maTran[j, i])
                        {
                            g.DrawLine(pen_Black, point_Dinh[i], point_Dinh[j]);
                            g.FillEllipse(br_MauTrang, (point_Dinh[i].X + point_Dinh[j].X) / 2 - 10, (point_Dinh[i].Y + point_Dinh[j].Y) / 2 - 10, 20, 20);
                            g.DrawString(maTran[i, j].ToString(), Font, br_MauDen, (point_Dinh[i].X + point_Dinh[j].X) / 2 - 5, (point_Dinh[i].Y + point_Dinh[j].Y) / 2 - 5);

                            lb_DSCanh.Items.Add((i + 1).ToString() + "-" + (j + 1).ToString() + ": " + maTran[i, j].ToString());
                        }
                    }
                }
            }

            tb_DinhDau.Text = "";
            tb_DinhCuoi.Text = "";
            tb_TrongSo.Text = "";
            tb_DinhDau.Refresh();
            tb_DinhCuoi.Refresh();
            tb_TrongSo.Refresh();


            lb_DSDinh.Items.Clear();
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                g.FillEllipse(br_MauXanhDuong, point_Dinh[i].X - 10, point_Dinh[i].Y - 10, 20, 20);
                g.DrawString((i + 1).ToString(), Font, br_MauTrang, point_Dinh[i].X - 5, point_Dinh[i].Y - 5);

                lb_DSDinh.Items.Add("Dinh: " + (i + 1).ToString());
            }

            tb_MaTran.Text = n_Point_Dinh.ToString() + "\r\n";
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (j != 0) tb_MaTran.Text += " ";
                    tb_MaTran.Text += maTran[i, j].ToString();
                }
                if (i != n_Point_Dinh - 1) tb_MaTran.Text += "\r\n";
            }

            if (dijkstra.id != 0)
            {
                for (int i = dijkstra.id; i >= 0; --i)
                {
                    if (i == dijkstra.id)
                    {
                        tb_KetQuaDijkstra.Text += (dijkstra.duongDi[i] + 1).ToString();

                        g.FillEllipse(br_MauDo, point_Dinh[dijkstra.duongDi[i]].X - 10, point_Dinh[dijkstra.duongDi[i]].Y - 10, 20, 20);
                        g.DrawString((dijkstra.duongDi[i] + 1).ToString(), Font, br_MauTrang, point_Dinh[dijkstra.duongDi[i]].X - 5, point_Dinh[dijkstra.duongDi[i]].Y - 5);

                    }
                    else
                    {
                        tb_KetQuaDijkstra.Text += " ---> " + (dijkstra.duongDi[i] + 1).ToString();

                        g.DrawLine(pen_Red, point_Dinh[dijkstra.duongDi[i + 1]], point_Dinh[dijkstra.duongDi[i]]);
                        g.FillEllipse(br_MauDo, point_Dinh[dijkstra.duongDi[i + 1]].X - 10, point_Dinh[dijkstra.duongDi[i + 1]].Y - 10, 20, 20);
                        g.FillEllipse(br_MauDo, point_Dinh[dijkstra.duongDi[i]].X - 10, point_Dinh[dijkstra.duongDi[i]].Y - 10, 20, 20);

                        g.DrawString((dijkstra.duongDi[i] + 1).ToString(), Font, br_MauTrang, point_Dinh[dijkstra.duongDi[i]].X - 5, point_Dinh[dijkstra.duongDi[i]].Y - 5);
                        g.DrawString((dijkstra.duongDi[i + 1] + 1).ToString(), Font, br_MauTrang, point_Dinh[dijkstra.duongDi[i + 1]].X - 5, point_Dinh[dijkstra.duongDi[i + 1]].Y - 5);


                        g.FillEllipse(br_MauTrang, (point_Dinh[dijkstra.duongDi[i + 1]].X + point_Dinh[dijkstra.duongDi[i]].X) / 2 - 10, (point_Dinh[dijkstra.duongDi[i + 1]].Y + point_Dinh[dijkstra.duongDi[i]].Y) / 2 - 10, 20, 20);
                        g.DrawString(maTran[dijkstra.duongDi[i], dijkstra.duongDi[i + 1]].ToString(), Font, br_MauDen, (point_Dinh[dijkstra.duongDi[i + 1]].X + point_Dinh[dijkstra.duongDi[i]].X) / 2 - 5, (point_Dinh[dijkstra.duongDi[i + 1]].Y + point_Dinh[dijkstra.duongDi[i]].Y) / 2 - 5);

                    }
                    Application.DoEvents();
                    Thread.Sleep(1000);
                }
                dijkstra.id = 0;
            }

            if (lienThong.n_SoMienLienThong != 0)
            {
                for (int i = 1; i <= lienThong.n_SoMienLienThong; ++i)
                {
                    int dem = 0;
                    tb_KetQuaLienThong.Text += "Mien lien thong thu " + i.ToString() + ":\r\n";

                    for (int j = 0; j < lienThong.n_SoDinh; ++j)
                    {
                        if (lienThong.visited[j] == i)
                        {
                            if (dem == 0)
                            {
                                tb_KetQuaLienThong.Text += "\t" + (j + 1).ToString();
                                dem = 1;

                                temp = j;

                                g.FillEllipse(arr_Br[bien_Mau], point_Dinh[j].X - 10, point_Dinh[j].Y - 10, 20, 20);
                                g.DrawString((j + 1).ToString(), Font, br_MauTrang, point_Dinh[j].X - 5, point_Dinh[j].Y - 5);

                            }
                            else if (dem == 1)
                            {
                                tb_KetQuaLienThong.Text += " - " + (j + 1).ToString();

                                for (int ii = 0; ii < n_Point_Dinh; ++ii)
                                {
                                    if (maTran[j, ii] != 0)
                                    {
                                        g.DrawLine(arr_Pen[bien_Mau], point_Dinh[ii], point_Dinh[j]);

                                        g.FillEllipse(arr_Br[bien_Mau], point_Dinh[ii].X - 10, point_Dinh[ii].Y - 10, 20, 20);
                                        g.FillEllipse(arr_Br[bien_Mau], point_Dinh[j].X - 10, point_Dinh[j].Y - 10, 20, 20);
                                        g.FillEllipse(br_MauTrang, (point_Dinh[ii].X + point_Dinh[j].X) / 2 - 10, (point_Dinh[ii].Y + point_Dinh[j].Y) / 2 - 10, 20, 20);

                                        g.DrawString((ii + 1).ToString(), Font, br_MauTrang, point_Dinh[ii].X - 5, point_Dinh[ii].Y - 5);
                                        g.DrawString((j + 1).ToString(), Font, br_MauTrang, point_Dinh[j].X - 5, point_Dinh[j].Y - 5);
                                        g.DrawString((maTran[ii, j]).ToString(), Font, br_MauDen, (point_Dinh[ii].X + point_Dinh[j].X) / 2 - 5, (point_Dinh[ii].Y + point_Dinh[j].Y) / 2 - 5);
                                    }
                                }
                            }
                        }
                    }
                    bien_Mau++;
                    tb_KetQuaLienThong.Text += "\r\n";
                }
                bien_Mau = 0;
                lienThong.n_SoMienLienThong = 0;
            }

            if (dfs.index != 0)
            {
                int[] a_dfs = new int[100];
                int n_a_dfs = 0;
                bool check = false;
                int dinhDau = 0, dinhCuoi = 0;

                check = int.TryParse(tb_DinhDauDB.Text, out dinhDau);
                check = int.TryParse(tb_DinhCuoiDB.Text, out dinhCuoi);

                --dinhDau;
                --dinhCuoi;

                int j = dinhCuoi;

                while (j != dinhDau)
                {
                    a_dfs[n_a_dfs++] = j;
                    j = dfs.luuVet[j];
                }
                a_dfs[n_a_dfs++] = dinhDau;

                int dem = 1;

                for (int i = 0; i < n_a_dfs; ++i)
                {
                    if (dem == 1)
                    {
                        g.FillEllipse(br_MauDo, point_Dinh[a_dfs[i]].X - 10, point_Dinh[a_dfs[i]].Y - 10, 20, 20);
                        g.DrawString((a_dfs[i] + 1).ToString(), Font, br_MauTrang, point_Dinh[a_dfs[i]].X - 5, point_Dinh[a_dfs[i]].Y - 5);

                        dem = 2;
                    }
                    else
                    {
                        g.DrawLine(pen_Red, point_Dinh[a_dfs[i - 1]], point_Dinh[a_dfs[i]]);

                        g.FillEllipse(br_MauDo, point_Dinh[a_dfs[i - 1]].X - 10, point_Dinh[a_dfs[i - 1]].Y - 10, 20, 20);
                        g.FillEllipse(br_MauDo, point_Dinh[a_dfs[i]].X - 10, point_Dinh[a_dfs[i]].Y - 10, 20, 20);
                        g.FillEllipse(br_MauTrang, (point_Dinh[a_dfs[i - 1]].X + point_Dinh[a_dfs[i]].X) / 2 - 10, (point_Dinh[a_dfs[i - 1]].Y + point_Dinh[a_dfs[i]].Y) / 2 - 10, 20, 20);

                        g.DrawString((a_dfs[i - 1] + 1).ToString(), Font, br_MauTrang, point_Dinh[a_dfs[i - 1]].X - 5, point_Dinh[a_dfs[i - 1]].Y - 5);
                        g.DrawString((a_dfs[i] + 1).ToString(), Font, br_MauTrang, point_Dinh[a_dfs[i]].X - 5, point_Dinh[a_dfs[i]].Y - 5);
                        g.DrawString(maTran[a_dfs[i - 1], a_dfs[i]].ToString(), Font, br_MauDen, (point_Dinh[a_dfs[i - 1]].X + point_Dinh[a_dfs[i]].X) / 2 - 5, (point_Dinh[a_dfs[i - 1]].Y + point_Dinh[a_dfs[i]].Y) / 2 - 5);
                    }
                }

                dfs.index = 0;

                pb_Bang.Refresh();
            }

            if (bfs.index != 0)
            {
                int[] a_bfs = new int[100];
                int n_a_bfs = 0;
                bool check = false;
                int dinhDau = 0, dinhCuoi = 0;

                check = int.TryParse(tb_DinhDauDB.Text, out dinhDau);
                check = int.TryParse(tb_DinhCuoiDB.Text, out dinhCuoi);

                --dinhDau;
                --dinhCuoi;

                int j = dinhCuoi;

                while (j != dinhDau)
                {
                    a_bfs[n_a_bfs++] = j;
                    j = bfs.luuVet[j];
                }
                a_bfs[n_a_bfs++] = dinhDau;

                int dem = 1;

                for (int i = 0; i < n_a_bfs; ++i)
                {
                    if (dem == 1)
                    {
                        g.FillEllipse(br_MauDo, point_Dinh[a_bfs[i]].X - 10, point_Dinh[a_bfs[i]].Y - 10, 20, 20);
                        g.DrawString((a_bfs[i] + 1).ToString(), Font, br_MauTrang, point_Dinh[a_bfs[i]].X - 5, point_Dinh[a_bfs[i]].Y - 5);

                        dem = 2;
                    }
                    else
                    {
                        g.DrawLine(pen_Red, point_Dinh[a_bfs[i - 1]], point_Dinh[a_bfs[i]]);

                        g.FillEllipse(br_MauDo, point_Dinh[a_bfs[i - 1]].X - 10, point_Dinh[a_bfs[i - 1]].Y - 10, 20, 20);
                        g.FillEllipse(br_MauDo, point_Dinh[a_bfs[i]].X - 10, point_Dinh[a_bfs[i]].Y - 10, 20, 20);
                        g.FillEllipse(br_MauTrang, (point_Dinh[a_bfs[i - 1]].X + point_Dinh[a_bfs[i]].X) / 2 - 10, (point_Dinh[a_bfs[i - 1]].Y + point_Dinh[a_bfs[i]].Y) / 2 - 10, 20, 20);

                        g.DrawString((a_bfs[i - 1] + 1).ToString(), Font, br_MauTrang, point_Dinh[a_bfs[i - 1]].X - 5, point_Dinh[a_bfs[i - 1]].Y - 5);
                        g.DrawString((a_bfs[i] + 1).ToString(), Font, br_MauTrang, point_Dinh[a_bfs[i]].X - 5, point_Dinh[a_bfs[i]].Y - 5);
                        g.DrawString(maTran[a_bfs[i - 1], a_bfs[i]].ToString(), Font, br_MauDen, (point_Dinh[a_bfs[i - 1]].X + point_Dinh[a_bfs[i]].X) / 2 - 5, (point_Dinh[a_bfs[i - 1]].Y + point_Dinh[a_bfs[i]].Y) / 2 - 5);
                    }
                }

                bfs.index = 0;

                pb_Bang.Refresh();
            }

        }
        private void bt_Reset_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    maTran[i, j] = 0;
                }
            }

            duong_Dan = "";
            tb_MaTran.Text = "";

            tb_KetQuaDijkstra.Text = "";
            dijkstra.id = 0;

            tb_DinhBatDau.Text = "";
            tb_DinhKetThuc.Text = "";

            tb_KetQuaLienThong.Text = "";
            lienThong.n_SoMienLienThong = 0;

            n_Point_Dinh = 0;
            pb_Bang.Refresh();
        }
        void xoa_Phan_Tu_Trong_DS_Dinh(int index)
        {
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = index; j < n_Point_Dinh - 1; ++j)
                {
                    maTran[i, j] = maTran[i, j + 1];
                    maTran[j, i] = maTran[j + 1, i];
                }
            }

            for (int i = index; i < n_Point_Dinh - 1; ++i)
            {
                point_Dinh[i] = point_Dinh[i + 1];
            }

            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                maTran[i, n_Point_Dinh - 1] = 0;
                maTran[n_Point_Dinh - 1, i] = 0;
            }

            --n_Point_Dinh;
        }
        private void bt_XoaDinh_Click(object sender, EventArgs e)
        {
            int index = -1;
            string str = "";
            foreach (string item in lb_DSDinh.SelectedItems)
            {
                str = item;
            }
            index = lb_DSDinh.Items.IndexOf(str);
            lb_DSDinh.Items.Remove(str);
            if (index != -1)
            {
                xoa_Phan_Tu_Trong_DS_Dinh(index);
                pb_Bang.Refresh();
            }
        }
        private void bt_Set_DoiTrongSo_Click(object sender, EventArgs e)
        {
            int dinhDau = 0, dinhCuoi = 0, trongSo = 0;
            if (tb_DinhDau.Text != "" && tb_DinhCuoi.Text != "" && tb_TrongSo.Text != "")
            {
                bool check_DinhDau = int.TryParse(tb_DinhDau.Text, out dinhDau);
                bool check_DinhCuoi = int.TryParse(tb_DinhCuoi.Text, out dinhCuoi);
                bool check_TrongSo = int.TryParse(tb_TrongSo.Text, out trongSo);

                maTran[dinhDau - 1, dinhCuoi - 1] = trongSo;
                maTran[dinhCuoi - 1, dinhDau - 1] = trongSo;

            }
            pb_Bang.Refresh();

        }
        private void bt_XoaCanh_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (string item in lb_DSCanh.SelectedItems)
            {
                str = item;
            }
            if (str != "")
            {
                string dinhDau_Str = "";
                string dinhCuoi_Str = "";
                int dem = 1;

                for (int i = 0; i < str.Length; ++i)
                {
                    if (str[i] == '-')
                    {
                        ++dem;
                        continue;
                    }
                    if (str[i] == ':') break;
                    if (dem == 1) dinhDau_Str += str[i];
                    if (dem == 2) dinhCuoi_Str += str[i];
                }

                int dinhDau = 0, dinhCuoi = 0;

                bool check_DinhDau = int.TryParse(dinhDau_Str, out dinhDau);
                bool check_DinhCuoi = int.TryParse(dinhCuoi_Str, out dinhCuoi);

                maTran[dinhDau - 1, dinhCuoi - 1] = 0;
                maTran[dinhCuoi - 1, dinhDau - 1] = 0;

                pb_Bang.Refresh();
            }
        }
        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                duong_Dan = open.FileName;
                StreamReader read = new StreamReader(open.FileName);
                tb_MaTran.Text = read.ReadToEnd();
                read.Close();
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                duong_Dan = open.FileName;
                StreamWriter write = new StreamWriter(duong_Dan.Trim());
                write.WriteLine(tb_MaTran.Text);
                write.Close();
                MessageBox.Show("Da luu.");
            }


        }
        private void saveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "|*.txt";
            save.RestoreDirectory = true;
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(save.FileName);
                write.WriteLine(tb_MaTran.Text);
                write.Close();
            }
        }
        private void bt_DocMaTran_Click(object sender, EventArgs e)
        {
            dijkstra.id = 0;
            lienThong.n_SoMienLienThong = 0;
            n_Point_Dinh = 0;
            tb_KetQuaDijkstra.Text = "";
            tb_KetQuaLienThong.Text = "";

            if (tb_MaTran.Text != "0\r\n")
            {

                int temp = 0;

                if (duong_Dan != "")
                {
                    StreamReader read = new StreamReader(duong_Dan.Trim());
                    string dong = "";
                    dong = read.ReadLine();
                    bool check_n = int.TryParse(dong, out temp);
                    string[] str = new string[100];
                    for (int i = 0; i < temp; ++i)
                    {
                        dong = read.ReadLine();
                        str = dong.Split(new char[] { ' ' });
                        for (int j = 0; j < temp; ++j)
                        {
                            int _temp = 0;
                            string s = str[j];
                            bool check = int.TryParse(s, out _temp);
                            if (check) maTran[i, j] = _temp;
                        }
                    }
                    read.Close();
                    duong_Dan = "";
                }
                else
                {
                    string dong = "";
                    dong = tb_MaTran.Text;
                    bool check = int.TryParse(dong[0].ToString(), out temp);
                    check = false;

                    int k = 0;
                    string[] str = new string[100];
                    dong = "";

                    for (int i = 3; i < tb_MaTran.Text.Length; ++i)
                    {
                        if (tb_MaTran.Text[i] != '\r')
                        {
                            dong += tb_MaTran.Text[i];
                        }
                        else
                        {
                            str = dong.Split(new char[] { ' ' });
                            for (int j = 0; j < temp; ++j)
                            {
                                check = int.TryParse(str[j], out maTran[k, j]);
                            }
                            ++i;
                            ++k;
                            dong = "";
                        }

                        if (i == tb_MaTran.Text.Length - 1)
                        {
                            str = dong.Split(new char[] { ' ' });
                            for (int j = 0; j < temp; ++j)
                            {
                                check = int.TryParse(str[j], out maTran[k, j]);
                            }
                            ++i;
                            ++k;
                            dong = "";
                        }
                    }
                }
                n_Point_Dinh = temp;
                if (kiem_Tra_Tinh_Hop_Le_Cua_Ma_Tran() && kiem_Tra_Do_Thi_Vo_Huong())
                {
                    n_Point_Dinh = 0;
                    Random rd = new Random();
                    while (n_Point_Dinh < temp)
                    {
                        point_Dinh[n_Point_Dinh].X = rd.Next(50, 594);
                        point_Dinh[n_Point_Dinh].Y = rd.Next(50, 510);
                        if (n_Point_Dinh != 0)
                        {
                            if (kiem_Tra_Khoang_Cach(point_Dinh[n_Point_Dinh].X, point_Dinh[n_Point_Dinh].Y) == false) continue;
                        }
                        ++n_Point_Dinh;
                    }
                    pb_Bang.Refresh();
                }
                else
                {
                    MessageBox.Show("Kiem tra lai ma tran.");
                }
            }
        }
        private void bt_Dijkstra_Click(object sender, EventArgs e)
        {
            lienThong.n_SoMienLienThong = 0;
            lienThong.doc_Ma_Tran(maTran, n_Point_Dinh);
            lienThong.xet_Thanh_Phan_Lien_Thong();

            if (lienThong.n_SoMienLienThong == 1)
            {
                lienThong.n_SoMienLienThong = 0;
                tb_KetQuaDijkstra.Text = "";
                dijkstra.id = 0;
                if (n_Point_Dinh != 0)
                {
                    dijkstra.docMaTran(maTran, n_Point_Dinh);
                    if (tb_DinhBatDau.Text != "" && tb_DinhKetThuc.Text != "")
                    {
                        bool check = false;
                        int dinhBatDau = 0, dinhKetThuc = 0;
                        check = int.TryParse(tb_DinhBatDau.Text, out dinhBatDau);
                        check = int.TryParse(tb_DinhKetThuc.Text, out dinhKetThuc);

                        if (dinhBatDau == 0 || dinhBatDau > n_Point_Dinh || dinhKetThuc == 0 || dinhKetThuc > n_Point_Dinh)
                        {
                            MessageBox.Show("Dinh khong hop le.\nXin vui long nhap lai.");
                            tb_DinhBatDau.Text = "";
                            tb_DinhKetThuc.Text = "";
                        }
                        else
                        {
                            dijkstra.dijkstra(dinhBatDau, dinhKetThuc);
                            dijkstra.xuat(dinhBatDau, dinhKetThuc);
                            //temp = dijkstra.id;
                            pb_Bang.Refresh();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Do thi dang xet khong phai la do thi lien thong.");
            }

        }
        private void tb_KiemTraMaTran_Click(object sender, EventArgs e)
        {
            string dong = tb_MaTran.Text;
            string loc = "";
            string[] str = new string[100];
            bool check = false;
            khoi_Tao_Ma_Tran();

            check = int.TryParse(dong[0].ToString(), out n_Point_Dinh);
            int j = 0;

            for (int i = 3; i < dong.Length; ++i)
            {
                if (dong[i] == '\r')
                {
                    str = loc.Split(new char[] { ' ' });

                    for (int k = 0; k < n_Point_Dinh; ++k)
                    {
                        check = int.TryParse(str[k], out maTran[j, k]);

                    }
                    loc = "";
                    ++i;
                    ++j;
                }
                else
                {
                    loc += dong[i];
                }

                if (i == dong.Length - 1)
                {
                    str = loc.Split(new char[] { ' ' });

                    for (int k = 0; k < n_Point_Dinh; ++k)
                    {
                        check = int.TryParse(str[k], out maTran[j, k]);

                    }
                    loc = "";
                    ++i;
                    ++j;
                }
            }

            if (n_Point_Dinh == 0)
            {
                MessageBox.Show("Hien tai chua co ma tran.");
            }
            else if (n_Point_Dinh != 0)
            {
                if (kiem_Tra_Tinh_Hop_Le_Cua_Ma_Tran())
                {
                    if (kiem_Tra_Do_Thi_Vo_Huong())
                    {
                        MessageBox.Show("Ma tran hop le.\nLa do thi vo huong.");
                    }
                    else
                    {
                        MessageBox.Show("Ma tran hop le.\nKhong phai la do thi vo huong.");
                    }
                }
                else
                {
                    MessageBox.Show("Ma tran khong hop le.");
                }
            }
        }
        private void tb_XetLienThong_Click(object sender, EventArgs e)
        {
            tb_KetQuaLienThong.Text = "";

            string dong = "";
            bool check = false;
            string[] str = new string[100];
            int k = 0;

            check = int.TryParse(tb_MaTran.Text[0].ToString(), out n_Point_Dinh);

            for (int i = 3; i < tb_MaTran.Text.Length; ++i)
            {
                if (tb_MaTran.Text[i] == '\r')
                {
                    str = dong.Split(new char[] { ' ' });

                    for (int j = 0; j < n_Point_Dinh; ++j)
                    {
                        check = int.TryParse(str[j], out maTran[k, j]);
                    }

                    ++k;
                    ++i;
                    dong = "";
                }
                else
                {
                    dong += tb_MaTran.Text[i];
                }
            }

            lienThong.doc_Ma_Tran(maTran, n_Point_Dinh);
            lienThong.xet_Thanh_Phan_Lien_Thong();

            if (lienThong.n_SoMienLienThong != 0)
            {
                if (lienThong.n_SoMienLienThong > 1)
                {
                    tb_KetQuaLienThong.Text += "Do thi khong lien thong.\r\n";
                }
                else
                {
                    tb_KetQuaLienThong.Text += "Do thi dang xet la do thi lien thong.\r\n";
                }

                tb_KetQuaLienThong.Text += "Co " + lienThong.n_SoMienLienThong.ToString() + " mien lien thong:\r\n";

                pb_Bang.Refresh();
            }
        }
        private void bt_DFS_Click(object sender, EventArgs e)
        {
            tb_KetQuaDB.Text = "";

            dfs.doc_Ma_Tran(maTran, n_Point_Dinh);

            if (tb_DinhDauDB.Text != "" && tb_DinhCuoiDB.Text != "")
            {
                bool check = false;
                int dinhDau = 0, dinhCuoi = 0;

                check = int.TryParse(tb_DinhDauDB.Text, out dinhDau);
                check = int.TryParse(tb_DinhCuoiDB.Text, out dinhCuoi);

                if (dinhDau == 0 || dinhCuoi == 0 || dinhDau > n_Point_Dinh || dinhCuoi > n_Point_Dinh)
                {
                    MessageBox.Show("Dinh khong hop le.");
                }
                else
                {
                    --dinhDau;
                    --dinhCuoi;
                    dfs.duyetDFS(dinhDau, dinhCuoi);

                    if (dfs.index == 0)
                    {
                        MessageBox.Show("Khong co duong di tu dinh " + (dinhDau + 1).ToString() + " den dinh " + (dinhCuoi + 1).ToString() + ".");
                    }
                    else
                    {
                        int j = dinhCuoi;
                        while (j != dinhDau)
                        {
                            tb_KetQuaDB.Text += (j + 1).ToString() + " <--- ";
                            j = dfs.luuVet[j];
                        }
                        tb_KetQuaDB.Text += (dinhDau + 1).ToString();

                        pb_Bang.Refresh();
                    }
                }
            }
        }
        private void bt_BFS_Click(object sender, EventArgs e)
        {
            tb_KetQuaDB.Text = "";

            bfs.doc_Ma_Tran(maTran, n_Point_Dinh);

            if (tb_DinhDauDB.Text != "" && tb_DinhCuoiDB.Text != "")
            {
                bool check = false;
                int dinhDau = 0, dinhCuoi = 0;

                check = int.TryParse(tb_DinhDauDB.Text, out dinhDau);
                check = int.TryParse(tb_DinhCuoiDB.Text, out dinhCuoi);

                if (dinhDau == 0 || dinhCuoi == 0 || dinhDau > n_Point_Dinh || dinhCuoi > n_Point_Dinh)
                {
                    MessageBox.Show("Dinh khong hop le.");
                }
                else
                {
                    --dinhDau;
                    --dinhCuoi;
                    bfs.duyetBFS(dinhDau, dinhCuoi);

                    if (bfs.index == 0)
                    {
                        MessageBox.Show("Khong co duong di tu dinh " + (dinhDau + 1).ToString() + " den dinh " + (dinhCuoi + 1).ToString() + ".");
                    }
                    else
                    {
                        int j = dinhCuoi;
                        while (j != dinhDau)
                        {
                            tb_KetQuaDB.Text += (j + 1).ToString() + " <--- ";
                            j = bfs.luuVet[j];
                        }
                        tb_KetQuaDB.Text += (dinhDau + 1).ToString();

                        pb_Bang.Refresh();
                    }
                }
            }
        }
    }
}
