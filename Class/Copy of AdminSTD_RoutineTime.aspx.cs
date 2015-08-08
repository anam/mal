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
            //           loadSTD_RoutineTimeData();
            RoomIDLoad();
            SubjectIDLoad();
            EmployeeIDLoad();
            ClassIDLoad();
            //ClassDayIDLoad();
            //ClassTimeIDLoad();
            RoutineIDLoad();
            _showDayAndTime();

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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();

            sTD_RoutineTime.RoutineTimeName = txtRoutineTimeName.Text;
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

            foreach (GridView row in gvClassDay.Rows)
            {
                Label lblDayID = (Label)row.FindControl("lblDayID");
                CheckBoxList chkClassTime = (CheckBoxList)row.FindControl("chkClassTime");
                string routineTime = "";
                foreach (ListItem item in chkClassTime.Items)
                {
                    routineTime += item.Value + ",";
                }
                string[] spTime = routineTime.Split(',');

                for (int i = 0; i < spTime.Length; i++)
                {
                    sTD_RoutineTime.ClassTimeID = Convert.ToInt32(spTime[i]);
                    sTD_RoutineTime.ClassDayID = Convert.ToInt32(lblDayID.Text);

                    int resutl = STD_RoutineTimeManager.InsertSTD_RoutineTime(sTD_RoutineTime);

                    if (resutl == 0)
                        lblMessage.Text = "Entry already exists for the time";
                }
            }

            //string routineTime = "";

            //foreach (ListItem item in chkClassTime.Items)
            //{
            //    if (item.Selected)
            //        routineTime += item.Value + ",";
            //}

            //int resutl = STD_RoutineTimeManager.InsertSTD_RoutineTime(sTD_RoutineTime);

            //if (resutl == 0)
            //    lblMessage.Text = "Entry already exists for the time";
            //else
            //    Response.Redirect("AdminDisplaySTD_RoutineTime.aspx");
        }
        catch (Exception ex)
        {
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_RoutineTime sTD_RoutineTime = new STD_RoutineTime();
            sTD_RoutineTime.RoutineTimeID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_RoutineTime.RoutineTimeName = txtRoutineTimeName.Text;
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
            ddlRoomID.SelectedValue = sTD_RoutineTime.RoomID.ToString();
            ddlSubjectID.SelectedValue = sTD_RoutineTime.SubjectID.ToString();
            ddlEmployeeID.SelectedValue = sTD_RoutineTime.EmployeeID.ToString();
            ddlClassID.SelectedValue = sTD_RoutineTime.ClassID.ToString();
            //ddlClassDayID.SelectedValue = sTD_RoutineTime.ClassDayID.ToString();
            //ddlClassTimeID.SelectedValue = sTD_RoutineTime.ClassTimeID.ToString();
            ddlRoutineID.SelectedValue = sTD_RoutineTime.RoutineID.ToString();
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

    private void RoutineIDLoad()
    {
        try
        {
            DataSet ds = STD_RoutineManager.GetDropDownListAllSTD_Routine();
            ddlRoutineID.DataValueField = "RoutineID";
            ddlRoutineID.DataTextField = "RoutineName";
            ddlRoutineID.DataSource = ds.Tables[0];
            ddlRoutineID.DataBind();
            ddlRoutineID.Items.Insert(0, new ListItem("Select Routine >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void OnRowDataBound_gvClassDay(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataSet ds = STD_ClassTimeManager.GetDropDownListAllSTD_ClassTime();
            CheckBoxList chkClassTime = (CheckBoxList)e.Row.FindControl("chkClassTime");


            chkClassTime.DataValueField = "ClassTimeID";
            chkClassTime.DataTextField = "ClassTimeName";
            chkClassTime.DataSource = ds.Tables[0];
            chkClassTime.DataBind();
        }
    }

}

