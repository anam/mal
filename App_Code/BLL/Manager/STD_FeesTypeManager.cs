using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_FeesTypeManager
{
	public STD_FeesTypeManager()
	{
	}

    public static DataSet  GetAllSTD_FeesTypes()
    {
       DataSet sTD_FeesTypes = new DataSet();
        SqlSTD_FeesTypeProvider sqlSTD_FeesTypeProvider = new SqlSTD_FeesTypeProvider();
        sTD_FeesTypes = sqlSTD_FeesTypeProvider.GetAllSTD_FeesTypes();
        return sTD_FeesTypes;
    }

	public static void sTD_FeesTypesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_FeesTypePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_FeesTypeProvider sqlSTD_FeesTypeProvider = new SqlSTD_FeesTypeProvider();
		DataSet ds =  sqlSTD_FeesTypeProvider.GetSTD_FeesTypePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_FeesTypesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_FeesType()
    {
       DataSet sTD_FeesTypes = new DataSet();
        SqlSTD_FeesTypeProvider sqlSTD_FeesTypeProvider = new SqlSTD_FeesTypeProvider();
        sTD_FeesTypes = sqlSTD_FeesTypeProvider.GetDropDownLisAllSTD_FeesType();
        return sTD_FeesTypes;
    }


    public static STD_FeesType GetCOMN_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_FeesType sTD_FeesType = new STD_FeesType();
        SqlSTD_FeesTypeProvider sqlSTD_FeesTypeProvider = new SqlSTD_FeesTypeProvider();
        sTD_FeesType = sqlSTD_FeesTypeProvider.GetSTD_FeesTypeByRowStatusID(RowStatusID);
        return sTD_FeesType;
    }


    public static STD_FeesType GetSTD_FeesTypeByFeesTypeID(int FeesTypeID)
    {
        STD_FeesType sTD_FeesType = new STD_FeesType();
        SqlSTD_FeesTypeProvider sqlSTD_FeesTypeProvider = new SqlSTD_FeesTypeProvider();
        sTD_FeesType = sqlSTD_FeesTypeProvider.GetSTD_FeesTypeByFeesTypeID(FeesTypeID);
        return sTD_FeesType;
    }


    public static int InsertSTD_FeesType(STD_FeesType sTD_FeesType)
    {
        SqlSTD_FeesTypeProvider sqlSTD_FeesTypeProvider = new SqlSTD_FeesTypeProvider();
        return sqlSTD_FeesTypeProvider.InsertSTD_FeesType(sTD_FeesType);
    }


    public static bool UpdateSTD_FeesType(STD_FeesType sTD_FeesType)
    {
        SqlSTD_FeesTypeProvider sqlSTD_FeesTypeProvider = new SqlSTD_FeesTypeProvider();
        return sqlSTD_FeesTypeProvider.UpdateSTD_FeesType(sTD_FeesType);
    }

    public static bool DeleteSTD_FeesType(int sTD_FeesTypeID)
    {
        SqlSTD_FeesTypeProvider sqlSTD_FeesTypeProvider = new SqlSTD_FeesTypeProvider();
        return sqlSTD_FeesTypeProvider.DeleteSTD_FeesType(sTD_FeesTypeID);
    }
}

