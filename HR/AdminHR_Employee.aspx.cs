using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

/// <summary>
/// 
/// </summary>
public partial class AdminHR_Employee : System.Web.UI.Page
{
    private static List<HR_PackageRules> _ListPackageRules = new List<HR_PackageRules>();
    static List<COMN_JobExperience> _jobExperienceColl = new List<COMN_JobExperience>();
    static List<HR_ChildrenInfo> _childrenInfoColl = new List<HR_ChildrenInfo>();

    static List<COMN_EducatinalBackground> _educationalBackgroundColl = new List<COMN_EducatinalBackground>();

    static List<HR_BenifitPackage> _benifitPackageColl = new List<HR_BenifitPackage>();
    
    //hfEmployeeID.Value = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfLoggedInUserID.Value = Profile.UserName;
            _ListPackageRules = new List<HR_PackageRules>();
            _jobExperienceColl = new List<COMN_JobExperience>();
            _childrenInfoColl = new List<HR_ChildrenInfo>();

            Session["_educationalBackgroundColl"]  = new List<COMN_EducatinalBackground>();
            
            _benifitPackageColl = new List<HR_BenifitPackage>();
            radIsGross.SelectedValue = "True";
            EmployeeTypeLoad();
            LoadDepartment();
            DesignationIDLoad();
            RankLoad();
            BloodGroupIDLoad();
            ReligionIDLoad();
            MaritualStatusIDLoad();
            NationalityIDLoad();
            //DepartmentIDLoad();
            //SupervisorIDLoad();
            FillAdjustmentList();
            SalaryTaxPackageIDLoad();
            //SalaryIncrementEmployeeIDLoad();
            //JobPostingDesignationIDLoad();
            LoadBenifitPackage();
            SalaryIncrementPackageIDLoad();
            OverTimePackIDLoad();
            LoadPackage();
            ProvidentfundPercentageLoad();

            btnAddContact.Visible = true;
            btnUpdateContacts.Visible = false;

            btnAddBank.Visible = true;
            btnUpdateBank.Visible = false;

            btnAddAttendenceRules.Visible = true;
            btnUpdateAttendenceRules.Visible = false;

            btnAddWorkingDaysShifting.Visible = true;
            btnUpdateWorkingDaysShifting.Visible = false;

            if (Request.QueryString["ID"] != null)
            {
                this.Page.Title = "Edit Employee";
                headerH3Name.InnerText = "Edit Employee";

                string ID = Request.QueryString["ID"].ToString();
                hfEmployeeID.Value = ID;
                hfEmployeeID.Value = ID;
                //_newAddedEmployeeID = ID;
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                ShowHREmployeeData();

                contenttab.Visible = true;
                divPersonalDoucument.Visible =true;

                showEmployeeScheduleGrid();

                
            }
            else
            {
                txtUserID.Text = HR_EmployeeManager.GetEmployeeNo();
                txtEmailAddress.Text = txtUserID.Text + "@cucedu.com";
                txtEmail.Text = txtUserID.Text + "@cucedu.com";
                contenttab.Visible = false;
                divPersonalDoucument.Visible = false;
            }
            txtUserID.ReadOnly = true;
        }
    }

    #region --------Private Methods-----------------------------------------------

    private void ShowHREmployeeData()
    {
        try
        {
            lblTmpMobile.Visible = false;
            lblTmpSalary.Visible = false;
            txtTmpMobile.Visible = false;
            txtTmpSalary.Visible = false;
            HR_Employee hR_Employee = new HR_Employee();
            hR_Employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeID(Request.QueryString["ID"]);
            txtEmployeeName.Text = hR_Employee.EmployeeName.ToString();
            txtEmailAddress.Text = hR_Employee.EmailAddress;
            txtUserID.Text = hR_Employee.EmployeeNo;
            ddlEmployeerType.SelectedValue = hR_Employee.EmployeeType.ToString();
            ddlDesignationID.SelectedValue = hR_Employee.DesignationID.ToString();
            ddlDepartment.SelectedValue = hR_Employee.DepartmentID.ToString();
            ddlRank.SelectedValue = hR_Employee.EmployeeRank; //HR_RankManager.GetHR_RankByRankID(Convert.ToInt32(hR_Employee.EmployeeRank)).RankID.ToString();
            txtFathersName.Text = hR_Employee.FathersName.ToString();
            txtMothersName.Text = hR_Employee.MothersName.ToString();
            txtSpouseName.Text = hR_Employee.SpouseName.ToString();
            txtDateOfBirth.Text = hR_Employee.DateOfBirth.ToString("dd MMM yyyy");
            txtPlaceOfBirth.Text = hR_Employee.PlaceOfBirth.ToString();
            ddlBloodGroupID.SelectedValue = hR_Employee.BloodGroupID.ToString();
            ddlGenderID.SelectedValue = hR_Employee.GenderID.ToString();
            ddlReligionID.SelectedValue = hR_Employee.ReligionID.ToString();
            ddlMaritualStatusID.SelectedValue = hR_Employee.MaritualStatusID.ToString();
            ddlNationalityID.SelectedValue = hR_Employee.NationalityID.ToString();
            if (hR_Employee.Photo.ToString() == "")
            {
               // imgEmployeerImage.ImageUrl = "~/App_Themes/CoffeyGreen/images/NoImage.jpg";
                imgEmployeerImage.ImageUrl = String.Format("~/App_Themes/CoffeyGreen/images/NoImage.jpg");
                
            }
            else
            {
                //imgEmployeerImage.ImageUrl = hR_Employee.Photo.ToString();
                hdnEmployeerImage.Value = hR_Employee.Photo.ToString();

                imgEmployeerImage.ImageUrl = String.Format("~/HR/upload/employeer/{0}", hR_Employee.Photo.ToString());
            }
            txtAddress.Text = hR_Employee.Address.ToString();
            txtJoiningDate.Text = hR_Employee.JoiningDate == DateTime.MinValue ? "" : hR_Employee.JoiningDate.ToString("dd MMM yyyy");
            txtNickName.Text = hR_Employee.ExtraField1;
            txtNickNameDetail.Text = hR_Employee.ExtraField2;
            radFlag.SelectedValue = hR_Employee.Flag == true ? "Active" : "Inactive";

            _jobExperienceColl = COMN_JobExperienceManager.GetCOMN_JobExperiencesByEmpUserID(hfEmployeeID.Value.ToString());
            gvHR_JobExperience.DataSource = _jobExperienceColl;
            gvHR_JobExperience.DataBind();


            _childrenInfoColl = HR_ChildrenInfoManager.GetHR_ChildrenInfosByEmployeeID(hfEmployeeID.Value.ToString());
            gvHR_ChildrenInfo.DataSource = _childrenInfoColl;
            gvHR_ChildrenInfo.DataBind();

            Session["_educationalBackgroundColl"] = COMN_EducatinalBackgroundManager.GetCOMN_EducatinalBackgroundsByEmpUserID(hfEmployeeID.Value.ToString());
            gv_educationalBackground.DataSource = (List<COMN_EducatinalBackground>)Session["_educationalBackgroundColl"];
            gv_educationalBackground.DataBind();

            RefreshContact();
            btnAddContact.Visible = false;
            btnUpdateContacts.Visible = true;

            RefreshBankAccount();
            btnAddBank.Visible = false;
            btnUpdateBank.Visible = true;

            RefreshAttendenceRules();
            btnAddAttendenceRules.Visible = false;
            btnUpdateAttendenceRules.Visible = true;

            RefreshWorkingDaysShifting();
            btnAddWorkingDaysShifting.Visible = false;
            btnUpdateWorkingDaysShifting.Visible = true;

            RefreshEmployeeSalary();
            btnSaveEmployeeSalary.Visible = false;
            btnUpdateEmployeeSalary.Visible = true;

            RefreshProvidentFundddl();
            btnAddProvidenedFund.Visible = false;
            btnUpdateProvidenedFund.Visible = true;

            RefreshBenefitPackageRules();

            RefreshLunchRuleControl();

            RefreshSalaryTaxPackage();

            RefreshSalaryAdjustmentListRules();

           
        }
        catch (Exception ex)
        {

        }
    }

    private string UpLoadCompanyEmployeerPicture(FileUpload fl, string employeerID)
    {
        string dirUrl = "../HR/upload/employeer/";
        string temp_dirUrl = "../HR/upload/temp/";
        string dirPath = Server.MapPath(dirUrl);
        string temp_filePath = Server.MapPath(temp_dirUrl);
        string filename = "";
        if (fl.HasFile)
        {
            SmartDataSoft.ImageResize imge_resize = new SmartDataSoft.ImageResize();
            filename = imge_resize.ResizedImage(temp_filePath, dirPath, fl, 100, employeerID);
        }
        return filename;
    }

    #region ------------------ Load Methods----------------------------------------------

    private void EmployeeTypeLoad()
    {
        DataSet ds = HR_EmployerTypeManager.GetDropDownListAllHR_EmployerType();
        ddlEmployeerType.DataValueField = "EmployerType";
        ddlEmployeerType.DataTextField = "EmployerTypeName";
        ddlEmployeerType.DataSource = ds.Tables[0];
        ddlEmployeerType.DataBind();
        //ddlEmployeerType.Items.Insert(0, new ListItem("Select Employee Type >>", "0"));
    }

    private void LoadDepartment()
    {
        DataSet allDepartment = HR_DepartmentManager.GetDropDownListAllHR_Department();
        ddlDepartment.DataValueField = "DepartmentID";
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataSource = allDepartment.Tables[0];
        ddlDepartment.DataBind();
        //ddlDepartment.Items.Insert(0, new ListItem("All Department >>", "0"));
        ddlDepartment.SelectedIndex = 1;
    }

    private void DesignationIDLoad()
    {
        try
        {
            DataSet ds = HR_DesignationManager.GetDropDownListAllHR_Designation();
            ddlDesignationID.DataValueField = "DesignationID";
            ddlDesignationID.DataTextField = "DesignationName";
            ddlDesignationID.DataSource = ds.Tables[0];
            ddlDesignationID.DataBind();
            //ddlDesignationID.Items.Insert(0, new ListItem("Select Designation >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void DesignationIDLoad(int departmentNo)
    {
        try
        {
            DataSet ds = HR_DesignationManager.GetHR_DesignationByDepartmentID(departmentNo);
            ddlDesignationID.DataValueField = "DesignationID";
            ddlDesignationID.DataTextField = "DesignationName";
            ddlDesignationID.DataSource = ds.Tables[0];
            ddlDesignationID.DataBind();
            //ddlDesignationID.Items.Insert(0, new ListItem("All Designation >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void RankLoad()
    {
       try
        {
            DataSet ds = HR_RankManager.GetDropDownListAllHR_Rank();
            ddlRank.DataValueField = "RankID";
            ddlRank.DataTextField = "RankName";
            ddlRank.DataSource = ds.Tables[0];
            ddlRank.DataBind();
           // ddlRank.Items.Insert(0, new ListItem("Select Rank >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void BloodGroupIDLoad()
    {
        try
        {
            DataSet ds = COMN_BloodGroupManager.GetDropDownListAllHR_BloodGroup();
            ddlBloodGroupID.DataValueField = "BloodGroupID";
            ddlBloodGroupID.DataTextField = "BloodGroupName";
            ddlBloodGroupID.DataSource = ds.Tables[0];
            ddlBloodGroupID.DataBind();
            //ddlBloodGroupID.Items.Insert(0, new ListItem("Select BloodGroup >>", "0"));
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
            DataSet ds = COMN_ReligionManager.GetDropDownListAllHR_Religion();
            ddlReligionID.DataValueField = "ReligionID";
            ddlReligionID.DataTextField = "ReligionName";
            ddlReligionID.DataSource = ds.Tables[0];
            ddlReligionID.DataBind();
            //ddlReligionID.Items.Insert(0, new ListItem("Select Religion >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void MaritualStatusIDLoad()
    {
        try
        {
            DataSet ds = COMN_MaritualStatusManager.GetDropDownListAllHR_MaritualStatus();
            ddlMaritualStatusID.DataValueField = "MaritualStatusID";
            ddlMaritualStatusID.DataTextField = "MaritualStatusName";
            ddlMaritualStatusID.DataSource = ds.Tables[0];
            ddlMaritualStatusID.DataBind();
            //ddlMaritualStatusID.Items.Insert(0, new ListItem("Select MaritalStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void NationalityIDLoad()
    {
        try
        {
            DataSet ds = COMN_NationalityManager.GetDropDownListAllHR_Nationality();
            ddlNationalityID.DataValueField = "NationalityID";
            ddlNationalityID.DataTextField = "NationalityName";
            ddlNationalityID.DataSource = ds.Tables[0];
            ddlNationalityID.DataBind();
            //ddlNationalityID.Items.Insert(0, new ListItem("Select Nationality >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void ProvidentfundPercentageLoad()
    {
        ddlProvidentfundPercentage.DataTextField = "Value";
        ddlProvidentfundPercentage.DataValueField = "ProvidentfundRulesID";
        ddlProvidentfundPercentage.DataSource = HR_ProvidentfundRulesManager.GetAllHR_ProvidentfundRuless();
        ddlProvidentfundPercentage.DataBind();
        ddlProvidentfundPercentage.Items.Insert(0, new ListItem("Select Package >>", "0"));
    }

    private bool IsDuplicateChildName(string name)
    {
        List<HR_ChildrenInfo> childs = HR_ChildrenInfoManager.GetHR_ChildrenInfosByEmployeeID(hfEmployeeID.Value.ToString());
        foreach (HR_ChildrenInfo child in childs)
        {
            if (child.ChildrenInfoName.ToString().Trim() == name)
                return true;
        }
        return false;
    }

    public void LoadPackage()
    {
        try
        {
            DataSet ds = HR_PackageManager.GetDropDownListAllHR_Package();
            ddlPackage.DataValueField = "PackageID";
            ddlPackage.DataTextField = "PackageName";
            ddlPackage.DataSource = ds.Tables[0];
            ddlPackage.DataBind();
            ddlPackage.Items.Insert(0, new ListItem("Select Package >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    public void LoadBenifitPackage()
    {
        try
        {
            DataSet ds = HR_BenifitPackageManager.GetAllHR_BenifitPackages();
            ddlBenifitPackage.DataValueField = "BenifitPackageID";
            ddlBenifitPackage.DataTextField = "BenifitPackageName";
            ddlBenifitPackage.DataSource = ds.Tables[0];
            ddlBenifitPackage.DataBind();
            ddlBenifitPackage.Items.Insert(0, new ListItem("Select Package  Rules>>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void SalaryTaxPackageIDLoad()
    {
        try
        {
            DataSet ds = HR_SalaryTaxPackageManager.GetDropDownListAllHR_SalaryTaxPackage();
            ddlSalaryTaxPackageID.DataValueField = "SalaryTaxPackagePackageID";
            ddlSalaryTaxPackageID.DataTextField = "SalaryTaxPackagePackageName";
            ddlSalaryTaxPackageID.DataSource = ds.Tables[0];
            ddlSalaryTaxPackageID.DataBind();
            ddlSalaryTaxPackageID.Items.Insert(0, new ListItem("Select SalaryTaxPackage >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void SalaryIncrementPackageIDLoad()
    {
        try
        {
            DataSet ds = HR_SalaryIncrementPackageManager.GetDropDownListAllHR_SalaryIncrementPackage();
            ddlSalaryIncrementPackageID.DataValueField = "SalaryIncrementPackageID";
            ddlSalaryIncrementPackageID.DataTextField = "SalaryIncrementPackageName";
            ddlSalaryIncrementPackageID.DataSource = ds.Tables[0];
            ddlSalaryIncrementPackageID.DataBind();
            ddlSalaryIncrementPackageID.Items.Insert(0, new ListItem("Select SalaryIncrementPackage >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void OverTimePackIDLoad()
    {
        try
        {
            DataSet ds = HR_OverTimePackageManager.GetDropDownListAllHR_OverTimePackage();
            ddlOverTimePackID.DataValueField = "OverTimePackageID";
            ddlOverTimePackID.DataTextField = "OverTimePackageName";
            ddlOverTimePackID.DataSource = ds.Tables[0];
            ddlOverTimePackID.DataBind();
            ddlOverTimePackID.Items.Insert(0, new ListItem("Select Over Time Package >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

   #endregion ------------------ Load Methods----------------------------------------------

    #region ------------Refresh Control--------------------------------------------------

    private void RefreshPackageRelues()
    {
        _ListPackageRules = new List<HR_PackageRules>();
        if (radSalaryRules.SelectedValue == "True")
        {
            for (int rowCounter = 0; rowCounter < gridViewPackageAndPackageRules.Rows.Count; rowCounter++)
            {
                CheckBox checkBox = (CheckBox)gridViewPackageAndPackageRules.Rows[rowCounter].FindControl("chkPackageRulesID");
                if (checkBox.Checked)
                {
                    HR_PackageRules packageRule = new HR_PackageRules();

                    packageRule = HR_PackageRulesManager.GetHR_PackageRulesByPackageRulesID(int.Parse(((Label)gridViewPackageAndPackageRules.Rows[rowCounter].FindControl("lblPackageRulesID")).Text));
                    packageRule.PackageRulesID = packageRule.PackageRulesID;
                    packageRule.PackageRulesName = packageRule.PackageRulesName;
                    packageRule.RulesValue = packageRule.RulesValue;
                    packageRule.RulesOperator = packageRule.RulesOperator;

                    _ListPackageRules.Add(packageRule);
                }
            }
        }
        else
        {
            for (int rowCounter = 0; rowCounter < gvHR_PackageRules.Rows.Count; rowCounter++)
            {
                HR_PackageRules packageRule = new HR_PackageRules();
                packageRule = HR_PackageRulesManager.GetHR_PackageRulesByPackageRulesID(int.Parse(((Label)gvHR_PackageRules.Rows[rowCounter].FindControl("lblPackageRulesID")).Text));
                packageRule.PackageRulesID = packageRule.PackageRulesID;
                packageRule.PackageRulesName = packageRule.PackageRulesName;
                packageRule.RulesValue = packageRule.RulesValue;
                packageRule.RulesOperator = packageRule.RulesOperator;

                _ListPackageRules.Add(packageRule);
            }
        }
    }

    private void FillAdjustmentList()
    {
        ddlAdjustmentGroup.DataTextField = "GroupName";
        ddlAdjustmentGroup.DataValueField = "SalaryAdjustmentGroupID";
        ddlAdjustmentGroup.DataSource = HR_SalaryAdjustmentGroupManager.GetDropDownListAllHR_SalaryAdjustment();
        ddlAdjustmentGroup.DataBind();
        ddlAdjustmentGroup.Items.Insert(0, new ListItem("Select Group Name >>", "0"));
    }

    private void RefreshContact()
    {
        HR_Contact hR_Contact = new HR_Contact();
        hR_Contact = HR_ContactManager.GetHR_ContactObjectByEmployeeID(hfEmployeeID.Value.ToString());
        if (hR_Contact != null)
        {
            hdnContactsID.Value = hR_Contact.ContactID.ToString();
            txtCurrentAddress.Text = hR_Contact.CurrentAddress;
            txtPermanentAddress.Text = hR_Contact.PermanentAddress;
            txtTelephone.Text = hR_Contact.Telephone;
            txtMobile.Text = hR_Contact.Mobile;
            txtEmail.Text = hR_Contact.Email;
        }
    }

    private void RefreshBankAccount()
    {
        HR_BankAccount hR_Bank = new HR_BankAccount();
        hR_Bank = HR_BankAccountManager.GetHR_BankAccountByEmployeeID(hfEmployeeID.Value.ToString());
        if (hR_Bank != null)
        {
            hdnBankID.Value = hR_Bank.BankAccountNoID.ToString();
            txtBankAccountName.Text = hR_Bank.AccountName;
            txtBankAccountNo.Text = hR_Bank.AccountNo;
            txtBankName.Text = hR_Bank.BankName;
            txtBankAddress.Text = hR_Bank.BankAddress;
            txtBankTelephone.Text = hR_Bank.ContactPerson;
        }
    }

    private void RefreshAttendenceRules()
    {
        HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules();
        hR_AttendenceRules = HR_AttendenceRulesManager.GetHR_AttendenceRulesObjectByEmployeeID(hfEmployeeID.Value.ToString());
        if (hR_AttendenceRules != null)
        {
            hdnAttendanceRulesID.Value = hR_AttendenceRules.AttendenceRulesID.ToString();
            txtRules.Text = hR_AttendenceRules.Rules;
            ddlTime.SelectedValue = hR_AttendenceRules.Time.ToString();
            //hR_AttendenceRules.Unit = "Min";
        }
    }

    private void RefreshWorkingDaysShifting()
    {
        HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting();
        hR_WorkingDaysShifting = HR_WorkingDaysShiftingManager.GetHR_WorkingDaysShiftingObjectByEmployeeID(hfEmployeeID.Value.ToString());
        if (hR_WorkingDaysShifting != null)
        {
            hdnWorkingDaysShiftingID.Value = hR_WorkingDaysShifting.WorkingDaysID.ToString();
            chkSaturday.Checked = hR_WorkingDaysShifting.Saturday;
            chkSunday.Checked = hR_WorkingDaysShifting.Sunday;
            chkMonday.Checked = hR_WorkingDaysShifting.Monday;
            chkTuesday.Checked = hR_WorkingDaysShifting.Tuesday;
            chkWednesday.Checked = hR_WorkingDaysShifting.Wednesday;
            chkThrusday.Checked = hR_WorkingDaysShifting.Thrusday;
            chkFriday.Checked = hR_WorkingDaysShifting.Friday;

            string startingHour = hR_WorkingDaysShifting.ShiftStartTime.Hour.ToString();
            ddltime_hoursStart.SelectedValue = startingHour.Length == 1 ? "0" + startingHour : startingHour;
            string startingMinute = hR_WorkingDaysShifting.ShiftStartTime.Minute.ToString();
            ddltime_minstart.SelectedValue = startingMinute.Length == 1 ? "0" + startingMinute : startingMinute;

            string endingHour = hR_WorkingDaysShifting.ShiftEndTime.Hour.ToString();
            ddltime_hoursEnd.SelectedValue = endingHour.Length == 1 ? "0" + endingHour : endingHour;
            string endingMinute = hR_WorkingDaysShifting.ShiftEndTime.Minute.ToString();
            ddltime_minEnd.SelectedValue = endingMinute.Length == 1 ? "0" + endingMinute : endingMinute;
            txtDescription.Text = hR_WorkingDaysShifting.Description;
        }
    }

    private void RefreshEmployeeSalary()
    {
        HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(hfEmployeeID.Value.ToString());
        if (employeeSalary != null)
        {
            hdnEmployeeSalaryID.Value = employeeSalary.EmployeeSalaryID.ToString();
            radIsGross.SelectedValue = employeeSalary.IsGross == true ? "Gross" : "Basic";

            if (employeeSalary.IsGross)
            {
                txtAmount.Text = employeeSalary.GrossAmount.ToString();
            }
            else
            {
                txtAmount.Text = employeeSalary.BasicAmount.ToString();
            }
            radSalaryRules.SelectedValue = "False";
            ddlPackage.Visible = true;
            DataSet employeeSalaryRulesDataSet = HR_EmployeeSalaryRulesManager.GetHR_EmployeeSalaryRulesByEmployeeID(hfEmployeeID.Value.ToString());
            List<HR_PackageRules> packageRulesColl = new List<HR_PackageRules>();
            if (employeeSalaryRulesDataSet.Tables.Count > 0)
            {
                foreach (DataRow row in employeeSalaryRulesDataSet.Tables[0].Rows)
                {
                    HR_PackageRules packageRules = HR_PackageRulesManager.GetHR_PackageRulesByPackageRulesID(Convert.ToInt32(row["PackageRulesID"]));
                    HR_Package package = HR_PackageManager.GetHR_PackageByPackageID(Convert.ToInt32(row["PackageID"]));
                    ddlPackage.SelectedValue = package.PackageID.ToString();
                    packageRulesColl.Add(packageRules);
                }
            }
            gvHR_PackageRules.DataSource = packageRulesColl;
            gvHR_PackageRules.DataBind();
        }
    }

    private void RefreshProvidentFundddl()
    {
        HR_ProvidentfundContribution providentfundContribution = HR_ProvidentfundContributionManager.GetHR_ProvidentfundContributionByEmployeeID(hfEmployeeID.Value.ToString());
        txtSecurityMoney.Text = providentfundContribution.Amount.ToString("0,0");
        if (providentfundContribution != null)
        {
            hdnProvidentFundContributionID.Value = providentfundContribution.ProvidentfundContributionID.ToString();
            HR_ProvidentfundRules providentfundRules = HR_ProvidentfundRulesManager.GetHR_ProvidentfundRulesByProvidentfundRulesID(providentfundContribution.ProvidentfundRulesID);
            if (providentfundRules != null)
            {
                ddlProvidentfundPercentage.SelectedValue = providentfundRules.ProvidentfundRulesID.ToString();
            }
        }
    }

    private void RefreshBenefitPackageRules()
    {
        DataSet benifitPackageRules = HR_BenifitPackageRulesManager.GetAllHR_BenifitPackageRulesByEmployeeID(hfEmployeeID.Value.ToString());
        
        if (benifitPackageRules.Tables[0]!= null)
        {
            foreach (DataRow row in benifitPackageRules.Tables[0].Rows)
            {
                HR_BenifitPackage benifitPackage = HR_BenifitPackageManager.GetHR_BenifitPackageByBenifitPackageID(Convert.ToInt32(row["BenifitPackageID"]));
                _benifitPackageColl.Add(benifitPackage);
            }
        }
        gvHR_BenefitPackage.DataSource = _benifitPackageColl;
        gvHR_BenefitPackage.DataBind();
    }

    private void RefreshSalaryTaxPackage()
    {
        HR_SalaryTaxPackageRules salaryTaxPackageRules = new HR_SalaryTaxPackageRules();
        salaryTaxPackageRules = HR_SalaryTaxPackageRulesManager.GetHR_SalaryTaxPackageRulesByEmployeeID(hfEmployeeID.Value.ToString());

        ddlSalaryTaxPackageID.SelectedValue = salaryTaxPackageRules.SalaryTaxPackageID.ToString();
        List<HR_SalaryTaxPackage> salaryTaxPackageList = new List<HR_SalaryTaxPackage>();
        HR_SalaryTaxPackage salaryTaxPackage = HR_SalaryTaxPackageManager.GetHR_SalaryTaxPackageBySalaryTaxPackagePackageID(salaryTaxPackageRules.SalaryTaxPackageID);
        salaryTaxPackageList.Add(salaryTaxPackage);
        gvHR_SalaryTaxPackage.DataSource = salaryTaxPackageList;
        gvHR_SalaryTaxPackage.DataBind();
    }

    private void RefreshSalaryAdjustmentListRules()
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = new HR_SalaryAdjustmentListRules();
        salaryAdjustmentListRules = HR_SalaryAdjustmentListRulesManager.GetSalaryAdjustmentListRulesOnlyByEmployeeID(hfEmployeeID.Value.ToString());
        if (salaryAdjustmentListRules != null)
        {
            ddlAdjustmentGroup.SelectedValue = salaryAdjustmentListRules.SalaryAdjustmentGroupID.ToString();

            gvHR_AdjustmentList.DataSource = HR_SalaryAdjustmentListManager.GetSalaryAdjustmentListBySalaryAdjustmenGroupID(Convert.ToInt32(ddlAdjustmentGroup.SelectedValue));
            gvHR_AdjustmentList.DataBind();
        }
    }

    private void RefreshLunchRuleControl()
    {
        HR_LunchRule lunchRule = HR_LunchRuleManager.GetHR_LunchRuleByEmployeeID(hfEmployeeID.Value.ToString());
        if (lunchRule != null)
        {
            hdnLunchRuleID.Value = lunchRule.LunchRuleID.ToString();
            string startingHour = lunchRule.LunchTimeStart.Hour.ToString();
            ddlLunchTimeStartHour.SelectedValue = startingHour.Length == 1 ? "0" + startingHour : startingHour;
            string startingMinute = lunchRule.LunchTimeStart.Minute.ToString();
            ddlLunchTimeStartMinute.SelectedValue = startingMinute.Length == 1 ? "0" + startingMinute : startingMinute;

            string endingHour = lunchRule.LunchTimeEnd.Hour.ToString();
            ddlLunchTimeEndHour.SelectedValue = endingHour.Length == 1 ? "0" + endingHour : endingHour;
            string endingMinute = lunchRule.LunchTimeEnd.Minute.ToString();
            ddlLunchTimeEndMinute.SelectedValue = endingMinute.Length == 1 ? "0" + endingMinute : endingMinute;

            string flexibleTime = lunchRule.LunchFlexibleTimeMins.ToString();
            ddlLunchFlexibleTimeMins.SelectedValue = flexibleTime.Length == 1 ? "0" + flexibleTime : flexibleTime;
            radLunchFlag.SelectedValue = lunchRule.LunchFlag == true ? "True" : "False";
        }
    }

    #endregion------Refresh Control-------------------------------------------------------------

    #endregion -----------Private Methods-------------------------------------------------------

    #region ------------------ Events-----------------------------------------------------------


    protected void fileEmployerPhoto_OnPreRender(object sender, EventArgs e)
    {

    }

    protected void ddlDepartment_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlDepartment.SelectedValue) > 0)
        {
            DesignationIDLoad(Convert.ToInt32(ddlDepartment.SelectedValue));
        }
        else
        {
            DesignationIDLoad();
        }
    }

    protected void showImage_OnClick(object sender, EventArgs e)
    {
        //if (fileEmployerPhoto.HasFile)
        //{
        //    string employeerPhoto = UpLoadCompanyEmployeerPicture(fileEmployerPhoto, "showPicture");

        //    imgEmployeerImage.ImageUrl = String.Format("~/HR/upload/employeer/showPicture.Jpeg");
        //    hdnEmployeerImage.Value = "showPicture.Jpeg";
        //}
        //else
        //{
        //    imgEmployeerImage.ImageUrl = String.Format("~/App_Themes/CoffeyGreen/images/NoImage.jpg");
        //}
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        divPersonalDoucument.Visible = true;
        contenttab.Visible = true;
        btnUpdate.Visible = true;
        btnAdd.Visible = false;

        lblError.ForeColor = System.Drawing.Color.Red;
        var employeerPhoto = string.Empty;
        var employeerID = "";
        MembershipCreateStatus result;
        try
        {
            txtUserID.Text = HR_EmployeeManager.GetEmployeeNo();
            if (txtEmailAddress.Text.Trim() == string.Empty)
            {
                txtEmailAddress.Text = txtUserID.Text + "@cucedu.com";
                txtEmail.Text = txtUserID.Text + "@cucedu.com";
            }
            Membership.DeleteUser(txtUserID.Text.Trim().ToString());
            Membership.CreateUser(txtUserID.Text.ToString(), "123456", txtEmailAddress.Text, "a", "a", true, out result);

            switch (result)
            {
                case MembershipCreateStatus.Success:

                    FormsAuthentication.SetAuthCookie(txtUserID.Text.ToString(), true);

                    var role = "hr";
                    //if (rbUserType.SelectedItem.Value.ToString() == "1")
                    //{

                    MembershipUser myObject = Membership.GetUser(txtUserID.Text.Trim());
                    employeerID = myObject.ProviderUserKey.ToString();
                    hfEmployeeID.Value = employeerID;
                    //Roles.AddUserToRole(txtUserID.Text.ToString(), "hr");
                    txtUserID.Enabled = false;
                    txtEmailAddress.Enabled = false;
                    ////Roles.AddUserToRole(UserName.Text, "Student");
                    //Response.Redirect("StudentsProfilePage.aspx?&usertype=" + rbUserType.SelectedItem.Value.ToString());
                    //}

                    //if (rbUserType.SelectedItem.Value.ToString() == "2")
                    //{
                    //Roles.AddUserToRole(UserName.Text, "Teacher");
                    //Response.Redirect("TeachersProfilePage.aspx?&usertype=" + rbUserType.SelectedItem.Value.ToString());
                    //}

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
            //lblError.Text = ex.Message.ToString();
        }

        if (result != MembershipCreateStatus.Success)
        {
            return;
        }

        if (Session["imagePath"] != null)
        {
            try
            {
                string dirUrl = "upload/employeer/";
                string dirPath = Server.MapPath(dirUrl);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string picPath = Session["imagePath"].ToString();
                Session.Remove("imagePath");
                string[] st = picPath.ToString().Split('.');
                string st_pic = st[1];
                string fileName = employeerID + "." + st_pic;
                string fileUrl = dirUrl + "/" + fileName;

                System.Drawing.Image stImage = System.Drawing.Image.FromFile(picPath);
                stImage.Save(Server.MapPath(fileUrl));

                employeerPhoto = fileName;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        else
        {
            if (fileEmployerPhoto.HasFile)
            {
                employeerPhoto = UpLoadCompanyEmployeerPicture(fileEmployerPhoto, employeerID);
                string locationOfImage = Server.MapPath(fileEmployerPhoto.FileName);
                imgEmployeerImage.ImageUrl = String.Format(locationOfImage);
            }
            else
            {
                employeerPhoto = "upload/employeer/NoImage.jpg";
            }
        }
        
        //else
        //{
        //    string dirPathOnly= String.Format("~/HR/upload/employeer/");
        //    string dirPathWithName = String.Format("~/HR/upload/employeer/showPicture.Jpeg");
        //    System.IO.FileInfo file;
        //    file = new System.IO.FileInfo(dirPathWithName);
        //    if (file.Exists)
        //    {
        //        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(dirPathOnly + hdnEmployeerImage.Value);

        //        originalImage.Save(dirPathOnly + employeerID, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        employeerPhoto = employeerID + ".Jpeg";
        //        file.Delete();
        //    }
        //}

        //load The loggedin user
        FormsAuthentication.SetAuthCookie(hfLoggedInUserID.Value, true);
        MembershipUser myObjectLoggedInUser = Membership.GetUser(hfLoggedInUserID.Value);


        HR_Employee hR_Employee = new HR_Employee();
        hR_Employee.EmployeeID = employeerID;
        hR_Employee.EmployeeName = txtEmployeeName.Text;
        hR_Employee.EmployeeNo = txtUserID.Text.Trim();
        hR_Employee.EmailAddress = txtEmailAddress.Text.Trim();
        hR_Employee.EmployeeType = ddlEmployeerType.SelectedValue;
        hR_Employee.DesignationID = int.Parse(ddlDesignationID.SelectedValue);
        hR_Employee.EmployeeRank = ddlRank.SelectedValue.ToString();
        hR_Employee.FathersName = txtFathersName.Text;
        hR_Employee.MothersName = txtMothersName.Text;
        hR_Employee.SpouseName = txtSpouseName.Text;
        hR_Employee.DateOfBirth = (txtDateOfBirth.Text =="" ?DateTime.Today.AddYears(-20):DateTime.Parse(txtDateOfBirth.Text));
        hR_Employee.PlaceOfBirth = txtPlaceOfBirth.Text;
        hR_Employee.BloodGroupID = Int16.Parse(ddlBloodGroupID.SelectedValue);
        hR_Employee.GenderID = ddlGenderID.SelectedValue;
        hR_Employee.ReligionID = int.Parse(ddlReligionID.SelectedValue);
        hR_Employee.MaritualStatusID = Int16.Parse(ddlMaritualStatusID.SelectedValue);
        hR_Employee.NationalityID = int.Parse(ddlNationalityID.SelectedValue);
        hR_Employee.Photo = employeerPhoto;
        hR_Employee.Address = txtAddress.Text;
        hR_Employee.JoiningDate = txtJoiningDate.Text == null ? DateTime.MinValue : Convert.ToDateTime(txtJoiningDate.Text.Trim());
        hR_Employee.ExtraField1 = txtNickName.Text.Trim();
        hR_Employee.ExtraField2 = txtNickNameDetail.Text.Trim();
        hR_Employee.Flag = radFlag.SelectedValue == "Active" ? true : false;



        //if (Session["userID"] ==null)
        //{
        //    FormsAuthentication.SignOut();
        //}
        string userID = Profile.card_id;
       // if(userID!= string.Empty)
        hR_Employee.AddedBy = userID;
        hR_Employee.AddedDate = DateTime.Now;
        hR_Employee.ModifiedBy = userID;
        hR_Employee.ModifiedDate = DateTime.Now;
        int resutl = HR_EmployeeManager.InsertHR_Employee(hR_Employee);
        hfEmployeeID.Value = employeerID;
        
        autoAddedInfo();
        
        if (hR_Employee.Photo.ToString() == "")
        {
            imgEmployeerImage.ImageUrl = String.Format("~/App_Themes/CoffeyGreen/images/NoImage.jpg");
        }
        else
        {
            hdnEmployeerImage.Value = hR_Employee.Photo.ToString();
            imgEmployeerImage.ImageUrl = String.Format("~/HR/upload/employeer/{0}", hR_Employee.Photo.ToString());
        }
    }
    private void autoAddedInfo()
    {
        if (txtTmpSalary.Text != "" && decimal.Parse(txtTmpSalary.Text) != 0)
        {
            radIsGross.SelectedValue = "Gross";
            txtAmount.Text = txtTmpSalary.Text;
            radSalaryRules.SelectedValue = "False";
            radSalaryRules_SelectedIndexChanged(this, new EventArgs());
            ddlPackage.SelectedIndex = 1;
            ddlPackage_SelectedIndexChanged(this, new EventArgs());
            btnSaveEmployeeSalary_Click(this, new EventArgs());

            ddlProvidentfundPercentage.SelectedIndex = 1;
            btnAddProvidenedFund_Click(this, new EventArgs());
        }

        txtMobile.Text = txtTmpMobile.Text;
        btnAddContact_Click(this, new EventArgs());
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        var employeerPhoto = string.Empty;
        var employeerID = hfEmployeeID.Value.ToString();

        //Membership membership = membership. //.GetUser(txtUserID.Text.Trim());
        //Membership.UpdateUser() //.CreateUser(txtUserID.Text.ToString(), "123456", txtEmailAddress.Text, "a", "a", true, out result);

        if (Session["imagePath"] != null)
        {
            try
            {
                string dirUrl = "upload/employeer/";
                string dirPath = Server.MapPath(dirUrl);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string picPath = Session["imagePath"].ToString();

                string[] st = picPath.ToString().Split('.');
                string st_pic = st[1];
                string fileName = employeerID + "." + st_pic;
                string fileUrl = dirUrl + "/" + fileName;

                System.Drawing.Image stImage = System.Drawing.Image.FromFile(picPath);
                stImage.Save(Server.MapPath(fileUrl));

                employeerPhoto = fileName;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        else
        {
            if (fileEmployerPhoto.HasFile)
            {
                employeerPhoto = UpLoadCompanyEmployeerPicture(fileEmployerPhoto, employeerID);
            }
        }
        //else
        //{
        //    string dirPathOnly = String.Format("~/HR/upload/employeer/");
        //    dirPathOnly = Server.MapPath(dirPathOnly);
        //    string dirPathWithName = String.Format("~/HR/upload/employeer/showPicture.Jpeg");
        //    dirPathWithName = Server.MapPath(dirPathWithName);
        //    System.IO.FileInfo file;
        //    file = new System.IO.FileInfo(dirPathWithName);
        //    if (file.Exists)
        //    {
        //        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(dirPathOnly + hdnEmployeerImage.Value);

        //        originalImage.Save(dirPathOnly + employeerID, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        employeerPhoto = employeerID + ".Jpeg";
        //    }
        //}
        HR_Employee hR_Employee = new HR_Employee();
        hR_Employee.EmployeeID = Request.QueryString["ID"].ToString();
        hR_Employee.EmployeeName = txtEmployeeName.Text;
        hR_Employee.EmployeeNo = txtUserID.Text.Trim();
        hR_Employee.EmailAddress = txtEmailAddress.Text.Trim();
        hR_Employee.EmployeeType = ddlEmployeerType.SelectedValue;
        hR_Employee.DesignationID = int.Parse(ddlDesignationID.SelectedValue);
        hR_Employee.EmployeeRank = ddlRank.SelectedValue.ToString();
        hR_Employee.FathersName = txtFathersName.Text;
        hR_Employee.MothersName = txtMothersName.Text;
        hR_Employee.SpouseName = txtSpouseName.Text;
        hR_Employee.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);
        hR_Employee.PlaceOfBirth = txtPlaceOfBirth.Text;
        hR_Employee.BloodGroupID = Int16.Parse(ddlBloodGroupID.SelectedValue);
        hR_Employee.GenderID = ddlGenderID.SelectedValue;
        hR_Employee.ReligionID = int.Parse(ddlReligionID.SelectedValue);
        hR_Employee.MaritualStatusID = Int16.Parse(ddlMaritualStatusID.SelectedValue);
        hR_Employee.NationalityID = int.Parse(ddlNationalityID.SelectedValue);
        if (employeerPhoto != string.Empty)
        {
            hR_Employee.Photo = employeerPhoto;
        }
        else
        {
            hR_Employee.Photo = hdnEmployeerImage.Value;
        }
        hR_Employee.Address = txtAddress.Text;
        hR_Employee.JoiningDate = txtJoiningDate.Text == null ? DateTime.MinValue : Convert.ToDateTime(txtJoiningDate.Text.Trim());
        hR_Employee.ExtraField1 = txtNickName.Text.Trim();
        hR_Employee.ExtraField2 = txtNickNameDetail.Text.Trim();
        hR_Employee.Flag = radFlag.SelectedValue == "Active" ? true : false;//

        string userID = Profile.card_id;

        hR_Employee.AddedBy = userID;
        hR_Employee.AddedDate = DateTime.Now;
        hR_Employee.ModifiedBy = userID;
        hR_Employee.ModifiedDate = DateTime.Now;
        bool resutl = HR_EmployeeManager.UpdateHR_Employee(hR_Employee);
        lblError.Text = "Employee information is updated successfully.";
        lblError.ForeColor = System.Drawing.Color.Green;

        if (hR_Employee.Photo.ToString() == "")
        {
            imgEmployeerImage.ImageUrl = String.Format("~/App_Themes/CoffeyGreen/images/NoImage.jpg");
        }
        else
        {
            hdnEmployeerImage.Value = hR_Employee.Photo.ToString();
            imgEmployeerImage.ImageUrl = String.Format("~/HR/upload/employeer/{0}", hR_Employee.Photo.ToString());
        }
    }

    protected void btnAddContact_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {

            HR_Contact hR_Contact = new HR_Contact();
            //	hR_Contact.ContactID=  int.Parse(ddlContactID.SelectedValue);
            hR_Contact.EmployeeID = hfEmployeeID.Value.ToString();
            hR_Contact.CurrentAddress = txtCurrentAddress.Text;
            hR_Contact.PermanentAddress = txtPermanentAddress.Text;
            hR_Contact.Telephone = txtTelephone.Text;
            hR_Contact.Mobile = txtMobile.Text;
            hR_Contact.Email = txtEmail.Text;

            string userID = Profile.card_id;

            hR_Contact.AddedBy = userID;
            hR_Contact.AddedDate = DateTime.Now;
            hR_Contact.ModifiedBy = userID;
            hR_Contact.ModifiedDate = DateTime.Now;
            int resutl = HR_ContactManager.InsertHR_Contact(hR_Contact);
            hdnContactsID.Value = resutl.ToString();
            //Response.Redirect("AdminDisplayHR_Contact.aspx");

            lblContactMsg.Text = "Contact Information is saved successfully";
            lblContactMsg.ForeColor = System.Drawing.Color.Green;

        }
        else
        {
            lblContactMsg.Text = "Employee is not specified.";
            lblContactMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnUpdateContacts_click(object sender, EventArgs e)
    {
        HR_Contact hR_Contact = new HR_Contact();
        //hR_Contact.ContactID = int.Parse(hdnContactsID.Value);
        hR_Contact.EmployeeID = hfEmployeeID.Value.ToString();
        hR_Contact.CurrentAddress = txtCurrentAddress.Text;
        hR_Contact.PermanentAddress = txtPermanentAddress.Text;
        hR_Contact.Telephone = txtTelephone.Text;
        hR_Contact.Mobile = txtMobile.Text;
        hR_Contact.Email = txtEmail.Text;
        string userID = Profile.card_id;
        hR_Contact.AddedBy = userID;
        hR_Contact.AddedDate = DateTime.Now;
        hR_Contact.ModifiedBy = userID;
        hR_Contact.ModifiedDate = DateTime.Now;
        if (hdnContactsID.Value==string.Empty)
        {
            int resutl = HR_ContactManager.InsertHR_Contact(hR_Contact);
            hdnContactsID.Value = resutl.ToString();
        }
        else
        {
            hR_Contact.ContactID = int.Parse(hdnContactsID.Value);
            bool resutl = HR_ContactManager.UpdateHR_Contact(hR_Contact);
        }
       
        lblContactMsg.Text = "Information is updated successfully.";
        lblContactMsg.ForeColor = System.Drawing.Color.Green;
    }

    protected void lblSelectChildren_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo();
        hR_ChildrenInfo = _childrenInfoColl.ElementAt(index);

        hdnChildrenInfoID.Value = hR_ChildrenInfo.ChildrenInfoID.ToString();
        txtChildrenInfoName.Text = hR_ChildrenInfo.ChildrenInfoName;
        txtChildrenDateOfBirth.Text = hR_ChildrenInfo.ChildrenDateOfBirth.ToString();
        ddlSex.SelectedValue = hR_ChildrenInfo.Sex;
        
        _childrenInfoColl.RemoveAt(index);
        gvHR_ChildrenInfo.DataSource = _childrenInfoColl;
        gvHR_ChildrenInfo.DataBind();
        UpdatePanel1.Update();

    }

    protected void lblChildrenDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo();
        hR_ChildrenInfo = _childrenInfoColl.ElementAt(index);
        if (hR_ChildrenInfo.ChildrenInfoID != 0)
        {
            bool result =  HR_ChildrenInfoManager.DeleteHR_ChildrenInfo(hR_ChildrenInfo.ChildrenInfoID);
        }
        _childrenInfoColl.RemoveAt(index);
        gvHR_ChildrenInfo.DataSource = _childrenInfoColl;
        gvHR_ChildrenInfo.DataBind();
        UpdatePanel1.Update();
    }

    protected void btnAddChildrenInfo_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value!= null)
        {
            HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo();
            //hR_ChildrenInfo.ChildrenInfoID=  int.Parse(ddlChildrenInfoID.SelectedValue);
            hR_ChildrenInfo.EmployeeID = hfEmployeeID.Value.ToString();
            hR_ChildrenInfo.ChildrenInfoName = txtChildrenInfoName.Text;
            hR_ChildrenInfo.ChildrenDateOfBirth = txtChildrenDateOfBirth.Text;
            hR_ChildrenInfo.Sex = ddlSex.SelectedValue;
            string userID = Profile.card_id;
            hR_ChildrenInfo.AddedBy = userID;
            hR_ChildrenInfo.AddedDate = DateTime.Now;
            hR_ChildrenInfo.ModifiedBy = userID;
            hR_ChildrenInfo.ModifiedDate = DateTime.Now;

            if (hdnChildrenInfoID.Value == string.Empty || hdnChildrenInfoID.Value == "0")
            {
                if (!IsDuplicateChildName(txtChildrenInfoName.Text))
                {
                    int resutl = HR_ChildrenInfoManager.InsertHR_ChildrenInfo(hR_ChildrenInfo);
                    hR_ChildrenInfo.ChildrenInfoID = resutl;
                    hdnChildrenInfoID.Value = resutl.ToString();
                    _childrenInfoColl.Add(hR_ChildrenInfo);
                    txtChildrenInfoName.Text = string.Empty;
                    txtChildrenDateOfBirth.Text = string.Empty;
                    lblMsg.Text = "Information is saved";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Children Name is already exist')", true);
                }
            }
            else
            {
                hR_ChildrenInfo.ChildrenInfoID = Convert.ToInt32(hdnChildrenInfoID.Value);
                HR_ChildrenInfoManager.UpdateHR_ChildrenInfo(hR_ChildrenInfo);
                _childrenInfoColl.Add(hR_ChildrenInfo);
                lblMsg.Text = "Information is updated";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtChildrenInfoName.Text = string.Empty;
                txtChildrenDateOfBirth.Text = string.Empty;
            }
        }
        else
        {
            lblMsg.Text = "Employee is not specified.";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

        gvHR_ChildrenInfo.DataSource = _childrenInfoColl;
        gvHR_ChildrenInfo.DataBind();
    }

    protected void btnUpdateChildrenInfo_click(object sender, EventArgs e)
    {
        HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo();
        hR_ChildrenInfo.ChildrenInfoID = int.Parse(hdnChildrenInfoID.Value);
        hR_ChildrenInfo.EmployeeID = hfEmployeeID.Value.ToString();
        hR_ChildrenInfo.ChildrenInfoName = txtChildrenInfoName.Text;
        hR_ChildrenInfo.ChildrenDateOfBirth = txtChildrenDateOfBirth.Text;
        hR_ChildrenInfo.Sex = ddlSex.SelectedValue;
        string userID = Profile.card_id;
        hR_ChildrenInfo.AddedBy = userID;
        hR_ChildrenInfo.AddedDate = DateTime.Now;
        hR_ChildrenInfo.ModifiedBy = userID;
        hR_ChildrenInfo.ModifiedDate = DateTime.Now;
        bool resutl = HR_ChildrenInfoManager.UpdateHR_ChildrenInfo(hR_ChildrenInfo);
        //Response.Redirect("AdminDisplayHR_ChildrenInfo.aspx");
    }

    protected void lblSelectJobExperience_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        COMN_JobExperience comm_JobExperience = new COMN_JobExperience();
        comm_JobExperience = _jobExperienceColl.ElementAt(index);

        hdnJobExperienceID.Value = comm_JobExperience.JobExperienceID.ToString();
        txtOrganization.Text = comm_JobExperience.OrganizationName;
        txtPosition.Text = comm_JobExperience.Designation;
        txtYearStart.Text = comm_JobExperience.DateStart.ToShortDateString();
        txtYearEnd.Text = comm_JobExperience.DateEnds.ToShortDateString();
        txtReasonForLeaving.Text = comm_JobExperience.ReasionForLeaving;
        txtContactPerson.Text = comm_JobExperience.Contact;

        _jobExperienceColl.RemoveAt(index);
        gvHR_JobExperience.DataSource = _jobExperienceColl;
        gvHR_JobExperience.DataBind();
        UpdatePanel1.Update();
    }

    protected void lblDeleteJobExperience_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        COMN_JobExperience comm_JobExperience = new COMN_JobExperience();
        comm_JobExperience = _jobExperienceColl.ElementAt(index);

        if (comm_JobExperience != null)
        {
            bool result = COMN_JobExperienceManager.DeleteCOMN_JobExperience(comm_JobExperience.JobExperienceID);
        }
        
        _jobExperienceColl.RemoveAt(index);
        gvHR_JobExperience.DataSource = _jobExperienceColl;
        gvHR_JobExperience.DataBind();
        UpdatePanel1.Update();
    }

    protected void btnAddJobExperience_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            COMN_JobExperience comm_JobExperience = new COMN_JobExperience();
            comm_JobExperience.UserID = hfEmployeeID.Value.ToString();
            comm_JobExperience.OrganizationName = txtOrganization.Text;
            comm_JobExperience.Designation = txtPosition.Text;
            comm_JobExperience.NatureofWork = "";
            if (txtYearStart.Text.Trim() != string.Empty)
            {
                comm_JobExperience.DateStart = DateTime.Parse(txtYearStart.Text);
            }            
            if (txtYearEnd.Text.Trim() != string.Empty)
            {
                comm_JobExperience.DateEnds = DateTime.Parse(txtYearEnd.Text);
            }            
            comm_JobExperience.Duration = Convert.ToDecimal(0.00);
            comm_JobExperience.ReasionForLeaving = txtReasonForLeaving.Text;
            comm_JobExperience.Contact = txtContactPerson.Text;
            string userID = Profile.card_id;
            comm_JobExperience.AddedBy = userID;
            comm_JobExperience.AddedDate = DateTime.Now;
            comm_JobExperience.UpdatedBy = userID;
            comm_JobExperience.UpdatedDate = DateTime.Now;
            if (hdnJobExperienceID.Value == string.Empty || hdnJobExperienceID.Value == "0")
            {
                int resutl = COMN_JobExperienceManager.InsertCOMN_JobExperience(comm_JobExperience);
                //hdnJobExperienceID.Value = resutl.ToString();
                comm_JobExperience.JobExperienceID = resutl;

                lblJobExperienceMsg.Text = "Information of Job Experience is saved";
                lblJobExperienceMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                comm_JobExperience.JobExperienceID = Convert.ToInt32(hdnJobExperienceID.Value);
                COMN_JobExperienceManager.UpdateCOMN_JobExperience(comm_JobExperience);

                lblJobExperienceMsg.Text = "Information of Job Experience is updated";
                lblJobExperienceMsg.ForeColor = System.Drawing.Color.Green;
            }
            txtOrganization.Text = string.Empty;
            txtPosition.Text = string.Empty;
            txtYearStart.Text = string.Empty;
            txtYearEnd.Text = string.Empty;
            txtReasonForLeaving.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            _jobExperienceColl.Add(comm_JobExperience);
        }
        else
        {

            lblJobExperienceMsg.Text = "Employee is not specified.";
            lblJobExperienceMsg.ForeColor = System.Drawing.Color.Red;
        }
        gvHR_JobExperience.DataSource = _jobExperienceColl;
        gvHR_JobExperience.DataBind();
        UpdatePanel1.Update();
    }

    protected void btnUpdateJobExperience_Click(object sender, EventArgs e)
    {
        COMN_JobExperience comm_JobExperience = new COMN_JobExperience();
        comm_JobExperience.JobExperienceID = int.Parse(hdnJobExperienceID.Value);
        comm_JobExperience.UserID = hfEmployeeID.Value.ToString();
        comm_JobExperience.OrganizationName = txtOrganization.Text;
        comm_JobExperience.Designation = txtPosition.Text;
        comm_JobExperience.NatureofWork = "";
        if (txtYearStart.Text.Trim() != string.Empty)
        {
            comm_JobExperience.DateStart = DateTime.Parse(txtYearStart.Text);
        }
        if (txtYearEnd.Text.Trim() != string.Empty)
        {
            comm_JobExperience.DateEnds = DateTime.Parse(txtYearEnd.Text);
        }
        comm_JobExperience.Duration = Convert.ToDecimal(0.00);
        comm_JobExperience.ReasionForLeaving = txtReasonForLeaving.Text;
        comm_JobExperience.Contact = txtContactPerson.Text;
        string userID = Profile.card_id;
        comm_JobExperience.AddedBy = userID;
        comm_JobExperience.AddedDate = DateTime.Now;
        comm_JobExperience.UpdatedBy = userID;
        comm_JobExperience.UpdatedDate = DateTime.Now;
        bool resutl = COMN_JobExperienceManager.UpdateCOMN_JobExperience(comm_JobExperience);
    }

    //protected void btnAddJobPosting_Click(object sender, EventArgs e)
    //{
    //    if (ViewState["_employeeID"].ToString() != string.Empty)
    //    {
    //        HR_JobPosting hR_JobPosting = new HR_JobPosting();
    //        //	hR_JobPosting.JobPostingID=  int.Parse(ddlJobPostingID.SelectedValue);
    //        hR_JobPosting.EmployeeID = ViewState["_employeeID"].ToString();
    //        hR_JobPosting.DepartmentID = int.Parse(ddlDepartmentID.SelectedValue);
    //        hR_JobPosting.DesignationID = int.Parse(ddlDesignation1ID.SelectedValue);
    //        hR_JobPosting.JoinDate = DateTime.Parse(txtJoinDate.Text);
    //        hR_JobPosting.EndDate = DateTime.Parse(txtEndDate.Text);
    //        hR_JobPosting.PostingStatus = txtPostingStatus.Text;
    //        hR_JobPosting.JobLocation = txtJobLocation.Text;
    //        hR_JobPosting.SupervisorID = ddlSupervisorID.SelectedValue;
    //           string userID = Session["userID"].ToString();
    //        hR_JobPosting.AddedBy = userID;
    //        hR_JobPosting.AddedDate = DateTime.Now;
    //        hR_JobPosting.ModifiedBy = userID;
    //        hR_JobPosting.ModifiedDate = DateTime.Now;
    //        int resutl = HR_JobPostingManager.InsertHR_JobPosting(hR_JobPosting);
    //        hdnJobPostingID.Value = resutl.ToString();
    //        //Response.Redirect("AdminDisplayHR_JobPosting.aspx");
    //        lblJobpostingMsg.Text = "Job Posting Information is received";
    //        lblJobpostingMsg.ForeColor = System.Drawing.Color.Green;
    //    }
    //    else
    //    {
    //        lblJobpostingMsg.Text = "Employee is not specified.";
    //        lblJobpostingMsg.ForeColor = System.Drawing.Color.Red;
    //    }
    //}

    //protected void btnUpdateJobPosting_Click(object sender, EventArgs e)
    //{
    //    HR_JobPosting hR_JobPosting = new HR_JobPosting();
    //    hR_JobPosting.JobPostingID = int.Parse(hdnJobPostingID.Value);
    //    hR_JobPosting.EmployeeID = ViewState["_employeeID"].ToString();
    //    hR_JobPosting.DepartmentID = int.Parse(ddlDepartmentID.SelectedValue);
    //    hR_JobPosting.DesignationID = int.Parse(ddlDesignation1ID.SelectedValue);
    //    hR_JobPosting.JoinDate = DateTime.Parse(txtJoinDate.Text);
    //    hR_JobPosting.EndDate = DateTime.Parse(txtEndDate.Text);
    //    hR_JobPosting.PostingStatus = txtPostingStatus.Text;
    //    hR_JobPosting.JobLocation = txtJobLocation.Text;
    //    hR_JobPosting.SupervisorID = ddlSupervisorID.SelectedValue;
    //     string userID = Session["userID"].ToString();
    //    hR_JobPosting.AddedBy = userID;
    //    hR_JobPosting.AddedDate = DateTime.Now;
    //    hR_JobPosting.ModifiedBy = userID;
    //    hR_JobPosting.ModifiedDate = DateTime.Now;
    //    bool resutl = HR_JobPostingManager.UpdateHR_JobPosting(hR_JobPosting);
    //    //Response.Redirect("AdminDisplayHR_JobPosting.aspx");
    //}

    protected void btnAddAttendenceRules_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value !=null)
        {
            HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules();
            hR_AttendenceRules.EmployeeID = hfEmployeeID.Value.ToString();
            hR_AttendenceRules.Rules = txtRules.Text;
            hR_AttendenceRules.Time = int.Parse(ddlTime.SelectedValue);
            hR_AttendenceRules.Unit = "Min";
            string userID = Profile.card_id;
            hR_AttendenceRules.AddedBy = userID;
            hR_AttendenceRules.AddedDate = DateTime.Now;
            hR_AttendenceRules.ModifiedBy = userID;
            hR_AttendenceRules.ModifiedDate = DateTime.Now;
            int resutl = HR_AttendenceRulesManager.InsertHR_AttendenceRules(hR_AttendenceRules);
            hdnAttendanceRulesID.Value = resutl.ToString();
            lblAttendendRulesMsg.Text = "Attendend Rules Information is Received";
            lblAttendendRulesMsg.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblAttendendRulesMsg.Text = "Employee is not specified.";
            lblAttendendRulesMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnUpdateAttendenceRules_Click(object sender, EventArgs e)
    {
        HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules();
        hR_AttendenceRules.EmployeeID = hfEmployeeID.Value.ToString();
        hR_AttendenceRules.Rules = txtRules.Text;
        hR_AttendenceRules.Time = int.Parse(ddlTime.SelectedValue);
        hR_AttendenceRules.Unit = "Min";
        string userID = Profile.card_id;
        hR_AttendenceRules.AddedBy = userID;
        hR_AttendenceRules.AddedDate = DateTime.Now;
        hR_AttendenceRules.ModifiedBy = userID;
        hR_AttendenceRules.ModifiedDate = DateTime.Now;
        if (hdnAttendanceRulesID.Value == string.Empty)
        {
            int resutl = HR_AttendenceRulesManager.InsertHR_AttendenceRules(hR_AttendenceRules);
            hdnAttendanceRulesID.Value = resutl.ToString();
        }
        else
        {
            hR_AttendenceRules.AttendenceRulesID = int.Parse(hdnAttendanceRulesID.Value);
            bool resutl = HR_AttendenceRulesManager.UpdateHR_AttendenceRules(hR_AttendenceRules);
        }
        lblAttendendRulesMsg.Text = "Attendend Rules Information is updated";
        lblAttendendRulesMsg.ForeColor = System.Drawing.Color.Green;
    }

    protected void btnAddOtherDocuments_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            HR_OthersDocuments hR_OthersDocuments = new HR_OthersDocuments();
            //	hR_OthersDocuments.OthersDocumentsID=  int.Parse(ddlOthersDocumentsID.SelectedValue);
            hR_OthersDocuments.EmployeeID = hfEmployeeID.Value.ToString();
            hR_OthersDocuments.DocumentsType = ddlDocumentType.SelectedValue;
            //hR_OthersDocuments.DocumentName=  txtDocumentName.Text;


            if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
            {
                //try
                //{
                string dirUrl = "../HR/upload/employeer";
                string dirPath = Server.MapPath(dirUrl);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                string fileName = Path.GetFileName(uplFile.PostedFile.FileName);

                string[] fileNameSpilt = fileName.Split('.');

                if (fileNameSpilt.Length == 2)
                {
                    if (fileNameSpilt[1] != "txt" && fileNameSpilt[1] != "pdf" && fileNameSpilt[1] != "doc" && fileNameSpilt[1] != "docx")
                    {
                        lblOtherDocumentsMessage.Text = "Document is not valid formated.(Valid documents are .txt, .pdf, .doc, .docx)";
                        lblOtherDocumentsMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
                string filePath = Server.MapPath(fileUrl);
                uplFile.PostedFile.SaveAs(filePath);

                hR_OthersDocuments.DocumentName = fileName;
                //}
                //catch (Exception ex)
                //{
                //    lblMessage.Text = ex.Message.ToString();
                //    lblMessage.Text = lblMessage.Text + "<br />Please rename your file. ";
                //}
            }
            else
            {
                hR_OthersDocuments.DocumentName = "Not loaded any document";
            }
            string userID = Profile.card_id;
            hR_OthersDocuments.AddedBy = userID;
            hR_OthersDocuments.AddedDate = DateTime.Now;
            hR_OthersDocuments.ModifiedBy = userID;
            hR_OthersDocuments.ModifiedDate = DateTime.Now;
            int resutl = HR_OthersDocumentsManager.InsertHR_OthersDocuments(hR_OthersDocuments);
            hdnOtherDocumentsID.Value = resutl.ToString();
            //Response.Redirect("AdminDisplayHR_OthersDocuments.aspx");
            lblOtherDocumentsMessage.Text = "Documents is saved";
            lblOtherDocumentsMessage.ForeColor = System.Drawing.Color.Green;
        }
        else
        {

            lblOtherDocumentsMessage.Text = "Employee is not specified.";
            lblOtherDocumentsMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnUpdateOtherDocuments_click(object sender, EventArgs e)
    {
        HR_OthersDocuments hR_OthersDocuments = new HR_OthersDocuments();
        hR_OthersDocuments.OthersDocumentsID = int.Parse(hdnOtherDocumentsID.Value);
        hR_OthersDocuments.EmployeeID = hfEmployeeID.Value.ToString();
        hR_OthersDocuments.DocumentsType = ddlDocumentType.SelectedValue;
        //hR_OthersDocuments.DocumentName=  txtDocumentName.Text;
        if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
        {
            //try
            //{
            string dirUrl = "../HR/upload/employeer";
            string dirPath = Server.MapPath(dirUrl);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
            string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
            string filePath = Server.MapPath(fileUrl);
            uplFile.PostedFile.SaveAs(filePath);

            hR_OthersDocuments.DocumentName = dirUrl + "/" + fileName;
            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = ex.Message.ToString();
            //    lblMessage.Text = lblMessage.Text + "<br />Please rename your file. ";
            //}
        }
        else
        {
            hR_OthersDocuments.DocumentName = hR_OthersDocuments.DocumentName;
        }
        string userID = Profile.card_id;
        hR_OthersDocuments.AddedBy = userID;
        hR_OthersDocuments.AddedDate = DateTime.Now;
        hR_OthersDocuments.ModifiedBy = userID;
        hR_OthersDocuments.ModifiedDate = DateTime.Now;
        bool resutl = HR_OthersDocumentsManager.UpdateHR_OthersDocuments(hR_OthersDocuments);
        //Response.Redirect("AdminDisplayHR_OthersDocuments.aspx");
    }

    protected void btnAddWorkingDaysShifting_Click(object sender, EventArgs e)
    {

        if (hfEmployeeID.Value != null)
        {
            string txtStartHour = this.ddltime_hoursStart.SelectedValue.ToString();
            string txtStartMin = this.ddltime_minstart.SelectedValue.ToString();
            string txtStartTime = DateTime.Now.ToShortDateString() + " " + txtStartHour + " : " + txtStartMin + ": 00";
            DateTime dtStartTime = Convert.ToDateTime(txtStartTime);
            string txtEndHour = this.ddltime_hoursEnd.SelectedValue.ToString();
            string txtEndMin = this.ddltime_minEnd.SelectedValue.ToString();
            string txtEndTime = DateTime.Now.ToShortDateString() + " " + txtEndHour + " : " + txtEndMin + ": 00";
            DateTime dtEndTime = Convert.ToDateTime(txtEndTime);
            HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting();
            hR_WorkingDaysShifting.EmployeeID = hfEmployeeID.Value.ToString();
            hR_WorkingDaysShifting.Saturday = chkSaturday.Checked == true ? true : false;
            hR_WorkingDaysShifting.Sunday = chkSunday.Checked == true ? true : false;
            hR_WorkingDaysShifting.Monday = chkMonday.Checked == true ? true : false;
            hR_WorkingDaysShifting.Tuesday = chkTuesday.Checked == true ? true : false;
            hR_WorkingDaysShifting.Wednesday = chkWednesday.Checked == true ? true : false;
            hR_WorkingDaysShifting.Thrusday = chkThrusday.Checked == true ? true : false;
            hR_WorkingDaysShifting.Friday = chkFriday.Checked == true ? true : false;
            hR_WorkingDaysShifting.ShiftStartTime = dtStartTime;
            hR_WorkingDaysShifting.ShiftEndTime = dtEndTime;
            hR_WorkingDaysShifting.Description = txtDescription.Text;
            string userID = Profile.card_id;
            hR_WorkingDaysShifting.AddedBy = userID;
            hR_WorkingDaysShifting.AddedDate = DateTime.Now;
            hR_WorkingDaysShifting.ModifiedBy = userID;
            hR_WorkingDaysShifting.ModifiedDate = DateTime.Now;
            int resutl = HR_WorkingDaysShiftingManager.InsertHR_WorkingDaysShifting(hR_WorkingDaysShifting);
            hdnWorkingDaysShiftingID.Value = resutl.ToString();
            lblDaysShiftingMessage.Text = "Working Shift Information is saved";
            lblDaysShiftingMessage.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblDaysShiftingMessage.Text = "Employee is not specified.";
            lblDaysShiftingMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnUpdateWorkingDaysShifting_Click(object sender, EventArgs e)
    {
        string txtStartHour = this.ddltime_hoursStart.SelectedValue.ToString();
        string txtStartMin = this.ddltime_minstart.SelectedValue.ToString();
        string txtStartTime = DateTime.Now.ToShortDateString() + " " + txtStartHour + " : " + txtStartMin + ": 00";
        DateTime dtStartTime = Convert.ToDateTime(txtStartTime);
        string txtEndHour = this.ddltime_hoursEnd.SelectedValue.ToString();
        string txtEndMin = this.ddltime_minEnd.SelectedValue.ToString();
        string txtEndTime = DateTime.Now.ToShortDateString() + " " + txtEndHour + " : " + txtEndMin + ": 00";
        DateTime dtEndTime = Convert.ToDateTime(txtEndTime);
        HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting();
        hR_WorkingDaysShifting.EmployeeID = hfEmployeeID.Value.ToString();
        hR_WorkingDaysShifting.Saturday = chkSaturday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Sunday = chkSunday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Monday = chkMonday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Tuesday = chkTuesday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Wednesday = chkWednesday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Thrusday = chkThrusday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Friday = chkFriday.Checked = true ? true : false;
        hR_WorkingDaysShifting.ShiftStartTime = dtStartTime;
        hR_WorkingDaysShifting.ShiftEndTime = dtEndTime;
        hR_WorkingDaysShifting.Description = txtDescription.Text;
        string userID = Profile.card_id;
        hR_WorkingDaysShifting.AddedBy = userID;
        hR_WorkingDaysShifting.AddedDate = DateTime.Now;
        hR_WorkingDaysShifting.ModifiedBy = userID;
        hR_WorkingDaysShifting.ModifiedDate = DateTime.Now;
        if (hdnWorkingDaysShiftingID.Value == string.Empty)
        {
            int resutl = HR_WorkingDaysShiftingManager.InsertHR_WorkingDaysShifting(hR_WorkingDaysShifting);
            hdnWorkingDaysShiftingID.Value = resutl.ToString();
        }
        else
        {
            hR_WorkingDaysShifting.WorkingDaysID = Convert.ToInt32(hdnWorkingDaysShiftingID.Value);
            bool resutl = HR_WorkingDaysShiftingManager.UpdateHR_WorkingDaysShifting(hR_WorkingDaysShifting);
        }
        lblDaysShiftingMessage.Text = "Working Shift Information is updated successfull.";
        lblDaysShiftingMessage.ForeColor = System.Drawing.Color.Green;
    }

    protected void btnAddBank_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            HR_BankAccount hR_Bank = new HR_BankAccount();
            hR_Bank.EmployeeID = hfEmployeeID.Value.ToString();
            hR_Bank.AccountName = txtBankAccountName.Text;
            hR_Bank.AccountNo = txtBankAccountNo.Text;
            hR_Bank.BankName = txtBankName.Text;
            hR_Bank.BankAddress = txtBankAddress.Text;
            hR_Bank.ContactPerson = txtBankTelephone.Text;
            string userID = Profile.card_id;
            hR_Bank.AddedBy = userID;
            hR_Bank.AddedDate = DateTime.Now;
            hR_Bank.ModifiedBy = userID;
            hR_Bank.ModifiedDate = DateTime.Now;
            int resutl = HR_BankAccountManager.InsertHR_BankAccount(hR_Bank);
            hdnBankID.Value = resutl.ToString();
            lblBankMsg.Text = "Bank Information is saved";
            lblBankMsg.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblBankMsg.Text = "Employee is not specified.";
            lblBankMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnUpdateBank_Click(object sender, EventArgs e)
    {
        HR_BankAccount hR_Bank = new HR_BankAccount();
        hR_Bank.EmployeeID = hfEmployeeID.Value.ToString();
        hR_Bank.AccountName = txtBankAccountName.Text;
        hR_Bank.AccountNo = txtBankAccountNo.Text;
        hR_Bank.BankName = txtBankName.Text;
        hR_Bank.BankAddress = txtBankAddress.Text;
        hR_Bank.ContactPerson = txtBankTelephone.Text;
        string userID = Profile.card_id;
        hR_Bank.AddedBy = userID;
        hR_Bank.AddedDate = DateTime.Now;
        hR_Bank.ModifiedBy = userID;
        hR_Bank.ModifiedDate = DateTime.Now;
        if (hdnBankID.Value == string.Empty)
        {
            int resutl = HR_BankAccountManager.InsertHR_BankAccount(hR_Bank);
            hdnBankID.Value = resutl.ToString();
        }
        else
        {
            hR_Bank.BankAccountNoID = int.Parse(hdnBankID.Value);
            bool resutl = HR_BankAccountManager.UpdateHR_BankAccount(hR_Bank);
        }

        lblBankMsg.Text = "Bank Information is updated successfully";
        lblBankMsg.ForeColor = System.Drawing.Color.Green;
    }

    protected void lblSelectEducational_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
        //List<COMN_EducatinalBackground>
        
        List<COMN_EducatinalBackground> educationalBackgroundColl = (List<COMN_EducatinalBackground>)Session["_educationalBackgroundColl"];
        cOMN_EducatinalBackground = educationalBackgroundColl.ElementAt(index);
        educationalBackgroundColl.RemoveAt(index);
        Session["_educationalBackgroundColl"] = educationalBackgroundColl;

        hdnEducationBackground.Value = cOMN_EducatinalBackground.EducationalBacgroundID.ToString();

        txtYear.Text = cOMN_EducatinalBackground.Year.ToString();
        txtBoardUniversity.Text = cOMN_EducatinalBackground.BoardUniversity.ToString();
        txtEducationGroup.Text = cOMN_EducatinalBackground.EducationGroup.ToString();
        txtMajor.Text = cOMN_EducatinalBackground.Major;
        ddlReaultSystemID.SelectedValue = cOMN_EducatinalBackground.ReaultSystemID.ToString();
        txtDegree.Text = cOMN_EducatinalBackground.Degree;
        txtResult.Text = cOMN_EducatinalBackground.Result;
        txtScore.Text = cOMN_EducatinalBackground.Score.ToString();
        txtOutOf.Text = cOMN_EducatinalBackground.OutOf.ToString();

        gv_educationalBackground.DataSource = educationalBackgroundColl;
        gv_educationalBackground.DataBind();
        UpdatePanel1.Update();
    }

    protected void lblDeleteEducational_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
        List<COMN_EducatinalBackground> educationalBackgroundColl = (List<COMN_EducatinalBackground>)Session["_educationalBackgroundColl"];
        cOMN_EducatinalBackground = educationalBackgroundColl.ElementAt(index);
       
        
        bool result = COMN_EducatinalBackgroundManager.DeleteCOMN_EducatinalBackground(cOMN_EducatinalBackground.EducationalBacgroundID);

        educationalBackgroundColl.RemoveAt(index);
        Session["_educationalBackgroundColl"] = educationalBackgroundColl;
        gv_educationalBackground.DataSource = educationalBackgroundColl;
        gv_educationalBackground.DataBind();
        UpdatePanel1.Update();
    }
    
    protected void btnAddEducationalBackground_Click(object sender, EventArgs e)
    {
        List<COMN_EducatinalBackground> educationalBackgroundColl = (List<COMN_EducatinalBackground>)Session["_educationalBackgroundColl"];
       

        if (hfEmployeeID.Value != null)
        {
            COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
            cOMN_EducatinalBackground.UserID = hfEmployeeID.Value.ToString();
            cOMN_EducatinalBackground.Year = txtYear.Text;
            cOMN_EducatinalBackground.BoardUniversity = txtBoardUniversity.Text;
            cOMN_EducatinalBackground.EducationGroup = txtEducationGroup.Text;
            cOMN_EducatinalBackground.Major = txtMajor.Text;
            cOMN_EducatinalBackground.ReaultSystemID = int.Parse(ddlReaultSystemID.SelectedValue);
            cOMN_EducatinalBackground.Degree = txtDegree.Text;
            cOMN_EducatinalBackground.Result = txtResult.Text;
            if (txtScore.Text.Trim() != string.Empty)
            {
                cOMN_EducatinalBackground.Score = decimal.Parse(txtScore.Text);
            }
            else
            {
                cOMN_EducatinalBackground.Score = 0;
            }
            if (txtOutOf.Text.Trim() != string.Empty)
            {
                cOMN_EducatinalBackground.OutOf = int.Parse(txtOutOf.Text);
            }
            else
            {
                cOMN_EducatinalBackground.OutOf = 0;
            }
            string userID = Profile.card_id;
            cOMN_EducatinalBackground.AddedBy = userID;
            cOMN_EducatinalBackground.AddedDate = DateTime.Now;
            cOMN_EducatinalBackground.ModifiedBy = userID;
            cOMN_EducatinalBackground.ModifiedDate = DateTime.Now;

            if (hdnEducationBackground.Value == string.Empty || hdnEducationBackground.Value == "0")
            {
                int resutl = COMN_EducatinalBackgroundManager.InsertCOMN_EducatinalBackground(cOMN_EducatinalBackground);
                hdnEducationBackground.Value = resutl.ToString();
                cOMN_EducatinalBackground.EducationalBacgroundID = resutl;

                lblEducationalMsg.Text = "Educational Information is saved";
                lblEducationalMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                cOMN_EducatinalBackground.EducationalBacgroundID = Convert.ToInt32(hdnEducationBackground.Value);
                COMN_EducatinalBackgroundManager.UpdateCOMN_EducatinalBackground(cOMN_EducatinalBackground);
                lblEducationalMsg.Text = "Educational Information is updated";
                lblEducationalMsg.ForeColor = System.Drawing.Color.Green;
            }

            txtYear.Text = string.Empty;
            txtBoardUniversity.Text = string.Empty;
            txtEducationGroup.Text = string.Empty;
            txtMajor.Text = string.Empty;
            txtDegree.Text = string.Empty;
            txtResult.Text = string.Empty;
            txtScore.Text = string.Empty;
            txtOutOf.Text = string.Empty;
            hdnEducationBackground.Value = string.Empty;

            educationalBackgroundColl.Add(cOMN_EducatinalBackground);
        }
        else
        {
            lblEducationalMsg.Text = "Employee is not specified.";
            lblEducationalMsg.ForeColor = System.Drawing.Color.Red;
        }
        Session["_educationalBackgroundColl"] = educationalBackgroundColl;

        gv_educationalBackground.DataSource = educationalBackgroundColl;
        gv_educationalBackground.DataBind();

    }

    //protected void btnUpdateEducationalBackground_Click(object sender, EventArgs e)
    //{
    //    COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
    //    cOMN_EducatinalBackground.EducationalBacgroundID = int.Parse(hdnEducationBackground.Value);
    //    cOMN_EducatinalBackground.UserID = hfEmployeeID.Value.ToString();
    //    cOMN_EducatinalBackground.Year = txtYear.Text;
    //    cOMN_EducatinalBackground.BoardUniversity = txtBoardUniversity.Text;
    //    cOMN_EducatinalBackground.EducationGroup = txtEducationGroup.Text;
    //    cOMN_EducatinalBackground.Major = txtMajor.Text;
    //    cOMN_EducatinalBackground.ReaultSystemID = int.Parse(ddlReaultSystemID.SelectedValue);
    //    cOMN_EducatinalBackground.Degree = txtDegree.Text;
    //    cOMN_EducatinalBackground.Result = txtResult.Text;
    //    cOMN_EducatinalBackground.Score = decimal.Parse(txtScore.Text);
    //    cOMN_EducatinalBackground.OutOf = int.Parse(txtOutOf.Text);
    //     string userID = Session["userID"].ToString();
    //    cOMN_EducatinalBackground.AddedBy = userID;
    //    cOMN_EducatinalBackground.AddedDate = DateTime.Now;
    //    cOMN_EducatinalBackground.ModifiedBy = userID;
    //    cOMN_EducatinalBackground.ModifiedDate = DateTime.Now;
    //    bool resutl = COMN_EducatinalBackgroundManager.UpdateCOMN_EducatinalBackground(cOMN_EducatinalBackground);
    //    //Response.Redirect("AdminDisplayCOMN_EducatinalBackground.aspx");
    //}


    //private void DepartmentIDLoad()
    //{
    //    try
    //    {
    //        DataSet ds = HR_DepartmentManager.GetDropDownListAllHR_Department();
    //        ddlDepartmentID.DataValueField = "DepartmentID";
    //        ddlDepartmentID.DataTextField = "DepartmentName";
    //        ddlDepartmentID.DataSource = ds.Tables[0];
    //        ddlDepartmentID.DataBind();
    //        ddlDepartmentID.Items.Insert(0, new ListItem("Select Department >>", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Message.ToString();
    //    }
    //}
    //private void JobPostingDesignationIDLoad()
    //{
    //    try
    //    {
    //        DataSet ds = HR_DesignationManager.GetDropDownListAllHR_Designation();
    //        ddlDesignation1ID.DataValueField = "DesignationID";
    //        ddlDesignation1ID.DataTextField = "DesignationName";
    //        ddlDesignation1ID.DataSource = ds.Tables[0];
    //        ddlDesignation1ID.DataBind();
    //        ddlDesignation1ID.Items.Insert(0, new ListItem("Select Designation >>", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Message.ToString();
    //    }
    //}
    //private void SupervisorIDLoad()
    //{
    //    try
    //    {
    //        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
    //        ddlSupervisorID.DataValueField = "EmployeeID";
    //        ddlSupervisorID.DataTextField = "EmployeeName";
    //        ddlSupervisorID.DataSource = ds.Tables[0];
    //        ddlSupervisorID.DataBind();
    //        ddlSupervisorID.Items.Insert(0, new ListItem("Select Supervisor >>", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Message.ToString();
    //    }
    //}
    
    protected void ddlPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvHR_PackageRules.DataSource = HR_PackageRulesManager.GetAllHR_PackageRulessByPackageID(Convert.ToInt32(ddlPackage.SelectedValue));
        gvHR_PackageRules.DataBind();
    }

    protected void btnSaveEmployeeSalary_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value == null)
        {
            lblSalaryMsg.Text = "Invalid Employee";
            lblSalaryMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (hfEmployeeID.Value.ToString() != string.Empty)
        {
            if (txtAmount.Text.Trim() == string.Empty)
            {
                lblSalaryMsg.Text = "Amount is Empty";
                lblSalaryMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
            HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
            hR_EmployeeSalary.EmployeeID = hfEmployeeID.Value.ToString();
            hR_EmployeeSalary.IsGross = radIsGross.SelectedValue == "Gross" ? true : false;
            if (hR_EmployeeSalary.IsGross)
            {
                hR_EmployeeSalary.GrossAmount = decimal.Parse(txtAmount.Text);
            }
            else
            {
                hR_EmployeeSalary.BasicAmount = decimal.Parse(txtAmount.Text);
            }

            hR_EmployeeSalary.IsActive = true;
            string userID = Profile.card_id;
            hR_EmployeeSalary.AddedBy = userID;
            hR_EmployeeSalary.AddedDate = DateTime.Now;
            hR_EmployeeSalary.ModifiedBy = userID;
            hR_EmployeeSalary.ModifiedDate = DateTime.Now;
            if (HR_EmployeeSalaryManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
            {
                HR_EmployeeSalary empSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(hfEmployeeID.Value.ToString());
                if (empSalary != null)
                {
                    HR_EmployeeSalaryManager.DeleteHR_EmployeeSalary(empSalary.EmployeeSalaryID);
                }
                //lblSalaryMsg.Text = "Employee's salary information is Exist";
                //lblSalaryMsg.ForeColor = System.Drawing.Color.BlueViolet;
            }
            //else
            //{
                int resutl = HR_EmployeeSalaryManager.InsertHR_EmployeeSalary(hR_EmployeeSalary);
            //}

                if (HR_EmployeeSalaryRulesManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
                {
                    HR_EmployeeSalaryRulesManager.DeleteHR_EmployeeSalaryRulesByEmployeeID(hfEmployeeID.Value.ToString());
                }

                RefreshPackageRelues();
                foreach (HR_PackageRules packageRules in _ListPackageRules)
                {
                    HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules();

                    hR_EmployeeSalaryRules.EmployeeID = hfEmployeeID.Value.ToString();
                    hR_EmployeeSalaryRules.PackageRulesID = packageRules.PackageRulesID;
                    hR_EmployeeSalaryRules.AddedBy = userID;
                    hR_EmployeeSalaryRules.AddedDate = DateTime.Now;
                    hR_EmployeeSalaryRules.UpdatedBy = userID;
                    hR_EmployeeSalaryRules.UpdatedDate = DateTime.Now;
                    int resID = HR_EmployeeSalaryRulesManager.InsertHR_EmployeeSalaryRules(hR_EmployeeSalaryRules);
                }
                lblSalaryMsg.Text = "Salary Information is saved";
                lblSalaryMsg.ForeColor = System.Drawing.Color.Green;
            
        }
        else
        {
            lblSalaryMsg.Text = "Employee is not specified.";
            lblSalaryMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnUpdateEmployeeSalary_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value == null)
        {
            lblSalaryMsg.Text = "Invalid Employee";
            lblSalaryMsg.ForeColor = System.Drawing.Color.Red;
            UpdatePanel1.Update();
            return;
        }

        if (hfEmployeeID.Value.ToString() != string.Empty)
        {
            if (txtAmount.Text.Trim() == string.Empty)
            {
                lblSalaryMsg.Text = "Amount is Empty";
                lblSalaryMsg.ForeColor = System.Drawing.Color.Red;
                UpdatePanel1.Update();
                return;
            }

            HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
            hR_EmployeeSalary.EmployeeID = hfEmployeeID.Value.ToString();
            hR_EmployeeSalary.IsGross = radIsGross.SelectedValue == "Gross" ? true : false;
            if (hR_EmployeeSalary.IsGross)
            {
                hR_EmployeeSalary.GrossAmount = decimal.Parse(txtAmount.Text);
            }
            else
            {
                hR_EmployeeSalary.BasicAmount = decimal.Parse(txtAmount.Text);
            }

            hR_EmployeeSalary.IsActive = true;
            string userID = Profile.card_id;
            hR_EmployeeSalary.AddedBy = userID;
            hR_EmployeeSalary.AddedDate = DateTime.Now;
            hR_EmployeeSalary.ModifiedBy = userID;
            hR_EmployeeSalary.ModifiedDate = DateTime.Now;

            if (hdnEmployeeSalaryID.Value == string.Empty)
            {
                if (HR_EmployeeSalaryManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
                {
                    lblSalaryMsg.Text = "Employee's salary information is Exist";
                    lblSalaryMsg.ForeColor = System.Drawing.Color.BlueViolet;
                }
                else
                {
                    int resutl = HR_EmployeeSalaryManager.InsertHR_EmployeeSalary(hR_EmployeeSalary);
                }
            }
            else
            {
                hR_EmployeeSalary.EmployeeSalaryID = Convert.ToInt32(hdnEmployeeSalaryID.Value);
                HR_EmployeeSalaryManager.UpdateHR_EmployeeSalary(hR_EmployeeSalary);
            }


            if (HR_EmployeeSalaryRulesManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
            {
                HR_EmployeeSalaryRulesManager.DeleteHR_EmployeeSalaryRulesByEmployeeID(hfEmployeeID.Value.ToString());
            }

                RefreshPackageRelues();
                foreach (HR_PackageRules packageRules in _ListPackageRules)
                {
                    HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules();

                    hR_EmployeeSalaryRules.EmployeeID = hfEmployeeID.Value.ToString();
                    hR_EmployeeSalaryRules.PackageRulesID = packageRules.PackageRulesID;
                   // string userID = Profile.card_id;
                    hR_EmployeeSalaryRules.AddedBy = userID;
                    hR_EmployeeSalaryRules.AddedDate = DateTime.Now;
                    hR_EmployeeSalaryRules.UpdatedBy = userID;
                    hR_EmployeeSalaryRules.UpdatedDate = DateTime.Now;
                    int resID = HR_EmployeeSalaryRulesManager.InsertHR_EmployeeSalaryRules(hR_EmployeeSalaryRules);
                }
                lblSalaryMsg.Text = "Salary Information is saved";
                lblSalaryMsg.ForeColor = System.Drawing.Color.Green;
            
        }
        else
        {
            lblSalaryMsg.Text = "Employee is not specified.";
            lblSalaryMsg.ForeColor = System.Drawing.Color.Red;
        }
        UpdatePanel1.Update();
    }

    protected void ddlBenifitPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //List<HR_BenifitPackage> benifitPackageList = new List<HR_BenifitPackage>();
        //HR_BenifitPackage benifitPackage = HR_BenifitPackageManager.GetHR_BenifitPackageByBenifitPackageID(Convert.ToInt32(ddlBenifitPackage.SelectedValue));
        //benifitPackageList.Add(benifitPackage);
        //gvHR_BenefitPackage.DataSource = benifitPackageList;
        //gvHR_BenefitPackage.DataBind();
    }
   
    private void showHR_EmployeeSalaryData()
    {
        HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
        hR_EmployeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeSalaryID(Int32.Parse(Request.QueryString["ID"]));
        radIsGross.SelectedValue = hR_EmployeeSalary.IsGross.ToString();
        txtAmount.Text = hR_EmployeeSalary.BasicAmount.ToString();
        // radIsActive.SelectedValue  =hR_EmployeeSalary.IsActive.ToString();
    }

    protected void radSalaryRules_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radSalaryRules.SelectedValue == "False")
        {
            ddlPackage.Visible = true;
            gridViewPackageAndPackageRules.Visible = false;
        }
        else
        {
            ddlPackage.Visible = false;
            gridViewPackageAndPackageRules.Visible = true;
            DataSet dataSet = HR_PackageRulesManager.GetAllHR_PackageAndPackageRuless();

            gridViewPackageAndPackageRules.DataSource = dataSet.Tables[0];
            gridViewPackageAndPackageRules.DataBind();

            gvHR_PackageRules.DataSource = null;
            gvHR_PackageRules.DataBind();
        }
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);
        _ListPackageRules.RemoveAt(index);
        gvHR_PackageRules.DataSource = _ListPackageRules;
        gvHR_PackageRules.DataBind();
    }

    protected void btnAddLunchRule_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            string txtStartHour = this.ddlLunchTimeStartHour.SelectedValue.ToString();
            string txtStartMin = this.ddlLunchTimeStartMinute.SelectedValue.ToString();
            string txtStartTime = DateTime.Now.ToShortDateString() + " " + txtStartHour + " : " + txtStartMin + ": 00";
            DateTime dtStartTime = Convert.ToDateTime(txtStartTime);
            string txtEndHour = this.ddlLunchTimeEndHour.SelectedValue.ToString();
            string txtEndMin = this.ddlLunchTimeEndMinute.SelectedValue.ToString();
            string txtEndTime = DateTime.Now.ToShortDateString() + " " + txtEndHour + " : " + txtEndMin + ": 00";
            DateTime dtEndTime = Convert.ToDateTime(txtEndTime);

            HR_LunchRule hR_LunchRule = new HR_LunchRule();
            hR_LunchRule.EmployeeID = hfEmployeeID.Value.ToString();

            hR_LunchRule.LunchTimeStart = dtStartTime;
            hR_LunchRule.LunchTimeEnd = dtEndTime;
            hR_LunchRule.LunchFlexibleTimeMins = Convert.ToInt32(ddlLunchFlexibleTimeMins.SelectedValue);

            hR_LunchRule.LunchTimeAllowed = 0;// int.Parse(txtLunchTimeAllowed.Text);
            hR_LunchRule.LunchFlag = radLunchFlag.SelectedValue == "True" ? true : false;
            string userID = Profile.card_id;
            hR_LunchRule.AddedBy = userID;
            hR_LunchRule.AddedDate = DateTime.Now;
            hR_LunchRule.ModifiedBy = userID;
            hR_LunchRule.ModifiedDate = DateTime.Now;
            if (hdnLunchRuleID.Value == string.Empty)
            {
                int resutl = HR_LunchRuleManager.InsertHR_LunchRule(hR_LunchRule);
                lblLunchMsg.Text = "Lunch rule Information is saved successfully";
                hdnLunchRuleID.Value = resutl.ToString();
            }
            else
            {
                hR_LunchRule.LunchRuleID = Convert.ToInt32(hdnLunchRuleID.Value);
                HR_LunchRuleManager.UpdateHR_LunchRule(hR_LunchRule);
                lblLunchMsg.Text = "Lunch rule Information is updated successfully";
            }
            
            lblLunchMsg.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblLunchMsg.Text = "Employee is not specified.";
            lblLunchMsg.ForeColor = System.Drawing.Color.Red;
        }
        UpdatePanel1.Update();
    }

    //protected void lblSelectBenefit_Click(object sender, EventArgs e)
    //{

    //}

    protected void lblDeleteBenefit_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);

        HR_BenifitPackage benifitPackage = new HR_BenifitPackage();

        benifitPackage = _benifitPackageColl.ElementAt(index);

        if (benifitPackage.BenifitPackageID != 0)
        {
            bool result = HR_BenifitPackageRulesManager.DeleteHR_BenifitPackageRulesByEmpIDAndBenPackageID(hfEmployeeID.Value.ToString(),benifitPackage.BenifitPackageID) ;
        }
        _benifitPackageColl.RemoveAt(index);
        gvHR_BenefitPackage.DataSource = _benifitPackageColl;
        gvHR_BenefitPackage.DataBind();
        UpdatePanel1.Update();
    }

    protected void btnAddBenifitRules_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            HR_BenifitPackageRules hR_BenifitPackageRules = new HR_BenifitPackageRules();

            hR_BenifitPackageRules.EmployeeID = hfEmployeeID.Value.ToString();
            hR_BenifitPackageRules.BenifitPackageID = Convert.ToInt32(ddlBenifitPackage.SelectedValue.ToString());
            
            int resutl = HR_BenifitPackageRulesManager.InsertHR_BenifitPackageRules(hR_BenifitPackageRules);
            hR_BenifitPackageRules.BenifitPackageRulesID = resutl;
            HR_BenifitPackage benefitPackage = HR_BenifitPackageManager.GetHR_BenifitPackageByBenifitPackageID(hR_BenifitPackageRules.BenifitPackageID);
            _benifitPackageColl.Add(benefitPackage);
            lblBenifitMsg.Text = "Benefit Rules Information is saved";
            lblBenifitMsg.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblBenifitMsg.Text = "Employee is not specified.";
            lblBenifitMsg.ForeColor = System.Drawing.Color.Red;
        }

        gvHR_BenefitPackage.DataSource = _benifitPackageColl;
        gvHR_BenefitPackage.DataBind();
        UpdatePanel1.Update();
    }

    protected void ddlSalaryTaxPackageID_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<HR_SalaryTaxPackage> salaryTaxPackageList = new List<HR_SalaryTaxPackage>();
        HR_SalaryTaxPackage salaryTaxPackage = HR_SalaryTaxPackageManager.GetHR_SalaryTaxPackageBySalaryTaxPackagePackageID(Convert.ToInt32(ddlSalaryTaxPackageID.SelectedValue));
        salaryTaxPackageList.Add(salaryTaxPackage);
        gvHR_SalaryTaxPackage.DataSource = salaryTaxPackageList;
        gvHR_SalaryTaxPackage.DataBind();
    }

    protected void btnAddSalaryTax_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            if (!HR_SalaryTaxPackageRulesManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
            {
                HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules = new HR_SalaryTaxPackageRules();
                hR_SalaryTaxPackageRules.EmployeeID = hfEmployeeID.Value.ToString();
                hR_SalaryTaxPackageRules.SalaryTaxPackageID = int.Parse(ddlSalaryTaxPackageID.SelectedValue);
                string userID = Profile.card_id;
                hR_SalaryTaxPackageRules.AddedBy = userID;
                hR_SalaryTaxPackageRules.AddedDate = DateTime.Now;
                hR_SalaryTaxPackageRules.ModifiedBy = userID;
                hR_SalaryTaxPackageRules.ModifiedDate = DateTime.Now;
                int resutl = HR_SalaryTaxPackageRulesManager.InsertHR_SalaryTaxPackageRules(hR_SalaryTaxPackageRules);
                lblTaxRulesMsg.Text = "Salary Tax Package Information is saved";
                lblTaxRulesMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblTaxRulesMsg.Text = "Employee's information is exist.";
                lblTaxRulesMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblTaxRulesMsg.Text = "Employee is not specified.";
            lblTaxRulesMsg.ForeColor = System.Drawing.Color.Red;
        }
        UpdatePanel1.Update();
    }

    protected void btnAddSalaryIncrement_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            if (!HR_SalaryIncrementPackageRulesManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
            {
                HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules = new HR_SalaryIncrementPackageRules();
                //	hR_SalaryIncrementPackageRules.SalaryIncrementPackageRulesID=  int.Parse(ddlSalaryIncrementPackageRulesID.SelectedValue);
                hR_SalaryIncrementPackageRules.EmployeeID = hfEmployeeID.Value.ToString();//ddlsalaryIncrementEmployeeID.SelectedValue;
                hR_SalaryIncrementPackageRules.SalaryIncrementPackageID = int.Parse(ddlSalaryIncrementPackageID.SelectedValue);
                hR_SalaryIncrementPackageRules.Year = int.Parse(txtSalaryYear.Text);
                hR_SalaryIncrementPackageRules.Month = int.Parse(txtMonth.Text);
                string userID = Profile.card_id;
                hR_SalaryIncrementPackageRules.AddedBy = userID;
                hR_SalaryIncrementPackageRules.AddedDate = DateTime.Now;
                hR_SalaryIncrementPackageRules.ModifiedBy = userID;
                hR_SalaryIncrementPackageRules.ModifiedDate = DateTime.Now;
                int resutl = HR_SalaryIncrementPackageRulesManager.InsertHR_SalaryIncrementPackageRules(hR_SalaryIncrementPackageRules);
                //Response.Redirect("AdminDisplayHR_SalaryIncrementPackageRules.aspx");
                lblSalaryIncrementMsg.Text = "Salary Increment Information is saved";
            }
            else
            {
                lblSalaryIncrementMsg.Text = "Employee information is exist";
                lblSalaryIncrementMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {

            lblSalaryIncrementMsg.Text = "Employee is not specified.";
            lblSalaryIncrementMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnAddProvidenedFund_Click(object sender, EventArgs e)
    {

        if (hfEmployeeID.Value != null)
        {
            if (!HR_ProvidentfundContributionManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
            {
                HR_ProvidentfundContribution hR_ProvidentfundContribution = new HR_ProvidentfundContribution();
                hR_ProvidentfundContribution.EmployeeID = hfEmployeeID.Value.ToString();
                hR_ProvidentfundContribution.ProvidentfundRulesID = Convert.ToInt32(ddlProvidentfundPercentage.SelectedValue);
                hR_ProvidentfundContribution.Amount = decimal.Parse(txtSecurityMoney.Text);
                string userID = Profile.card_id;
                hR_ProvidentfundContribution.AddedBy = userID;
                hR_ProvidentfundContribution.AddedDate = DateTime.Now;
                hR_ProvidentfundContribution.ModifiedBy = userID;
                hR_ProvidentfundContribution.ModifiedDate = DateTime.Now;
                if (Convert.ToInt32(ddlProvidentfundPercentage.SelectedValue) != 0)
                {
                    int resutl = HR_ProvidentfundContributionManager.InsertHR_ProvidentfundContribution(hR_ProvidentfundContribution);
                    lblProvidenedFundMsg.Text = "This Information is saved";
                    lblProvidenedFundMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblProvidenedFundMsg.Text = "Select vaild value";
                    lblProvidenedFundMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblProvidenedFundMsg.Text = "Employee's information is exist.";
                lblProvidenedFundMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblProvidenedFundMsg.Text = "Employee is not specified.";
            lblProvidenedFundMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnUpdateProvidenedFund_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            HR_ProvidentfundContribution hR_ProvidentfundContribution = new HR_ProvidentfundContribution();
            hR_ProvidentfundContribution.EmployeeID = hfEmployeeID.Value.ToString();
            hR_ProvidentfundContribution.ProvidentfundRulesID = Convert.ToInt32(ddlProvidentfundPercentage.SelectedValue);
            hR_ProvidentfundContribution.Amount = decimal.Parse(txtSecurityMoney.Text); 
            string userID = Profile.card_id;
            hR_ProvidentfundContribution.AddedBy = userID;
            hR_ProvidentfundContribution.AddedDate = DateTime.Now;
            hR_ProvidentfundContribution.ModifiedBy = userID;
            hR_ProvidentfundContribution.ModifiedDate = DateTime.Now;
            if (Convert.ToInt32(ddlProvidentfundPercentage.SelectedValue) != 0)
            {
                if (hdnProvidentFundContributionID.Value != string.Empty)
                {
                    hR_ProvidentfundContribution.ProvidentfundContributionID = Convert.ToInt32(hdnProvidentFundContributionID.Value);
                    bool resutl = HR_ProvidentfundContributionManager.UpdateHR_ProvidentfundContribution(hR_ProvidentfundContribution);
                    lblProvidenedFundMsg.Text = "This Information is updated successfully.";
                    lblProvidenedFundMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    int resutl = HR_ProvidentfundContributionManager.InsertHR_ProvidentfundContribution(hR_ProvidentfundContribution);
                    hdnProvidentFundContributionID.Value = resutl.ToString();
                    lblProvidenedFundMsg.Text = "This Information is saved successfully";
                    lblProvidenedFundMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                lblProvidenedFundMsg.Text = "Select vaild value";
                lblProvidenedFundMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblProvidenedFundMsg.Text = "Employee is not specified.";
            lblProvidenedFundMsg.ForeColor = System.Drawing.Color.Red;
        }
        UpdatePanel1.Update();
    }

    protected void btnAddOvertimePackageRule_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            if (!HR_EmployeeOverTimePackageManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
            {
                HR_EmployeeOverTimePackage hR_OverTime = new HR_EmployeeOverTimePackage();
                //	hR_OverTime.OverTimeID=  int.Parse(ddlOverTimeID.SelectedValue);
                hR_OverTime.EmployeeID = hfEmployeeID.Value.ToString();
                hR_OverTime.OverTimePackageID = int.Parse(ddlOverTimePackID.SelectedValue);
                hR_OverTime.OverTimeTakaPerHour = decimal.Parse(txtOverTimeTakaPerHour.Text);
                hR_OverTime.OverTimeFlag = bool.Parse(radOverTimeFlag.SelectedValue);
                hR_OverTime.DayMonth = txtMonthlyTotalHour.Text;
                hR_OverTime.OverTimeDate = DateTime.Today;
                string userID = Profile.card_id;
                hR_OverTime.AddedBy = userID;
                hR_OverTime.AddedDate = DateTime.Now;
                hR_OverTime.ModifiedBy = userID;
                hR_OverTime.ModifiedDate = DateTime.Now;
                int resutl = HR_EmployeeOverTimePackageManager.InsertHR_EmployeeOverTimePackage(hR_OverTime);
                lblOvertimePackageRuleMsg.Text = "Overtime package rules Information is saved";
                lblOvertimePackageRuleMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblOvertimePackageRuleMsg.Text = "Employee informtion is exist.";
                lblOvertimePackageRuleMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblOvertimePackageRuleMsg.Text = "Employee is not specified.";
            lblOvertimePackageRuleMsg.ForeColor = System.Drawing.Color.Red;
        }
        UpdatePanel1.Update();
    }    

    protected void btnSalaryAdjustmentListRules_Click(object sender, EventArgs e)
    {
        if (hfEmployeeID.Value != null)
        {
            if (HR_SalaryAdjustmentListRulesManager.IsEmployeeExist(hfEmployeeID.Value.ToString()))
            {
                HR_SalaryAdjustmentListRulesManager.DeleteSalaryAdjustmentListRulesByEmployeeID(hfEmployeeID.Value.ToString());
            }
            HR_SalaryAdjustmentListRules item = new HR_SalaryAdjustmentListRules();

            item.EmployeeID = hfEmployeeID.Value.ToString();
            item.SalaryAdjustmentGroupID = Convert.ToInt32(ddlAdjustmentGroup.SelectedValue);
            string userID = Profile.card_id;
            item.AddedBy = userID;
            item.AddedDate = DateTime.Now;
            item.UpdatedBy = userID;
            item.UpdatedDate = DateTime.Now;
            HR_SalaryAdjustmentListRulesManager.InsertSalaryAdjustmentListRules(item);
            lblSalaryAdjustmentGroupMsg.Text = "This information is saved";
            lblSalaryAdjustmentGroupMsg.ForeColor = System.Drawing.Color.Green;

            //}
            //else
            //{
            //    lblSalaryAdjustmentGroupMsg.Text = "Employee information is exist.";
            //    lblSalaryAdjustmentGroupMsg.ForeColor = System.Drawing.Color.Red;
            //}
        }
        else
        {
            lblSalaryAdjustmentGroupMsg.Text = "Employee is not specified.";
            lblSalaryAdjustmentGroupMsg.ForeColor = System.Drawing.Color.Red;
        }
        UpdatePanel1.Update();
    }

    protected void ddlAdjustmentGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvHR_AdjustmentList.DataSource = HR_SalaryAdjustmentListManager.GetSalaryAdjustmentListBySalaryAdjustmenGroupID(Convert.ToInt32(ddlAdjustmentGroup.SelectedValue));
        gvHR_AdjustmentList.DataBind();
    }

    #endregion ---------- Events--------------------------------------------------------------------------------
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        if (radSalaryRules.SelectedIndex == 1)
        {
            ddlPackage.SelectedIndex = 1;
            ddlPackage_SelectedIndexChanged(this,new EventArgs());
        }
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

    protected void lbSelectEmployeeSchedule_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        hfEmployeeScheduleID.Value = id.ToString();
        
        btnUpdateEmployeeSchedule.Visible = true;

        EmployeeSchedule employeeSchedule = new EmployeeSchedule();
        employeeSchedule = EmployeeScheduleManager.GetEmployeeScheduleByID(id);

        ddlClassDay.SelectedIndex = employeeSchedule.ClassDayID - 1;
        ddlStartHour.SelectedValue = employeeSchedule.StartTime.Split(':')[0].Trim();
        ddlStartMin.SelectedValue = employeeSchedule.StartTime.Split(':')[1].Split(' ')[0].Trim();
        ddlStartTT.SelectedValue = employeeSchedule.StartTime.Split(':')[1].Split(' ')[1].Trim();

        ddlEndHour.SelectedValue = employeeSchedule.EndTime.Split(':')[0].Trim();
        ddlEndMin.SelectedValue = employeeSchedule.EndTime.Split(':')[1].Split(' ')[0].Trim();
        ddlEndTT.SelectedValue = employeeSchedule.EndTime.Split(':')[1].Split(' ')[1].Trim();
    }
    protected void lbDeleteEmployeeSchedule_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = EmployeeScheduleManager.DeleteEmployeeSchedule(Convert.ToInt32(linkButton.CommandArgument));
        showEmployeeScheduleGrid();
    }

    private void showEmployeeScheduleGrid()
    {
        btnUpdateEmployeeSchedule.Visible = false;
        gvEmployeeSchedule.DataSource = EmployeeScheduleManager.GetAllEmployeeSchedulesByEmployeeID(Request.QueryString["ID"]);
        gvEmployeeSchedule.DataBind();
    }

    protected void btnAddEmployeeSchedule_Click(object sender, EventArgs e)
    {
        EmployeeSchedule employeeSchedule = new EmployeeSchedule();

        employeeSchedule.EmployeeID = Request.QueryString["ID"];
        employeeSchedule.ClassDayID = ddlClassDay.SelectedIndex +1;
        employeeSchedule.StartTime = ddlStartHour.SelectedValue+":"+ddlStartMin.SelectedValue+" "+ddlStartTT.SelectedValue;
        employeeSchedule.EndTime = ddlEndHour.SelectedValue + ":" + ddlEndMin.SelectedValue + " " + ddlEndTT.SelectedValue;
        employeeSchedule.RowStatusID = 1;
        employeeSchedule.AddedBy = Profile.card_id;
        employeeSchedule.AddedDate = DateTime.Now;
        employeeSchedule.UpdatedBy = Profile.card_id;
        employeeSchedule.UpdateDate = DateTime.Now;
        int resutl = EmployeeScheduleManager.InsertEmployeeSchedule(employeeSchedule);
        showEmployeeScheduleGrid();
    }
    protected void btnUpdateEmployeeSchedule_Click(object sender, EventArgs e)
    {
        EmployeeSchedule employeeSchedule = new EmployeeSchedule();
        employeeSchedule.EmployeeScheduleID = Int32.Parse(hfEmployeeScheduleID.Value);

        employeeSchedule.EmployeeID = Request.QueryString["ID"];
        employeeSchedule.ClassDayID = ddlClassDay.SelectedIndex + 1;
        employeeSchedule.StartTime = ddlStartHour.SelectedValue + ":" + ddlStartMin.SelectedValue + " " + ddlStartTT.SelectedValue;
        employeeSchedule.EndTime = ddlEndHour.SelectedValue + ":" + ddlEndMin.SelectedValue + " " + ddlEndTT.SelectedValue;
        employeeSchedule.RowStatusID = 1;
        employeeSchedule.AddedBy = Profile.card_id;
        employeeSchedule.AddedDate = DateTime.Now;
        employeeSchedule.UpdatedBy = Profile.card_id;
        employeeSchedule.UpdateDate = DateTime.Now;
        bool result = EmployeeScheduleManager.UpdateEmployeeSchedule(employeeSchedule);
        showEmployeeScheduleGrid();
    }
}

