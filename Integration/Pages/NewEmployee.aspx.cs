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
        string sql;
        string query;
        SqlConnection SqlConn;
        SqlDataAdapter SqlAdapter;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //SQL server
            SqlConn = new SqlConnection(connectstring);
            SqlConn.Open();
            sql = "SELECT DISTINCT Department FROM Job_History";
            SqlAdapter = new SqlDataAdapter(sql, SqlConn);
            DataSet datasetDP = new DataSet();
            DataSet datasetBP = new DataSet();
            SqlAdapter.Fill(datasetDP);
            sql = "SELECT DISTINCT Benefit_Plan_ID AS 'Plan ID', Plan_Name AS 'Benefit Plans' FROM  Benefit_Plans";
            SqlAdapter = new SqlDataAdapter(sql, SqlConn);
            SqlAdapter.Fill(datasetBP);
            SqlConn.Close();
            department.DataTextField = datasetDP.Tables[0].Columns["Department"].ToString();
            department.DataValueField = datasetDP.Tables[0].Columns["Department"].ToString();
            department.DataSource = datasetDP.Tables[0];
            department.DataBind();
            BenefitPlanID.DataTextField = datasetBP.Tables[0].Columns["Benefit Plans"].ToString();
            BenefitPlanID.DataValueField = datasetBP.Tables[0].Columns["Plan ID"].ToString();
            BenefitPlanID.DataSource = datasetBP.Tables[0];
            BenefitPlanID.DataBind();
        }
        protected void Add_Click(object sender, EventArgs e)
        {

            var sql = "INSERT INTO Personal (Employee_ID, First_Name, Last_Name, Middle_Initial, " +
                "Address1, Address2, City, State, Zip, Email, Phone_Number, Social_Security_Number, " +
                "Drivers_License, Marital_Status, Gender, Shareholder_Status, Benefit_Plans, " +
                "Ethnicity, Date_of_birth) values (Cast(@Employee_ID AS Decimal(18,0)), " +
                "@First_Name, @Last_Name, @Middle_Initial, @Address1, @Address2, @City, @State, @Zip, @Email, @Phone_Number, @Social_Security_Number, " +
                 "@Drivers_License, @Marital_Status, @Gender, @Shareholder_Status, (Cast(@Benefit_Plans AS Decimal(18,0)), " +
                  "@Ethnicity, @Date_of_birth)";
            using (SqlConnection cnn = new SqlConnection(connectstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("Employee_ID", EmployeeIDText.Text);
                    cmd.Parameters.AddWithValue("First_Name", firstnameText.Text);
                    cmd.Parameters.AddWithValue("Last_Name", lastnameText.Text);
                    cmd.Parameters.AddWithValue("Middle_Initial", null);
                    cmd.Parameters.AddWithValue("Address1", null);
                    cmd.Parameters.AddWithValue("Address2", null);
                    cmd.Parameters.AddWithValue("City", null);
                    cmd.Parameters.AddWithValue("State", null);
                    cmd.Parameters.AddWithValue("Zip", null);
                    cmd.Parameters.AddWithValue("Email", Email.Text);
                    cmd.Parameters.AddWithValue("Phone_Number", Phone_Number.Text);
                    cmd.Parameters.AddWithValue("Social_Security_Number", SSN.Text);
                    cmd.Parameters.AddWithValue("Drivers_License", null);
                    cmd.Parameters.AddWithValue("Marital_Status", null);
                    cmd.Parameters.AddWithValue("Gender", null);
                    cmd.Parameters.AddWithValue("Shareholder_Status", 1);
                    cmd.Parameters.AddWithValue("Benefit_Plans", 1);
                    cmd.Parameters.AddWithValue("Ethnicity", null);
                    cmd.Parameters.AddWithValue("Date_of_birth", null);

                    cnn.Open();
                }
            }

            EmployeeIDText.Text = "";
            firstnameText.Text = "";
            lastnameText.Text = "";
            Email.Text = "";
            Phone_Number.Text = "";
            SSN.Text = "";
        }
    }
}