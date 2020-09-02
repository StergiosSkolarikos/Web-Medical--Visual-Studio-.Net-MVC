using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EatrikiVideoCall;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace WebMedicalNew
{ 
    public class MainPage
    {
        public string announcement_title { get; set; }
        public string announcement { get; set; }
        public List<Announcements> announcements { get; set; }

       public List<Announcements> GetAnnouncements()
        {
            ConnectToDatabase.connectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter("Select id,fullname,doc_category,date,announcement_title,announcement from AnnouncementsInfos where date='" + DateTime.Now.ToString("dd/MM/yyyy") + "';", ConnectToDatabase.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Announcements> announcements = new List<Announcements>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Announcements ann = new Announcements();
                ann.doc_fullname = ds.Tables[0].Rows[i]["fullname"].ToString();
                ann.doc_category = ds.Tables[0].Rows[i]["doc_category"].ToString();
                ann.date = ds.Tables[0].Rows[i]["date"].ToString();
                ann.announcement_title = ds.Tables[0].Rows[i]["announcement_title"].ToString();
                ann.announcement = ds.Tables[0].Rows[i]["announcement"].ToString();
                announcements.Add(ann);

            }
            ConnectToDatabase.cnn.Close();
            return announcements;
        }
        public void InsertAnnouncements(int doc_id,string announcement_title,string announcement)
        {
            ConnectToDatabase.connectToDatabase();
            SqlCommand cmd = new SqlCommand("insert into Announcements(doc_account_id,announcement_title,announcement,date) values (" + doc_id + ",'" + announcement_title + "','" + announcement + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')", ConnectToDatabase.cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            ConnectToDatabase.cnn.Close();
        }
    }
    public class Announcements
    {
        public int id { get; set; }
        public string doc_fullname { get; set; }
        public string doc_category { get; set; }
        public string date { get; set; }
        public string announcement_title { get; set; }
        public string announcement { get; set; }
    }
}