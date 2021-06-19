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
    public partial class VacationDays : System.Web.UI.Page
    {
        //Sql Server Connection string
        string connectstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HR;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //MySQL Connection string
        string constr = "Data Source=localhost;port=3306;Initial Catalog=mydb;User Id=root;password=root";
        string sql;
        string query;
        private void AddID(DataTable t, List<string> id)
        {
            for (int i = 0; i < t.Rows.Count; i++)
            {
                id.Add(t.Rows[i][0].ToString());
            }
        }
        private void VDDataSeparateHandle(DataTable first_table, DataTable second_table,
            List<string> first_table_key, List<string> second_table_key)//Vacation Days data Separate Handle
        {
            foreach (var key in first_table_key)
            {
                if (!second_table_key.Contains(key))
                {
                    foreach (DataRow row in first_table.Select())
                    {
                        if (row[0].ToString() == key)
                            row.Delete();
                        first_table.AcceptChanges();
                    }
                }
            }
            for (int i = 0; i < first_table.Rows.Count; i++)
            {
                if (first_table.Rows[i]["Employee ID"].ToString() == second_table.Rows[i]["Employee ID"].ToString())
                {
                    first_table.Rows[i]["Vacation Days"] = second_table.Rows[i]["Vacation Days"].ToString();
                }

            }
            first_table.AcceptChanges();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //SQL server
                SqlConnection SqlConn = new SqlConnection(connectstring);
                SqlConn.Open();
                sql = "SELECT CAST(Personal.Employee_ID AS integer) AS 'Employee ID', First_Name AS 'Name', Shareholder_Status As 'Shareholder', " +
                    " Gender, Ethnicity, Employment_Status AS 'Employment' " +
                    "FROM Personal, Employment where Personal.Employee_ID = Employment.Employee_ID";
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(sql, SqlConn);
                DataTable DT = new DataTable();
                DT.PrimaryKey = new DataColumn[] { DT.Columns["Employee ID"] };
                SqlAdapter.Fill(DT);
                DT.Columns.Add("Vacation Days", typeof(int));
                SqlConn.Close();
                List<string> hrID = new List<string>();
                AddID(DT, hrID);

                //MySQL
                MySqlConnection con = new MySqlConnection(constr);
                DataTable ds = new DataTable();
                con.Open();
                ds.PrimaryKey = new DataColumn[] { ds.Columns["Employee ID"] };
                foreach (var item in hrID)
                {
                    query = "select idEmployee AS 'Employee ID',`Vacation Days` from Employee " +
                        "where Employee.idEmployee = '" + item + "' AND `Vacation Days` IS NOT NULL";
                    MySqlDataAdapter sda = new MySqlDataAdapter(query, constr);
                    sda.Fill(ds);
                }
                con.Close();
                List<string> prID = new List<string>();
                AddID(ds, prID);
                VDDataSeparateHandle(DT, ds, hrID, prID);
                GridView1.DataSource = DT;
                GridView1.DataBind();
            }
        }

        protected void Find_Click(object sender, EventArgs e)
        {
            //SQL server
            SqlConnection SqlConn = new SqlConnection(connectstring);
            SqlConn.Open();
            sql = "SELECT CAST(Personal.Employee_ID AS integer) AS 'Employee ID', First_Name AS 'Name', Shareholder_Status As 'Shareholder', " +
                " Gender, Ethnicity, Employment_Status AS 'Employment' " +
                "FROM Personal, Employment where Personal.Employee_ID = Employment.Employee_ID and (Personal.First_Name like '" + Searchtext.Text + "%' OR Personal.Employee_ID like '" + Searchtext.Text + "%')";
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sql, SqlConn);
            DataTable DT = new DataTable();
            DT.PrimaryKey = new DataColumn[] { DT.Columns["Employee ID"] };
            SqlAdapter.Fill(DT);
            DT.Columns.Add("Vacation Days", typeof(int));
            SqlConn.Close();
            List<string> hrID = new List<string>();
            AddID(DT, hrID);

            //MySQL
            MySqlConnection con = new MySqlConnection(constr);
            DataTable ds = new DataTable();
            con.Open();
            ds.PrimaryKey = new DataColumn[] { ds.Columns["Employee ID"] };
            foreach (var item in hrID)
            {
                query = "select idEmployee AS 'Employee ID',`Vacation Days` from Employee " +
                    "where Employee.idEmployee = '" + item + "' AND `Vacation Days` IS NOT NULL";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, constr);
                sda.Fill(ds);
            }
            con.Close();
            List<string> prID = new List<string>();
            AddID(ds, prID);
            VDDataSeparateHandle(DT, ds, hrID, prID);
            GridView1.DataSource = DT;
            GridView1.DataBind();
        }
    }
}