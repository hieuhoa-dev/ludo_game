using ludogame_v4.DuLieu;
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
    public partial class TuyChon : Form
    {
        private TabControl tabControl1;

        private TabPage XiNgau;

        private TabPage RaQuanVeDich;

        private TabPage NguoiChoi;

        private GroupBox groupBox1;

        private Button btnApDung;

        private GroupBox groupBox2;

        private GroupBox groupBox3;

        private Label label1;

        private Label label2;

        private GroupBox groupBox4;

        private Label label3;

        private Label label4;

        private Label label5;

        private Label label6;

        private Label label7;

        private Label label8;

        private Label label9;

        private Label label10;

        private TabPage BanCo;

        private Button btnThayDoi;

        private OpenFileDialog openFileDlg;

        private PictureBox picBC;

        private ComboBox cmbRQ2;

        private ComboBox cmbRQ1;

        private ComboBox cmbVD2;

        private ComboBox cmbVD1;

        public DuLieuTuyChon tc = new DuLieuTuyChon();

        private TheHienXiNgau theHienXN = new TheHienXiNgau();

        private ComboBox cmbQuan4;

        private ComboBox cmbQuan3;

        private ComboBox cmbQuan2;

        private ComboBox cmbQuan1;

        private ComboBox cmbSoNguoiChoi;

        private RadioButton Quan4;

        private RadioButton Quan3;

        private RadioButton Quan2;

        private RadioButton Quan1;

        public RadioButton MotXN;

        public RadioButton HaiXN;

        private PictureBox picQuan4;

        private PictureBox picQuan3;

        private PictureBox picQuan2;

        private PictureBox picQuan1;

        private TextBox txtUser4;

        private TextBox txtUser3;

        private TextBox txtUser2;

        private TextBox txtUser1;

        private Label lblUser4;

        private Label lblUser3;

        private Label lblUser2;

        private Label lblUser1;

        public TheHienQuanCo qc = new TheHienQuanCo();

        public TuyChon()
        {
            InitializeComponent();
        }



        private void TuyChon_Load(object sender, EventArgs e)
        {
            RemoveItemsControls();
            theHienXN.LoadImageXiNgau1(Application.StartupPath + "/HinhXiNgau/1.jpg");
            theHienXN.LoadImageXiNgau2(Application.StartupPath + "/HinhXiNgau/6.jpg");
            this.panel1.Controls.Add(theHienXN);

            theHienXN.DinhViXiNgau();
            for (int i = 0; i < 4; i++)
            {
                cmbSoNguoiChoi.Items.Add(i + 1);
            }
            for (int i = 0; i < 6; i++)
            {
                cmbQuan1.Items.Add(i + 1);
                cmbQuan2.Items.Add(i + 1);
                cmbQuan3.Items.Add(i + 1);
                cmbQuan4.Items.Add(i + 1);
                cmbRQ1.Items.Add(i + 1);
                cmbRQ2.Items.Add(i + 1);
                cmbVD1.Items.Add(i + 1);
                cmbVD2.Items.Add(i + 1);
            }
            cmbRQ1.Text = cmbRQ1.GetItemText(1);
            cmbRQ2.Text = cmbRQ2.GetItemText(6);
            cmbVD1.Text = cmbVD1.GetItemText(1);
            cmbVD2.Text = cmbVD2.GetItemText(6);
            cmbSoNguoiChoi.Text = cmbSoNguoiChoi.GetItemText(4);
            cmbQuan1.Text = cmbQuan1.GetItemText(4);
            cmbQuan2.Text = cmbQuan2.GetItemText(4);
            cmbQuan3.Text = cmbQuan3.GetItemText(4);
            cmbQuan4.Text = cmbQuan4.GetItemText(4);
            picQuan1.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + qc.LayHinhQuanCo(1));
            picQuan2.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + qc.LayHinhQuanCo(2));
            picQuan3.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + qc.LayHinhQuanCo(3));
            picQuan4.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + qc.LayHinhQuanCo(4));
            picBC.Image = new Bitmap(Application.StartupPath + "/HinhBanCo/banco1.bmp");
        }

        private void RemoveItemsControls()
        {
            cmbSoNguoiChoi.Items.Clear();
            cmbQuan1.Items.Clear();
            cmbQuan2.Items.Clear();
            cmbQuan3.Items.Clear();
            cmbQuan4.Items.Clear();
            cmbRQ1.Items.Clear();
            cmbRQ2.Items.Clear();
            cmbVD1.Items.Clear();
            cmbVD2.Items.Clear();
        }

        private void AnHienQuan(int n, bool TrangThai)
        {
            if (n == 1 && txtUser1.Visible != TrangThai)
            {
                lblUser1.Visible = TrangThai;
                txtUser1.Visible = TrangThai;
                picQuan1.Visible = TrangThai;
                cmbQuan1.Visible = TrangThai;
                Quan1.Visible = TrangThai;
                cbMay1.Visible = TrangThai;
            }
            if (n == 2 && txtUser2.Visible != TrangThai)
            {
                lblUser2.Visible = TrangThai;
                txtUser2.Visible = TrangThai;
                picQuan2.Visible = TrangThai;
                cmbQuan2.Visible = TrangThai;
                Quan2.Visible = TrangThai;
                cbMay2.Visible = TrangThai;
            }
            if (n == 3 && txtUser3.Visible != TrangThai)
            {
                lblUser3.Visible = TrangThai;
                txtUser3.Visible = TrangThai;
                picQuan3.Visible = TrangThai;
                cmbQuan3.Visible = TrangThai;
                Quan3.Visible = TrangThai;
                cbMay3.Visible = TrangThai;
            }
            if (n == 4 && txtUser4.Visible != TrangThai)
            {
                lblUser4.Visible = TrangThai;
                txtUser4.Visible = TrangThai;
                picQuan4.Visible = TrangThai;
                cmbQuan4.Visible = TrangThai;
                Quan4.Visible = TrangThai;
                cbMay4.Visible = TrangThai;
            }
        }

        private void cmbSoNguoiChoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            tc.SoNguoiChoi = cmbSoNguoiChoi.SelectedIndex + 1;
            switch (tc.SoNguoiChoi)
            {
                case 4:
                    AnHienQuan(1, TrangThai: true);
                    AnHienQuan(2, TrangThai: true);
                    AnHienQuan(3, TrangThai: true);
                    AnHienQuan(4, TrangThai: true);
                    break;
                case 3:
                    AnHienQuan(1, TrangThai: true);
                    AnHienQuan(2, TrangThai: true);
                    AnHienQuan(3, TrangThai: true);
                    AnHienQuan(4, TrangThai: false);
                    break;
                case 2:
                    AnHienQuan(1, TrangThai: true);
                    AnHienQuan(2, TrangThai: true);
                    AnHienQuan(3, TrangThai: false);
                    AnHienQuan(4, TrangThai: false);
                    break;
                case 1:
                    AnHienQuan(1, TrangThai: true);
                    AnHienQuan(2, TrangThai: false);
                    AnHienQuan(3, TrangThai: false);
                    AnHienQuan(4, TrangThai: false);
                    break;
            }
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            openFileDlg.ShowDialog();
            string fileName = openFileDlg.FileName;
            if (fileName != "")
            {
                try
                {
                    picBC.Image = new Bitmap(fileName);
                    tc.HinhBanCo = fileName;
                }
                catch
                {
                    MessageBox.Show("You must chose fileimage");
                }
            }
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            tc.SoHotXiNgau = (MotXN.Checked ? 1 : 2);
            tc.gtRaQuan1 = cmbRQ1.SelectedIndex + 1;
            tc.gtRaQuan2 = cmbRQ2.SelectedIndex + 1;
            tc.gtVeDich1 = cmbVD1.SelectedIndex + 1;
            tc.gtVeDich2 = cmbVD2.SelectedIndex + 1;
            tc.SoNguoiChoi = cmbSoNguoiChoi.SelectedIndex + 1;
            tc.PlayerNames[0] = txtUser1.Text;
            tc.PlayerNames[1] = txtUser2.Text;
            tc.PlayerNames[2] = txtUser3.Text;
            tc.PlayerNames[3] = txtUser4.Text;
            if (Quan1.Checked)
            {
                tc.NguoiUuTien = 1;
            }
            if (Quan2.Checked)
            {
                tc.NguoiUuTien = 2;
            }
            if (Quan3.Checked)
            {
                tc.NguoiUuTien = 3;
            }
            if (Quan4.Checked)
            {
                tc.NguoiUuTien = 4;
            }
            tc.SoNguaQuan[0] = cmbQuan1.SelectedIndex + 1;
            tc.SoNguaQuan[1] = cmbQuan2.SelectedIndex + 1;
            tc.SoNguaQuan[2] = cmbQuan3.SelectedIndex + 1;
            tc.SoNguaQuan[3] = cmbQuan4.SelectedIndex + 1;

            if (cbMay1.Checked)
                tc.SoMay[0] = 1;
            else
                tc.SoMay[0] = 0;

            if (cbMay2.Checked)
                tc.SoMay[1] = 1;
            else
                tc.SoMay[1] = 0;

            if (cbMay3.Checked)
                tc.SoMay[2] = 1;
            else
                tc.SoMay[2] = 0;

            if (cbMay4.Checked)
                tc.SoMay[3] = 1;
            else
                tc.SoMay[3] = 0;

            Close();
        }

        private void MotXN_Click(object sender, EventArgs e)
        {
            theHienXN.SoXiNgauTheHien = 1;
            theHienXN.DinhViXiNgau();
        }

        private void HaiXN_Click(object sender, EventArgs e)
        {
            theHienXN.SoXiNgauTheHien = 2;
            theHienXN.DinhViXiNgau();
        }

        public bool KiemTraChoiVoiMay()
        {
            if (cbMay1.Checked) return true;
            if (cbMay2.Checked) return true;
            if (cbMay3.Checked) return true;
            if (cbMay4.Checked) return true;

            return false;
        }
    }
}
