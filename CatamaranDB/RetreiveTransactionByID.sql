CREATE PROCEDURE [dbo].[RetreiveTransactionByID]
	@TransactionId uniqueidentifier
AS
	SELECT [TransactionID]
      ,[TransactionDate]
      ,[TransactionAmount]
      ,[Vendor]
      ,[Product]
      ,[PaymentMode]

    FROM TransactionTable
    WHERE [TransactionID] = @TransactionId
GO
