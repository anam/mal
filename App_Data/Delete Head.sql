SELECT distinct ACC_Head.HeadID into #HeadID from ACC_Head inner join ACC_HeadUser on
ACC_HeadUser.HeadID =ACC_Head.HeadID
where ACC_Head.HeadID=320

select Distinct ACC_Journal.JournalMasterID  into #JournalMasterID
from ACC_Journal where HeadID in 
(SELECT HeadID from #HeadID)

Delete ACC_Journal where JournalMasterID in (select JournalMasterID from #JournalMasterID) 
Delete ACC_JournalMaster where JournalMasterID in (select JournalMasterID from #JournalMasterID) 

Delete ACC_HeadUser where HeadID in (SELECT HeadID from #HeadID) 
Delete ACC_Head where HeadID in (SELECT HeadID from #HeadID) 

Drop table #HeadID
Drop table #JournalMasterID
