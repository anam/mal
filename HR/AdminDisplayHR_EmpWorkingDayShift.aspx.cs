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


public partial class AdminDisplayHR_EmpWorkingDayShift : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MakeWorkDayShift();
        }
    }

    private void MakeWorkDayShift()
    {
        //string userID = Session["userID"].ToString();
        // if (userID != null)
        // {
        //     HR_WorkingDaysShifting hR_WorkingDayShift = HR_WorkingDaysShiftingManager.GetHR_WorkingDaysShiftingObjectByEmployeeID(userID);


        // gvWorkDayShift.DataSource = HR_WorkingDaysShiftingManager.GetHR_WorkingDaysShiftingTableByEmployeeID(userID);
        gvWorkDayShift.DataSource = HR_WorkingDaysShiftingManager.GetHR_WorkingDaysShiftingTableByEmployeeID("96b72550-3649-45c6-a1f5-0474a77f4fa6");

        gvWorkDayShift.DataBind();
        //}
    }
}

