create database Prodavnica;
use Prodavnica;

create table Stavka(
id int identity primary key,
artikal nvarchar(20),
kom nvarchar(2),
cena nvarchar(10),
popust nvarchar(3)
)