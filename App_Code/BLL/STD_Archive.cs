using System;
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

public class STD_Archive
{
    public STD_Archive()
    {
    }

    public STD_Archive
        (
        int sTD_ArchiveID, 
        string archive, 
        DateTime addedDate
        )
    {
        this.STD_ArchiveID = sTD_ArchiveID;
        this.Archive = archive;
        this.AddedDate = addedDate;
    }


    private int _sTD_ArchiveID;
    public int STD_ArchiveID
    {
        get { return _sTD_ArchiveID; }
        set { _sTD_ArchiveID = value; }
    }

    private string _archive;
    public string Archive
    {
        get { return _archive; }
        set { _archive = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }
}
