create database pro
use pro

---cret table product
CREATE TABLE ProductsDetails (
ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(255),
    Price DECIMAL(10, 2),
    DiscountedPrice AS (Price * 0.9)  -- Calculated column for 10% discount
);


-----procedure
CREATE PROCEDURE InsertProduct
    @ProductName VARCHAR(255)
    @Price DECIMAL(10, 2),
    @GeneratedProductId INT OUTPUT,
    @DiscountedPrice DECIMAL(10, 2) OUTPUT
AS
BEGIN  
   INSERT INTO ProductsDetails (ProductName, Price)

    VALUES (@ProductName, @Price);    
    SET @GeneratedProductId = SCOPE_IDENTITY();
    SET @DiscountedPrice = @Price * 0.9;  
END;


select * from ProductsDetails
