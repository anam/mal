USE [CUCDB]
	
	declare @CourseID int
	declare @StudentID uniqueidentifier
	
	DECLARE FeesMaster_cursor CURSOR FOR 
    SELECT CourseID,StudentID
    FROM STD_FeesMaster 
    
    OPEN FeesMaster_cursor;
    FETCH NEXT FROM FeesMaster_cursor 
    INTO @CourseID,@StudentID
    

    WHILE @@FETCH_STATUS = 0
    BEGIN
		
		update STD_Student set SpouseQualification=CAST(@CourseID as nvarchar(256))
		where StudentID=@StudentID
			
        FETCH NEXT FROM FeesMaster_cursor 
		INTO @CourseID,@StudentID
    END;
	
    CLOSE FeesMaster_cursor;
    DEALLOCATE FeesMaster_cursor;
