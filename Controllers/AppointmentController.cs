using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace WebMedicalNew.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            Appointment cat = new Appointment { doc_cat = DocCategories() };
            cat.appointments = cat.GetAppInfos();
            return View(cat);

        }
        [HttpPost]
        public ActionResult Index(Appointment app)
        {
            app.doc_cat = DocCategories();
            app.doctors = Doctors(app.selected_cat_id);
            app.GetDocData(app.selected_doc_id);
            app.appHours=appHours(app.appDate,app.selected_doc_id);
            app.appCat = AppCategories();
            app.SetAppDetails(app.selected_doc_id, Login.id, app.appDate.ToString("dd/MM/yyyy"), app.selected_appHour_id, app.selected_app_cat);
            return View(app);
        }

        public static List<DocCategory> DocCategories()
        {
            ConnectToDatabase.connectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter("select id,descr from DocCategory", ConnectToDatabase.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<DocCategory> doc_cat = new List<DocCategory>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DocCategory dc = new DocCategory();
                dc.cat_id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                dc.cat_descr = ds.Tables[0].Rows[i]["descr"].ToString();
                doc_cat.Add(dc);
            }
            ConnectToDatabase.cnn.Close();
            return doc_cat;
        }
        public List<Doctors> Doctors(int doc_cat_id) {
            ConnectToDatabase.connectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter("select id,CONCAT(firstname,' ',lastname) as fullname from Doctors where doccategory_id=" + doc_cat_id+";", ConnectToDatabase.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Doctors> docs = new List<Doctors>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Doctors doc = new Doctors();
                doc.doc_id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                doc.doc_name = ds.Tables[0].Rows[i]["fullname"].ToString();
                docs.Add(doc);
            }
            ConnectToDatabase.cnn.Close();
            return docs;
        }

        public List<appHours> appHours(DateTime dt,int doc_id)
        {
            ConnectToDatabase.connectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter("select * from appHours where id not in (select hour_id from Appointments where date='"+dt.ToString("dd/MM/yyyy")+"' and doc_account_id="+doc_id+") ", ConnectToDatabase.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<appHours> appHours = new List<appHours>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                appHours ah = new appHours();
                ah.hour_id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                ah.hour_descr = ds.Tables[0].Rows[i]["descr"].ToString();
                appHours.Add(ah);
            }
            ConnectToDatabase.cnn.Close();
            return appHours;
        }
        public static List<appCat> AppCategories()
        {
            ConnectToDatabase.connectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter("select id,descr from AppointmentCategory", ConnectToDatabase.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<appCat> app_cat = new List<appCat>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                appCat ac = new appCat();
                ac.appCat_id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                ac.appCat_descr = ds.Tables[0].Rows[i]["descr"].ToString();
                app_cat.Add(ac);
            }
            ConnectToDatabase.cnn.Close();
            return app_cat;
        }
    }
}