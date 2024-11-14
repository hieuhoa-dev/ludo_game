using ludogame_v4.XuLy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludogame_v4.DuLieu
{
	public class DuLieuUser
	{
		private string Username;

		private int mauQC;

		private int soQC;

		public int SoQuanVeDich;

		public ArrayList arrQC = new ArrayList();

		public Point[] arrVtDich = new Point[6];

		public string UserName
		{
			get
			{
				return Username;
			}
			set
			{
				Username = value;
			}
		}

		public int MauQuanCo
		{
			get
			{
				return mauQC;
			}
			set
			{
				mauQC = value;
			}
		}

		public int SoQuanCo
		{
			get
			{
				return soQC;
			}
			set
			{
				soQC = value;
			}
		}

		public DuLieuUser()
		{
			SoQuanCo = 4;
			SoQuanVeDich = 0;
			for (int i = 0; i < SoQuanCo; i++)
			{
				QuanCo value = new QuanCo();
				arrQC.Add(value);
			}
		}

		public DuLieuUser(int SoQCo)
		{
			SoQuanCo = SoQCo;
			SoQuanVeDich = 0;
			for (int i = 0; i < SoQuanCo; i++)
			{
				QuanCo value = new QuanCo();
				arrQC.Add(value);
			}
		}
	}
}
