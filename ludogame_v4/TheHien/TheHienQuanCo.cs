using ludogame_v4.DuLieu;
using ludogame_v4.XuLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ludogame_v4.TheHien
{
    public partial class TheHienQuanCo : UserControl
    {
        public PictureBox picQC;

        private Point vtTheHien;

        private string strFileName;

        private bool StateClick;

        public DuLieuBanCo dlbc;

        public DuLieuUser User;

        public DuLieuQuanCo dlqc;



        public bool TrangThaiClick
        {
            get
            {
                return StateClick;
            }
            set
            {
                StateClick = value;
            }
        }

        public Point VitriTheHien
        {
            get
            {
                return vtTheHien;
            }
            set
            {
                vtTheHien = value;
            }
        }

        public TheHienQuanCo()
        {
            InitializeComponent();
            TrangThaiClick = false;
        }

        public TheHienQuanCo(Point p, int Mau)
        {
            InitializeComponent();
            LayHinhQuanCo(Mau);
            picQC.Location = new Point(p.X, p.Y);
            try
            {
                picQC.Image = new Bitmap(Application.StartupPath + "/hinhngua/" + strFileName + ".gif");
            }
            catch
            {
                MessageBox.Show("File Image khong tim thay");
            }
            TrangThaiClick = false;
        }





        public void picQC_Click(object sender, EventArgs e)
        {
            if (!TrangThaiClick || ThucHienNuocDi() != 1)
            {
                return;
            }
            TrangThaiClick = false;
            for (int i = 0; i < User.SoQuanCo; i++)
            {
                QuanCo quanCo = (QuanCo)User.arrQC[i];
                if (quanCo.QCTH.TrangThaiClick)
                {
                    quanCo.QCTH.TrangThaiClick = false;

                }
            }
            if (dlbc.gtXN1 != 1 && dlbc.gtXN1 != 6)
                UserTiepTheo();
        }



        public void UserTiepTheo()
        {
            dlbc.UserHienTai = dlbc.UserHienTai % dlbc.SoNguoichoi + 1;
        }

        public string LayHinhQuanCo(int m)
        {
            switch (m)
            {
                case 1:
                    strFileName = "Duong.gif";
                    break;
                case 2:
                    strFileName = "Do.gif";
                    break;
                case 3:
                    strFileName = "Vang.gif";
                    break;
                case 4:
                    strFileName = "Xanh.gif";
                    break;
            }
            return strFileName;
        }

        public void HienThi(int m)
        {
            LayHinhQuanCo(m);
            picQC.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + strFileName);
        }

        public void LoadImageQuanCo(Bitmap bmp)
        {
            picQC.Image = bmp;
        }

        LuuDuLieuSql Data = new LuuDuLieuSql();
        public int ThucHienNuocDi()
        {
            if (dlqc.ViTriTrenBanCo == -1)
            {
                if (KiemTraRaQuan() && dlbc.arrBC[dlqc.ViTriRaQuan] != dlqc.MauCo)
                {
                    if (dlbc.arrBC[dlqc.ViTriRaQuan] != 0)
                    {
                        DaQuan(dlqc.ViTriRaQuan);
                    }
                    dlqc.ViTriTrenBanCo = dlqc.ViTriRaQuan;
                    dlbc.arrBC[dlqc.ViTriTrenBanCo] = dlqc.MauCo;
                    dlqc.Count++;
                    BanCo banCo = new BanCo();
                    Point point = banCo.LayVT(dlqc.ViTriTrenBanCo);
                    picQC.Location = new Point(point.X, point.Y);
                    return 1;
                }
            }
            else
            {
                int num = dlbc.LayGiaTriXN();
                if (dlqc.ViTriTrenBanCo == dlqc.ViTriVeDich)
                {
                    if (KiemTraVeDich() && dlqc.Bac == 0)
                    {
                        int num2 = LaySoQuanVeDich();
                        DuLieuUser duLieuUser = (DuLieuUser)dlbc.arrUsers[dlqc.MauCo - 1];
                        Point point = duLieuUser.arrVtDich[5 - num2];
                        picQC.Location = new Point(point.X, point.Y);
                        dlbc.arrBC[dlqc.ViTriTrenBanCo] = 0;
                        duLieuUser.SoQuanVeDich++;
                        dlqc.Bac = 5 - num2;
                        Data.SaveScore(dlqc.MauCo, duLieuUser.SoQuanVeDich);
                        return 1;
                    }
                    return 0;
                }
                if (dlqc.Count + num > dlbc.SoOBc)
                {
                    return 0;
                }
                if (KiemTraDiDuoc(num, dlqc.ViTriTrenBanCo) && dlbc.arrBC[(dlqc.ViTriTrenBanCo + num) % 56] != dlqc.MauCo)
                {
                    if (dlbc.arrBC[(dlqc.ViTriTrenBanCo + num) % 56] != 0)
                    {
                        DaQuan((dlqc.ViTriTrenBanCo + num) % 56);
                    }
                    dlbc.arrBC[dlqc.ViTriTrenBanCo] = 0;
                    dlqc.ViTriTrenBanCo += num;
                    dlqc.ViTriTrenBanCo %= 56;
                    dlbc.arrBC[dlqc.ViTriTrenBanCo] = dlqc.MauCo;
                    dlqc.Count += dlbc.LayGiaTriXN();
                    BanCo banCo = new BanCo();
                    Point point = banCo.LayVT(dlqc.ViTriTrenBanCo);
                    picQC.Location = new Point(point.X, point.Y);
                    return 1;
                }
            }
            return 0;
        }

        public int KiemTraQuanCoDiDc() // Kiem tra có đi dc hay không
        {
            if (dlqc.ViTriTrenBanCo == -1)
            {
                if (KiemTraRaQuan() && dlbc.arrBC[dlqc.ViTriRaQuan] != dlqc.MauCo)
                {
 
                    return 1;
                }
            }
            else
            {
                int num = dlbc.LayGiaTriXN();
                if (dlqc.ViTriTrenBanCo == dlqc.ViTriVeDich)
                {
                    if (KiemTraVeDich() && dlqc.Bac == 0)
                    {    
                        return 1;
                    }
                    return 0;
                }
                if (dlqc.Count + num > dlbc.SoOBc)
                {
                    return 0;
                }
                if (KiemTraDiDuoc(num, dlqc.ViTriTrenBanCo) && dlbc.arrBC[(dlqc.ViTriTrenBanCo + num) % 56] != dlqc.MauCo)
                {                   
                    return 1;
                }
            }
            return 0;
        }

        public bool KiemTraRaQuan()
        {
            if (dlbc.SoXN == 1)
            {
                if (dlbc.gtXN1 == dlbc.gtRQ1 || dlbc.gtXN1 == dlbc.gtRQ2)
                {
                    return true;
                }
            }
            else if ((dlbc.gtXN1 == dlbc.gtRQ1 && dlbc.gtXN2 == dlbc.gtRQ1) || (dlbc.gtXN1 == dlbc.gtRQ2 && dlbc.gtXN2 == dlbc.gtRQ2))
            {
                return true;
            }
            return false;
        }

        public bool KiemTraVeDich()
        {
            if (dlbc.SoXN == 1)
            {
                if (dlbc.gtXN1 == dlbc.gtVD1 || dlbc.gtXN1 == dlbc.gtVD2)
                {
                    return true;
                }
            }
            else if ((dlbc.gtXN1 == dlbc.gtVD1 && dlbc.gtXN2 == dlbc.gtVD1) || (dlbc.gtXN1 == dlbc.gtVD2 && dlbc.gtXN2 == dlbc.gtVD2))
            {
                return true;
            }
            return false;
        }

        public void DaQuan(int vtTrenBC)
        {
            int num = dlbc.arrBC[vtTrenBC];
            DuLieuUser duLieuUser = (DuLieuUser)dlbc.arrUsers[num - 1];
            for (int i = 0; i < duLieuUser.SoQuanCo; i++)
            {
                QuanCo quanCo = (QuanCo)duLieuUser.arrQC[i];
                if (quanCo.QCDL.ViTriTrenBanCo == vtTrenBC)
                {
                    quanCo.QCTH.picQC.Location = new Point(quanCo.QCDL.ViTriTrongChuong.X, quanCo.QCDL.ViTriTrongChuong.Y);
                    quanCo.QCDL.ViTriTrenBanCo = -1;
                    break;
                }
            }
        }

        public bool KiemTraDiDuoc(int gtXN, int vtBC)
        {
            for (int i = 1; i < gtXN; i++)
            {
                if (dlbc.arrBC[(vtBC + i) % 56] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int LaySoQuanVeDich()
        {
            DuLieuUser duLieuUser = (DuLieuUser)dlbc.arrUsers[dlqc.MauCo - 1];
            return duLieuUser.SoQuanVeDich;
        }
    }
}
