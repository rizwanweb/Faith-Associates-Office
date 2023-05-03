CREATE PROCEDURE [dbo].[usp_PidBillsGetLastPidBillID]

AS
BEGIN
	SELECT TOP 1 BillID from PidBills ORDER BY BillID DESC
END
