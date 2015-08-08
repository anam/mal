using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
public partial class AdminSTD_RoutineTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            CampuesLoad();//           loadSTD_RoutineTimeData();
            //RoomIDLoad();
            //SubjectIDLoad();
            //EmployeeIDLoad();
            ClassIDLoad();
            //ClassDayIDLoad();
            //ClassTimeIDLoad();
           
            //RoutineIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showSTD_RoutineTimeData();
            }
        }
    }

    private void _showDayAndTime()
    {
        gvClassDay.DataSource = STD_ClassDayManager.GetAllSTD_ClassDaies();
        gvClassDay.DataBind();
    }

    private void CampuesLoad()
    {
        try
        {
            DataSet ds = STD_CampusManager.GetDropDownListAllSTD_Campus();
            ddlCampus.DataValueField = "CampusID";
            ddlCampus.DataTextField = "CampusName";
            ddlCampus.DataSource = ds.Tables[0];
            ddlCampus.DataBind();
            ddlCampus.Items.Insert(0, new ListItem("Select Campus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblMessage.Text= varifyConfict();
            if (lblMessage.Text != "")
                return;
            
            STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();

            sTD_RoutineTime.RoutineTimeName = "(" + ddlSubjectID.SelectedItem.Text.Split('(')[0] + ")(" + ddlClassID.SelectedItem.Text + ")(" + ddlEmployeeID.SelectedItem.Text + ")(" + ddlRoomID.SelectedItem.Text.Split('(')[0] + ")";
            sTD_RoutineTime.RoomID = int.Parse(ddlRoomID.SelectedValue);
            sTD_RoutineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            sTD_RoutineTime.EmployeeID = ddlEmployeeID.SelectedValue;
            sTD_RoutineTime.ClassID = int.Parse(ddlClassID.SelectedValue);
            //sTD_RoutineTime.ClassDayID = int.Parse(ddlClassDayID.SelectedValue);
            //sTD_RoutineTime.ClassTimeID = int.Parse(ddlClassTimeID.SelectedValue);
            sTD_RoutineTime.RoutineID = int.Parse(ddlRoutineID.SelectedValue);
            sTD_RoutineTime.AddedBy = Profile.card_id;
            sTD_RoutineTime.AddedDate = DateTime.Now;
            sTD_RoutineTime.UpdatedBy = Profile.card_id;
            sTD_RoutineTime.UpdateDate = DateTime.Now;

            int resutl = 0;
            foreach (GridViewRow row in gvClassDay.Rows)
            {
                Label lblDayID = (Label)row.FindControl("lblDayID");
                HiddenField hfDayID = (HiddenField)row.FindControl("hfDayID");
                DataList dlTime = (DataList)row.FindControl("dlTime");

                foreach (DataListItem iteam in dlTime.Items)
                {
                    HiddenField hfClassTimeID = (HiddenField)iteam.FindControl("hfClassTimeID");
                    CheckBox chkTime = (CheckBox)iteam.FindControl("chkTime");

                    if (chkTime.Checked)
                    {
                        sTD_RoutineTime.ClassTimeID = int.Parse(hfClassTimeID.Value);
                        sTD_RoutineTime.ClassDayID = int.Parse(hfDayID.Value);
                        try
                        {
                           resutl = STD_RoutineTimeManager.InsertSTD_RoutineTime(sTD_RoutineTime);
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                
                //CheckBoxList chkClassTime = (CheckBoxList)row.FindControl("chkClassTime");
                
                
                //string routineTime = "";
                //foreach (ListItem item in chkClassTime.Items)
                //{
                //    routineTime += item.Value + ",";
                //}
                //string[] spTime = routineTime.Split(',');

                //for (int i = 0; i < spTime.Length; i++)
                //{
                //    sTD_RoutineTime.ClassTimeID = Convert.ToInt32(spTime[i]);
                //    sTD_RoutineTime.ClassDayID = Convert.ToInt32(lblDayID.Text);

                //    int resutl = STD_RoutineTimeManager.InsertSTD_RoutineTime(sTD_RoutineTime);

                //    if (resutl == 0)
                //        lblMessage.Text = "Entry already exists for the time";
                //}
            }

            //int resutl = STD_RoutineTimeManager.InsertSTD_RoutineTime(sTD_RoutineTime);

            //if (resutl == 0)
            //    lblMessage.Text = "Entry already exists for the time";
            //else

            loadRoutine();
            btnAdd.Visible = false;
            //btnLoadDaynTime_Click(this, new EventArgs());


            //Response.Redirect("Class_Display_RoutineTime_ByValues.aspx?IsDelete=0&CampusID=" + ddlCampus.SelectedValue + "&RoutineID=" + ddlRoutineID.SelectedValue + "&ClassID=" + ddlClassID.SelectedValue + "&SubjectID=" + ddlSubjectID.SelectedValue + "&EmployeeID=" + ddlEmployeeID.SelectedValue );
        }
        catch (Exception ex)
        {
        }

    }

    private string varifyConfict()
    {
        string message = "";

        foreach (GridViewRow row in gvClassDay.Rows)
        {
            Label lblDayID = (Label)row.FindControl("lblDayID");
            HiddenField hfDayID = (HiddenField)row.FindControl("hfDayID");
            DataList dlTime = (DataList)row.FindControl("dlTime");
            Label lblDay = (Label)row.FindControl("lblDay");
            foreach (DataListItem iteam in dlTime.Items)
            {
                HiddenField hfClassTimeID = (HiddenField)iteam.FindControl("hfClassTimeID");
                HiddenField hfClassTimeName = (HiddenField)iteam.FindControl("hfClassTimeName");
                HiddenField hfExtraField3 = (HiddenField)iteam.FindControl("hfExtraField3");
                CheckBox chkTime = (CheckBox)iteam.FindControl("chkTime");

                if (chkTime.Checked)
                {
                    foreach (DataListItem checkIteam in dlTime.Items)
                    {
                        HiddenField hfClassTimeIDcheckIteam = (HiddenField)checkIteam.FindControl("hfClassTimeID");
                        HiddenField hfClassTimeNamecheckIteam = (HiddenField)checkIteam.FindControl("hfClassTimeName");
                        HiddenField hfExtraField3checkIteam = (HiddenField)checkIteam.FindControl("hfExtraField3");
                        CheckBox chkTimecheckIteam = (CheckBox)checkIteam.FindControl("chkTime");

                        if (chkTimecheckIteam.Checked && hfClassTimeID.Value != hfClassTimeIDcheckIteam.Value)
                        {
                            if (hfExtraField3checkIteam.Value.Contains(hfClassTimeID.Value + ";") || hfExtraField3.Value.Contains(hfClassTimeIDcheckIteam.Value + ";"))
                            {
                                if (!message.Contains(lblDay.Text + " : " + hfClassTimeName.Value + " & " + hfClassTimeNamecheckIteam.Value + " "))
                                {
                                    message += "</br>" + lblDay.Text + " : " + hfClassTimeName.Value + " & " + hfClassTimeNamecheckIteam.Value + " have time confict but both of them has checked....";
                                }
                            }
                        }
                    }
                }
            }
        }

        return message;
    }

    protected void btnVaryfyConfict_Click(object sender, EventArgs e)
    {


        lblMessage.Text = varifyConfict() ;
                
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
            sTD_RoutineTime.RoutineTimeID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_RoutineTime.RoutineTimeName = "(" + ddlSubjectID.SelectedItem.Text + ") (" + ddlClassID.SelectedItem.Text + ") (" + ddlEmployeeID.SelectedItem.Text + ") (" + ddlRoomID.SelectedItem.Text + ")";
            sTD_RoutineTime.RoomID = int.Parse(ddlRoomID.SelectedValue);
            sTD_RoutineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            sTD_RoutineTime.EmployeeID = ddlEmployeeID.SelectedValue;
            sTD_RoutineTime.ClassID = int.Parse(ddlClassID.SelectedValue);
            //sTD_RoutineTime.ClassDayID = int.Parse(ddlClassDayID.SelectedValue);
            //sTD_RoutineTime.ClassTimeID = int.Parse(ddlClassTimeID.SelectedValue);
            sTD_RoutineTime.RoutineID = 1;//int.Parse(ddlRoutineID.SelectedValue);
            sTD_RoutineTime.AddedBy = Profile.card_id;
            sTD_RoutineTime.AddedDate = DateTime.Now;
            sTD_RoutineTime.UpdatedBy = Profile.card_id;
            sTD_RoutineTime.UpdateDate = DateTime.Now;
            bool resutl = STD_RoutineTimeManager.UpdateSTD_RoutineTime(sTD_RoutineTime);
            Response.Redirect("AdminDisplaySTD_RoutineTime.aspx");
        }
        catch (Exception ex)
        {
        }
    }

    private void showSTD_RoutineTimeData()
    {
        try
        {

            STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
            sTD_RoutineTime = STD_RoutineTimeManager.GetSTD_RoutineTimeByRoutineTimeID(Int32.Parse(Request.QueryString["ID"]));
            txtRoutineTimeName.Text = sTD_RoutineTime.RoutineTimeName.ToString();
            //RoomIDLoad();
            //SubjectIDLoad();
            //EmployeeIDLoad();
            ddlRoomID.SelectedValue = sTD_RoutineTime.RoomID.ToString();
            ddlClassID.SelectedValue = sTD_RoutineTime.ClassID.ToString();
            ddlClassID_SelectedIndexChanged(this, new EventArgs());
            
            ddlSubjectID.SelectedValue = sTD_RoutineTime.SubjectID.ToString();
            ddlSubjectID_SelectedIndexChanged(this, new EventArgs());
            
            ddlEmployeeID.SelectedValue = sTD_RoutineTime.EmployeeID.ToString();
            
            //ddlClassDayID.SelectedValue = sTD_RoutineTime.ClassDayID.ToString();
            //ddlClassTimeID.SelectedValue = sTD_RoutineTime.ClassTimeID.ToString();
            //ddlRoutineID.SelectedValue = sTD_RoutineTime.RoutineID.ToString();
        }
        catch (Exception ex)
        {
        }
    }

    private void RoomIDLoad()
    {
        try
        {
            DataSet ds = STD_RoomManager.GetDropDownListAllSTD_Room();
            ddlRoomID.DataValueField = "RoomID";
            ddlRoomID.DataTextField = "RoomName";
            ddlRoomID.DataSource = ds.Tables[0];
            ddlRoomID.DataBind();
            ddlRoomID.Items.Insert(0, new ListItem("Select Room >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void SubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void EmployeeIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
            //ddlEmployeeID.Items.Insert(0, new ListItem("Mehdi Sir", "96b72550-3649-45c6-a1f5-0474a77f4fa5"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void ClassIDLoad()
    {
        try
        {
            DataSet ds = STD_ClassManager.GetDropDownListAllSTD_Class();
            ddlClassID.DataValueField = "ClassID";
            ddlClassID.DataTextField = "ClassName";
            ddlClassID.DataSource = ds.Tables[0];
            ddlClassID.DataBind();
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    //private void ClassDayIDLoad()
    //{
    //    try
    //    {
    //        DataSet ds = STD_ClassDayManager.GetDropDownListAllSTD_ClassDay();
    //        ddlClassDayID.DataValueField = "ClassDayID";
    //        ddlClassDayID.DataTextField = "ClassDayName";
    //        ddlClassDayID.DataSource = ds.Tables[0];
    //        ddlClassDayID.DataBind();
    //        ddlClassDayID.Items.Insert(0, new ListItem("Select ClassDay >>", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Message.ToString();
    //    }
    //}

    //private void ClassTimeIDLoad()
    //{
    //    try
    //    {
    //        DataSet ds = STD_ClassTimeManager.GetDropDownListAllSTD_ClassTime();
    //        ddlClassTimeID.DataValueField = "ClassTimeID";
    //        ddlClassTimeID.DataTextField = "ClassTimeName";
    //        ddlClassTimeID.DataSource = ds.Tables[0];
    //        ddlClassTimeID.DataBind();
    //        ddlClassTimeID.Items.Insert(0, new ListItem("Select ClassTime >>", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Message.ToString();
    //    }
    //}

    private void RoutineIDLoad(string campusID)
    {
        try
        {
            DataSet ds = STD_RoutineManager.GetDropDownListAllSTD_Routine();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if(dr["RoutineName"].ToString() != campusID)
                dr.Delete();
            }

            ddlRoutineID.DataValueField = "RoutineID";
            ddlRoutineID.DataTextField = "RoutineName";
            ddlRoutineID.DataSource = ds.Tables[0];
            ddlRoutineID.DataBind();
            //ddlRoutineID.Items.Insert(0, new ListItem("Select Routine >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            SubjectIDLoad(ClassID);
            //int SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            //EmployeeIDLoadByClassID(ClassID, SubjectID);
        }

    }
    protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCampus.SelectedValue != null)
        {
            long campasID = long.Parse(ddlCampus.SelectedValue);
            RoomIDLoad(campasID);
            RoutineIDLoad(ddlCampus.SelectedValue);
        }
    }

    private void RoomIDLoad(long CampusID)
    {
        try
        {
            DataSet ds = STD_RoomManager.GetSTD_CampusByCampusID(CampusID);

            ddlRoomID.Items.Clear();

            ListItem li = new ListItem("Select Room >>", "0");
            ddlRoomID.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["RoomName"].ToString() + " (" + dr["Description"].ToString() + " Students)", dr["RoomID"].ToString());
                ddlRoomID.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    private void SubjectIDLoad(int ClassID)
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectByClassID(ClassID);

            ddlSubjectID.Items.Clear();
            ListItem li = new ListItem("Select Subject >>", "0");
            ddlSubjectID.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["SubjectName"].ToString() + " (" + dr["NoOfStudents"].ToString() + " Students)", dr["SubjectID"].ToString());
                ddlSubjectID.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    private void EmployeeIDLoadByClassID(int ClassID, int SubjectID)
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_EmployeClassID(ClassID, SubjectID);
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
            //ddlEmployeeID.Items.Insert(0, new ListItem("Mehdi Sir", "96b72550-3649-45c6-a1f5-0474a77f4fa5"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            int SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            EmployeeIDLoadByClassID(ClassID, SubjectID);
        }
    }
    //public static List<STD_ClassTime> ListClassTime = new List<STD_ClassTime>();

    protected void OnRowDataBound_gvClassDay(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            List<STD_ClassTime> ListClassTime = new List<STD_ClassTime>();
            HiddenField hfDayID = (HiddenField)e.Row.FindControl("hfDayID");
            if (ListClassTime.Count == 0)
            {
                DataSet ds = STD_ClassTimeManager.GetAllSTD_ClassTimes();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    STD_ClassTime classTime = new STD_ClassTime();
                    classTime.ClassTimeID = int.Parse(dr["ClassTimeID"].ToString());
                    classTime.ClassTimeName = dr["ClassTimeName"].ToString();
                    classTime.ClassTimeGroupName = dr["ClassTimeGroupName"].ToString();
                    classTime.ClassTimeGroupID = int.Parse(dr["ClassTimeGroupID"].ToString());
                    classTime.ExtraField1 = dr["ExtraField1"].ToString();
                    classTime.ExtraField2 = dr["ExtraField2"].ToString();
                    classTime.ExtraField3 = dr["ExtraField3"].ToString();
                    classTime.IsEnabled = true;
                    classTime.CaseForDisabled = "";
                    
                    for (int i = int.Parse(dr["ExtraField1"].ToString())-1; i <= int.Parse(dr["ExtraField2"].ToString())+1; i++)
                    {
                        //if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";"))
                        //{
                        //    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";";
                        //}
                        if (hfDayIDTimeIDPair.Value.Contains(";" + hfDayID.Value + "-" +i.ToString() + ";"))
                        {
                            classTime.IsEnabled = false;
                            classTime.CaseForDisabled = "(Time Confickted)";
                           
                            foreach (ListItem li in ddlRoutineTimeIDnCause.Items)
                            {
                                if (li.Value == hfDayID.Value + "-" + dr["ClassTimeID"].ToString() + ";")
                                {
                                    if (classTime.CaseForDisabled.Contains("(Time Confickted)"))
                                    {
                                        classTime.CaseForDisabled ="";
                                    }
                                    if (!classTime.CaseForDisabled.Contains("?ID=" + li.Text.Split(';')[0].Substring(1) + "'>"))
                                    {
                                        if (classTime.CaseForDisabled != "") 
                                            classTime.CaseForDisabled += " & ";
                                        ddlRoutineTImeIDnValue.SelectedValue = li.Text.Split(';')[0].Substring(1);
                                        string routineTimeName = ddlRoutineTImeIDnValue.SelectedItem.Text;
                                        //string routineTimeName = STD_RoutineTimeManager.GetSTD_RoutineTimeByRoutineTimeID(int.Parse(li.Text.Split(';')[1].Substring(1))).RoutineTimeName;
                                        //classTime.CaseForDisabled += STD_RoutineTimeManager.GetSTD_RoutineTimeByRoutineTimeID(int.Parse(li.Text.Split(';')[1].Substring(1))).RoutineTimeName;//"<a target='_blank' href='Admin/DeleteClassByID.aspx?ID=" + li.Text.Split(';')[1].Substring(1) + "'>Click here To Delete " + STD_RoutineTimeManager.GetSTD_RoutineTimeByRoutineTimeID(int.Parse(li.Text.Split(';')[1].Substring(1))).RoutineTimeName + "</a>";
                                        classTime.CaseForDisabled += "<img alt='" + routineTimeName + "' src='../App_Themes/CoffeyGreen/images/Confusion.png' title='" + routineTimeName + "'/>";//"<a target='_blank' href='Admin/DeleteClassByID.aspx?ID=" + li.Text.Split(';')[1].Substring(1) + "'>Click here To Delete " + STD_RoutineTimeManager.GetSTD_RoutineTimeByRoutineTimeID(int.Parse(li.Text.Split(';')[1].Substring(1))).RoutineTimeName + "</a>";
                                    }
                                }
                            }
                            if (!classTime.CaseForDisabled.Contains("(Time Confickted)"))
                            {
                                classTime.CaseForDisabled = "(" + classTime.CaseForDisabled + ")";
                            }
                            
                        }
                    }



                    ListClassTime.Add(classTime);

                }
            }
            else
            {
                foreach (STD_ClassTime classTime in ListClassTime)
                {
                    classTime.IsEnabled = true;
                    classTime.CaseForDisabled = "";
                    for (int i = int.Parse(classTime.ExtraField1) - 1; i <= int.Parse(classTime.ExtraField2) + 1; i++)
                    {
                        //if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";"))
                        //{
                        //    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";";
                        //}
                        if (hfDayIDTimeIDPair.Value.Contains(";" + hfDayID.Value + "-" + i.ToString() + ";"))
                        {
                            classTime.IsEnabled = false;
                            classTime.CaseForDisabled = "Confickted with another Class";
                            foreach (ListItem li in ddlRoutineTimeIDnCause.Items)
                            {
                                if (li.Value == hfDayID.Value + "-" + classTime.ClassTimeID.ToString() + ";")
                                {
                                    classTime.CaseForDisabled = li.Text;
                                }
                            }
                        }
                    }


                    //if (hfDayIDTimeIDPair.Value.Contains(";" + hfDayID.Value + "-" + classTime.ClassTimeID + ";"))
                    //{
                    //    classTime.IsEnabled = false;
                    //}
                    //else
                    //{
                    //    classTime.IsEnabled = true;
                    //}
                }
            }
            DataList dlTime = (DataList)e.Row.FindControl("dlTime");

            //chkClassTime.DataValueField = "ClassTimeID";
            //chkClassTime.DataTextField = "ClassTimeName";            
            dlTime.DataSource = ListClassTime;
            dlTime.DataBind();
        }
    }

   

    protected void btnLoadDaynTime_Click(object sender, EventArgs e)
    {
        if (ddlRoomID.SelectedIndex != 0 && ddlEmployeeID.SelectedIndex != 0)
        {
            BindDayIDTimeIDPair();
            _showDayAndTime();
            btnAdd.Visible = true;
        }

    }

    private void fillddl(string value,string text)
    {
        
        List<ddl> ddlList = new List<ddl>();
        text += ";";
        value += ";";
        if (ddlRoutineTimeIDnCause.Items.Count == 0)
        {
            ddl newddl = new ddl();

            newddl.ddlText = text;

            newddl.ddlValue = value;
            ddlList.Add(newddl);
        }
        else
        {
            bool isFount = false;

            foreach (ListItem li in ddlRoutineTimeIDnCause.Items)
            {
                ddl newddl = new ddl();
                newddl.ddlText = li.Text;
                if (li.Value == value)
                {
                    if (!li.Text.Contains(text))
                       newddl.ddlText = li.Text + text;
                    isFount = true;
                }
                newddl.ddlValue = li.Value;
                ddlList.Add(newddl);
            }

            if (!isFount)
            {
                ddl newddl = new ddl();

                newddl.ddlText = text;

                newddl.ddlValue = value;
                ddlList.Add(newddl);
            }
        }
        ddlRoutineTimeIDnCause.Items.Clear();
        ddlRoutineTimeIDnCause.DataValueField = "ddlValue";
        ddlRoutineTimeIDnCause.DataTextField = "ddlText";
        ddlRoutineTimeIDnCause.DataSource = ddlList;
        ddlRoutineTimeIDnCause.DataBind();
    }

    private void fillddlForRoutine(string value, string text)
    {
        List<ddl> ddlList = new List<ddl>();
        if (ddlRoutineTImeIDnValue.Items.Count == 0)
        {
            ddl newddl = new ddl();

            newddl.ddlText = text;

            newddl.ddlValue = value;
            ddlList.Add(newddl);
        }
        else
        {
            bool isFount = false;

            foreach (ListItem li in ddlRoutineTImeIDnValue.Items)
            {
                ddl newddl = new ddl();
                newddl.ddlText = li.Text;
                if (li.Value == value)
                {
                    isFount = true;
                }
                newddl.ddlValue = li.Value;
                ddlList.Add(newddl);
            }

            if (!isFount)
            {
                ddl newddl = new ddl();

                newddl.ddlText = text;

                newddl.ddlValue = value;
                ddlList.Add(newddl);
            }
        }
        ddlRoutineTImeIDnValue.Items.Clear();
        ddlRoutineTImeIDnValue.DataValueField = "ddlValue";
        ddlRoutineTImeIDnValue.DataTextField = "ddlText";
        ddlRoutineTImeIDnValue.DataSource = ddlList;
        ddlRoutineTImeIDnValue.DataBind();
    }

    private void BindDayIDTimeIDPair()
    {
        string dayIDTimeIDPair = ";";

        STD_RoutineTime routineTime = new STD_RoutineTime();
        routineTime.RoomID = int.Parse(ddlRoomID.SelectedValue);
        routineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
        routineTime.ClassID = int.Parse(ddlClassID.SelectedValue);
        routineTime.EmployeeID = ddlEmployeeID.SelectedValue;
        
        DataSet dsRoomEmployeeClass= STD_RoutineTimeManager.STD_SearchRoutineTimeForRoutineCheck(routineTime,"");
        foreach (DataRow dr in dsRoomEmployeeClass.Tables[0].Rows)// table[0] == for Room
        {
            for (int i = int.Parse(dr["ExtraField1"].ToString()); i <= int.Parse(dr["ExtraField2"].ToString()); i++)
            {
                //if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";"))
                //{
                //    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";";
                //}
                if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + i.ToString() + ";"))
                {
                    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + i.ToString() + ";";
                }

            }
            fillddlForRoutine(dr["RoutineTimeID"].ToString(), getClassName(dr));
            fillddl(dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString(), "R" + dr["RoutineTimeID"].ToString());
        }
        lblHaveClassInHour.Text  = "0";
        lblTotalNoOfClasses.Text = dsRoomEmployeeClass.Tables[1].Rows.Count.ToString();
        foreach (DataRow dr in dsRoomEmployeeClass.Tables[1].Rows) // table[1] == Employee
        {
            for (int i = int.Parse(dr["ExtraField1"].ToString()); i <= int.Parse(dr["ExtraField2"].ToString()); i++)
            {
                //if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";"))
                //{
                //    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";";
                //}
                if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + i.ToString() + ";"))
                {
                    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + i.ToString() + ";";
                }
            }

            fillddlForRoutine(dr["RoutineTimeID"].ToString(), getClassName(dr));
            fillddl(dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString(), "T" + dr["RoutineTimeID"].ToString());
            lblHaveClassInHour.Text = (decimal.Parse(lblHaveClassInHour.Text) + decimal.Parse(dr["Duration"].ToString())).ToString();
        }

        lblHaveClassInHour.Text = (decimal.Parse(lblHaveClassInHour.Text) / 60).ToString("0") + " : " + (decimal.Parse(lblHaveClassInHour.Text) % 60).ToString();

        foreach (DataRow dr in dsRoomEmployeeClass.Tables[2].Rows) //table[2] == Class
        {
            for (int i = int.Parse(dr["ExtraField1"].ToString()); i <= int.Parse(dr["ExtraField2"].ToString()); i++)
            {
                //if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";"))
                //{
                //    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";";
                //}
                if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + i.ToString() + ";"))
                {
                    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + i.ToString() + ";";
                }
            }

            fillddlForRoutine(dr["RoutineTimeID"].ToString(), getClassName(dr));
            fillddl(dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString(), "C" + dr["RoutineTimeID"].ToString());

        }

        foreach (DataRow dr in dsRoomEmployeeClass.Tables[3].Rows) //table[2] == other Classes
        {
            for (int i = int.Parse(dr["ExtraField1"].ToString()); i <= int.Parse(dr["ExtraField2"].ToString()); i++)
            {
                //if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";"))
                //{
                //    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString() + ";";
                //}
                if (!dayIDTimeIDPair.Contains(";" + dr["ClassDayID"].ToString() + "-" + i.ToString() + ";"))
                {
                    dayIDTimeIDPair += dr["ClassDayID"].ToString() + "-" + i.ToString() + ";";
                }
            }

            fillddlForRoutine(dr["RoutineTimeID"].ToString(), getClassName(dr));
            fillddl(dr["ClassDayID"].ToString() + "-" + dr["ClassTimeID"].ToString(), "C" + dr["RoutineTimeID"].ToString());

        }


        hfDayIDTimeIDPair.Value= dayIDTimeIDPair;
    }

    private string getClassName(DataRow dr)
    {
        return "(" + dr["SubjectName"].ToString() + ") (" + dr["ClassName"].ToString() + ") (" + dr["EmployeeName"].ToString() + ") (" + dr["RoomName"].ToString()+")";
    }

    protected void ddlEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployeeID.SelectedIndex != 0)
        {
            gvWorkDayShift.Visible = true;
            gvEmployeeSchedule.DataSource = EmployeeScheduleManager.GetAllEmployeeSchedulesByEmployeeID(ddlEmployeeID.SelectedValue);
            gvEmployeeSchedule.DataBind();


            btnLoadDaynTime_Click(this, new EventArgs());
            lblRoutineDisplay.Text = "";
        }
        else
        {
            gvWorkDayShift.Visible = false;
        }
    }


    private void loadRoutine()
    {
        STD_RoutineTime routineTime = new STD_RoutineTime();
        routineTime.RoomID = 0;
        routineTime.RoutineID = ddlCampus.SelectedValue == "0" ? 0 : int.Parse(ddlRoutineID.SelectedValue);
        routineTime.ClassID = int.Parse(ddlClassID.SelectedValue);
        routineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
        routineTime.EmployeeID = ddlEmployeeID.SelectedValue == "0" ? "" : ddlEmployeeID.SelectedValue;
        string StudentID = "";
        lblRoutineDisplay.Text = STD_RoutineTimeManager.getRoutineTextDayTop(routineTime, StudentID).Replace(" style='display:none;'", "");
    }
}

