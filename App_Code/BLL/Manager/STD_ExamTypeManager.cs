using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ExamTypeManager
{
	public STD_ExamTypeManager()
	{
	}

    public static DataSet  GetAllSTD_ExamTypes()
    {
       DataSet sTD_ExamTypes = new DataSet();
        SqlSTD_ExamTypeProvider sqlSTD_ExamTypeProvider = new SqlSTD_ExamTypeProvider();
        sTD_ExamTypes = sqlSTD_ExamTypeProvider.GetAllSTD_ExamTypes();
        return sTD_ExamTypes;
    }

	public static void sTD_ExamTypesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ExamTypePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ExamTypeProvider sqlSTD_ExamTypeProvider = new SqlSTD_ExamTypeProvider();
		DataSet ds =  sqlSTD_ExamTypeProvider.GetSTD_ExamTypePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ExamTypesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ExamType()
    {
       DataSet sTD_ExamTypes = new DataSet();
        SqlSTD_ExamTypeProvider sqlSTD_ExamTypeProvider = new SqlSTD_ExamTypeProvider();
        sTD_ExamTypes = sqlSTD_ExamTypeProvider.GetDropDownLisAllSTD_ExamType();
        return sTD_ExamTypes;
    }


    public static STD_ExamType GetSTD_RowStatusByRowStatusID(int RowStatusID)
    {
        STD_ExamType sTD_ExamType = new STD_ExamType();
        SqlSTD_ExamTypeProvider sqlSTD_ExamTypeProvider = new SqlSTD_ExamTypeProvider();
        sTD_ExamType = sqlSTD_ExamTypeProvider.GetSTD_ExamTypeByRowStatusID(RowStatusID);
        return sTD_ExamType;
    }


    public static STD_ExamType GetSTD_ExamTypeByExamTypeID(int ExamTypeID)
    {
        STD_ExamType sTD_ExamType = new STD_ExamType();
        SqlSTD_ExamTypeProvider sqlSTD_ExamTypeProvider = new SqlSTD_ExamTypeProvider();
        sTD_ExamType = sqlSTD_ExamTypeProvider.GetSTD_ExamTypeByExamTypeID(ExamTypeID);
        return sTD_ExamType;
    }


    public static int InsertSTD_ExamType(STD_ExamType sTD_ExamType)
    {
        SqlSTD_ExamTypeProvider sqlSTD_ExamTypeProvider = new SqlSTD_ExamTypeProvider();
        return sqlSTD_ExamTypeProvider.InsertSTD_ExamType(sTD_ExamType);
    }


    public static bool UpdateSTD_ExamType(STD_ExamType sTD_ExamType)
    {
        SqlSTD_ExamTypeProvider sqlSTD_ExamTypeProvider = new SqlSTD_ExamTypeProvider();
        return sqlSTD_ExamTypeProvider.UpdateSTD_ExamType(sTD_ExamType);
    }

    public static bool DeleteSTD_ExamType(int sTD_ExamTypeID)
    {
        SqlSTD_ExamTypeProvider sqlSTD_ExamTypeProvider = new SqlSTD_ExamTypeProvider();
        return sqlSTD_ExamTypeProvider.DeleteSTD_ExamType(sTD_ExamTypeID);
    }
}

