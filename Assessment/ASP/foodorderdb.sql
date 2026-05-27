create database foodorderdb;
go

use foodorderdb;
go

create table menuitems
(
    menuid int primary key identity(1,1),
    itemname varchar(100) not null,
    category varchar(50),
    foodtype varchar(20),
    price decimal(10,2),
    availablequantity int,
    isavailable bit,
    createddate datetime default getdate()
);
go

insert into menuitems
(itemname, category, foodtype, price, availablequantity, isavailable)values
('chicken fried rice', 'chinese', 'non-veg', 180, 20, 1),
('paneer pizza', 'italian', 'veg', 250, 15, 1),
('burger', 'fast food', 'veg', 120, 30, 1);
