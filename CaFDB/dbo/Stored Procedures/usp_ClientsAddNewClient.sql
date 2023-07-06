CREATE PROCEDURE [dbo].[usp_ClientsAddNewClient]
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
	,@StandAddress nvarchar(500)
	,@Fax	nvarchar(50)
	,@CNIC	nvarchar(50)
	,@Designation	nvarchar(50)
	,@AuthorizedPerson	nvarchar(150)
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
				   ,[ClientType]
				   ,[StandAddress]
				   ,[Fax]
				   ,[CNIC]
				   ,[Designation]
				   ,[AuthorizedPerson]
				   
				   )
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
				   ,@StandAddress
				   ,@Fax
				   ,@CNIC
				   ,@Designation
				   ,@AuthorizedPerson
				   )
	END


