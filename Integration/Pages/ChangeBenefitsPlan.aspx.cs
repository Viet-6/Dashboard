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
    public partial class ChangeBenefitsPlan : System.Web.UI.Page
    {
        //Sql Server Connection string
        string connectstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SelectQuery();
            }
        }

        protected void Find_Click(object sender, EventArgs e)
        {
            SelectQuery();
        }

        private void SelectQuery()
        {
            //SQL server
            SqlConnection SqlConn = new SqlConnection(connectstring);
            SqlConn.Open();
            string sql = "SELECT Personal.Employee_ID AS 'Employee ID', First_Name AS 'First Name'," +
                " Last_Name As 'Last Name', Department, Plan_Name AS 'Benefit Plans', Deductable " +
                "FROM Personal, Job_History, Benefit_Plans " +
                "where Personal.Employee_ID = Job_History.Employee_ID AND Personal.Benefit_Plans = Benefit_Plans.Benefit_Plan_ID And (Personal.First_Name like '" + Searchtext.Text + "%' OR Personal.Employee_ID like '" + Searchtext.Text + "%')";
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sql, SqlConn);
            DataTable DT = new DataTable();
            SqlAdapter.Fill(DT);
            SqlConn.Close();
            GridView1.DataSource = DT;
            GridView1.DataBind();
            EnablePagingButton();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //EnablePagingButton();
            SelectQuery();
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
            SelectQuery();
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            ++GridView1.PageIndex;
            SelectQuery();
        }
    }
}