using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Windows.Forms;
using EatrikiVideoCall;


namespace WebMedicalNew
{
    public class Login
    {
        public static int usertype;
        public static int id;
        public string UserName { get; set; }
        public string Password { get; set; }

        public string getCredentials(String username, String password)
        {
            String message = "";
            ConnectToDatabase.connectToDatabase();
            SqlCommand cmd = new SqlCommand("Select id,username,password,usertype from All_Accounts where username='" + username + "' and password='" + password + "';", ConnectToDatabase.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                id = Int32.Parse(reader[0].ToString());
                usertype = Int32.Parse(reader[3].ToString());
                if (usertype == 1)
                {
                    UserName = reader["username"].ToString();
                    message = "1";
                    reader.Close();
                }
                else if (usertype == 2)
                {
                    
                    UserName = reader["username"].ToString();
                    message = "2";
                    reader.Close();
                }
                
            }
            else
            {
                message = "Invalid Credentials";
            }
            ConnectToDatabase.cnn.Close();
            return message;
        }
    }
}