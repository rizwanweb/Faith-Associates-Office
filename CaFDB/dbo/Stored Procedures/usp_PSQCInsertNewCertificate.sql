CREATE PROCEDURE [dbo].[usp_PSQCInsertNewCertificate]
(
		 @PSQCID int
		,@JobID int
        ,@Invoice nvarchar(50)
        ,@InvoiceDate date
        ,@Origin nvarchar(50)
        ,@Brand nvarchar(50)
        ,@AuthorizedPerson int
)
AS
INSERT INTO [dbo].[PSQCACertificate]
           ([JobID]
           ,[Invoice]
           ,[InvoiceDate]
           ,[Origin]
           ,[Brand]
           ,[AuthorizedPerson])
     VALUES
           (
		    @JobID
           ,@Invoice
           ,@InvoiceDate
           ,@Origin
           ,@Brand
           ,@AuthorizedPerson
		   )