using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integration.Pages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        //Sql Server Connection string
        string connectstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //MySQL Connection string
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SelectCount();
        }

        private void SelectCount()
        {
            SqlConnection SqlConn = new SqlConnection(connectstring);
            SqlConn.Open();
            string sqlshare = "SELECT Count(Shareholder_Status) FROM Personal where Shareholder_Status = '1' ";
            SqlCommand comm = new SqlCommand(sqlshare, SqlConn);
            sharehol.Text = comm.ExecuteScalar().ToString();
            string sqlEmploy = "SELECT Count(*) FROM Personal";
            comm = new SqlCommand(sqlEmploy, SqlConn);
            Employ.Text = comm.ExecuteScalar().ToString();
            string sqlMale = "SELECT Count(Gender) FROM Personal where Gender = '1' ";
            comm = new SqlCommand(sqlMale, SqlConn);
            male.Text = comm.ExecuteScalar().ToString();
            string sqlFemale = "SELECT Count(Gender) FROM Personal where Gender = '0' ";
            comm = new SqlCommand(sqlFemale, SqlConn);
            female.Text = comm.ExecuteScalar().ToString();
        }
    }
}