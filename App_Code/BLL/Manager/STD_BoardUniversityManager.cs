using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_BoardUniversityManager
{
	public STD_BoardUniversityManager()
	{
	}

    public static DataSet  GetAllSTD_BoardUniversities()
    {
       DataSet sTD_BoardUniversities = new DataSet();
        SqlSTD_BoardUniversityProvider sqlSTD_BoardUniversityProvider = new SqlSTD_BoardUniversityProvider();
        sTD_BoardUniversities = sqlSTD_BoardUniversityProvider.GetAllSTD_BoardUniversities();
        return sTD_BoardUniversities;
    }

	public static void sTD_BoardUniversitiesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_BoardUniversityPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_BoardUniversityProvider sqlSTD_BoardUniversityProvider = new SqlSTD_BoardUniversityProvider();
		DataSet ds =  sqlSTD_BoardUniversityProvider.GetSTD_BoardUniversityPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_BoardUniversitiesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_BoardUniversity()
    {
       DataSet sTD_BoardUniversities = new DataSet();
        SqlSTD_BoardUniversityProvider sqlSTD_BoardUniversityProvider = new SqlSTD_BoardUniversityProvider();
        sTD_BoardUniversities = sqlSTD_BoardUniversityProvider.GetDropDownListAllSTD_BoardUniversity();
        return sTD_BoardUniversities;
    }


    public static STD_BoardUniversity GetSTD_BoardUniversityByBoardUniversityID(int BoardUniversityID)
    {
        STD_BoardUniversity sTD_BoardUniversity = new STD_BoardUniversity();
        SqlSTD_BoardUniversityProvider sqlSTD_BoardUniversityProvider = new SqlSTD_BoardUniversityProvider();
        sTD_BoardUniversity = sqlSTD_BoardUniversityProvider.GetSTD_BoardUniversityByBoardUniversityID(BoardUniversityID);
        return sTD_BoardUniversity;
    }


    public static int InsertSTD_BoardUniversity(STD_BoardUniversity sTD_BoardUniversity)
    {
        SqlSTD_BoardUniversityProvider sqlSTD_BoardUniversityProvider = new SqlSTD_BoardUniversityProvider();
        return sqlSTD_BoardUniversityProvider.InsertSTD_BoardUniversity(sTD_BoardUniversity);
    }


    public static bool UpdateSTD_BoardUniversity(STD_BoardUniversity sTD_BoardUniversity)
    {
        SqlSTD_BoardUniversityProvider sqlSTD_BoardUniversityProvider = new SqlSTD_BoardUniversityProvider();
        return sqlSTD_BoardUniversityProvider.UpdateSTD_BoardUniversity(sTD_BoardUniversity);
    }

    public static bool DeleteSTD_BoardUniversity(int sTD_BoardUniversityID)
    {
        SqlSTD_BoardUniversityProvider sqlSTD_BoardUniversityProvider = new SqlSTD_BoardUniversityProvider();
        return sqlSTD_BoardUniversityProvider.DeleteSTD_BoardUniversity(sTD_BoardUniversityID);
    }
}

