using ludogame_v4.login;
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
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}

		private void linkLabelQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Hide();
			ForgotPassword form = new ForgotPassword();
			form.Show();
		}

		private void linkLabelDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Hide();
			SignUp form = new SignUp();
			form.ShowDialog();
		}
		Modifi modifi = new Modifi();
		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			string tentk = txtTenDangNhap.Text;
			string matkhau = txtMatKhau.Text;
			if (tentk.Trim() == "" || matkhau.Trim() == "")
			{
				MessageBox.Show("vui lòng nhập tên tài khoản và mật khẩu"); return;
			}
			else
			{
				string query = "select * from TaiKhoan where AccountName='"
					+ tentk + "'and Password='" + matkhau + "'";
				if (modifi.TaiKhoans(query).Count != 0)
				{
					// Ẩn Form1
					this.Hide();

					// Tạo FormXuLyChinh và chạy nó như Form chính mới
					FormXuLyChinh form = new FormXuLyChinh();
					form.ShowDialog();

					// Đóng Form1 sau khi FormXuLyChinh được đóng
					this.Close();
				}
				else
				{
					MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
