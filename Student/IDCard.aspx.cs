using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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

                DataSet ds = STD_StudentManager.GetSTD_StudentByIDs(IDs);

                string htmlText = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["Mobile"].ToString().Contains("+88-"))
                    {
                        dr["Mobile"] = dr["Mobile"].ToString().Replace("+88-", "");
                    }

                    if (dr["Mobile"].ToString().Contains(","))
                    {
                        dr["Mobile"] = dr["Mobile"].ToString().Split(',')[0].Trim();
                    }

                    if (dr["PPSizePhoto"].ToString().Contains("~"))
                    {
                        dr["PPSizePhoto"] = ".." + dr["PPSizePhoto"].ToString().Substring(1,dr["PPSizePhoto"].ToString().Length-1);
                    }



                    htmlText += "<div style=\"page-break-after:always; background-image: url('images/ID/Student-Front-Page.png');border:0px solid white; font-family: verdana; height: 205px; width: 325px;\">";
         htmlText += @"<table border='0' cellpadding='0' cellspacing='0'>
<tr>
<td colspan='2'>
<div style='margin-top:31px;'>
<table width='100%'>

<tr>
<td align='left' style='font-size:8px;padding-left:55px;font-style:italic;'>Established 2001</td>
    <td align='right' style='font-size:8px;padding-right:16px;font-style:italic;'>... we change your life</td>
</tr>
</table>
</div>
</td>
    
</tr>
            <tr>
                <td>
                    <div style='border: 1px solid white; width: 100px; margin-top: 3px; height: 75px; margin-left: 18px;text-align: center;'>
                        <img  src='" + (dr["PPSizePhoto"].ToString() == "" ? "images/ID/NoImage.jpg" : dr["PPSizePhoto"]) + @"' style='width:84px;height:101px;'/>
    
    <br/><span style='font-size:15px;font-weight: bold;'>" + dr["StudentCode"].ToString() + @"</span>                    
</div>
                </td>
           <td>
           <table  border='0' cellpadding='0' cellspacing='0' style='margin-top: 4px;'> 
            <tr>
            <td valign='top'>
    <div style='border: 0 solid white;font-weight:bold;font-size: 10px;line-height: 13.5px;margin-left: 3px;margin-top: -5px;width: 76px;'>
                    Name
 </div>
            </td>
            <td valign='top'>
 <div style='border: 0 solid white; font-size: 10px;line-height: 13.5px;margin-left: 1px;margin-top: -5px;width: 2px;font-weight:bold;'>
                    :
 </div>
            </td>
            <td valign='top'>
<div style='border: 0 solid white;font-size: 10.5px;line-height: 13.5px;margin-left: 4px;margin-top: -4px;width: 123px;'>
                    " + dr["StudentName"].ToString() + @"</div>
            </td>
            </tr>
            <td>   
            <div style='border: 0 solid white;font-weight:bold;font-size: 10px;height: 56px;line-height: 13.5px;margin-left: 3px;width: 76px;'>
                    Course Name
                    <br />
                    
                    Date Of Birth
                    <br />
                    Issue Date
                    <br />
                    Valid Date
                    <br />
                    Contact
                    <br />
                    Sex
                    <br />
                    Blood Group
                    
                    
                    </div>
                </td>
                <td>
                    <div style='border: 0 solid white; font-size: 10px;height: 56px;line-height: 13.5px;margin-left: 1px;width: 2px;font-weight:bold;'>
                    :
                    
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    </div>
                </td>
                <td>
                    <div style='border: 0 solid white;font-size: 10.5px;height: 56px;line-height: 13.5px;margin-left: 4px;width: 123px;'>
                    " + dr["Course"].ToString() + @"
                    <br />
                    " + DateTime.Parse(dr["DateofBirth"].ToString()).ToString("dd MMM, yyyy") + @"
                    <br />
                    " + DateTime.Parse(Request.QueryString["IssueDate"] == null ? DateTime.Today.ToString() : Request.QueryString["IssueDate"]).ToString("dd MMM, yyyy") + @"
                    <br />
                    " + DateTime.Parse(Request.QueryString["ValidDate"] == null ? DateTime.Today.AddMonths(12).ToString() : Request.QueryString["ValidDate"]).ToString("dd MMM, yyyy") + @"
                    <br />
                    " + dr["Mobile"].ToString() + @"
                    <br />
                    " + (dr["Gender"].ToString() == "M" ? "Male" : (dr["Gender"].ToString() == "F" ? "Female" : dr["Gender"].ToString())) + @"
                    <br />
                    " + dr["BloodGroup"].ToString() + @"
                    
                    </div>
                </td>
            </tr></table>
            </tr>
         </table> 
    </div>";
                }
                lblIDCards.Text = htmlText;
            }

        }
        catch (Exception ex)
        {
        }
    }
}