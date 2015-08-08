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

public class COMN_FileManager
{
	public COMN_FileManager()
	{
	}

    public static List<COMN_File> GetAllFiles()
    {
        List<COMN_File> COMN_Files = new List<COMN_File>();
        SqlFileProvider sqlFileProvider = new SqlFileProvider();
        COMN_Files = sqlFileProvider.GetAllFiles();
        return COMN_Files;
    }


    public static COMN_File GetFileByID(int id)
    {
        COMN_File COMN_File = new COMN_File();
        SqlFileProvider sqlFileProvider = new SqlFileProvider();
        COMN_File = sqlFileProvider.GetFileByID(id);
        return COMN_File;
    }


    public static int InsertFile(COMN_File file)
    {
        SqlFileProvider sqlFileProvider = new SqlFileProvider();
        return sqlFileProvider.InsertFile(file);
    }


    public static bool UpdateFile(COMN_File file)
    {
        SqlFileProvider sqlFileProvider = new SqlFileProvider();
        return sqlFileProvider.UpdateFile(file);
    }

    public static bool DeleteFile(int COMN_FileID)
    {
        SqlFileProvider sqlFileProvider = new SqlFileProvider();
        return sqlFileProvider.DeleteFile(COMN_FileID);
    }
}
