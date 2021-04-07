create table Cars
(
CarId int primary key identity(1,1),
BrandId int,
ColorId int,
ModelYear int,
DailyPrice int,
Description varchar(200),

);

create table Brands
(
BrandId int primary key identity(1,1),
BrandName varchar(20),
);

create table Colors
(
ColorId int primary key identity(1,1),
ColorName varchar(20),
);

insert into Cars(1,1,1,1997,50000,'97 Opel Vectra 2.5 Motor');

insert into Cars(2,2,2,2015,130000,'2015 Hyundai i20');

insert into Cars(3,2,1,2018,150000,'Hyundai Getz 1.6');

insert into Cars(4,3,2,2020,170000,'Toyota Yariss');

insert into Cars(5,4,2,2021,350000,'KIA Sportage');


insert into Colors(1,'Blue');

insert into Colors(2,'Red')

select * from Cars
select * from Brands
select * from Colors

