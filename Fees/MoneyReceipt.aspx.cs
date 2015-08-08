using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_MoneyReceipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["examID"] != null)
            {
                STD_CBEExam exam = STD_CBEExamManager.GetCBEExamByID(Convert.ToInt32(Request.QueryString["examID"]));
                lblBillTo.Text = exam.CandidateName;
                lblContactNo.Text = exam.Mobile;
                lblDate.Text = DateTime.Now.ToString("dd MMM, yyyy");
                lblEmail.Text = exam.Email;
                lblPhone.Text = exam.Tel;
                lblRegNo.Text = exam.RegiNo;

                lblBillTo1.Text = exam.CandidateName;
                lblContactNumber.Text = exam.Mobile;
                lblDate1.Text = DateTime.Now.ToString("dd MMM, yyyy");
                lblEmail1.Text = exam.Email;
                lblPhone1.Text = exam.Tel;
                lblACCAReg.Text = exam.RegiNo;

                if (Session["studentCode"] != null)
                {
                    lblStudentID.Text = Session["studentCode"].ToString();
                    lblStudentID1.Text = Session["studentCode"].ToString();
                    Session.Remove("studentCode");
                }
                else
                {
                    lblStudentID.Text = "N/A";
                    lblStudentID1.Text = "N/A";
                }

                List<STD_CBEExamSubject> list = new List<STD_CBEExamSubject>();
                list = STD_CBEExamSubjectManager.GetSTD_CBEExamSubjectByCBEExamID(Convert.ToInt32(Request.QueryString["examID"]));
                gvCBEExamSubject.DataSource = list;
                gvCBEExamSubject.DataBind();
                gvCBEExamSubject1.DataSource = list;
                gvCBEExamSubject1.DataBind();

            }

        }
    }
    protected void gvCBEExamSubject_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal sum = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblFees = (Label)e.Row.FindControl("lblFees");
            if (Session["sum"] == null)
            {
                sum = sum + decimal.Parse(lblFees.Text);
                Session["sum"] = sum;
            }
            else
                Session["sum"] = decimal.Parse(Session["sum"].ToString()) + decimal.Parse(lblFees.Text);

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblSumTotal = (Label)e.Row.FindControl("lblSumTotal");

            if (Session["sum"] != null)
            {
                decimal total = decimal.Parse(Session["sum"].ToString());
                lblSumTotal.Text = total.ToString("00.00") ;
                Session["sum"] = null;
            }
        }
    }
}