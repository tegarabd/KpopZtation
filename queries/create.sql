create table Customer (
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	CustomerName VARCHAR(50) NOT NULL,
	CustomerEmail VARCHAR(50) NOT NULL,
	CustomerPassword VARCHAR(50) NOT NULL,
	CustomerGender VARCHAR(6) NOT NULL,
	CustomerAddress VARCHAR(100) NOT NULL,
	CustomerRole VARCHAR(5) NOT NULL
)

create table Artist (
	ArtistID INT PRIMARY KEY IDENTITY(1,1),
	ArtistName VARCHAR(50) NOT NULL,
	ArtistImage VARCHAR(50) NOT NULL
)

create table Album (
	AlbumID INT PRIMARY KEY IDENTITY(1,1),
	ArtistID INT NOT NULL REFERENCES Artist(ArtistID),
	AlbumName VARCHAR(50) NOT NULL,
	AlbumImage VARCHAR(50) NOT NULL,
	AlbumPrice INT NOT NULL,
	AlbumStock INT NOT NULL,
	AlbumDescription VARCHAR(255) NOT NULL,
)

create table TransactionHeader (
	TransactionID INT PRIMARY KEY IDENTITY(1,1),
	TransactionDate DATE NOT NULL,
	CustomerID INT NOT NULL REFERENCES Customer(CustomerID)
)

create table TransactionDetail (
	TransactionID INT NOT NULL REFERENCES TransactionHeader(TransactionID),
	AlbumID INT NOT NULL REFERENCES Album(AlbumID),
	Qty INT NOT NULL,
	PRIMARY KEY (TransactionID, AlbumID)
)

create table Cart (
	CustomerID INT NOT NULL REFERENCES Customer(CustomerID),
	AlbumID INT NOT NULL REFERENCES Album(AlbumID),
	Qty INT NOT NULL,
	PRIMARY KEY (CustomerID, AlbumID)
)