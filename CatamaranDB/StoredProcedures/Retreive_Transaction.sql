CREATE PROCEDURE [dbo].[Retreive_Transaction]
	@TransactionId uniqueidentifier = null,
    @TransactionMonth int = null,
    @TransactionYear int = null
AS

IF @TransactionId IS NOT NULL
	    SELECT [TransactionID]
          ,[TransactionDate]
          ,[TransactionAmount]
          ,[Vendor]
          ,[Product]
          ,[PaymentMode]
          
        FROM TransactionTable
        WHERE [TransactionID] = @TransactionId

ELSE IF @TransactionMonth IS NOT NULL
	    SELECT [TransactionID]
          ,[TransactionDate]
          ,[TransactionAmount]
          ,[Vendor]
          ,[Product]
          ,[PaymentMode]

        FROM TransactionTable
        WHERE MONTH([TransactionDate]) = @TransactionMonth

ELSE IF @TransactionYear IS NOT NULL
	    SELECT [TransactionID]
          ,[TransactionDate]
          ,[TransactionAmount]
          ,[Vendor]
          ,[Product]
          ,[PaymentMode]

        FROM TransactionTable
        WHERE YEAR([TransactionDate]) = @TransactionYear
GO
