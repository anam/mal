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
public partial class AdminSTD_Fees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_FeesData();
            Session["fees"] = null;
            pnStudentDetails.Visible = false;
            FeesTypeIDLoad();
            StudentIDLoad();
            CourseIDLoad();
            RowStatusIDLoad();
            divReceivePayment.Visible = false;
            if (Request.QueryString["ReceivePayment"] != null)
            {
                divSearchStudent.Visible = true;
                btnAdd.Visible = false;
                divAddNewInstallment.Visible = false;
                btnUpdate.Visible = false;
                divShowInstallment.Visible = true;
                divReceivePayment.Visible = false;
                //ddlCourseID.SelectedValue = Request.QueryString["CourseID"];
                //hfStudentID.Value = Request.QueryString["StudentID"];
                //showSTD_FeesDataByStudentIDnCourseID();

            }
            else
                if (Request.QueryString["StudentID"] != null)
                {
                    divSearchStudent.Visible = true;
                    btnAdd.Visible = false;
                    divAddNewInstallment.Visible = false;
                    btnUpdate.Visible = false;
                    divShowInstallment.Visible = true;
                    ddlCourseID.SelectedValue = Request.QueryString["CourseID"];
                    ddlCourseIDReceived.SelectedValue = Request.QueryString["CourseID"];
                    hfStudentID.Value = Request.QueryString["StudentID"];
                    showSTD_FeesDataByStudentIDnCourseID();
                    btnVarify_OnClick(this, new EventArgs());
                }
                else
                {
                    divSearchStudent.Visible = false;
                    btnAdd.Visible = false;
                    divAddNewInstallment.Visible = false;
                    divShowInstallment.Visible = false;
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (StudentCodeVarification())
        {
            foreach (GridViewRow gr in gvFeesAdd.Rows)
            {
                TextBox txtSubmissionDate = (TextBox)gr.FindControl("txtSubmissionDate");
                TextBox txtAmount = (TextBox)gr.FindControl("txtAmount");

                HiddenField hfFeesID = (HiddenField)gr.FindControl("hfFeesID");

                STD_Fees sTD_Fees = new STD_Fees();
                sTD_Fees.FeesName = txtFeesName.Text;
                sTD_Fees.Amount = decimal.Parse(txtAmount.Text);
                sTD_Fees.FeesTypeID = 1; //installment
                sTD_Fees.SubmissionDate = DateTime.Parse(txtSubmissionDate.Text);
                sTD_Fees.SubmitedDate = "";
                sTD_Fees.StudentID = hfStudentID.Value;
                sTD_Fees.CourseID = int.Parse(ddlCourseID.SelectedValue);
                sTD_Fees.AddedBy = Profile.card_id;
                sTD_Fees.AddedDate = DateTime.Now;
                sTD_Fees.UpdatedBy = Profile.card_id;
                sTD_Fees.UpdateDate = DateTime.Now;
                sTD_Fees.RowStatusID = int.Parse("1");
                sTD_Fees.Remarks = txtRemarks.Text;
                sTD_Fees.IsPaid = false;
                int resutl = STD_FeesManager.InsertSTD_Fees(sTD_Fees);
            }

            btnAdd.Visible = false;
            showSTD_FeesDataByStudentIDnCourseID();
            divAddNewInstallment.Visible = false;
            divShowInstallment.Visible = true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //STD_Fees sTD_Fees = new STD_Fees ();
        //sTD_Fees.FeesID=  int.Parse(Request.QueryString["ID"].ToString());
        //sTD_Fees.FeesName=  txtFeesName.Text;
        //sTD_Fees.Amount=  decimal.Parse(txtAmount.Text);
        //sTD_Fees.FeesTypeID=  int.Parse(ddlFeesTypeID.SelectedValue);
        //sTD_Fees.SubmissionDate=  DateTime.Parse(txtSubmissionDate.Text);
        //sTD_Fees.StudentID=  hfStudentID.Value;
        //sTD_Fees.CourseID=  int.Parse(ddlCourseID.SelectedValue);
        //sTD_Fees.AddedBy=  Profile.card_id;
        //sTD_Fees.AddedDate=  DateTime.Now;
        //sTD_Fees.UpdatedBy=  Profile.card_id;
        //sTD_Fees.UpdateDate=  DateTime.Now;
        //sTD_Fees.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
        //sTD_Fees.Remarks=  txtRemarks.Text;
        //sTD_Fees.IsPaid=  bool.Parse( radIsPaid.SelectedValue);
        //bool  resutl =STD_FeesManager.UpdateSTD_Fees(sTD_Fees);
        //Response.Redirect("AdminDisplaySTD_Fees.aspx");
    }
    private void showSTD_FeesDataByStudentIDnCourseID()
    {
        try
        {
            string studentID = Request.QueryString["StudentID"] == null ? hfStudentID.Value : Request.QueryString["StudentID"];
            string courseID = Request.QueryString["CourseID"] == null ? ddlCourseID.SelectedValue : Request.QueryString["CourseID"];

            if (txtStudentCode.Text == "")
            {
                txtStudentCode.Text = STD_StudentManager.GetSTD_StudentByStudentID(studentID).StudentCode;
                txtStudentCodeSearch.Text = txtStudentCode.Text;
            }

            DataSet dsFeesByStudentIDnCourseID = STD_FeesManager.GetSTD_StudentByStudentID(studentID, int.Parse(courseID));
            if (dsFeesByStudentIDnCourseID != null)
            {
                if (dsFeesByStudentIDnCourseID.Tables[0].Rows.Count == 0)
                {
                    lblMessageForList.Text = "No Installment has fixed before for that Student ID and Course";
                }

                List<STD_Fees> fees = new List<STD_Fees>();

                fees = new List<STD_Fees>();

                foreach (DataRow drFeesByStudentIDnCourseID in dsFeesByStudentIDnCourseID.Tables[0].Rows)
                {
                    STD_Fees sTD_Fees = new STD_Fees();
                    sTD_Fees.FeesID = int.Parse(drFeesByStudentIDnCourseID["FeesID"].ToString());
                    sTD_Fees.FeesName = drFeesByStudentIDnCourseID["FeesName"].ToString();
                    sTD_Fees.Amount = decimal.Parse(drFeesByStudentIDnCourseID["Amount"].ToString());
                    sTD_Fees.FeesTypeID = int.Parse(drFeesByStudentIDnCourseID["FeesTypeID"].ToString());
                    sTD_Fees.SubmissionDate = DateTime.Parse(drFeesByStudentIDnCourseID["SubmissionDate"].ToString());
                    sTD_Fees.SubmitedDate = drFeesByStudentIDnCourseID["SubmitedDate"].ToString();
                    sTD_Fees.StudentID = studentID;
                    sTD_Fees.CourseID = int.Parse(courseID);
                    sTD_Fees.AddedBy = drFeesByStudentIDnCourseID["AddedBy"].ToString();
                    sTD_Fees.AddedDate = DateTime.Parse(drFeesByStudentIDnCourseID["AddedDate"].ToString());
                    sTD_Fees.UpdatedBy = Profile.card_id;
                    sTD_Fees.UpdateDate = DateTime.Now;
                    sTD_Fees.RowStatusID = int.Parse(drFeesByStudentIDnCourseID["RowStatusID"].ToString()); ;
                    sTD_Fees.Remarks = drFeesByStudentIDnCourseID["Remarks"].ToString();
                    sTD_Fees.IsPaid = bool.Parse(drFeesByStudentIDnCourseID["IsPaid"].ToString());
                    sTD_Fees.IsEnabled = !sTD_Fees.IsPaid;
                    fees.Add(sTD_Fees);
                }
                Session["fees"] = fees;
                gvFeesShow.DataSource = fees;
                gvFeesShow.DataBind();
            }
            else
            {
                lblMessageForList.Text = "No Installment has fixed before for that Student ID and Course";
            }
            //ddlFeesTypeID.SelectedValue = fees[0].FeesTypeID.ToString();
        }
        catch (Exception ex)
        {
            lblMessageForList.Text = "No Installment has fixed before for that Student ID and Course";
        }
    }

    private void FeesTypeIDLoad()
    {
        try
        {
            //DataSet ds = STD_FeesTypeManager.GetDropDownListAllSTD_FeesType();
            //ddlFeesTypeID.DataValueField = "FeesTypeID";
            //ddlFeesTypeID.DataTextField = "FeesTypeName";
            //ddlFeesTypeID.DataSource = ds.Tables[0];
            //ddlFeesTypeID.DataBind();
            //ddlFeesTypeID.Items.Insert(0, new ListItem("Select FeesType >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void StudentIDLoad()
    {
        //try {
        //DataSet ds = STD_StudentManager.GetDropDownListAllSTD_Student();
        //ddlStudentID.DataValueField = "StudentID";
        //ddlStudentID.DataTextField = "StudentName";
        //ddlStudentID.DataSource = ds.Tables[0];
        //ddlStudentID.DataBind();
        //ddlStudentID.Items.Insert(0, new ListItem("Select Student >>", "0"));
        //}
        //catch (Exception ex) {
        //ex.Message.ToString();
        //}
    }
    private void CourseIDLoad()
    {
        try
        {
            DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
            ddlCourseID.DataValueField = "CourseID";
            ddlCourseID.DataTextField = "CourseName";
            ddlCourseID.DataSource = ds.Tables[0];
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("Select Course >>", "0"));

            ddlCourseIDReceived.DataValueField = "CourseID";
            ddlCourseIDReceived.DataTextField = "CourseName";
            ddlCourseIDReceived.DataSource = ds.Tables[0];
            ddlCourseIDReceived.DataBind();
            ddlCourseIDReceived.Items.Insert(0, new ListItem("Select Course >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void RowStatusIDLoad()
    {
        try
        {
            DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
            ddlRowStatusID.DataValueField = "RowStatusID";
            ddlRowStatusID.DataTextField = "RowStatusName";
            ddlRowStatusID.DataSource = ds.Tables[0];
            ddlRowStatusID.DataBind();
            ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void btnGridGenerator_Click(object sender, EventArgs e)
    {
        try
        {
            List<STD_Fees> fees = new List<STD_Fees>();

            fees = new List<STD_Fees>();

            int j = 0;
            for (int i = 0; i < int.Parse(txtNoOfInstallment.Text); i++)
            {
                STD_Fees fee = new STD_Fees();
                fee.FeesID = i;
                fee.SubmissionDate = txtInstallmentDuration.Text != "" ? DateTime.Now.AddDays((i * int.Parse(txtInstallmentDuration.Text))) : DateTime.Now;
                if (txtDiscount.Text != "" && j == 0 && decimal.Parse(txtInstallmentAmount.Text) > decimal.Parse(txtDiscount.Text))
                {
                    fee.Amount = decimal.Parse(txtInstallmentAmount.Text) - (decimal.Parse(txtInstallmentAmount.Text) * decimal.Parse(txtDiscount.Text)) / 100;
                    j++;
                }
                else
                {
                    fee.Amount = decimal.Parse(txtInstallmentAmount.Text);
                }

                fee.IsPaid = false;
                fee.IsEnabled = false;
                fees.Add(fee);
            }

            Session["fees"] = fees;

            gvFeesAdd.DataSource = fees;
            gvFeesAdd.DataBind();

            btnAdd.Visible = true;
            divAddNewInstallment.Visible = true;
        }

        catch (Exception ex)
        {
        }
    }

    protected void btnPayAdvance_Click(object sender, EventArgs e)
    {
        try
        {
            decimal paymentAmount = Convert.ToDecimal(txtPaymentAmount.Text);

            foreach (GridViewRow row in gvFeesShow.Rows)
            {
                bool isPaid = Convert.ToBoolean(((CheckBox)row.FindControl("chkIspaid")).Checked);
                if (!isPaid)
                {
                    int feesID = Convert.ToInt32(((HiddenField)row.FindControl("hfFeesID")).Value);

                    STD_Fees currentFee = STD_FeesManager.GetSTD_FeesByFeesID(feesID);

                    if (paymentAmount >= currentFee.Amount)
                    {
                        #region Fully Payment
                        paymentAmount -= currentFee.Amount;
                        currentFee.IsPaid = true;
                        currentFee.SubmitedDate = DateTime.Today.ToString();
                        currentFee.UpdatedBy = Profile.card_id;
                        currentFee.UpdateDate = DateTime.Now;
                        currentFee.RowStatusID = int.Parse("1");
                        currentFee.Remarks = "Fully paid";
                        bool resutl = STD_FeesManager.UpdateSTD_Fees(currentFee);
                        #endregion
                    }

                    else if (paymentAmount > 0)
                    {
                        #region Partial Payment
                        decimal amountRemaining = currentFee.Amount - paymentAmount;

                        currentFee.IsPaid = true;
                        currentFee.SubmitedDate = DateTime.Today.ToString();
                        currentFee.Amount = paymentAmount;

                        currentFee.UpdatedBy = Profile.card_id;
                        currentFee.UpdateDate = DateTime.Now;
                        currentFee.RowStatusID = int.Parse("1");
                        currentFee.Remarks = "Partially Paid";
                        bool resutl = STD_FeesManager.UpdateSTD_Fees(currentFee);


                        //Add a new row 
                        STD_Fees newFee = new STD_Fees();
                        newFee = currentFee;
                        newFee.Amount = amountRemaining;
                        newFee.SubmissionDate = currentFee.SubmissionDate.AddMonths(1);// 1 Month Later, Default
                        newFee.SubmitedDate = "";
                        newFee.AddedBy = Profile.card_id;
                        newFee.AddedDate = DateTime.Now;
                        newFee.Remarks = "Partially payment done but Something remaining";
                        newFee.IsPaid = false;
                        STD_FeesManager.InsertSTD_Fees(newFee);
                        #endregion
                        paymentAmount = 0;
                        break;
                    }
                }
            }
            txtPaymentAmount.Text = "";
            showSTD_FeesDataByStudentIDnCourseID();
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbPaid_Click(object sender, EventArgs e)
    {
        if (IsValidStudent(txtStudentCode.Text))
        {
            Button linkButton = new Button();
            linkButton = (Button)sender;
            int id;
            id = Convert.ToInt32(linkButton.CommandArgument);

            //pay it in the fees table
            STD_Fees sTD_FeesUpdate = new STD_Fees();

            sTD_FeesUpdate = STD_FeesManager.GetSTD_FeesByFeesID(id);
            sTD_FeesUpdate.IsPaid = true;
            sTD_FeesUpdate.SubmitedDate = DateTime.Today.ToString();
            sTD_FeesUpdate.UpdatedBy = Profile.card_id;
            sTD_FeesUpdate.UpdateDate = DateTime.Now;
            sTD_FeesUpdate.RowStatusID = int.Parse("1");
            sTD_FeesUpdate.Remarks = "Fully paid";
            bool resutl = STD_FeesManager.UpdateSTD_Fees(sTD_FeesUpdate);

            //for accounting we need to process

            showSTD_FeesDataByStudentIDnCourseID();


            Response.Redirect("~/Accounting/JournalDoubleEntry.aspx?DrOrCr=Cr&SubBasicAccountID=20&AccountID=31&UserTypeID=1&StudentCode=" + txtStudentCode.Text + "&UserTypeIDMoney=2&Amount=" + sTD_FeesUpdate.Amount);
        }
        else
        {
            lblTest.Text = "StudentCode is not exist.";
        }
    }


    protected void lbPartiallyPaid_Click(object sender, EventArgs e)
    {
        Button linkButton = new Button();
        linkButton = (Button)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);


        //update the exiting 1 
        decimal amountRemaining = 0;

        STD_Fees sTD_FeesUpdate = new STD_Fees();
        STD_Fees sTD_FeesNew = new STD_Fees();

        sTD_FeesUpdate = STD_FeesManager.GetSTD_FeesByFeesID(id);
        amountRemaining = sTD_FeesUpdate.Amount;

        sTD_FeesUpdate.IsPaid = true;
        sTD_FeesUpdate.SubmitedDate = DateTime.Today.ToString();
        sTD_FeesUpdate.Amount = getPartialPaymentByFeesID(id);
        amountRemaining -= sTD_FeesUpdate.Amount;
        sTD_FeesUpdate.UpdatedBy = Profile.card_id;
        sTD_FeesUpdate.UpdateDate = DateTime.Now;
        sTD_FeesUpdate.RowStatusID = int.Parse("1");
        sTD_FeesUpdate.Remarks = "Partially payment";
        bool resutl = STD_FeesManager.UpdateSTD_Fees(sTD_FeesUpdate);

        //Add a new row 
        sTD_FeesNew = sTD_FeesUpdate;
        sTD_FeesNew.Amount = amountRemaining;
        sTD_FeesNew.SubmissionDate = getRemainingDateByFeesID(id);
        sTD_FeesNew.SubmitedDate = "";
        sTD_FeesNew.AddedBy = Profile.card_id;
        sTD_FeesNew.AddedDate = DateTime.Now;
        sTD_FeesNew.Remarks = "Partially payment done but someting remaining";
        sTD_FeesNew.IsPaid = false;
        STD_FeesManager.InsertSTD_Fees(sTD_FeesNew);

        showSTD_FeesDataByStudentIDnCourseID();
    }

    private decimal getPartialPaymentByFeesID(int feesID)
    {
        foreach (GridViewRow gr in gvFeesShow.Rows)
        {
            TextBox txtPartiallyPaidAmount = (TextBox)gr.FindControl("txtPartiallyPaidAmount");

            HiddenField hfFeesID = (HiddenField)gr.FindControl("hfFeesID");
            if (hfFeesID.Value == feesID.ToString())
            {
                return decimal.Parse(txtPartiallyPaidAmount.Text);
            }
        }
        return 0;
    }

    private DateTime getRemainingDateByFeesID(int feesID)
    {
        foreach (GridViewRow gr in gvFeesShow.Rows)
        {
            TextBox txtRemainingSubmissionDate = (TextBox)gr.FindControl("txtRemainingSubmissionDate");

            HiddenField hfFeesID = (HiddenField)gr.FindControl("hfFeesID");
            if (hfFeesID.Value == feesID.ToString())
            {
                return DateTime.Parse(txtRemainingSubmissionDate.Text);
            }
        }
        return DateTime.Now;
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        STD_FeesManager.DeleteSTD_Fees(id);

        showSTD_FeesDataByStudentIDnCourseID();
    }
    protected void btnPaymentReceive_Click(object sender, EventArgs e)
    {

    }

    protected void btnSearchStudent_Click(object sender, EventArgs e)
    {

        if (ddlCourseIDReceived.SelectedIndex == 0 || txtStudentCodeSearch.Text == "")
        {
            lblInstallmentSearchMessage.Text = "Please enter the Student ID and Select the Course";
            return;
        }

        try
        {
            //call the methord by which we can get the student info
            STD_Student sTD_Student = new STD_Student();
            sTD_Student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCodeSearch.Text);

            if (sTD_Student == null)
            {
                lblInstallmentSearchMessage.Text = "There is no registured student by this ID and in the selected Course";
                return;
            }


            //divReceivePayment.Visible = true;
            ddlCourseID.SelectedValue = ddlCourseIDReceived.SelectedValue;
            hfStudentID.Value = sTD_Student.StudentID;
            showSTD_FeesDataByStudentIDnCourseID();
        }
        catch (Exception ex)
        {
            lblInstallmentSearchMessage.Text = "Please enter the Student ID and Select the Course";
        }
    }
    protected void btnVarify_OnClick(object sender, EventArgs e)
    {
        StudentCodeVarification();
    }

    private bool StudentCodeVarification()
    {
        STD_Student students = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text.Trim());
        if (students != null)
        {
            pnStudentDetails.Visible = true;
            lblName.Text = students.StudentName;
            lblContact.Text = students.Mobile;
            imgStudent.ImageUrl = students.PPSizePhoto;

            hfStudentID.Value = students.StudentID;
            lblTest.Text = "Student Code is Exist. <a target='_blank' style='color:blue;' href='../Student/AdminDetailsSTD_Student.aspx?ID=" + students.StudentID + "'>Click here for Details</a>";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is Exist')", true);
            return true;
        }
        else
        {
            lblTest.Text = "Student Code is not Exist";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is not Exist')", true);
        }
        return false;
    }

    private bool IsValidStudent(string studentCode)
    {
        DataSet stuents = STD_StudentManager.GetAllSTD_Students();

        foreach (DataRow student in stuents.Tables[0].Rows)
        {
            if (student["StudentCode"].ToString().Trim() == txtStudentCode.Text)
                return true;
        }
        return false;
    }
    protected void gvFeesAdd_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        double sum = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtAmount = (TextBox)e.Row.FindControl("txtAmount");
            sum = Convert.ToDouble(Session["sum"]) + double.Parse(txtAmount.Text);

            Session["sum"] = sum;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");
            lblTotalAmount.Text = Session["sum"] != null ? Session["sum"].ToString() : "";
            Session["sum"] = null;
        }
    }
    protected void txtAmount_OnTextChanged(object sender, EventArgs e)
    {
        int i = 0;
        List<STD_Fees> fees = new List<STD_Fees>();

        foreach (GridViewRow row in gvFeesAdd.Rows)
        {
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            STD_Fees fee = new STD_Fees();
            fee.FeesID = i;
            fee.SubmissionDate = txtInstallmentDuration.Text != "" ? DateTime.Now.AddDays((i * int.Parse(txtInstallmentDuration.Text))) : DateTime.Now;
            fee.Amount = decimal.Parse(txtAmount.Text);
            fee.IsPaid = false;
            fee.IsEnabled = false;
            fees.Add(fee);
            i++;
        }
        Session["fees"] = fees;
        gvFeesAdd.DataSource = fees;
        gvFeesAdd.DataBind();

    }

    protected void gvFeesShow_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal PaidTotal = 0, UnpaidTotal = 0;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtAmount = (TextBox)e.Row.FindControl("txtListAmount");
            CheckBox chkIspaid = (CheckBox)e.Row.FindControl("chkIspaid");

            if (chkIspaid.Checked)
            {
                PaidTotal = Convert.ToDecimal(Session["PaidTotal"]) + decimal.Parse(txtAmount.Text);

                Session["PaidTotal"] = PaidTotal;
            }
            else
            {
                UnpaidTotal = Convert.ToDecimal(Session["UnpaidTotal"]) + decimal.Parse(txtAmount.Text);

                Session["UnpaidTotal"] = UnpaidTotal;
            }


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
            Label lblUnpaidAmount = (Label)e.Row.FindControl("lblUnpaidAmount");
            lblPaidAmount.Text = Session["PaidTotal"] != null ? Session["PaidTotal"].ToString() : "";
            lblUnpaidAmount.Text = Session["UnpaidTotal"] != null ? Session["UnpaidTotal"].ToString() : "";

            Session["PaidTotal"] = null;
            Session["UnpaidTotal"] = null;
        }
    }


    protected void lbDeleteFees_Click(object sender, EventArgs e)
    {
        try
        {
            List<STD_Fees> fees = new List<STD_Fees>();
            fees = (List<STD_Fees>)Session["fees"];

            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            fees.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
            for (int i = 0; i < fees.Count; i++)
            {
                fees[i].FeesID = i;
            }
            Session["fees"] = fees;
            gvFeesAdd.DataSource = fees;
            gvFeesAdd.DataBind();
        }
        catch (Exception ex)
        { }
    }
}