declare @AccountID int
set @AccountID=34


select JournalMasterID into #DeletedJournalMasterID from ACC_Journal 
	where HeadID in (select HeadID from ACC_Head where AccountID =@AccountID)
select * from #DeletedJournalMasterID					
Delete ACC_Journal where HeadID in (select HeadID from ACC_Head where AccountID  =@AccountID)
					
Delete ACC_JournalMaster where JournalMasterID in (select JournalMasterID from #DeletedJournalMasterID)

drop table #DeletedJournalMasterID

delete ACC_HeadUser where HeadID in (select HeadID from ACC_Head where AccountID  =@AccountID)
delete ACC_Head where AccountID  =@AccountID

delete ACC_Account where AccountID  =@AccountID