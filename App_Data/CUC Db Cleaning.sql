--Accounts Cleaning
Drop table ACC_VoucherIteam
Drop table ACC_Voucher
Drop table ACC_OpeningBalance
Delete ACC_JournalHistory
Delete ACC_JournalInfoForDelete
Delete ACC_Journal
Delete ACC_JournalMaster
Delete ACC_HeadUser
Delete ACC_Head
Delete ACC_BankAccount
Delete ACC_EmployPayRoleSalaryTmp
Delete ACC_EmployPayRoleSalary
Delete ACC_CUCCheck
Delete ACC_Check
Delete ACC_AccountingUser

--Inventory Clean
Delete INV_Sale
Delete INV_MRRInfoMaster
Delete INV_MRRInfo
Delete INV_ItemBarcode
Delete INV_Iteam_History
Delete INV_Issue
Delete INV_IssueMaster
Delete INV_Store
Delete INV_Iteam
Delete INV_IteamSubCategory
Delete INV_IteamCategory

-- Library Cleaning
Delete LIB_BookIssueHistory
Delete LIB_BookIssue
Delete LIB_Book
Delete LIB_Publisher
Delete LIB_Author
Delete LIB_SubCategory
Delete LIB_Category

--Quiz Cleaning
Delete Quiz_ExamQuestionDetails
Delete Quiz_StudentExamQuestions
Delete Quiz_MultipleQuestionDetails
Delete Quiz_TrueFalse
Delete Quiz_MultipleQuestion
Delete Quiz_FillInTheBlanksDetails
Delete Quiz_FillInTheBlanks
Delete Quiz_Comprehension
Delete Quiz_ExamStudent
Delete Quiz_Exam
Delete Quiz_Chapter

--Common Clean
Delete COMN_Attendence

--Student Delete
Delete STD_Batch
Delete STD_CBEExam
Delete STD_CBEExamSubject
Drop table STD_ComprehensionQuestion 
Drop table STD_Comprehension 
Drop table STD_QuestionChapter
Drop table STD_QuestionAnswer
Drop Table STD_Chapter
Drop table STD_Question 
Drop table STD_QuestionType
Delete STD_Fees
Delete STD_FeesMaster
Delete STD_Fees1
--Delete STD_FeesMaster_PU
Delete STD_ExamDetails
Delete STD_ExamDetailsStudent
Delete STD_Exam
Delete STD_ClassStudent
Delete STD_ClassSubjectStudent
Delete STD_ClassSubjectEmployeeStudent
Delete STD_ClassSubjectEmployee
Delete STD_ClassSubject
Delete STD_Program
Delete STD_Contact
Delete STD_RoutineTime
Delete STD_Room
Delete STD_ClassTime
Delete STD_ClassTimeGroup
Delete STD_Routine
Delete STD_SubjectEmployee
Delete STD_SubjectStudent
Delete STD_Class
Delete STD_Subject where CourseID<28
Delete STD_Course where CourseID<28
Delete STD_Student

--Temporary
Drop table T_Installment
Drop table T_Payment
--HR Clean
Delete HR_AbsendSalaryDiduction
Delete HR_AttendenceRules where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_BenifitPackageRules  where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_ChildrenInfo where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_Contact where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_ContactInformation where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_Documents where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EducatinalBackground where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EmployeeLeave where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EmployeeLeaveRules where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EmployeeOverTimePackage where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EmployeeSalary where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EmployeeSalaryHistory where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EmployeeSalaryRules where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EmployeeSalaryRulesHistory where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_EmployeeSchedule where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_JobPosting where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_LeavesRuleEmployee where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_LunchRule where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_OthersDocuments where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_Overtime where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_PersonalDocuments where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_PostingInformation where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_ProvidentfundAmount where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_ProvidentfundContribution where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_ProvidentFundRegister where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_RetirementsRuleEmployee where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_SalaryAdjustmentListRules where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_SalaryIncrementPackageRules where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_SalaryStucture where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_SalaryTaxPackageRules where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_TaxAmount where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_TaxContribution where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))
Delete HR_WorkingDaysShifting where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054'))     
--HR Relation with the student
Delete HR_Employee where EmployeeID not in (select EmployeeID from HR_Employee 
		where EmployeeNo in ('05120141','02120079','01120054')) 

--Asp net user
Delete aspnet_Membership where UserId in (select UserId from aspnet_Users where UserName not in ('05120141','02120079','01120054'))
Delete aspnet_UsersInRoles where UserId in (select UserId from aspnet_Users where UserName not in ('05120141','02120079','01120054'))
Delete aspnet_Profile where UserId in (select UserId from aspnet_Users where UserName not in ('05120141','02120079','01120054'))
Delete aspnet_Users where UserName not in ('05120141','02120079','01120054')
