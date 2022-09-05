CREATE PROCEDURE SP_AssignParty_Insert
	@Partyid int,
	@Productid int
AS
insert into AssignParty
(
	Partyid,
	Productid
)
values
(
	@Partyid,
	@Productid
)