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

public class AttencenceManager
{
	public AttencenceManager()
	{
	}

    public static List<Attencence> GetAllAttencences()
    {
        List<Attencence> attencences = new List<Attencence>();
        SqlAttencenceProvider sqlAttencenceProvider = new SqlAttencenceProvider();
        attencences = sqlAttencenceProvider.GetAllAttencences();
        return attencences;
    }


    public static Attencence GetAttencenceByID(int id)
    {
        Attencence attencence = new Attencence();
        SqlAttencenceProvider sqlAttencenceProvider = new SqlAttencenceProvider();
        attencence = sqlAttencenceProvider.GetAttencenceByID(id);
        return attencence;
    }


    public static int InsertAttencence(Attencence attencence)
    {
        SqlAttencenceProvider sqlAttencenceProvider = new SqlAttencenceProvider();
        return sqlAttencenceProvider.InsertAttencence(attencence);
    }


    public static bool UpdateAttencence(Attencence attencence)
    {
        SqlAttencenceProvider sqlAttencenceProvider = new SqlAttencenceProvider();
        return sqlAttencenceProvider.UpdateAttencence(attencence);
    }

    public static bool DeleteAttencence(int attencenceID)
    {
        SqlAttencenceProvider sqlAttencenceProvider = new SqlAttencenceProvider();
        return sqlAttencenceProvider.DeleteAttencence(attencenceID);
    }
}
