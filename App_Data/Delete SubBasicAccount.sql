declare @SubBasicAccountID int
set @SubBasicAccountID=29


select JournalMasterID into #DeletedJournalMasterID from ACC_Journal 
	where HeadID in (select HeadID from ACC_Head where AccountID in
					(select AccountID from ACC_Account where SubBasicAccountID=@SubBasicAccountID))
select * from #DeletedJournalMasterID					
Delete ACC_Journal where HeadID in (select HeadID from ACC_Head where AccountID in
					(select AccountID from ACC_Account where SubBasicAccountID=@SubBasicAccountID))
					
Delete ACC_JournalMaster where JournalMasterID in (select JournalMasterID from #DeletedJournalMasterID)

drop table #DeletedJournalMasterID

delete ACC_HeadUser where HeadID in (select HeadID from ACC_Head where AccountID in
					(select AccountID from ACC_Account where SubBasicAccountID=@SubBasicAccountID))
delete ACC_Head where AccountID in
					(select AccountID from ACC_Account where SubBasicAccountID=@SubBasicAccountID)

delete ACC_Account where SubBasicAccountID=@SubBasicAccountID
delete ACC_SubBasicAccount where SubBasicAccountID=@SubBasicAccountID

					
