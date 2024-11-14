using ludogame_v4.TheHien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ludogame_v4.XuLy
{
	public class XiNgau
	{
		public int gt1;

		public int gt2;

		public int SoXN;

		public void DoXingau(TheHienXiNgau XN,Panel panel)
		{
			SoXN = XN.SoXiNgauTheHien;
			Random rd = new Random(DateTime.Now.Millisecond);
			if (SoXN == 1)
			{
				gt1 = RandomGiatriXN(rd);
				XN.LoadImageXiNgau1(Application.StartupPath + "/HinhXiNgau/" + gt1 + ".jpg");
				return;
			}
			gt1 = RandomGiatriXN(rd);
			XN.LoadImageXiNgau1(Application.StartupPath + "/HinhXiNgau/" + gt1 + ".jpg");
			gt2 = RandomGiatriXN(rd);
			XN.LoadImageXiNgau2(Application.StartupPath + "/HinhXiNgau/" + gt2 + ".jpg");

		}

		public int RandomGiatriXN(Random rd)
		{
			return rd.Next(1, 7);
		}
	}

}
