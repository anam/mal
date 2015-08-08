using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class INV_SaleManager
{
	public INV_SaleManager()
	{
	}

    public static DataSet  GetAllINV_Sales()
    {
       DataSet iNV_Sales = new DataSet();
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        iNV_Sales = sqlINV_SaleProvider.GetAllINV_Sales();
        return iNV_Sales;
    }

	public static void iNV_SalesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadINV_SalePage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
		DataSet ds =  sqlINV_SaleProvider.GetINV_SalePageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 iNV_SalesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllINV_Sale()
    {
       DataSet iNV_Sales = new DataSet();
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        iNV_Sales = sqlINV_SaleProvider.GetDropDownListAllINV_Sale();
        return iNV_Sales;
    }

    public static DataSet   GetAllINV_SalesWithRelation()
    {
       DataSet iNV_Sales = new DataSet();
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        iNV_Sales = sqlINV_SaleProvider.GetAllINV_Sales();
        return iNV_Sales;
    }
    public static DataSet GetAllINV_TakaInWord(string InvoiseNo)
    {
        DataSet iNV_Sales = new DataSet();
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        iNV_Sales = sqlINV_SaleProvider.GetAllINV_TakaInWord(InvoiseNo);
        return iNV_Sales;
    }


    public static INV_Sale GetSTD_CampusByCampusID(int CampusID)
    {
        INV_Sale iNV_Sale = new INV_Sale();
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        iNV_Sale = sqlINV_SaleProvider.GetINV_SaleByCampusID(CampusID);
        return iNV_Sale;
    }


    public static INV_Sale GetINV_IteamByIteamID(int IteamID)
    {
        INV_Sale iNV_Sale = new INV_Sale();
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        iNV_Sale = sqlINV_SaleProvider.GetINV_SaleByIteamID(IteamID);
        return iNV_Sale;
    }


    public static INV_Sale GetINV_SaleBySaleID(int SaleID)
    {
        INV_Sale iNV_Sale = new INV_Sale();
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        iNV_Sale = sqlINV_SaleProvider.GetINV_SaleBySaleID(SaleID);
        return iNV_Sale;
    }


    public static int InsertINV_Sale(INV_Sale iNV_Sale)
    {
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        return sqlINV_SaleProvider.InsertINV_Sale(iNV_Sale);
    }

    public static int InsertINV_SaleInsert(string stprose, string Invoice, string SIRCODE, string TAGID, string WARRENTY, string QUANTITY, string UNITPRICE, string InvDate, string invCampus, string remarks)
    {
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        return sqlINV_SaleProvider.InsertINV_SaleInsert(stprose,Invoice, SIRCODE, TAGID, WARRENTY, QUANTITY, UNITPRICE, InvDate, invCampus, remarks);
    }

    public static bool UpdateINV_Sale(INV_Sale iNV_Sale)
    {
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        return sqlINV_SaleProvider.UpdateINV_Sale(iNV_Sale);
    }

    public static bool DeleteINV_Sale(int iNV_SaleID)
    {
        SqlINV_SaleProvider sqlINV_SaleProvider = new SqlINV_SaleProvider();
        return sqlINV_SaleProvider.DeleteINV_Sale(iNV_SaleID);
    }
}

