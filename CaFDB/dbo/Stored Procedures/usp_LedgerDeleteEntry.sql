﻿CREATE PROCEDURE [dbo].[usp_LedgerDeleteEntry]
(
	@REFF	INT
)
AS

DELETE FROM [dbo].[AccountLedger]
WHERE REFF = @REFF