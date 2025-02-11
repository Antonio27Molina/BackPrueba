create database PruebaDB

use PruebaDB
create table Customers(
idCustomer int identity primary key,
[Name] varchar(100) not null,
LastName varchar(100),
[UserName] varchar(100) not null,
Email varchar(100) not null,
[Password] varchar(100) not null,
[Address] varchar(300)
)

Create table Store(
idStore int primary key identity,
[Name] varchar(100) not null,
[Address] varchar(300),
[Status] bit not null
)

create table Item(
idItem int primary key identity,
Code varchar(100) not null,
[Description] varchar(100) not null,
Price decimal not null,
[Image] varchar(500) null,
[Status] bit not null)


create table ItemsStore(
idItem int not  null foreign key references Item(idItem),
idStore int not  null foreign key references Store(idStore),
stock int not null 
)
create table Cart(
idCart int primary key identity,
idItem int not  null foreign key references Item(idItem),
idCustomer int not  null foreign key references Customers(idCustomer),
quantity int not null,
createDate date not null,
[Status] bit not null
)
INSERT INTO Item (Code, [Description], Price, [Image], [Status])
VALUES
('ITEM001', 'Laptop HP Pavilion', 799.99, 'https://source.unsplash.com/400x300/?laptop', 1),
('ITEM002', 'Smartphone Samsung Galaxy S21', 999.99, 'https://source.unsplash.com/400x300/?smartphone', 1),
('ITEM003', 'Monitor LG 24"', 189.50, 'https://source.unsplash.com/400x300/?monitor', 1),
('ITEM004', 'Teclado Mecánico RGB', 75.00, 'https://source.unsplash.com/400x300/?keyboard', 1),
('ITEM005', 'Mouse Inalámbrico Logitech', 45.99, 'https://source.unsplash.com/400x300/?mouse', 1),
('ITEM006', 'Silla Gamer', 259.99, 'https://source.unsplash.com/400x300/?chair', 1),
('ITEM007', 'Disco Duro Externo 1TB', 89.99, 'https://source.unsplash.com/400x300/?harddisk', 1),
('ITEM008', 'Memoria USB 128GB', 29.99, 'https://source.unsplash.com/400x300/?usb', 1),
('ITEM009', 'Impresora Multifunción HP', 199.99, 'https://source.unsplash.com/400x300/?printer', 1),
('ITEM010', 'Auriculares Bluetooth Sony', 120.50, 'https://source.unsplash.com/400x300/?headphones', 1),
('ITEM011', 'Tablet Samsung Galaxy Tab', 349.99, 'https://source.unsplash.com/400x300/?tablet', 1),
('ITEM012', 'Cámara Canon EOS 90D', 1099.99, 'https://source.unsplash.com/400x300/?camera', 1),
('ITEM013', 'Smartwatch Apple Watch 7', 499.99, 'https://source.unsplash.com/400x300/?smartwatch', 1),
('ITEM014', 'Consola PlayStation 5', 599.99, 'https://source.unsplash.com/400x300/?console', 1),
('ITEM015', 'Tarjeta Gráfica RTX 3080', 1299.99, 'https://source.unsplash.com/400x300/?gpu', 1),
('ITEM016', 'Router WiFi 6 TP-Link', 99.99, 'https://source.unsplash.com/400x300/?router', 1),
('ITEM017', 'Microondas Samsung 23L', 139.99, 'https://source.unsplash.com/400x300/?microwave', 1),
('ITEM018', 'Refrigerador LG 400L', 699.99, 'https://source.unsplash.com/400x300/?fridge', 1),
('ITEM019', 'Lavadora Whirlpool 18kg', 549.99, 'https://source.unsplash.com/400x300/?washingmachine', 1),
('ITEM020', 'Bocinas Bluetooth JBL', 89.99, 'https://source.unsplash.com/400x300/?speakers', 1),
-- 80 registros adicionales
('ITEM021', 'Smart TV Samsung 55"', 599.99, 'https://source.unsplash.com/400x300/?tv', 1),
('ITEM022', 'Cafetera Nespresso', 149.99, 'https://source.unsplash.com/400x300/?coffee', 1),
('ITEM023', 'iPad Pro 12.9"', 1099.99, 'https://source.unsplash.com/400x300/?ipad', 1),
('ITEM024', 'Cargador Inalámbrico Anker', 29.99, 'https://source.unsplash.com/400x300/?charger', 1),
('ITEM025', 'Parlantes Bose SoundLink', 199.99, 'https://source.unsplash.com/400x300/?bose', 1),
('ITEM026', 'Batería Externa 20000mAh', 49.99, 'https://source.unsplash.com/400x300/?powerbank', 1),
('ITEM027', 'Drone DJI Mini 2', 499.99, 'https://source.unsplash.com/400x300/?drone', 1),
('ITEM028', 'Videoproyector Epson', 329.99, 'https://source.unsplash.com/400x300/?projector', 1),
('ITEM029', 'Estufa Eléctrica', 239.99, 'https://source.unsplash.com/400x300/?stove', 1),
('ITEM030', 'Smart Lock August', 189.99, 'https://source.unsplash.com/400x300/?lock', 1)


INSERT INTO Store ([Name], [Address], [Status])
VALUES
('Tech Store', '123 Tech St, New York, NY', 1),
('Gadget Hub', '456 Gadget Ave, San Francisco, CA', 1),
('Smart Electronics', '789 Smart Rd, Los Angeles, CA', 1),
('Home Appliances', '101 Appliance Blvd, Chicago, IL', 1),
('Digital World', '202 Digital Dr, Austin, TX', 1);

DECLARE @ItemCount INT = 30;  
DECLARE @StoreCount INT = 5; 
DECLARE @MaxStock INT = 100;  

DECLARE @i INT = 1;
DECLARE @storeId INT;
DECLARE @itemId INT;
DECLARE @stock INT;

WHILE @i <= @ItemCount
BEGIN
    SET @storeId = (SELECT TOP 1 idStore FROM Store ORDER BY NEWID());

    SET @itemId = @i;
    SET @stock = (SELECT FLOOR(RAND() * @MaxStock) + 1);

    INSERT INTO ItemsStore (idItem, idStore, stock)
    VALUES (@itemId, @storeId, @stock);

    SET @i = @i + 1;
END










go
DECLARE @ItemCount INT = 30;
DECLARE @StoreCount INT = 5;
DECLARE @MaxStock INT = 100; 

DECLARE @i INT = 1;
DECLARE @storeId INT;
DECLARE @itemId INT;
DECLARE @stock INT;

WHILE @i <= @ItemCount
BEGIN
    SET @storeId = (SELECT TOP 1 idStore FROM Store ORDER BY NEWID());

    SET @itemId = @i;  

    SET @stock = (SELECT FLOOR(RAND() * @MaxStock) + 1);

    INSERT INTO ItemsStore (idItem, idStore, stock)
    VALUES (@itemId, @storeId, @stock);

    SET @i = @i + 1;
END

go

create procedure GetProducts(
@id int
)
as
begin
select top 5 c.* from ItemsStore a join ItemsStore b on a.idStore=b.idStore
join Item c on b.idItem=c.idItem where a.idStore=@id
group by c.idItem, c.Code, c.Description, c.Price, c.Image, c.Status
end
go
create procedure GetProductsAll(
@id int
)
as
begin
select c.* from ItemsStore a join ItemsStore b on a.idStore=b.idStore
join Item c on b.idItem=c.idItem where a.idStore=@id
group by c.idItem, c.Code, c.Description, c.Price, c.Image, c.Status
end
