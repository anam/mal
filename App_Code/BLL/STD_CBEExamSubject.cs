using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for STD_CBEExamSubject
/// </summary>
public class STD_CBEExamSubject
{
	public STD_CBEExamSubject()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public STD_CBEExamSubject
        (
        int cBEExamSubjectID, 
        int cBEExamID, 
        string subjectTitle, 
        string subjectCode, 
        string taxOrPaperVariant, 
        Decimal fees,
        DateTime examDate, 
        string addedBy, 
        DateTime addedDate, 
        string updatedBy, 
        DateTime updatedDate, 
        int rowStatusID
        )
    {
        this.CBEExamSubjectID = cBEExamSubjectID;
        this.CBEExamID = cBEExamID;
        this.SubjectTitle = subjectTitle;
        this.SubjectCode = subjectCode;
        this.TaxOrPaperVariant = taxOrPaperVariant;
        this.Fees = fees;
        this.ExamDate = examDate;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;
        this.RowStatusID = rowStatusID;
    }


    private int _cBEExamSubjectID;
    public int CBEExamSubjectID
    {
        get { return _cBEExamSubjectID; }
        set { _cBEExamSubjectID = value; }
    }

    private int _cBEExamID;
    public int CBEExamID
    {
        get { return _cBEExamID; }
        set { _cBEExamID = value; }
    }

    private string _subjectTitle;
    public string SubjectTitle
    {
        get { return _subjectTitle; }
        set { _subjectTitle = value; }
    }

    private string _subjectCode;
    public string SubjectCode
    {
        get { return _subjectCode; }
        set { _subjectCode = value; }
    }

    private string _taxOrPaperVariant;
    public string TaxOrPaperVariant
    {
        get { return _taxOrPaperVariant; }
        set { _taxOrPaperVariant = value; }
    }

    private Decimal _fees;

    public Decimal Fees
    {
        get { return _fees; }
        set { _fees = value; }
    }

    private DateTime _examDate;
    public DateTime ExamDate
    {
        get { return _examDate; }
        set { _examDate = value; }
    }

    private string _addedBy;
    public string AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private string _updatedBy;
    public string UpdatedBy
    {
        get { return _updatedBy; }
        set { _updatedBy = value; }
    }

    private DateTime _updatedDate;
    public DateTime UpdatedDate
    {
        get { return _updatedDate; }
        set { _updatedDate = value; }
    }

    private int _rowStatusID;
    public int RowStatusID
    {
        get { return _rowStatusID; }
        set { _rowStatusID = value; }
    }

    public string FeesDescription
    {
        get;
        set;
    }
}