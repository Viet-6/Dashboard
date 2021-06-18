using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integration.Pages
{
    public partial class Birthday : System.Web.UI.Page
    {
        //Sql Server Connection string
        string connectstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HR;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string sql;
        protected void Page_Load(object sender, EventArgs e)
        {
            //SQL server
            SqlConnection SqlConn = new SqlConnection(connectstring);
            SqlConn.Open();
            sql = "SELECT Personal.Employee_ID AS 'Employee ID', First_Name AS 'First Name'," +
                " Last_Name As 'Last Name', Department, CONVERT(char(10),Date_of_birth,101) AS 'Date of Birth' FROM Personal, Job_History " +
                "where Personal.Employee_ID = Job_History.Employee_ID";
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sql, SqlConn);
            DataTable DT = new DataTable();
            SqlAdapter.Fill(DT);
            SqlConn.Close();
            GridView1.DataSource = DT;
            GridView1.DataBind();
        }
    }
}