using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebMedicalNew
{
    public class Profile
    {
        public int account_id;
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string Amka { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string OfficePhone { get; set; }
        public string MedicalHistory { get; set; }
        public string City { get; set; }
        public string OfficeCity { get; set; }
        public string StreetName { get; set; }
        public string OfficeAddress { get; set; }
        public string ZipCode { get; set; }
        public string OfficeZipCode { get; set; }
        public List<Gender> Gender { get; set; }
        public List<familyStatus> FamilyStatus { get; set; }

        public List<DocCategory> DocCategories { get; set; }
        public string DoctorBachelor { get; set; }
        public string DoctorMaster { get; set; }
        public string DoctorPHD { get; set; }
        public string AdditionalInfos { get; set; }

        public int selected_gen_id { get; set; }
        public int selected_fs_id { get; set; }
        public int selected_doc_cat { get; set; }
        public void GetData()
        {
            if (Login.usertype == 1)
            {
                ConnectToDatabase.connectToDatabase();
                SqlCommand cmd = new SqlCommand("Select username,password,firstname,lastname,fathername,doccategory_id,ge_id,dateofbirth,bachelor,master,phd,email,mobile,officephone,officeaddress,officecity,officetk,additionalinfos from Doctors where id='" + Login.id + "';", ConnectToDatabase.cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Username = reader[0].ToString();
                    Password = reader[1].ToString();
                    FirstName = reader[2].ToString();
                    LastName = reader[3].ToString();
                    FatherName = reader[4].ToString();
                    DateOfBirth = reader[7].ToString();
                    DoctorBachelor = reader[8].ToString();
                    DoctorMaster = reader[9].ToString();
                    DoctorPHD = reader[10].ToString();
                    Email = reader[11].ToString();
                    Mobile = reader[12].ToString();
                    OfficePhone = reader[13].ToString();
                    OfficeAddress = reader[14].ToString();
                    OfficeCity = reader[15].ToString();
                    OfficeZipCode = reader[16].ToString();
                    AdditionalInfos = reader[17].ToString();
                }
                ConnectToDatabase.cnn.Close();
            }
            else if(Login.usertype==2)
            {
                ConnectToDatabase.connectToDatabase();
                SqlCommand cmd = new SqlCommand("Select username,password,firstname,lastname,fathername,dateofbirth,gender,familystatus,occupation,amka,email,mobile,phone,address,city,tk from Users where id='"+Login.id+"';", ConnectToDatabase.cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Username = reader[0].ToString();
                    Password= reader[1].ToString();
                    FirstName= reader[2].ToString();
                    LastName = reader[3].ToString();
                    FatherName = reader[4].ToString();
                    DateOfBirth = reader[5].ToString();
                    Occupation = reader[8].ToString();
                    Amka = reader[9].ToString();
                    Email = reader[10].ToString();
                    Mobile = reader[11].ToString();
                    Phone = reader[12].ToString();
                    StreetName = reader[13].ToString();
                    City = reader[14].ToString();
                    ZipCode = reader[15].ToString();
                }
                ConnectToDatabase.cnn.Close();
            }
            

        }
        public void UpdateData(
            string firstname,string lastname,string fathername,
            string occupation,string amka,
            string dob,
            string mediacalhistory,
            string mobile,string phone,
            string docBachelor,string docMaster,string docPHD,
            string address,string city,string zipcode,
            string doc_additional_infos,
            int gender,int fs,int doc_cat
            )
        {
            if (Login.usertype == 1)
            {
                ConnectToDatabase.connectToDatabase();
                SqlCommand cmd = new SqlCommand(
                    "Update DoctorInfos set " +
                    "doccategory_id=" + doc_cat + "," +
                    "firstname='" + firstname + "'," +
                    "lastname='" + lastname + "'," +
                    "fathername='" + fathername + "'," +
                    "gender=" + gender + "," +
                    "dateofbirth='" + dob + "'," +
                    "officeaddress='" + address + "'," +
                    "officecity='" + city + "'," +
                    "officetk='" + zipcode + "'," +
                    "officephone='" + phone + "'," +
                    "mobile='" + mobile + "'," +
                    "bachelor='" + docBachelor + "'," +
                    "master='" + docMaster + "'," +
                    "phd='" + docPHD + "'," +
                    "additionalinfos='" + doc_additional_infos + "'"+
                    " where account_id=" +Login.id+";", ConnectToDatabase.cnn) ;
                    SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            else if (Login.usertype == 2)
            {
                ConnectToDatabase.connectToDatabase();
                SqlCommand cmd = new SqlCommand(
                    "Update UserMedicalRecord set " +
                    "firstname='" + firstname + "'," +
                    "lastname='" + lastname + "'," +
                    "fathername='" + fathername + "'," +
                    "gender=" + gender + "," +
                    "dateofbirth='" + dob + "'," +
                    "address='" + address + "'," +
                    "city='" + city + "'," +
                    "tk='" + zipcode + "'," +
                    "phone='" + phone + "'," +
                    "mobile='" + mobile + "'," +
                    "amka='" + amka + "'," +
                    "occupation='" + occupation + "'," +
                    "familystatus=" + fs + "," +
                    "medicalhistory='" + mediacalhistory + "'" +
                    " where account_id=" + Login.id + ";", ConnectToDatabase.cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            
            ConnectToDatabase.cnn.Close();
        }
    }
    public class Gender
    {
        public int gender_id { get; set; }
        public string gender_descr { get; set; }
    }
    public class familyStatus
    {
        public int fs_id { get; set; }
        public string fs_descr { get; set; }
    }

}