﻿CREATE PROCEDURE [dbo].[usp_JobsGetLastJobID]

AS
BEGIN
	SELECT TOP 1 JobID from Jobs ORDER BY JobID DESC
END