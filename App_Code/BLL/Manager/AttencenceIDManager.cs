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

public class AttencenceIDManager
{
	public AttencenceIDManager()
	{
	}

    public static List<AttencenceID> GetAllAttencenceIDs()
    {
        List<AttencenceID> attencenceIDs = new List<AttencenceID>();
        SqlAttencenceIDProvider sqlAttencenceIDProvider = new SqlAttencenceIDProvider();
        attencenceIDs = sqlAttencenceIDProvider.GetAllAttencenceIDs();
        return attencenceIDs;
    }


    public static AttencenceID GetAttencenceIDByID(int id)
    {
        AttencenceID attencenceID = new AttencenceID();
        SqlAttencenceIDProvider sqlAttencenceIDProvider = new SqlAttencenceIDProvider();
        attencenceID = sqlAttencenceIDProvider.GetAttencenceIDByID(id);
        return attencenceID;
    }


    public static int InsertAttencenceID(AttencenceID attencenceID)
    {
        SqlAttencenceIDProvider sqlAttencenceIDProvider = new SqlAttencenceIDProvider();
        return sqlAttencenceIDProvider.InsertAttencenceID(attencenceID);
    }


    public static bool UpdateAttencenceID(AttencenceID attencenceID)
    {
        SqlAttencenceIDProvider sqlAttencenceIDProvider = new SqlAttencenceIDProvider();
        return sqlAttencenceIDProvider.UpdateAttencenceID(attencenceID);
    }

    public static bool DeleteAttencenceID(int attencenceIDID)
    {
        SqlAttencenceIDProvider sqlAttencenceIDProvider = new SqlAttencenceIDProvider();
        return sqlAttencenceIDProvider.DeleteAttencenceID(attencenceIDID);
    }
}
