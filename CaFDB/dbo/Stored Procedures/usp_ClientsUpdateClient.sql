CREATE PROCEDURE [dbo].[usp_ClientsUpdateClient]
(
	   @ClientID int
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
	  ,@CNIC nvarchar(50)
	  ,@Designation	nvarchar(50)
	  ,@AuthorizedPerson	nvarchar(150)

)

AS
	BEGIN

		UPDATE [dbo].[Clients]
		   SET [ClientName] = @ClientName
			  ,[ContactPerson] = @ContactPerson
			  ,[Phone] = @Phone
			  ,[Mobile] = @Mobile
			  ,[Email] = @Email
			  ,[NTN] = @NTN
			  ,[GST] = @GST
			  ,[Address] = @Address
			  ,[City] = @City
			  ,[ClientType] = @ClientType
			  ,[StandAddress] = @StandAddress
			  ,[Fax] = @Fax
			  ,[CNIC] = @CNIC
			  ,[Designation] = @Designation
			  ,[AuthorizedPerson] = @AuthorizedPerson
		 WHERE [ClientID] = @ClientID
	END


