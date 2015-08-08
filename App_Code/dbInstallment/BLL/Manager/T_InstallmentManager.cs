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

public class T_InstallmentManager
{
	public T_InstallmentManager()
	{
	}

    public static List<T_Installment> GetAllT_Installments()
    {
        List<T_Installment> t_Installments = new List<T_Installment>();
        SqlT_InstallmentProvider sqlT_InstallmentProvider = new SqlT_InstallmentProvider();
        t_Installments = sqlT_InstallmentProvider.GetAllT_Installments();
        return t_Installments;
    }


    public static List<T_Installment> GetAllT_InstallmentsByStudentID(string StudentID)
    {
        List<T_Installment> t_Installments = new List<T_Installment>();
        SqlT_InstallmentProvider sqlT_InstallmentProvider = new SqlT_InstallmentProvider();
        t_Installments = sqlT_InstallmentProvider.GetAllT_InstallmentsByStudentID(StudentID);
        return t_Installments;
    }

    public static T_Installment GetT_InstallmentByID(int id)
    {
        T_Installment t_Installment = new T_Installment();
        SqlT_InstallmentProvider sqlT_InstallmentProvider = new SqlT_InstallmentProvider();
        t_Installment = sqlT_InstallmentProvider.GetT_InstallmentByID(id);
        return t_Installment;
    }


    public static int InsertT_Installment(T_Installment t_Installment)
    {
        SqlT_InstallmentProvider sqlT_InstallmentProvider = new SqlT_InstallmentProvider();
        return sqlT_InstallmentProvider.InsertT_Installment(t_Installment);
    }


    public static bool UpdateT_Installment(T_Installment t_Installment)
    {
        SqlT_InstallmentProvider sqlT_InstallmentProvider = new SqlT_InstallmentProvider();
        return sqlT_InstallmentProvider.UpdateT_Installment(t_Installment);
    }

    public static bool DeleteT_Installment(int t_InstallmentID)
    {
        SqlT_InstallmentProvider sqlT_InstallmentProvider = new SqlT_InstallmentProvider();
        return sqlT_InstallmentProvider.DeleteT_Installment(t_InstallmentID);
    }
}
