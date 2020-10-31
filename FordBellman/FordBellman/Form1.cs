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

namespace FordBellman
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

        void khoi_Tao_Ma_Tran()
        {
            for (int i = 0; i < 100; ++i)
            {
                for (int j = 0; j < 100; ++i)
                {
                    maTran[i, j] = 0;
                }
            }
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
            if (kiem_Tra_Khoang_Cach(e.X, e.Y))
            {
                point_Dinh[n_Point_Dinh] = new Point(e.X, e.Y);
                ++n_Point_Dinh;
                pb_Bang.Refresh();
            }
        }
        private void pb_Bang_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            SolidBrush br_MauTrang = new SolidBrush(Color.White);
            SolidBrush br_MauXanhDuong = new SolidBrush(Color.Blue);
            SolidBrush br_MauDen = new SolidBrush(Color.Black);

            Pen pen = new Pen(Color.Black, 2);

            lb_DSCanh.Items.Clear();
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (j > i)
                    {
                        if (maTran[i, j] != 0)
                        {
                            g.DrawLine(pen, point_Dinh[i], point_Dinh[j]);
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
                tb_MaTran.Text += "\r\n";
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
            if (tb_MaTran.Text != "")
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
            }
        }
    }
}
