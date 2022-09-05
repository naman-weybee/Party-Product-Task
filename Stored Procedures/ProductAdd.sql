CREATE PROCEDURE SP_Product_Insert
	@ProductName varchar(250)
AS
insert into Products
(
	ProductName
)
values
(
	@ProductName
)