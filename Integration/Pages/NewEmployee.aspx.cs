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
    public partial class NewEmployee : System.Web.UI.Page
    {
        //Sql Server Connection string
        string connectstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HR;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //MySQL Connection string
        string constr = "Data Source=localhost;port=3306;Initial Catalog=mydb;User Id=root;password=root";
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
            "(CAST(@Employee_ID_Empl AS Decimal(18, 0)), @Employ_Stat, @Hire_date, " +
            "@Work_Comp, @Termination_date, @Rehire_date, @Last_review )";
            string insert_Personal = "INSERT INTO Personal (Employee_ID, "+
                "First_Name, Last_Name, Middle_Initial, Address1, Address2, City, "+
                "State, Zip, Email, Phone_Number, Social_Security_Number, " +
                "Drivers_License, Marital_Status, Gender, Shareholder_Status, Benefit_Plans, " +
                "Ethnicity, Date_of_birth) values (Cast(@Employee_ID AS Numeric(18,0)), " +
                "@First_Name, @Last_Name, @Middle_Initial, @Address1, @Address2, @City, @State, @Zip, @Email, @Phone_Number, @Social_Security_Number, " +
                 "@Drivers_License, @Marital_Status, @Gender, @Shareholder_Status, Cast(@Benefit_Plans AS Numeric(18,0)), " +
                  "@Ethnicity, @Date_of_birth)";
            string insert_Job = "insert into Job_History ([Employee_ID], [Department], [Division], [Start_Date], [End_Date], [Job_Title], [Supervisor], [Job_Category], [Location], [Departmen_Code], [Salary_Type], [Pay_Period], [Hours_per_Week], [Hazardous_Training]) values (Cast(@Employee_ID_JH AS Numeric(18,0)), @Department, @Division," +
            " getdate(), Cast(@End_Date AS datetime), @Job_Title, Cast(@Supervisor AS Numeric(18)), @Job_Category, @Location, Cast(@Department_Code AS Numeric(18))," +
            " Cast(@Salary_Type AS Numeric(18)), @Pay_Period, Cast(@Hours_per_Week AS Numeric(18)), @Hazardous )";
            string insert_payrates = "insert into `Pay rates` (`idPay Rates`, `Pay Rate Name`, `Value`, `Tax Percentage`, `Pay Type`, `Pay Amount`, `PT - Level C`)" +
                    " values (@idPay_Rates, @Pay_Rate_Name, Cast(@Value AS Decimal)," +
                    "Cast(@Tax_Percentage AS Decimal), @Pay_Type, Cast(@Pay_Amount AS Decimal), Cast(@PT_Level_C AS Decimal) )";
            string insert_Employee = "insert into Employee values (@Employee_ID, @Employee_Number, @First_Name, @Last_Name, Cast(@SSN AS NUMERIC), @Pay_Rate," +
               " @Pay_Rate_ID, @Vacation_Days, Cast(@Paid_To_Date As Decimal), Cast(@Paid_Last_Year As Decimal))";
            
            SqlDataSource cmd = new SqlDataSource();
            cmd.ConnectionString = connectstring;
            cmd.InsertCommandType = SqlDataSourceCommandType.Text;
            
            Insert_Personal(cmd,insert_Personal);
            Insert_Job_History(cmd,insert_Job);
            Insert_Employment(cmd,insert_employment);
            using (MySqlConnection connection = new MySqlConnection(constr))
            {
                Insert_Pay_Rates(insert_payrates,connection);
                Insert_Employee(insert_Employee,connection);
            }
            Clear();
        }

        private void Insert_Employment(SqlDataSource cmd, string insertsql)
        {//SQL Server Insert to Employment table
            cmd.InsertCommand = insertsql;
            cmd.InsertParameters.Add("Employee_ID_Empl", EmployeeIDText.Text);
            cmd.InsertParameters.Add("Employ_Stat", Employment_ST.Text);
            cmd.InsertParameters.Add("Hire_date", Hire_dateSelect.Text);
            cmd.InsertParameters.Add("Work_Comp", null);
            cmd.InsertParameters.Add("Termination_date", null);
            cmd.InsertParameters.Add("Rehire_date", null);
            cmd.InsertParameters.Add("Last_review", null);
            cmd.Insert();
        }

        private void Insert_Job_History(SqlDataSource cmd, string insertsql)
        {//SQL Server Insert to Job History table
            cmd.InsertCommand = insertsql;
            cmd.InsertParameters.Add("Employee_ID_JH", EmployeeIDText.Text);
            cmd.InsertParameters.Add("Department", department.SelectedValue);
            cmd.InsertParameters.Add("Division", null);
            cmd.InsertParameters.Add("End_Date", "2026-01-01");
            cmd.InsertParameters.Add("Job_Title", null);
            cmd.InsertParameters.Add("Supervisor", null);
            cmd.InsertParameters.Add("Job_Category", null);
            cmd.InsertParameters.Add("Location", null);
            cmd.InsertParameters.Add("Department_Code", null);
            cmd.InsertParameters.Add("Salary_Type", null);
            cmd.InsertParameters.Add("Pay_Period", null);
            cmd.InsertParameters.Add("Hours_per_Week", "7");
            cmd.InsertParameters.Add("Hazardous", null);
            cmd.Insert();
        }

        private void Insert_Personal(SqlDataSource cmd, string insertsql)
        {//SQL Server Insert to Personal table
            cmd.InsertCommand = insertsql;
            cmd.InsertParameters.Add("Employee_ID", EmployeeIDText.Text);
            cmd.InsertParameters.Add("First_Name", firstnameText.Text);
            cmd.InsertParameters.Add("Last_Name", lastnameText.Text);
            cmd.InsertParameters.Add("Middle_Initial", null);
            cmd.InsertParameters.Add("Address1", null);
            cmd.InsertParameters.Add("Address2", null);
            cmd.InsertParameters.Add("City", null);
            cmd.InsertParameters.Add("State", null);
            cmd.InsertParameters.Add("Zip", null);
            cmd.InsertParameters.Add("Email", Email.Text);
            cmd.InsertParameters.Add("Phone_Number", Phone_Number.Text);
            cmd.InsertParameters.Add("Social_Security_Number", SSN.Text);
            cmd.InsertParameters.Add("Drivers_License", null);
            cmd.InsertParameters.Add("Marital_Status", null);
            cmd.InsertParameters.Add("Gender", Gender.SelectedValue);
            cmd.InsertParameters.Add("Shareholder_Status", ShareholderSelect.SelectedValue);
            cmd.InsertParameters.Add("Benefit_Plans", BenefitPlanID.SelectedValue);
            cmd.InsertParameters.Add("Ethnicity", null);
            cmd.InsertParameters.Add("Date_of_birth", BirthdaySelect.Text);
            cmd.Insert();
        }

        private void Insert_Employee(string query, MySqlConnection connection)
        {
            //MySQL Employee Table
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Employee_ID", EmployeeIDText.Text);
                command.Parameters.AddWithValue("@Employee_Number", EmployeeNum.Text);
                command.Parameters.AddWithValue("@First_Name", firstnameText.Text);
                command.Parameters.AddWithValue("@Last_Name", lastnameText.Text);
                command.Parameters.AddWithValue("@SSN", SSN.Text);
                command.Parameters.AddWithValue("@Pay_Rate", "1");
                command.Parameters.AddWithValue("@Pay_Rate_ID", IDPayRates.Text);
                command.Parameters.AddWithValue("@Vacation_Days", "1");
                command.Parameters.AddWithValue("@Paid_To_Date", "1");
                command.Parameters.AddWithValue("@Paid_Last_Year", "1");
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
        }

        private void Insert_Pay_Rates(string query, MySqlConnection connection)
        {
            //MySQL Pay Rates Table
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPay_Rates", IDPayRates.Text);
                command.Parameters.AddWithValue("@Pay_Rate_Name", "VND");
                command.Parameters.AddWithValue("@Value", "100");
                command.Parameters.AddWithValue("@Tax_Percentage", "10");
                command.Parameters.AddWithValue("@Pay_Type", "1");
                command.Parameters.AddWithValue("@Pay_Amount", "10000");
                command.Parameters.AddWithValue("@PT_Level_C", "1");
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
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
            Gender.ClearSelection();
        }
    }
}