create database Product


CREATE TABLE ProductsDetails (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,  
    ProductName VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    DiscountedPrice AS (Price - (Price * 0.1)) 
);
 
CREATE PROCEDURE InsertProduct
    @ProductName VARCHAR(100),
    @Price DECIMAL(10, 2),
    @GeneratedProductId INT OUTPUT,
    @DiscountedPrice DECIMAL(10, 2) OUTPUT
AS
BEGIN
    DECLARE @InsertedProducts TABLE (ProductId INT);
    -- Insert the record and capture the ProductId using OUTPUT
    INSERT INTO ProductsDetails (ProductName, Price)
    OUTPUT INSERTED.ProductId INTO @InsertedProducts
    VALUES (@ProductName, @Price);
    -- Retrieve the captured ProductId
    SELECT @GeneratedProductId = ProductId FROM @InsertedProducts;
    -- Calculate the DiscountedPrice
    SET @DiscountedPrice = @Price - (@Price * 0.1);
END;
 
 
DECLARE @GeneratedProductId INT, @DiscountedPrice DECIMAL(10, 2);
-- Call the procedure
EXEC InsertProduct
    @ProductName = 'Laptop',
    @Price = 50000,
    @GeneratedProductId = @GeneratedProductId OUTPUT,
    @DiscountedPrice = @DiscountedPrice OUTPUT;
-- Check the output values
SELECT @GeneratedProductId AS ProductId, @DiscountedPrice AS DiscountedPrice;


SELECT * FROM ProductsDetails;
 