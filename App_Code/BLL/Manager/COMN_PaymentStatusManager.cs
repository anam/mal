using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_PaymentStatusManager
{
	public COMN_PaymentStatusManager()
	{
	}

    public static DataSet  GetAllCOMN_PaymentStatuss()
    {
       DataSet cOMN_PaymentStatuss = new DataSet();
        SqlCOMN_PaymentStatusProvider sqlCOMN_PaymentStatusProvider = new SqlCOMN_PaymentStatusProvider();
        cOMN_PaymentStatuss = sqlCOMN_PaymentStatusProvider.GetAllCOMN_PaymentStatuss();
        return cOMN_PaymentStatuss;
    }

	public static void cOMN_PaymentStatussPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_PaymentStatusPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_PaymentStatusProvider sqlCOMN_PaymentStatusProvider = new SqlCOMN_PaymentStatusProvider();
		DataSet ds =  sqlCOMN_PaymentStatusProvider.GetCOMN_PaymentStatusPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_PaymentStatussPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_PaymentStatus()
    {
       DataSet cOMN_PaymentStatuss = new DataSet();
        SqlCOMN_PaymentStatusProvider sqlCOMN_PaymentStatusProvider = new SqlCOMN_PaymentStatusProvider();
        cOMN_PaymentStatuss = sqlCOMN_PaymentStatusProvider.GetDropDownLisAllCOMN_PaymentStatus();
        return cOMN_PaymentStatuss;
    }


    public static COMN_PaymentStatus GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        COMN_PaymentStatus cOMN_PaymentStatus = new COMN_PaymentStatus();
        SqlCOMN_PaymentStatusProvider sqlCOMN_PaymentStatusProvider = new SqlCOMN_PaymentStatusProvider();
        cOMN_PaymentStatus = sqlCOMN_PaymentStatusProvider.GetCOMN_PaymentStatusByRowStatusID(RowStatusID);
        return cOMN_PaymentStatus;
    }


    public static COMN_PaymentStatus GetCOMN_PaymentStatusByPaymentStatusID(int PaymentStatusID)
    {
        COMN_PaymentStatus cOMN_PaymentStatus = new COMN_PaymentStatus();
        SqlCOMN_PaymentStatusProvider sqlCOMN_PaymentStatusProvider = new SqlCOMN_PaymentStatusProvider();
        cOMN_PaymentStatus = sqlCOMN_PaymentStatusProvider.GetCOMN_PaymentStatusByPaymentStatusID(PaymentStatusID);
        return cOMN_PaymentStatus;
    }


    public static int InsertCOMN_PaymentStatus(COMN_PaymentStatus cOMN_PaymentStatus)
    {
        SqlCOMN_PaymentStatusProvider sqlCOMN_PaymentStatusProvider = new SqlCOMN_PaymentStatusProvider();
        return sqlCOMN_PaymentStatusProvider.InsertCOMN_PaymentStatus(cOMN_PaymentStatus);
    }


    public static bool UpdateCOMN_PaymentStatus(COMN_PaymentStatus cOMN_PaymentStatus)
    {
        SqlCOMN_PaymentStatusProvider sqlCOMN_PaymentStatusProvider = new SqlCOMN_PaymentStatusProvider();
        return sqlCOMN_PaymentStatusProvider.UpdateCOMN_PaymentStatus(cOMN_PaymentStatus);
    }

    public static bool DeleteCOMN_PaymentStatus(int cOMN_PaymentStatusID)
    {
        SqlCOMN_PaymentStatusProvider sqlCOMN_PaymentStatusProvider = new SqlCOMN_PaymentStatusProvider();
        return sqlCOMN_PaymentStatusProvider.DeleteCOMN_PaymentStatus(cOMN_PaymentStatusID);
    }
}

