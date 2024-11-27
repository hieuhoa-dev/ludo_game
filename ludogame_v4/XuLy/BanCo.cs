using ludogame_v4.DuLieu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ludogame_v4.XuLy
{
    public class BanCo
    {
        public DuLieuBanCo DLBC;

        public DuLieuBanCo ThongTinBanCo
        {
            get
            {
                return DLBC;
            }
            set
            {
                DLBC = value;
            }
        }

        public BanCo()
        {
            DLBC = new DuLieuBanCo();
        }

        public BanCo(DuLieuBanCo DL)
        {
            DLBC = DL;
        }

        public void HuyBC(Panel panel)
        {
            int count = panel.Controls.Count;
            for (int num = count - 1; num >= 0; num--)
            {
                if (panel.Controls[num].Name != "panelXN_Red" && panel.Controls[num].Name != "panelXN_Blue"&&

					panel.Controls[num].Name != "panelXN_Yellow"&& panel.Controls[num].Name != "panelXN_Green")
                    panel.Controls.RemoveAt(num);
            }
        }

        public void TaoViTriQuan(Point vtCB, int i, DuLieuUser User, Panel panel)
        {
            int num = -24;
            int num2 = -24;
            if (i == 1)
            {
                num2 = -num2;
            }
            if (i == 2)
            {
                num = -num;
                num2 = -num2;
            }
            if (i == 3)
            {
                num = -num;
            }
            for (int j = 0; j < User.SoQuanCo; j++)
            {
                Point viTriTrongChuong = ((j != 0 && j != 2 && j != 4) ? new Point(vtCB.X + (j - 1) / 2 * num, vtCB.Y + num2) : new Point(vtCB.X + j / 2 * num, vtCB.Y));
                QuanCo quanCo = (QuanCo)User.arrQC[j];
                quanCo.QCDL.ViTriTrongChuong = viTriTrongChuong;
                quanCo.QCDL.ViTriTrenBanCo = -1;
                quanCo.QCDL.ViTriRaQuan = i * 14;
                if (quanCo.QCDL.ViTriRaQuan == 0)
                {
                    quanCo.QCDL.ViTriVeDich = 55;
                }
                else
                {
                    quanCo.QCDL.ViTriVeDich = quanCo.QCDL.ViTriRaQuan - 1;
                }
                quanCo.QCDL.MauCo = i + 1;
                quanCo.QCTH.picQC.Location = new Point(quanCo.QCDL.ViTriTrongChuong.X, quanCo.QCDL.ViTriTrongChuong.Y);
                quanCo.QCTH.HienThi(i + 1);
                panel.Controls.Add(quanCo.QCTH.picQC);
            }
        }

        public void TuDongDiChuyenQuanCo(DuLieuUser User)
        {
            for (int i = 0; i < User.SoQuanCo; i++)
            {
                QuanCo quanCo = (QuanCo)User.arrQC[i];
                quanCo.QCTH.picQC_Click(quanCo.QCTH.picQC, EventArgs.Empty);
            }
        }

        public void TuDongDiChuyenNguoiChoi()
        {
            int soNguoichoi = DLBC.SoNguoichoi;
            for (int i = 0; i < soNguoichoi; i++)
            {
                TuDongDiChuyenQuanCo((DuLieuUser)DLBC.arrUsers[i]);
            }
        }

        public void SapBanCo(Panel panel, DuLieuTuyChon tc)
        {
            HuyBC(panel);
            CapNhatDuLieuBanco(tc);
            int soNguoichoi = DLBC.SoNguoichoi;
            for (int i = 0; i < soNguoichoi; i++)
            {
                TaoViTriQuan((Point)DLBC.arrVTChuong[i], i, (DuLieuUser)DLBC.arrUsers[i], panel);
            }
        }

        public void CapNhatDuLieuBanco(DuLieuTuyChon tc)
        {
            DLBC.HinhBanCo = tc.HinhBanCo;
            DLBC.SoNguoichoi = tc.SoNguoiChoi;
        }

        public void XuLyBanCo()
        {
            int userHienTai = DLBC.UserHienTai;
            DuLieuUser duLieuUser = (DuLieuUser)DLBC.arrUsers[userHienTai - 1];
            for (int i = 0; i < duLieuUser.SoQuanCo; i++)
            {
                QuanCo quanCo = (QuanCo)duLieuUser.arrQC[i];
                quanCo.QCTH.dlbc = DLBC;
                quanCo.QCTH.dlqc = quanCo.QCDL;
                quanCo.QCTH.User = duLieuUser;
                quanCo.QCTH.TrangThaiClick = true;
            }
			for (int i = 0; i < DLBC.arrUsers.Count; i++)
			{
				if (i != (userHienTai - 1))
				{
					duLieuUser = (DuLieuUser)DLBC.arrUsers[i];
					for (int j = 0; j < duLieuUser.SoQuanCo; j++)
					{
						QuanCo quanCo = (QuanCo)duLieuUser.arrQC[j];

						quanCo.QCTH.TrangThaiClick = false;
					}
				}
			}
		}

        // Kiểm tra người chơi còn nước đi không
        public bool KiemTraNguoiChoiDiDc() 
        {
            int userHienTai = DLBC.UserHienTai;
            DuLieuUser duLieuUser = (DuLieuUser)DLBC.arrUsers[userHienTai - 1];
            for (int i = 0; i < duLieuUser.SoQuanCo; i++)
            {
                QuanCo quanCo = (QuanCo)duLieuUser.arrQC[i];
               if (quanCo.QCTH.KiemTraQuanCoDiDc() == 1)        
                {
                    return true;
                }    
            }
            return false;
        }

        public Point LayVT(int vtTrenBC)
        {
            Point result = new Point(224, 220);
            int num = 0;
            int num2 = 0;
            int num3 = 29;
            if (vtTrenBC == 55)
            {
                num2 = 7 * num3;
            }
            if (vtTrenBC == 13)
            {
                num = 7 * num3;
            }
            if (vtTrenBC == 27)
            {
                num2 = -7 * num3;
            }
            if (vtTrenBC == 41)
            {
                num = -7 * num3;
            }
            if (vtTrenBC >= 28 && vtTrenBC <= 33)
            {
                num = -num3;
                num2 = -num3 * (35 - vtTrenBC);
            }
            if (vtTrenBC >= 48 && vtTrenBC <= 54)
            {
                num = -num3;
                num2 = num3 * (vtTrenBC - 47);
            }
            if (vtTrenBC >= 0 && vtTrenBC <= 5)
            {
                num = num3;
                num2 = num3 * (7 - vtTrenBC);
            }
            if (vtTrenBC >= 21 && vtTrenBC <= 26)
            {
                num = num3;
                num2 = -num3 * (vtTrenBC - 19);
            }
            if (vtTrenBC >= 6 && vtTrenBC <= 12)
            {
                num2 = num3;
                num = num3 * (vtTrenBC - 5);
            }
            if (vtTrenBC >= 42 && vtTrenBC <= 47)
            {
                num2 = num3;
                num = -num3 * (49 - vtTrenBC);
            }
            if (vtTrenBC >= 34 && vtTrenBC <= 40)
            {
                num2 = -num3;
                num = -num3 * (vtTrenBC - 33);
            }
            if (vtTrenBC >= 14 && vtTrenBC <= 20)
            {
                num2 = -num3;
                num = num3 * (21 - vtTrenBC);
            }
            result.X += num;
            result.Y += num2;
            return result;
        }
    }
}
