using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class HR_BenifitPackageRulesManager
{
	public HR_BenifitPackageRulesManager()
	{
	}

    public static DataSet  GetAllHR_BenifitPackageRules()
    {
       DataSet hR_BenifitPackages = new DataSet();
        return hR_BenifitPackages;
    }

    //public static HR_BenifitPackageRules GetHR_BenifitPackageRulesByBenifitPackageRulesID(int BenifitPackageRulesID)
    //{
    //    HR_BenifitPackageRules hR_BenifitPackageRules = new HR_BenifitPackageRules();
    //    SqlHR_BenifitPackageRulesProvider sqlHR_BenifitPackageRulesProvider = new SqlHR_BenifitPackageRulesProvider();
    //    hR_BenifitPackageRules = sqlHR_BenifitPackageRulesProvider.GetHR_BenifitPackageRulesByBenifitPackageRulesID(BenifitPackageRulesID);
    //    return hR_BenifitPackageRules;
    //}

    public static HR_BenifitPackageRules GetHR_BenifitPackageRulesByEmployeeID(string employeeID)
    {
        HR_BenifitPackageRules hR_BenifitPackageRules = new HR_BenifitPackageRules();
        SqlHR_BenifitPackageRulesProvider sqlHR_BenifitPackageRulesProvider = new SqlHR_BenifitPackageRulesProvider();
        hR_BenifitPackageRules = sqlHR_BenifitPackageRulesProvider.GetHR_BenifitPackageRulesByEmployeeID(employeeID);
        return hR_BenifitPackageRules;
    }

    public static DataSet GetAllHR_BenifitPackageRulesByEmployeeID(string employeeID)
    {
        DataSet hR_BenifitPackageRulesDataSet = new DataSet();
        SqlHR_BenifitPackageRulesProvider sqlHR_BenifitPackageRulesProvider = new SqlHR_BenifitPackageRulesProvider();
        hR_BenifitPackageRulesDataSet = sqlHR_BenifitPackageRulesProvider.GetAllHR_BenifitPackageRulesByEmployeeID(employeeID);
        return hR_BenifitPackageRulesDataSet;
    }

    public static bool IsEmployeeExist(string employeeID)
    {
        SqlHR_BenifitPackageRulesProvider sqlHR_BenifitPackageRulesProvider = new SqlHR_BenifitPackageRulesProvider();
        return sqlHR_BenifitPackageRulesProvider.IsEmployeeExist(employeeID);
    }

    public static int InsertHR_BenifitPackageRules(HR_BenifitPackageRules hR_BenifitPackageRules)
    {
        SqlHR_BenifitPackageRulesProvider sqlHR_BenifitPackageRulesProvider = new SqlHR_BenifitPackageRulesProvider();
        return sqlHR_BenifitPackageRulesProvider.InsertHR_BenifitPackageRules(hR_BenifitPackageRules);
    }


    //public static bool UpdateHR_BenifitPackageRules(HR_BenifitPackageRules hR_BenifitPackageRules)
    //{
    //    SqlHR_BenifitPackageRulesProvider sqlHR_BenifitPackageRulesProvider = new SqlHR_BenifitPackageRulesProvider();
    //    return sqlHR_BenifitPackageRulesProvider.UpdateHR_BenifitPackageRules(hR_BenifitPackageRules);
    //}


    public static bool DeleteHR_BenifitPackageRulesByEmpIDAndBenPackageID(string employeeID, int benifitPackageID)
    {
        SqlHR_BenifitPackageRulesProvider sqlHR_BenifitPackageRulesProvider = new SqlHR_BenifitPackageRulesProvider();
        return sqlHR_BenifitPackageRulesProvider.DeleteHR_BenifitPackageRulesByEmpIDAndBenPackageID(employeeID, benifitPackageID);
    }
    public static bool DeleteHR_BenifitPackageRules(int hR_BenifitPackageRulesID)
    {
        SqlHR_BenifitPackageRulesProvider sqlHR_BenifitPackageRulesProvider = new SqlHR_BenifitPackageRulesProvider();
        return sqlHR_BenifitPackageRulesProvider.DeleteHR_BenifitPackageRules(hR_BenifitPackageRulesID);
    }
}

