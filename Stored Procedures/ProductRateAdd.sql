CREATE PROCEDURE SP_ProductRate_Insert
	@Productid int,
	@Rate int,
	@DateOfRate date
AS
insert into ProductRate
(
	Productid,
	Rate,
	DateOfRate
)
values
(
	@Productid,
	@Rate,
	@DateOfRate
)