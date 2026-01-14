
CREATE DATABASE ProductInventory;
GO
USE ProductInventory;
GO

-- Stores Table
BEGIN
    CREATE TABLE Stores (
        StoreId INT IDENTITY(1,1) PRIMARY KEY,
        StoreName NVARCHAR(100) NOT NULL,
        Address NVARCHAR(200)
    );
END
GO

-- Products Table
BEGIN
    CREATE TABLE Products (
        ProductId INT IDENTITY(1,1) PRIMARY KEY,
        ProductName NVARCHAR(100) NOT NULL,
        Category NVARCHAR(50)
    );
END
GO

-- Stocks Table
BEGIN
    CREATE TABLE Stocks (
        StockId INT IDENTITY(1,1) PRIMARY KEY,
        StoreId INT NOT NULL,
        ProductId INT NOT NULL,
        StockLevel INT NOT NULL DEFAULT 0,
        FOREIGN KEY (StoreId) REFERENCES Stores(StoreId),
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
        CONSTRAINT UQ_Store_Product UNIQUE(StoreId, ProductId) 
    );
END
GO

-- Insert Data for Stores
BEGIN
    INSERT INTO Stores (StoreName, Address) VALUES 
    ('Tech Haven', '123 Tech Blvd, Silicon Valley'),
    ('Gadget World', '456 Innovation Dr, New York'),
    ('SuperMart', '789 Market St, San Francisco');
END
GO

-- Insert Data for Products
BEGIN
    INSERT INTO Products (ProductName, Category) VALUES 
    ('Laptop', 'Electronics'),
    ('Mouse', 'Accessories'),
    ('Keyboard', 'Accessories'),
    ('Monitor', 'Electronics'),
    ('Smartphone', 'Electronics');
END
GO

-- Insert Data for Stocks
BEGIN
    -- Store 1 Stocks
    INSERT INTO Stocks (StoreId, ProductId, StockLevel) VALUES (1, 1, 50);
    INSERT INTO Stocks (StoreId, ProductId, StockLevel) VALUES (1, 2, 100);
    INSERT INTO Stocks (StoreId, ProductId, StockLevel) VALUES (1, 3, 75);

    -- Store 2 Stocks
    INSERT INTO Stocks (StoreId, ProductId, StockLevel) VALUES (2, 1, 30);
    INSERT INTO Stocks (StoreId, ProductId, StockLevel) VALUES (2, 4, 15);
END
GO


CREATE PROCEDURE sp_GetStock
    @StoreId INT,
    @ProductId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        s.StockId,
        st.StoreName,
        p.ProductName,
        s.StockLevel
    FROM Stocks s
    INNER JOIN Stores st ON s.StoreId = st.StoreId
    INNER JOIN Products p ON s.ProductId = p.ProductId
    WHERE s.StoreId = @StoreId AND s.ProductId = @ProductId;
END
GO


CREATE PROCEDURE sp_UpdateStock
    @StoreId INT,
    @ProductId INT,
    @NewStockLevel INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Stocks
    SET StockLevel = @NewStockLevel
    WHERE StoreId = @StoreId AND ProductId = @ProductId;

    IF @@ROWCOUNT > 0
    BEGIN
         SELECT 
            s.StockId,
            st.StoreName,
            p.ProductName,
            s.StockLevel
        FROM Stocks s
        INNER JOIN Stores st ON s.StoreId = st.StoreId
        INNER JOIN Products p ON s.ProductId = p.ProductId
        WHERE s.StoreId = @StoreId AND s.ProductId = @ProductId;
    END
    ELSE
    BEGIN
        SELECT NULL; 
    END
END
GO
