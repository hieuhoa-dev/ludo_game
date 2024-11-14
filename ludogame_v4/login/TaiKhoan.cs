using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludogame_v4.login
{
	internal class TaiKhoan
	{
		private string tenTaiKhoan;
		private string matKhau;
        public TaiKhoan()
        {
            
        }

		public TaiKhoan(string tenTaiKhoan, string matKhau)
		{
			this.TenTaiKhoan = tenTaiKhoan;
			this.MatKhau = matKhau;
		}

		public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
		public string MatKhau { get => matKhau; set => matKhau = value; }

		public override string ToString()
		{
			return string.Format("Tên tài khoản: {0},Mật Khẩu: {1}",tenTaiKhoan,matKhau);
		}
	}
}
