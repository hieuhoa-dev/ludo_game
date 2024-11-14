using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ludogame_v4.XuLy
{
    public class LuuDuLieuSql
    {
        public void SaveScore(int MauCo, int Diem)
        {
            try
            {
                string connectionString = "server=.; database=ChartScore; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy ID lớn nhất
                    SqlCommand cmdTimIDLonNhat = conn.CreateCommand();
                    cmdTimIDLonNhat.CommandText = "SELECT Max(ID) FROM ChartScore";
                    int maxId = (int)cmdTimIDLonNhat.ExecuteScalar();

                    // Lấy điểm số hiện tại của ID lớn nhất
                    SqlCommand cmdGetCurrentScores = conn.CreateCommand();
                    cmdGetCurrentScores.CommandText = "SELECT BlueScore, RedScore, YellowScore, GreenScore FROM ChartScore WHERE ID = @Id";
                    cmdGetCurrentScores.Parameters.Add("@Id", SqlDbType.Int).Value = maxId;

                    int blueScore = 0, redScore = 0, yellowScore = 0, greenScore = 0;
                    using (SqlDataReader reader = cmdGetCurrentScores.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            blueScore = reader.GetInt32(0);
                            redScore = reader.GetInt32(1);
                            yellowScore = reader.GetInt32(2);
                            greenScore = reader.GetInt32(3);
                        }
                    }

                    // Điều chỉnh điểm số dựa trên MauCo
                    if (MauCo == 1)
                    {
                        blueScore = Diem;
                    }
                    else if (MauCo == 2)
                    {
                        redScore = Diem;
                    }
                    else if (MauCo == 3)
                    {
                        yellowScore = Diem;
                    }
                    else if (MauCo == 4)
                    {
                        greenScore = Diem;
                    }

                    // Tạo SqlCommand để cập nhật điểm số
                    SqlCommand cmdUpdateScore = conn.CreateCommand();
                    cmdUpdateScore.CommandText = "EXECUTE UpdateScore @Id, @BlueScore, @RedScore, @YellowScore, @GreenScore";
                    cmdUpdateScore.Parameters.Add("@ID", SqlDbType.Int).Value = maxId;
                    cmdUpdateScore.Parameters.Add("@BlueScore", SqlDbType.Int).Value = blueScore;
                    cmdUpdateScore.Parameters.Add("@RedScore", SqlDbType.Int).Value = redScore;
                    cmdUpdateScore.Parameters.Add("@YellowScore", SqlDbType.Int).Value = yellowScore;
                    cmdUpdateScore.Parameters.Add("@GreenScore", SqlDbType.Int).Value = greenScore;

                    // Thực thi lệnh
                    cmdUpdateScore.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }

        public void CreateBanSql()
        {
            try
            {
                string connectionString = "server=.; database = ChartScore; Integrated Security = true; ";
                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertScore @ID OUTPUT, @BlueScore, @RedScore, @YellowScore, @GreenScore";

                // Thêm tham số vào đối tượng Command
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@BlueScore", SqlDbType.Int);
                cmd.Parameters.Add("@RedScore", SqlDbType.Int);
                cmd.Parameters.Add("@YellowScore", SqlDbType.Int);
                cmd.Parameters.Add("@GreenScore", SqlDbType.Int);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                // Truyền giá trị vào thủ tục qua tham số
                cmd.Parameters["@BlueScore"].Value = 0;
                cmd.Parameters["@RedScore"].Value = 0;
                cmd.Parameters["@YellowScore"].Value = 0;
                cmd.Parameters["@GreenScore"].Value = 0;
                //mở kết nối

                int numRowAffected = cmd.ExecuteNonQuery();

                // Thông báo kết quả
                //if (numRowAffected > 0)
                //{
                //    string foodID = cmd.Parameters["@id"].Value.ToString();
                //    MessageBox.Show("Successfully adding new food, Food ID =" + foodID, "Message");
                //    this.ResetText();
                //}
                //else
                //{
                //    MessageBox.Show("Adding food failed");
                //}
                // đóng kết nối
                conn.Close();
                conn.Dispose();
            }
            // Bắt lỗi SQL và các lỗi khác
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
    }
}
