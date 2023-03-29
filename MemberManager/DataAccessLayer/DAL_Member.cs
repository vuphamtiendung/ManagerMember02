using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class DAL_Member : DBConnect
    {
        public DataTable GetData()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select TV_ID, TV_NAME, TV_PHONE, TV_EMAIL", _conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public bool InsertData(DTO_Member member)
        {
            try
            {
                _conn.Open();
                string query = string.Format($"Insert Into THANHVIEN(TV_NAME, TV_PHONE, TV_EMAIL) Values " +
                                        $"(N'{member.MemberFullName}', N'{member.MemberPhone}', N'{member.MemberEmail}')");
                SqlCommand cmd = new SqlCommand(query, _conn);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Has been error, detail: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool UpdateData(DTO_Member member)
        {
            try
            {
                _conn.Open();
                string query = string.Format($"Update THANHVIEN Set TV_NAME = N'{member.MemberFullName}', " +
                            $"TV_PHONE = N'{member.MemberPhone}', TV_EMAIL = N'{member.MemberEmail}' Where TV_ID = '{member.MemberId}'");
                SqlCommand cmd = new SqlCommand(query, _conn);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Has been error! detail:" + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool DeleteData(int id) 
        {
            try
            {
                _conn.Open();
                string query = string.Format($"Delete From THANHVIEN Where TV_ID = {id}");
                SqlCommand cmd = new SqlCommand(query, _conn);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Has been error, detail: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;   
        }
    }
}
