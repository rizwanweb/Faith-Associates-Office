CREATE PROCEDURE usp_LOLODeletelolo
(
	@LoloID	INT
)
AS
DELETE FROM [dbo].[LOLOs]
      WHERE LoloID = @LoloID



