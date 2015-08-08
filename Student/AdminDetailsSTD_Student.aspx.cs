using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Student_AdminDetailsSTD_Student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ID"] != null)
            {
                string studentID = Request.QueryString["ID"];

                STD_Student student = STD_StudentManager.GetSTD_StudentByStudentID(studentID);
                a_IDCard.HRef = "IDCard.aspx?IDs=" + student.StudentCode;
                lblStudentName.Text = student.StudentName != "" ? student.StudentName : "Not Provided";
                lblStudentCode.Text = student.StudentCode;
                lblBloodGroup.Text = student.BloodGroup != "" ? student.BloodGroup : "Not Provided";
                lblDateofBirth.Text = student.DateofBirth.ToString("dd MMM,yyyy");
                lblBatch.Text = student.BatchNo.ToString();
                lblEmail.Text = student.Email;
                lblEnglishQualification.Text = student.EnglishQualification != "" ? student.EnglishQualification : "Not Provided";
                lblGender.Text = student.Gender;
                lblIELTS.Text = student.IELTS.ToString();
                lblMaritualStatusID.Text = student.MeritalStatus.ToString();
                lblPermanentAddress.Text = student.PermanentAddress != "" ? student.PermanentAddress : "Not Provided";
                lblPresentAddress.Text = student.PresentAddress != "" ? student.PresentAddress : "Not Provided";
                imgPhoto.ImageUrl = student.PPSizePhoto != "" ? student.PPSizePhoto : "~/Uploads/StudentImages/NoImage.jpg";
                lblTOFEL.Text = student.TOFEL != 0 ? student.TOFEL.ToString() : "0";
                lblTelephone.Text = student.Telephone != "" ? student.Telephone : "Not Provided";
                lblMobile.Text = student.Mobile != "" ? student.Mobile : "Not Provided";
                lblPassportNo.Text = student.PassportNo != "" ? student.PassportNo : "Not Provided";
                lblGender.Text = student.Gender != "" ? student.Gender : "Not Provided";
                lblReligionID.Text = student.ReligionName.ToString();
               
                lblSpouseQualification.Text = student.SpouseQualification != "" ? student.SpouseQualification : "Not Provided";
                if (student.RegistrationDate.ToShortDateString() != "1/1/1753")
                {
                    lblRegistrationDate.Text = student.RegistrationDate.ToString("dd MMM,yyyy");
                }
                else
                {
                    lblRegistrationDate.Text = "N/A";
                }
                lblRegistrationNo.Text = student.RegistrationNo != "" ? student.RegistrationNo : "Not Provided";
                //a_FeesDetails.HRef += student.StudentCode;
                _loadEducationInfo(studentID);

                _loadJobExpereince(studentID);

                _loadContactInfo(studentID);
            }
        }

        catch (Exception ex)
        {
        }
    }

    private void _loadEducationInfo(string studentID)
    {
        try
        {

            List<COMN_EducatinalBackground> educations = COMN_EducatinalBackgroundManager.GetCOMN_EducatinalBackgroundsByUserID(studentID);
            gvCOMN_EducatinalBackground.DataSource = educations;
            gvCOMN_EducatinalBackground.DataBind();
        }

        catch (Exception ex)
        {
        }

    }

    private void _loadJobExpereince(string studentID)
    {
        try
        {

            List<COMN_JobExperience> jobs = COMN_JobExperienceManager.GetCOMN_JobExperiencesByUserID(studentID);

            gvCOMN_JobExperience.DataSource = jobs;
            gvCOMN_JobExperience.DataBind();
        }

        catch (Exception ex)
        {
        }
    }

    private void _loadContactInfo(string studentID)
    {
        try
        {

            List<STD_Contact> contacts = STD_ContactManager.GetSTD_ContactsByStudentID(studentID);
            gvSTD_Contact.DataSource = contacts;
            gvSTD_Contact.DataBind();
        }

        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            Response.Redirect("StudentRegistration.aspx?studentID=" + Request.QueryString["ID"]);
        }
    }
}