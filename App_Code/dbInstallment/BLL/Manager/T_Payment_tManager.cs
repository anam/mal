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

public class T_Payment_tManager
{
	public T_Payment_tManager()
	{
	}

    public static List<T_Payment_t> GetAllT_Payment_ts()
    {
        List<T_Payment_t> t_Payment_ts = new List<T_Payment_t>();
        SqlT_Payment_tProvider sqlT_Payment_tProvider = new SqlT_Payment_tProvider();
        t_Payment_ts = sqlT_Payment_tProvider.GetAllT_Payment_ts();
        return t_Payment_ts;
    }


    public static T_Payment_t GetT_Payment_tByID(int id)
    {
        T_Payment_t t_Payment_t = new T_Payment_t();
        SqlT_Payment_tProvider sqlT_Payment_tProvider = new SqlT_Payment_tProvider();
        t_Payment_t = sqlT_Payment_tProvider.GetT_Payment_tByID(id);
        return t_Payment_t;
    }


    public static int InsertT_Payment_t(T_Payment_t t_Payment_t)
    {
        SqlT_Payment_tProvider sqlT_Payment_tProvider = new SqlT_Payment_tProvider();
        return sqlT_Payment_tProvider.InsertT_Payment_t(t_Payment_t);
    }


    public static bool UpdateT_Payment_t(T_Payment_t t_Payment_t)
    {
        SqlT_Payment_tProvider sqlT_Payment_tProvider = new SqlT_Payment_tProvider();
        return sqlT_Payment_tProvider.UpdateT_Payment_t(t_Payment_t);
    }

    public static bool DeleteT_Payment_t(int t_Payment_tID)
    {
        SqlT_Payment_tProvider sqlT_Payment_tProvider = new SqlT_Payment_tProvider();
        return sqlT_Payment_tProvider.DeleteT_Payment_t(t_Payment_tID);
    }
}
