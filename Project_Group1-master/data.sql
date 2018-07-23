drop database if exists shopping;
create database shopping;
use shopping;
create table Users
(
	UserId int auto_increment primary key,
    Username varchar(50) not null,
    Password varchar(50) not null,
    Phone int not null,
    Address varchar(50)
);
create table Items
(
	ItemID int auto_increment primary key,
    ItemName varchar(50),
    Price decimal(20,2) default 0,
    Amount int 
);
create table Orders
(
	CodeOrders INT auto_increment primary key,
    ItemID INT,
    ItemName varchar(50),
    Price decimal(20,2) not null,
    Amount INT,
    UserId int,
    Constraint fk_Orders_Customer foreign key(UserId) references users(UserId)  
);
create table Bill
(
	CodeOrders int not null,
    ItemID int not null,
    ItemName varchar(50),
    Price decimal(20,2)not null,
    quantity int not null default 1,
    Constraint pk_Bill primary key (CodeOrders, ItemID),
    CONSTRAINT fk_Bill_order FOREIGN key(CodeOrders) references Orders(CodeOrders),
    CONSTRAINT fk_Bill_Item FOREIGN KEY(ItemID) REFERENCES Items(ItemID)
);
Select * From Users  where Username = 'hoan' and password = '12345';

delimiter $$
create trigger tg_before_insert before insert
	on Items for each row
    begin
		if new.amount < 0 then
            signal sqlstate '45001' set message_text = 'Số lượng lớn hơn 0';
        end if;
    end $$
delimiter ;

delimiter $$
create trigger tg_CheckAmount
	before update on Items
	for each row
	begin
		if new.amount < 0 then
            signal sqlstate '45001' set message_text = 'Số lượng lớn hơn 0';
        end if;
    end $$
delimiter ;
insert into Users(Username, Password, Phone, Address) values
('hoan', '12345', 01659023808, 'Ha Noi');

insert into Items(ItemName, Price , Amount) values
('Poca', 6000.0, 10 ),
('Coca', 15000.0, 10),
('Pepsi', 15000.0, 10),
('7Up', 15000.0, 10),
('Fanta', 15000.0, 10),
('Swing', 6000.0, 10),
('Ostar', 6000.0, 10);
 

