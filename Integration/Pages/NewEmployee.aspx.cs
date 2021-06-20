using MySql.Data.MySqlClient;
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
    public partial class NewEmployee : System.Web.UI.Page
    {
        //Sql Server Connection string
        string connectstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //MySQL Connection string
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        private void LoadBenefitPlanData()
        {
            SqlConnection SqlConn = new SqlConnection(connectstring);
            SqlConn.Open();
            DataTable datasetBP = new DataTable();
            string sql = "SELECT Benefit_Plan_ID, Plan_Name FROM  Benefit_Plans";
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sql, SqlConn);
            SqlAdapter.Fill(datasetBP);
            SqlConn.Close();
            department.DataBind();
            BenefitPlanID.DataSource = datasetBP;
            BenefitPlanID.DataTextField = "Plan_Name";
            BenefitPlanID.DataValueField = "Benefit_Plan_ID";
            BenefitPlanID.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadBenefitPlanData();
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            string insert_employment = "insert into Employment ([Employee_ID]," +
            " [Employment_Status], [Hire_Date], [Workers_Comp_Code], " +
            " [Termination_Date], [Rehire_Date], [Last_Review_Date]) VALUES " +
            "(CAST('" + EmployeeIDText.Text + "' AS Decimal(18, 0)), '" + Employment_ST.Text +
            "', '" + Hire_dateSelect.Text + "', " + "null, null, null, null )";
            string insert_Personal = "INSERT INTO Personal (Employee_ID, " +
                "First_Name, Last_Name, Middle_Initial, Address1, Address2, City, " +
                "State, Zip, Email, Phone_Number, Social_Security_Number, " +
                "Drivers_License, Marital_Status, Gender, Shareholder_Status, Benefit_Plans, " +
                "Ethnicity, Date_of_birth) values (Cast('" + EmployeeIDText.Text + "' AS Numeric(18,0)), " +
                "'" + firstnameText.Text + "', '" + lastnameText.Text + "', null, null, null, null, null, null, '"
                + Email.Text + "', '" + Phone_Number.Text + "', '" + SSN.Text + "', " + "null, null, '" +
                Gender.SelectedValue + "', '" + ShareholderSelect.SelectedValue +
                "', Cast('" + BenefitPlanID.SelectedValue + "' AS Numeric(18,0)), " + "null, '" + BirthdaySelect.Text + "')";
            string insert_Job = "insert into Job_History ([Employee_ID], [Department], [Division], [Start_Date], [End_Date], [Job_Title], [Supervisor], [Job_Category], [Location], [Departmen_Code], [Salary_Type], [Pay_Period], [Hours_per_Week], [Hazardous_Training]) " +
                " values (Cast('" + EmployeeIDText.Text + "' AS Numeric(18,0)), '" + department.SelectedValue + "', null," +
            " getdate(), Cast('2026-01-01' AS datetime), null, Cast(null AS Numeric(18)), null, null, Cast(null AS Numeric(18))," +
            " Cast(null AS Numeric(18)), null, Cast('7' AS Numeric(18)), null )";
            string insert_payrates = "insert into `Pay rates` (`idPay Rates`, `Pay Rate Name`, `Value`, `Tax Percentage`, `Pay Type`, `Pay Amount`, `PT - Level C`)" +
                    " values (@idPay_Rates, @Pay_Rate_Name, Cast(@Value AS Decimal)," +
                    "Cast(@Tax_Percentage AS Decimal), @Pay_Type, Cast(@Pay_Amount AS Decimal), Cast(@PT_Level_C AS Decimal) )";
            string insert_Employee = "insert into Employee values (@Employee_ID, @Employee_Number, @First_Name, @Last_Name, Cast(@SSN AS Decimal), @Pay_Rate," +
               " @Pay_Rate_ID, @Vacation_Days, Cast(@Paid_To_Date As Decimal), Cast(@Paid_Last_Year As Decimal))";
            SqlConnection SqlConn = new SqlConnection(connectstring);
            SqlTransaction tran = null;
            MySqlTransaction mytran = null;
            try
            {
                SqlConn.Open();
                tran = SqlConn.BeginTransaction();
                insertsql(insert_Personal + insert_Job + insert_employment, SqlConn, tran);
                using (MySqlConnection connection = new MySqlConnection(constr))
                {
                    connection.Open();
                    mytran = connection.BeginTransaction();
                    Insert_Pay_Rates(insert_payrates, connection);
                    Insert_Employee(insert_Employee, connection);
                    mytran.Commit();
                    connection.Close();
                }
                tran.Commit();
                Clear();
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 2627)
                {
                    if (sqle.Message.Contains("Primary"))
                    {
                        string message = "Already have data in databases!";
                        Alert(message);
                    }
                    else
                    {
                        string message = "Already have data in databases!";
                        Alert(message);
                    }
                }
                else
                {
                    string message = "Human Resource Connection Error!";
                    Alert(message);
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("Primary"))
                    {
                        string message = "Already have data in databases!";
                        Alert(message);
                    }
                    else
                    {
                        string message = "Already have data in databases!";
                        Alert(message);
                    }
                }
                else
                {
                    if (tran != null)
                    { tran.Rollback(); }
                    else if (mytran != null)
                    {
                        tran.Rollback();
                        mytran.Rollback();
                    }
                    string message = "Already have data in databases!";
                    Alert(message);
                }
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open)
                    SqlConn.Close();
            }
        }

        private static void insertsql(string insert_Personal, SqlConnection SqlConn, SqlTransaction tran)
        {
            SqlCommand comm = new SqlCommand(insert_Personal, SqlConn, tran);
            comm.ExecuteNonQuery();
        }

        private void Alert(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        private void Insert_Employee(string query, MySqlConnection connection)
        {
            //MySQL Employee Table
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Employee_ID", EmployeeIDText.Text);
            command.Parameters.AddWithValue("@Employee_Number", EmployeeNum.Text);
            command.Parameters.AddWithValue("@First_Name", firstnameText.Text);
            command.Parameters.AddWithValue("@Last_Name", lastnameText.Text);
            command.Parameters.AddWithValue("@SSN", SSN.Text);
            command.Parameters.AddWithValue("@Pay_Rate", "10");
            command.Parameters.AddWithValue("@Pay_Rate_ID", IDPayRates.Text);
            command.Parameters.AddWithValue("@Vacation_Days", "0");
            command.Parameters.AddWithValue("@Paid_To_Date", "0");
            command.Parameters.AddWithValue("@Paid_Last_Year", "0");
            command.ExecuteNonQuery();
        }

        private void Insert_Pay_Rates(string query, MySqlConnection connection)
        {
            //MySQL Pay Rates Table
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@idPay_Rates", IDPayRates.Text);
            command.Parameters.AddWithValue("@Pay_Rate_Name", "VND");
            command.Parameters.AddWithValue("@Value", "100");
            command.Parameters.AddWithValue("@Tax_Percentage", "10");
            command.Parameters.AddWithValue("@Pay_Type", "1");
            command.Parameters.AddWithValue("@Pay_Amount", "10000");
            command.Parameters.AddWithValue("@PT_Level_C", "1");
            command.ExecuteNonQuery();
        }

        private void Clear()
        {
            EmployeeIDText.Text = "";
            firstnameText.Text = "";
            lastnameText.Text = "";
            Email.Text = "";
            Phone_Number.Text = "";
            SSN.Text = "";
            IDPayRates.Text = "";
            BirthdaySelect.Text = "";
            Employment_ST.Text = "";
            Hire_dateSelect.Text = "";
            EmployeeNum.Text = "";
            Gender.ClearSelection();
        }
    }
}