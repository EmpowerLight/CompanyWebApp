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

create table [User](
	UserId int primary key identity(1, 1),
	Email varchar(50) unique,
	[Password] nvarchar(225), 
	ContactNumber int
);

create procedure sp_insert_user
@email varchar(50),
@password varchar(500),
@contactNumber int
as
begin
	insert into [User] (Email, [Password], ContactNumber) 
	values (@email, @password, @contactNumber);
end;

create procedure sp_select_user
@email varchar(50)
as
begin
	select * from [User] where Email = @email;
end;

select * from [User];

delete [User] where Email = 'global@global.com'

exec sp_select_user 'global@global.com';

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


select * from Companies_Infos;

--Cid int identity(1, 1),
	--DateOfInstallation DateTime,
	--DateOfRenew DateTime,
	--DisplayMessage Varchar(500),
	--Remarks Varchar(500),
	--Attachment nvarchar(500),
	--Id int FOREIGN KEY REFERENCES Companies(Id)


	--Id int identity(1, 1),
	--CompanyName varchar(500),
	--Email varchar(500),
	--PhoneNumber int,
	--MobileNumber int

create procedure sp_detail_whole
@date Date
as
begin
	select c.Id, c.CompanyName, c.Email, c.MobileNumber, c.PhoneNumber, 
	ci.Cid, ci.DateOfInstallation, ci.DateOfRenew, ci.DisplayMessage, 
	ci.DateOfRenew, ci.Remarks, ci.Attachment
	from Companies_Infos ci
	inner join Companies c
	on c.Id = ci.Id where cast(ci.DateOfInstallation as DATE) = @date;
end

exec sp_detail_whole '2024-04-18 13:12:00.000';


DROP PROCEDURE sp_detail_whole;


create procedure sp_detail_name
@name varchar(500)
as
begin
	select c.Id, c.CompanyName, c.Email, c.MobileNumber, c.PhoneNumber, 
	ci.Cid, ci.DateOfInstallation, ci.DateOfRenew, ci.DisplayMessage, 
	ci.DateOfRenew, ci.Remarks, ci.Attachment
	from Companies c
	left join Companies_Infos ci 
	on c.Id = ci.Id where c.CompanyName = @name
end









