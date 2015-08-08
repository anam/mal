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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
public partial class StudentRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfLoggedInUserID.Value = Profile.UserName;
            //loadSTD_StudentData();
            MaritualStatusIDLoad();
            BatchIDLoad();
            ReligionIDLoad();
            ReaultSystemIDLoad();
            ContactTypeIDLoad();
            loadOthers();
            CourseIDLoad();

            Session["educationalBackground"] = null ;
            Session["jobexperience"] = null;
            Session["contacts"] = null;

            if (Request.QueryString["studentID"] != null)
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                loadOthersUpdate();
                showSTD_StudentData();
            }
        }
    }

    private void CourseIDLoad()
    {
        try
        {
            DataSet ds = STD_ProgramManager.GetDropDownListAllSTD_Program();
            ddlCourseID.DataValueField = "ProgramID";
            ddlCourseID.DataTextField = "ProgramName";
            ddlCourseID.DataSource = ds.Tables[0];
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("Select Program >>", "0"));

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void ContactTypeIDLoad()
    {
        try
        {
            DataSet ds = STD_ContactTypeManager.GetDropDownListAllSTD_ContactType();
            ddlContactTypeID.DataValueField = "ContactTypeID";
            ddlContactTypeID.DataTextField = "ContactTypeName";
            ddlContactTypeID.DataSource = ds.Tables[0];
            ddlContactTypeID.DataBind();
            ddlContactTypeID.Items.Insert(0, new ListItem("Select ContactType >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void ReaultSystemIDLoad()
    {
        try
        {
            DataSet ds = COMN_ReaultSystemManager.GetDropDownListAllCOMN_ReaultSystem();
            ddlReaultSystemID.DataValueField = "ReaultSystemID";
            ddlReaultSystemID.DataTextField = "ReaultSystemName";
            ddlReaultSystemID.DataSource = ds.Tables[0];
            ddlReaultSystemID.DataBind();
            ddlReaultSystemID.Items.Insert(0, new ListItem("Select ResultSystem >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void loadOthers()
    {
        dt_StudentCode.Visible = false;
        dd_StudentCode.Visible = false;

        if (Session["EducationalBackground"] != null)
        {
            gvCOMN_EducatinalBackground.DataSource = Session["EducationalBackground"];
            gvCOMN_EducatinalBackground.DataBind();
        }
    }

    private void loadOthersUpdate()
    {
        dt_StudentCode.Visible = true;
        dd_StudentCode.Visible = true;
    }

    private void MaritualStatusIDLoad()
    {
        try
        {
            DataSet ds = COMN_MaritualStatusManager.GetDropDownListAllCOMN_MaritualStatus();
            ddlMaritualStatusID.DataValueField = "MaritualStatusID";
            ddlMaritualStatusID.DataTextField = "MaritualStatusName";
            ddlMaritualStatusID.DataSource = ds.Tables[0];
            ddlMaritualStatusID.DataBind();
            ddlMaritualStatusID.Items.Insert(0, new ListItem("Select MaritalStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void BatchIDLoad()
    {
        try
        {
            DataSet ds = STD_BatchManager.GetAllSTD_Batchs();
            ddlBatchID.DataValueField = "BatchCode";
            ddlBatchID.DataTextField = "BatchName";
            ddlBatchID.DataSource = ds.Tables[0];
            ddlBatchID.DataBind();
            ddlBatchID.Items.Insert(0, new ListItem("Select Batch >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void ReligionIDLoad()
    {
        try
        {
            DataSet ds = COMN_ReligionManager.GetDropDownListAllCOMN_Religion();
            ddlReligionID.DataValueField = "ReligionID";
            ddlReligionID.DataTextField = "ReligionName";
            ddlReligionID.DataSource = ds.Tables[0];
            ddlReligionID.DataBind();
            ddlReligionID.Items.Insert(0, new ListItem("Select Religion >>", "0"));
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
            string studentCode = "";
            DateTime date = DateTime.Now;
            int year = date.Year;
            string batchNo = "";

            STD_Student student = STD_StudentManager.GetAllSTD_StudentsByBatchNo(ddlBatchID.SelectedValue != "" ? Convert.ToInt32(ddlBatchID.SelectedValue) : 0);
            int sID = 0;
            if (student != null)
            {
                sID = student.MaxID ;
            }
            else
            {
                sID = 1;
            }
            if (ddlBatchID.SelectedValue.Length > 3)
            {
                batchNo = ddlBatchID.SelectedValue.Substring(2, 3);
            }
            studentCode = year.ToString().Substring(2, 2) + batchNo + sID.ToString("000");

            try
            {
                while (Membership.ValidateUser(studentCode, Membership.Provider.GetPassword(studentCode, "a")))
                {
                    sID = sID + 1;
                    studentCode = year.ToString().Substring(2, 2) + batchNo + sID.ToString("000");
                    //break;
                }
            }
            catch (Exception ex)
            {
            }
            lblError.ForeColor = System.Drawing.Color.Red;
            var employeerPhoto = string.Empty;
            var studentID = "";
            string email = "";

            #region Create User

            if (txtEmail.Text != "")
            {
                MembershipCreateStatus result;
                try
                {

                    txtStudentCode.Text = studentCode;//set the studentCode;
                    Membership.CreateUser(studentCode, "123456", txtEmail.Text, "a", "a", true, out result);

                    switch (result)
                    {
                        case MembershipCreateStatus.Success:

                            FormsAuthentication.SetAuthCookie(txtStudentCode.Text.ToString(), true);

                            var role = "STD";

                            MembershipUser myObject = Membership.GetUser(txtStudentCode.Text.Trim());
                            studentID = myObject.ProviderUserKey.ToString();

                            //Assign Role to the Student
                            if(!Roles.IsUserInRole("Student"))
                                Roles.AddUserToRole(myObject.UserName, "Student");

                            lblError.Text = "User successfully created!";
                            lblError.ForeColor = System.Drawing.Color.Green;
                            break;

                        case MembershipCreateStatus.InvalidUserName:
                            lblError.Text = "The username format was invalid. Please enter a different username.";
                            break;
                        case MembershipCreateStatus.InvalidPassword:
                            lblError.Text = "The password was invalid: A password cannot be an empty string and must also meet the pasword strength requirements of the configured provider. Please enter a new password.";
                            break;
                        case MembershipCreateStatus.InvalidEmail:
                            lblError.Text = "The email format was invalid. Please enter a different username.";
                            break;
                        case MembershipCreateStatus.InvalidQuestion:
                            lblError.Text = "The password question format was invalid. Please enter a different question.";
                            break;
                        case MembershipCreateStatus.InvalidAnswer:
                            lblError.Text = "The password answer format was invalid. Please enter a different answer.";
                            break;
                        case MembershipCreateStatus.DuplicateUserName:
                            lblError.Text = "The username is already in use. Please enter a new username.";
                            break;
                        case MembershipCreateStatus.DuplicateEmail:
                            lblError.Text = "The email address is already in use. Please enter a different email address.";
                            break;
                        default:
                            lblError.Text = "An error occurred while creating the user.";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    return;
                }
            }
            else
            {
                MembershipCreateStatus result;
                try
                {

                    txtStudentCode.Text = studentCode;//set the studentCode;
                    email = studentCode.ToString() + "@cuc.com";
                    Membership.CreateUser(studentCode, "123456", email, "a", "a", true, out result);

                    switch (result)
                    {
                        case MembershipCreateStatus.Success:

                            FormsAuthentication.SetAuthCookie(txtStudentCode.Text.ToString(), true);

                            var role = "STD";

                            MembershipUser myObject = Membership.GetUser(txtStudentCode.Text.Trim());

                            studentID = myObject.ProviderUserKey.ToString();

                            if (!Roles.IsUserInRole("Student"))
                                Roles.AddUserToRole(myObject.UserName, "Student");

                            lblError.Text = "User successfully created!";
                            lblError.ForeColor = System.Drawing.Color.Green;
                            break;

                        case MembershipCreateStatus.InvalidUserName:
                            lblError.Text = "The username format was invalid. Please enter a different username.";
                            break;
                        case MembershipCreateStatus.InvalidPassword:
                            lblError.Text = "The password was invalid: A password cannot be an empty string and must also meet the pasword strength requirements of the configured provider. Please enter a new password.";
                            break;
                        case MembershipCreateStatus.InvalidEmail:
                            lblError.Text = "The email format was invalid. Please enter a different username.";
                            break;
                        case MembershipCreateStatus.InvalidQuestion:
                            lblError.Text = "The password question format was invalid. Please enter a different question.";
                            break;
                        case MembershipCreateStatus.InvalidAnswer:
                            lblError.Text = "The password answer format was invalid. Please enter a different answer.";
                            break;
                        case MembershipCreateStatus.DuplicateUserName:
                            lblError.Text = "The username is already in use. Please enter a new username.";
                            break;
                        case MembershipCreateStatus.DuplicateEmail:
                            lblError.Text = "The email address is already in use. Please enter a different email address.";
                            break;
                        default:
                            lblError.Text = "An error occurred while creating the user.";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    return;
                }
            }

            //load The loggedin user
            FormsAuthentication.SetAuthCookie(hfLoggedInUserID.Value, true);
            MembershipUser myObjectLoggedInUser = Membership.GetUser(hfLoggedInUserID.Value);
            #endregion





            #region StudentInfo
            try
            {
                STD_Student sTD_Student = new STD_Student();
                sTD_Student.StudentID = studentID;
                sTD_Student.StudentName = txtStudentName.Text.Trim();
                //sTD_Student.PPSizePhoto=  "Fileurl";
                if (Session["imagePath"] != null)
                {
                    try
                    {
                        string dirUrl = "~/Uploads/StudentImages";
                        string dirPath = Server.MapPath(dirUrl);

                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }

                        string picPath = Session["imagePath"].ToString();
                        Session.Remove("imagePath");
                        string[] st = picPath.ToString().Split('.');
                        string st_pic = st[1];
                        string fileName = sTD_Student.StudentID + "." + st_pic;
                        string fileUrl = dirUrl + "/" + fileName;

                        System.Drawing.Image stImage = System.Drawing.Image.FromFile(picPath);
                        stImage.Save(Server.MapPath(fileUrl));

                        sTD_Student.PPSizePhoto = fileUrl;
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                    }
                }
                else
                {
                    if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
                    {
                        try
                        {
                            string dirUrl = "~/Uploads/StudentImages";
                            string dirPath = Server.MapPath(dirUrl);

                            if (!Directory.Exists(dirPath))
                            {
                                Directory.CreateDirectory(dirPath);
                            }
                            string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                            string fileUrl = dirUrl + "/" + sTD_Student.StudentID + "_" + Path.GetFileName(uplFile.PostedFile.FileName);
                            string filePath = Server.MapPath(fileUrl);
                            uplFile.PostedFile.SaveAs(filePath);

                            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(filePath);
                            System.Drawing.Image resizedImage = resizeImageWithGivenValue(originalImage, 150, 150);
                            resizedImage.Save(dirPath + "/" + "Display_" + sTD_Student.StudentID + fileName, ImageFormat.Jpeg);

                            sTD_Student.PPSizePhoto = dirUrl + "/" + "Display_" + sTD_Student.StudentID + fileName;
                        }
                        catch (Exception ex)
                        {
                            lblError.Text = ex.Message;
                        }
                    }
                    else
                    {
                        sTD_Student.PPSizePhoto = "~/Uploads/StudentImages/NoImage.jpg";
                    }
                }
                sTD_Student.StudentCode = txtStudentCode.Text;
                sTD_Student.PresentAddress = txtPresentAddress.Text;
                sTD_Student.PermanentAddress = txtPermanentAddress.Text;
                sTD_Student.Telephone = txtTelephone.Text;
                sTD_Student.Mobile = txtMobile.Text;
                sTD_Student.Email = txtEmail.Text != "" ? txtEmail.Text : email;
                sTD_Student.DateofBirth = DateTime.Parse(txtDateofBirth.Text);
                sTD_Student.PassportNo = txtPassportNo.Text;
                sTD_Student.Gender = txtGender.Text;
                sTD_Student.MaritualStatusID = ddlMaritualStatusID.SelectedValue != "" ? int.Parse(ddlMaritualStatusID.SelectedValue) : 0;
                sTD_Student.ReligionID = ddlReligionID.SelectedValue != "" ? int.Parse(ddlReligionID.SelectedValue) : 0;
                sTD_Student.SpouseQualification = ddlCourseID.SelectedValue;
                sTD_Student.EnglishQualification = txtEnglishQualification.Text;
                sTD_Student.IsRegisterWithACCA = Convert.ToBoolean(radIsRegisterWithACCA.SelectedValue);
                sTD_Student.RegistrationDate = txtRegistrationDate.Text != "" ? DateTime.Parse(txtRegistrationDate.Text) : DateTime.Parse("1/1/1753");
                sTD_Student.RegistrationNo = txtRegistrationNo.Text;
                sTD_Student.AddedBy = Profile.card_id;
                sTD_Student.AddedDate = DateTime.Now;
                sTD_Student.ModifiedBy = Profile.card_id;
                sTD_Student.ModifiedDate = DateTime.Now;
                sTD_Student.BloodGroup = txtBloodGroup.Text;
                sTD_Student.IELTS = txtIELTS.Text != "" ? decimal.Parse(txtIELTS.Text) : 0;
                sTD_Student.TOFEL = txtTOFEL.Text != "" ? decimal.Parse(txtTOFEL.Text) : 0;
                sTD_Student.ID = sID;
                sTD_Student.BatchNo = ddlBatchID.SelectedValue != "" ? Convert.ToInt32(ddlBatchID.SelectedValue) : 0;
                sTD_Student.Year = year;
                //sTD_Student.StudentID = 
                sTD_Student.RowStatusID = 1;
                DataSet dsStudent = new DataSet();
                dsStudent = STD_StudentManager.InsertSTD_Student(sTD_Student);


                sTD_Student.StudentID = dsStudent.Tables[0].Rows[0]["StudentID"].ToString();
                sTD_Student.StudentCode = dsStudent.Tables[0].Rows[0]["StudentCode"].ToString();

                //add to educational background to the db

                
                if (Session["educationalBackground"] != null)
                {
                    List<COMN_EducatinalBackground> educationalBackground = new List<COMN_EducatinalBackground>();
                    educationalBackground = (List<COMN_EducatinalBackground>)Session["educationalBackground"];

                    foreach (COMN_EducatinalBackground cOMN_EducatinalBackground in educationalBackground)
                    {
                        cOMN_EducatinalBackground.UserID = sTD_Student.StudentID;
                        COMN_EducatinalBackgroundManager.InsertCOMN_EducatinalBackground(cOMN_EducatinalBackground);
                    }

                    educationalBackground.RemoveRange(0, educationalBackground.Count);
                }

                // Add job_experience 
                if (Session["jobexperience"] != null)
                {
                    List<COMN_JobExperience> jobexperience = new List<COMN_JobExperience>();
                    jobexperience = (List<COMN_JobExperience>)Session["jobexperience"];

                    foreach (COMN_JobExperience cOMN_JobExperience in jobexperience)
                    {
                        cOMN_JobExperience.UserID = sTD_Student.StudentID;
                        COMN_JobExperienceManager.InsertCOMN_JobExperience(cOMN_JobExperience);
                    }
                    jobexperience.RemoveRange(0, jobexperience.Count);
                }
                // Add job_experience 
                if (Session["contacts"] != null)
                {
                    List<STD_Contact> contacts = new List<STD_Contact>();
                    contacts = (List<STD_Contact>)Session["contacts"];

                    foreach (STD_Contact sTD_Contact in contacts)
                    {
                        sTD_Contact.StudentID = sTD_Student.StudentID;
                        STD_ContactManager.InsertSTD_Contact(sTD_Contact);
                    }
                    contacts.RemoveRange(0, contacts.Count);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            #endregion


            #region Add semester fee
            if (txtSemesterFee.Text != "" && txtSemesterFee.Text != "0" && ddlCourseID.SelectedIndex != 0)
            {
                STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
                sTD_FeesMaster = insertFeesMaster(29, studentID); //Semester Fee = 29

            }
            #endregion

            Response.Redirect("AdminDetailsSTD_Student.aspx?ID=" + studentID);

        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    private STD_FeesMaster insertFeesMaster(int accountID,string studentID)
    {
        //add in the FeesMaster 
        STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
        //	sTD_FeesMaster.FeesMasterID=  int.Parse(ddlFeesMasterID.SelectedValue);
        DataSet ds = STD_FeesMasterManager.GetSTD_FeesMasterByStudentIDnCourseIDnFeesTypeID(studentID, int.Parse(ddlCourseID.SelectedValue), accountID);
        if (ds.Tables[0].Rows.Count != 0)
        {
            sTD_FeesMaster.FeesMasterID = int.Parse(ds.Tables[0].Rows[0]["FeesMasterID"].ToString());
            sTD_FeesMaster.FeesMasterName = (ds.Tables[0].Rows[0]["FeesMasterName"].ToString());
            sTD_FeesMaster.TotalPayment = decimal.Parse(ds.Tables[0].Rows[0]["TotalPayment"].ToString());
            sTD_FeesMaster.Discount = decimal.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
            sTD_FeesMaster.TotalPaymentNeedtoPay = decimal.Parse(ds.Tables[0].Rows[0]["TotalPaymentNeedtoPay"].ToString());
            sTD_FeesMaster.FeesTypeID = int.Parse(ds.Tables[0].Rows[0]["FeesTypeID"].ToString());
            sTD_FeesMaster.SubmissionDate = DateTime.Parse(ds.Tables[0].Rows[0]["SubmissionDate"].ToString());
            sTD_FeesMaster.SubmitedDate = (ds.Tables[0].Rows[0]["SubmitedDate"].ToString());
            sTD_FeesMaster.StudentID = (ds.Tables[0].Rows[0]["StudentID"].ToString());
            sTD_FeesMaster.CourseID = int.Parse(ds.Tables[0].Rows[0]["CourseID"].ToString());
            sTD_FeesMaster.Remarks = (ds.Tables[0].Rows[0]["Remarks"].ToString());
            sTD_FeesMaster.IsPaid = bool.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
            sTD_FeesMaster.PaymentStatusID = int.Parse(ds.Tables[0].Rows[0]["PaymentStatusID"].ToString());
            sTD_FeesMaster.ExtraField1 = (ds.Tables[0].Rows[0]["ExtraField1"].ToString());
            sTD_FeesMaster.ExtraField2 = (ds.Tables[0].Rows[0]["ExtraField2"].ToString());
            sTD_FeesMaster.ExtraField3 = (ds.Tables[0].Rows[0]["ExtraField3"].ToString());
            sTD_FeesMaster.ExtraField4 = (ds.Tables[0].Rows[0]["ExtraField4"].ToString());
            sTD_FeesMaster.ExtraField5 = (ds.Tables[0].Rows[0]["ExtraField5"].ToString());
            sTD_FeesMaster.AddedBy = (ds.Tables[0].Rows[0]["AddedBy"].ToString());
            sTD_FeesMaster.AddedDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString());
            sTD_FeesMaster.UpdatedBy = (ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
            sTD_FeesMaster.UpdateDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateDate"].ToString());
            sTD_FeesMaster.RowStatusID = int.Parse(ds.Tables[0].Rows[0]["RowStatusID"].ToString());

            //updated data
            //sTD_FeesMaster.FeesMasterName = "";
            //sTD_FeesMaster.TotalPayment += decimal.Parse(txtSemesterFee.Text);
            sTD_FeesMaster.ExtraField5 = txtSemesterFee.Text;
            //sTD_FeesMaster.Discount +=0;
            //sTD_FeesMaster.TotalPaymentNeedtoPay += decimal.Parse(txtSemesterFee.Text);
            //sTD_FeesMaster.IsPaid = false;
            //sTD_FeesMaster.PaymentStatusID = int.Parse("1");
            //sTD_FeesMaster.ExtraField2 = (decimal.Parse(sTD_FeesMaster.ExtraField2) + decimal.Parse(txtSemesterFee.Text)).ToString();
            sTD_FeesMaster.UpdatedBy = Profile.card_id;
            sTD_FeesMaster.UpdateDate = DateTime.Now;
            sTD_FeesMaster.RowStatusID = int.Parse("1");
            STD_FeesMasterManager.UpdateSTD_FeesMaster(sTD_FeesMaster);
        }
        else
        {

            sTD_FeesMaster.FeesMasterName = "";
            sTD_FeesMaster.TotalPayment = decimal.Parse(txtSemesterFee.Text);
            sTD_FeesMaster.Discount = 0;
            sTD_FeesMaster.TotalPaymentNeedtoPay = decimal.Parse(txtSemesterFee.Text);
            sTD_FeesMaster.FeesTypeID = accountID;
            sTD_FeesMaster.SubmissionDate = DateTime.Today;
            sTD_FeesMaster.SubmitedDate = "";
            sTD_FeesMaster.StudentID = studentID;
            sTD_FeesMaster.CourseID = int.Parse(ddlCourseID.SelectedValue);
            sTD_FeesMaster.Remarks = "";
            sTD_FeesMaster.IsPaid = false;
            sTD_FeesMaster.PaymentStatusID = int.Parse("1");
            sTD_FeesMaster.ExtraField1 = "0";
            sTD_FeesMaster.ExtraField2 =txtSemesterFee.Text;
            sTD_FeesMaster.ExtraField3 = "";
            sTD_FeesMaster.ExtraField4 = "";
            sTD_FeesMaster.ExtraField5 = txtSemesterFee.Text;
            sTD_FeesMaster.AddedBy = Profile.card_id;
            sTD_FeesMaster.AddedDate = DateTime.Now;
            sTD_FeesMaster.UpdatedBy = Profile.card_id;
            sTD_FeesMaster.UpdateDate = DateTime.Now;
            sTD_FeesMaster.RowStatusID = int.Parse("1");
            sTD_FeesMaster.FeesMasterID = STD_FeesMasterManager.InsertSTD_FeesMaster(sTD_FeesMaster);




            STD_Fees sTD_Fees = new STD_Fees();
            sTD_Fees.FeesName = sTD_FeesMaster.FeesMasterID.ToString();//it will be fees masterID
            sTD_Fees.Amount = decimal.Parse(txtSemesterFee.Text);
            sTD_Fees.FeesTypeID = 1; //installment
            sTD_Fees.SubmissionDate = DateTime.Today;
            sTD_Fees.SubmitedDate = "";
            sTD_Fees.StudentID = studentID;
            sTD_Fees.CourseID = int.Parse(ddlCourseID.SelectedValue);
            sTD_Fees.AddedBy = Profile.card_id;
            sTD_Fees.AddedDate = DateTime.Now;
            sTD_Fees.UpdatedBy = Profile.card_id;
            sTD_Fees.UpdateDate = DateTime.Now;
            sTD_Fees.RowStatusID = int.Parse("1");
            sTD_Fees.Remarks = "0";
            sTD_Fees.IsPaid = false;
            sTD_Fees.FeesID = STD_FeesManager.InsertSTD_Fees(sTD_Fees);
        }

        return sTD_FeesMaster;
    }

    public Bitmap resizeImageWithGivenValue(System.Drawing.Image originalImage, int givenWidth, int givenHeight)
    {
        int sourceImageWidth = originalImage.Width;
        int sourceImageHeight = originalImage.Height;
        int distinationX = 0;
        int distinationY = 0;
        int sourceX = 0;
        int sourceY = 0;
        int resizedImageWidth = givenWidth;
        int resizedImageHeight = givenHeight;
        Bitmap resizedImage = new Bitmap(resizedImageWidth, resizedImageHeight, PixelFormat.Format24bppRgb);
        resizedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);
        Graphics newResizedImage = Graphics.FromImage(resizedImage);
        newResizedImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
        newResizedImage.DrawImage(
                                    originalImage,
                                    new Rectangle(distinationX, distinationY, resizedImageWidth, resizedImageHeight),
                                    new Rectangle(sourceX, sourceY, sourceImageWidth, sourceImageHeight),
                                    GraphicsUnit.Pixel
                                  );
        newResizedImage.Dispose();

        return resizedImage;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Student sTD_Student = STD_StudentManager.GetSTD_StudentByStudentID(Request.QueryString["studentID"]);
            //STD_Student temp_Stuent = new STD_Student();
            sTD_Student.StudentID = sTD_Student.StudentID;
            sTD_Student.StudentName = txtStudentName.Text;
            if (Session["imagePath"] != null)
            {
                try
                {
                    string dirUrl = "~/Uploads/StudentImages";
                    string dirPath = Server.MapPath(dirUrl);

                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string picPath = Session["imagePath"].ToString();
                    Session.Remove("imagePath");
                    string[] st = picPath.ToString().Split('.');
                    string st_pic = st[1];
                    string fileName = sTD_Student.StudentID + "." + st_pic;
                    string fileUrl = dirUrl + "/" + fileName;

                    System.Drawing.Image stImage = System.Drawing.Image.FromFile(picPath);
                    stImage.Save(Server.MapPath(fileUrl));

                    sTD_Student.PPSizePhoto = fileUrl;
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        string dirUrl = "~/Uploads/StudentImages";
                        string dirPath = Server.MapPath(dirUrl);

                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }
                        string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                        string fileUrl = dirUrl + "/" + sTD_Student.StudentID + "_" + Path.GetFileName(uplFile.PostedFile.FileName);
                        string filePath = Server.MapPath(fileUrl);
                        uplFile.PostedFile.SaveAs(filePath);

                        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(filePath);
                        System.Drawing.Image resizedImage = resizeImageWithGivenValue(originalImage, 150, 150);
                        resizedImage.Save(dirPath + "/" + "Display_" + sTD_Student.StudentID + fileName, ImageFormat.Jpeg);

                        sTD_Student.PPSizePhoto = dirUrl + "/" + "Display_" + sTD_Student.StudentID + fileName;                       
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
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
            sTD_Student.SpouseQualification = ddlCourseID.SelectedValue;
            sTD_Student.EnglishQualification = txtEnglishQualification.Text;
            sTD_Student.IsRegisterWithACCA = radIsRegisterWithACCA.SelectedValue == "" ? false : Convert.ToBoolean(radIsRegisterWithACCA.SelectedValue);
            sTD_Student.RegistrationDate = txtRegistrationDate.Text != "" ? DateTime.Parse(txtRegistrationDate.Text) : DateTime.Parse("1/1/1753");
            sTD_Student.RegistrationNo = txtRegistrationNo.Text;
            sTD_Student.AddedBy = Profile.card_id;
            sTD_Student.AddedDate = DateTime.Now;
            sTD_Student.ModifiedBy = Profile.card_id;
            sTD_Student.ModifiedDate = DateTime.Now;
            sTD_Student.BloodGroup = txtBloodGroup.Text;
            sTD_Student.IELTS = txtIELTS.Text != "" ? decimal.Parse(txtIELTS.Text) : 0;
            sTD_Student.TOFEL = txtTOFEL.Text != "" ? decimal.Parse(txtTOFEL.Text) : 0;
            sTD_Student.BatchNo = Convert.ToInt32(ddlBatchID.SelectedValue);
            bool resutl = STD_StudentManager.UpdateSTD_Student(sTD_Student);

            //add to educational background to the db
            //delete the old educational history
            //COMN_EducatinalBackgroundManager.DeleteCOMN_EducatinalBackgroundByUserID(sTD_Student.StudentID); 
            if (Session["educationalBackground"] != null)
            {
                List<COMN_EducatinalBackground> educationalBackground = new List<COMN_EducatinalBackground>();
                educationalBackground = (List<COMN_EducatinalBackground>)Session["educationalBackground"];

                List<COMN_EducatinalBackground> educations = COMN_EducatinalBackgroundManager.GetCOMN_EducatinalBackgroundsByUserID(sTD_Student.StudentID);
                foreach (COMN_EducatinalBackground education in educations)
                {
                    COMN_EducatinalBackgroundManager.DeleteCOMN_EducatinalBackground(education.EducationalBacgroundID);
                }
                foreach (COMN_EducatinalBackground cOMN_EducatinalBackground in educationalBackground)
                {
                    cOMN_EducatinalBackground.UserID = sTD_Student.StudentID;
                    COMN_EducatinalBackgroundManager.InsertCOMN_EducatinalBackground(cOMN_EducatinalBackground);
                }
                educationalBackground.RemoveRange(0, educationalBackground.Count);
            }

            //delete Job exprience
            //STD_ContactManager.DeleteSTD_ContactByStudentID(sTD_Student.StudentID);

            //delete Job exprience
            //COMN_JobExperienceManager.DeleteCOMN_JobExperienceByUserID(sTD_Student.StudentID);
            if (Session["jobexperience"] != null)
            {
                List<COMN_JobExperience> jobexperience = new List<COMN_JobExperience>();
                jobexperience = (List<COMN_JobExperience>)Session["jobexperience"];

                List<COMN_JobExperience> jobs = COMN_JobExperienceManager.GetCOMN_JobExperiencesByUserID(sTD_Student.StudentID);

                foreach (COMN_JobExperience job in jobs)
                {
                    COMN_JobExperienceManager.DeleteCOMN_JobExperience(job.JobExperienceID);
                }

                foreach (COMN_JobExperience cOMN_JobExperience in jobexperience)
                {
                    cOMN_JobExperience.UserID = sTD_Student.StudentID;
                    COMN_JobExperienceManager.InsertCOMN_JobExperience(cOMN_JobExperience);
                }
                jobexperience.RemoveRange(0, jobexperience.Count);
            }

            //delete Job exprience
            //STD_ContactManager.DeleteSTD_ContactByStudentID(sTD_Student.StudentID);
            // Add job_experience 

            if (Session["contacts"] != null)
            {
                List<STD_Contact> contacts = new List<STD_Contact>();
                contacts = (List<STD_Contact>)Session["contacts"];

                List<STD_Contact> sTD_contacts = STD_ContactManager.GetSTD_ContactsByStudentID(sTD_Student.StudentID);

                foreach (STD_Contact contact in sTD_contacts)
                {
                    STD_ContactManager.DeleteSTD_Contact(contact.ContactID);
                }

                foreach (STD_Contact sTD_Contact in contacts)
                {
                    sTD_Contact.StudentID = sTD_Student.StudentID;
                    STD_ContactManager.InsertSTD_Contact(sTD_Contact);
                }
                contacts.RemoveRange(0, contacts.Count);
            }


            #region Update the semester Fee and course
            if (
                hfLatestSemesterFeesAmount.Value != txtSemesterFee.Text 
                || hfLatestSemesterFeesCourseID.Value != ddlCourseID.SelectedValue
                )
            {
                if (decimal.Parse(txtSemesterFee.Text) != 0)
                {
                    STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
                    sTD_FeesMaster = insertFeesMaster(29, sTD_Student.StudentID); //Semester Fee = 29
                }
            }
            #endregion

            Response.Redirect("AdminDetailsSTD_Student.aspx?ID=" + Request.QueryString["studentID"]);

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    private void showSTD_StudentData()
    {
        STD_Student sTD_Student = new STD_Student();
        sTD_Student = STD_StudentManager.GetSTD_StudentByStudentID(Request.QueryString["studentID"]);
        txtStudentName.Text = sTD_Student.StudentName.ToString();
        //txtPPSizePhoto.Text =sTD_Student.PPSizePhoto.ToString();
        txtStudentCode.Text = sTD_Student.StudentCode.ToString();
        txtPresentAddress.Text = sTD_Student.PresentAddress.ToString();
        txtPermanentAddress.Text = sTD_Student.PermanentAddress.ToString();
        txtTelephone.Text = sTD_Student.Telephone.ToString();
        txtMobile.Text = sTD_Student.Mobile.ToString();
        txtEmail.Text = sTD_Student.Email.ToString();
        txtDateofBirth.Text = sTD_Student.DateofBirth.ToString();
        txtPassportNo.Text = sTD_Student.PassportNo.ToString();
        txtGender.Text = sTD_Student.Gender.ToString();
        ddlMaritualStatusID.SelectedValue = sTD_Student.MaritualStatusID.ToString();
        ddlReligionID.SelectedValue = sTD_Student.ReligionID.ToString();
        txtSpouseQualification.Text = sTD_Student.SpouseQualification.ToString();
        txtEnglishQualification.Text = sTD_Student.EnglishQualification.ToString();
        radIsRegisterWithACCA.SelectedValue = sTD_Student.IsRegisterWithACCA.ToString();
        txtRegistrationDate.Text = sTD_Student.RegistrationDate.ToString();
        txtRegistrationNo.Text = sTD_Student.RegistrationNo.ToString();
        txtBloodGroup.Text = sTD_Student.BloodGroup.ToString();
        txtIELTS.Text = sTD_Student.IELTS.ToString();
        txtTOFEL.Text = sTD_Student.TOFEL.ToString();
        ddlCourseID.SelectedValue = sTD_Student.SpouseQualification;

        loadEducationalBackground(sTD_Student.StudentID);
        loadjobExperience(sTD_Student.StudentID);
        loadcontact(sTD_Student.StudentID);
        ddlBatchID.SelectedValue = sTD_Student.BatchNo.ToString();

        #region Load Semester fee
        DataSet ds = STD_FeesMasterManager.GetSTD_SemesterFeeByStudentID(Request.QueryString["studentID"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCourseID.SelectedValue = ds.Tables[0].Rows[0]["CourseID"].ToString();
            txtSemesterFee.Text = ds.Tables[0].Rows[0]["ExtraField5"].ToString();
            hfLatestSemesterFeesAmount.Value = ds.Tables[0].Rows[0]["ExtraField5"].ToString();
            hfLatestSemesterFeesCourseID.Value = ds.Tables[0].Rows[0]["CourseID"].ToString();
            hfLatestSemesterFeesTypeID.Value = ds.Tables[0].Rows[0]["FeesTypeID"].ToString();
            hfLatestSemesterFeesID.Value = ds.Tables[0].Rows[0]["FeesMasterID"].ToString();
        }
        #endregion
    }

    #region EducationalBackGournd
    private void loadEducationalBackground(string studentID)
    {
        List<COMN_EducatinalBackground> educationalBackground = new List<COMN_EducatinalBackground>();
        DataSet dsEducationalBackground = COMN_EducatinalBackgroundManager.GetCOMN_UserByUserID(studentID, true);

        int i = 0;
        foreach (DataRow drEducationalBackground in dsEducationalBackground.Tables[0].Rows)
        {
            COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
            cOMN_EducatinalBackground.EducationalBacgroundID = i++;
            cOMN_EducatinalBackground.UserID = drEducationalBackground["UserID"].ToString();
            
            cOMN_EducatinalBackground.Year = drEducationalBackground["Year"].ToString();
            cOMN_EducatinalBackground.BoardUniversity = drEducationalBackground["BoardUniversity"].ToString();
            cOMN_EducatinalBackground.EducationGroup = drEducationalBackground["EducationGroup"].ToString();
            cOMN_EducatinalBackground.Major = drEducationalBackground["Major"].ToString();
            cOMN_EducatinalBackground.ReaultSystemID = int.Parse(drEducationalBackground["ReaultSystemID"].ToString());
            cOMN_EducatinalBackground.ReaultSystemName = drEducationalBackground["ReaultSystemName"].ToString();
            cOMN_EducatinalBackground.Degree = drEducationalBackground["Degree"].ToString();
            cOMN_EducatinalBackground.Result = drEducationalBackground["Result"].ToString();
            cOMN_EducatinalBackground.Score = decimal.Parse(drEducationalBackground["Score"].ToString());
            cOMN_EducatinalBackground.OutOf = int.Parse(drEducationalBackground["OutOf"].ToString());
            cOMN_EducatinalBackground.AddedBy = drEducationalBackground["AddedBy"].ToString();
            cOMN_EducatinalBackground.AddedDate = DateTime.Parse(drEducationalBackground["AddedDate"].ToString());
            cOMN_EducatinalBackground.ModifiedBy = drEducationalBackground["ModifiedBy"].ToString();
            cOMN_EducatinalBackground.ModifiedDate = DateTime.Parse(drEducationalBackground["ModifiedDate"].ToString());

            educationalBackground.Add(cOMN_EducatinalBackground);
        }

        Session["educationalBackground"] = educationalBackground;

        gvCOMN_EducatinalBackground.DataSource = educationalBackground;
        gvCOMN_EducatinalBackground.DataBind();
    }
    protected void btnEducationalBackgroundAdd_Click(object sender, EventArgs e)
    {
        if (Session["educationalBackground"] == null)
        {
            List<COMN_EducatinalBackground> educationalBackground = new List<COMN_EducatinalBackground>();

            COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
            cOMN_EducatinalBackground.UserID = Profile.card_id;
            cOMN_EducatinalBackground.Year = txtYear.Text;
            cOMN_EducatinalBackground.BoardUniversity = txtBoardUniversity.Text;
            cOMN_EducatinalBackground.EducationGroup = txtEducationGroup.Text;
            cOMN_EducatinalBackground.Major = txtMajor.Text;
            cOMN_EducatinalBackground.ReaultSystemID = int.Parse(ddlReaultSystemID.SelectedValue);
            cOMN_EducatinalBackground.ReaultSystemName = ddlReaultSystemID.SelectedItem.Text;
            cOMN_EducatinalBackground.Degree = txtDegree.Text;
            cOMN_EducatinalBackground.Result = txtResult.Text;
            cOMN_EducatinalBackground.Score = decimal.Parse(txtScore.Text);
            cOMN_EducatinalBackground.OutOf = int.Parse(txtOutOf.Text);
            cOMN_EducatinalBackground.AddedBy = Profile.card_id;
            cOMN_EducatinalBackground.AddedDate = DateTime.Now;
            cOMN_EducatinalBackground.ModifiedBy = Profile.card_id;
            cOMN_EducatinalBackground.ModifiedDate = DateTime.Now;
            
            //int resutl = COMN_EducatinalBackgroundManager.InsertCOMN_EducatinalBackground(cOMN_EducatinalBackground);
            //add educational background
            cOMN_EducatinalBackground.EducationalBacgroundID = educationalBackground.Count;

            educationalBackground.Add(cOMN_EducatinalBackground);
            Session["educationalBackground"] = educationalBackground;

            gvCOMN_EducatinalBackground.DataSource = Session["educationalBackground"];
            gvCOMN_EducatinalBackground.DataBind();
        }
        else
        {
            COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
            cOMN_EducatinalBackground.UserID = Profile.card_id;
            cOMN_EducatinalBackground.Year = txtYear.Text;
            cOMN_EducatinalBackground.BoardUniversity = txtBoardUniversity.Text;
            cOMN_EducatinalBackground.EducationGroup = txtEducationGroup.Text;
            cOMN_EducatinalBackground.Major = txtMajor.Text;
            cOMN_EducatinalBackground.ReaultSystemID = int.Parse(ddlReaultSystemID.SelectedValue);
            cOMN_EducatinalBackground.Degree = txtDegree.Text;
            cOMN_EducatinalBackground.Result = txtResult.Text;
            cOMN_EducatinalBackground.Score = decimal.Parse(txtScore.Text);
            cOMN_EducatinalBackground.OutOf = int.Parse(txtOutOf.Text);
            cOMN_EducatinalBackground.AddedBy = Profile.card_id;
            cOMN_EducatinalBackground.AddedDate = DateTime.Now;
            cOMN_EducatinalBackground.ModifiedBy = Profile.card_id;
            cOMN_EducatinalBackground.ModifiedDate = DateTime.Now;
            //int resutl = COMN_EducatinalBackgroundManager.InsertCOMN_EducatinalBackground(cOMN_EducatinalBackground);
            //add educational background
            cOMN_EducatinalBackground.EducationalBacgroundID = ((List<COMN_EducatinalBackground>)Session["educationalBackground"]).Count;

            ((List<COMN_EducatinalBackground>)Session["educationalBackground"]).Add(cOMN_EducatinalBackground);
           
            gvCOMN_EducatinalBackground.DataSource = Session["educationalBackground"];
            gvCOMN_EducatinalBackground.DataBind();
        }

    }
    protected void btnEducationalBackgroundUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["educationalBackground"] != null)
            {
                List<COMN_EducatinalBackground> educationalBackground = new List<COMN_EducatinalBackground>();
                educationalBackground = (List<COMN_EducatinalBackground>)Session["educationalBackground"];

                COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
                cOMN_EducatinalBackground.EducationalBacgroundID = int.Parse(hfEducationalBackgroundID.Value);
                cOMN_EducatinalBackground.UserID = hfUserID.Value;
                cOMN_EducatinalBackground.Year = txtYear.Text;
                cOMN_EducatinalBackground.BoardUniversity = txtBoardUniversity.Text;
                cOMN_EducatinalBackground.EducationGroup = txtEducationGroup.Text;
                cOMN_EducatinalBackground.Major = txtMajor.Text;
                cOMN_EducatinalBackground.ReaultSystemID = int.Parse(ddlReaultSystemID.SelectedValue);
                cOMN_EducatinalBackground.Degree = txtDegree.Text;
                cOMN_EducatinalBackground.Result = txtResult.Text;
                cOMN_EducatinalBackground.Score = decimal.Parse(txtScore.Text);
                cOMN_EducatinalBackground.OutOf = int.Parse(txtOutOf.Text);
                cOMN_EducatinalBackground.AddedBy = Profile.card_id;
                cOMN_EducatinalBackground.AddedDate = DateTime.Now;
                cOMN_EducatinalBackground.ModifiedBy = Profile.card_id;
                cOMN_EducatinalBackground.ModifiedDate = DateTime.Now;


                educationalBackground[int.Parse(hfEducationalBackgroundID.Value)] = cOMN_EducatinalBackground;
                Session["educationalBackground"] = educationalBackground;
                gvCOMN_EducatinalBackground.DataSource = educationalBackground;
                gvCOMN_EducatinalBackground.DataBind();

                btnEducationalBackgroundAdd.Visible = true;
                btnEducationalBackgroundUpdate.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbSelectEducationalBackGround_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        showCOMN_EducatinalBackgroundData(id);

        btnEducationalBackgroundAdd.Visible = false;
        btnEducationalBackgroundUpdate.Visible = true;
    }

    private void showCOMN_EducatinalBackgroundData(int educationalBackgroundID)
    {
        try
        {
            if (Session["educationalBackground"] != null)
            {
                List<COMN_EducatinalBackground> educationalBackground = new List<COMN_EducatinalBackground>();
                educationalBackground = (List<COMN_EducatinalBackground>)Session["educationalBackground"];

                COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();

                cOMN_EducatinalBackground = educationalBackground[educationalBackgroundID];
                //cOMN_EducatinalBackground = COMN_EducatinalBackgroundManager.GetCOMN_EducatinalBackgroundByEducationalBacgroundID(educationalBackgroundID);
                hfEducationalBackgroundID.Value = educationalBackgroundID.ToString();
                hfUserID.Value = cOMN_EducatinalBackground.UserID == null ? Profile.card_id : cOMN_EducatinalBackground.UserID;
                txtYear.Text = cOMN_EducatinalBackground.Year.ToString();
                txtBoardUniversity.Text = cOMN_EducatinalBackground.BoardUniversity.ToString();
                txtEducationGroup.Text = cOMN_EducatinalBackground.EducationGroup.ToString();
                txtMajor.Text = cOMN_EducatinalBackground.Major.ToString();
                ddlReaultSystemID.SelectedValue = cOMN_EducatinalBackground.ReaultSystemID.ToString();
                txtDegree.Text = cOMN_EducatinalBackground.Degree.ToString();
                txtResult.Text = cOMN_EducatinalBackground.Result.ToString();
                txtScore.Text = cOMN_EducatinalBackground.Score.ToString();
                txtOutOf.Text = cOMN_EducatinalBackground.OutOf.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbDeleteEducationalBackGround_Click(object sender, EventArgs e)
    {
        try
        {
            List<COMN_EducatinalBackground> educationalBackground = new List<COMN_EducatinalBackground>();
            educationalBackground = (List<COMN_EducatinalBackground>)Session["educationalBackground"];

            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            educationalBackground.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
            for (int i = 0; i < educationalBackground.Count; i++)
            {
                educationalBackground[i].EducationalBacgroundID = i;
            }
            Session["educationalBackground"] = educationalBackground;
            gvCOMN_EducatinalBackground.DataSource = educationalBackground;
            gvCOMN_EducatinalBackground.DataBind();
        }
        catch (Exception ex)
        { }
    }
    #endregion

    #region JobExperience
    private void loadjobExperience(string studentID)
    {
        List<COMN_JobExperience> jobexperience = new List<COMN_JobExperience>();
       
        DataSet dsjobExperience = COMN_JobExperienceManager.GetCOMN_UserByUserID(studentID, true);

        int i = 0;
        foreach (DataRow drjobExperience in dsjobExperience.Tables[0].Rows)
        {
            COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience();
            cOMN_JobExperience.JobExperienceID = i++;
            cOMN_JobExperience.UserID = drjobExperience["UserID"].ToString();
            cOMN_JobExperience.OrganizationName = drjobExperience["OrganizationName"].ToString();
            cOMN_JobExperience.Designation = drjobExperience["Designation"].ToString();
            cOMN_JobExperience.NatureofWork = drjobExperience["NatureofWork"].ToString(); ;
            cOMN_JobExperience.DateStart = DateTime.Parse(drjobExperience["DateStart"].ToString());
            cOMN_JobExperience.DateEnds = DateTime.Parse(drjobExperience["DateEnds"].ToString());
            cOMN_JobExperience.Duration = decimal.Parse(drjobExperience["Duration"].ToString());
            cOMN_JobExperience.ReasionForLeaving = drjobExperience["ReasionForLeaving"].ToString();
            cOMN_JobExperience.Contact = drjobExperience["Contact"].ToString();
            cOMN_JobExperience.AddedBy = Profile.card_id;
            cOMN_JobExperience.AddedDate = DateTime.Parse(drjobExperience["AddedDate"].ToString());
            cOMN_JobExperience.UpdatedBy = Profile.card_id;
            cOMN_JobExperience.UpdatedDate = DateTime.Parse(drjobExperience["UpdatedDate"].ToString());

            jobexperience.Add(cOMN_JobExperience);
        }
        Session["jobexperience"] = jobexperience;
        gvCOMN_JobExperience.DataSource = jobexperience;
        gvCOMN_JobExperience.DataBind();
    }
    protected void btnjobExperienceAdd_Click(object sender, EventArgs e)
    {
        if (Session["jobexperience"] != null)
        {
            COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience();
            cOMN_JobExperience.UserID = Profile.card_id;
            cOMN_JobExperience.OrganizationName = txtOrganizationName.Text;
            cOMN_JobExperience.Designation = txtDesignation.Text;
            cOMN_JobExperience.NatureofWork = txtNatureofWork.Text;
            cOMN_JobExperience.DateStart =txtDateStart.Text!=""? DateTime.Parse(txtDateStart.Text):DateTime.Parse("1/1/1753");
            cOMN_JobExperience.DateEnds = DateTime.Parse(txtDateEnds.Text);
            cOMN_JobExperience.Duration =txtDuration.Text!=""? decimal.Parse(txtDuration.Text):0;
            cOMN_JobExperience.ReasionForLeaving = txtReasionForLeaving.Text;
            cOMN_JobExperience.Contact = txtContact.Text;
            cOMN_JobExperience.AddedBy = Profile.card_id;
            cOMN_JobExperience.AddedDate = DateTime.Now;
            cOMN_JobExperience.UpdatedBy = Profile.card_id;
            cOMN_JobExperience.UpdatedDate = DateTime.Now;
            
            //int resutl = COMN_JobExperienceManager.InsertCOMN_JobExperience(cOMN_JobExperience);
            //add educational background


            cOMN_JobExperience.JobExperienceID = ((List<COMN_JobExperience>)Session["jobexperience"]).Count;

            ((List<COMN_JobExperience>)Session["jobexperience"]).Add(cOMN_JobExperience);

            gvCOMN_JobExperience.DataSource = Session["jobexperience"];
            gvCOMN_JobExperience.DataBind();
        }

        else
        {
            List<COMN_JobExperience> jobexperience = new List<COMN_JobExperience>();

            COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience();
            cOMN_JobExperience.UserID = Profile.card_id;
            cOMN_JobExperience.OrganizationName = txtOrganizationName.Text;
            cOMN_JobExperience.Designation = txtDesignation.Text;
            cOMN_JobExperience.NatureofWork = txtNatureofWork.Text;
            cOMN_JobExperience.DateStart = DateTime.Parse(txtDateStart.Text);
            cOMN_JobExperience.DateEnds = DateTime.Parse(txtDateEnds.Text);
            cOMN_JobExperience.Duration = decimal.Parse(txtDuration.Text);
            cOMN_JobExperience.ReasionForLeaving = txtReasionForLeaving.Text;
            cOMN_JobExperience.Contact = txtContact.Text;
            cOMN_JobExperience.AddedBy = Profile.card_id;
            cOMN_JobExperience.AddedDate = DateTime.Now;
            cOMN_JobExperience.UpdatedBy = Profile.card_id;
            cOMN_JobExperience.UpdatedDate = DateTime.Now;
            //int resutl = COMN_JobExperienceManager.InsertCOMN_JobExperience(cOMN_JobExperience);
            //add educational background


            cOMN_JobExperience.JobExperienceID = jobexperience.Count;

            jobexperience.Add(cOMN_JobExperience);

            Session["jobexperience"] = jobexperience;

            gvCOMN_JobExperience.DataSource = Session["jobexperience"];
            gvCOMN_JobExperience.DataBind();
        }
    }
    protected void btnjobExperienceUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["jobexperience"] != null)
            {
                List<COMN_JobExperience> jobexperience = new List<COMN_JobExperience>();
                jobexperience = (List<COMN_JobExperience>)Session["jobexperience"];

                COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience();
                cOMN_JobExperience.JobExperienceID = int.Parse(hfjobExperienceID.Value);
                cOMN_JobExperience.UserID = hfUserID.Value;
                cOMN_JobExperience.OrganizationName = txtOrganizationName.Text;
                cOMN_JobExperience.Designation = txtDesignation.Text;
                cOMN_JobExperience.NatureofWork = txtNatureofWork.Text;
                cOMN_JobExperience.DateStart = DateTime.Parse(txtDateStart.Text);
                cOMN_JobExperience.DateEnds = DateTime.Parse(txtDateEnds.Text);
                cOMN_JobExperience.Duration = decimal.Parse(txtDuration.Text);
                cOMN_JobExperience.ReasionForLeaving = txtReasionForLeaving.Text;
                cOMN_JobExperience.Contact = txtContact.Text;
                cOMN_JobExperience.AddedBy = Profile.card_id;
                cOMN_JobExperience.AddedDate = DateTime.Now;
                cOMN_JobExperience.UpdatedBy = Profile.card_id;
                cOMN_JobExperience.UpdatedDate = DateTime.Now;



                jobexperience[int.Parse(hfjobExperienceID.Value)] = cOMN_JobExperience;
                Session["jobexperience"] = jobexperience;
                gvCOMN_JobExperience.DataSource = jobexperience;
                gvCOMN_JobExperience.DataBind();

                btnjobExperienceAdd.Visible = true;
                btnjobExperienceUpdate.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbSelectjobExperience_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        showCOMN_JobExperienceData(id);

        btnjobExperienceAdd.Visible = false;
        btnjobExperienceUpdate.Visible = true;
    }

    private void showCOMN_JobExperienceData(int jobExperienceID)
    {
        try
        {
            if (Session["jobexperience"] != null)
            {
                List<COMN_JobExperience> jobexperience = new List<COMN_JobExperience>();
                jobexperience = (List<COMN_JobExperience>)Session["jobexperience"];

                COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience();

                cOMN_JobExperience = jobexperience[jobExperienceID];

                hfjobExperienceID.Value = jobExperienceID.ToString();
                hfUserID.Value = cOMN_JobExperience.UserID == null ? Profile.card_id : cOMN_JobExperience.UserID;
                txtOrganizationName.Text = cOMN_JobExperience.OrganizationName.ToString();
                txtDesignation.Text = cOMN_JobExperience.Designation;
                txtNatureofWork.Text = cOMN_JobExperience.NatureofWork.ToString();
                txtDateStart.Text = cOMN_JobExperience.DateStart.ToString();
                txtDateEnds.Text = cOMN_JobExperience.DateEnds.ToString();
                txtDuration.Text = cOMN_JobExperience.Duration.ToString();
                txtReasionForLeaving.Text = cOMN_JobExperience.ReasionForLeaving.ToString();
                txtContact.Text = cOMN_JobExperience.Contact.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbDeletejobExperience_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["jobexperience"] != null)
            {
                List<COMN_JobExperience> jobexperience = new List<COMN_JobExperience>();
                jobexperience = (List<COMN_JobExperience>)Session["jobexperience"];

                ImageButton linkButton = new ImageButton();
                linkButton = (ImageButton)sender;


                jobexperience.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
                for (int i = 0; i < jobexperience.Count; i++)
                {
                    jobexperience[i].JobExperienceID = i;
                }
                Session["jobexperience"] = jobexperience;
                gvCOMN_JobExperience.DataSource = jobexperience;
                gvCOMN_JobExperience.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion

    #region contact
    private void loadcontact(string studentID)
    {
         
        List<STD_Contact> contacts = new List<STD_Contact>();
        DataSet dscontact = STD_ContactManager.GetSTDContactByStudentID(studentID, true);

        int i = 0;
        foreach (DataRow drcontact in dscontact.Tables[0].Rows)
        {
            STD_Contact sTD_Contact = new STD_Contact();

            sTD_Contact.ContactID = i++;
            sTD_Contact.StudentID = drcontact["StudentID"].ToString();
            sTD_Contact.Name = drcontact["Name"].ToString();
            sTD_Contact.CellNo = drcontact["CellNo"].ToString();
            sTD_Contact.Occupation = drcontact["Occupation"].ToString();
            sTD_Contact.OfficeTel = drcontact["OfficeTel"].ToString();
            sTD_Contact.OfficeAddress = drcontact["OfficeAddress"].ToString();
            sTD_Contact.ContactTypeID = int.Parse(drcontact["ContactTypeID"].ToString());
            sTD_Contact.AddedBy = drcontact["AddedBy"].ToString();
            sTD_Contact.AddedDate = DateTime.Parse(drcontact["AddedDate"].ToString());
            sTD_Contact.ModifiedBy = drcontact["ModifiedBy"].ToString();
            sTD_Contact.ModifiedDate = DateTime.Parse(drcontact["ModifiedDate"].ToString());
            sTD_Contact.RowStatusID = 1;

            contacts.Add(sTD_Contact);
        }

        Session["contacts"] = contacts;

        gvSTD_Contact.DataSource = contacts;
        gvSTD_Contact.DataBind();
    }
    protected void btnContactAdd_Click(object sender, EventArgs e)
    {
        if (Session["contacts"] == null)
        {
            List<STD_Contact> contacts = new List<STD_Contact>();

            STD_Contact sTD_Contact = new STD_Contact();
            //	sTD_Contact.ContactID=  int.Parse(ddlContactID.SelectedValue);
            sTD_Contact.StudentID = Profile.card_id;
            sTD_Contact.Name = txtName.Text;
            sTD_Contact.CellNo = txtCellNo.Text;
            sTD_Contact.Occupation = txtOccupation.Text;
            sTD_Contact.OfficeTel = txtOfficeTel.Text;
            sTD_Contact.OfficeAddress = txtOfficeAddress.Text;
            sTD_Contact.ContactTypeID = int.Parse(ddlContactTypeID.SelectedValue);
            sTD_Contact.AddedBy = Profile.card_id;
            sTD_Contact.AddedDate = DateTime.Now;
            sTD_Contact.ModifiedBy = Profile.card_id;
            sTD_Contact.ModifiedDate = DateTime.Now;
            sTD_Contact.RowStatusID = 1;
            //int resutl = STD_ContactManager.InsertSTD_Contact(STD_Contact);
            //add educational background


            sTD_Contact.ContactID = contacts.Count;

            contacts.Add(sTD_Contact);

            Session["contacts"] = contacts;

            gvSTD_Contact.DataSource = Session["contacts"];
            gvSTD_Contact.DataBind();
        }
        else
        {
            STD_Contact sTD_Contact = new STD_Contact();
            //	sTD_Contact.ContactID=  int.Parse(ddlContactID.SelectedValue);
            sTD_Contact.StudentID = Profile.card_id;
            sTD_Contact.Name = txtName.Text;
            sTD_Contact.CellNo = txtCellNo.Text;
            sTD_Contact.Occupation = txtOccupation.Text;
            sTD_Contact.OfficeTel = txtOfficeTel.Text;
            sTD_Contact.OfficeAddress = txtOfficeAddress.Text;
            sTD_Contact.ContactTypeID = int.Parse(ddlContactTypeID.SelectedValue);
            sTD_Contact.AddedBy = Profile.card_id;
            sTD_Contact.AddedDate = DateTime.Now;
            sTD_Contact.ModifiedBy = Profile.card_id;
            sTD_Contact.ModifiedDate = DateTime.Now;

            sTD_Contact.RowStatusID = 1;
            //int resutl = STD_ContactManager.InsertSTD_Contact(STD_Contact);
            //add educational background


            sTD_Contact.ContactID = ((List < STD_Contact >) Session["contacts"]).Count;

            ((List<STD_Contact>)Session["contacts"]).Add(sTD_Contact);

            gvSTD_Contact.DataSource = Session["contacts"];
            gvSTD_Contact.DataBind();
        }
    }
    protected void btnContactUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            List<STD_Contact> contacts = new List<STD_Contact>();
            contacts = (List<STD_Contact>)Session["contacts"];

            STD_Contact sTD_Contact = new STD_Contact();
            sTD_Contact.ContactID = int.Parse(hfContactID.Value);
            sTD_Contact.StudentID = hfUserID.Value;
            sTD_Contact.Name = txtName.Text;
            sTD_Contact.CellNo = txtCellNo.Text;
            sTD_Contact.Occupation = txtOccupation.Text;
            sTD_Contact.OfficeTel = txtOfficeTel.Text;
            sTD_Contact.OfficeAddress = txtOfficeAddress.Text;
            sTD_Contact.ContactTypeID = int.Parse(ddlContactTypeID.SelectedValue);
            sTD_Contact.AddedBy = Profile.card_id;
            sTD_Contact.AddedDate = DateTime.Now;
            sTD_Contact.ModifiedBy = Profile.card_id;
            sTD_Contact.ModifiedDate = DateTime.Now;

            contacts[int.Parse(hfContactID.Value)] = sTD_Contact;
            Session["contacts"] = contacts;
            gvSTD_Contact.DataSource = contacts;
            gvSTD_Contact.DataBind();

            btnContactAdd.Visible = true;
            btnContactUpdate.Visible = false;
        }

        catch (Exception ex)
        {
        }
    }

    protected void lbSelectContact_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        showSTD_ContactData(id);

        btnContactAdd.Visible = false;
        btnContactUpdate.Visible = true;
    }

    private void showSTD_ContactData(int contactID)
    {
        try
        {
            if (Session["contacts"] != null)
            {
                List<STD_Contact> contacts = new List<STD_Contact>();
                contacts = (List<STD_Contact>)Session["contacts"];

                STD_Contact STD_Contact = new STD_Contact();

                STD_Contact = contacts[contactID];

                STD_Contact sTD_Contact = new STD_Contact();
                sTD_Contact = contacts[contactID];
                hfContactID.Value = contactID.ToString();
                hfUserID.Value = STD_Contact.StudentID == null ? Profile.card_id : STD_Contact.StudentID;
                txtName.Text = sTD_Contact.Name.ToString();
                txtCellNo.Text = sTD_Contact.CellNo.ToString();
                txtOccupation.Text = sTD_Contact.Occupation.ToString();
                txtOfficeTel.Text = sTD_Contact.OfficeTel.ToString();
                txtOfficeAddress.Text = sTD_Contact.OfficeAddress.ToString();
                ddlContactTypeID.SelectedValue = sTD_Contact.ContactTypeID.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbDeleteContact_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["contacts"] != null)
            {
                List<STD_Contact> contacts = new List<STD_Contact>();
                contacts = (List<STD_Contact>)Session["contacts"];

                ImageButton linkButton = new ImageButton();
                linkButton = (ImageButton)sender;



                contacts.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
                for (int i = 0; i < contacts.Count; i++)
                {
                    contacts[i].ContactID = i;
                }
                Session["contacts"] = contacts;
                gvSTD_Contact.DataSource = contacts;
                gvSTD_Contact.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion



    protected void radIsRegisterWithACCA_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (radIsRegisterWithACCA.SelectedIndex == 0)
        {
            pnRegistration.Visible = true;
            rfvRegi.Enabled = true;
        }
        else
        {
            pnRegistration.Visible = false;
            rfvRegi.Enabled = false;
        }
    }
    protected void btnShowCurrentPhoto_Click(object sender, EventArgs e)
    {
        STD_Student std = STD_StudentManager.GetHR_StudnetByStudentCode(txtID.Text);

        imgCurrentPhoto.ImageUrl = std.PPSizePhoto;
        hfUserID.Value = std.StudentID;
    }
    protected void btnSavePhoto_Click(object sender, EventArgs e)
    {
        STD_Student sTD_Student = STD_StudentManager.GetHR_StudnetByStudentCode(txtID.Text);
        DeleteFileFromFolder(sTD_Student.PPSizePhoto);
        if (Session["imagePath"] != null)
        {
            try
            {
                string dirUrl = "~/Uploads/StudentImages";
                string dirPath = Server.MapPath(dirUrl);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string picPath = Session["imagePath"].ToString();
                Session.Remove("imagePath");
                string[] st = picPath.ToString().Split('.');
                string st_pic = st[1];
                string fileName = sTD_Student.StudentID + "." + st_pic;
                string fileUrl = dirUrl + "/" + fileName;

                System.Drawing.Image stImage = System.Drawing.Image.FromFile(picPath);
                stImage.Save(Server.MapPath(fileUrl));

                sTD_Student.PPSizePhoto = fileUrl;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        else
        {
            if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
            {
                try
                {
                    string dirUrl = "~/Uploads/StudentImages";
                    string dirPath = Server.MapPath(dirUrl);

                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                    string fileUrl = dirUrl + "/" + sTD_Student.StudentID + "_" + Path.GetFileName(uplFile.PostedFile.FileName);
                    string filePath = Server.MapPath(fileUrl);
                    uplFile.PostedFile.SaveAs(filePath);

                    System.Drawing.Image originalImage = System.Drawing.Image.FromFile(filePath);
                    System.Drawing.Image resizedImage = resizeImageWithGivenValue(originalImage, 150, 150);
                    resizedImage.Save(dirPath + "/" + "Display_" + sTD_Student.StudentID + fileName, ImageFormat.Jpeg);

                    sTD_Student.PPSizePhoto = dirUrl + "/" + "Display_" + sTD_Student.StudentID + fileName;
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
            else
            {
                sTD_Student.PPSizePhoto = "~/Uploads/StudentImages/NoImage.jpg";
            }
        }

        STD_StudentManager.UpdateSTD_Student(sTD_Student);
    }

    public void DeleteFileFromFolder(string StrFilename)
    {
        if (StrFilename.Contains("NoImage.jpg"))
            return;

        try
        {
            string strPhysicalFolder = Server.MapPath("..\\Uploads\\StudentImages\\");
            string strFileFullPath = strPhysicalFolder + StrFilename.Split('/')[2];

            if (System.IO.File.Exists(strFileFullPath))
            {
                System.IO.File.Delete(strFileFullPath);
            }
        }
        catch (Exception ex)
        {
        }
    }
}

