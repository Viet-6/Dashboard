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
    public partial class HiringAnniversary : System.Web.UI.Page
    {
        //Sql Server Connection string
        string connectstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql = "SELECT Personal.Employee_ID AS 'Employee ID', First_Name AS 'First Name'," +
                " Last_Name As 'Last Name', Department, CONVERT(char(10),Hire_Date,101) AS 'Hire Date' " +
                "FROM Personal, Job_History, Employment " +
                "where Personal.Employee_ID = Job_History.Employee_ID AND Personal.Employee_ID = Employment.Employee_ID";
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

            if (month.SelectedValue == "0" && year.SelectedValue == "0") { CheckFindx.Text = "false"; } else { CheckFindx.Text = "true"; }
            string sqlFind = Getmonthsql();
            SelectQuery(sql + sqlFind);
        }

        private string Getmonthsql()
        {
            string sqlfind = "";
            if (month.SelectedValue != "0" && year.SelectedValue != "0")
            {
                sqlfind = " and Month(Hire_Date) = '" + month.SelectedValue + "' And Year(Hire_Date) = '" + year.SelectedValue + "' ";
            }
            else if (month.SelectedValue != "0" && year.SelectedValue == "0")
            {
                sqlfind = " and Month(Hire_Date) = '" + month.SelectedValue + "' And '" + year.SelectedValue + "' = 0";
            }
            else if (month.SelectedValue == "0" && year.SelectedValue != "0")
            {
                sqlfind = " and Year(Hire_Date) = '" + year.SelectedValue + "' And '" + month.SelectedValue + "' = 0";
            }
            return sqlfind;
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
                string sqlFind = Getmonthsql();
                SelectQuery(sql + sqlFind);
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