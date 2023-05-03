CREATE PROCEDURE [dbo].[usp_HeadersInsertNewHeader]
(
	@BillHead	nvarchar(250)
	,@HeadID	INT
)
AS
INSERT INTO [dbo].[BillHeaders]
           ([BillHead])
     VALUES
           (@BillHead)


