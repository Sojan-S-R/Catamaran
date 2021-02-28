INSERT INTO [dbo].[TransactionTable] 
	([TransactionID]
          ,[TransactionDate]
          ,[TransactionAmount]
          ,[Vendor]
          ,[Product]
          ,[PaymentMode])
    VALUES 
    (
     	NEWID(),
        GETDATE(),
        5000,
        'Flipkart',
        'Laptop Stand',
        'Google Pay'   
    ),
    (
     	NEWID(),
        GETDATE(),
        5000,
        'Amazon',
        'Book',
        'Phone Pay'   
    ),    
    (
     	NEWID(),
        GETDATE(),
        5000,
        'Tata Cliq',
        'TShirt',
        'Net Banking'   
    );


    Select * from [dbo].[TransactionTable] 
