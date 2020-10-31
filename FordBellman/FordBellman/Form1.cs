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

        Point[] point_Dinh = new Point[100]; // Mang luu tru toa do cac dinh
        int n_Point_Dinh = 0; // So dinh
        int[,] maTran = new int[100, 100]; // Mang 2 chieu luu tru ma tran trong so
        String duong_Dan = ""; // Luu duong dan file

        // Ham khoi tao ma tran
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
        // Ham kiem tra khoang cach
        bool kiem_Tra_Khoang_Cach(int x, int y)
        {
            int x_Vector = 0, y_Vector = 0; // Khai báo, khoi tao toa do vector 
            int khoang_Cach = 0; // Khai bao, khoi tao bien do dai vector
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                x_Vector = Math.Abs(x - point_Dinh[i].X); // hoanh = hoanh cua A - hoang cua B
                y_Vector = Math.Abs(y - point_Dinh[i].Y); // tung = tung cua A - tung cua B
                khoang_Cach = (int)Math.Sqrt(Math.Pow(x_Vector, 2) + Math.Pow(y_Vector, 2)); // Tinh do dai vector
                if (khoang_Cach < 50) return false; // Neu do dai nho hon 50 => tra ve gia tri false
            }
            return true;
        }
        // Ham su kien click vao picture box
        private void pb_Bang_MouseClick(object sender, MouseEventArgs e)
        {
            if (kiem_Tra_Khoang_Cach(e.X, e.Y)) // Kiem tra khoang cách giua diem moi voi các diem khac
            {
                point_Dinh[n_Point_Dinh] = new Point(e.X, e.Y); // Them vao trong mang
                ++n_Point_Dinh; // Cong them 1 phan tu
                pb_Bang.Refresh(); // Load lai picture box
            }
        }
        // Ham su kien ve tren picture box
        private void pb_Bang_Paint(object sender, PaintEventArgs e)
        {
            Graphics g; // khai bao bien kieu graphics
            g = e.Graphics; // Cai nay kieu nhu cho phep bien g hoat dong trong picture box
            SolidBrush br_MauTrang = new SolidBrush(Color.White); // Mau nen la mau trang
            SolidBrush br_MauXanhDuong = new SolidBrush(Color.Blue); // Mau nen la mau xanh duong
            SolidBrush br_MauDen = new SolidBrush(Color.Black); // mau nen la mau den

            Pen pen = new Pen(Color.Black, 2); // Khai bao va khoi tao but ve

            lb_DSCanh.Items.Clear(); // Xoa het item trong list box chua canh
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (j > i)
                    {
                        if (maTran[i, j] != 0)
                        {
                            g.DrawLine(pen, point_Dinh[i], point_Dinh[j]); // Ve duong thang
                            g.FillEllipse(br_MauTrang, (point_Dinh[i].X + point_Dinh[j].X) / 2 - 10, (point_Dinh[i].Y + point_Dinh[j].Y) / 2 - 10, 20, 20); // Ve dinh
                            g.DrawString(maTran[i, j].ToString(), Font, br_MauDen, (point_Dinh[i].X + point_Dinh[j].X) / 2 - 5, (point_Dinh[i].Y + point_Dinh[j].Y) / 2 - 5); // Ve ten dinh

                            lb_DSCanh.Items.Add((i + 1).ToString() + "-" + (j + 1).ToString() + ": " + maTran[i, j].ToString()); // Add canh vao trong list box chua canh
                        }
                    }
                }
            }

            tb_DinhDau.Text = ""; // Xoa chuoi trong textbox dinh dau
            tb_DinhCuoi.Text = ""; // Xoa chuoi trong textbox dinh cuoi
            tb_TrongSo.Text = ""; // Xoa chuoi trong textbox trong so
            tb_DinhDau.Refresh(); // Load lai textbox dinh dau
            tb_DinhCuoi.Refresh(); // Load lai textbox dinh cuoi
            tb_TrongSo.Refresh(); // Load lai textbox trong so

            lb_DSDinh.Items.Clear(); // Xoa tat ca item trong list box chua dinh
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                g.FillEllipse(br_MauXanhDuong, point_Dinh[i].X - 10, point_Dinh[i].Y - 10, 20, 20); // Ve dinh
                g.DrawString((i + 1).ToString(), Font, br_MauTrang, point_Dinh[i].X - 5, point_Dinh[i].Y - 5); // Ve ten dinh

                lb_DSDinh.Items.Add("Dinh: " + (i + 1).ToString()); // Add dinh vao trong list box chua dinh
            }

            tb_MaTran.Text = n_Point_Dinh.ToString() + "\r\n"; // them so dinh vào trong textbox ma tran
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (j != 0) tb_MaTran.Text += " "; // Neu khong phai phan tu dau cua moi dong thi cach ra mot khoang
                    tb_MaTran.Text += maTran[i, j].ToString(); // them trong so vào trong textbox ma tran
                }
                tb_MaTran.Text += "\r\n"; // het vong lap cho xuong dong
            }
        }
        // Nut reset lai tu dau
        private void bt_Reset_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    maTran[i, j] = 0; // Cho mac dinh trong so trong ma tran bang 0
                }
            }

            duong_Dan = ""; // reset duong dan 
            tb_MaTran.Text = ""; // reset lai textbox ma tran

            n_Point_Dinh = 0; // reset lai so dinh lai bang 0
            pb_Bang.Refresh(); // Load lai picture box
        }
        // Ham xoa dinh bat ki có tham so la chi so cua dinh ta muon xoa
        void xoa_Phan_Tu_Trong_DS_Dinh(int index) // index la chi so cua dinh ma ta muon xoa
        {
            // Xoa trong so lien quan toi dinh ta muon xoa trong mang 2 chieu
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = index; j < n_Point_Dinh - 1; ++j)
                {
                    maTran[i, j] = maTran[i, j + 1];
                    maTran[j, i] = maTran[j + 1, i];
                }
            }

            // Xoa dinh trong mang 1 chieu
            for (int i = index; i < n_Point_Dinh - 1; ++i)
            {
                point_Dinh[i] = point_Dinh[i + 1];
            }

            // reset lai trong so o ngoai ria
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                maTran[i, n_Point_Dinh - 1] = 0;
                maTran[n_Point_Dinh - 1, i] = 0;
            }

            --n_Point_Dinh; // Giam di 1 dinh
        }
        // Nut xoa dinh
        private void bt_XoaDinh_Click(object sender, EventArgs e)
        {
            int index = -1; // Khai bao bien index khoi tao voi gia tri la -1
            string str = ""; // khai bao, khoi tao bien str kieu chuoi de lay chuoi trong danh sach dinh
            foreach (string item in lb_DSDinh.SelectedItems) // Vong lap for ko biet trc so luong phan tu
            {
                str = item; // lay ra chuoi da dc chon de xoa 
            }
            index = lb_DSDinh.Items.IndexOf(str); // gan cho index chi so cua phan tu chua chuoi da dc chon
            lb_DSDinh.Items.Remove(str); // Xoa chuoi do ra khoi listbox chua dinh
            if (index != -1) // Neu co phan tu dc chon de xoa
            {
                xoa_Phan_Tu_Trong_DS_Dinh(index); // Thuc hien ham xoa dinh va canh co lien quan ma ta muon xoa
                pb_Bang.Refresh(); // Load lai picturebox
            }
        }
        // Nut thiet lap / thay doi trong so
        private void bt_Set_DoiTrongSo_Click(object sender, EventArgs e)
        {
            int dinhDau = 0, dinhCuoi = 0, trongSo = 0; // Khai bao va khoi tao
            if (tb_DinhDau.Text != "" && tb_DinhCuoi.Text != "" && tb_TrongSo.Text != "") // Neu 3 textbox dc dien day du thi chay
            {
                // Chuyen kieu chuoi sang kieu so nguyen
                bool check_DinhDau = int.TryParse(tb_DinhDau.Text, out dinhDau);
                bool check_DinhCuoi = int.TryParse(tb_DinhCuoi.Text, out dinhCuoi);
                bool check_TrongSo = int.TryParse(tb_TrongSo.Text, out trongSo);

                // Gan trong so vao phan tu trong mang 2 chieu cua ma tran
                maTran[dinhDau - 1, dinhCuoi - 1] = trongSo;
                maTran[dinhCuoi - 1, dinhDau - 1] = trongSo;

            }
            pb_Bang.Refresh(); // Load lai picturebox

        }
        // Nut xoa canh
        private void bt_XoaCanh_Click(object sender, EventArgs e)
        {
            string str = ""; // Khai bao va khoi tao chuoi
            foreach (string item in lb_DSCanh.SelectedItems)
            {
                str = item; // Lay ra chuoi da dc chon 
            }
            if (str != "") // Neu co chuoi dc chon thi cho chay
            {
                // Khai bao va khoi tao 
                string dinhDau_Str = "";
                string dinhCuoi_Str = "";
                int dem = 1; // 1 la dinh dau, 2 la dinh cuoi

                // Phan tich, tach de lay dinh dau, dinh cuoi va trong so trong chuoi ma ta muon xoa
                for (int i = 0; i < str.Length; ++i)
                {
                    if (str[i] == '-') // Neu la ki tu '-' => ta nhap vao dinh cuoi
                    {
                        ++dem;
                        continue; // tiep tuc vong lap
                    }
                    if (str[i] == ':') break; // Thoat ra khoi vong lap
                    if (dem == 1) dinhDau_Str += str[i]; // Gan vao chuoi dinh dau
                    if (dem == 2) dinhCuoi_Str += str[i]; // Gan vao chuoi dinh cuoi
                }

                // Khai báo va khoi tao
                int dinhDau = 0, dinhCuoi = 0;

                // Chuyen tu dang chuoi sang dang so nguyen
                bool check_DinhDau = int.TryParse(dinhDau_Str, out dinhDau);
                bool check_DinhCuoi = int.TryParse(dinhCuoi_Str, out dinhCuoi);

                // Set cho trong so giua 2 dinh bang 0
                maTran[dinhDau - 1, dinhCuoi - 1] = 0;
                maTran[dinhCuoi - 1, dinhDau - 1] = 0;

                pb_Bang.Refresh(); // Load lai picture box
            }
        }
        // Mo file (phan nay ko can de y nhieu)
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
        // Save file (Phan nay cung ko can de y nhieu)
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
        // Luu vao File moi (Cung ko can de y nhieu)
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
        // Nut doc ma tran va ve do thi len picture box
        private void bt_DocMaTran_Click(object sender, EventArgs e)
        {
            if (tb_MaTran.Text != "") // Cai nay hoi sai mot chut, nhung ma no van chay dc nen dung de y nhieu, tui se fix lai sau
            {
                int temp = 0; // khai bao, khoi tao bien tam de luu so phan tu

                if (duong_Dan != "") // Neu da co duong dan
                {
                    // Phan nay ko bien command sao, chac nhu nay da la command roi nhi, hihi
                    StreamReader read = new StreamReader(duong_Dan.Trim());
                    string dong = "";
                    dong = read.ReadLine();
                    bool check_n = int.TryParse(dong, out temp);

                    // Khai bao mang kieu chuoi de chua trong so khi doc ma tran
                    string[] str = new string[100];
                    for (int i = 0; i < temp; ++i)
                    {
                        dong = read.ReadLine();
                        str = dong.Split(new char[] { ' ' }); // Tach tung trong so ra khoi chuoi

                        // Phan nay la chuyen trong so tu kieu chuoi sang kieu so nguyen roi gan vao mang chua trong so cua ma tran
                        for (int j = 0; j < temp; ++j)
                        {
                            int _temp = 0;
                            string s = str[j];
                            bool check = int.TryParse(s, out _temp);
                            if (check) maTran[i, j] = _temp;
                        }
                    }
                    read.Close(); // Dong lai

                    Random rd = new Random(); // Khai bao bien co kieu random
                    while (n_Point_Dinh < temp)
                    {
                        point_Dinh[n_Point_Dinh].X = rd.Next(50, 594); // Random toa do x
                        point_Dinh[n_Point_Dinh].Y = rd.Next(50, 510); // Random toa do y
                        if (n_Point_Dinh != 0) // Neu trong mang da co dinh thi cho chay
                        {
                            // Neu vi tri cua dinh vua moi random ko thoa thi quay lai random lai, nguoc lai neu thoa thi cho qua
                            if (kiem_Tra_Khoang_Cach(point_Dinh[n_Point_Dinh].X, point_Dinh[n_Point_Dinh].Y) == false) continue;
                        }
                        ++n_Point_Dinh; // them 1 dinh
                    }
                    pb_Bang.Refresh(); // Load lai picturebox

                }
            }
        }
    }
}
