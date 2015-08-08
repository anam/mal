using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ContactTypeManager
{
	public STD_ContactTypeManager()
	{
	}

    public static DataSet  GetAllSTD_ContactTypes()
    {
       DataSet sTD_ContactTypes = new DataSet();
        SqlSTD_ContactTypeProvider sqlSTD_ContactTypeProvider = new SqlSTD_ContactTypeProvider();
        sTD_ContactTypes = sqlSTD_ContactTypeProvider.GetAllSTD_ContactTypes();
        return sTD_ContactTypes;
    }

	public static void sTD_ContactTypesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ContactTypePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ContactTypeProvider sqlSTD_ContactTypeProvider = new SqlSTD_ContactTypeProvider();
		DataSet ds =  sqlSTD_ContactTypeProvider.GetSTD_ContactTypePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ContactTypesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ContactType()
    {
       DataSet sTD_ContactTypes = new DataSet();
        SqlSTD_ContactTypeProvider sqlSTD_ContactTypeProvider = new SqlSTD_ContactTypeProvider();
        sTD_ContactTypes = sqlSTD_ContactTypeProvider.GetDropDownListAllSTD_ContactType();
        return sTD_ContactTypes;
    }


    public static STD_ContactType GetSTD_ContactTypeByContactTypeID(int ContactTypeID)
    {
        STD_ContactType sTD_ContactType = new STD_ContactType();
        SqlSTD_ContactTypeProvider sqlSTD_ContactTypeProvider = new SqlSTD_ContactTypeProvider();
        sTD_ContactType = sqlSTD_ContactTypeProvider.GetSTD_ContactTypeByContactTypeID(ContactTypeID);
        return sTD_ContactType;
    }


    public static int InsertSTD_ContactType(STD_ContactType sTD_ContactType)
    {
        SqlSTD_ContactTypeProvider sqlSTD_ContactTypeProvider = new SqlSTD_ContactTypeProvider();
        return sqlSTD_ContactTypeProvider.InsertSTD_ContactType(sTD_ContactType);
    }


    public static bool UpdateSTD_ContactType(STD_ContactType sTD_ContactType)
    {
        SqlSTD_ContactTypeProvider sqlSTD_ContactTypeProvider = new SqlSTD_ContactTypeProvider();
        return sqlSTD_ContactTypeProvider.UpdateSTD_ContactType(sTD_ContactType);
    }

    public static bool DeleteSTD_ContactType(int sTD_ContactTypeID)
    {
        SqlSTD_ContactTypeProvider sqlSTD_ContactTypeProvider = new SqlSTD_ContactTypeProvider();
        return sqlSTD_ContactTypeProvider.DeleteSTD_ContactType(sTD_ContactTypeID);
    }
}

