CREATE PROCEDURE SP_Party_Insert
	@PartyName varchar(250)
AS
insert into Party
(
	PartyName
)
values
(
	@PartyName
)