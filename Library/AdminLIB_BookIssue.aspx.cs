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
public partial class AdminLIB_BookIssue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BookIDLoad();
            IssedToIDLoad();
            txtIssueDate.Text = DateTime.Now.ToString("dd MMM yyyy");
            txtReturnDate.Text = DateTime.Now.AddDays(7).ToString("dd MMM yyyy");
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showLIB_BookIssueData();
            }
        }
    }

    private void showLIB_BookIssueData()
    {
        LIB_BookIssue lIB_BookIssue = new LIB_BookIssue();
        lIB_BookIssue = LIB_BookIssueManager.GetLIB_BookIssueByBookIssueID(Int32.Parse(Request.QueryString["ID"]));
        ddlBookID.SelectedValue = lIB_BookIssue.BookID.ToString();
        ddlIssedToID.SelectedValue = lIB_BookIssue.IssedToID.ToString();
        radIsStudent.SelectedValue = lIB_BookIssue.IsStudent.ToString();
        txtIssueDate.Text = lIB_BookIssue.IssueDate.ToString();
        txtReturnDate.Text = lIB_BookIssue.ReturnDate.ToString();
    }

    private void BookIDLoad()
    {

        try
        {
            DataSet ds = LIB_BookManager.GetDropDownListAllLIB_Book();
            ddlBookID.DataValueField = "BookID";
            ddlBookID.DataTextField = "BookName";
            ddlBookID.DataSource = ds.Tables[0];
            ddlBookID.DataBind();
            ddlBookID.Items.Insert(0, new ListItem("Select Book >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void IssedToIDLoad()
    {
        try
        {
            ddlIssedToID.Items.Clear();

            DataSet ds = new DataSet();
            if (radIsStudent.SelectedIndex == 0)
            {
                ds = STD_StudentManager.GetDropDownListAllSTD_Student();
                ddlIssedToID.DataValueField = "StudentID";
                ddlIssedToID.DataTextField = "StudentName";
                ddlIssedToID.DataSource = ds.Tables[0];
                ddlIssedToID.DataBind();
                ddlIssedToID.Items.Insert(0, new ListItem("Select Student Issue To >>", "0"));
            }
            else
            {
                ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
                ddlIssedToID.DataValueField = "EmployeeID";
                ddlIssedToID.DataTextField = "EmployeeName";
                ddlIssedToID.DataSource = ds.Tables[0];
                ddlIssedToID.DataBind();
                ddlIssedToID.Items.Insert(0, new ListItem("Select Teacher Issue To >>", "0"));
            }


        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void radIsStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        IssedToIDLoad();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ddlBookID.SelectedValue) == 0)
            {
                messageIssue.Text = "Select book from list.";
                messageIssue.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlIssedToID.SelectedValue.Equals("0"))
            {
                if (radIsStudent.SelectedValue == "Yes")
                {
                    messageIssue.Text = "Select student to issue book.";
                }
                else
                {
                    messageIssue.Text = "Select teacher to issue book.";
                }
                messageIssue.ForeColor = System.Drawing.Color.Red;
                return;
            }

            LIB_BookIssue lIB_BookIssue = new LIB_BookIssue();
            lIB_BookIssue.BookID = int.Parse(ddlBookID.SelectedValue);

            if (radIsStudent.SelectedValue == "Yes")
            {
                STD_Student student = STD_StudentManager.GetSTD_StudentByStudentID(ddlIssedToID.SelectedValue);
                lIB_BookIssue.IssedToID = student.StudentCode;
            }
            else
            {
                HR_Employee employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeID(ddlIssedToID.SelectedValue);
                lIB_BookIssue.IssedToID = employee.EmployeeNo;
            }

            lIB_BookIssue.IsStudent = radIsStudent.SelectedValue =="Yes"? true: false;
            lIB_BookIssue.IssueDate = Convert.ToDateTime(txtIssueDate.Text);
            lIB_BookIssue.ReturnDate = Convert.ToDateTime(txtReturnDate.Text);
            lIB_BookIssue.AddedBy = Profile.card_id;
            lIB_BookIssue.AddedDate = DateTime.Now;
            lIB_BookIssue.ModifiedBy = Profile.card_id;
            lIB_BookIssue.ModifiedDate = DateTime.Now;
            int resutl = LIB_BookIssueManager.InsertLIB_BookIssue(lIB_BookIssue);
            Response.Redirect("AdminDisplayLIB_BookIssue.aspx");
        }
        catch (Exception ex)
        {
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            LIB_BookIssue lIB_BookIssue = new LIB_BookIssue();
            lIB_BookIssue.BookIssueID = int.Parse(Request.QueryString["ID"].ToString());
            lIB_BookIssue.BookID = int.Parse(ddlBookID.SelectedValue);

            if (radIsStudent.SelectedValue == "Yes")
            {
                STD_Student student = STD_StudentManager.GetSTD_StudentByStudentID(ddlIssedToID.SelectedValue);
                lIB_BookIssue.IssedToID = student.StudentCode;
            }
            else
            {
                HR_Employee employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeID(ddlIssedToID.SelectedValue);
                lIB_BookIssue.IssedToID = employee.EmployeeNo;
            }
                        
            lIB_BookIssue.IsStudent = bool.Parse(radIsStudent.SelectedValue);
            lIB_BookIssue.IssueDate = LIB_BookIssueManager.GetLIB_BookIssueByBookIssueID(int.Parse(Request.QueryString["ID"].ToString())).IssueDate;
            lIB_BookIssue.ReturnDate = Convert.ToDateTime(txtReturnDate.Text);
            lIB_BookIssue.AddedBy = Profile.card_id;
            lIB_BookIssue.AddedDate = DateTime.Now;
            lIB_BookIssue.ModifiedBy = Profile.card_id;
            lIB_BookIssue.ModifiedDate = DateTime.Now;
            bool resutl = LIB_BookIssueManager.UpdateLIB_BookIssue(lIB_BookIssue);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayLIB_BookIssue.aspx");
    }      
}

