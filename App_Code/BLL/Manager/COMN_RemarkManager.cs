using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_RemarkManager
{
	public COMN_RemarkManager()
	{
	}

    public static DataSet  GetAllCOMN_Remarks()
    {
       DataSet cOMN_Remarks = new DataSet();
        SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
        cOMN_Remarks = sqlCOMN_RemarkProvider.GetAllCOMN_Remarks();
        return cOMN_Remarks;
    }

	public static void cOMN_RemarksPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
		{
		double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
		int pageCount = (int)Math.Ceiling(dblPageCount);
		List<ListItem> pages = new List<ListItem>();
		if (pageCount > 0)
		{
 		pages.Add(new ListItem("First", "1", currentPage > 1));
		for (int i = 1; i <= pageCount; i++)
		{
		 pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
		}
		pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
		}
		rptPager.DataSource = pages;
		rptPager.DataBind();
		}
 	public static void LoadCOMN_RemarkPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
		DataSet ds =  sqlCOMN_RemarkProvider.GetCOMN_RemarkPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
        //COMN_CommonManager common = new COMN_CommonManager();
        COMN_CommonManager.Paggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static void LoadCOMN_RemarkPageByID(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize,string id)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
        DataSet ds = sqlCOMN_RemarkProvider.GetCOMN_RemarkPageWiseByID(pageIndex, PageSize, out recordCount,id);
        gv.DataSource = ds;
        gv.DataBind();
        //COMN_CommonManager common = new COMN_CommonManager();
        COMN_CommonManager.Paggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet  GetDropDownListAllCOMN_Remark()
    {
       DataSet cOMN_Remarks = new DataSet();
        SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
        cOMN_Remarks = sqlCOMN_RemarkProvider.GetDropDownLisAllCOMN_Remark();
        return cOMN_Remarks;
    }


    public static COMN_Remark GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        COMN_Remark cOMN_Remark = new COMN_Remark();
        SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
        cOMN_Remark = sqlCOMN_RemarkProvider.GetCOMN_RemarkByRowStatusID(RowStatusID);
        return cOMN_Remark;
    }


    public static COMN_Remark GetCOMN_RemarkByRemarkID(int RemarkID)
    {
        COMN_Remark cOMN_Remark = new COMN_Remark();
        SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
        cOMN_Remark = sqlCOMN_RemarkProvider.GetCOMN_RemarkByRemarkID(RemarkID);
        return cOMN_Remark;
    }


    public static int InsertCOMN_Remark(COMN_Remark cOMN_Remark)
    {
        SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
        return sqlCOMN_RemarkProvider.InsertCOMN_Remark(cOMN_Remark);
    }


    public static bool UpdateCOMN_Remark(COMN_Remark cOMN_Remark)
    {
        SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
        return sqlCOMN_RemarkProvider.UpdateCOMN_Remark(cOMN_Remark);
    }

    public static bool DeleteCOMN_Remark(int cOMN_RemarkID)
    {
        SqlCOMN_RemarkProvider sqlCOMN_RemarkProvider = new SqlCOMN_RemarkProvider();
        return sqlCOMN_RemarkProvider.DeleteCOMN_Remark(cOMN_RemarkID);
    }
}

