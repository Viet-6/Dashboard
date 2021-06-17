using MySql.Data.MySqlClient;
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
    public partial class AccumulatedVacation : System.Web.UI.Page
    {
        private void AddID(DataTable t, List<string> id)
        {
            long Length = -1;
            for (int i = 0; i < t.Rows.Count; i++)
            {
                ++Length;
                id.Add(t.Rows[0].ToString());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //SQL Server
                string connectstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //declare sqlconnection
                SqlConnection SqlConn = new SqlConnection(connectstring);
                //declare sqldataadapter
                SqlConn.Open();
                //string sql = "SELECT Personal.Employee_ID AS 'Employee ID', First_Name AS 'First Name', Last_Name As 'Last Name', "+
                //    "Department FROM Personal, Job_History where Personal.Employee_ID = Job_History.Employee_ID";
                string sql = "Select * from Job_History";
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(sql, SqlConn);
                DataTable DT = new DataTable();
                DT.PrimaryKey = new DataColumn[] {DT.Columns["Employee ID"]};
                SqlAdapter.Fill(DT);
                SqlConn.Close();
                List<string> id = new List<string>();
                AddID(DT, id);

                //MySQL
                string constr = "Data Source=localhost;port=3306;Initial Catalog=mydb;User Id=root;password=root";
                MySqlConnection con = new MySqlConnection(constr);
                DataTable ds = new DataTable();
                ds.PrimaryKey = new DataColumn[] { ds.Columns["Employee ID"] };
                foreach (var item in id)
                {
                    string query = "select idEmployee AS 'Employe ID', `Vacation Days` form Employee "+
                        "where Employee.idEmployee = '"+item+"' AND `Vacation Days` IS NOT NULL ;";
                    MySqlDataAdapter sda = new MySqlDataAdapter(query,constr);
                    sda.Fill(ds);
                }
                List<string> prID = new List<string>();
                AddID(ds, prID);
                foreach (var hrID in id)
                {
                    if(!prID.Contains(hrID))
                    {
                        foreach (DataRow row in DT.Select())
                        {
                            if (row[0].ToString() == hrID)
                                row.Delete();
                            DT.AcceptChanges();
                        }
                    }
                }
                DT.Columns.Add("Vacation Days",typeof(int));
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    if (DT.Rows[i]["Employee ID"].ToString() == ds.Rows[i]["Employee ID"].ToString())
                        DT.Rows[i]["Vacation Days"] = ds.Rows[i]["Vacation Days"].ToString();
                }
                DT.AcceptChanges();
                GridView1.DataSource = DT;
                GridView1.DataBind();
            }
        }
    }
}