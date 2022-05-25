create database moedaBD;

use moedaBD;

CREATE TABLE moeda(
id int primary key auto_increment,
nome varchar(50),
quantidade int
);

select *from moeda