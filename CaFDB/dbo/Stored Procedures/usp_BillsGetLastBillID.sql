﻿CREATE PROCEDURE usp_BillsGetLastBillID

AS
BEGIN
	SELECT TOP 1 BillID from Bills ORDER BY BillID DESC
END