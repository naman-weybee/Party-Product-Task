CREATE PROCEDURE SP_Product_Edit
	@id int,
	@ProductName varchar(250)
AS
update Products
set ProductName = @ProductName
where id = @id;
