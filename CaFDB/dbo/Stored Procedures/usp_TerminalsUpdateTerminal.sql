CREATE PROCEDURE [dbo].[usp_TerminalsUpdateTerminal]
(
	 @TerminalID INT
	,@TerminalName nvarchar(100)
	,@ShortName nvarchar(50)
	,@Phone nvarchar(50)
	,@Email nvarchar(50)
)
AS
BEGIN
UPDATE [dbo].[Terminals]
   SET [TerminalName] = @TerminalName
      ,[ShortName] = @ShortName
      ,[Phone] = @Phone
      ,[Email] = @Email
 WHERE TerminalID = @TerminalID
END