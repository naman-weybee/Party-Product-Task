CREATE PROCEDURE SP_Party_Edit
	@id int,
	@PartyName varchar(250)
AS
update Party
set PartyName = @PartyName
where id = @id;