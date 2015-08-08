using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class INV_MRRInfoMaster
{
    public INV_MRRInfoMaster()
    {
    }


    public INV_MRRInfoMaster
        (
int  mRRInfoMasterID,
string  mRRInfoMasterName,
int  campusID,
string  mRRCode,
DateTime  mRRDate,
int  storeID

        )

    {
this.MRRInfoMasterID = mRRInfoMasterID;
this.MRRInfoMasterName = mRRInfoMasterName;
this.CampusID = campusID;
this.MRRCode = mRRCode;
this.MRRDate = mRRDate;
this.StoreID = storeID;

    }

    public int  MRRInfoMasterID
    {
        get ; 
        set  ;
    }

    public string  MRRInfoMasterName
    {
        get ; 
        set  ;
    }

    public int  CampusID
    {
        get ; 
        set  ;
    }

    public string  MRRCode
    {
        get ; 
        set  ;
    }

    public DateTime  MRRDate
    {
        get ; 
        set  ;
    }

    public int  StoreID
    {
        get ; 
        set  ;
    }

}

