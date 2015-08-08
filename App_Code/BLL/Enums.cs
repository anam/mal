using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Enums
/// </summary>
public class Enums
{
	public Enums()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public enum SalaryStatus
    {
        Paid=35,
        PartiallyPaid=36,
        Unpaid=37
    }

    public enum QuestionTypes
    {
        TrueFalse = 1,
        DrCr = 2,
        MCQ = 3,
        FillInTheBlanks = 4,
        Comprehension = 5
    }

    public enum RowStatus
    {
        Active = 1,
        Disabled = 2,
        Deleted = 3,
        Approved = 4,
        Not_Approved = 5,
        Waiting4Approval = 6,
        TemporaryInsertedInDB = 7,
        Bounched_Check = 8,
        CheckTransactionCompleted = 9
    }
}