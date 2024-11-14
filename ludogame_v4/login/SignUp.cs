using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ludogame_v4.login;


namespace ludogame_v4.TheHien
{
	public partial class SignUp : Form
	{
		public SignUp()
		{
			InitializeComponent();
		}
		public bool checkAccount(string account)//check tai khoan va mat khau
		{
			return Regex.IsMatch(account, @"^[a-zA-Z0-9]{1,24}$");
		}
		public bool checkEmail(string email)
		{
			return Regex.IsMatch(email, @"^[\w]{1,20}@gmail.com(.vn|)$");
		}
		Modifi modifi= new Modifi();	
		private void btnDangKy_Click(object sender, EventArgs e)
		{
			string tenTK = txtTenTaiKhoan.Text;
			string matKhau = txtMatKhau.Text;
			string xacNhanMatKhau = txtXacNhanMatKhau.Text;
			string email = txtEmail.Text;

			if (!checkAccount(tenTK))
			{
				MessageBox.Show("Vui lòng nhập Tên Tài Khoản 6-24 ký tự, với chữ cái và số, chữ HOA hoặc chữ thường!"); return;
			}
			if (!checkAccount(matKhau))
			{
				MessageBox.Show("Vui lòng nhập Mật Khẩu 6-24 ký tự, với chữ cái và số, chữ HOA hoặc chữ thường!"); return;
			}
			if (matKhau!=xacNhanMatKhau)
			{
				MessageBox.Show("Mật Khẩu và Xác Nhận Mật Khẩu không trùng khớp "); return;
			}
			if (!checkEmail(email))
			{
				MessageBox.Show("Vui lòng nhập đúng định dạng email!"); return;

			}
			if (modifi.TaiKhoans("select * from TaiKhoan where Email='" + email+"'").Count!=0)
			{
				MessageBox.Show("Email đã được sử dụng vui lòng sử dung email khác !"); return;
				
			}
			try
			{
				string query = "insert into TaiKhoan Values('"+tenTK+ "','"+matKhau+"','"+email+"') ";
				modifi.Command(query);
				MessageBox.Show(" đăng ký thành công !", "thông báo");
				
					this.Close();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("Tên tài khoản nay đã được đăng ký vui lòng đăng ký tên tài khoản khác ");
			}


		}

		private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
		{
			Login form = new Login();
			form.Show();
		}
	}
}
