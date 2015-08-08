using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_BarCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["BarCode"]!=null)
            {
                txtIDs.Text = Request.QueryString["BarCode"];
            }
        }
    }
    protected void btnBarCode_Click(object sender, EventArgs e)
    {
        string barcodes = "<table><tr>";
        int remaining = 5;
        if (txtStart.Text != "")
        {
            txtIDs.Text = "";

            for (int i = int.Parse(txtStart.Text); i <= int.Parse(txtEnd.Text); i++)
            {
                txtIDs.Text += i.ToString()+",";
            }

            txtIDs.Text = txtIDs.Text.Substring(0, txtIDs.Text.Length - 1);
        }
        
        if (!txtIDs.Text.Trim().Contains(","))
        {
            txtIDs.Text = txtIDs.Text + ",";
        }


        for (int i = 0; i < txtIDs.Text.Trim().Split(',').Length; i++)
        {
            try
            {
                int test = int.Parse(txtIDs.Text.Trim().Split(',')[i]);

                if (i % 5 == 0)
                {
                    barcodes += "</tr><tr>";
                    remaining = 4;
                }
                else
                {
                    remaining--;
                }

                barcodes += "<td><div style='overflow:hidden;margin-left:-12px;width:157px; height:30px;margin-top: 28px;'><img style='margin-top:-30px' src='http://www.bcgen.com/demo/linear-dbgs.aspx?D=";
                barcodes += txtIDs.Text.Trim().Split(',')[i] + "'/></div></td>";
            }
            catch (Exception ex)
            { }
        }

        for (int i = 0; i < remaining; i++)
        {
            barcodes += "<td></td>";
        }
        barcodes += "</tr></table>";

        lblBarCode.Text = barcodes;
    }
}