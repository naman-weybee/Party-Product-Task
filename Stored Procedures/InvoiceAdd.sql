CREATE PROCEDURE SP_Invoice_Insert
	@Partyid int,
	@Productid int,
	@RateOfProduct int,
	@Quantity int,
	@Total bigint
AS
insert into Invoice
(
	Partyid,
	Productid,
	RateOfProduct,
	Quantity,
	Total
)
values
(
	@Partyid,
	@Productid,
	@RateOfProduct,
	@Quantity,
	@Total
)