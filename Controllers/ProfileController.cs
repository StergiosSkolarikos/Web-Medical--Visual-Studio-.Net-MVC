using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebMedicalNew.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            Profile p = new Profile()
            {
                Gender = GetGender(),
                FamilyStatus = GetFamilyStatus(),
                DocCategories = AppointmentController.DocCategories()
            };
            p.GetData();
            
            return View(p);
        }
        [HttpPost]
        public ActionResult Index(Profile p)
        {
            p.Gender = GetGender();
            p.FamilyStatus = GetFamilyStatus();
            p.DocCategories = AppointmentController.DocCategories();
            p.UpdateData(
                p.FirstName, p.LastName, p.FatherName,
                p.Occupation, p.Amka, p.DateOfBirth, p.MedicalHistory,
                p.Mobile, p.OfficePhone,
                p.DoctorBachelor, p.DoctorMaster, p.DoctorPHD,
                p.OfficeAddress, p.OfficeCity, p.ZipCode, p.AdditionalInfos, p.selected_gen_id, p.selected_fs_id, p.selected_doc_cat
            );
            return View(p);

        }
        public List<Gender> GetGender()
        {
            ConnectToDatabase.connectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter("select id,descr from Gender", ConnectToDatabase.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Gender> g = new List<Gender>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Gender ge = new Gender();
                ge.gender_id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                ge.gender_descr = ds.Tables[0].Rows[i]["descr"].ToString();
                g.Add(ge);
            }
           
            ConnectToDatabase.cnn.Close();
            return g;
        }
        public List<familyStatus> GetFamilyStatus()
        {
            ConnectToDatabase.connectToDatabase();
            SqlDataAdapter da = new SqlDataAdapter("select id,descr from FamilyStatus", ConnectToDatabase.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<familyStatus> fs = new List<familyStatus>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                familyStatus f = new familyStatus();
                f.fs_id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                f.fs_descr = ds.Tables[0].Rows[i]["descr"].ToString();
                fs.Add(f);
            }

            ConnectToDatabase.cnn.Close();
            return fs;
        }
    }
}