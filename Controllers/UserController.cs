using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace backendDecot.Controllers
{
    public class UserController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter da = null;

        [HttpPost]
        [Route("Registration")]
        public string Registration(Models.User user)
        {
            string msg = string.Empty;
            try
            {
                cmd = new SqlCommand("usp_Registration", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@birthdate", user.birthdate);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i > 0)
                {
                    msg = "Data inserted.";
                }
                else
                {
                    msg = "Error.";
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        [HttpPost]
        [Route("Login")]
        public string Login(Models.User user)
        {
            string msg = string.Empty;
            try
            {
                da = new SqlDataAdapter("usp_Login", conn);
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@username", user.username);
                da.SelectCommand.Parameters.AddWithValue("@password", user.password);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    msg = "User is valid";
                }
                else
                {
                    msg = "User is invalid, check whether the username inserted is correct";
                }

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i > 0)
                {
                    msg = "Data inserted";
                }
                else
                {
                    msg = "Error";
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
    }
}
