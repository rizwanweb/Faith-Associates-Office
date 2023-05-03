CREATE PROCEDURE [dbo].[usp_BillsCheckBillExist]
(
	 @JobID int
)
AS
	BEGIN

		DECLARE @IfBillExist BIT
		SET @IfBillExist = 0

		IF EXISTS (SELECT '#' FROM [dbo].[Bills] WHERE [JobID] = @JobID)
			BEGIN
				SET @IfBillExist = 1
			END
		SELECT @IfBillExist AS '@IfBillExist'
	END