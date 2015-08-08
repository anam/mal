using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ClassTypeManager
{
	public STD_ClassTypeManager()
	{
	}

    public static DataSet  GetAllSTD_ClassTypes()
    {
       DataSet sTD_ClassTypes = new DataSet();
        SqlSTD_ClassTypeProvider sqlSTD_ClassTypeProvider = new SqlSTD_ClassTypeProvider();
        sTD_ClassTypes = sqlSTD_ClassTypeProvider.GetAllSTD_ClassTypes();
        return sTD_ClassTypes;
    }

	public static void sTD_ClassTypesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ClassTypePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ClassTypeProvider sqlSTD_ClassTypeProvider = new SqlSTD_ClassTypeProvider();
		DataSet ds =  sqlSTD_ClassTypeProvider.GetSTD_ClassTypePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ClassTypesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ClassType()
    {
       DataSet sTD_ClassTypes = new DataSet();
        SqlSTD_ClassTypeProvider sqlSTD_ClassTypeProvider = new SqlSTD_ClassTypeProvider();
        sTD_ClassTypes = sqlSTD_ClassTypeProvider.GetDropDownListAllSTD_ClassType();
        return sTD_ClassTypes;
    }


    public static STD_ClassType GetSTD_ClassTypeByClassTypeID(int ClassTypeID)
    {
        STD_ClassType sTD_ClassType = new STD_ClassType();
        SqlSTD_ClassTypeProvider sqlSTD_ClassTypeProvider = new SqlSTD_ClassTypeProvider();
        sTD_ClassType = sqlSTD_ClassTypeProvider.GetSTD_ClassTypeByClassTypeID(ClassTypeID);
        return sTD_ClassType;
    }


    public static int InsertSTD_ClassType(STD_ClassType sTD_ClassType)
    {
        SqlSTD_ClassTypeProvider sqlSTD_ClassTypeProvider = new SqlSTD_ClassTypeProvider();
        return sqlSTD_ClassTypeProvider.InsertSTD_ClassType(sTD_ClassType);
    }


    public static bool UpdateSTD_ClassType(STD_ClassType sTD_ClassType)
    {
        SqlSTD_ClassTypeProvider sqlSTD_ClassTypeProvider = new SqlSTD_ClassTypeProvider();
        return sqlSTD_ClassTypeProvider.UpdateSTD_ClassType(sTD_ClassType);
    }

    public static bool DeleteSTD_ClassType(int sTD_ClassTypeID)
    {
        SqlSTD_ClassTypeProvider sqlSTD_ClassTypeProvider = new SqlSTD_ClassTypeProvider();
        return sqlSTD_ClassTypeProvider.DeleteSTD_ClassType(sTD_ClassTypeID);
    }
}

