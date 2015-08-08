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

public class T_installment_tManager
{
	public T_installment_tManager()
	{
	}

    public static List<T_installment_t> GetAllT_installment_ts()
    {
        List<T_installment_t> t_installment_ts = new List<T_installment_t>();
        SqlT_installment_tProvider sqlT_installment_tProvider = new SqlT_installment_tProvider();
        t_installment_ts = sqlT_installment_tProvider.GetAllT_installment_ts();
        return t_installment_ts;
    }


    public static T_installment_t GetT_installment_tByID(int id)
    {
        T_installment_t t_installment_t = new T_installment_t();
        SqlT_installment_tProvider sqlT_installment_tProvider = new SqlT_installment_tProvider();
        t_installment_t = sqlT_installment_tProvider.GetT_installment_tByID(id);
        return t_installment_t;
    }


    public static int InsertT_installment_t(T_installment_t t_installment_t)
    {
        SqlT_installment_tProvider sqlT_installment_tProvider = new SqlT_installment_tProvider();
        return sqlT_installment_tProvider.InsertT_installment_t(t_installment_t);
    }


    public static bool UpdateT_installment_t(T_installment_t t_installment_t)
    {
        SqlT_installment_tProvider sqlT_installment_tProvider = new SqlT_installment_tProvider();
        return sqlT_installment_tProvider.UpdateT_installment_t(t_installment_t);
    }

    public static bool DeleteT_installment_t(int t_installment_tID)
    {
        SqlT_installment_tProvider sqlT_installment_tProvider = new SqlT_installment_tProvider();
        return sqlT_installment_tProvider.DeleteT_installment_t(t_installment_tID);
    }
}
