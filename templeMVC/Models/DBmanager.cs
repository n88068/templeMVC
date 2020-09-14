using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace templeMVC.Models
{
    public class DBmanager
    {
        private readonly string ConnStr = @"Data Source=DESKTOP-P6UDMAE\SQLEXPRESS;Initial Catalog=MyTemple;Integrated Security=True";
        public List<Member> GetMembers()
        {
            List<Member> members = new List<Member>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("select * from member");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Member member = new Member
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("id")),
                        name = reader.GetString(reader.GetOrdinal("name")),
                        number = reader.GetString(reader.GetOrdinal("number")),
                    };
                    members.Add(member);
                }
            }
            else
            {
                Console.WriteLine("無資料");
            }
            sqlConnection.Close();
            return members;
        }
        public void NewMember(Member member)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(@"insert into member (id,name,number) values (@id,@name,@number)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", member.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", member.name));
            sqlCommand.Parameters.Add(new SqlParameter("@number", member.number));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}