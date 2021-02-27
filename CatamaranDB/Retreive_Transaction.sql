CREATE PROCEDURE [dbo].[Retreive_Transaction]
	@TransactionId uniqueidentifier,
    @TransactionMonth int,
    @TransactionYear int
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
