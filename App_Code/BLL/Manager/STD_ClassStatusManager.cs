using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassStatusManager
{
	public STD_ClassStatusManager()
	{
	}

    public static DataSet  GetAllSTD_ClassStatuss()
    {
       DataSet sTD_ClassStatuss = new DataSet();
        SqlSTD_ClassStatusProvider sqlSTD_ClassStatusProvider = new SqlSTD_ClassStatusProvider();
        sTD_ClassStatuss = sqlSTD_ClassStatusProvider.GetAllSTD_ClassStatuss();
        return sTD_ClassStatuss;
    }

	public static void sTD_ClassStatussPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassStatusPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassStatusProvider sqlSTD_ClassStatusProvider = new SqlSTD_ClassStatusProvider();
		DataSet ds =  sqlSTD_ClassStatusProvider.GetSTD_ClassStatusPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassStatussPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassStatus()
    {
       DataSet sTD_ClassStatuss = new DataSet();
        SqlSTD_ClassStatusProvider sqlSTD_ClassStatusProvider = new SqlSTD_ClassStatusProvider();
        sTD_ClassStatuss = sqlSTD_ClassStatusProvider.GetDropDownListAllSTD_ClassStatus();
        return sTD_ClassStatuss;
    }


    public static STD_ClassStatus GetSTD_ClassStatusByClassStatusID(int ClassStatusID)
    {
        STD_ClassStatus sTD_ClassStatus = new STD_ClassStatus();
        SqlSTD_ClassStatusProvider sqlSTD_ClassStatusProvider = new SqlSTD_ClassStatusProvider();
        sTD_ClassStatus = sqlSTD_ClassStatusProvider.GetSTD_ClassStatusByClassStatusID(ClassStatusID);
        return sTD_ClassStatus;
    }


    public static int InsertSTD_ClassStatus(STD_ClassStatus sTD_ClassStatus)
    {
        SqlSTD_ClassStatusProvider sqlSTD_ClassStatusProvider = new SqlSTD_ClassStatusProvider();
        return sqlSTD_ClassStatusProvider.InsertSTD_ClassStatus(sTD_ClassStatus);
    }


    public static bool UpdateSTD_ClassStatus(STD_ClassStatus sTD_ClassStatus)
    {
        SqlSTD_ClassStatusProvider sqlSTD_ClassStatusProvider = new SqlSTD_ClassStatusProvider();
        return sqlSTD_ClassStatusProvider.UpdateSTD_ClassStatus(sTD_ClassStatus);
    }

    public static bool DeleteSTD_ClassStatus(int sTD_ClassStatusID)
    {
        SqlSTD_ClassStatusProvider sqlSTD_ClassStatusProvider = new SqlSTD_ClassStatusProvider();
        return sqlSTD_ClassStatusProvider.DeleteSTD_ClassStatus(sTD_ClassStatusID);
    }
}

