using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class ACC_JournalInfoForDelete
{
    public ACC_JournalInfoForDelete()
    {
    }


    public ACC_JournalInfoForDelete
        (
int  journalID,
string  tableNameValue,
string  updatedBy,
DateTime  updateDate,
int  rowStatusID

        )

    {
this.JournalID = journalID;
this.TableNameValue = tableNameValue;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.RowStatusID = rowStatusID;

    }

    public int  JournalID
    {
        get ; 
        set  ;
    }


    /// <summary>
    /// Formal: tableName:PrimaryKeyValue
    /// 
    /// ACC_Check --> sp --> InsertACC_Check
    /// ACC_CUCCheck --> sp  --> InsertACC_CUCCheck
    /// ACC_EmployPayRoleSalary --> sp  --> UpdateACC_EmployPayRoleSalary
    /// STD_FeesMaster --> sp --> UpdateSTD_FeesMaster
    /// </summary>
    public string  TableNameValue
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

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

}

