using System;
using System.Collections.Generic;
using System.Configuration;
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
        string connectstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql = "SELECT Personal.Employee_ID AS 'Employee ID', First_Name AS 'First Name'," +
                " Last_Name As 'Last Name', Department, CONVERT(char(10),Date_of_birth,101) AS 'Date of Birth' FROM Personal, Job_History " +
                "where Personal.Employee_ID = Job_History.Employee_ID";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SelectQuery(sql);
                CheckFindx.Text = "false";
            }
        }

        private void SelectQuery(string sql)
        {
            //SQL server
            SqlConnection SqlConn = new SqlConnection(connectstring);
            SqlConn.Open();
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sql, SqlConn);
            DataTable DT = new DataTable();
            SqlAdapter.Fill(DT);
            SqlConn.Close();
            GridView1.DataSource = DT;
            GridView1.DataBind();
            EnablePagingButton();
        }

        protected void Find_Click(object sender, EventArgs e)
        {
            string smonth = " and (Month(Date_of_birth) = '" + birthday.SelectedValue + "' OR ('" + birthday.SelectedValue + "' = 0 And Date_of_birth is not null )) ";
            if (birthday.SelectedValue == "0") { CheckFindx.Text = "false"; } else { CheckFindx.Text = "true"; }
            SelectQuery(sql + smonth);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //EnablePagingButton();
            CheckFind();
        }

        private void CheckFind()
        {
            if (CheckFindx.Text == "true")
            {
                string smonth = " and (Month(Date_of_birth) = '" + birthday.SelectedValue + "' OR ('" + birthday.SelectedValue + "' = 0 And Date_of_birth is not null )) ";
                SelectQuery(sql + smonth);
            }
            else
            {
                SelectQuery(sql);
            }
        }

        private void EnablePagingButton()
        {
            if (GridView1.PageCount == 1)
            {
                Next.Enabled = Previous.Enabled = false;
            }
            else if (GridView1.PageIndex == 0 || GridView1.PageIndex == GridView1.PageCount - 1)
            {
                if (GridView1.PageIndex == GridView1.PageCount - 1)
                {
                    Next.Enabled = false;
                    Previous.Enabled = true;
                }
                else
                {
                    Previous.Enabled = false;
                    Next.Enabled = true;
                }
            }
            else if (!Next.Enabled || !Previous.Enabled)
            {
                Next.Enabled = Previous.Enabled = true;
            }
        }

        protected void Previous_Click(object sender, EventArgs e)
        {
            --GridView1.PageIndex;
            CheckFind();
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            ++GridView1.PageIndex;
            CheckFind();
        }
    }
}