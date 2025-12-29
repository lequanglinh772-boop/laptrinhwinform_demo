create database QLSP;
go
use QLSP;
CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);
CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(200) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Quantity INT NOT NULL,
    CategoryID INT NOT NULL,
    CONSTRAINT FK_Product_Category 
        FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);
INSERT INTO Category(CategoryName)
VALUES (N'Chip CPU'), (N'Ram Ai Siêu Đắt '), (N'SSD 10TB');

INSERT INTO Product(ProductName, Price, Quantity, CategoryID)
VALUES
(N'Chip Nasa ', 900000, 10, 1),
(N'Ram 10TB ', 450000, 15, 2),
(N'SSD kèm case', 5500000, 5, 3);


