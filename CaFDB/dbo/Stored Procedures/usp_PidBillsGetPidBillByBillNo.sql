CREATE PROCEDURE [dbo].[usp_PidBillsGetPidBillByBillNo]
(
	@BillNo	int
)
AS
SELECT [BillID]
      ,[BillNo]
      ,[BillDate]
      ,Pidbills.[PidID]
	  ,[Pids].[PidNo]
	  ,Clients.ClientName
  FROM [dbo].[PidBills]
  INNER JOIN Pids ON PidBills.PidID = Pids.PidID
  INNER JOIN Clients ON Pids.Client = Clients.ClientID
  WHERE PidBills.BillNo = @BillNo
