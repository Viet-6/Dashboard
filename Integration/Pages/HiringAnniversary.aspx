﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiringAnniversary.aspx.cs" Inherits="Integration.Pages.HiringAnniversary" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard</title>
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <link rel="stylesheet" href="../css/all.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="../css/Table_day.css">
    <link rel="stylesheet" href="https://maxst.icons8.com/vue-static/landings/line-awesome/line-awesome/1.3.0/css/line-awesome.min.css">
</head>
<body>
    <form runat ="server">
    <input type="checkbox" name="" id="nav-toggle">
    <div class="slidebar">
        <div class="slidebar-brand">
            <h2><span class="lab la-accusoft"></span> <b class="logo">Management System</b> </h2>
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
                    <li style="border-bottom:.3rem solid black;">
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
    <div class="main-content">
        <header>
            <h2>
                <label for="nav-toggle">
                    <span class="las la-bars"></span>
                </label> Hiring Anniversary
            </h2>
            <div class="user-wrapper">
                <div class="nav">
                    <li>
                        <a href="#" class="fas fa-chevron-down"></a>
                        <ul class="subnav">
                            <li><a href="#"><i class="fas fa-user-circle  m-r-10"></i>Account</a></li>
                            <li><a href="#"><i class="fas fa-cogs m-r-10"></i>Setting</a></li>
                            <li><a href="Index.aspx"><i class="fas fa-sign-out-alt m-r-10"></i>Log Out</a></li>
                        </ul>
                    </li>
                </div>
                <img src="../images/face.jpg" width="40px" height="40px" alt="">
                <div>
                    <h4>Tuan</h4>
                    <small>Super admin</small>
                </div>
            </div>
        </header>
        <main>
            <form action="">
                Search:
                <b>Year</b>
                <select name="Year" class="choose" id="">
                    <option value="Year">2025</option>
                    <option value="Year">2024</option>
                    <option value="Year">2023</option>
                    <option value="Year">2022</option>
                    <option value="Year">2021</option>
                    <option value="Year">2020</option>
                    <option value="Year">2019</option>
                    <option value="Year">2018</option>
                    <option value="Year">2017</option>
                    <option value="Year">2016</option>
                </select>
                <b>Month</b>
                <select name="Month" class="choose" id="">
                    <option value="Month">1</option>
                    <option value="Month">2</option>
                    <option value="Month">3</option>
                    <option value="Month">4</option>
                    <option value="Month">5</option>
                    <option value="Month">6</option>
                    <option value="Month">7</option>
                    <option value="Month">8</option>
                    <option value="Month">9</option>
                    <option value="Month">10</option>
                    <option value="Month">11</option>
                    <option value="Month">12</option>
                </select>
                <input type="submit" class="find" value="FIND">
            </form>

            <div class="recent-grid">
                <div class="projects">
                    <div class="card">
                        <div class="card-header">
                            <h2>Employee List</h2>
                            <button>Next<span class="fa fa-arrow-right "></span></button>
                        </div>
                        <div class="card-body">
                            <table width="100%">
                                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </div>
    <script src="/js/MonthYear.js"></script>
    </form>
</body>
</html>