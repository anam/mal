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
            SubjectIDLoad();
            Session["fees"] = null;
            pnStudentDetails.Visible = false;
            //FeesTypeIDLoad();
            StudentIDLoad();
            CourseIDLoad();
            RowStatusIDLoad();
            AccountIDLoad();//this is for frees type
            //initially load the 
            ddlAccountID.SelectedValue = "31";
            ddlAccountID_SelectedIndexChanged(this, new EventArgs());

            //loadForInstallation(false);
            //divReceivePayment.Visible = false;
            if (Request.QueryString["ReceivePayment"] != null)
            {
                divSearchStudent.Visible = true;
                //btnAdd.Visible = false;
                divAddNewInstallment.Visible = false;
                btnUpdate.Visible = false;
                divShowInstallment.Visible = true;
                //divReceivePayment.Visible = false;
                //ddlCourseID.SelectedValue = Request.QueryString["CourseID"];
                //hfStudentID.Value = Request.QueryString["StudentID"];
                //showSTD_FeesDataByStudentIDnCourseID();

            }
            else
                if (Request.QueryString["StudentID"] != null)
                {
                    divSearchStudent.Visible = true;
                    //btnAdd.Visible = false;
                    divAddNewInstallment.Visible = false;
                    btnUpdate.Visible = false;
                    divShowInstallment.Visible = true;
                    ddlCourseID.SelectedValue = Request.QueryString["CourseID"];
                    ddlCourseIDReceived.SelectedValue = Request.QueryString["CourseID"];
                    hfStudentID.Value = Request.QueryString["StudentID"];
                    showSTD_FeesDataByStudentIDnCourseID();
                    btnVarify_OnClick(this, new EventArgs());
                    btnSearchStudent_Click(this, new EventArgs());
                }
                else if (Request.QueryString["StudentCode"] != null)
                {
                    divSearchStudent.Visible = true;
                    //btnAdd.Visible = false;
                    divAddNewInstallment.Visible = false;
                    btnUpdate.Visible = false;
                    divShowInstallment.Visible = true;
                    txtStudentCodeSearch.Text = Request.QueryString["StudentCode"];
                    btnVarify_OnClick(this, new EventArgs());
                    btnSearchStudent_Click(this, new EventArgs());
                    showSTD_FeesDataByStudentIDnCourseID();
                    
                }
                else
                {
                    //divSearchStudent.Visible = false;
                    //btnAdd.Visible = false;
                    divAddNewInstallment.Visible = false;
                    divShowInstallment.Visible = false;
                }

            loadStudentSubjectData();
        }
    }

    private void SubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetAllSTD_Subjects();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "CourseSubject";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void AccountIDLoad()
    {
        try
        {
            DataSet ds = ACC_AccountManager.GetACC_AccountBySubBasicAccountID(20,true);//20=student fees
            ddlAccountID.DataValueField = "AccountID";
            ddlAccountID.DataTextField = "AccountName";
            ddlAccountID.DataSource = ds.Tables[0];
            ddlAccountID.DataBind();
            ddlAccountID.Items.Insert(0, new ListItem("Select Free type >>", "0"));

            foreach (ListItem item in ddlAccountID.Items)
            {
                if (item.Value == "29")
                {
                    ddlAccountID.Items.Remove(item);
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    private void showPaymentHistory()
    {
        DataSet dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAllByUserIDStudentFees(0,0, 0, hfStudentID.Value, 1, "", "");
        //}

        string html = "<table><tr style='font-weight:bold;'><td  style='background-color:#46BEDF;border:1px solid black;'>S. No.</td><td style='background-color:#46BEDF;border:1px solid black;'>Head Name</td><td style='background-color:#46BEDF;border:1px solid black;'>Date</td><td style='background-color:#46BEDF;border:1px solid black; width:70px;text-align:right;'>Debit</td><td style='background-color:#46BEDF;border:1px solid black;text-align:right; width:70px;'>Credit</td>";
        int serialNo = 1;
        decimal debit = 0;
        decimal credit = 0;

        foreach (DataRow dr in dsJournal.Tables[0].Rows)
        {
            html += "<tr " + (serialNo % 2 == 0 ? "style='background-color:#EBEAEA;'" : "") + ">";
            html += "<td style='border:1px solid black;text-align:right;padding-right:5px;'>" + serialNo++ + "</td>";
            html += "<td style='border:1px solid black;'>" + dr["HeadName"].ToString() + "</td>";
            html += "<td style='border:1px solid black;'>" + DateTime.Parse(dr["AddedDate"].ToString()).ToString("dd MMM yyyy") + "</td>";
            html += "<td style='border:1px solid black;text-align:right;'>" + decimal.Parse(dr["Debit"].ToString()).ToString("0,0.00") + "</td>";
            debit += decimal.Parse(dr["Debit"].ToString());
            credit += decimal.Parse(dr["Credit"].ToString());
            html += "<td style='border:1px solid black;text-align:right;'>" + decimal.Parse(dr["Credit"].ToString()).ToString("0,0.00") + "</td>";
            html += "</tr>";
        }


        html += "<tr><td></td><td></td><td>Total:</td><td style='text-align:right;border:1px solid black;'>" + debit.ToString("0,0.00") + "</td><td style='text-align:right;border:1px solid black;'>" + credit.ToString("0,0.00") + "</td>";
        decimal diff = debit - credit;
        html += "<tr><td></td><td></td><td>Balance:</td><td style='text-align:right;border:1px solid black;'>" + (diff > 0 ? "(Dr)" + diff.ToString("0,0.00") : "") + "</td><td style='text-align:right;border:1px solid black;'>" + (diff < 0 ? "(Cr)" + (diff * (-1)).ToString("0,0.00") : "") + "</td>";
        html += "</table>";
        lblJournal.Visible = true;
        lblJournal.Text = html;
    }

    private STD_FeesMaster insertFeesMaster(int accountID)
    {
        //add in the FeesMaster 
        STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
        //	sTD_FeesMaster.FeesMasterID=  int.Parse(ddlFeesMasterID.SelectedValue);
        DataSet ds = STD_FeesMasterManager.GetSTD_FeesMasterByStudentIDnCourseIDnFeesTypeID(hfStudentID.Value, int.Parse(ddlCourseIDReceived.SelectedValue), accountID);
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
            sTD_FeesMaster.FeesMasterName = "";
            sTD_FeesMaster.TotalPayment += decimal.Parse(txtTotalAmount.Text);
            sTD_FeesMaster.Discount += decimal.Parse(txtDiscount.Text);
            sTD_FeesMaster.TotalPaymentNeedtoPay += decimal.Parse(txtTotalAmountNeedToPay.Text);
            sTD_FeesMaster.IsPaid = false;
            sTD_FeesMaster.PaymentStatusID = int.Parse("1");
            sTD_FeesMaster.ExtraField2 = (decimal.Parse(sTD_FeesMaster.ExtraField2) + decimal.Parse(txtTotalAmountNeedToPay.Text)).ToString();
            //sTD_FeesMaster.ExtraField3 +=  "  "+ txtRemarkForReceipt.Text;
            sTD_FeesMaster.UpdatedBy = Profile.card_id;
            sTD_FeesMaster.UpdateDate = DateTime.Now;
            sTD_FeesMaster.RowStatusID = int.Parse("1");
            STD_FeesMasterManager.UpdateSTD_FeesMaster(sTD_FeesMaster);
        }
        else
        {

            sTD_FeesMaster.FeesMasterName = "";
            sTD_FeesMaster.TotalPayment = decimal.Parse(txtTotalAmount.Text);
            sTD_FeesMaster.Discount = decimal.Parse(txtDiscount.Text);
            sTD_FeesMaster.TotalPaymentNeedtoPay = decimal.Parse(txtTotalAmountNeedToPay.Text);
            sTD_FeesMaster.FeesTypeID = accountID;
            sTD_FeesMaster.SubmissionDate = DateTime.Today;
            sTD_FeesMaster.SubmitedDate = "";
            sTD_FeesMaster.StudentID = hfStudentID.Value;
            sTD_FeesMaster.CourseID = int.Parse(ddlCourseIDReceived.SelectedValue);
            sTD_FeesMaster.Remarks = txtRemarks.Text;
            sTD_FeesMaster.IsPaid = false;
            sTD_FeesMaster.PaymentStatusID = int.Parse("1");
            sTD_FeesMaster.ExtraField1 = "0";
            sTD_FeesMaster.ExtraField2 = txtTotalAmountNeedToPay.Text;
            sTD_FeesMaster.ExtraField3 = txtRemarkForReceipt.Text;
            sTD_FeesMaster.ExtraField4 = "";
            sTD_FeesMaster.ExtraField5 = "";
            sTD_FeesMaster.AddedBy = Profile.card_id;
            sTD_FeesMaster.AddedDate = DateTime.Now;
            sTD_FeesMaster.UpdatedBy = Profile.card_id;
            sTD_FeesMaster.UpdateDate = DateTime.Now;
            sTD_FeesMaster.RowStatusID = int.Parse("1");
            sTD_FeesMaster.FeesMasterID = STD_FeesMasterManager.InsertSTD_FeesMaster(sTD_FeesMaster);

        }

        return sTD_FeesMaster;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlCourseIDReceived.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Plase Select the Program from top')", true);

            return;
        }
        if (hfStudentID.Value != "" && ddlAccountID.SelectedValue!="0")
        {
            

            STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
            sTD_FeesMaster = insertFeesMaster(int.Parse(ddlAccountID.SelectedValue));


            if (ddlAccountID.SelectedValue == "31" || ddlAccountID.SelectedValue == "57")//installment fees and Paper wise fee
            {
                hfIsAdmissionFees.Value = "1";
            }

            if (ddlAccountID.SelectedValue == "31")//installment fees
            {
                foreach (GridViewRow gr in gvFeesAdd.Rows)
                {
                    TextBox txtSubmissionDate = (TextBox)gr.FindControl("txtSubmissionDate");
                    TextBox txtAmount = (TextBox)gr.FindControl("txtAmount");

                    HiddenField hfFeesID = (HiddenField)gr.FindControl("hfFeesID");

                    
                    STD_Fees sTD_Fees = new STD_Fees();
                    sTD_Fees.FeesName = sTD_FeesMaster.FeesMasterID.ToString();//it will be fees masterID
                    sTD_Fees.Amount = decimal.Parse(txtAmount.Text);
                    sTD_Fees.FeesTypeID = 1; //installment
                    sTD_Fees.SubmissionDate = DateTime.Parse(txtSubmissionDate.Text);
                    sTD_Fees.SubmitedDate = "";
                    sTD_Fees.StudentID = hfStudentID.Value;
                    sTD_Fees.CourseID = int.Parse(ddlCourseIDReceived.SelectedValue);
                    sTD_Fees.AddedBy = Profile.card_id;
                    sTD_Fees.AddedDate = DateTime.Now;
                    sTD_Fees.UpdatedBy = Profile.card_id;
                    sTD_Fees.UpdateDate = DateTime.Now;
                    sTD_Fees.RowStatusID = int.Parse("1");
                    sTD_Fees.Remarks = "0";
                    if (decimal.Parse(txtAmount.Text) != decimal.Parse("0"))
                    { sTD_Fees.IsPaid = false; }
                    else
                    sTD_Fees.IsPaid = true;
                    int resutl = STD_FeesManager.InsertSTD_Fees(sTD_Fees);
                }               
                
            }
            else
            {

                ////add in the FeesMaster 
                //STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster();
                ////	sTD_FeesMaster.FeesMasterID=  int.Parse(ddlFeesMasterID.SelectedValue);
                //sTD_FeesMaster.FeesMasterName = "";
                //sTD_FeesMaster.TotalPayment = decimal.Parse(txtTotalAmount.Text);
                //sTD_FeesMaster.Discount = decimal.Parse(txtDiscount.Text);
                //sTD_FeesMaster.TotalPaymentNeedtoPay = decimal.Parse(txtTotalAmountNeedToPay.Text);
                //sTD_FeesMaster.FeesTypeID = int.Parse(ddlAccountID.SelectedValue);
                //sTD_FeesMaster.SubmissionDate = DateTime.Today;
                //sTD_FeesMaster.SubmitedDate = "";
                //sTD_FeesMaster.StudentID = hfStudentID.Value;
                //sTD_FeesMaster.CourseID = int.Parse(ddlCourseIDReceived.SelectedValue);
                //sTD_FeesMaster.Remarks = txtRemarks.Text;
                //sTD_FeesMaster.IsPaid = false;
                //sTD_FeesMaster.PaymentStatusID = int.Parse("1");
                //sTD_FeesMaster.ExtraField1 = "0";
                //sTD_FeesMaster.ExtraField2 = txtTotalAmountNeedToPay.Text;
                //sTD_FeesMaster.ExtraField3 = "";
                //sTD_FeesMaster.ExtraField4 = "";
                //sTD_FeesMaster.ExtraField5 = "";
                //sTD_FeesMaster.AddedBy = Profile.card_id;
                //sTD_FeesMaster.AddedDate = DateTime.Now;
                //sTD_FeesMaster.UpdatedBy = Profile.card_id;
                //sTD_FeesMaster.UpdateDate = DateTime.Now;
                //sTD_FeesMaster.RowStatusID = int.Parse("1");
                //sTD_FeesMaster.FeesMasterID = STD_FeesMasterManager.InsertSTD_FeesMaster(sTD_FeesMaster);


                STD_Fees sTD_Fees = new STD_Fees();
                sTD_Fees.FeesName = sTD_FeesMaster.FeesMasterID.ToString();//it will be fees masterID
                sTD_Fees.Amount = decimal.Parse(txtTotalAmountNeedToPay.Text);
                sTD_Fees.FeesTypeID = 1; //installment
                sTD_Fees.SubmissionDate = DateTime.Today;
                sTD_Fees.SubmitedDate = "";
                sTD_Fees.StudentID = hfStudentID.Value;
                sTD_Fees.CourseID = int.Parse(ddlCourseIDReceived.SelectedValue);
                sTD_Fees.AddedBy = Profile.card_id;
                sTD_Fees.AddedDate = DateTime.Now;
                sTD_Fees.UpdatedBy = Profile.card_id;
                sTD_Fees.UpdateDate = DateTime.Now;
                sTD_Fees.RowStatusID = int.Parse("1");
                sTD_Fees.Remarks = "0";
                sTD_Fees.IsPaid = false;
                sTD_Fees.FeesID = STD_FeesManager.InsertSTD_Fees(sTD_Fees);
            }
        }

        //btnAdd.Visible = false;

        showFeesMaster();
        showSTD_FeesDataByStudentIDnCourseID();

        divAddNewInstallment.Visible = false;
        divShowInstallment.Visible = true;
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

           
            //ddlFeesTypeID.SelectedValue = fees[0].FeesTypeID.ToString();
        }
        catch (Exception ex)
        {
            lblMessageForList.Text = "No Installment has fixed before for that Student ID and Course";
        }
    }

    protected void gvSTD_FeesMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvFeesShow = (GridView)e.Row.FindControl("gvFeesShow");
            GridView gvFeesShowForInstallment = (GridView)e.Row.FindControl("gvFeesShowForInstallment");
            /*
                                             <asp:HiddenField ID="hfCourseID" runat="server" Value='<%#Eval("CourseID") %>'/>
                                                                <asp:HiddenField ID="hfFeesMasterID" runat="server" Value='<%#Eval("FeesMasterName") %>'/>
                                                                <asp:HiddenField ID="hfStudentID" runat="server" Value='<%#Eval("StudentID") %>'/>
             */
            HiddenField hfCourseID = (HiddenField)e.Row.FindControl("hfCourseID");
            HiddenField hfFeesTypeID = (HiddenField)e.Row.FindControl("hfFeesTypeID");
            HiddenField hfFeesMasterID = (HiddenField)e.Row.FindControl("hfFeesMasterID");
            HiddenField hfStudentID = (HiddenField)e.Row.FindControl("hfStudentID");
            Label lblMessage = (Label)e.Row.FindControl("lblMessage");
            Label lblDueAmount = (Label)e.Row.FindControl("lblDueAmount");
            Label lblUnpaidAmount = (Label)e.Row.FindControl("lblUnpaidAmount");

            string studentID = hfStudentID.Value;
            string courseID = hfCourseID.Value;
            //lblMessageForList.Text = "No Installment has fixed before for that Student ID and Course";
           
            DataSet dsFeesByStudentIDnCourseID = STD_FeesManager.GetSTD_FeesListByFeesMasterID(hfFeesMasterID.Value);
            if (dsFeesByStudentIDnCourseID != null)
            {
                //if (dsFeesByStudentIDnCourseID.Tables[0].Rows.Count == 0)
                //{
                //    lblMessageForList.Visible = true;
                //}
                

                List<STD_Fees> fees = new List<STD_Fees>();

                fees = new List<STD_Fees>();

                decimal due = 0;
                decimal unpaid = 0;

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

                    sTD_Fees.UnpaidAmount = sTD_Fees.Amount - decimal.Parse(sTD_Fees.Remarks);

                    if (!sTD_Fees.IsPaid)
                    {
                        if (sTD_Fees.SubmissionDate > DateTime.Today)
                        {
                            sTD_Fees.PaymentStatus = "<b style='color:Blue;'>UnPaid</b>";
                            unpaid += sTD_Fees.UnpaidAmount;
                        }
                        else
                        {
                            sTD_Fees.PaymentStatus = "<b style='color:Red;'>Due</b>";
                            due += sTD_Fees.UnpaidAmount;
                        }
                    }
                    else
                    {
                        if (sTD_Fees.Amount == decimal.Parse(sTD_Fees.Remarks))
                        {
                            sTD_Fees.PaymentStatus = "<b style='color:Green;'>Paid</b>";
                        }
                        else
                        {
                            if (sTD_Fees.SubmissionDate > DateTime.Today)
                            {
                                sTD_Fees.PaymentStatus = "<b style='color:Blue;'>Partially Unpaid</b>";
                                unpaid += sTD_Fees.UnpaidAmount;
                            }
                            else
                            {
                                sTD_Fees.PaymentStatus = "<b style='color:Red;'>Partially Due</b>";
                                due += sTD_Fees.UnpaidAmount;
                            }
                        }
                    }
                    //sTD_Fees.PaymentStatus = sTD_Fees.IsPaid ? "<b style='color:Green;'>Paid</b>" : "<b style='color:Red;'>Unpaid</b>";
                    sTD_Fees.IsEnabled = !sTD_Fees.IsPaid;
                    fees.Add(sTD_Fees);
                }

                lblUnpaidAmount.Text = unpaid.ToString().Contains('.')? unpaid.ToString().Substring(0, unpaid.ToString().IndexOf('.') + 3):unpaid.ToString();
                lblDueAmount.Text = due.ToString().Contains('.')? due.ToString().Substring(0, due.ToString().IndexOf('.') + 3):due.ToString();

                Session["fees"] = fees;

                if (hfFeesTypeID.Value != "31")
                {
                    gvFeesShow.DataSource = fees;
                    gvFeesShow.DataBind();
                    gvFeesShow.Visible = true;
                    gvFeesShowForInstallment.Visible = false;
                    lblMessage.Visible = false;
                }
                else
                {
                    gvFeesShowForInstallment.DataSource = fees;
                    gvFeesShowForInstallment.DataBind();
                    gvFeesShow.Visible = false;
                    gvFeesShowForInstallment.Visible = true;
                    lblMessage.Visible = true;
                }
            }
            //else
            //{
            //    lblMessageForList.Text = "No Installment has fixed before for that Student ID and Course";
            //}
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
            DataSet ds = STD_ProgramManager.GetDropDownListAllSTD_Program();
            ddlCourseID.DataValueField = "ProgramID";
            ddlCourseID.DataTextField = "ProgramName";
            ddlCourseID.DataSource = ds.Tables[0];
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("Select Program >>", "0"));

            ddlCourseIDReceived.DataValueField = "ProgramID";
            ddlCourseIDReceived.DataTextField = "ProgramName";
            ddlCourseIDReceived.DataSource = ds.Tables[0];
            ddlCourseIDReceived.DataBind();
            ddlCourseIDReceived.Items.Insert(0, new ListItem("Select Program >>", "0"));
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
            //calculateTotal();
            List<STD_Fees> fees = new List<STD_Fees>();

            fees = new List<STD_Fees>();
            decimal discount = decimal.Parse(txtDiscount.Text);
            int j = 0;
            lblDiscountMessage.Text = "";
            //txtInstallmentAmount.Text =  ((decimal.Parse(txtTotalAmountNeedToPay.Text) - decimal.Parse(txtInitialPaymentAmount.Text)) / decimal.Parse(txtNoOfInstallment.Text)).ToString();
            
            for (int i = 0; i <= int.Parse(txtNoOfInstallment.Text); i++)
            {
                STD_Fees fee = new STD_Fees();
                fee.FeesID = i;
                if (i == 0)
                {
                    fee.SubmissionDate = DateTime.Today;
                    fee.Amount = decimal.Parse(txtInitialPaymentAmount.Text);
                }
                else
                if (i == 1)
                {
                    fee.SubmissionDate = txtInstallmentDuration.Text != "" ? DateTime.Now.AddMonths(((i) * int.Parse(txtInstallmentDuration.Text))) : DateTime.Now;

                    fee.Amount = decimal.Parse(txtTotalAmountNeedToPay.Text) - (decimal.Parse(txtInstallmentAmount.Text) * (decimal.Parse(txtNoOfInstallment.Text) - 1)) - decimal.Parse(txtInitialPaymentAmount.Text);
                }
                else
                {
                    fee.Amount = decimal.Parse(txtInstallmentAmount.Text);
                    fee.SubmissionDate = txtInstallmentDuration.Text != "" ? DateTime.Now.AddMonths(((i) * int.Parse(txtInstallmentDuration.Text))) : DateTime.Now;
                }
                //if (txtDiscount.Text != "" && j == 0 && decimal.Parse(txtInstallmentAmount.Text) > decimal.Parse(txtDiscount.Text))
                //{
                //    fee.Amount = decimal.Parse(txtInstallmentAmount.Text) - (decimal.Parse(txtInstallmentAmount.Text) * decimal.Parse(txtDiscount.Text)) / 100;
                //    j++;
                //}
                //else
                //{

                /*
                if (discount < decimal.Parse(txtInstallmentAmount.Text))
                {
                    fee.Amount = decimal.Parse(txtInstallmentAmount.Text) - discount;
                    if (discount != 0)
                        lblDiscountMessage.Text += "From the installment # " + (i + 1).ToString() + " we have diducted the discount</br>";
                    discount = 0;
                }
                else
                {
                    discount -= decimal.Parse(txtInstallmentAmount.Text);
                    lblDiscountMessage.Text += "installment # " + (i + 1).ToString() + " has not added because of the discount is bigger than the installment value. </br>";
                    i--;
                    txtNoOfInstallment.Text = (int.Parse(txtNoOfInstallment.Text) - 1).ToString();
                    continue;
                }
                */
                    //fee.Amount = decimal.Parse(txtInstallmentAmount.Text);
                //}

                fee.IsPaid = false;
                fee.IsEnabled = false;
                fees.Add(fee);
            }

            Session["fees"] = fees;

            gvFeesAdd.DataSource = fees;
            gvFeesAdd.DataBind();

            //btnAdd.Visible = true;
            divAddNewInstallment.Visible = true;
        }

        catch (Exception ex)
        {
        }
    }

    protected void btnPayAdvance_Click(object sender, EventArgs e)
    {
        btnPayAdvance.Visible = false;
        string remark=ddlAccountID.SelectedItem.Text+"( Fees ";
        STD_FeesMaster feesMaster = new STD_FeesMaster();
        feesMaster= STD_FeesMasterManager.GetSTD_FeesMasterByFeesMasterID(int.Parse(ddlFeesMaster.SelectedValue));

        if (decimal.Parse(txtPaymentAmount.Text) > decimal.Parse(feesMaster.ExtraField2))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('The amount can not be the dua amount..')", true);
            return;
        }

        try
        {
            decimal paymentAmount = Convert.ToDecimal(txtPaymentAmount.Text);
            foreach (GridViewRow grMaster in gvSTD_FeesMaster.Rows)
            {
                GridView gvFeesShow = (GridView)grMaster.FindControl(feesMaster.FeesTypeID == 31 ? "gvFeesShowForInstallment" : "gvFeesShow");
                int FeesMasterID= Convert.ToInt32(((HiddenField)grMaster.FindControl("hfFeesMasterID")).Value);
                if (feesMaster.FeesMasterID == FeesMasterID)
                {
                    decimal payemntAmountB4Processing = paymentAmount;
                    List<STD_Fees> feesListUpdate = new List<STD_Fees>();
                    int newlyAddedFeeID = 0;
                    foreach (GridViewRow row in gvFeesShow.Rows)
                    {
                        bool isPaid = Convert.ToBoolean(((CheckBox)row.FindControl("chkIspaid")).Checked);
                        decimal unpaidAmount = decimal.Parse(((Label)row.FindControl("lblUnpaidAmount")).Text);
                        
                        remark+="# "+((Label)row.FindControl("lblInstallmentNo")).Text+", ";
                        if(unpaidAmount !=0)
                        {
                            int feesID = Convert.ToInt32(((HiddenField)row.FindControl("hfFeesID")).Value);

                            STD_Fees currentFee = STD_FeesManager.GetSTD_FeesByFeesID(feesID);

                            if (paymentAmount >= unpaidAmount)
                            {
                                #region Fully Payment
                                paymentAmount -= (currentFee.Amount - decimal.Parse(currentFee.Remarks));
                                currentFee.IsPaid = true;
                                currentFee.SubmitedDate = DateTime.Today.ToString();
                                currentFee.UpdatedBy = Profile.card_id;
                                currentFee.UpdateDate = DateTime.Now;
                                currentFee.RowStatusID = int.Parse("1");
                                currentFee.Remarks = (decimal.Parse(currentFee.Remarks) + unpaidAmount).ToString();
                                feesListUpdate.Add(currentFee);
                                //bool resutl = STD_FeesManager.UpdateSTD_Fees(currentFee);
                                #endregion
                            }
                            else if (paymentAmount > 0)
                            {
                                #region Partial Payment
                                decimal amountRemaining = (currentFee.Amount - decimal.Parse(currentFee.Remarks)) - paymentAmount;

                                currentFee.IsPaid = true;
                                currentFee.SubmitedDate = DateTime.Today.ToString();
                                //currentFee.Amount = paymentAmount;

                                currentFee.UpdatedBy = Profile.card_id;
                                currentFee.UpdateDate = DateTime.Now;
                                currentFee.RowStatusID = int.Parse("1");//Temporary Updated In DB
                                currentFee.Remarks = (decimal.Parse(currentFee.Remarks)+ paymentAmount).ToString() ;
                                feesListUpdate.Add(currentFee);
                                //bool resutl = STD_FeesManager.UpdateSTD_Fees(currentFee);


                                ////Add a new row 
                                //STD_Fees newFee = new STD_Fees();
                                //newFee.FeesName = FeesMasterID.ToString();
                                //newFee.FeesTypeID= int.Parse( ddlAccountID.SelectedValue);
                                //newFee.StudentID = currentFee.StudentID;
                                //newFee.CourseID = currentFee.CourseID;
                                //newFee.UpdatedBy = Profile.card_id;
                                //newFee.UpdateDate = DateTime.Now;
                                //newFee.Amount = amountRemaining;
                                //newFee.SubmissionDate = currentFee.SubmissionDate;
                                //newFee.SubmitedDate = "";
                                //newFee.AddedBy = Profile.card_id;
                                //newFee.AddedDate = DateTime.Now;
                                //newFee.RowStatusID = int.Parse("10");//Temporary Updated In DB
                                //newFee.Remarks = "Partially payment done but Something remaining";
                                //newFee.IsPaid = false;
                                //newlyAddedFeeID = STD_FeesManager.InsertSTD_Fees(newFee);
                                #endregion
                                paymentAmount = 0;
                                break;
                            }
                        }
                    }

                    Session["feesListUpdate"] = feesListUpdate;
                    decimal payemntAmountAfterProcessing = paymentAmount;
                    //STD_FeesMaster feesMaster = STD_FeesMasterManager.GetSTD_FeesMasterByFeesMasterID(FeesMasterID);

                    //paid amount
                    feesMaster.ExtraField1 = (decimal.Parse(feesMaster.ExtraField1) + (payemntAmountB4Processing - payemntAmountAfterProcessing)).ToString();
                    //unpaid amount
                    feesMaster.ExtraField2 = (decimal.Parse(feesMaster.ExtraField2) - (payemntAmountB4Processing - payemntAmountAfterProcessing)).ToString();

                    if (decimal.Parse(feesMaster.ExtraField2) == 0)
                    {
                        feesMaster.IsPaid = true;
                    }

                    Session["feesMaster"] = feesMaster;
                    //STD_FeesMasterManager.UpdateSTD_FeesMaster(feesMaster);
                    ddlFeesTypeID.SelectedValue = ddlFeesMaster.SelectedValue;
                    //Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?newFeesID=" + newlyAddedFeeID.ToString() + "&DrOrCr=Cr&SubBasicAccountID=20&AccountID=" + ddlFeesTypeID.SelectedItem.Text + "&UserTypeID=1&StudentCode=" + txtStudentCode.Text + "&AccountIDMoney=1&UserTypeIDMoney=2&Amount=" + txtPaymentAmount.Text + "&Remarks=" + (txtRemarkForReceipt.Text != "" ? txtRemarkForReceipt.Text : remark) + "&IsAdmissionFees=" + hfIsAdmissionFees.Value);
                    if (ddlFeesTypeID.SelectedItem.Text == "31")//only for the installment fees
                    {
                        Response.Redirect("JournalDoubleEntryCommon.aspx?newFeesID=" + newlyAddedFeeID.ToString() + "&DrOrCr=Cr&SubBasicAccountID=20&AccountID=" + ddlFeesTypeID.SelectedItem.Text + "&UserTypeID=1&StudentCode=" + txtStudentCode.Text + "&AccountIDMoney=1&UserTypeIDMoney=2&Amount=" + txtPaymentAmount.Text + "&Remarks=" + feesMaster.ExtraField3 + "&IsAdmissionFees=" + hfIsAdmissionFees.Value);
                    }
                    else
                    {
                        Response.Redirect("JournalDoubleEntryCommon.aspx?newFeesID=" + newlyAddedFeeID.ToString() + "&DrOrCr=Cr&SubBasicAccountID=20&AccountID=" + ddlFeesTypeID.SelectedItem.Text + "&UserTypeID=1&StudentCode=" + txtStudentCode.Text + "&AccountIDMoney=1&UserTypeIDMoney=2&Amount=" + txtPaymentAmount.Text + "&Remarks=" + (txtRemarkForReceipt.Text != "" ? txtRemarkForReceipt.Text : remark) + "&IsAdmissionFees=" + hfIsAdmissionFees.Value);
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
        if (hfStudentID.Value!="")
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
            //bool resutl = STD_FeesManager.UpdateSTD_Fees(sTD_FeesUpdate);

            //for accounting we need to process

            showSTD_FeesDataByStudentIDnCourseID();


            Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?FeesID=" + sTD_FeesUpdate.FeesID.ToString() + "&Remarks=" + sTD_FeesUpdate.Remarks + "&DrOrCr=Cr&SubBasicAccountID=20&AccountID=31&UserTypeID=1&StudentCode=" + txtStudentCode.Text + "&UserTypeIDMoney=2&Amount=" + sTD_FeesUpdate.Amount);
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
        foreach (GridViewRow grMaster in gvSTD_FeesMaster.Rows)
        {
            GridView gvFeesShow = (GridView)grMaster.FindControl("gvFeesShow");
       
            foreach (GridViewRow gr in gvFeesShow.Rows)
            {
                TextBox txtPartiallyPaidAmount = (TextBox)gr.FindControl("txtPartiallyPaidAmount");

                HiddenField hfFeesID = (HiddenField)gr.FindControl("hfFeesID");
                if (hfFeesID.Value == feesID.ToString())
                {
                    return decimal.Parse(txtPartiallyPaidAmount.Text);
                }
            }
        }
        return 0;
    }

    private DateTime getRemainingDateByFeesID(int feesID)
    {
       foreach (GridViewRow grMaster in gvSTD_FeesMaster.Rows)
        {
            GridView gvFeesShow = (GridView)grMaster.FindControl("gvFeesShow");

            foreach (GridViewRow gr in gvFeesShow.Rows)
            {
                TextBox txtRemainingSubmissionDate = (TextBox)gr.FindControl("txtRemainingSubmissionDate");

                HiddenField hfFeesID = (HiddenField)gr.FindControl("hfFeesID");
                if (hfFeesID.Value == feesID.ToString())
                {
                    return DateTime.Parse(txtRemainingSubmissionDate.Text);
                }
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
        txtStudentCodeSearch.Enabled = false;
        divPaymentHistory.Visible = true;
        if (Request.QueryString["StudentCode"] != null)
        {
            if (txtStudentCodeSearch.Text != Request.QueryString["StudentCode"])
            {
                Response.Redirect("FeesInstallment.aspx?StudentCode=" + txtStudentCodeSearch.Text);
            }
        }

        divFeesDetailsPerStudent.Visible = false;
        divReceivePayment.Visible = false;
        if (txtStudentCodeSearch.Text == "")
        {
            lblInstallmentSearchMessage.Text = "Please enter the Student ID";
            
            return;
        }

        try
        {
            lblInstallmentSearchMessage.Text = "";
            //call the methord by which we can get the student info
            STD_Student sTD_Student = new STD_Student();
            sTD_Student = STD_StudentManager.GetSTD_StudentByStudentCodeRefund(txtStudentCodeSearch.Text.Trim());

            if (sTD_Student == null)
            {
                lblInstallmentSearchMessage.Text = "There is no registured student by this ID";
                return;
            }
            if (sTD_Student.RowStatusID == 14)
            {
                lblInstallmentSearchMessage.Text = "<br/><br/><h1 style='font-size:60px;line-height: 60px;'>Student Registration Cancelled<h1>";
                hfIsRefund.Value = "1";
            }

            //divReceivePayment.Visible = true;
            try
            {
                ddlCourseIDReceived.SelectedValue = sTD_Student.SpouseQualification;
            }
            catch (Exception ex)
            { }
            ddlCourseID.SelectedValue = ddlCourseIDReceived.SelectedValue;
            hfStudentID.Value = sTD_Student.StudentID;
            StudentCodeVarification(sTD_Student);
            showFeesMaster();
            showSTD_FeesDataByStudentIDnCourseID();
            divFeesDetailsPerStudent.Visible = true;
            //divReceivePayment.Visible = true;
            loadStudentSubjectData();
            showPaymentHistory();


            if (hfIsRefund.Value == "1")
            {
                btnPayAdvance.Visible = false;
                btnRefund.Visible = false;
                divReceivePayment.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblInstallmentSearchMessage.Text = "Please enter the Student ID";
        }
    }

    private void showFeesMaster()
    {
        DataSet ds = new DataSet();
        ds = STD_FeesMasterManager.GetSTD_FeesMasterByStudentID(hfStudentID.Value);

        //ListItem li = new ListItem("Select Employee...", "0");
        //ddlAccountingUser.Items.Add(li);
        if (ds.Tables[0].Rows.Count == 0)
        {
            divReceivePayment.Visible = false;
            if(btnAddNewInsatallation.Text.Contains("Add")) btnAddNewInsatallation_Click(this, new EventArgs());
        }
        else
        {
            divReceivePayment.Visible = true;
            divShowInstallment.Visible = true;
            if (btnAddNewInsatallation.Text.Contains("Hide")) btnAddNewInsatallation_Click(this, new EventArgs());
        }

        ddlFeesMaster.Items.Clear();
        ddlFeesTypeID.Items.Clear();
        lblTotalAllUnpaidAmount.Text = "0";
        hfRefundAmount.Value = "0";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            hfRefundAmount.Value = (decimal.Parse(hfRefundAmount.Value) + decimal.Parse(dr["ExtraField1"].ToString())).ToString("00.00");
            if (decimal.Parse(dr["ExtraField2"].ToString()) != decimal.Parse("0"))
            {
                if (int.Parse(dr["RowStatusID"].ToString()) == 1)
                {
                    lblTotalAllUnpaidAmount.Text = (decimal.Parse(lblTotalAllUnpaidAmount.Text) + decimal.Parse(dr["ExtraField2"].ToString())).ToString("0,000");
                }

                ListItem item = new ListItem( "( Unpaid amount " + dr["ExtraField2"].ToString() + " ) "+dr["FeesTypeName"].ToString() + " of " + dr["CourseName"].ToString(), dr["FeesMasterID"].ToString());
                ddlFeesMaster.Items.Add(item);

                ListItem itemFeesTypeID = new ListItem(dr["FeesTypeID"].ToString(), dr["FeesMasterID"].ToString());
                ddlFeesTypeID.Items.Add(itemFeesTypeID);

                if (ddlCourseIDReceived.SelectedIndex == 0)
                {
                    ddlCourseIDReceived.SelectedValue = dr["CourseID"].ToString();

                    ddlCourseID.SelectedValue = dr["CourseID"].ToString();
                }

                if (ddlAccountID.SelectedValue == "0")
                {
                    ddlAccountID.SelectedValue = dr["FeesTypeID"].ToString();
                }
            }
        }

        lblRefundAmount.Text = hfRefundAmount.Value;

        if (ddlFeesMaster.Items.Count > 0)
        {
            btnPayAdvance.Visible = true;
        }
        else
        {
            btnPayAdvance.Visible = false;
        }

        gvSTD_FeesMaster.DataSource = ds;
        gvSTD_FeesMaster.DataBind();
    }
    protected void btnVarify_OnClick(object sender, EventArgs e)
    {
        //StudentCodeVarification();
    }

    private bool StudentCodeVarification(STD_Student students)
    {
        // = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text.Trim());
        if (students != null)
        {
            pnStudentDetails.Visible = true;
            lblName.Text = students.StudentName;
            lblContact.Text = students.Mobile;
            imgStudent.ImageUrl = students.PPSizePhoto;

            hfStudentID.Value = students.StudentID;
            lblTest.Text = "Student Code is Exist. <a target='_blank' style='color:blue;' href='../Student/AdminDetailsSTD_Student.aspx?ID=" + students.StudentID + "'>Click here for Details</a>";
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is Exist')", true);
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
            txtTotalAmount.Text = (decimal.Parse(lblTotalAmount.Text)+ decimal.Parse(txtDiscount.Text)).ToString() ;
            txtTotalAmountNeedToPay.Text = (decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)).ToString();
            
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
            TextBox txtSubmissionDate = (TextBox)row.FindControl("txtSubmissionDate");
            
            STD_Fees fee = new STD_Fees();
            fee.FeesID = i;
            fee.SubmissionDate = DateTime.Parse(txtSubmissionDate.Text);
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

    //protected void gvFeesShow_OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    decimal PaidTotal = 0, UnpaidTotal = 0;

    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        TextBox txtAmount = (TextBox)e.Row.FindControl("txtListAmount");
    //        CheckBox chkIspaid = (CheckBox)e.Row.FindControl("chkIspaid");

    //        if (chkIspaid.Checked)
    //        {
    //            PaidTotal = Convert.ToDecimal(Session["PaidTotal"]) + decimal.Parse(txtAmount.Text);

    //            Session["PaidTotal"] = PaidTotal;
    //        }
    //        else
    //        {
    //            UnpaidTotal = Convert.ToDecimal(Session["UnpaidTotal"]) + decimal.Parse(txtAmount.Text);

    //            Session["UnpaidTotal"] = UnpaidTotal;
    //        }


    //    }

    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
    //        Label lblUnpaidAmount = (Label)e.Row.FindControl("lblUnpaidAmount");
    //        lblPaidAmount.Text = Session["PaidTotal"] != null ? Session["PaidTotal"].ToString() : "";
    //        lblUnpaidAmount.Text = Session["UnpaidTotal"] != null ? Session["UnpaidTotal"].ToString() : "";

    //        Session["PaidTotal"] = null;
    //        Session["UnpaidTotal"] = null;
    //    }
    //}


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
    protected void ddlAccountID_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkAddNewSemisterFee.Visible = ddlAccountID.SelectedValue == "29" ? true : false;

        dtPerSubjectfee.Visible = true;
        ddPerSubjectfee.Visible = true;

        if (ddlAccountID.SelectedValue != "31")
        {
            loadForInstallation(false);
            if (ddlAccountID.SelectedValue != "57")
            {
                dtPerSubjectfee.Visible = false;
                ddPerSubjectfee.Visible = false;
            }
            txtInitialPaymentAmount.Text = "0";
        }
        else
        {
            loadForInstallation(true);
            txtInitialPaymentAmount.Text = "30000";
            
            
        }
        txtTotalAmount.Text = txtInitialPaymentAmount.Text;
        txtTotalAmountNeedToPay.Text = txtInitialPaymentAmount.Text;
        
    }

    private void loadForInstallation(bool isTrue)
    {
        btnGridGenerator.Visible = isTrue;

        lblNoOfInstallment.Visible = isTrue;
        txtNoOfInstallment.Visible = isTrue;

        lblInstallmentDuration.Visible = isTrue;
        txtInstallmentDuration.Visible = isTrue;

        lblInstallmentAmount.Visible = isTrue;
        txtInstallmentAmount.Visible = isTrue;

        spanInstalationDuration.Visible = isTrue;

        initialPaymentlbl.Visible = isTrue;
        initialPaymentTxt.Visible = isTrue;

        bGenerateInstallationFees.Visible = isTrue;

        
    }

    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        calculateTotal();
    }

    protected void txtCalculateAmount_TextChanged(object sender, EventArgs e)
    {
        calculateTotal();
    }

    //protected void txtInitialPaymentAmount_TextChanged(object sender, EventArgs e)
    //{
    //    calculateTotal();
    //}
    private void calculateTotal()
    {
        try
        {

        
        //if (ddlAccountID.SelectedValue != "31")
        //{
            txtInstallmentAmount.Text = ((decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtInitialPaymentAmount.Text)) / decimal.Parse(txtNoOfInstallment.Text)).ToString();
            txtTotalAmountNeedToPay.Text = (decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)).ToString();
            if (txtInstallmentAmount.Text.Contains('.'))
            {
                txtInstallmentAmount.Text = txtInstallmentAmount.Text.Substring(0, txtInstallmentAmount.Text.IndexOf('.'));
            }
            if (ddlAccountID.SelectedValue == "31")
            {
                btnGridGenerator_Click(this, new EventArgs());
            }
        //}
        //else
        //{
        //    txtTotalAmount.Text = ((decimal.Parse(txtNoOfInstallment.Text) * decimal.Parse(txtInstallmentAmount.Text)) + decimal.Parse(txtInitialPaymentAmount.Text)).ToString();
        //    txtTotalAmountNeedToPay.Text = (decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text)).ToString();
        //}
        }
        catch (Exception ex)
        {

        }
    }
    protected void txtTotalAmount_TextChanged(object sender, EventArgs e)
    {
        calculateTotal();
    }


    protected void btnAddNewInsatallation_Click(object sender, EventArgs e)
    {
        if (btnAddNewInsatallation.Text == "Add New Fess (List)")
        {
            divAddNewInstallationProcess.Visible = true;
            btnAddNewInsatallation.Text = "Hide Adding New Fess (List)";
        }
        else
        {
            divAddNewInstallationProcess.Visible = false;
            btnAddNewInsatallation.Text = "Add New Fess (List)";
        }
    }
    protected void btnAddSubjectStudent_Click(object sender, EventArgs e)
    {
        STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent();
        //	sTD_SubjectStudent.SubjectStudentID=  int.Parse(ddlSubjectStudentID.SelectedValue);
        sTD_SubjectStudent.SubjectStudentName = "0";
        sTD_SubjectStudent.StudentID = hfStudentID.Value;
        sTD_SubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
        sTD_SubjectStudent.AddedBy = Profile.card_id;
        sTD_SubjectStudent.AddedDate = DateTime.Now;
        sTD_SubjectStudent.UpdatedBy = Profile.card_id;
        sTD_SubjectStudent.UpdateDate = DateTime.Now;
        sTD_SubjectStudent.RowStatusID = 1;
        int resutl = STD_SubjectStudentManager.InsertSTD_SubjectStudent(sTD_SubjectStudent);

        //Add fees
        if (txtTotalAmount.Text == "0")
        {
            txtTotalAmount.Text = txtInitialPaymentAmount.Text;
        }
        txtTotalAmount.Text = (decimal.Parse(txtTotalAmount.Text) + decimal.Parse(txtPerSubject.Text)).ToString("0");
        txtCalculateAmount_TextChanged(this, new EventArgs());

        //Receipt Message
        hfSubjects.Value += ","+ ddlSubjectID.SelectedItem.Text.Substring(ddlSubjectID.SelectedItem.Text.IndexOf('-')+2, ddlSubjectID.SelectedItem.Text.Length - ddlSubjectID.SelectedItem.Text.IndexOf('-') - 2);
        txtRemarkForReceipt.Text = @""+(txtInitialPaymentAmount.Text!="0"?"Admission Fees Tk," + txtInitialPaymentAmount.Text + "/-":"")+" Per Paper Fees TK," + txtPerSubject.Text + "*" + (hfSubjects.Value.Split(',').Length-1) + "=" + (decimal.Parse(txtPerSubject.Text) *(hfSubjects.Value.Split(',').Length-1) ).ToString("0")+ "/- (Total: "+txtTotalAmountNeedToPay.Text+"/-) "+ddlCourseIDReceived.SelectedItem.Text+" Paper "+hfSubjects.Value+",";

        loadStudentSubjectData();
    }

    private void loadStudentSubjectData()
    {
        //STD_SubjectStudentManager.LoadSTD_SubjectStudentPage(gvSTD_SubjectStudent, rptPager, 1, ddlPageSize);
        DataSet ds = new DataSet();
        ds = STD_SubjectStudentManager.GetSTD_StudentByStudentIDWithHistory(hfStudentID.Value, true);

        
        gvSTD_SubjectStudent.DataSource = ds;
        gvSTD_SubjectStudent.DataBind();
    }


    protected void lbDeleteStudentSubject_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        STD_SubjectStudent subjectStudent = STD_SubjectStudentManager.GetSTD_SubjectStudentBySubjectStudentID(Convert.ToInt32(linkButton.CommandArgument));
        subjectStudent.RowStatusID = 3;

        bool result = STD_SubjectStudentManager.UpdateSTD_SubjectStudent(subjectStudent);
        loadStudentSubjectData();
    }
    protected void btnRefund_Click(object sender, EventArgs e)
    {
        if (decimal.Parse(hfRefundAmount.Value) < decimal.Parse(txtRefundAmount.Text))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('The amount can not be greater the paid amount..')", true);
            return;
        }
        else
        {
            Response.Redirect("JournalDoubleEntryCommon.aspx?Refund=1&DrOrCr=Dr&SubBasicAccountID=39&AccountID=66&UserTypeID=1&StudentCode=" + txtStudentCode.Text + "&AccountIDMoney=1&UserTypeIDMoney=2&Amount=" + txtRefundAmount.Text + "&Remarks=Student Refund&IsAdmissionFees=" + hfIsAdmissionFees.Value);
        }           

        //if (STD_FeesMasterManager.RefundSTD_FeesMaster(hfStudentID.Value))
        //{ 
            
        //}
    }
    protected void btnAddInstallment_Click(object sender, EventArgs e)
    {
        try
        {
            ACC_Journal pfACC_Journal = new ACC_Journal();
            pfACC_Journal.UserID = hfStudentID.Value;
            pfACC_Journal.Balance = Convert.ToDecimal(txtJournalHistoryAmount.Text);
            pfACC_Journal.AddedBy = Profile.card_id;
            pfACC_Journal.AddedDate = DateTime.Parse(txtJournalHistoryDate.Text);
            pfACC_Journal.UpdatedBy = Profile.card_id;
            pfACC_Journal.UpdateDate = DateTime.Now;
            pfACC_Journal.EmployPayRoleSalaryID = 0;
            ACC_AccountingCommonManager.ProcessACC_JournalHistory(hfStudentID.Value, pfACC_Journal);

            showPaymentHistory();
        }
        catch (Exception ex)
        { }
    }
}