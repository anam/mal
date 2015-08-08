using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Room
{
    public STD_Room()
    {
    }


    public STD_Room
        (
int  roomID,
int  campusID,
string  roomName,
string  description,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.RoomID = roomID;
this.CampusID = campusID;
this.RoomName = roomName;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  RoomID
    {
        get ; 
        set  ;
    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    public string  RoomName
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public string  AddedBy
    {
        get ; 
        set  ;
    }

    public DateTime  AddedDate
    {
        get ; 
        set  ;
    }

    public string  UpdatedBy
    {
        get ; 
        set  ;
    }

    public DateTime  UpdateDate
    {
        get ; 
        set  ;
    }

    public string CampusName
    {
        get;
        set;
    }
}

