using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_EducationGroupManager
{
	public STD_EducationGroupManager()
	{
	}

    public static DataSet  GetAllSTD_EducationGroups()
    {
       DataSet sTD_EducationGroups = new DataSet();
        SqlSTD_EducationGroupProvider sqlSTD_EducationGroupProvider = new SqlSTD_EducationGroupProvider();
        sTD_EducationGroups = sqlSTD_EducationGroupProvider.GetAllSTD_EducationGroups();
        return sTD_EducationGroups;
    }

	public static void sTD_EducationGroupsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_EducationGroupPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_EducationGroupProvider sqlSTD_EducationGroupProvider = new SqlSTD_EducationGroupProvider();
		DataSet ds =  sqlSTD_EducationGroupProvider.GetSTD_EducationGroupPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_EducationGroupsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_EducationGroup()
    {
       DataSet sTD_EducationGroups = new DataSet();
        SqlSTD_EducationGroupProvider sqlSTD_EducationGroupProvider = new SqlSTD_EducationGroupProvider();
        sTD_EducationGroups = sqlSTD_EducationGroupProvider.GetDropDownListAllSTD_EducationGroup();
        return sTD_EducationGroups;
    }


    public static STD_EducationGroup GetSTD_EducationGroupByEducationGroupID(int EducationGroupID)
    {
        STD_EducationGroup sTD_EducationGroup = new STD_EducationGroup();
        SqlSTD_EducationGroupProvider sqlSTD_EducationGroupProvider = new SqlSTD_EducationGroupProvider();
        sTD_EducationGroup = sqlSTD_EducationGroupProvider.GetSTD_EducationGroupByEducationGroupID(EducationGroupID);
        return sTD_EducationGroup;
    }


    public static int InsertSTD_EducationGroup(STD_EducationGroup sTD_EducationGroup)
    {
        SqlSTD_EducationGroupProvider sqlSTD_EducationGroupProvider = new SqlSTD_EducationGroupProvider();
        return sqlSTD_EducationGroupProvider.InsertSTD_EducationGroup(sTD_EducationGroup);
    }


    public static bool UpdateSTD_EducationGroup(STD_EducationGroup sTD_EducationGroup)
    {
        SqlSTD_EducationGroupProvider sqlSTD_EducationGroupProvider = new SqlSTD_EducationGroupProvider();
        return sqlSTD_EducationGroupProvider.UpdateSTD_EducationGroup(sTD_EducationGroup);
    }

    public static bool DeleteSTD_EducationGroup(int sTD_EducationGroupID)
    {
        SqlSTD_EducationGroupProvider sqlSTD_EducationGroupProvider = new SqlSTD_EducationGroupProvider();
        return sqlSTD_EducationGroupProvider.DeleteSTD_EducationGroup(sTD_EducationGroupID);
    }
}

