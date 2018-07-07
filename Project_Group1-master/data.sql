drop database if exists shopping;
create database shopping;
use shopping;
create table Users
(
	UserId int primary key,
    Username varchar(50) not null,
    Password varchar(50) not null,
    Phone int not null
);
create table Items
(
	ItemID int primary key,
    ItemName varchar(50),
    Price varchar(50),
    Amount int 
);
create table Orders
(
	CodeOrders INT primary key,
    orderDate datetime default now(),
    ItemName varchar(50),
    Price varchar(50),
    UserId int,
    Constraint fk_Orders_Customer foreign key(UserId) references users(UserId)  
);
create table Bill
(
	CodeOrders int not null,
    ItemID int not null,
    ItemName varchar(50),
    Price varchar(50),
    quantity int not null default 1,
    TotalMoney varchar(50),
    constraint pk_Bill primary key (CodeOrders, ItemID),
    CONSTRAINT fk_Bill_order FOREIGN key(CodeOrders) references Orders(CodeOrders),
    CONSTRAINT fk_Bill_Item FOREIGN KEY(ItemID) REFERENCES Items(ItemID)
);


