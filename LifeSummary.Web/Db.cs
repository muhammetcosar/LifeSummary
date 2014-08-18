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
                return new SqlConnection("Data Source=UZEM-BILGISAYAR;Initial Catalog=LifeSummary;Integrated Security=True");
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

    }
}
