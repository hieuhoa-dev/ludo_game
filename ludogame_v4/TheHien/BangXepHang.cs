using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ludogame_v4.TheHien
{
    public partial class BangXepHang : Form
    {
        public BangXepHang()
        {
            InitializeComponent();
        }

        public void ShowData()
        {
            string connectionString = "server=.; database = ChartScore; Integrated Security = true; ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT BlueScore, RedScore, YellowScore, GreenScore FROM ChartScore";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                // Thiết lập ListView
                lvRank.Items.Clear();
                lvRank.Columns.Clear();

                // Thêm các cột từ DataTable vào ListView
                foreach (DataColumn column in dt.Columns)
                {
                    lvRank.Columns.Add(column.ColumnName);
                    
                }

                // Thêm các dòng từ DataTable vào ListView
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem listItem = new ListViewItem(((int)row[0]*10).ToString());

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        listItem.SubItems.Add(((int)row[i]*10).ToString());
                    }

                    lvRank.Items.Add(listItem);
                }

                // Tùy chỉnh ListView
                lvRank.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvRank.View = View.Details; // Hiển thị dưới dạng chi tiết
            }
        }

    }
}
