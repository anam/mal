using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_EducatinalBackgroundManager
{
	public HR_EducatinalBackgroundManager()
	{
	}

    public static DataSet  GetAllHR_EducatinalBackgrounds()
    {
       DataSet hR_EducatinalBackgrounds = new DataSet();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackgrounds = sqlHR_EducatinalBackgroundProvider.GetAllHR_EducatinalBackgrounds();
        return hR_EducatinalBackgrounds;
    }

	public static void hR_EducatinalBackgroundsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadHR_EducatinalBackgroundPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
		DataSet ds =  sqlHR_EducatinalBackgroundProvider.GetHR_EducatinalBackgroundPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 hR_EducatinalBackgroundsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllHR_EducatinalBackground()
    {
       DataSet hR_EducatinalBackgrounds = new DataSet();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackgrounds = sqlHR_EducatinalBackgroundProvider.GetDropDownListAllHR_EducatinalBackground();
        return hR_EducatinalBackgrounds;
    }

    public static DataSet   GetAllHR_EducatinalBackgroundsWithRelation()
    {
       DataSet hR_EducatinalBackgrounds = new DataSet();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackgrounds = sqlHR_EducatinalBackgroundProvider.GetAllHR_EducatinalBackgrounds();
        return hR_EducatinalBackgrounds;
    }


    public static HR_EducatinalBackground GetHR_EmployeeByEmployeeID(string EmployeeID)
    {
        HR_EducatinalBackground hR_EducatinalBackground = new HR_EducatinalBackground();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackground = sqlHR_EducatinalBackgroundProvider.GetHR_EducatinalBackgroundByEmployeeID(EmployeeID);
        return hR_EducatinalBackground;
    }


    public static HR_EducatinalBackground GetHR_YearByYearID(int YearID)
    {
        HR_EducatinalBackground hR_EducatinalBackground = new HR_EducatinalBackground();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackground = sqlHR_EducatinalBackgroundProvider.GetHR_EducatinalBackgroundByYearID(YearID);
        return hR_EducatinalBackground;
    }


    public static HR_EducatinalBackground GetHR_BoardUniversityByBoardUniversityID(int BoardUniversityID)
    {
        HR_EducatinalBackground hR_EducatinalBackground = new HR_EducatinalBackground();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackground = sqlHR_EducatinalBackgroundProvider.GetHR_EducatinalBackgroundByBoardUniversityID(BoardUniversityID);
        return hR_EducatinalBackground;
    }


    public static HR_EducatinalBackground GetHR_EducationGroupByEducationGroupID(int EducationGroupID)
    {
        HR_EducatinalBackground hR_EducatinalBackground = new HR_EducatinalBackground();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackground = sqlHR_EducatinalBackgroundProvider.GetHR_EducatinalBackgroundByEducationGroupID(EducationGroupID);
        return hR_EducatinalBackground;
    }


    public static HR_EducatinalBackground GetHR_ReaultSystemByReaultSystemID(int ReaultSystemID)
    {
        HR_EducatinalBackground hR_EducatinalBackground = new HR_EducatinalBackground();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackground = sqlHR_EducatinalBackgroundProvider.GetHR_EducatinalBackgroundByReaultSystemID(ReaultSystemID);
        return hR_EducatinalBackground;
    }


    public static HR_EducatinalBackground GetHR_EducatinalBackgroundByEducationalBacgroundID(int EducationalBacgroundID)
    {
        HR_EducatinalBackground hR_EducatinalBackground = new HR_EducatinalBackground();
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        hR_EducatinalBackground = sqlHR_EducatinalBackgroundProvider.GetHR_EducatinalBackgroundByEducationalBacgroundID(EducationalBacgroundID);
        return hR_EducatinalBackground;
    }


    public static int InsertHR_EducatinalBackground(HR_EducatinalBackground hR_EducatinalBackground)
    {
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        return sqlHR_EducatinalBackgroundProvider.InsertHR_EducatinalBackground(hR_EducatinalBackground);
    }


    public static bool UpdateHR_EducatinalBackground(HR_EducatinalBackground hR_EducatinalBackground)
    {
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        return sqlHR_EducatinalBackgroundProvider.UpdateHR_EducatinalBackground(hR_EducatinalBackground);
    }

    public static bool DeleteHR_EducatinalBackground(int hR_EducatinalBackgroundID)
    {
        SqlHR_EducatinalBackgroundProvider sqlHR_EducatinalBackgroundProvider = new SqlHR_EducatinalBackgroundProvider();
        return sqlHR_EducatinalBackgroundProvider.DeleteHR_EducatinalBackground(hR_EducatinalBackgroundID);
    }
}

