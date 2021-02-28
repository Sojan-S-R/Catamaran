CREATE PROCEDURE [dbo].[Insert_Transaction]
	@TransactionId uniqueidentifier,
    @TransactionDate date,
    @TransactionAmount money,
    @Vendor nvarchar,
    @Product nvarchar,
    @PaymentMode nvarchar
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
