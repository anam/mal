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
 

public partial class AdminDisplayHR_JobPosting : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtIssueDate.Text = DateTime.Today.ToString("dd MMM yyyy");
            txtTo.Text = @"Mr. Salman Haque
172, Kalabagan 2nd lane, “Priyo Kanon”, Flat# A2, 
Dhanmondi, Dhaka
Mobile# +88-01823132134";

            txtSubject.Text = "Letter of Appointment.";
            txtDearTo.Text = "Mr. ";
            txtDepartment.Text = "Lecturer in Faculty of CAT & ACCA";
            txtJoiningDate.Text=DateTime.Today.ToString("dd MMM yyyy");
            txtSalary.Text = "Tk.20,000 (Twenty Thousand only)";
            txtOfficeTime.Text = "8:00 AM to 4:30 PM. ";
            txtThanks.Text = @"Best regards,



Dr. Anisur Rahman Khan
Founder Chairman";

            txtP0_1.Text = "Thank you for applying as ";
            txtP0_2.Text = "in our organization. You have been selected for this post by our management.";
            txtP1_1.Text = " We are very happy to you for joining with us on ";
            txtP1_2.Text = "for one year provisional period with Package Gross salary";
            txtP1_3.Text = " per month. After successfully completing one year provisional period you would be permanent for this post. Your salary will be revised on that time.";
            txtP2_1.Text = "Your office time will be ";
            txtP2_2.Text = "Time will be depended and changed as per organizations regulations. The employee will abide by the general rules and regulations of the organization which may be changed by the organization time to time.";
            txtP3.Text = "The employee shall not make any financial commitment on behalf of the organization and/are engages in any dealing, which may involve the organization financially unless specifically authorized by the organization.";
            txtP4.Text = "Chartered University College reserves the right to terminate employee any time during provisional period. If employee wants to leave the job, he has to inform Chartered University College before one (1) month but he cannot leave the job within Twelve (12) months. Chartered University College also inform before one month if termination is made.";
            txtP5.Text ="The employee accepts the employment under the conditions mentioned above and other terms and conditions written in the personnel policy of the organization.";
            txtP6.Text = "I hope that you will be joined in proper time.";

            if (Request.QueryString["EmployeeNo"] != null)
            {
                try
                {
                    DataSet dsEmployeeInfo = HR_EmployeeManager.GetHR_EmployeeInfoByEmployeeNo(Request.QueryString["EmployeeNo"]);

                    txtTo.Text =(dsEmployeeInfo.Tables[0].Rows[0]["GenderID"].ToString()=="F"?"Ms. ": "Mr. " )+ dsEmployeeInfo.Tables[0].Rows[0]["EmployeeName"].ToString() + "\n" + dsEmployeeInfo.Tables[0].Rows[0]["Address"].ToString() + "\nMobile # " + dsEmployeeInfo.Tables[0].Rows[0]["Mobile"].ToString();
                    txtDearTo.Text = (dsEmployeeInfo.Tables[0].Rows[0]["GenderID"].ToString() == "F" ? "Ms. " : "Mr. ") + dsEmployeeInfo.Tables[0].Rows[0]["EmployeeName"].ToString();
                    txtDepartment.Text = dsEmployeeInfo.Tables[0].Rows[0]["DesignationName"] + " of " + dsEmployeeInfo.Tables[0].Rows[0]["DepartmentName"];

                    if (txtDepartment.Text.Substring(0, 1).ToLower() == "a"
                        || txtDepartment.Text.Substring(0, 1).ToLower() == "e"
                        || txtDepartment.Text.Substring(0, 1).ToLower() == "i"
                        || txtDepartment.Text.Substring(0, 1).ToLower() == "o"
                        || txtDepartment.Text.Substring(0, 1).ToLower() == "u"
                        )
                    {
                        txtP0_1.Text += "an ";
                    }
                    else
                    {
                        txtP0_1.Text += "a ";
                    }

                    txtJoiningDate.Text = DateTime.Parse(dsEmployeeInfo.Tables[0].Rows[0]["JoiningDate"].ToString()).ToString("dd MMM, yyyy");

                    if (dsEmployeeInfo.Tables[1].Rows.Count != 0)
                    {
                        dsEmployeeInfo.Tables[0].Rows[0]["GrossAmount"] = double.Parse(dsEmployeeInfo.Tables[0].Rows[0]["GrossAmount"].ToString()) - double.Parse(dsEmployeeInfo.Tables[1].Rows[0]["Amount"].ToString());
                    }
                    
                    if (double.Parse(dsEmployeeInfo.Tables[0].Rows[0]["GrossAmount"].ToString()) != 0.0)
                    {
                        txtSalary.Text = " Tk." + double.Parse(dsEmployeeInfo.Tables[0].Rows[0]["GrossAmount"].ToString()).ToString("0") + " (" + NumberToWords(Convert.ToInt32(double.Parse(dsEmployeeInfo.Tables[0].Rows[0]["GrossAmount"].ToString()).ToString("0"))) + " Only) ";
                    }

                    if (dsEmployeeInfo.Tables[0].Rows[0]["GenderID"].ToString() == "F")
                    {
                        txtP4.Text = "Chartered University College reserves the right to terminate employee any time during provisional period. If employee wants to leave the job, she has to inform Chartered University College before one (1) month but she cannot leave the job within Twelve (12) months. Chartered University College also inform before one month if termination is made.";
                    }
                }
                catch (Exception ex)
                { }
            }
        }
  	}

    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String printedString=@"<p class='MsoNormal'  style='text-align:right;'>
        <b><br /><br /><br /><br /><br /><span>";
           printedString+= "Issue Date- " + txtIssueDate.Text;
           printedString+=@" <o:p></o:p></span></b></p>
    <p class='MsoNormal'>
        <span><o:p>&nbsp;</o:p></span></p>
    <p class='MsoNormal'>
        <b><span>";
            printedString+= "<b>To,</b><br/>"+txtTo.Text.Replace("\n","<br/>")+"<br />Subject: "+ txtSubject.Text;

        
       printedString+=@"<o:p></o:p></span></b></p>
    <p class='MsoNormal'>
        <b><span><o:p>&nbsp;</o:p></span></b></p>
    <p class='MsoNormal'>
        <b><span>";
          printedString+=  "Dear "+ txtDearTo.Text+@",<o:p></o:p></span></b></p>
    <p class='MsoNormal'>";
        printedString+= txtP0_1.Text+"<b>"+txtDepartment.Text+" </b>"+txtP0_2.Text+" </p>";
   
     printedString+=@"<p class='MsoNormal'>"+txtP1_1.Text+ txtJoiningDate.Text+"&nbsp;</b>"+txtP1_2.Text+"<b>"+ txtSalary.Text+"</b><span> </span>"+txtP1_3.Text+"<span><o:p></o:p></span></p><p class='MsoNormal'>";
      printedString+=txtP2_1.Text+" <b>"+txtOfficeTime.Text+"</b>"+txtP2_2.Text+@"</p>
   
    <p class='MsoNormal'>
        "+txtP3.Text+@"</p>
    
    <p class='MsoNormal'>
        "+txtP4.Text+@"<b> </b><span>&nbsp;</span></p>
    
    <p class='MsoNormal'>
        "+txtP5.Text+@"</p>
    
    <p class='MsoNormal'>
        "+txtP6.Text+@"</p>
   
    <p class='MsoNormal'>
        <b>
            "+txtThanks.Text.Replace("\n", "<br/>")+"</b></p>";

        //lblIssueDate.Text = "Issue Date- " + txtIssueDate.Text;
        //lblTo.Text = "<b>To,</b><br/>"+txtTo.Text.Replace("\n","<br/>");
        //lblSubject.Text = "<br />Subject: "+ txtSubject.Text;
        //lblDearTo.Text ="Dear "+ txtDearTo.Text;
        //lblDepartment.Text = txtDepartment.Text;
        //lblJoiningDate.Text = txtJoiningDate.Text;
        //lblSalary.Text = txtSalary.Text;
        //lblOfficeTime.Text = txtOfficeTime.Text;
        //lblThanks.Text = txtThanks.Text.Replace("\n", "<br/>");

        lnkPrint.Visible = true;
        appointmentLetter.Visible = true;

        //Fixed Text
        //lblP0_1.Text = txtP0_1.Text;
        //lblP0_2.Text = txtP0_2.Text;
        
        //lblP1_1.Text = txtP1_1.Text;
        //lblP1_2.Text = txtP1_2.Text;
        //lblP1_3.Text = txtP1_3.Text;

        //lblP2_1.Text = txtP2_1.Text;
        //lblP2_2.Text = txtP2_2.Text;

        //lblP3.Text = txtP3.Text;
        //lblP4.Text = txtP4.Text;
        //lblP5.Text = txtP5.Text;

        lblPrintedLetter.Text = printedString;

        if (chkSaveIndb.Checked)
        {
            COMN_File file = new COMN_File();

            file.FileContent = printedString;
            file.RowStatusID = 1;
            file.AddedDate = DateTime.Now;
            try
            {
                file.AddedBy = HR_EmployeeManager.GetHR_EmployeeInfoByEmployeeNo(Request.QueryString["EmployeeNo"]).Tables[0].Rows[0]["EmployeeID"].ToString();
            }
            catch (Exception ex)
            {
                file.AddedBy = Profile.card_id;
            }
            int resutl = COMN_FileManager.InsertFile(file);
        }        
    }
}

