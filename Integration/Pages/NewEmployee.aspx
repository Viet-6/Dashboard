<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployee.aspx.cs" Inherits="Integration.Pages.NewEmployee" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Dashboard</title>
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <link rel="stylesheet" href="../css/all.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/NewEmployee.css" />
    <link rel="stylesheet"
        href="https://maxst.icons8.com/vue-static/landings/line-awesome/line-awesome/1.3.0/css/line-awesome.min.css" />
<script type="text/javascript" language="javascript">
    function numeric(evt)
    {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if(charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
                            return true;
               else
               {
                        alert('Please Enter Numeric values.');
                        return false;
               }
    }
    </script>
    <script type="text/javascript" language="javascript">
    function IDValid() {
        var Description = document.getElementById("<%= EmployeeIDText.ClientID %>");
        if (Description.value == "") {
            alert("Please Enter Employee ID!");
            Description.focus();
            return false;
        }
        Description = document.getElementById("<%= Hire_dateSelect.ClientID %>");
        if (Description.value == "") {
            alert("Please Select Hire Date!");
            Description.focus();
            return false;
        }
        Description = document.getElementById("<%= firstnameText.ClientID %>");
        if (Description.value == "") {
            alert("Please Enter Employee Name!");
            Description.focus();
            return false;
        }
        Description = document.getElementById("<%= BirthdaySelect.ClientID %>");
        if (Description.value == "") {
            alert("Please Select Date of Birth!");
            Description.focus();
            return false;
        }
        Description = document.getElementById("<%= Employment_ST.ClientID %>");
        if (Description.value == "") {
            alert("Please Enter Employment Status!");
            Description.focus();
            return false;
        }
        Description = document.getElementById("<%= EmployeeNum.ClientID %>");
        if (Description.value == "") {
            alert("Please Enter Employee Number!");
            Description.focus();
            return false;
        }
        Description = document.getElementById("<%= IDPayRates.ClientID %>");
        if (Description.value == "") {
            alert("Please Enter Employee Pay Rates ID!");
            Description.focus();
            return false;
        }
        Description = document.getElementById("<%= SSN.ClientID %>");
        if (Description.value == "") {
            alert("Please Enter Employee Social Security Number!");
            Description.focus();
            return false;
        }
        
        var email = Email;
        if (Email != null)
        {
            var emailRegex = new RegExp(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$/i);
            var emailAddress = document.getElementById("<%= Email.ClientID %>").value;
            var valid = emailRegex.test(emailAddress);
            if (!valid) {
                alert("Invalid e-mail address");
                return false;
            }
        }
        return true;
    }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="checkbox" name="" id="nav-toggle" />
        <div class="slidebar">
            <div class="slidebar-brand">
                <h2>
                    <span class="lab la-accusoft"></span>
                    <b class="logo">Management System</b>
                </h2>
            </div>
            <div class="slidebar-menu">
                <ul>
                    <li>
                        <a href="Dashboard.aspx"><span class="las la-igloo"></span><span>Dashboard</span></a>
                    </li>
                    <li class="menu"><b>INFORMATION</b></li>
                    <li>
                        <a href="TotalEarning.aspx"><span class="fas fa-coins"></span><span>Total Earning</span></a>
                    </li>
                    <li>
                        <a href="VacationDays.aspx"><span class="far fa-calendar-alt"></span><span>Vacation Days</span></a>
                    </li>
                    <li>
                        <a href="BenefitsPaid.aspx"><span class="fab fa-bitcoin"></span><span>Benefits Paid</span></a>
                    </li>
                    <li>
                        <a href="NewEmployee.aspx"><span class="fas fa-user-plus"></span><span>New Employee</span></a>
                    </li>
                    <li class="menu"><b>NOTIFICATION</b></li>
                    <li>
                        <a href="HiringAnniversary.aspx"><span class="fas fa-align-left"></span><span>Hiring Anniversary</span></a>
                    </li>
                    <li>
                        <a href="AccumulatedVacation.aspx"><span class="fas fa-route"></span><span>Accumulated Vacation</span></a>
                    </li>
                    <li>
                        <a href="ChangeBenefitsPlan.aspx"><span class="fas fa-trophy"></span><span>Change Benefits Plan</span></a>
                    </li>
                    <li style="border-bottom: .3rem solid black;">
                        <a href="Birthday.aspx"><span class="fas fa-birthday-cake"></span><span>Birthday</span></a>
                    </li>
                    <!-- <li>
                    <a href=""><span class="fas la-user-circle "></span><span>Account</span></a>
                </li> -->
                    <!-- <li>
                    <a href="#"><span class="fab fa-bitcoin"></span><span>Payroll</span></a>
                </li> -->
                </ul>
            </div>
        </div>
        <div>
            <div class="main-content">
                <header>
                    <h2>
                        <label for="nav-toggle">
                            <span class="las la-bars"></span>
                        </label>
                        New Employee
                    </h2>
                    <div class="user-wrapper">
                        <div class="nav">
                            <li>
                                <a href="#" class="fas fa-chevron-down"></a>
                                <ul class="subnav">
                                    <li>
                                        <a href="#"><i class="fas fa-user-circle m-r-10"></i>Account</a>
                                    </li>
                                    <li>
                                        <a href="#"><i class="fas fa-cogs m-r-10"></i>Setting</a>
                                    </li>
                                    <li>
                                        <a href="Index.aspx"><i class="fas fa-sign-out-alt m-r-10"></i>Log Out</a>
                                    </li>
                                </ul>
                            </li>
                        </div>
                        <img src="../images/face.jpg" width="40px" height="40px" alt="" />
                        <div>
                            <h4>Tuan</h4>
                            <small>Super admin</small>
                        </div>
                    </div>
                </header>
                <main>
            <div class="container-fluid">
                <div class="row justify-content-center">
                    <div class="col-12 col-xl-10">
                        <div class="row align-items-center my-4">
                            <div class="col">
                                <h2 class="h3 mb-0 page-title">Add Contact</h2>
                            </div>
                            <div class="col-auto">
                                <asp:Button class="btn btn-primary" ID="btn_add" runat="server" Text="Save Change" OnClientClick="return IDValid();" onclick="Add_Click"></asp:button>
                            </div>
                        </div>
                        <hr class="my-4" />
                            <div class="form-row">
                                <div class="form-group col-md-4 ">
                                    <label for="">Employee ID</label>
                                    <asp:TextBox ID="EmployeeIDText" runat="server" class="form-control" onkeypress="return numeric(event)">
                                    </asp:TextBox>
                                </div>
                                 <div class="form-group col-md-4 " >
                                    <label for="birthday">Hire Date</label>
                                        <asp:TextBox type ="date" ID="Hire_dateSelect" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-4 " > <br />
                                    <asp:RadioButtonList ID="Gender" runat="server" Width="161px" Height="25px" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Selected="True">Male</asp:ListItem>
                                        <asp:ListItem Value="0">Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                               
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="firstname">Firstname</label>
                                    <asp:TextBox ID="firstnameText" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="lastname">Lastname</label>
                                   <asp:TextBox ID="lastnameText" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-8">
                                    <label for="">Email</label>
                                    <asp:TextBox type ="email" ID="Email" runat="server" class="form-control" TextMode="Email"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Phone Number</label>
                                    <asp:TextBox ID="Phone_Number" runat="server" class="form-control" onkeypress="return numeric(event)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <form action="">
                                        <label for="birthday">Birthday</label>
                                        <asp:TextBox type ="date" ID="BirthdaySelect" runat="server" class="form-control"></asp:TextBox>
                                    </form>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Employment Status</label>
                                    <asp:TextBox ID="Employment_ST" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Benefit plan</label>
                                    <asp:DropDownList ID="BenefitPlanID" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="">Employee Number</label>
                                    <asp:TextBox ID="EmployeeNum" runat="server" class="form-control" onkeypress="return numeric(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="">SSN (Social Security Number)</label>
                                    <asp:TextBox ID="SSN" runat="server" class="form-control" onkeypress="return numeric(event)"></asp:TextBox>
                                </div>
                            </div>
                         <div class="form-row">
                                <div class="form-group col-md-4">
                                    <label for="">ID Pay Rates</label>
                                    <asp:TextBox ID="IDPayRates" runat="server" class="form-control" onkeypress="return numeric(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Shareholder Status</label>
                                        <asp:DropDownList ID="ShareholderSelect" runat="server" class="form-control">
                                            <asp:ListItem Text="Non-Shareholder" Value ="0"></asp:ListItem>
                                            <asp:ListItem Text="Shareholder" Value ="1"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                             <div class="form-group col-md-4">
                                    <label for="">Department</label>
                                    <asp:DropDownList ID="department" runat="server" class="form-control">
                                            <asp:ListItem Text="Designer" Value ="Designer"></asp:ListItem>
                                            <asp:ListItem Text="Developer" Value ="Developer"></asp:ListItem>
                                            <asp:ListItem Text="Tester" Value ="Tester"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
            </div>
    </form>
</body>
</html>
