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

public class AbsendSalaryDiductionManager
{
	public AbsendSalaryDiductionManager()
	{
	}

    public static List<AbsendSalaryDiduction> GetAllAbsendSalaryDiductions()
    {
        List<AbsendSalaryDiduction> absendSalaryDiductions = new List<AbsendSalaryDiduction>();
        SqlAbsendSalaryDiductionProvider sqlAbsendSalaryDiductionProvider = new SqlAbsendSalaryDiductionProvider();
        absendSalaryDiductions = sqlAbsendSalaryDiductionProvider.GetAllAbsendSalaryDiductions();
        return absendSalaryDiductions;
    }

    public static List<AbsendSalaryDiduction> GetAllAbsendSalaryDiductionsBySalaryOfMonth(string SalaryOfMonth)
    {
        List<AbsendSalaryDiduction> absendSalaryDiductions = new List<AbsendSalaryDiduction>();
        SqlAbsendSalaryDiductionProvider sqlAbsendSalaryDiductionProvider = new SqlAbsendSalaryDiductionProvider();
        absendSalaryDiductions = sqlAbsendSalaryDiductionProvider.GetAllAbsendSalaryDiductionsBySalaryOfMonth(SalaryOfMonth);
        return absendSalaryDiductions;
    }



    public static AbsendSalaryDiduction GetAbsendSalaryDiductionByID(int id)
    {
        AbsendSalaryDiduction absendSalaryDiduction = new AbsendSalaryDiduction();
        SqlAbsendSalaryDiductionProvider sqlAbsendSalaryDiductionProvider = new SqlAbsendSalaryDiductionProvider();
        absendSalaryDiduction = sqlAbsendSalaryDiductionProvider.GetAbsendSalaryDiductionByID(id);
        return absendSalaryDiduction;
    }


    public static int InsertAbsendSalaryDiduction(AbsendSalaryDiduction absendSalaryDiduction)
    {
        SqlAbsendSalaryDiductionProvider sqlAbsendSalaryDiductionProvider = new SqlAbsendSalaryDiductionProvider();
        return sqlAbsendSalaryDiductionProvider.InsertAbsendSalaryDiduction(absendSalaryDiduction);
    }


    public static bool UpdateAbsendSalaryDiduction(AbsendSalaryDiduction absendSalaryDiduction)
    {
        SqlAbsendSalaryDiductionProvider sqlAbsendSalaryDiductionProvider = new SqlAbsendSalaryDiductionProvider();
        return sqlAbsendSalaryDiductionProvider.UpdateAbsendSalaryDiduction(absendSalaryDiduction);
    }

    public static bool DeleteAbsendSalaryDiduction(int absendSalaryDiductionID)
    {
        SqlAbsendSalaryDiductionProvider sqlAbsendSalaryDiductionProvider = new SqlAbsendSalaryDiductionProvider();
        return sqlAbsendSalaryDiductionProvider.DeleteAbsendSalaryDiduction(absendSalaryDiductionID);
    }
}
