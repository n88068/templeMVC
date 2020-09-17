using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace templeMVC.Models
{
    public class DBmanager
    {
        //private readonly string ConnStr = @"Data Source=DESKTOP-P6UDMAE\SQLEXPRESS;Initial Catalog=MyTemple;Integrated Security=True"; 家裡電腦
        //private readonly string ConnStr = @"Data Source = LAPTOP-981C2FSJ\SQLEXPRESS;Initial Catalog =Temple;Integrated Security = True"; //筆腦
        
        public List<Member> GetMembers()
        {
            List<Member> members = new List<Member>();
            // SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("select * from member");
            sqlCommand.Connection = conn;
            conn.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Member member = new Member
                    {                        
                        ID = reader.GetString(reader.GetOrdinal("id")),
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
            conn.Close();
            return members;
        }
        public void NewMember(Member member)
        {
            //SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(@"insert into member (id,name,number) values (@id,@name,@number)");
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.Add(new SqlParameter("@id", member.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", member.name));
            sqlCommand.Parameters.Add(new SqlParameter("@number", member.number));
            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
}