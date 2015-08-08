using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Student_SearchCBEExamStudents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["sum"] = null;

            txtFromDate.Text = DateTime.Now.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString())).ToString("dd MMM yyyy");
            txtToDate.Text = DateTime.Now.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString())).ToString("dd MMM yyyy");
        }
    }

    private void showCBEExamGrid(string name, string subject, DateTime startDate, DateTime endDate)
    {
       
    }

    protected void btnSeach_OnClick(object sender, EventArgs e)
    {
        /*
         set @sql='  SELECT STD_CBEExam.*,STD_CBEExamSubject.SubjectTitle, STD_CBEExamSubject.Fees FROM STD_CBEExam
    inner join STD_CBEExamSubject on STD_CBEExam.CBEExamID=STD_CBEExamSubject.CBEExamID '
    if @Name<>''
    set @sql+='WHERE STD_CBEExam.CandidateName like ''%'+@Name+'%'' '
    if @SubjectTitle<>''
    set @sql+=' And STD_CBEExamSubject.SubjectTitle like ''%'+@SubjectTitle+'%'' '
    if ( @FromDate<>'' or @ToDate<>'')
    set @sql+=' And (STD_CBEExam.AddedDate between '''+CAST(@FromDate as NVARCHAR(100))+''' And ''' +CAST(@ToDate as NVARCHAR(100))+''' ) '
 
  exec(@sql)
         */
        string sql = @"
 SELECT STD_CBEExam.*,STD_CBEExamSubject.SubjectTitle, STD_CBEExamSubject.Fees,STD_CBEExam.AddedDate FROM STD_CBEExam
    inner join STD_CBEExamSubject on STD_CBEExam.CBEExamID=STD_CBEExamSubject.CBEExamID 
WHERE 1=1 and (STD_CBEExam.AddedDate between '" + DateTime.Parse(txtFromDate.Text).ToString("yyyy-MM-dd") + @"' And '" + DateTime.Parse(txtToDate.Text).AddDays(1).ToString("yyyy-MM-dd") + @"' )
";
        if (txtName.Text != "")
        {
            sql += @"
 and STD_CBEExam.CandidateName like '%"+txtName.Text+"%' ";
        }

        if (txtSubject.Text != "")
        {
            sql += @"
WHERE STD_CBEExamSubject.SubjectTitle like '%" + txtSubject.Text + "%' ";
        }
        sql += @"
order by STD_CBEExam.AddedDate desc
";
        DataSet ds=CommonManager.SQLExec(sql);
        gvCBEExam.DataSource = ds.Tables[0];
        gvCBEExam.DataBind();

        decimal total = 0;
        foreach (GridViewRow gvr in gvCBEExam.Rows)
        {
            Label lblFees = (Label)gvr.FindControl("lblFees");
            total += decimal.Parse(lblFees.Text);
        }

        ((Label)gvCBEExam.FooterRow.FindControl("lblTotal")).Text=total.ToString("0,0.00");
    }

    
}