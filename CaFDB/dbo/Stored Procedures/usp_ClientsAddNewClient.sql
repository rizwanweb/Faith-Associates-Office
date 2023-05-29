CREATE PROCEDURE usp_ClientsAddNewClient
(
	 @ClientID	int
	,@ClientName nvarchar(250)
	,@ContactPerson nvarchar(100)
	,@Phone nvarchar(50)
	,@Mobile nvarchar(50)
	,@Email nvarchar(50)
	,@NTN nvarchar(50)
	,@GST nvarchar(50)
	,@Address text
	,@City int
	,@ClientType nvarchar(50)
)

AS

	BEGIN

		INSERT INTO [dbo].[Clients]
				   ([ClientName]
				   ,[ContactPerson]
				   ,[Phone]
				   ,[Mobile]
				   ,[Email]
				   ,[NTN]
				   ,[GST]
				   ,[Address]
				   ,[City]
				   ,[ClientType])
			 VALUES
				   (
				    @ClientName 
				   ,@ContactPerson
				   ,@Phone
				   ,@Mobile
				   ,@Email
				   ,@NTN
				   ,@GST
				   ,@Address
				   ,@City
				   ,@ClientType
				   )
	END


