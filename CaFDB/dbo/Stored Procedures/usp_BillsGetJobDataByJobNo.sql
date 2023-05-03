CREATE PROCEDURE [dbo].[usp_BillsGetJobDataByJobNo]
(
	@JobID	INT
)
AS
SELECT [JobID]
      ,[JobNo]
      ,[JobDate]
      ,[Clients].[ClientName]
	  ,CONCAT([Clients].[Address], ', ', [Cities].[CityName]) AS 'Address'
      ,[LC]
      ,[LCDate]
      ,[Items].[ItemName]
      ,[Containers]
      ,[Size]
      ,[Packages]
      ,[Vessel]
      ,[BL]
      ,[BLDate]
      ,[IGM]
      ,[IGMDate]
      ,[IndexNo]

	  ,[GD]
	  ,[GDDate]
	  ,[Cash]
	  ,[CashDate]

  FROM [dbo].[Jobs]
  INNER JOIN Clients on Client = Clients.ClientID
  INNER JOIN Items on Item = Items.ItemID
  INNER JOIN Cities on CityID = Cities.CityID
  WHERE JobID = @JobID



