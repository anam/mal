using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.Data;
using System.Configuration;
using System.Collections; 
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using System.IO;
public partial class RptViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["PrintOpt"] == null)
            return;

        string PrtOpt = Request.QueryString["PrintOpt"].ToString();
        switch (PrtOpt)
        {
            case "HTML":
                this.RptHtml();
                break;
            case "PDF":
                this.RptPDF();
                break;
            case "WORD":
                this.RptMSWord();
                break;
            case "EXCEL":
                this.RptMSExcel();
                break;
        }
    }
    protected void RptPDF() 
    {
        ReportDocument rpt1 = (ReportDocument)Session["Report1"];
        MemoryStream oStream;
        oStream = (MemoryStream)rpt1.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    
    
    }
    protected void RptHtml() 
    {
        ReportDocument rpt1 = (ReportDocument)Session["Report1"];
        MemoryStream oStream;
        oStream = (MemoryStream)rpt1.ExportToStream(CrystalDecisions.Shared.ExportFormatType.HTML40);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "text/html";
        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    
    }

    protected void RptMSWord() 
    {
        ReportDocument rpt1 = (ReportDocument)Session["Report1"];
        MemoryStream oStream;
        oStream = (MemoryStream)rpt1.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel"; //application/msword
        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    
    }
    protected void RptMSExcel() 
    {
        ReportDocument rpt1 = (ReportDocument)Session["Report1"];
        MemoryStream oStream;
        oStream = (MemoryStream)rpt1.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/msword"; //application/msword
        Response.BinaryWrite(oStream.ToArray());
        Response.End();
    
    }
   
    
    
    
  
    
}
