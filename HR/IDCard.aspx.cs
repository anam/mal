using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class HR_IDCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string IDs = Request.QueryString["IDs"];

            if (IDs != "")
            {
                IDs = "'" + IDs;
                if (IDs.Contains(','))
                {
                    IDs = IDs.Replace(",", "','");
                }

                if (IDs.Substring(IDs.Length - 1, 1) != "'")
                {
                    IDs += "'";
                }
                else
                {
                    IDs = IDs.Substring(0, IDs.Length - 2);
                }

                DataSet ds = HR_EmployeeManager.GetAllHR_EmployeesByIDs(IDs);

                string htmlText = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["Contact"].ToString().Contains("+88-"))
                    {
                        dr["Contact"] = dr["Contact"].ToString().Replace("+88-", "");
                    }

                    if (dr["Contact"].ToString().Contains(","))
                    {  
                        dr["Contact"] = dr["Contact"].ToString().Split(',')[0].Trim();
                    }

                    if (dr["DesignationName"].ToString().Contains("- "))
                    {
                        dr["DesignationName"] = dr["DesignationName"].ToString().Replace("- ","<br/>");
                    }
                    string imageLocation =Server.MapPath("upload/employeer/" + dr["Photo"].ToString());
                    //System.Drawing.Image img = new Bitmap(imageLocation);
                    System.Drawing.Image img = System.Drawing.Image.FromFile(imageLocation);

                    htmlText += "<div style=\"page-break-after:always;background-image: url('images/ID/Admin-front-Page.png');border:1px solid #C4DCEB; font-family: verdana; width: 205px; height: 325px;\">";
                    htmlText += @"<table border='0' cellpadding='0' cellspacing='0'>
                    <tr>
                    <td colspan='3'>
                    <div style='margin-top:55px;'>
                    <table width='100%'>

                    <tr>
                    <td align='left' style='font-size:7px;padding-left:13px;font-style:italic;'>Established 2001</td>
                        <td align='right' style='font-size:7px;padding-right:16px;font-style:italic;'>... we change your life</td>
                    </tr>
                    </table>
                    </div>
                    </td>
    
                    </tr>
            <tr>
                <td colspan='3'>
                    ";
                    if (img.Width == 200)
                    {

                        htmlText += @"<div style='border:1px solid #C4DCEB;margin-top:4px;margin-left:32px;width:129px;height:97px;'>
                        <img alt='no Image' src='" + (dr["Photo"].ToString() == "" ? "images/ID/NoImage.jpg" : "upload/employeer/" + dr["Photo"]) + @"' style='width:129px;height:97px;'/>
                    </div>";
                    }
                    else
                    {
                        htmlText += @"<div style='border:1px solid #C4DCEB;margin-top:4px;margin-left:62px;width:77px;height:95px;'>
                        <img alt='no Image' src='" + (dr["Photo"].ToString() == "" ? "images/ID/NoImage.jpg" : "upload/employeer/" + dr["Photo"]) + @"' style='width:77px;height:95px;'/>
                    </div>";
                    }
                htmlText +=@"</td>
            </tr>
            <tr>
                <td colspan='3'>
                    <div align='center' style='padding-bottom:-2px;'>
                         <span style='font-size:12px;'> " + dr["EmployeeNo"] + @"</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan='3'>
                    <div align='center'>
                        <span style='font-size: " + (dr["EmployeeName"].ToString().Length >20?"12":"15") + @"px; '>" + dr["EmployeeName"].ToString() + @"</span>
                         <br />   
                         <span style='font-size:" + (dr["DesignationName"].ToString().Length > 25 ? "11" : "11") + @"px;'> " + dr["DesignationName"].ToString() + @"</span>
                         <br />   
                         <!--<span style='font-size:11px;'> " + dr["DepartmentName"].ToString() + @"</span>-->
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style='border: 0px solid Red; height: 56px; margin-top: 7px; margin-left: 17px; font-weight: bold; font-size: 10px; width: 72px;'>
                    Department
                    <br />" + (dr["DepartmentName"].ToString().Length > 15 ? "<br/>" : "") + @"
                    Join Date
                    <br />
                    Contact No
                    <br />
                    Blood Group
                    </div>
                </td>
                <td>
                    <div style='border: 0px solid Red; font-size: 10.5px; height: 56px; margin-top: 7px; width: 5px; font-weight: bold; margin-left: 0px;'>
                    :
                    <br />" + (dr["DepartmentName"].ToString().Length > 15 ? "<br/>" : "") + @"
                    :
                    <br />
                    :
                    <br />
                    :
                    </div>
                </td>
                <td>
                    <div style='border: 0px solid Red; font-size: 10.5px; height: 56px; margin-top: 7px; width: 109px; margin-left: 1px;'>
                    " + dr["DepartmentName"].ToString() + @"
                    <br />
                    " + DateTime.Parse(dr["JoiningDate"].ToString()).ToString("dd MMM, yyyy") + @"
                    <br />
                    " + dr["Contact"].ToString() + @"
                    <br />
                     " + dr["BloodGroupName"].ToString() + @"
                    </div>
                </td>
            </tr>
            <tr>
                <td  colspan='3' style='padding-top:14px; display:none;'>
<br/>
                    <span style='border-top: 1px solid Black; font-size: 7px; margin-top: 31px; margin-left: 129px;'>Authorized Signature</span>
                
                </td>
            </tr>
         </table> 
    </div>";
                }
                lblIDCards.Text = htmlText;
            }

        }
        catch (Exception ex)
        {
            lblIDCards.Text = ex.ToString()+"exception";
        }
    }
}