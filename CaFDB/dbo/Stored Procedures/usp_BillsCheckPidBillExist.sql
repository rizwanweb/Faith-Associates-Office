
CREATE PROCEDURE [dbo].[usp_BillsCheckPidBillExist]
(
	 @PidID int
)
AS
	BEGIN

		DECLARE @IfBillExist BIT
		SET @IfBillExist = 0

		IF EXISTS (SELECT '#' FROM [dbo].[PidBills] WHERE [PidID] = @PidID)
			BEGIN
				SET @IfBillExist = 1
			END
		SELECT @IfBillExist AS '@IfBillExist'
	END