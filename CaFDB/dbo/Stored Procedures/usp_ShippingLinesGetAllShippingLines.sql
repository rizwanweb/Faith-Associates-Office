﻿CREATE PROCEDURE usp_ShippingLinesGetAllShippingLines
AS
	BEGIN
		SELECT [ShippingLineID]
		  ,[ShippingLineName]
		  ,[ShortName]
		  ,[Phone]
		  ,[Email]
		FROM [dbo].[ShippingLines]
	END



