using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_EducatinalBackgroundManager
{
	public COMN_EducatinalBackgroundManager()
	{
	}

    public static DataSet  GetAllCOMN_EducatinalBackgrounds()
    {
       DataSet cOMN_EducatinalBackgrounds = new DataSet();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackgrounds = sqlCOMN_EducatinalBackgroundProvider.GetAllCOMN_EducatinalBackgrounds();
        return cOMN_EducatinalBackgrounds;
    }

    public static DataSet GetAllCOMN_EducatinalBackgroundsByEmployerID(string employerID)
    {
        DataSet cOMN_EducatinalBackgrounds = new DataSet();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackgrounds = sqlCOMN_EducatinalBackgroundProvider.GetAllCOMN_EducatinalBackgroundsEmployerID(employerID);
        return cOMN_EducatinalBackgrounds;
    }


	public static void cOMN_EducatinalBackgroundsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadCOMN_EducatinalBackgroundPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
		DataSet ds =  sqlCOMN_EducatinalBackgroundProvider.GetCOMN_EducatinalBackgroundPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 cOMN_EducatinalBackgroundsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllCOMN_EducatinalBackground()
    {
       DataSet cOMN_EducatinalBackgrounds = new DataSet();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackgrounds = sqlCOMN_EducatinalBackgroundProvider.GetDropDownListAllCOMN_EducatinalBackground();
        return cOMN_EducatinalBackgrounds;
    }


    public static COMN_EducatinalBackground GetCOMN_UserByUserID(string UserID)
    {
        COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackground = sqlCOMN_EducatinalBackgroundProvider.GetCOMN_EducatinalBackgroundByUserID(UserID);
        return cOMN_EducatinalBackground;
    }

    public static DataSet GetCOMN_UserByUserID(string UserID,bool isDataset)
    {
        DataSet cOMN_EducatinalBackground = new DataSet();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackground = sqlCOMN_EducatinalBackgroundProvider.GetCOMN_EducatinalBackgroundByUserID(UserID, isDataset);
        return cOMN_EducatinalBackground;
    }
    public static COMN_EducatinalBackground GetCOMN_ReaultSystemByReaultSystemID(int ReaultSystemID)
    {
        COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackground = sqlCOMN_EducatinalBackgroundProvider.GetCOMN_EducatinalBackgroundByReaultSystemID(ReaultSystemID);
        return cOMN_EducatinalBackground;
    }


    public static COMN_EducatinalBackground GetCOMN_EducatinalBackgroundByEducationalBacgroundID(int EducationalBacgroundID)
    {
        COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackground = sqlCOMN_EducatinalBackgroundProvider.GetCOMN_EducatinalBackgroundByEducationalBacgroundID(EducationalBacgroundID);
        return cOMN_EducatinalBackground;
    }


    public static int InsertCOMN_EducatinalBackground(COMN_EducatinalBackground cOMN_EducatinalBackground)
    {
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        return sqlCOMN_EducatinalBackgroundProvider.InsertCOMN_EducatinalBackground(cOMN_EducatinalBackground);
    }


    public static bool UpdateCOMN_EducatinalBackground(COMN_EducatinalBackground cOMN_EducatinalBackground)
    {
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        return sqlCOMN_EducatinalBackgroundProvider.UpdateCOMN_EducatinalBackground(cOMN_EducatinalBackground);
    }

    public static bool DeleteCOMN_EducatinalBackground(int cOMN_EducatinalBackgroundID)
    {
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        return sqlCOMN_EducatinalBackgroundProvider.DeleteCOMN_EducatinalBackground(cOMN_EducatinalBackgroundID);
    }

    public static bool DeleteCOMN_EducatinalBackgroundByUserID(string userID)
    {
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        return sqlCOMN_EducatinalBackgroundProvider.DeleteCOMN_EducatinalBackgroundByUserID(userID);
    }

    public static List<COMN_EducatinalBackground> GetCOMN_EducatinalBackgroundsByUserID(string UserID)
    {
        List<COMN_EducatinalBackground> cOMN_EducatinalBackground = new List<COMN_EducatinalBackground>();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackground = sqlCOMN_EducatinalBackgroundProvider.GetCOMN_EducatinalBackgroundsByUserID(UserID);
        return cOMN_EducatinalBackground;
    }

    public static List<COMN_EducatinalBackground> GetCOMN_EducatinalBackgroundsByEmpUserID(string UserID)
    {
        List<COMN_EducatinalBackground> cOMN_EducatinalBackground = new List<COMN_EducatinalBackground>();
        SqlCOMN_EducatinalBackgroundProvider sqlCOMN_EducatinalBackgroundProvider = new SqlCOMN_EducatinalBackgroundProvider();
        cOMN_EducatinalBackground = sqlCOMN_EducatinalBackgroundProvider.GetCOMN_EducatinalBackgroundsByEmpUserID(UserID);
        return cOMN_EducatinalBackground;
    }
}

