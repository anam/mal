using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_Control_UCEmployeeInfo : System.Web.UI.UserControl
{

    public   DataSet DsEmployeeInfo
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DsEmployeeInfo != null)
        {

            DataTable dtEmployeeInfo = DsEmployeeInfo.Tables[0];

            //  lblEmployeeName.Text = dtEmployeeInfo.Rows[0]["EmployeeName"].ToString();
            if (dtEmployeeInfo.Rows.Count > 0)
            {
                //HR_Employee employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeID(dtEmployeeInfo.Rows[0]["EmployeeID"].ToString());
                HR_Rank rank = HR_RankManager.GetHR_RankByRankID(Convert.ToInt32(dtEmployeeInfo.Rows[0]["EmployeeRank"].ToString()));
                if (rank != null)
                {
                    //lblEmployeeRank.Text = dtEmployeeInfo.Rows[0]["EmployeeRank"].ToString();
                    lblEmployeeRank.Text = rank.RankName;
                }
                
                lblEmployeeID.Text = dtEmployeeInfo.Rows[0]["EmployeeNo"].ToString();
                lblFathersName.Text = dtEmployeeInfo.Rows[0]["FathersName"].ToString();
                lblMothersName.Text = dtEmployeeInfo.Rows[0]["MothersName"].ToString();
                lblSpouseName.Text = dtEmployeeInfo.Rows[0]["SpouseName"].ToString();
                lblDateOfBirth.Text = DateTime.Parse(dtEmployeeInfo.Rows[0]["DateOfBirth"].ToString()).ToString("MMMM dd, yyyy");
                lblPlaceOfBirth.Text = dtEmployeeInfo.Rows[0]["PlaceOfBirth"].ToString();
                //lblPhoto.Text = dtEmployeeInfo.Rows[0]["Photo"].ToString();
                if (dtEmployeeInfo.Rows[0]["Photo"].ToString() == string.Empty)
                {
                    imgEmployee.ImageUrl = String.Format("~/App_Themes/CoffeyGreen/images/NoImage.jpg");
                }
                else
                {
                    imgEmployee.ImageUrl = String.Format("~/HR/upload/employeer/{0}", dtEmployeeInfo.Rows[0]["Photo"].ToString());
                }
                lblGender.Text = dtEmployeeInfo.Rows[0]["GenderID"].ToString() == "F" ? "Female" : "Male";

                lblDepartmentName.Text = dtEmployeeInfo.Rows[0]["DepartmentName"].ToString();
                lblMaritualStatusName.Text = dtEmployeeInfo.Rows[0]["MaritualStatusName"].ToString();
                lblReligionName.Text = dtEmployeeInfo.Rows[0]["ReligionName"].ToString();
                lblBloodGroupName.Text = dtEmployeeInfo.Rows[0]["BloodGroupName"].ToString();
                lblNationalityName.Text = dtEmployeeInfo.Rows[0]["NationalityName"].ToString();
            }
        }
    }
}