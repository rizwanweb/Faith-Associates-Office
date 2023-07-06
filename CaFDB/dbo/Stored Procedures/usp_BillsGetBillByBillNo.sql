CREATE PROCEDURE [dbo].[usp_BillsGetBillByBillNo]
(
	@BillNo	int
)
AS
SELECT [BillID]
      ,[BillNo]
      ,[BillDate]
      ,bills.[JobID]
	  ,[Jobs].[JobNo]
	  ,Clients.ClientName
  FROM [dbo].[Bills]
  INNER JOIN Jobs ON Bills.JobID = Jobs.JobID
  INNER JOIN Clients ON Jobs.Client = Clients.ClientID
  WHERE Bills.BillNo = @BillNo
