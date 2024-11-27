using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludogame_v4.DuLieu
{
	public class DuLieuQuanCo // Lưu giá trị các Quân cờ
	{
		//Lưu trị trí trong Chuồng
		private Point vtTrongChuong;

        //Lưu trị trí trên bàn cờ
        private int vtTrenBC;

		private int vtRQ;

		private int vtVD;

		private int Mau;

		//Số bậc về đích: có 6 bậc, Bậc = 5 
		public int Bac; 

		public int Count;

		public int MauCo
		{
			get
			{
				return Mau;
			}
			set
			{
				Mau = value;
			}
		}

		public int ViTriTrenBanCo
		{
			get
			{
				return vtTrenBC;
			}
			set
			{
				vtTrenBC = value;
			}
		}

		public Point ViTriTrongChuong
		{
			get
			{
				return vtTrongChuong;
			}
			set
			{
				vtTrongChuong = value;
			}
		}

		public int ViTriRaQuan
		{
			get
			{
				return vtRQ;
			}
			set
			{
				vtRQ = value;
			}
		}

		public int ViTriVeDich
		{
			get
			{
				return vtVD;
			}
			set
			{
				vtVD = value;
			}
		}

		public DuLieuQuanCo()
		{		
			ViTriTrenBanCo = -1;
			Count = 0;
			Bac = 0;
		}
	}
}
