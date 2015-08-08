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
 public partial class AdminSTD_Student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_StudentData();
         		MaritualStatusIDLoad();
		ReligionIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_StudentData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Student sTD_Student = new STD_Student();
            //	sTD_Student.StudentID=  ddlStudentID.SelectedValue;
            sTD_Student.StudentName = txtStudentName.Text;
            sTD_Student.PPSizePhoto = txtPPSizePhoto.Text;
            sTD_Student.StudentCode = txtStudentCode.Text;
            sTD_Student.PresentAddress = txtPresentAddress.Text;
            sTD_Student.PermanentAddress = txtPermanentAddress.Text;
            sTD_Student.Telephone = txtTelephone.Text;
            sTD_Student.Mobile = txtMobile.Text;
            sTD_Student.Email = txtEmail.Text;
            sTD_Student.DateofBirth = DateTime.Parse(txtDateofBirth.Text);
            sTD_Student.PassportNo = txtPassportNo.Text;
            sTD_Student.Gender = txtGender.Text;
            sTD_Student.MaritualStatusID = int.Parse(ddlMaritualStatusID.SelectedValue);
            sTD_Student.ReligionID = int.Parse(ddlReligionID.SelectedValue);
            sTD_Student.SpouseQualification = txtSpouseQualification.Text;
            sTD_Student.EnglishQualification = txtEnglishQualification.Text;
            sTD_Student.IsRegisterWithACCA = bool.Parse(radIsRegisterWithACCA.SelectedValue);
            sTD_Student.RegistrationDate = DateTime.Parse(txtRegistrationDate.Text);
            sTD_Student.RegistrationNo = txtRegistrationNo.Text;
            sTD_Student.AddedBy = Profile.card_id;
            sTD_Student.AddedDate = DateTime.Now;
            sTD_Student.ModifiedBy = Profile.card_id;
            sTD_Student.ModifiedDate = DateTime.Now;
            sTD_Student.BloodGroup = txtBloodGroup.Text;
            sTD_Student.IELTS = decimal.Parse(txtIELTS.Text);
            sTD_Student.TOFEL = decimal.Parse(txtTOFEL.Text);
            STD_StudentManager.InsertSTD_Student(sTD_Student);
        }
        catch (Exception ex) { }
        
        Response.Redirect("AdminDisplaySTD_Student.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_Student sTD_Student = new STD_Student ();
	sTD_Student.StudentID=  Request.QueryString["ID"].ToString();
	sTD_Student.StudentName=  txtStudentName.Text;
	sTD_Student.PPSizePhoto=  txtPPSizePhoto.Text;
	sTD_Student.StudentCode=  txtStudentCode.Text;
	sTD_Student.PresentAddress=  txtPresentAddress.Text;
	sTD_Student.PermanentAddress=  txtPermanentAddress.Text;
	sTD_Student.Telephone=  txtTelephone.Text;
	sTD_Student.Mobile=  txtMobile.Text;
	sTD_Student.Email=  txtEmail.Text;
	sTD_Student.DateofBirth=   DateTime.Parse(txtDateofBirth.Text);
	sTD_Student.PassportNo=  txtPassportNo.Text;
	sTD_Student.Gender=  txtGender.Text;
	sTD_Student.MaritualStatusID=  int.Parse(ddlMaritualStatusID.SelectedValue);
	sTD_Student.ReligionID=  int.Parse(ddlReligionID.SelectedValue);
	sTD_Student.SpouseQualification=  txtSpouseQualification.Text;
	sTD_Student.EnglishQualification=  txtEnglishQualification.Text;
	sTD_Student.IsRegisterWithACCA=  bool.Parse( radIsRegisterWithACCA.SelectedValue);
	sTD_Student.RegistrationDate=   DateTime.Parse(txtRegistrationDate.Text);
	sTD_Student.RegistrationNo=  txtRegistrationNo.Text;
	sTD_Student.AddedBy=  Profile.card_id;
	sTD_Student.AddedDate=  DateTime.Now;
	sTD_Student.ModifiedBy=  Profile.card_id;
	sTD_Student.ModifiedDate=  DateTime.Now;
	sTD_Student.BloodGroup=  txtBloodGroup.Text;
	sTD_Student.IELTS=  decimal.Parse(txtIELTS.Text);
	sTD_Student.TOFEL=  decimal.Parse(txtTOFEL.Text);
	bool  resutl =STD_StudentManager.UpdateSTD_Student(sTD_Student);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Student.aspx");
	}
	private void showSTD_StudentData()
	{
	 	STD_Student sTD_Student  = new STD_Student ();
	 	sTD_Student = STD_StudentManager.GetSTD_StudentByStudentID(Request.QueryString["ID"]);
	 	txtStudentName.Text =sTD_Student.StudentName.ToString();
	 	txtPPSizePhoto.Text =sTD_Student.PPSizePhoto.ToString();
	 	txtStudentCode.Text =sTD_Student.StudentCode.ToString();
	 	txtPresentAddress.Text =sTD_Student.PresentAddress.ToString();
	 	txtPermanentAddress.Text =sTD_Student.PermanentAddress.ToString();
	 	txtTelephone.Text =sTD_Student.Telephone.ToString();
	 	txtMobile.Text =sTD_Student.Mobile.ToString();
	 	txtEmail.Text =sTD_Student.Email.ToString();
	 	txtDateofBirth.Text =sTD_Student.DateofBirth.ToString();
	 	txtPassportNo.Text =sTD_Student.PassportNo.ToString();
	 	txtGender.Text =sTD_Student.Gender.ToString();
	 	ddlMaritualStatusID.SelectedValue  =sTD_Student.MaritualStatusID.ToString();
	 	ddlReligionID.SelectedValue  =sTD_Student.ReligionID.ToString();
	 	txtSpouseQualification.Text =sTD_Student.SpouseQualification.ToString();
	 	txtEnglishQualification.Text =sTD_Student.EnglishQualification.ToString();
	 	 radIsRegisterWithACCA.SelectedValue  =sTD_Student.IsRegisterWithACCA.ToString();
	 	txtRegistrationDate.Text =sTD_Student.RegistrationDate.ToString();
	 	txtRegistrationNo.Text =sTD_Student.RegistrationNo.ToString();
	 	txtBloodGroup.Text =sTD_Student.BloodGroup.ToString();
	 	txtIELTS.Text =sTD_Student.IELTS.ToString();
	 	txtTOFEL.Text =sTD_Student.TOFEL.ToString();
	}
	
	private void MaritualStatusIDLoad()
	{
		try {
		DataSet ds = HR_MaritualStatusManager.GetDropDownListAllHR_MaritualStatus();
		ddlMaritualStatusID.DataValueField = "MaritualStatusID";
		ddlMaritualStatusID.DataTextField = "MaritualStatusName";
		ddlMaritualStatusID.DataSource = ds.Tables[0];
		ddlMaritualStatusID.DataBind();
		ddlMaritualStatusID.Items.Insert(0, new ListItem("Select MaritualStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ReligionIDLoad()
	{
		try {
		DataSet ds = HR_ReligionManager.GetDropDownListAllHR_Religion();
		ddlReligionID.DataValueField = "ReligionID";
		ddlReligionID.DataTextField = "ReligionName";
		ddlReligionID.DataSource = ds.Tables[0];
		ddlReligionID.DataBind();
		ddlReligionID.Items.Insert(0, new ListItem("Select Religion >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

