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
 public partial class BookIssue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadLIB_BookIssueData();
         		BookIDLoad();
		//IssedToIDLoad();

                if (Request.QueryString["BookID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["BookID"]);
                    btnAdd.Visible = false;
                    //btnUpdate.Visible = true;
                    showLIB_BookIssueData();
                    IssueCheck();
                }
        }
    }
    private void IssueCheck()
    {
        //DataSet ds = LIB_BookManager.GetDropDownListAllLIB_BookByBookID(Int32.Parse(Request.QueryString["BookID"]));
        DataSet dsi = LIB_BookManager.GetLIB_ISISSUED(Int32.Parse(Request.QueryString["BookID"]));
        DataTable dt = dsi.Tables[0];
        if (dt.Rows.Count<=0)
        {
            btnAdd.Visible = true;
            this.txtMsg.Text = "";
        }
        else {
            btnAdd.Visible = false;
            this.txtMsg.Text = "The Book is already issued!";
        }

    }
	protected void btnAdd_Click(object sender, EventArgs e){
        try
		{
	LIB_BookIssue lIB_BookIssue = new LIB_BookIssue ();
//	lIB_BookIssue.BookIssueID=  int.Parse(ddlBookIssueID.SelectedValue);
	lIB_BookIssue.BookID=  int.Parse(ddlBookID.SelectedValue);
	lIB_BookIssue.IssedToID=  ddlIssedToID.SelectedValue;
	lIB_BookIssue.IsStudent=  bool.Parse( radIsStudent.SelectedValue);
	lIB_BookIssue.IssueDate=   DateTime.Now;
    lIB_BookIssue.ReturnDate = DateTime.Now.AddDays(7);//DateTime.Parse(txtReturnDate.Text);
	lIB_BookIssue.AddedBy=  Profile.card_id;
	lIB_BookIssue.AddedDate=  DateTime.Now;
	lIB_BookIssue.ModifiedBy=  Profile.card_id;
	lIB_BookIssue.ModifiedDate=  DateTime.Now;
	int resutl =LIB_BookIssueManager.InsertLIB_BookIssue(lIB_BookIssue);
	}catch(Exception ex){}Response.Redirect("AdminDisplayLIB_BookIssue.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	LIB_BookIssue lIB_BookIssue = new LIB_BookIssue ();
    lIB_BookIssue.BookIssueID = int.Parse(Request.QueryString["BookID"].ToString());
	lIB_BookIssue.BookID=  int.Parse(ddlBookID.SelectedValue);
	lIB_BookIssue.IssedToID=  ddlIssedToID.SelectedValue;
	lIB_BookIssue.IsStudent=  bool.Parse( radIsStudent.SelectedValue);
    lIB_BookIssue.IssueDate = LIB_BookIssueManager.GetLIB_BookIssueByBookIssueID(int.Parse(Request.QueryString["BookID"].ToString())).IssueDate;
	lIB_BookIssue.ReturnDate=   DateTime.Now;
	lIB_BookIssue.AddedBy=  Profile.card_id;
	lIB_BookIssue.AddedDate=  DateTime.Now;
	lIB_BookIssue.ModifiedBy=  Profile.card_id;
	lIB_BookIssue.ModifiedDate=  DateTime.Now;
	bool  resutl =LIB_BookIssueManager.UpdateLIB_BookIssue(lIB_BookIssue);
	}catch(Exception ex){}Response.Redirect("AdminDisplayLIB_BookIssue.aspx");
	}
	private void showLIB_BookIssueData()
	{
        LIB_BookIssue lIB_BookIssue = new LIB_BookIssue();
        lIB_BookIssue = LIB_BookIssueManager.GetLIB_BookIssueByBookIssueID(Int32.Parse(Request.QueryString["BookID"]));
        //lIB_BookIssue = LIB_BookManager.GetLIB_BookByBookID(Int32.Parse(Request.QueryString["BookID"]));
	 	//ddlBookID.SelectedValue  =lIB_BookIssue.BookID.ToString();
        //ddlIssedToID.SelectedValue = lIB_BookIssue.IssedToID.ToString();
        //radIsStudent.SelectedValue = lIB_BookIssue.IsStudent.ToString();
        //txtIssueDate.Text = lIB_BookIssue.IssueDate.ToString();
        //txtReturnDate.Text = lIB_BookIssue.ReturnDate.ToString();
	}
	
	private void BookIDLoad()
	{
		try {
         DataSet ds = LIB_BookManager.GetDropDownListAllLIB_BookByBookID(Int32.Parse(Request.QueryString["BookID"]));
		ddlBookID.DataValueField = "BookID";
		ddlBookID.DataTextField = "BookName";
		ddlBookID.DataSource = ds.Tables[0];
		ddlBookID.DataBind();
		//ddlBookID.Items.Insert(0, new ListItem("Select Book >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void IssedToIDLoad()
	{
		try {
            ddlIssedToID.Items.Clear();

            DataSet ds = new DataSet();
            if (radIsStudent.SelectedIndex == 0)
            {
                ds = STD_StudentManager.GetDropDownListAllSTD_Student();
                ddlIssedToID.DataValueField = "StudentID";
                ddlIssedToID.DataTextField = "StudentName";
            }
            else
            {
                ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
                ddlIssedToID.DataValueField = "EmployeeID";
                ddlIssedToID.DataTextField = "EmployeeName";
            }
            ddlIssedToID.DataSource = ds.Tables[0];
            ddlIssedToID.DataBind();
            ddlIssedToID.Items.Insert(0, new ListItem("Select IssedTo >>", "0"));
            
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
    protected void radIsStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        IssedToIDLoad();
    }
}

