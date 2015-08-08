using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassTimeGroupManager
{
	public STD_ClassTimeGroupManager()
	{
	}

    public static DataSet  GetAllSTD_ClassTimeGroups()
    {
       DataSet sTD_ClassTimeGroups = new DataSet();
        SqlSTD_ClassTimeGroupProvider sqlSTD_ClassTimeGroupProvider = new SqlSTD_ClassTimeGroupProvider();
        sTD_ClassTimeGroups = sqlSTD_ClassTimeGroupProvider.GetAllSTD_ClassTimeGroups();
        return sTD_ClassTimeGroups;
    }

	public static void sTD_ClassTimeGroupsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassTimeGroupPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassTimeGroupProvider sqlSTD_ClassTimeGroupProvider = new SqlSTD_ClassTimeGroupProvider();
		DataSet ds =  sqlSTD_ClassTimeGroupProvider.GetSTD_ClassTimeGroupPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassTimeGroupsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassTimeGroup()
    {
       DataSet sTD_ClassTimeGroups = new DataSet();
        SqlSTD_ClassTimeGroupProvider sqlSTD_ClassTimeGroupProvider = new SqlSTD_ClassTimeGroupProvider();
        sTD_ClassTimeGroups = sqlSTD_ClassTimeGroupProvider.GetDropDownLisAllSTD_ClassTimeGroup();
        return sTD_ClassTimeGroups;
    }


    public static STD_ClassTimeGroup GetHRRowStatusByRowStatusID(int RowStatusID)
    {
        STD_ClassTimeGroup sTD_ClassTimeGroup = new STD_ClassTimeGroup();
        SqlSTD_ClassTimeGroupProvider sqlSTD_ClassTimeGroupProvider = new SqlSTD_ClassTimeGroupProvider();
        sTD_ClassTimeGroup = sqlSTD_ClassTimeGroupProvider.GetSTD_ClassTimeGroupByRowStatusID(RowStatusID);
        return sTD_ClassTimeGroup;
    }


    public static STD_ClassTimeGroup GetSTD_ClassTimeGroupByClassTimeGroupID(int ClassTimeGroupID)
    {
        STD_ClassTimeGroup sTD_ClassTimeGroup = new STD_ClassTimeGroup();
        SqlSTD_ClassTimeGroupProvider sqlSTD_ClassTimeGroupProvider = new SqlSTD_ClassTimeGroupProvider();
        sTD_ClassTimeGroup = sqlSTD_ClassTimeGroupProvider.GetSTD_ClassTimeGroupByClassTimeGroupID(ClassTimeGroupID);
        return sTD_ClassTimeGroup;
    }


    public static int InsertSTD_ClassTimeGroup(STD_ClassTimeGroup sTD_ClassTimeGroup)
    {
        SqlSTD_ClassTimeGroupProvider sqlSTD_ClassTimeGroupProvider = new SqlSTD_ClassTimeGroupProvider();
        return sqlSTD_ClassTimeGroupProvider.InsertSTD_ClassTimeGroup(sTD_ClassTimeGroup);
    }


    public static bool UpdateSTD_ClassTimeGroup(STD_ClassTimeGroup sTD_ClassTimeGroup)
    {
        SqlSTD_ClassTimeGroupProvider sqlSTD_ClassTimeGroupProvider = new SqlSTD_ClassTimeGroupProvider();
        return sqlSTD_ClassTimeGroupProvider.UpdateSTD_ClassTimeGroup(sTD_ClassTimeGroup);
    }

    public static bool DeleteSTD_ClassTimeGroup(int sTD_ClassTimeGroupID)
    {
        SqlSTD_ClassTimeGroupProvider sqlSTD_ClassTimeGroupProvider = new SqlSTD_ClassTimeGroupProvider();
        return sqlSTD_ClassTimeGroupProvider.DeleteSTD_ClassTimeGroup(sTD_ClassTimeGroupID);
    }
}

