using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_RoomManager
{
	public STD_RoomManager()
	{
	}

    public static DataSet  GetAllSTD_Rooms()
    {
       DataSet sTD_Rooms = new DataSet();
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        sTD_Rooms = sqlSTD_RoomProvider.GetAllSTD_Rooms();
        return sTD_Rooms;
    }

	public static void sTD_RoomsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
		{
		double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
		int pageCount = (int)Math.Ceiling(dblPageCount);
		List<ListItem> pages = new List<ListItem>();
		if (pageCount > 0)
		{
 		pages.Add(new ListItem("First", "1", currentPage > 1));
		for (int i = 1; i <= pageCount; i++)
		{
		 pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
		}
		pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
		}
		rptPager.DataSource = pages;
		rptPager.DataBind();
		}
 	public static void LoadSTD_RoomPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
		DataSet ds =  sqlSTD_RoomProvider.GetSTD_RoomPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_RoomsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Room()
    {
       DataSet sTD_Rooms = new DataSet();
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        sTD_Rooms = sqlSTD_RoomProvider.GetDropDownListAllSTD_Room();
        return sTD_Rooms;
    }

    public static DataSet   GetAllSTD_RoomsWithRelation()
    {
       DataSet sTD_Rooms = new DataSet();
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        sTD_Rooms = sqlSTD_RoomProvider.GetAllSTD_Rooms();
        return sTD_Rooms;
    }


    public static STD_Room GetSTD_CampusByCampusID(int CampusID)
    {
        STD_Room sTD_Room = new STD_Room();
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        sTD_Room = sqlSTD_RoomProvider.GetSTD_RoomByCampusID(CampusID);
        return sTD_Room;
    }


    public static STD_Room GetSTD_RoomByRoomID(int RoomID)
    {
        STD_Room sTD_Room = new STD_Room();
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        sTD_Room = sqlSTD_RoomProvider.GetSTD_RoomByRoomID(RoomID);
        return sTD_Room;
    }


    public static int InsertSTD_Room(STD_Room sTD_Room)
    {
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        return sqlSTD_RoomProvider.InsertSTD_Room(sTD_Room);
    }


    public static bool UpdateSTD_Room(STD_Room sTD_Room)
    {
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        return sqlSTD_RoomProvider.UpdateSTD_Room(sTD_Room);
    }

    public static bool DeleteSTD_Room(int sTD_RoomID)
    {
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        return sqlSTD_RoomProvider.DeleteSTD_Room(sTD_RoomID);
    }

    public static DataSet GetSTD_CampusByCampusID(long CampusID)
    {
        DataSet sTD_Rooms = new DataSet();
        SqlSTD_RoomProvider sqlSTD_RoomProvider = new SqlSTD_RoomProvider();
        sTD_Rooms = sqlSTD_RoomProvider.GetSTD_RoomByCampusID(CampusID);
        return sTD_Rooms;
    }
}

