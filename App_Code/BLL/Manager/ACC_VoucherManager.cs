using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class ACC_VoucherManager
{
	public ACC_VoucherManager()
	{
	}

    public static DataSet  GetAllACC_Vouchers()
    {
       DataSet aCC_Vouchers = new DataSet();
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        aCC_Vouchers = sqlACC_VoucherProvider.GetAllACC_Vouchers();
        return aCC_Vouchers;
    }

	public static void aCC_VouchersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadACC_VoucherPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
		DataSet ds =  sqlACC_VoucherProvider.GetACC_VoucherPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 aCC_VouchersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllACC_Voucher()
    {
       DataSet aCC_Vouchers = new DataSet();
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        aCC_Vouchers = sqlACC_VoucherProvider.GetDropDownLisAllACC_Voucher();
        return aCC_Vouchers;
    }

    public static DataSet   GetAllACC_VouchersWithRelation()
    {
       DataSet aCC_Vouchers = new DataSet();
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        aCC_Vouchers = sqlACC_VoucherProvider.GetAllACC_Vouchers();
        return aCC_Vouchers;
    }


    public static ACC_Voucher GetACC_HeadByHeadID(int HeadID)
    {
        ACC_Voucher aCC_Voucher = new ACC_Voucher();
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        aCC_Voucher = sqlACC_VoucherProvider.GetACC_VoucherByHeadID(HeadID);
        return aCC_Voucher;
    }


    public static ACC_Voucher GetACC_RowStatusByRowStatusID(int RowStatusID)
    {
        ACC_Voucher aCC_Voucher = new ACC_Voucher();
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        aCC_Voucher = sqlACC_VoucherProvider.GetACC_VoucherByRowStatusID(RowStatusID);
        return aCC_Voucher;
    }


    public static ACC_Voucher GetACC_VoucherByVoucherID(int VoucherID)
    {
        ACC_Voucher aCC_Voucher = new ACC_Voucher();
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        aCC_Voucher = sqlACC_VoucherProvider.GetACC_VoucherByVoucherID(VoucherID);
        return aCC_Voucher;
    }


    public static int InsertACC_Voucher(ACC_Voucher aCC_Voucher)
    {
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        return sqlACC_VoucherProvider.InsertACC_Voucher(aCC_Voucher);
    }


    public static bool UpdateACC_Voucher(ACC_Voucher aCC_Voucher)
    {
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        return sqlACC_VoucherProvider.UpdateACC_Voucher(aCC_Voucher);
    }

    public static bool DeleteACC_Voucher(int aCC_VoucherID)
    {
        SqlACC_VoucherProvider sqlACC_VoucherProvider = new SqlACC_VoucherProvider();
        return sqlACC_VoucherProvider.DeleteACC_Voucher(aCC_VoucherID);
    }
}

