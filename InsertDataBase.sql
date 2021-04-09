create table Cars(
CarId int primary key not null,
CarName varchar(255) not null,
CarBrandId int  not null,
CarColorId int not null,
CarModelYear int not null,
CarDailyPrice decimal not null,
CarDescription varchar(255) not null,

)

create table Brands(
BrandId int primary key not null,
BrandName varchar(255) not null,
)

create table Colors(
ColorId int primary key not null,
ColorName varchar(255) not null,
)




