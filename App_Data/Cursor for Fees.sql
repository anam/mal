USE [islamicfinancebd_CUCDB]
	DELETE fROM STD_Fees
	--DELETE fROM STD_FeesMaster

	Declare @FeesMasterID int
	declare @CourseID int
	declare @StudentID uniqueidentifier
	declare @TotalPaymentNeedtoPay decimal(18,0)
	declare @PaidAmount decimal(18,0)
	declare @ExtraField1 nvarchar(256)
	
	DECLARE FeesMaster_cursor CURSOR FOR 
    SELECT FeesMasterID,CourseID,StudentID,TotalPaymentNeedtoPay,ExtraField1
    FROM STD_FeesMaster 
    
    OPEN FeesMaster_cursor;
    FETCH NEXT FROM FeesMaster_cursor 
    INTO @FeesMasterID,@CourseID,@StudentID,@TotalPaymentNeedtoPay,@ExtraField1;
    

    WHILE @@FETCH_STATUS = 0
    BEGIN

        set @PaidAmount = CAST(@ExtraField1 as decimal)
		Declare @IsFinish int
		set @IsFinish=0; 
		WHILE @IsFinish = 0
			BEGIN
				declare @Amount decimal
				declare @Remarks nvarchar(256)
				declare @IsPaid bit
				set @IsPaid=0
				IF @TotalPaymentNeedtoPay > 0
				BEGIN
				if @TotalPaymentNeedtoPay >=25000
				BEGIN
					if @TotalPaymentNeedtoPay =25000
						BEGIN
							set @IsFinish =1
						END
					set @Amount = 25000
					set @TotalPaymentNeedtoPay -= @Amount
					
					if @PaidAmount <> 0
					set @IsPaid=1
					
					if @PaidAmount >= @Amount
						BEGIN
							set @PaidAmount -= @Amount
							set @Remarks = @Amount
						END
						Else 
						BEGIN
							set @Remarks = cast(@PaidAmount as nvarchar(256))
							set @PaidAmount =0							
						END					
				END
				ELSE
				BEGIN
					set @Amount = @TotalPaymentNeedtoPay
					set @TotalPaymentNeedtoPay -= @Amount
					
					if @PaidAmount <> 0
					set @IsPaid=1
					
					if @PaidAmount >= @Amount
						BEGIN
							set @PaidAmount -= @Amount
							set @Remarks = @Amount
						END
						Else 
						BEGIN
							set @Remarks = cast(@PaidAmount as nvarchar(256))
							set @PaidAmount =0							
						END		
					set @IsFinish =1
				END
				END
				else
				BEGIN
					set @IsFinish =1
				END
				INSERT INTO [STD_Fees]
					   ([FeesName]
					   ,[Amount]
					   ,[FeesTypeID]
					   ,[SubmissionDate]
					   ,[SubmitedDate]
					   ,[StudentID]
					   ,[CourseID]
					   ,[AddedBy]
					   ,[AddedDate]
					   ,[UpdatedBy]
					   ,[UpdateDate]
					   ,[RowStatusID]
					   ,[Remarks]
					   ,[IsPaid])
				 VALUES
					   (cast(@FeesMasterID as nvarchar)
					   ,@Amount
					   ,1
					   ,GETDATE()
					   ,''
					   ,@StudentID
					   ,@CourseID
					   ,'62e5b13a-f7ef-49f3-a7d6-6143acf452ac'
					   ,GETDATE()
					   ,'62e5b13a-f7ef-49f3-a7d6-6143acf452ac'
					   ,GETDATE()
					   ,1
					   ,@Remarks
					   ,@IsPaid)
					print @Remarks
			END
        FETCH NEXT FROM FeesMaster_cursor 
		INTO @FeesMasterID,@CourseID,@StudentID,@TotalPaymentNeedtoPay,@ExtraField1;
    END;
	
    CLOSE FeesMaster_cursor;
    DEALLOCATE FeesMaster_cursor;