CREATE PROCEDURE SP_ProductRate_Edit
	@Productid int,
	@Rate int,
	@DateOfRate date
AS
update ProductRate
set 
	Rate = @Rate,
	DateOfRate = @DateOfRate
where
	Productid = @Productid