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

public class COMN_File
{
    public COMN_File()
    {
    }

    public COMN_File
        (
        int fileID, 
        string fileContent, 
        int rowStatusID, 
        DateTime addedDate, 
        string addedBy
        )
    {
        this.FileID = fileID;
        this.FileContent = fileContent;
        this.RowStatusID = rowStatusID;
        this.AddedDate = addedDate;
        this.AddedBy = addedBy;
    }


    private int _fileID;
    public int FileID
    {
        get { return _fileID; }
        set { _fileID = value; }
    }

    private string _fileContent;
    public string FileContent
    {
        get { return _fileContent; }
        set { _fileContent = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private string _addedBy;
    public string AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }
}
