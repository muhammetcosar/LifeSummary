using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Whe;

namespace LifeSummary
{
    public class Db
    {

        public static SqlConnection Connection
        {
            get
            {
                return  new SqlConnection("Data Source=UZEM-BILGISAYAR;Initial Catalog=LifeSummary;Integrated Security=True");
            }
        }
        public static LoginResult Login(string uname, string pass)
        {
            LoginResult result = new LoginResult() { SUCCESS = false };

            try
            {
                SqlConnection con = Connection;
                SqlCommand cmd = new SqlCommand("ST_SP_USER_LOGIN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERNAME", uname);
                cmd.Parameters.AddWithValue("@PASSWORD", pass);

                con.Open();
                var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read())
                {
                    result.SUCCESS = true;
                    result.USERID = Convert.ToInt32(dr["USERID"]);
                    result.USERNAME = dr["USERNAME"].ToString();
                    result.PASSWORD = dr["PASSWORD"].ToString();

                    result.ISADMIN = Convert.ToBoolean(dr["ISADMIN"]);


                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                result.MESSAGE = "Hata Oluştu.";
            }

            return result;
        }

        public static DataTable CityTableGet(int? id)
        {

            SqlConnection baglanti = Connection;
            SqlDataAdapter adapter = new SqlDataAdapter("ST_SP_CITY_SELECT ", baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@countryId", id);

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            return tablo;
        }
        public static City CityParseGet(DataRow row)
        {
            City c = new City();
            c.CityId = Convert.ToInt32(row["CityId"].ToString());
            c.CityName = row["CityName"].ToString();
            c.CountryId = Convert.ToInt32(row["CountryId"].ToString());
            return c;
        }
        public static List<City> CityListGet(int? id)
        {
            var table = CityTableGet(id);
            List<City> list = new List<City>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(CityParseGet(row));
            }
            return list;
        }


        public static DataTable TitleTableGet()
        {

            SqlConnection baglanti = Connection;
            SqlDataAdapter adapter = new SqlDataAdapter("ST_SP_TITLE_SELECT ", baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
          

            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            return tablo;
        }
        public static Title TitleParseGet(DataRow row)
        {
            Title c = new Title();
            c.TitleId = Convert.ToInt32(row["TitleId"].ToString());
            c.TitleName = row["TitleName"].ToString();
         
            return c;
        }
        public static List<Title> TitleListGet()
        {
            var table = TitleTableGet();
            List<Title> list = new List<Title>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(TitleParseGet(row));
            }
            return list;
        }

        public static void CityDelete(int id)
        {
            var con = Connection;
            con.Open();
            var cmd = new SqlCommand("ST_SP_CITY_DELETE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityId", id);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void CitySave(string CityName, int CountryId, int? cityid)
        {

            var baglanti = Connection;
            baglanti.Open();
            var cmd = new SqlCommand("ST_SP_CITYCOUNT_SELECT", baglanti);
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityId", cityid);
            var sc = cmd.ExecuteScalar();
            var sayi = Convert.ToInt32(sc);

            if (sayi == 0)
            {
                cmd = new SqlCommand("ST_SP_CITY_SAVE", baglanti);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityName", CityName);
                cmd.Parameters.AddWithValue("@CountryId", CountryId);
                cmd.ExecuteNonQuery();
            }
            else if (sayi != 0)
            {
                cmd = new SqlCommand("ST_SP_CITY_UPDATE", baglanti);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityId", cityid);
                cmd.Parameters.AddWithValue("@CityName", CityName);
                cmd.ExecuteNonQuery();
            }
            baglanti.Close();
        }
      
        public static void CategorySave(string CategoryName)
        {
            var con = Connection;
            con.Open();
            var cmd = new SqlCommand("ST_SP_CATEGORY_SAVE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", CategoryName);

            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static DataTable CompanyTableGet(int? id)
        {

            SqlConnection baglanti = Connection;
            SqlDataAdapter adapter = new SqlDataAdapter("ST_SP_COMPANY_SELECT ", baglanti);
            adapter.SelectCommand.Parameters.AddWithValue("@CityId", id);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            return tablo;
        }
        public static Company CompanyParseGet(DataRow row)
        {
            Company c = new Company();
            c.CityId = Convert.ToInt32(row["CityId"].ToString());
            c.CompanyTitle = row["CompanyTitle"].ToString();
            c.CompanyId = Convert.ToInt32(row["CompanyId"].ToString());

            return c;
        }
        public static List<Company> CompanyListGet(int? id)
        {
            var table = CompanyTableGet(id);
            List<Company> list = new List<Company>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(CompanyParseGet(row));
            }
            return list;
        }
        public static void CompanyUpdate(string CompanyTitle, int Company)
        {
            var baglanti = Connection;
            baglanti.Open();

            var cmd = new SqlCommand("ST_SP_COMPANY_UPDATE", baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", Company);
            cmd.Parameters.AddWithValue("@CompanyTitle", CompanyTitle);
            cmd.ExecuteNonQuery();

            baglanti.Close();
        }
        public static void CompanySave( int CityId,string CompanyTitle)
        {
            var baglanti = Connection;
            baglanti.Open();

            var cmd = new SqlCommand("ST_SP_COMPANY_SAVE", baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityId", CityId);
            cmd.Parameters.AddWithValue("@CompanyTitle", CompanyTitle);
            cmd.ExecuteNonQuery();

            baglanti.Close();
        }
        public static void CompanyDelete(int id)
        {
            var con = Connection;
            con.Open();
            var cmd = new SqlCommand("ST_SP_COMPANY_DELETE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", id);

            cmd.ExecuteNonQuery();
            con.Close();
        }




        public static void PersonSave(string name, string surname, string Description,string title,int city,DateTime itarih,DateTime atarih,int titleid)
        {
            var baglanti = Connection;
            baglanti.Open();

            var cmd = new SqlCommand("ST_SP_PERSON_SAVE", baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@SurName", surname);
            cmd.Parameters.AddWithValue("@PDescription", Description);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@FMCity", city);
            cmd.Parameters.AddWithValue("@FMDate", itarih);
            cmd.Parameters.AddWithValue("@LMDate", atarih);
            cmd.Parameters.AddWithValue("@TitleId", titleid);
           
            cmd.ExecuteNonQuery();

            baglanti.Close();
        }
    }

}
