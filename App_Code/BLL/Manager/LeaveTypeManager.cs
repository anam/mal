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

public class LeaveTypeManager
{
	public LeaveTypeManager()
	{
	}

    public static List<LeaveType> GetAllLeaveTypes()
    {
        List<LeaveType> leaveTypes = new List<LeaveType>();
        SqlLeaveTypeProvider sqlLeaveTypeProvider = new SqlLeaveTypeProvider();
        leaveTypes = sqlLeaveTypeProvider.GetAllLeaveTypes();
        return leaveTypes;
    }


    public static LeaveType GetLeaveTypeByID(int id)
    {
        LeaveType leaveType = new LeaveType();
        SqlLeaveTypeProvider sqlLeaveTypeProvider = new SqlLeaveTypeProvider();
        leaveType = sqlLeaveTypeProvider.GetLeaveTypeByID(id);
        return leaveType;
    }


    public static int InsertLeaveType(LeaveType leaveType)
    {
        SqlLeaveTypeProvider sqlLeaveTypeProvider = new SqlLeaveTypeProvider();
        return sqlLeaveTypeProvider.InsertLeaveType(leaveType);
    }


    public static bool UpdateLeaveType(LeaveType leaveType)
    {
        SqlLeaveTypeProvider sqlLeaveTypeProvider = new SqlLeaveTypeProvider();
        return sqlLeaveTypeProvider.UpdateLeaveType(leaveType);
    }

    public static bool DeleteLeaveType(int leaveTypeID)
    {
        SqlLeaveTypeProvider sqlLeaveTypeProvider = new SqlLeaveTypeProvider();
        return sqlLeaveTypeProvider.DeleteLeaveType(leaveTypeID);
    }
}
