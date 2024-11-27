using ludogame_v4.DuLieu;
using ludogame_v4.XuLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ludogame_v4.TheHien
{
    public enum Colors
    {
        Green,
        Red,
        Yellow,
        Blue
    }

    public partial class FormXuLyChinh : Form
    {
        private Panel panelBC;

        private Button btnDoXiNgau;

        private Button btnSapBanCo;

        private Label label1;

        private PictureBox picLuotQC;

        private TheHienXiNgau TheHienXN = new TheHienXiNgau();

        private XiNgau XN = new XiNgau();

        private Button btnTuyChon;

        private Button btnThoat;
        private Colors currentTurn;
        private BanCo BC;

        private TuyChon TuyChonThamSo = new TuyChon();

        private bool isAutoRunning = false;
        LuuDuLieuSql Data = new LuuDuLieuSql();

        public FormXuLyChinh()
        {
            InitializeComponent();
            TheHienXN.UserControlClicked += MyControl_UserControlClicked;
            //panelXN.Controls.Add(TheHienXN);

        }

        private void MyControl_UserControlClicked(object sender, EventArgs e)
        {
            btnDoXiNgau.Enabled = true;
            btnDoXiNgau.PerformClick();
        }

        private void XuLyChinh_Load(object sender, EventArgs e)
        {
            XN.SoXN = TuyChonThamSo.tc.SoHotXiNgau;
            btnDoXiNgau.Enabled = false;

        }

        public void LoadHinhBC()
        {
            panelBC.BackgroundImage = new Bitmap(TuyChonThamSo.tc.HinhBanCo);
        }
        public string GetStrImage()
        {
            string text = Application.StartupPath + "/hinhngua/";
            switch (BC.DLBC.UserHienTai)
            {
                case 1:
                    text += "duong.gif";
                    currentTurn = Colors.Blue;
                    break;
                case 2:
                    text += "do.gif";
                    currentTurn = Colors.Red;
                    break;
                case 3:
                    text += "vang.gif";
                    currentTurn = Colors.Yellow;
                    break;
                case 4:
                    text += "xanh.gif";
                    currentTurn = Colors.Green;
                    break;
            }
            return text;
        }

        public void ResetManHinh()
        {
            panelBC.BackgroundImage = new Bitmap(TuyChonThamSo.tc.HinhBanCo);
            TheHienXN.SoXiNgauTheHien = TuyChonThamSo.tc.SoHotXiNgau;
            TheHienXN.DinhViXiNgau();
            BC = new BanCo();
            BC.DLBC.CapNhatDL(TuyChonThamSo.tc);
        }

        public bool KiemTraRaQuan()
        {
            if (XN.SoXN == 1)
            {
                if (XN.gt1 == BC.DLBC.gtRQ1 || XN.gt1 == BC.DLBC.gtRQ2)
                {
                    return true;
                }
            }
            else if ((XN.gt1 == BC.DLBC.gtRQ1 && XN.gt2 == BC.DLBC.gtRQ1) || (XN.gt1 == BC.DLBC.gtRQ2 && XN.gt2 == BC.DLBC.gtRQ2))
            {
                return true;
            }
            return false;
        }

        private void btnDoXiNgau_Click(object sender, EventArgs e)
        {

            picLuotQC.Image = new Bitmap(GetStrImage());
            switch (currentTurn)
            {
                case Colors.Green:
                    XN.DoXingau(TheHienXN, panelXN_Green);
                    panelXN_Green.Controls.Add(TheHienXN);
                    panelXN_Green.BringToFront();
                    break;
                case Colors.Red:
                    XN.DoXingau(TheHienXN, panelXN_Red);
                    panelXN_Red.Controls.Add(TheHienXN);
                    panelXN_Red.BringToFront();
                    break;
                case Colors.Yellow:
                    XN.DoXingau(TheHienXN, panelXN_Yellow);
                    panelXN_Yellow.Controls.Add(TheHienXN);
                    panelXN_Yellow.BringToFront();
                    break;
                case Colors.Blue:
                    XN.DoXingau(TheHienXN, panelXN_Blue);
                    panelXN_Blue.Controls.Add(TheHienXN);
                    panelXN_Blue.BringToFront();
                    break;
                default:

                    break;
            }
            BC.DLBC.CapNhatGTXN(XN);

            BC.XuLyBanCo();

            if (BC.KiemTraNguoiChoiDiDc() == false) // Có đi dc không, nếu không thì chuyển User tiếp thep
            {
                UserNext();
            }
        }

        void UserNext()
        {
            BC.DLBC.UserHienTai = BC.DLBC.UserHienTai % BC.DLBC.SoNguoichoi + 1;
        }



        private void btnTuyChon_Click(object sender, EventArgs e)
        {
            TuyChonThamSo.ShowDialog(this);
            btnSapBanCo.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            this.Close();
        }




        //async void HamAuto()
        //{
        //    isAutoRunning = TuyChonThamSo.KiemTraChoiVoiMay();
        //    //isAutoRunning = true;
        //    while (isAutoRunning)
        //    {
        //        await Task.Delay(1000);
        //        for (int i = 0; i < TuyChonThamSo.tc.SoMay.Length; i++)
        //        {
        //            if (BC.DLBC.UserHienTai == i + 1 && TuyChonThamSo.tc.SoMay[i] == 1)
        //            {
        //                {
        //                    btnDoXiNgau.PerformClick();
        //                    await Task.Delay(500);
        //                    BC.TuDongDiChuyenCacQuan();
        //                    await Task.Delay(1000);
        //                    //isAutoRunning = true;
        //                }
        //            }
        //            //if (BC.DLBC.UserHienTai != i + 1 && TuyChonThamSo.tc.SoMay[i] != 1)
        //            //{
        //            //    isAutoRunning = false;
        //            //    HamAuto();
        //            //}

        //        }
        //    }


        //}

        private void btnSapBanCo_Click(object sender, EventArgs e)
        {
            panelXN.Controls.Add(TheHienXN);
            ResetManHinh();

            BC.SapBanCo(panelBC, TuyChonThamSo.tc);

            Data.CreateBanSql();
            btnSapBanCo.Enabled = false;
            btnDoXiNgau.Enabled = true;
            TatHanAuto();
            isAutoRunning = TuyChonThamSo.KiemTraChoiVoiMay();
            if (isAutoRunning)
                HamAuto();

            else
                TatHanAuto();
        }

        private Timer timer = null;
        void HamAuto()
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = 2500;
                timer.Tick += Timer_Tick;
            }
            timer.Start();
        }
        void TatHanAuto()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
                timer.Dispose();
                timer = null;
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            //await Task.Delay(500);
            for (int i = 0; i < TuyChonThamSo.tc.SoMay.Length; i++)
            {
                if (BC.DLBC.UserHienTai == i + 1 && TuyChonThamSo.tc.SoMay[i] == 1)
                {
                    {
                        btnDoXiNgau.PerformClick(); // Gọi lệnh đỗ Xúc sắc
                        await Task.Delay(400);
                        BC.TuDongDiChuyenNguoiChoi();
                        await Task.Delay(1300);
                    }
                }
            }
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            BangXepHang bangXepHang = new BangXepHang();
            bangXepHang.Show(this);
            bangXepHang.ShowData();
        }
    }
}

