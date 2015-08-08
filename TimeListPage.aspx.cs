using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TimeListPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TimeList timeList = new TimeList();
        //GridView1.DataSource = timeList.getTimeList();
        //GridView1.DataBind();

        string s = "";
        for (int i = 0; i < 60; i++)
        {
            if(i%5==0)s+= "\n<asp:ListItem Value=\"" + i.ToString() + "\">" + i.ToString() + "</asp:ListItem>";
        }
        TextBox1.Text = s;
    }
}