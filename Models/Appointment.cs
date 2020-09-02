using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebMedicalNew
{
    public class Appointment
    {

        public List<DocCategory> doc_cat { get; set; }

        public int selected_cat_id { get; set; }
        public int selected_doc_id { get; set; }
        public List<Doctors> doctors { get; set; }
        public string FullName { get; set; }
        public string DocCategory { get; set; }
        public string Bachelor { get; set; }
        public string Master { get; set; }
        public string PHD { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string officephone { get; set; }
        public string officeaddress { get; set; }
        public string officecity { get; set; }
        public string officetk { get; set; }

        public DateTime appDate { get; set; }
        public List<appCat> appCat {get;set;}
        public int selected_app_cat { get; set; }
        public List<appHours> appHours { get; set; }

        public int selected_appHour_id { get; set; }

        public List<Appointments> appointments { get; set; }
       
        public void GetDocData(int doc_id)
        {
            ConnectToDatabase.connectToDatabase();
            SqlCommand cmd = new SqlCommand("Select concat(firstname,' ',lastname) as fullname,docCategory,bachelor,master,phd,email,mobile,officephone,officeaddress,officecity,officetk from Doctors where id='" + doc_id + "';", ConnectToDatabase.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                FullName = reader[0].ToString();
                DocCategory = reader[1].ToString();
                Bachelor= reader[2].ToString();
                Master = reader[3].ToString();
                PHD = reader[4].ToString();
                email = reader[5].ToString();
                mobile = reader[6].ToString();
                officephone = reader[7].ToString();
                officeaddress = reader[8].ToString();
                officecity = reader[9].ToString();
                officetk = reader[10].ToString();
            }
            ConnectToDatabase.cnn.Close();
        }
        public void SetAppDetails(int doc_id,int user_id,string date,int hour_id,int appCat)
        {
            if (date != "01/01/0001" && hour_id != 0) {
                ConnectToDatabase.connectToDatabase();
                SqlCommand cmd = new SqlCommand("insert into Appointments(doc_account_id,user_account_id,date,hour_id,app_cat_id) values (" + doc_id + "," + user_id + ",'" + date + "'," + hour_id + "," + appCat + ")", ConnectToDatabase.cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                ConnectToDatabase.cnn.Close();
            }
           
        }
        public List<Appointments> GetAppInfos()
        {
            ConnectToDatabase.connectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter("Select username,fullname,amka,email,mobile,date,hours,appcat from AppointmentsInfos where doc_account_id="+Login.id+ "and date='"+DateTime.Now.ToString("dd/MM/yyyy") +"' order by date desc,hours asc;", ConnectToDatabase.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Appointments> appointments = new List<Appointments>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Appointments app = new Appointments();
                app.username = ds.Tables[0].Rows[i]["username"].ToString();
                app.fullname = ds.Tables[0].Rows[i]["fullname"].ToString();
                app.amka = ds.Tables[0].Rows[i]["amka"].ToString();
                app.email = ds.Tables[0].Rows[i]["email"].ToString();
                app.mobile = ds.Tables[0].Rows[i]["mobile"].ToString();
                app.date = ds.Tables[0].Rows[i]["date"].ToString();
                app.hours = ds.Tables[0].Rows[i]["hours"].ToString();
                app.app_cat = ds.Tables[0].Rows[i]["appcat"].ToString();
                appointments.Add(app);

            }
            ConnectToDatabase.cnn.Close();
            return appointments;
        }
    }
    public class DocCategory
    {
        public int cat_id { get; set; }
        public string cat_descr { get; set; }
    }
    public class Doctors
    {
        public int doc_id { get; set; }
        public string doc_name { get; set; }
    }
    public class appCat
    {
        public int appCat_id { get; set; }
        public string appCat_descr { get; set; }
    }
    public class appHours
    {
        public int hour_id { get; set; }
        public string hour_descr { get; set; }
    }
    public class Appointments
    {
        public string username { get; set; }
        public string fullname { get; set; }
        public string amka { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string date { get; set; }
        public string hours { get; set; }
        public string app_cat { get; set; }
    }

}