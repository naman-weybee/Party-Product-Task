CREATE PROCEDURE SP_Invoice_Edit
	@Partyid int,
	@Productid int,
	@Quantity int,
	@Total bigint
AS
update Invoice
set
	Quantity = @Quantity,
	Total = @Total
where
	Partyid = @Partyid and
	Productid = @Productid