create table Party(
	id int IDENTITY(1,1) PRIMARY KEY,
	PartyName varchar(100) UNIQUE,
);

create table Products(
	id int IDENTITY(1,1) PRIMARY KEY,
	ProductName varchar(100) UNIQUE,
);

create table AssignParty(
	id int IDENTITY(1,1) PRIMARY KEY,
	Partyid int FOREIGN KEY REFERENCES Party(id),
	Productid int FOREIGN KEY  REFERENCES Products(id),
);

create table ProductRate(
	id int IDENTITY(1,1) PRIMARY KEY,
	Productid int FOREIGN KEY REFERENCES Products(id), 
	Rate int not null,
	DateOfRate date not null,
);

create table Invoice(
	id int IDENTITY(1,1) PRIMARY KEY,
	Partyid int FOREIGN KEY REFERENCES Party(id),
	Productid int FOREIGN KEY  REFERENCES Products(id),
	RateOfProduct int,
	Quantity int,
	Total bigint,
);

------------------------------------------------------------------------------------------------------------------------------------------------------------------
select * from Party;
select * from Products;
select * from AssignParty;
select * from ProductRate;
select * from Invoice;


------------------------------------------------------------------------------------------------------------------------------------------------------------------

select AssignParty.id, Party.id as Party_id , AssignParty.Partyid as A_Partyid, Party.PartyName, Products.id as Product_id , AssignParty.Productid as A_Productid, Products.ProductName
from AssignParty
inner join Party
on Party.id = AssignParty.Partyid
inner join Products
on Products.id = AssignParty.Productid;

select ProductRate.id, Products.id as Product_id, ProductRate.Productid, Products.ProductName, Rate, DateOfRate
from ProductRate
inner join Products
on Products.id = ProductRate.Productid;

insert into ProductRate(Productid, Rate, DateOfRate)
values(2, 2000, '02/02/2000');

select Partyid, Productid from
AssignParty where id = 5;

select Partyid from AssignParty where id=2;

select AssignParty.id, Party.id as Party_id , AssignParty.Partyid as A_Partyid, Party.PartyName, Products.id as Product_id , AssignParty.Productid as A_Productid, Products.ProductName
from AssignParty
inner join Party
on Party.id = AssignParty.Partyid
inner join Products
on Products.id = AssignParty.Productid;

select AssignParty.id, Party.id as Party_id , AssignParty.Partyid as A_Partyid, Party.PartyName, Products.id as Product_id , AssignParty.Productid as A_Productid, Products.ProductName
from AssignParty
inner join Party
on Party.id = AssignParty.Partyid
inner join Products
on Products.id = AssignParty.Productid
where AssignParty.Partyid = 6;

select * from ProductRate;
select * from AssignParty;
select * from Invoice;

select Rate
from ProductRate
inner join Party
on Party.id = 1 
inner join AssignParty
on AssignParty.Productid = ProductRate.Productid
where AssignParty.Productid = 2;

select Productid
from AssignParty;

select AssignParty.id, AssignParty.Partyid as A_Partyid, Products.id as Product_id , AssignParty.Productid as A_Productid, Products.ProductName
from AssignParty
inner join Products
on Products.id = AssignParty.Productid;

select Invoice.id, Invoice.Partyid, Party.PartyName, Invoice.Productid, Products.ProductName,Invoice.RateOfProduct, Invoice.Quantity, Invoice.Total
from Invoice
inner join AssignParty
on AssignParty.Partyid = Invoice.Partyid
inner join Party
on Party.id = Invoice.Partyid
inner join Products
on Products.id = Invoice.Productid
where Products.id = 8;

select * from ProductRate;

select sum(Total) from Invoice;

select AssignParty.id, Party.id as Party_id , AssignParty.Partyid as A_Partyid, Party.PartyName, Products.id as Product_id , AssignParty.Productid as A_Productid, Products.ProductName
from AssignParty
inner join Party
on Party.id = AssignParty.Partyid
inner join Products
on Products.id = AssignParty.Productid 
where AssignParty.Partyid = 1;

select * from Party;
select * from Products;
select * from AssignParty;
select * from ProductRate;
select * from Invoice;

select Quantity from Invoice where Productid=1;
truncate table ProductRate;

select top 1 id from AssignParty where Partyid=1 and Productid=4;

select Invoice.id, AssignParty.Partyid, AssignParty.Productid, Party.PartyName, Products.ProductName, RateOfProduct, Quantity, Total
from Invoice
inner join Party
on Party.id = Invoice.Partyid
inner join Products
on Products.id = Invoice.Productid
inner join AssignParty
on AssignParty.Productid = Invoice.Productid
where Products.id = 1;

select Invoice.id, Invoice.Partyid, Party.PartyName, Invoice.Productid, Products.ProductName, Invoice.RateOfProduct, Invoice.Quantity, Invoice.Total
from Invoice 
inner join Party
on Party.id = Invoice.Partyid
inner join Products 
on Products.id = Invoice.Productid;

select AssignParty.id, Party.id as Party_id , AssignParty.Partyid as A_Partyid, Party.PartyName, Products.id as Product_id , AssignParty.Productid as A_Productid, Products.ProductName
from AssignParty
inner join Party
on Party.id = AssignParty.Partyid
inner join Products
on Products.id = AssignParty.Productid
where AssignParty.Partyid = 1 and AssignParty.Productid = 4;

select Invoice.id, Invoice.Partyid, Party.PartyName, Invoice.Productid, Products.ProductName,Invoice.RateOfProduct, Invoice.Quantity, Invoice.Total
from Invoice
inner join AssignParty
on AssignParty.Partyid = Invoice.Partyid and AssignParty.Productid = Invoice.Productid
inner join Party
on Party.id = Invoice.Partyid
inner join Products
on Products.id = Invoice.Productid
where Products.id = 2;

select AssignParty.id, Party.id , AssignParty.Partyid, Party.PartyName, Products.id, AssignParty.Productid, Products.ProductName
from AssignParty 
inner join Party 
on Party.id = AssignParty.Partyid 
inner join Products
on Products.id = AssignParty.Productid
where AssignParty.Partyid = 1;

select AssignParty.id, Party.id , AssignParty.Partyid, Party.PartyName, Products.id, AssignParty.Productid, Products.ProductName
from AssignParty 
inner join Party
on Party.id = AssignParty.Partyid
inner join Products
on Products.id = AssignParty.Productid
where AssignParty.Partyid = 1;

select AssignParty.id, Party.id , AssignParty.Partyid, Party.PartyName, Products.id, AssignParty.Productid, Products.ProductName
from AssignParty
inner join Party 
on Party.id = AssignParty.Partyid
inner join Products
on Products.id = AssignParty.Productid
where AssignParty.Partyid = 1;

select * from ProductRate inner join Party on Party.id =1 and Productid =7;

select ProductRate.id, Products.id , ProductRate.Productid, Products.ProductName, Rate, DateOfRate from ProductRate inner join Products on Products.id = ProductRate.Productid;

select  Partyid, Productid, RateOfProduct
from Invoice;