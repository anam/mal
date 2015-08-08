using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Web.Security;

public partial class DataUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected string valid(OleDbDataReader myreader, int stval)//if any columns are found null then they are replaced by zero
    {
        object val = myreader[stval];
        if (val != DBNull.Value)
            return val.ToString();
        else
            return Convert.ToString(0);
    }

   
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
        {
            try
            {
                string dirUrl = "~/Uploads/Project";
                string dirPath = Server.MapPath(dirUrl);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
                string filePath = Server.MapPath(fileUrl);
                uplFile.PostedFile.SaveAs(filePath);


                OleDbConnection oconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0");
                try
                {

                    OleDbCommand ocmd = new OleDbCommand("select * from [CUCData$]", oconn);
                    oconn.Open();
                    OleDbDataReader odr = ocmd.ExecuteReader();
                    DateTime CreateDate = DateTime.Now.Date;
                    string UserName = this.User.Identity.Name;

                    string s_id = "";
                    string p_id = "";
                    string s_name = "";
                    string password = "";
                    string father_name = "";
                    string pre_add = "";
                    string tel = "";

                    string mob = "";
                    string email = "";
                    string dob = "";

                    string gender = "";
                    string r_id = "";
                    string pay_method = "";

                    string total = "";
                    string course_discount = "";
                    string no_installment = "";
                    string prev_payment = "";
                    string pic_ext = "";


                    while (odr.Read())
                    {
                        //CreateDate = DateTime.Parse(valid(odr, 0));
                        //UserName = valid(odr, 1);

                        s_id = valid(odr, 0);
                        p_id = valid(odr, 1);
                        s_name = valid(odr, 2);
                        password = valid(odr, 3);


                        father_name = valid(odr, 4);
                        pre_add = valid(odr, 5);
                        tel = valid(odr, 6);
                        mob = valid(odr, 7);

                        email = valid(odr, 8);
                        dob = valid(odr, 9);
                        gender = valid(odr, 10);
                        r_id = valid(odr, 11);


                        pay_method = valid(odr, 12);
                        total = valid(odr, 13);
                        course_discount = valid(odr, 14);
                        no_installment = valid(odr, 15);
                        prev_payment = valid(odr, 16);
                        pic_ext = valid(odr, 17);

                        //IsUploaded = bool.Parse(valid(odr, 21));
                        StudentManager.InsertStudent(new Student(s_id,p_id, s_name, password, father_name, pre_add, tel, mob, email,dob, gender, r_id, pay_method, total, course_discount, no_installment, prev_payment, pic_ext,"0"));

                        //gvProduct.DataSource = Product_TempManager.DisplayProduct(this.User.Identity.Name);
                        //gvProduct.DataBind();
                        //string cityName = "Dallas";

                        //int cityID = CityManager.InsertCity( new City(0,cityName,));

                        //insertdataintosql(fname, lname, mobnum, city, state, zip);
                        //PropertyManager.InsertProperty(new Property(0, AddedDate, AddedBy, PropertiesTypeID, PropertyName, PropertyDesc, ShortDesc, Address, StreetName,
                        //                    StateID, CityID, MLS, PostalCode, ImageURL, BedRoom, BathRoom, OrginalPrice, SellPrice, IsFeature, IsRent,
                        //                    IsBuy, IsLatest, IsSell, PropertySize, MinKitchen, MadeDate));
                    }
                    oconn.Close();
                }
                catch (DataException ee)
                {
                    //lblErrorMsg.Text = ee.Message;
                    //lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    //lblErrorMsg.Text = "Data Inserted Sucessfully";
                    //lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                }

            }
            catch (Exception ex)
            {
                //lblErrorMsg.Text = ex.Message.ToString();
                //lblErrorMsg.Text = lblErrorMsg.Text + "<br />Please rename your file. ";
            }
        }
        else
        {
            //appartments.ImageURL = "~/Uploads/Project/NoFile.jpg";
        }
    }
    protected void btnAddStudent_Click(object sender, EventArgs e)
    {
        try
        {

            var studentID = "";
            string email = "";
            int sID = 1;

            List<Student> students = StudentManager.GetAllStudents();

            foreach (Student student in students)
            {
                

                #region Create User

                if (student.Email != "")
                {
                    MembershipCreateStatus result;

                    try
                    {


                        Membership.CreateUser(student.S_id, "123456", student.Email, "a", "a", true, out result);

                        switch (result)
                        {
                            case MembershipCreateStatus.Success:

                                FormsAuthentication.SetAuthCookie(student.S_id.ToString(), true);

                                var role = "STD";

                                MembershipUser myObject = Membership.GetUser(student.S_id.Trim());
                                studentID = myObject.ProviderUserKey.ToString();

                                //Assign Role to the Student
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

                else
                {
                    MembershipCreateStatus result;
                    try
                    {


                        email = student.S_id.ToString() + "@cuc.com";
                        Membership.CreateUser(student.S_id, "123456", email, "a", "a", true, out result);

                        switch (result)
                        {
                            case MembershipCreateStatus.Success:

                                FormsAuthentication.SetAuthCookie(student.S_id.ToString(), true);

                                var role = "STD";

                                MembershipUser myObject = Membership.GetUser(student.S_id.Trim());
                                studentID = myObject.ProviderUserKey.ToString();

                                //Assign Role to the Student
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

                #endregion



                #region StudentInfo
                try
                {
                    STD_Student sTD_Student = new STD_Student();
                    sTD_Student.StudentID = studentID;
                    sTD_Student.StudentName = student.S_name;
                    //sTD_Student.PPSizePhoto=  "Fileurl";


                    sTD_Student.PPSizePhoto = "~/Uploads/StudentImages/NoImage.jpg";

                    sTD_Student.StudentCode = student.S_id;
                    sTD_Student.PresentAddress = student.Pre_add;
                    sTD_Student.PermanentAddress = student.Pre_add;
                    sTD_Student.Telephone = student.Tel;
                    sTD_Student.Mobile = student.Mob;
                    sTD_Student.Email = student.Email != "" ? student.Email : email;

                    DateTime dateOfBirth = new DateTime(1970, 1, 1, 0, 0, 0, 0);

                    dateOfBirth = dateOfBirth.AddSeconds(int.Parse(student.Dob));

                    sTD_Student.DateofBirth = dateOfBirth;

                    sTD_Student.PassportNo = student.Password;
                    sTD_Student.Gender = student.Gender;
                    sTD_Student.MaritualStatusID = 1;
                    sTD_Student.ReligionID = student.R_id != "" ? int.Parse(student.R_id) : 0;
                    sTD_Student.SpouseQualification = "";
                    sTD_Student.EnglishQualification = "";
                    sTD_Student.IsRegisterWithACCA = false;
                    sTD_Student.RegistrationDate = DateTime.Parse("1/1/1753");
                    sTD_Student.RegistrationNo = "";
                    sTD_Student.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
                    sTD_Student.AddedDate = DateTime.Now;
                    sTD_Student.ModifiedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
                    sTD_Student.ModifiedDate = DateTime.Now;
                    sTD_Student.BloodGroup = "";
                    sTD_Student.IELTS = 0;
                    sTD_Student.TOFEL = 0;
                    sTD_Student.ID = sID;
                    sTD_Student.BatchNo = 12007;
                    sTD_Student.Year = DateTime.Now.Year;
                    //sTD_Student.StudentID = 
                    sTD_Student.RowStatusID = 1;
                    DataSet dsStudent = new DataSet();
                    dsStudent = STD_StudentManager.InsertSTD_Student(sTD_Student);


                    sTD_Student.StudentID = dsStudent.Tables[0].Rows[0]["StudentID"].ToString();
                    sTD_Student.StudentCode = dsStudent.Tables[0].Rows[0]["StudentCode"].ToString();

                    if (sTD_Student.StudentID != "")
                    {
                        //add to educational background to the db

                        STD_Contact contact = new STD_Contact();

                        contact.StudentID = sTD_Student.StudentID;
                        contact.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
                        contact.ModifiedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
                        contact.ModifiedDate = DateTime.Now;
                        contact.Name = student.Father_name;
                        contact.Occupation = "";
                        contact.OfficeAddress = "";
                        contact.OfficeTel = "";
                        contact.RowStatusID = 1;
                        contact.CellNo = "";
                        contact.ContactTypeID = 1;
                        contact.AddedDate = DateTime.Now;
                        STD_ContactManager.InsertSTD_Contact(contact);

                    }



                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
                #endregion

            }
        }

        catch (Exception ex)
        {
        }
    
    
    }
    protected void btnPayment_OnClick(object sender, EventArgs e)
    {
        decimal totalPayment = 0;
        //Student student = StudentManager.GetStudentByID("110112872");

        List<Student> students = StudentManager.GetAllStudents();

        foreach (Student student in students)
        {

            List<Account> payments = AccountManager.CUCTEST_GetAmountByS_ID(student.S_id);

            foreach (Account payment in payments)
            {
                totalPayment = totalPayment + payment.Received_amount;
            }
            student.TotalPayemt = totalPayment.ToString();
            StudentManager.UpdateStudent(student);
            totalPayment = 0;
        }
    }
    protected void btnFees_OnClick(object sender, EventArgs e)
    {

        List<Student> students = StudentManager.GetAllStudents();

        foreach (Student student in students)
        {
            STD_FeesMaster feesMaster = new STD_FeesMaster();

            //feesMaster.CourseID =int.Parse(student.P_id);
            //feesMaster.Discount = decimal.Parse(student.Course_discount);
            //feesMaster.TotalPayment = decimal.Parse(student.Total);
            //feesMaster.TotalPaymentNeedtoPay = decimal.Parse(student.Total) - decimal.Parse(student.Course_discount);
            //feesMaster.FeesTypeID = 31;
            //feesMaster.FeesMasterName = "";
            //feesMaster.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            //feesMaster.AddedDate = DateTime.Now;
            STD_Student st = STD_StudentManager.GetHR_StudnetByStudentCode(student.S_id);
            if (st == null)
                lblError.Text =lblError.Text+ " " +student.S_id ;

            //if (st != null)
            //    feesMaster.StudentID = st.StudentID;
            //else
            //    continue;

            //feesMaster.RowStatusID = 1;
            //feesMaster.Remarks = "";
            //feesMaster.SubmissionDate = DateTime.Now;
            //feesMaster.SubmitedDate = "";
            //feesMaster.UpdateDate = DateTime.Now;
            //feesMaster.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            //feesMaster.PaymentStatusID = 1;
            //feesMaster.ExtraField1 = student.TotalPayemt;

            //feesMaster.ExtraField2 = (decimal.Parse(student.Total) - decimal.Parse(student.Course_discount) - decimal.Parse(feesMaster.ExtraField1)).ToString();
            //if (feesMaster.ExtraField2 == "0")
            //    feesMaster.IsPaid = true;
            //else
            //    feesMaster.IsPaid = false;
            //feesMaster.ExtraField3 = "";
            //feesMaster.ExtraField4 = "";
            //feesMaster.ExtraField5 = "";
            //int result = STD_FeesMasterManager.InsertSTD_FeesMaster(feesMaster);

        }

        //lblError.Text = "Fees Added Successfully.";
    }
    protected void btnRejectedDate_OnClick(object sender, EventArgs e)
    {
        int sID = 1;
        var studentID = "";
        Student student = StudentManager.GetStudentByID("93102412");

        #region StudentInfo
        try
        {
            STD_Student sTD_Student = new STD_Student();

            MembershipUser myObject = Membership.GetUser("93102412");
            studentID = myObject.ProviderUserKey.ToString();
            

            sTD_Student.StudentID = studentID;
            sTD_Student.StudentName = student.S_name;
            //sTD_Student.PPSizePhoto=  "Fileurl";


            sTD_Student.PPSizePhoto = "~/Uploads/StudentImages/NoImage.jpg";

            sTD_Student.StudentCode = student.S_id;
            sTD_Student.PresentAddress = student.Pre_add;
            sTD_Student.PermanentAddress = student.Pre_add;
            sTD_Student.Telephone = student.Tel;
            sTD_Student.Mobile = student.Mob;
            sTD_Student.Email = student.Email;

            DateTime dateOfBirth = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            dateOfBirth = dateOfBirth.AddSeconds(int.Parse(student.Dob));

            sTD_Student.DateofBirth = dateOfBirth;

            sTD_Student.PassportNo = student.Password;
            sTD_Student.Gender = student.Gender;
            sTD_Student.MaritualStatusID = 1;
            sTD_Student.ReligionID = student.R_id != "" ? int.Parse(student.R_id) : 0;
            sTD_Student.SpouseQualification = "";
            sTD_Student.EnglishQualification = "";
            sTD_Student.IsRegisterWithACCA = false;
            sTD_Student.RegistrationDate = DateTime.Parse("1/1/1753");
            sTD_Student.RegistrationNo = "";
            sTD_Student.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_Student.AddedDate = DateTime.Now;
            sTD_Student.ModifiedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_Student.ModifiedDate = DateTime.Now;
            sTD_Student.BloodGroup = "";
            sTD_Student.IELTS = 0;
            sTD_Student.TOFEL = 0;
            sTD_Student.ID = sID;
            sTD_Student.BatchNo = 12007;
            sTD_Student.Year = DateTime.Now.Year;
            //sTD_Student.StudentID = 
            sTD_Student.RowStatusID = 1;
            DataSet dsStudent = new DataSet();
            dsStudent = STD_StudentManager.InsertSTD_Student(sTD_Student);


            sTD_Student.StudentID = dsStudent.Tables[0].Rows[0]["StudentID"].ToString();
            sTD_Student.StudentCode = dsStudent.Tables[0].Rows[0]["StudentCode"].ToString();

            if (sTD_Student.StudentID != "")
            {
                //add to educational background to the db

                STD_Contact contact = new STD_Contact();

                contact.StudentID = sTD_Student.StudentID;
                contact.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
                contact.ModifiedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
                contact.ModifiedDate = DateTime.Now;
                contact.Name = student.Father_name;
                contact.Occupation = "";
                contact.OfficeAddress = "";
                contact.OfficeTel = "";
                contact.RowStatusID = 1;
                contact.CellNo = "";
                contact.ContactTypeID = 1;
                contact.AddedDate = DateTime.Now;
                STD_ContactManager.InsertSTD_Contact(contact);

            }

            sID++;

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        #endregion
    }
}