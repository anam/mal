using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_WebUserControl2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadMenu(Request.RawUrl);
    }

    private void loadMenu(string url)
    {
        string menu = "";
        menu += "Manage <a href='ClassAdd.aspx' class='button button-" + (url.Contains("ClassAdd.aspx")?"blue":"white") + "'>Class</a> &nbsp;>>&nbsp;";
        menu += "<a href='ClassSubjectAdd.aspx' class='button button-" + (url.Contains("ClassSubjectAdd.aspx") ? "blue" : "white") + "'>Class ~ Subject</a> &nbsp;>>&nbsp;";
        menu += "<a href='ClassSubjectAddTeacher.aspx' class='button button-" + (url.Contains("ClassSubjectAddTeacher.aspx") ? "blue" : "white") + "'>Teacher ~ Subject</a> &nbsp;>>&nbsp; ";
        menu += "<a href='ClassStudentAdd.aspx' class='button button-" + (url.Contains("ClassStudentAdd.aspx") ? "blue" : "white") + "'>Class ~ Student</a> &nbsp;>>&nbsp; ";
        menu += "<a href='ClassSubjectAddStudent.aspx' class='button button-" + (url.Contains("ClassSubjectAddStudent.aspx") ? "blue" : "white") + "'>Student ~ Subject</a>";
        lblMenus.Text = menu;
    }
}