CREATE PROCEDURE [dbo].[usp_CitiesGetCities]
AS
	BEGIN
		SELECT [CityID]
			  ,[CityName]
		  FROM [dbo].[Cities]
		ORDER BY CityName ASC
	END



