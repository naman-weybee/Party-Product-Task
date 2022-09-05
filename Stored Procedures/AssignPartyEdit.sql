CREATE PROCEDURE SP_AssignParty_Edit
	@id int,
	@Partyid int,
	@Productid int
AS
update AssignParty
set	
	Partyid = @Partyid,
	Productid = @Productid
where
	id = @id