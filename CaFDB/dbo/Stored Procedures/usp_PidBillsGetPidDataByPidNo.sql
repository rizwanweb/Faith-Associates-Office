CREATE PROCEDURE [dbo].[usp_PidBillsGetPidDataByPidNo]
(
	@PidID	INT
)
AS
SELECT [PidID]
      ,[PidNo]
      ,[PidDate]
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

  FROM [dbo].[Pids]
  INNER JOIN Clients on Client = Clients.ClientID
  INNER JOIN Items on Item = Items.ItemID
  INNER JOIN Cities on CityID = Cities.CityID
  WHERE PidID = @PidID



