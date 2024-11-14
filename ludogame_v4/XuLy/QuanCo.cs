using ludogame_v4.DuLieu;
using ludogame_v4.TheHien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludogame_v4.XuLy
{
	public class QuanCo
	{
		public TheHienQuanCo QCTH;

		public DuLieuQuanCo QCDL;

		public QuanCo()
		{
			QCTH = new TheHienQuanCo();
			QCDL = new DuLieuQuanCo();
		}

		public void XuLyQuanCo(int MauHH)
		{
		}
	}
}
