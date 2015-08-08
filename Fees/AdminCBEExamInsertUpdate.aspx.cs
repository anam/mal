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

public partial class AdminCBEExamInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["examSubjects"] = null;

            if (Request.QueryString["cBEExamID"] != null)
            {
                int cBEExamID = Int32.Parse(Request.QueryString["cBEExamID"]);
                if (cBEExamID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCBEExamData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_CBEExam cBEExam = new STD_CBEExam();

            cBEExam.CandidateName = txtCandidateName.Text;
            cBEExam.DOB =txtDOB.Text!=""? Convert.ToDateTime(txtDOB.Text):DateTime.Parse("1/1/1753");
            cBEExam.Gender = ddlGender.SelectedItem.Text ;
            cBEExam.RegiNo = txtRegiNo.Text;
            cBEExam.InstituteName = txtInstituteName.Text;
            cBEExam.Tel = txtTel.Text;
            cBEExam.Mobile = txtMobile.Text;
            cBEExam.Email = txtEmail.Text;
            cBEExam.FeesDescription = txtFeesDescription.Text;
            cBEExam.AddedBy = Profile.card_id;
            cBEExam.AddedDate = DateTime.Now;
            cBEExam.UpdatedBy = Profile.card_id;
            cBEExam.UpdatedDate = DateTime.Now;
            cBEExam.RowStatusID = 1;
            int resutl = STD_CBEExamManager.InsertCBEExam(cBEExam);
            if (resutl != null)
            {
                List<STD_CBEExamSubject> examSubjects = new List<STD_CBEExamSubject>();
                examSubjects = (List<STD_CBEExamSubject>)Session["examSubjects"];

                foreach (STD_CBEExamSubject es in examSubjects)
                {
                    STD_CBEExamSubject examSubject = new STD_CBEExamSubject();
                    examSubject.SubjectTitle = es.SubjectTitle;
                    examSubject.SubjectCode = es.SubjectCode;
                    examSubject.TaxOrPaperVariant = es.TaxOrPaperVariant;
                    examSubject.ExamDate = es.ExamDate;
                    examSubject.Fees = es.Fees;
                    examSubject.AddedBy = Profile.card_id;
                    examSubject.AddedDate = DateTime.Now;
                    examSubject.UpdatedBy = Profile.card_id;
                    examSubject.UpdatedDate = DateTime.Now;
                    examSubject.RowStatusID = 1;
                    examSubject.CBEExamID = resutl;

                    string sql = @"
INSERT INTO [STD_CBEExamAcc]
           ([Head]
           ,[AccountFor]
           ,[Amount]
           ,[AddedDate]
           ,[AddedBy]
           ,[IsOpiningOrClosingAcc])
     VALUES
           ('Exam Fees','" + txtCandidateName.Text + (txtStudentCode.Text.Trim() == "" ? "" : "(" + txtStudentCode.Text + ")") + @"'
,"+es.Fees+",GETDATE(),'"+Profile.FirstName+@"',0);
";
                    CommonManager.SQLExec(sql);
                    int re = STD_CBEExamSubjectManager.InsertCBEExamSubject(examSubject);
                }
            }

            Session.Remove("examSubjects");
            Response.Redirect("MoneyReceipt.aspx?examID="+resutl);
        }

        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_CBEExam cBEExam = new STD_CBEExam();
            cBEExam = STD_CBEExamManager.GetCBEExamByID(Int32.Parse(Request.QueryString["cBEExamID"]));
            STD_CBEExam tempCBEExam = new STD_CBEExam();
            tempCBEExam.CBEExamID = cBEExam.CBEExamID;

            tempCBEExam.DOB =txtDOB.Text!=""? Convert.ToDateTime(txtDOB.Text):DateTime.Parse("1/1/1753");
            tempCBEExam.Gender = ddlGender.SelectedItem.Text;
            tempCBEExam.RegiNo = txtRegiNo.Text;
            tempCBEExam.InstituteName = txtInstituteName.Text;
            tempCBEExam.Tel = txtTel.Text;
            tempCBEExam.Mobile = txtMobile.Text;
            tempCBEExam.Email = txtEmail.Text;
            tempCBEExam.FeesDescription = txtFeesDescription.Text;
            tempCBEExam.AddedBy = Profile.card_id;
            tempCBEExam.AddedDate = DateTime.Now;
            tempCBEExam.UpdatedBy = Profile.card_id;
            tempCBEExam.UpdatedDate = DateTime.Now;
            tempCBEExam.RowStatusID = 1;
            bool result = STD_CBEExamManager.UpdateCBEExam(tempCBEExam);
            Response.Redirect("AdminCBEExamDisplay.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtDOB.Text = "";
        ddlGender.SelectedIndex = 0;
        txtRegiNo.Text = "";
        txtInstituteName.Text = "";
        txtTel.Text = "";
        txtMobile.Text = "";
        txtEmail.Text = "";
        txtFeesDescription.Text = "";
        txtStudentCode.Text = "";
        txtSubjectCode.Text = "";
        txtSubjectTitle.Text = "";
        txtExamDate.Text = "";
        txtFees.Text = "";
        txtCandidateName.Text = "";
        gvCBEExamSubject.DataSource = string.Empty.ToList();
        gvCBEExamSubject.DataBind();
        
    }
    private void showCBEExamData()
    {
        STD_CBEExam cBEExam = new STD_CBEExam();
        cBEExam = STD_CBEExamManager.GetCBEExamByID(Int32.Parse(Request.QueryString["cBEExamID"]));

        txtCandidateName.Text = cBEExam.CandidateName;
        txtDOB.Text = cBEExam.DOB.ToShortDateString();
        ddlGender.SelectedItem.Text = cBEExam.Gender;
        txtRegiNo.Text = cBEExam.RegiNo;
        txtInstituteName.Text = cBEExam.InstituteName;
        txtTel.Text = cBEExam.Tel;
        txtMobile.Text = cBEExam.Mobile;
        txtEmail.Text = cBEExam.Email;
        txtFeesDescription.Text = cBEExam.FeesDescription;
       
    }

    protected void btnAddSubjectDetaisl_OnClick(object sender, EventArgs e)
    {
        
        if (Session["examSubjects"] == null)
        {
            
            List<STD_CBEExamSubject> examSubjects = new List<STD_CBEExamSubject>();
            STD_CBEExamSubject examSubject = new STD_CBEExamSubject();

            examSubject.SubjectTitle = txtSubjectTitle.Text;
            examSubject.SubjectCode = txtSubjectCode.Text;
            examSubject.TaxOrPaperVariant = ddlTPV.SelectedItem.Text;
            examSubject.ExamDate = txtExamDate.Text != "" ? DateTime.Parse(txtExamDate.Text) : DateTime.Parse("1/1/1753");
            examSubject.AddedBy = Profile.card_id;
            examSubject.AddedDate = DateTime.Now;
            examSubject.UpdatedBy = Profile.card_id;
            examSubject.UpdatedDate = DateTime.Now;
            examSubject.Fees = txtFees.Text!=""?Convert.ToDecimal(txtFees.Text):0;
            examSubject.CBEExamSubjectID = examSubjects.Count;
            examSubjects.Add(examSubject);
            Session["examSubjects"] = examSubjects;
            gvCBEExamSubject.DataSource = Session["examSubjects"];
            gvCBEExamSubject.DataBind();
           
        }
        else
        {
            STD_CBEExamSubject examSubject = new STD_CBEExamSubject();
            examSubject.SubjectTitle = txtSubjectTitle.Text;
            examSubject.SubjectCode = txtSubjectCode.Text;
            examSubject.TaxOrPaperVariant = ddlTPV.SelectedItem.Text;
            examSubject.ExamDate = txtExamDate.Text != "" ? DateTime.Parse(txtExamDate.Text) : DateTime.Parse("1/1/1753");
            examSubject.Fees = txtFees.Text != "" ? Convert.ToDecimal(txtFees.Text) : 0;
            examSubject.AddedBy = Profile.card_id;
            examSubject.AddedDate = DateTime.Now;
            examSubject.UpdatedBy = Profile.card_id;
            examSubject.UpdatedDate = DateTime.Now;

            examSubject.CBEExamSubjectID = ((List<STD_CBEExamSubject>)Session["examSubjects"]).Count;

            ((List<STD_CBEExamSubject>)Session["examSubjects"]).Add(examSubject);

            gvCBEExamSubject.DataSource = Session["examSubjects"];
            gvCBEExamSubject.DataBind();
        }
    }

    protected void lbDeleteExamSubject_Click(object sender, EventArgs e)
    {
        try
        {
            List<STD_CBEExamSubject> examSubjects = new List<STD_CBEExamSubject>();
            examSubjects = (List<STD_CBEExamSubject>)Session["examSubjects"];

            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            examSubjects.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
            for (int i = 0; i < examSubjects.Count; i++)
            {
                examSubjects[i].CBEExamSubjectID = i;
            }
            Session["examSubjects"] = examSubjects;
            gvCBEExamSubject.DataSource = Session["examSubjects"];
            gvCBEExamSubject.DataBind();
        }
        catch (Exception ex)
        { }
    }
    protected void rbList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbList.SelectedIndex == 0)
            pnReg.Visible = true;
        else
            pnReg.Visible = false;
    }
    protected void gvCBEExamSubject_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblExamDate = (Label)e.Row.FindControl("lblExamDate");
            if (lblExamDate.Text.Trim() == "01 Jan,1753")
            {
                lblExamDate.Text = "N/A";
            }
        }
    }
    protected void rdListCuc_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdListCuc.SelectedIndex != 0)

            pnCucStudent.Visible = false;
        else
            pnCucStudent.Visible = true;
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Session["examSubjects"] = null;

        STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);
        txtCandidateName.Text = student.StudentName;
        txtDOB.Text = student.DateofBirth.ToString("dd MMM, yyyy");
        txtEmail.Text = student.Email;
        txtMobile.Text = student.Mobile;
        if (student.RegistrationNo != "" || student.RegistrationNo != null)
        {
            rbList.SelectedIndex = 0;
            txtRegiNo.Text = student.RegistrationNo;
        }
        txtInstituteName.Text = "Chartered University College";
        Session["studentCode"] = txtStudentCode.Text;
    }
}
