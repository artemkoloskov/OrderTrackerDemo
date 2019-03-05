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
    ('����', '������', '+79990001111', '������'),
    ('����', '������', '+79990001122', '���������'),
    ('�����', '�������', '+79990001133', '�����������'),
    ('���������', '�����������', '+79990001144', '��������');

CREATE TABLE Products (
    ID int IDENTITY(1,1) PRIMARY KEY, 
    Name varchar(128) NOT NULL,
    Price float NOT NULL
);

INSERT INTO Products (Name, Price)
VALUES
    ('�������', 999.99),
    ('�������', 499.99),
    ('������', 0.99),
	('�������', 0.49);