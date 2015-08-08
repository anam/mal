using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public class INV_MRRInfoManager
{
    public INV_MRRInfoManager()
    {
    }

    public static DataSet GetAllINV_MRRInfos()
    {
        DataSet iNV_MRRInfos = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfos = sqlINV_MRRInfoProvider.GetAllINV_MRRInfos();
        return iNV_MRRInfos;
    }



    public static DataSet GetAllINV_MRRInfos1(string desc1, string desc2)
    {
        DataSet iNV_MRRInfos = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfos = sqlINV_MRRInfoProvider.GetAllINV_MRRInfos1(desc1, desc2);
        return iNV_MRRInfos;
    }//GetAllINV_Items    GetAllINV_IssueNo   GetAllINV_InvoiseNo
    public static DataSet GetAllINV_IssueNo(string desc1)
    {
        DataSet iNV_Issue = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_IssueNo = new SqlINV_MRRInfoProvider();
        iNV_Issue = sqlINV_IssueNo.GetAllINV_IssueNo(desc1);
        return iNV_Issue;
    }

    public static DataSet GetAllINV_InvoiseNo(string desc1)
    {
        DataSet iNV_Issue = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_IssueNo = new SqlINV_MRRInfoProvider();
        iNV_Issue = sqlINV_IssueNo.GetAllINV_InvoiseNo(desc1);
        return iNV_Issue;
    }

    public static DataSet GetAllINV_Items(string desc1)
    {
        DataSet INV_Items = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        INV_Items = sqlINV_MRRInfoProvider.GetAllINV_Items(desc1);
        return INV_Items;
    }
    //FinalUpdateMrrMaster


    public static void iNV_MRRInfosPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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

    public static void LoadINV_MRRInfoPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        DataSet ds = sqlINV_MRRInfoProvider.GetINV_MRRInfoPageWise(pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        iNV_MRRInfosPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet GetINV_MRRInfoBySearchString(string searchSQLString)
    {
        DataSet iNV_MRRInfos = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfos = sqlINV_MRRInfoProvider.GetINV_MRRInfoBySearchString(searchSQLString);
        return iNV_MRRInfos;
    }

    public static DataSet GetDropDownListAllINV_MRRInfo()
    {
        DataSet iNV_MRRInfos = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfos = sqlINV_MRRInfoProvider.GetDropDownListAllINV_MRRInfo();
        return iNV_MRRInfos;
    }

    public static DataSet GetAllINV_MRRInfosWithRelation()
    {
        DataSet iNV_MRRInfos = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfos = sqlINV_MRRInfoProvider.GetAllINV_MRRInfos();
        return iNV_MRRInfos;
    }

    public static DataSet GetAllINV_MRRInfosByMRRID(string MRRInfoID)
    {
        DataSet iNV_MRRInfos = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfos = sqlINV_MRRInfoProvider.GetAllINV_MRRInfosByMRRID(MRRInfoID);
        return iNV_MRRInfos;
    }
    //GetAllINV_MRRReportsDateWise
    public static DataSet GetAllINV_MRRReportsDateWise(string storProcedure, string txtFromDate, string txtToDate)
    {
        DataSet iNV_MRRInfos = new DataSet();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfos = sqlINV_MRRInfoProvider.GetAllINV_MRRReportsDateWise(storProcedure, txtFromDate, txtToDate);
        return iNV_MRRInfos;
    }


    public static INV_MRRInfo GetSTD_CampusByCampusID(int CampusID)
    {
        INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfo = sqlINV_MRRInfoProvider.GetINV_MRRInfoByCampusID(CampusID);
        return iNV_MRRInfo;
    }


    public static INV_MRRInfo GetINV_MRRInfoMasterByMRRInfoMasterID(int MRRInfoMasterID)
    {
        INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfo = sqlINV_MRRInfoProvider.GetINV_MRRInfoByMRRInfoMasterID(MRRInfoMasterID);
        return iNV_MRRInfo;
    }


    public static INV_MRRInfo GetINV_IteamByIteamID(int IteamID)
    {
        INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfo = sqlINV_MRRInfoProvider.GetINV_MRRInfoByIteamID(IteamID);
        return iNV_MRRInfo;
    }


    public static INV_MRRInfo GetINV_TagByTagID(string TagID)
    {
        INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfo = sqlINV_MRRInfoProvider.GetINV_MRRInfoByTagID(TagID);
        return iNV_MRRInfo;
    }


    public static INV_MRRInfo GetINV_StoreByStoreID(int StoreID)
    {
        INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfo = sqlINV_MRRInfoProvider.GetINV_MRRInfoByStoreID(StoreID);
        return iNV_MRRInfo;
    }


    public static INV_MRRInfo GetINV_MRRInfoByMRRInfoID(int MRRInfoID)
    {
        INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        iNV_MRRInfo = sqlINV_MRRInfoProvider.GetINV_MRRInfoByMRRInfoID(MRRInfoID);
        return iNV_MRRInfo;
    }


    public static int InsertINV_MRRInfo(INV_MRRInfo iNV_MRRInfo)
    {
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        return sqlINV_MRRInfoProvider.InsertINV_MRRInfo(iNV_MRRInfo);
    }


    public static bool UpdateINV_MRRInfo(INV_MRRInfo iNV_MRRInfo)
    {
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        return sqlINV_MRRInfoProvider.UpdateINV_MRRInfo(iNV_MRRInfo);
    }

    public static bool DeleteINV_MRRInfo(int iNV_MRRInfoID)
    {
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        return sqlINV_MRRInfoProvider.DeleteINV_MRRInfo(iNV_MRRInfoID);
    }

    //----------------------------------- insert --------------------
    public static int FinalUpdateMrrMaster(string spname, string desc1, string desc2, string desc3, string Campusid)
    {
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        return sqlINV_MRRInfoProvider.FinalUpdateMrrMaster(spname, desc1, desc2, desc3, Campusid);
    }//  InsertIssueMaster("INV_InsertIssueMaster", issueno, storeid, procod, proqty, issuedate);

    public static int InsertIssueMaster(string spname, string issueno, string storeid, string masterName, string proqty, string issuedate, string CampusId) //insert Issue Master
    {
        SqlINV_MRRInfoProvider sqlINV_InsertIssueMaster = new SqlINV_MRRInfoProvider();
        return sqlINV_InsertIssueMaster.InsertIssueMaster(spname, issueno, storeid, masterName, proqty, issuedate, CampusId);
    }
    //----------------------------- Details ----------------------------------  FinalUpdateMRRDetails("INV_InsertMRRDetails", mrrno, sircode, tagid, mrrqty, mrramt, salamt, mrrdate, storeid);
    public static int FinalUpdateMRRDetails(string spname, string mrrno, string mrrMasterID, string CampusID, string sircode, string tagid, string mrrqty, string mrramt, string salamt, string mrrdate, string storeid)
    {
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        return sqlINV_MRRInfoProvider.FinalUpdateMRRDetails(spname, mrrno, mrrMasterID, CampusID, sircode, tagid, mrrqty, mrramt, salamt, mrrdate, storeid);
    }
    //InsertIssueDetails("InsertINV_IssueDetail", CampusId, IssueMasterId, storeid, issueno, itemcod, tagid, itemqty, issdate1);
    // --------------- InsertIssueDetails --------------
    public static int InsertIssueDetails(string spname, string CampusId, string IssueMasterId, string storeid, string issueno, string itemcod, string tagid, string itemqty, string issdate1)
    {
        SqlINV_MRRInfoProvider sqlINV_MRRInfoProvider = new SqlINV_MRRInfoProvider();
        return sqlINV_MRRInfoProvider.InsertIssueDetails(spname, CampusId, IssueMasterId, storeid, issueno, itemcod, tagid, itemqty, issdate1);
    }

    //public DataSet DataRelation(string procedure, string CallType, string TblName, string desc1,
    //       string desc2, string desc3, string desc4, string desc5, string desc6, string desc7, string desc8)
    //{//frmControlcode,frmCodeBooks,
    //    SqlUserProvider sqlUserProvider = new SqlUserProvider();
    //    try
    //    {

    //        string SQL = procedure;
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.CommandText = SQL;
    //        cmd.CommandType = CommandType.StoredProcedure;

    //        cmd.Parameters.Add(new SqlParameter("@CallType", CallType));
    //        cmd.Parameters.Add(new SqlParameter("@TblName", TblName));
    //        cmd.Parameters.Add(new SqlParameter("@Desc1", desc1));
    //        cmd.Parameters.Add(new SqlParameter("@Desc2", desc2));
    //        cmd.Parameters.Add(new SqlParameter("@Desc3", desc3));
    //        cmd.Parameters.Add(new SqlParameter("@Desc4", desc4));
    //        cmd.Parameters.Add(new SqlParameter("@Desc5", desc5));
    //        cmd.Parameters.Add(new SqlParameter("@Desc6", desc6));
    //        cmd.Parameters.Add(new SqlParameter("@Desc7", desc7));

    //        DataSet result = sqlUserProvider.GetDataSet(cmd);
    //        if (result == null)  //_result==false
    //        {
    //            //this.SetError(_dataAccess.ErrorObject);
    //            return null;
    //        }
    //        return result;
    //    }
    //    catch (Exception exp)
    //    {
    //        //this.SetError(exp);
    //        return null;
    //    }// try
    //}
}

