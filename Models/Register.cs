using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebMedicalNew
{
    public class Register
    {
        public int account_id;
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }

        public int Insert(string username, string password, string ConfirmPassword, string firstName, string lastname, string email, string confemail, string dateofbirth, string City, string streetname,string streetnumber, string zipcode)
        {
            //0 username null
            //1 ok
            //2 email or password doesnt match
            //3 account already exists
            string address = streetname + " " + streetnumber;
            int isOk = 0;

            if (username == null || username.Equals(""))
            {
                ConnectToDatabase.cnn.Close();
                return isOk;
            }
            else
            {
                ConnectToDatabase.connectToDatabase();
                SqlCommand cmd3 = new SqlCommand("Select id from UserAccount where username='" + username + "';", ConnectToDatabase.cnn);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    isOk = 3;
                    reader3.Close();
                    ConnectToDatabase.cnn.Close();
                    return isOk;

                }
                else
                {
                    if (password == null || ConfirmPassword == null || email == null || confemail == null)
                    {
                        isOk = 2;
                        ConnectToDatabase.cnn.Close();
                        return isOk;
                    }
                    else if (password.Equals(ConfirmPassword) && email.Equals(confemail))
                    {
                        reader3.Close();
                        SqlCommand cmd = new SqlCommand("insert into UserAccount (username,password,email,active) values ('" + username + "','" + password + "','" + email + "'," + 1 + ");", ConnectToDatabase.cnn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                        SqlCommand cmd1 = new SqlCommand("Select id from UserAccount where username='" + username + "';", ConnectToDatabase.cnn);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read()){
                            account_id = Int32.Parse(reader1[0].ToString());
                        }
                        reader1.Close();
                        SqlCommand cmd2 = new SqlCommand("insert into UserMedicalRecord (account_id,firstname,lastname,dateofbirth,address,city,tk) values (" + account_id + ",'" + firstName + "','" + lastname + "','" +dateofbirth+"','"+ address + "','" + City + "','" + zipcode + "');", ConnectToDatabase.cnn);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        isOk = 1;
                        reader2.Close();
                        ConnectToDatabase.cnn.Close();
                        return isOk;
                    }
                    else
                    {
                        isOk = 2;
                        ConnectToDatabase.cnn.Close();
                        return isOk;
                    }
                }
            }
            return isOk;
        }
    }
}