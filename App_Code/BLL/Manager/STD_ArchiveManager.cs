using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class STD_ArchiveManager
{
	public STD_ArchiveManager()
	{
	}

    public static List<STD_Archive> GetAllSTD_Archives()
    {
        List<STD_Archive> sTD_Archives = new List<STD_Archive>();
        SqlSTD_ArchiveProvider sqlSTD_ArchiveProvider = new SqlSTD_ArchiveProvider();
        sTD_Archives = sqlSTD_ArchiveProvider.GetAllSTD_Archives();
        return sTD_Archives;
    }


    public static STD_Archive GetSTD_ArchiveByID(int id)
    {
        STD_Archive sTD_Archive = new STD_Archive();
        SqlSTD_ArchiveProvider sqlSTD_ArchiveProvider = new SqlSTD_ArchiveProvider();
        sTD_Archive = sqlSTD_ArchiveProvider.GetSTD_ArchiveByID(id);
        return sTD_Archive;
    }


    public static int InsertSTD_Archive(STD_Archive sTD_Archive)
    {
        SqlSTD_ArchiveProvider sqlSTD_ArchiveProvider = new SqlSTD_ArchiveProvider();
        return sqlSTD_ArchiveProvider.InsertSTD_Archive(sTD_Archive);
    }


    public static bool UpdateSTD_Archive(STD_Archive sTD_Archive)
    {
        SqlSTD_ArchiveProvider sqlSTD_ArchiveProvider = new SqlSTD_ArchiveProvider();
        return sqlSTD_ArchiveProvider.UpdateSTD_Archive(sTD_Archive);
    }

    public static bool DeleteSTD_Archive(int sTD_ArchiveID)
    {
        SqlSTD_ArchiveProvider sqlSTD_ArchiveProvider = new SqlSTD_ArchiveProvider();
        return sqlSTD_ArchiveProvider.DeleteSTD_Archive(sTD_ArchiveID);
    }
}
