DROP TABLE IF EXISTS Clients;
DROP TABLE IF EXISTS Products;

CREATE TABLE Clients (
    ID int IDENTITY(1,1) PRIMARY KEY, 
    FirstName varchar(64) NOT NULL, 
    SecondName varchar(64) NOT NULL,
	PhoneNumber varchar(12),
	Address varchar(256) NULL
);

INSERT INTO Clients (FirstName, SecondName, PhoneNumber, Address)
VALUES
    ('Иван', 'Иванов', '+79990001111', 'Москва'),
    ('Петр', 'Петров', '+79990001122', 'Уссурийск'),
    ('Сидор', 'Сидоров', '+79990001133', 'Владивосток'),
    ('Александр', 'Александров', '+79990001144', 'Арсеньев');

CREATE TABLE Products (
    ID int IDENTITY(1,1) PRIMARY KEY, 
    Name varchar(128) NOT NULL,
    Price float NOT NULL
);

INSERT INTO Products (Name, Price)
VALUES
    ('Ноутбук', 999.99),
    ('Планшет', 499.99),
    ('Яблоко', 0.99),
	('Морковь', 0.49);