create database Practice

use Practice

create table EmployeeDetail
(
id int primary key identity,
Firstname varchar(50) not null,
Lastname varchar(50) not null,
Age int not null
)

select * from EmployeeDetail

insert into EmployeeDetail values
('Ramesh','Kumar','24'),
('Hari','Lahane','25'),
('Tushar','Theng','26')

select * from EmployeeDetail

Alter table EmployeeDetail
add EmailId varchar(60); 

select * from EmployeeDetail

update EmployeeDetail set EmailId = RK@gmail.com where id=1

ALTER TABLE EmployeeDetail
DROP COLUMN EmailId;

select * from EmployeeDetail

Alter table EmployeeDetail
add EmailId varchar(60) null; 

update EmployeeDetail set EmailId = 'RK@gmail.com' where id=1;
update EmployeeDetail set EmailId = 'HL@gmail.com' where id=2;
update EmployeeDetail set EmailId = 'TT@gmail.com' where id=3;


alter table EmployeeDetail add 
gender char(1) null

update EmployeeDetail set gender='M' where id in(1,2,3)

select * from EmployeeDetail

Alter table EmployeeDetail
add City varchar(60); 

Alter table EmployeeDetail
add State varchar(60); 

Alter table EmployeeDetail
add Country varchar(60); 

alter table EmployeeDetail add 
constraint DF_AddressConstraint default 'India' for Country

select * from EmployeeDetail

insert into EmployeeDetail values
('Suresh','Kumar','24','SK@gmail.com','M','jaipur','rajasthan','India')

update EmployeeDetail set City = 'Mumbai' where id=1;
update EmployeeDetail set City = 'Chandigad' where id=2;
update EmployeeDetail set City = 'Belgavi' where id=3;

update EmployeeDetail set State = 'Maharashtra' where id=1;
update EmployeeDetail set State = 'Punjab' where id=2;
update EmployeeDetail set State = 'Karnataka' where id=3;

update EmployeeDetail set Country = 'India' where id=1;
update EmployeeDetail set Country = 'India' where id=2;
update EmployeeDetail set Country = 'India' where id=3;

select * from EmployeeDetail
/*sorting data*/

SELECT Age FROM EmployeeDetail ORDER BY age ASC 

SELECT Firstname,Lastname,age  FROM EmployeeDetail ORDER BY age ASC 

/*Limiting Rows*/

SELECT Firstname,Lastname FROM EmployeeDetail ORDER BY age OFFSET 1 ROWS 
FETCH NEXT 1 ROWS ONLY;

/*Distinct*/
SELECT Distinct city, state FROM EmployeeDetail ORDER BY city, state;

SELECT Firstname + ' ' + Lastname AS 'Full Name' FROM EmployeeDetail ORDER BY Firstname;

SELECT Firstname 'Full Name' FROM EmployeeDetail ORDER BY 'Full Name';

SELECT Distinct stream, state FROM EmployeeDetail ORDER BY stream, state;


/*joining Tables*/

CREATE SCHEMA hr;
GO

CREATE TABLE candidates(
    id INT PRIMARY KEY IDENTITY,
    fullname VARCHAR(100) NOT NULL
);

CREATE TABLE employees(
    id INT PRIMARY KEY IDENTITY,
    fullname VARCHAR(100) NOT NULL
);
//////////////////////////////////////////////////////////////////////
INSERT INTO 
    candidates
VALUES
    ('John Doe'),
    ('Lily Bush'),
    ('Peter Drucker'),
    ('Jane Doe');


INSERT INTO 
    employees
VALUES
    ('John Doe'),
    ('Jane Doe'),
    ('Michael Scott'),
    ('Jack Sparrow');
/*Inner Join*/

select * from candidates

select * from employees

select p.id,p.Firstname,p.Lastname,p.age,i.id,i.fullname from EmployeeDetail as p 
 JOIN candidates as i on p.id = i.id order by age

 /*Grouping Data*/
 select * from EmployeeDetail

 Alter table EmployeeDetail
 add Stream varchar (50) ;

 Alter table EmployeeDetail
 add Upload_Date date  ;

 ALTER TABLE EmployeeDetail
DROP COLUMN Upload_Date;

 update EmployeeDetail set Upload_Date = '2015-04-18' where id=1;
 update EmployeeDetail set Upload_Date = '2017-04-18' where id=2;
 update EmployeeDetail set Upload_Date = '2015-04-18' where id=3;
 update EmployeeDetail set Upload_Date = '2017-04-18' where id=4;

 update EmployeeDetail set Stream = 'cs' where id=1;
 update EmployeeDetail set Stream = 'cs' where id=2;
 update EmployeeDetail set Stream = 'Mech' where id=3;
 update EmployeeDetail set Stream = 'Mech' where id=4;

 select stream ,count(*) as 'Total no' from EmployeeDetail group by stream;
 select Upload_Date ,count(*) as 'Total no' from EmployeeDetail group by Upload_Date;




