CREATE PROCEDURE [dbo].[Insert_Transaction]
	@TransactionId uniqueidentifier,
    @TransactionDate date,
    @TransactionAmount money,
    @Vendor nvarchar(50) = null,
    @Product nvarchar(50) = null,
    @PaymentMode int
AS
	INSERT INTO [dbo].[TransactionTable] 
	([TransactionID]
          ,[TransactionDate]
          ,[TransactionAmount]
          ,[Vendor]
          ,[Product]
          ,[PaymentMode])
    VALUES 
    (
     	@TransactionId,
        @TransactionDate,
        @TransactionAmount,
        @Vendor,
        @Product,
        @PaymentMode   
    );
GO
