CREATE PROCEDURE usp_TerminalsAddNewTerminal
(
	 @TerminalID INT
	,@TerminalName nvarchar(100)
	,@ShortName nvarchar(50)
	,@Phone nvarchar(50)
	,@Email nvarchar(50)
)

AS
BEGIN
	INSERT INTO [dbo].[Terminals]
			   ([TerminalName]
			   ,[ShortName]
			   ,[Phone]
			   ,[Email])
		 VALUES
			   ( 
				 @TerminalName
				,@ShortName
				,@Phone
				,@Email
			   )
END


