using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Summary description for Comm_Display_Routine
/// </summary>
public class Comm_Display_Routine
{
	public Comm_Display_Routine()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region ConvertDataTableToHTMLString
    public string ConvertDataTableToHTMLString(System.Data.DataTable dt, string fontsize, string border, bool headers, bool useCaptionForHeaders)
    {

        StringBuilder sb = new StringBuilder();
        sb.Append("<table borderColor='#ff9900' border='5px" + border + "'>");
        if (headers)
        {
            //write column headings
            sb.Append("<tr>");
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                if (useCaptionForHeaders)
                    sb.Append("<td><b><font face=Arial size=2>" + dc.Caption + "</font></b></td>");
                else
                    sb.Append("<td><b><font face=Arial size=2>" + dc.ColumnName + "</font></b></td>");
            }
            sb.Append("</tr>");
        }

        //write table data
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            sb.Append("<tr>");
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                sb.Append("<td><font face=Arial size=" + fontsize + ">" + dr[dc].ToString() + "</font></td>");
            }
            sb.Append("</tr>");
        }
        sb.Append("</table>");

        return sb.ToString();
    }
    #endregion

}