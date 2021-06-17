﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployee.aspx.cs" Inherits="Integration.Pages.NewEmployee" %>

<!DOCTYPE html>
<html lang="en">
<head>
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
</head>
<body>
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
                                <button type="button" class="btn btn-primary">
                                    Save Change
                                </button>
                            </div>
                        </div>
                        <form>
                            <hr class="my-4" />
                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <label for="">Employee ID</label>
                                    <input class="form-control" id="" />
                                </div>
                                <div class="form-group col-md-4">

                                </div>
                                <div class="form-group col-md-4">

                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="firstname">Firstname</label>
                                    <input type="text" id="firstname" class="form-control" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="lastname">Lastname</label>
                                    <input type="text" id="lastname" class="form-control" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-8">
                                    <label for="">Email</label>
                                    <input type="email" class="form-control" id="" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Phone Number</label>
                                    <input type="text" class="form-control" id="" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <form action="">
                                        <label for="birthday">Birthday</label>
                                        <input class="form-control" type="date" id="birthday" name="birthday">
                                    </form>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Job ID</label>
                                    <input class="form-control" id="" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Benefit plan ID</label>
                                    <input id="" class="form-control" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="">Employee Number</label>
                                    <input type="text" id="lastname" class="form-control" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="">SSN (Social Security Number)</label>
                                    <input type="text" id="firstname" class="form-control" />
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <label for="">ID Pay Rates</label>
                                    <input id="" class="form-control" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Shareholder Status</label>
                                    <select id="" class="form-control">
                                        <option value="female">...</option>
                                        <option value="male">...</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="">Department</label>
                                    <select id="" class="form-control">
                                        <option value="female">...</option>
                                        <option value="male">...</option>
                                    </select>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </main>
    </div>
</body>
</html>