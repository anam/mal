using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_Attendence : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadEmployee();
        }
    }
    private void loadEmployee()
    {
        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();

        ListItem li = new ListItem("Select Employee...", "0");
        ddlAccountingUser.Items.Add(li);
        ddlEmployee.Items.Add(li);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeNo"].ToString());
                ddlAccountingUser.Items.Add(item);
            }
        }

        ddlAccountingUser.SelectedValue = Profile.card_id;


        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeNo"].ToString());
                ddlEmployee.Items.Add(item);
            }
        }

        ddlAccountingUser.SelectedValue = Profile.card_id;
        ddlEmployee.SelectedValue = Profile.card_id;


        txtInOutTime.Text = DateTime.Now.ToString();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Attendence attendence = new Attendence();

        attendence.UserID = ddlAccountingUser.SelectedValue;
        attendence.InOutTime = DateTime.Parse(txtInOutTime.Text);
        int resutl = AttendenceManager.InsertAttendence(attendence);

        showAttendenceGrid();
        btnViewReport_Click(this, new EventArgs());
    }

    private void showAttendenceGrid()
    {
        //gvAttendence.DataSource = AttendenceManager.GetAllAttendences();
        //gvAttendence.DataBind();
    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {

        List<EmployeeSchedule> employeeSchedule = new List<EmployeeSchedule>();
        List<EmployeeLeave> employeeLeave = new List<EmployeeLeave>();

        if (ddlEmployee.SelectedIndex == 0)
        {
            employeeSchedule = EmployeeScheduleManager.GetAllEmployeeSchedulesWithHistory();
            employeeLeave = EmployeeLeaveManager.GetAllEmployeeLeaves();
        }
        else
        {
            employeeSchedule = EmployeeScheduleManager.GetAllEmployeeSchedulesByEmployeeIDWithHistory(HR_EmployeeManager.GetHR_EmployeeByEmployeeNo(ddlEmployee.SelectedValue).EmployeeID);
            employeeLeave = EmployeeLeaveManager.GetAllEmployeeLeavesByEmployeeID(HR_EmployeeManager.GetHR_EmployeeByEmployeeNo(ddlEmployee.SelectedValue).EmployeeID,txtDateFrom.Text,txtDateTo.Text);
        }

        List<Attendence> attendences = new List<Attendence>();

        List<Attendence> attendencesTimeDuration = new List<Attendence>();
        string date = "";
        lblReprtHeader.Text = "<h1 align='center'>Chartered University College</h1>";
        if (txtDate.Text != date)
        {
            date = " (InOutTime >= '" + DateTime.Parse(txtDate.Text).ToString("yyyy-MM-dd") + " 00:00:00' and InOutTime <= '" + DateTime.Parse(txtDate.Text).ToString("yyyy-MM-dd") + " 23:59:00')";
            lblReprtHeader.Text += "<center><b>Date:</b> " + DateTime.Parse(txtDate.Text).ToString("dd MMM, yyyy") + "</center>"; 
        }
        else if (txtDateFrom.Text != date && txtDateTo.Text != date)
        {
            date = " (InOutTime >= '" + DateTime.Parse(txtDateFrom.Text).ToString("yyyy-MM-dd") + " 00:00:00' and InOutTime <= '" + DateTime.Parse(txtDateTo.Text).ToString("yyyy-MM-dd") + " 23:59:00')";
            lblReprtHeader.Text += "<center><b>Date:</b> " + DateTime.Parse(txtDateFrom.Text).ToString("dd MMM, yyyy") + " to " + DateTime.Parse(txtDateTo.Text).ToString("dd MMM, yyyy") + "</center>"; 
        }

        if (ddlEmployee.SelectedValue != "0")
        {
            lblReprtHeader.Text += "<br/><center><b>Employee:</b> " + ddlEmployee.SelectedItem.Text + "</center>";
        }
        lblReprtHeader.Text += "<br/>";

        lblSummaryReportHeader.Text = lblReprtHeader.Text;
        lblGriphicalReportHeader.Text = lblReprtHeader.Text;

        attendences = AttendenceManager.GetAllAttendencesByUserIDnDate(ddlEmployee.SelectedValue == "0" ? "" : "'" + ddlEmployee.SelectedValue + "'", date);
        

        List<List<Attendence>> attendenceList = new List<List<Attendence>>();
        List<List<Attendence>>  totalWorking = new List<List<Attendence>>();
        List<Attendence> attendenceListIeam = new List<Attendence>();
        string lastUesrID = "";
        int counter = 0;
        foreach (Attendence item in attendences)
        {
            if (lastUesrID == "") lastUesrID = item.UserID;

            if (lastUesrID == item.UserID)
            {
                attendenceListIeam.Add(item);
            }
            else
            {
                lastUesrID = item.UserID;
                attendenceList.Add(attendenceListIeam);
                attendenceListIeam = new List<Attendence>();
                attendenceListIeam.Add(item);
            }

            counter++;
            if (counter == attendences.Count)
            {
                attendenceList.Add(attendenceListIeam);
            }
        }

        List<Attendence> finalList = new List<Attendence>();
        List<Attendence> finalListSummary = new List<Attendence>();

        string topDate = "<table border='1'><tr><td></td>";
        bool IstopdateClose = false;
        string employeereport = "";

        //foreach (List<Attendence> item in attendenceList)
        {
            attendences = new List<Attendence>();
            foreach (List<Attendence> item in attendenceList)
            {

                List<Attendence> totalWorkingItem = new List<Attendence>();
                if (txtDateFrom.Text != "")
                {
                    for (int i = 0; DateTime.Parse(txtDateFrom.Text).AddDays(i) <=  DateTime.Parse(txtDateTo.Text); i++)
                    {
                        
                        Attendence attendenc_Item = new Attendence();
                        attendenc_Item.Day = DateTime.Parse(txtDateFrom.Text).AddDays(i);
                        totalWorkingItem.Add(attendenc_Item);
                    }
                }

                Attendence finalListSummaryItem = new Attendence();
                
                attendencesTimeDuration = new List<Attendence>();
                attendences = new List<Attendence>();
                attendences = item;
                //attendences = attendenceList[1];

                for (int i = 1; i < attendences.Count; i++)
                {
                    if (((attendences[i].InOutTime.Subtract(attendences[i - 1].InOutTime).Days * 24 * 60) + (attendences[i].InOutTime.Subtract(attendences[i - 1].InOutTime).Hours * 60) + attendences[i].InOutTime.Subtract(attendences[i - 1].InOutTime).Minutes) < 1)
                    {
                        attendences.RemoveAt(i);
                        i--;
                    }
                }


                for (int i = 0; i < attendences.Count; i++)
                {
                    Attendence newItem = new Attendence();
                    newItem = attendences[i];
                    newItem.InTime = attendences[i].InOutTime;

                    bool isFound = false;
                    foreach (EmployeeSchedule empSchedule in employeeSchedule)
                    {
                        if (empSchedule.EmployeeID == newItem.ID && empSchedule.RowStatusID == 14 && newItem.InOutTime.DayOfWeek.ToString() == empSchedule.ClassDay && DateTime.Parse(empSchedule.UpdateDate.ToShortDateString()) >  DateTime.Parse(newItem.InOutTime.ToShortDateString()))
                        {
                            newItem.StarttingOfficeTime = DateTime.Parse((newItem.InTime.ToShortDateString() + " " + empSchedule.StartTime));
                            newItem.EndOfficeTime = DateTime.Parse((newItem.InTime.ToShortDateString() + " " + empSchedule.EndTime));
                            isFound = true;
                            break;
                        }
                    }

                    if (!isFound)
                    {
                        foreach (EmployeeSchedule empSchedule in employeeSchedule)
                        {
                            if (empSchedule.EmployeeID == newItem.ID && empSchedule.RowStatusID == 1 && newItem.InOutTime.DayOfWeek.ToString() == empSchedule.ClassDay )
                            {
                                newItem.StarttingOfficeTime = DateTime.Parse((newItem.InTime.ToShortDateString() + " " + empSchedule.StartTime));
                                newItem.EndOfficeTime = DateTime.Parse((newItem.InTime.ToShortDateString() + " " + empSchedule.EndTime));
                                break;
                            }
                        }
                    }

                    //Working Day
                    foreach (Attendence att in totalWorkingItem)
                    {
                        att.IsOffDay=false;
                        foreach (EmployeeSchedule empSchedule in employeeSchedule)
                        {
                            if (empSchedule.EmployeeID == newItem.ID && empSchedule.RowStatusID == 1 && empSchedule.ClassDay == att.Day.DayOfWeek.ToString())
                            {
                                if (empSchedule.StartTime.Split(' ')[0] == "00:00")
                                {
                                    att.IsOffDay = true;
                                }
                                else
                                {
                                    att.Duration = (DateTime.Parse(att.Day.ToString("yyyy-MM-dd") + " " + empSchedule.EndTime).Subtract(DateTime.Parse(att.Day.ToString("yyyy-MM-dd") + " " + empSchedule.StartTime)).Hours * 60) + (DateTime.Parse(att.Day.ToString("yyyy-MM-dd") + " " + empSchedule.EndTime).Subtract(DateTime.Parse(att.Day.ToString("yyyy-MM-dd") + " " + empSchedule.StartTime)).Hours);
                                }
                                break;
                            }
                        }
                    }

                    newItem.DefaultTimeTextBoxVisible = false;
                    newItem.DefaultTimeLabelVisible = true;
                    while (true)
                    {
                        if (attendences.Count > ++i)
                        {
                            if (((attendences[i].InOutTime.Subtract(newItem.InTime).Days * 24 * 60) + (attendences[i].InOutTime.Subtract(newItem.InTime).Hours * 60) + attendences[i].InOutTime.Subtract(newItem.InTime).Minutes) > 1)
                            {
                                

                                if (newItem.InTime.Date == attendences[i].InOutTime.Date)
                                {
                                    newItem.OutTime = attendences[i].InOutTime;
                                }
                                else
                                {


                                    if (newItem.EndOfficeTime.ToString("hh:mm") == "00:00")
                                    {
                                        newItem.OutTime = DateTime.Parse(newItem.InTime.ToShortDateString() + " 06:00 PM");
                                    }
                                    else
                                    {
                                        newItem.OutTime = DateTime.Parse(newItem.InTime.ToShortDateString() + " " + newItem.EndOfficeTime.ToString("hh:mm:ss tt"));
                                    } 
                                    newItem.DefaultTimeTextBoxVisible = true;
                                    newItem.DefaultTimeLabelVisible = false;
                                    i--;
                                }
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }


                    if (newItem.OutTime < DateTime.Parse("21 Feb 2012"))
                    {
                        if (newItem.EndOfficeTime.ToString("hh:mm") == "00:00")
                        {
                            newItem.OutTime = DateTime.Parse(newItem.InTime.ToShortDateString() + " 06:00 PM");
                        }
                        else
                        {
                            newItem.OutTime = DateTime.Parse(newItem.InTime.ToShortDateString() + " " + newItem.EndOfficeTime.ToString("hh:mm:ss tt"));
                        }
                        newItem.DefaultTimeTextBoxVisible = true;
                        newItem.DefaultTimeLabelVisible = false;
                    }

                    newItem.Duration = (newItem.OutTime.Subtract(newItem.InTime).Hours * 60 * 60) + (newItem.OutTime.Subtract(newItem.InTime).Minutes * 60) + newItem.OutTime.Subtract(newItem.InTime).Seconds;
                    if (newItem.Duration < 0)
                    {
                        newItem.OutTime = newItem.InTime.AddMinutes(5);
                        newItem.Duration = (newItem.OutTime.Subtract(newItem.InTime).Hours * 60 * 60) + (newItem.OutTime.Subtract(newItem.InTime).Minutes * 60) + newItem.OutTime.Subtract(newItem.InTime).Seconds;
                    }

                    //newItem.DurationDisplay = (newItem.OutTime - newItem.InTime).Hours.ToString() + " hour(s) : " + (newItem.OutTime - newItem.InTime).Minutes.ToString() + " Min(s)";
                    newItem.DurationDisplay = ((newItem.OutTime.Subtract(newItem.InTime).Days * 24) + (newItem.OutTime.Subtract(newItem.InTime).Hours)).ToString() +":" + newItem.OutTime.Subtract(newItem.InTime).Minutes.ToString();
                    attendencesTimeDuration.Add(newItem);
                }


                //gvAttendencePerEmployee.DataSource = attendences;
                //gvAttendencePerEmployee.DataBind();

                int lastLateDuration = attendencesTimeDuration[0].Duration;
                int lastIndex = 0;
                attendencesTimeDuration[0].DateDisplay = attendencesTimeDuration[0].InTime.ToString("dd MMM yyyy dddd");



                for (int i = 1; i < attendencesTimeDuration.Count; i++)
                {
                    if (attendencesTimeDuration[i - 1].InTime.ToShortDateString() != attendencesTimeDuration[i].InTime.ToShortDateString())
                    {
                        lastIndex = i;
                        attendencesTimeDuration[i].DateDisplay = attendencesTimeDuration[i].InTime.ToString("dd MMM yyyy dddd");
                        lastIndex = i;
                    }
                    else
                    {
                        attendencesTimeDuration[lastIndex].Duration += attendencesTimeDuration[i].Duration;
                        attendencesTimeDuration[i].DateDisplay = "";
                    }
                }

                int lastDisplay = 0;
                for (int i = 0; i < attendencesTimeDuration.Count; i++)
                {
                    if (attendencesTimeDuration[i].DateDisplay != "")
                    {
                        //processing the late count
                        if (attendencesTimeDuration[i].EndOfficeTime.ToString("hh:mm tt") != "12:00 AM")
                        {
                            attendencesTimeDuration[i].EarlyLeaveInMin = (attendencesTimeDuration[i].EndOfficeTime.Subtract(attendencesTimeDuration[i].OutTime).Hours * 60) + (attendencesTimeDuration[i].EndOfficeTime.Subtract(attendencesTimeDuration[i].OutTime).Minutes);
                            if (attendencesTimeDuration[i].EarlyLeaveInMin > 0)
                            {
                                //attendencesTimeDuration[i].EarlyLeaveInMin *= -1;
                                attendencesTimeDuration[i].EarlyLeaveDisplay = (attendencesTimeDuration[i].EarlyLeaveInMin / 60).ToString() + ":" + (attendencesTimeDuration[i].EarlyLeaveInMin % 60).ToString();
                            }
                            else
                            {
                                attendencesTimeDuration[i].EarlyLeaveInMin = 0;
                                attendencesTimeDuration[i].EarlyLeaveDisplay = "0:00";
                            }
                        }
                        else
                        {
                            attendencesTimeDuration[i].EarlyLeaveInMin = 0;
                            attendencesTimeDuration[i].EarlyLeaveDisplay = "0:00";
                        }


                        attendencesTimeDuration[i].UserNameDisplay = attendencesTimeDuration[i].UserName;
                        attendencesTimeDuration[i].UserIDDisplay = attendencesTimeDuration[i].UserID;
                        attendencesTimeDuration[i].TotalDuratinDisplay = (attendencesTimeDuration[i].Duration / (60 * 60)).ToString() + ":" + ((attendencesTimeDuration[i].Duration % (60 * 60)) / 60).ToString();


                        if (attendencesTimeDuration[i].StarttingOfficeTime.ToString("hh:mm tt") != "12:00 AM")
                        {
                            attendencesTimeDuration[i].StarttingOfficeTimeDisplay = attendencesTimeDuration[i].StarttingOfficeTime.ToString("hh:mm tt");
                            attendencesTimeDuration[i].EndOfficeTimeDisplay = attendencesTimeDuration[i].EndOfficeTime.ToString("hh:mm tt");
                            attendencesTimeDuration[i].LateComeInMin = (attendencesTimeDuration[i].StarttingOfficeTime.Subtract(attendencesTimeDuration[i].InTime).Hours * 60) + (attendencesTimeDuration[i].StarttingOfficeTime.Subtract(attendencesTimeDuration[i].InTime).Minutes);
                            if (attendencesTimeDuration[i].LateComeInMin < 0)
                            {
                                attendencesTimeDuration[i].LateComeInMin *= -1;
                                attendencesTimeDuration[i].LateComeDisplay = (attendencesTimeDuration[i].LateComeInMin / 60).ToString() + ":" + (attendencesTimeDuration[i].LateComeInMin % 60).ToString();
                            }
                            else
                            {
                                attendencesTimeDuration[i].LateComeInMin = 0;
                                attendencesTimeDuration[i].LateComeDisplay = "0:00";
                            }
                        }
                        else
                        {
                            attendencesTimeDuration[i].LateComeInMin = 0;
                            attendencesTimeDuration[i].LateComeDisplay = "0:00";
                        }

                        lastDisplay = i;
                    }
                }

                foreach (Attendence att in totalWorkingItem)
                {
                    att.IsPresent = false;
                }

                foreach (Attendence itemChild in attendencesTimeDuration)
                {

                    //Monthly Summary of each employee
                    if (itemChild.DateDisplay != "")
                    {
                        finalListSummaryItem.UserID = itemChild.UserID;
                        finalListSummaryItem.UserIDDisplay = itemChild.UserIDDisplay;
                        finalListSummaryItem.UserName = itemChild.UserName;
                        finalListSummaryItem.UserNameDisplay = itemChild.UserNameDisplay;
                        finalListSummaryItem.UserNameDisplay = itemChild.UserNameDisplay;
                        finalListSummaryItem.LateComeInMin += itemChild.LateComeInMin;
                        finalListSummaryItem.EarlyLeaveInMin += itemChild.EarlyLeaveInMin;
                        finalListSummaryItem.Duration += itemChild.Duration / 60;  //in min

                        finalListSummaryItem.TotalWorkingTime += ((itemChild.EndOfficeTime.Subtract(itemChild.StarttingOfficeTime).Hours * 60) + (itemChild.EndOfficeTime.Subtract(itemChild.StarttingOfficeTime).Minutes));  //in min
                        
                        finalListSummaryItem.TotalWorked += 1;

                        if (itemChild.StarttingOfficeTimeDisplay == "" ||itemChild.StarttingOfficeTimeDisplay == null)//Offday work
                        {
                            finalListSummaryItem.TotalOffDayWorkingDay += 1;
                        }

                        foreach (EmployeeLeave empLeave in employeeLeave)
                        {
                            if (empLeave.EmployeeID == attendencesTimeDuration[0].ID)
                            {
                                if (itemChild.InTime.ToShortDateString() == empLeave.LeaveDate.ToShortDateString())
                                {
                                    finalListSummaryItem.TotalLeaveDayWorkingDay += 1;
                                    break;
                                }

                                //Working Day
                                foreach (Attendence att in totalWorkingItem)
                                {
                                    if (att.Day.ToShortDateString() == empLeave.LeaveDate.ToShortDateString())
                                    {
                                        att.IsLeaveDay = true;
                                    }
                                    else
                                    {
                                        att.IsLeaveDay = false;
                                    }
                                }

                            }
                        }

                        //Working Day
                        foreach (Attendence att in totalWorkingItem)
                        {
                            if (att.Day.ToShortDateString() == itemChild.InOutTime.ToShortDateString())
                            {
                                att.IsPresent = true;
                                break;
                            }                            
                        }

                    }                    

                    finalList.Add(itemChild);
                }


                foreach (EmployeeLeave empLeave in employeeLeave)
                {
                    if (empLeave.EmployeeID == attendencesTimeDuration[0].ID)
                    {
                        finalListSummaryItem.TotalLeaveDay += 1;
                    }
                }


                finalListSummaryItem.LateComeDisplay = finalListSummaryItem.LateComeInMin / 60 + ":" + finalListSummaryItem.LateComeInMin % 60;
                finalListSummaryItem.EarlyLeaveDisplay = finalListSummaryItem.EarlyLeaveInMin/60+ ":" +finalListSummaryItem.EarlyLeaveInMin%60;
                finalListSummaryItem.TotalDuratinDisplay = finalListSummaryItem.Duration / 60 + ":" + finalListSummaryItem.Duration % 60;
                finalListSummaryItem.TotalWorkingTimeDisplay = finalListSummaryItem.TotalWorkingTime / 60 + ":" + finalListSummaryItem.TotalWorkingTime % 60;
                //finalListSummaryItem.OverTimeDisplay = ((finalListSummaryItem.TotalWorkingTime - finalListSummaryItem.Duration) / 60) + ":" + ((finalListSummaryItem.TotalWorkingTime - finalListSummaryItem.Duration) % 60);

                foreach (Attendence attendence_cal in totalWorkingItem)
                {
                    if(!attendence_cal.IsOffDay && !attendence_cal.IsLeaveDay)
                    {
                        finalListSummaryItem.TotalOfficeTime += attendence_cal.Duration;
                        if (!attendence_cal.IsPresent)
                        {
                            finalListSummaryItem.AbsentDay += 1;
                        }
                    }
                }

                finalListSummaryItem.TotalOfficeTimeDisplay = (finalListSummaryItem.TotalOfficeTime / 60 )+ ":" + (finalListSummaryItem.TotalOfficeTime%60);
                finalListSummaryItem.OverTimeDisplay = ((finalListSummaryItem.TotalWorkingTime - finalListSummaryItem.TotalOfficeTime) / 60) + ":" + ((finalListSummaryItem.TotalWorkingTime - finalListSummaryItem.TotalOfficeTime) % 60);

                HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(attendencesTimeDuration[0].ID);

                if (employeeSalary != null)
                {
                    if (employeeSalary.IsGross)
                    {
                        finalListSummaryItem.Amount = (employeeSalary.GrossAmount / (30 * 8 *60)) * (finalListSummaryItem.TotalWorkingTime - finalListSummaryItem.TotalOfficeTime);
                    }
                    else
                    {
                        //txtAmount.Text = employeeSalary.BasicAmount.ToString();
                        finalListSummaryItem.Amount = (employeeSalary.BasicAmount / (30 * 8 * 60)) * (finalListSummaryItem.TotalWorkingTime - finalListSummaryItem.TotalOfficeTime);

                    }
                }

                employeereport += "</tr><tr ><td  style='border: 1px solid black;'>" + finalListSummaryItem.UserIDDisplay + "</td>";

                foreach (Attendence workingitem in totalWorkingItem)
                {
                    if (!IstopdateClose)
                    {
                        topDate += "<td  style='border: 1px solid black;'>" + workingitem.Day.ToString("dd-MM-yyyy").Substring(0, 2) + "<br/>" + workingitem.Day.ToString("MMM-dd-yyyy").Substring(0, 3) + "<br/>" + workingitem.Day.DayOfWeek.ToString().Substring(0, 1) + "</td>";
                    }

                    if (workingitem.IsPresent)
                    {
                        employeereport += "<td style='background-color:green;border: 1px solid black;'>P</td>";
                    }
                    else if (!workingitem.IsPresent && !workingitem.IsOffDay && !workingitem.IsOffDay)
                    {
                        employeereport += "<td style='background-color:Red;border: 1px solid black;'>A</td>";
                    }
                    else if (workingitem.IsOffDay)
                    {
                        employeereport += "<td style='background-color:Yellow;border: 1px solid black;'>O</td>";
                    }
                    else if (workingitem.IsLeaveDay)
                    {
                        employeereport += "<td style='background-color:Blue;border: 1px solid black;'>L</td>";
                    }

                }

                if (!IstopdateClose)
                {
                    IstopdateClose = true;   
                }

                finalListSummary.Add(finalListSummaryItem);


                //gvMonthSummary.DataSource = totalWorkingItem;
                //gvMonthSummary.DataBind();

            }

            lblGriphicalReport.Text = topDate + employeereport + "</tr></table>";
            gvAttendenceDuration.DataSource = finalList;
            gvAttendenceDuration.DataBind();

            gvTotalSummary.DataSource = finalListSummary;
            gvTotalSummary.DataBind();

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in gvAttendenceDuration.Rows)
        {
            TextBox txtOutTime = (TextBox)gr.FindControl("txtOutTime");
            if (txtOutTime.Visible && txtOutTime.Text != "")
            {
                Attendence attendence = new Attendence();

                attendence.UserID = ((HiddenField)gr.FindControl("hfUserID")).Value;
                attendence.InOutTime = DateTime.Parse(((HiddenField)gr.FindControl("hfDate")).Value + " " + txtOutTime.Text);
                AttendenceManager.InsertAttendence(attendence);
            }
        }
        btnViewReport_Click(this, new EventArgs());
    }
    protected void btnApplyPayment_Click(object sender, EventArgs e)
    {

    }
}