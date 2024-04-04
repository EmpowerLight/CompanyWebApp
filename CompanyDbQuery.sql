create database CompanyDb;

use CompanyDb;

create table Companies(
	Id int identity(1, 1),
	CompanyName varchar(500),
	Email varchar(500),
	PhoneNumber int,
	MobileNumber int
);

ALTER TABLE Companies
ADD CONSTRAINT Comapany_Id PRIMARY KEY (ID);

create table Companies_Infos(
	Cid int identity(1, 1),
	DateOfInstallation DateTime,
	DateOfRenew DateTime,
	DisplayMessage Varchar(500),
	Remarks Varchar(500),
	Attachment nvarchar(500),
	Id int FOREIGN KEY REFERENCES Companies(Id)
);

select * from Companies_Infos;

create proc sp_select
as
begin
select * from Companies
end

exec sp_select;

create proc sp_insert
@companyName varchar(500),
@email varchar(500),
@phoneNumber int,
@mobileNumber int
as
begin
	insert into Companies (CompanyName, Email, PhoneNumber, MobileNumber)
	values (@companyName, @email, @phoneNumber, @mobileNumber);
end

create proc sp_update
@companyName varchar(500),
@email varchar(500),
@phoneNumber int,
@mobileNumber int,
@id int
as
begin
	update Companies set CompanyName=@companyName, Email=@email, PhoneNumber=@phoneNumber,
	MobileNumber=@mobileNumber where Id=@id;
end

create proc sp_delete
@id int
as
begin
	delete from Companies where Id=@id;
end


create procedure sp_ci_select
as
begin
	select * from Companies_Infos;
end

exec sp_ci_select

create procedure sp_ci_insert
@dateOfInstallation datetime,
@dateOfRenew datetime,
@displayMessage varchar(500),
@remarks varchar(500),
@attachment nvarchar(500),
@id int
as
begin
	insert into Companies_Infos(DateOfInstallation,	DateOfRenew, DisplayMessage, Remarks, Attachment, Id)
	values (@dateOfInstallation, @dateOfRenew, @displayMessage, @remarks, @attachment, @id);
end

create procedure sp_ci_update
@dateOfInstallation datetime,
@dateOfRenew datetime,
@displayMessage varchar(500),
@remarks varchar(500),
@attachment nvarchar(500),
@id int,
@cid int
as
begin
	update Companies_Infos set 
	DateOfInstallation=@dateOfInstallation,
	DateOfRenew=@dateOfRenew,
	Remarks=@remarks,
	Attachment=@attachment,
	Id=@id
	where Cid=@cid;
end

create procedure sp_ci_delete @cid int
as
begin
	delete from Companies_Infos where Cid=@cid;
end