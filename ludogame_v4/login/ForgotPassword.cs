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
	public partial class ForgotPassword : Form
	{
		public ForgotPassword()
		{
			InitializeComponent();
		}
		Modifi modifi = new Modifi();

		private void btnLayLaiMatKhau_Click(object sender, EventArgs e)
		{
			string query = "select * from TaiKhoan where Email='" + txtEmailDK.Text + "'";
			if(modifi.TaiKhoans(query).Count!=0)
			{
				
				TaiKhoan taikhoan = modifi.TaiKhoans(query)[0];
				txtKetQua.Text = taikhoan.ToString();
			}
			else
			{
				MessageBox.Show("Email chưa được đăng ký!", "Thông báo" ); 

			}
			
		}

		private void ForgotPassword_FormClosed(object sender, FormClosedEventArgs e)
		{
			Login form = new Login();
			form.Show();
		}
	}
}
