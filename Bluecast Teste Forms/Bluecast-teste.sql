CREATE SCHEMA `db_bluecast` ;

use db_bluecast;

CREATE TABLE `db_bluecast`.`clientes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `sobrenome` VARCHAR(45) NOT NULL,
  `valor` DECIMAL(9,2) NOT NULL,
  `desde` DATE,
  `inadimplentes` TINYINT(1) NOT NULL,
  PRIMARY KEY (`id`));
  
  # desde pode ter ou não valor default (quando não inserido) > `desde` DATE NOT NULL DEFAULT '2022-01-01',
  # o mesmo vale para o  valor.
  # ALTER TABLE clientes AUTO_INCREMENT = 1
  
INSERT INTO `db_bluecast`.`clientes` (`nome`, `sobrenome`, `valor`, `desde`, `inadimplentes`) 
VALUES ('Daniel', 'Souza', '12345.99', '2022-06-02', '1');

UPDATE `db_bluecast`.`clientes` SET `sobrenome` = 'Souza Silva' WHERE (`id` = '3');

INSERT INTO `db_bluecast`.`clientes` (`nome`, `sobrenome`, `valor`, `desde`, `inadimplentes`) 
VALUES ('Carlos', 'Souza', '100.50', '2022-01-03', '1');

INSERT INTO `db_bluecast`.`clientes` (`nome`, `sobrenome`, `valor`, `desde`, `inadimplentes`) 
VALUES ('Richard', 'Henrique', '0.00', '2022-04-22', '1');

INSERT INTO `db_bluecast`.`clientes` (`nome`, `sobrenome`, `valor`, `inadimplentes`) 
VALUES ('Luiz', 'Paulo da Silva', '0.00', '0');

INSERT INTO `db_bluecast`.`clientes` (`nome`, `sobrenome`, `valor`, `desde`, `inadimplentes`) 
VALUES ('Moura', 'Carlos Perreira Santos', '12345.99', '2022-06-02', '1');

#Select Completo (Bruto)
SELECT * FROM db_bluecast.clientes;

#Pesquisa por Nome
#Use % antes, meio ou depois para achar qualqur dado na sequencia desejada.
SELECT * FROM clientes WHERE (nome LIKE 'Car%');

#Pesquisa por Valor (Simples Ações)
# >= maior igual valor
# = igual valor
# <= menor igual valor
SELECT * FROM clientes WHERE (valor >= 1000);

#Pesquisa por Data
SELECT * FROM clientes WHERE (desde >= '2020-01-01');

#Pesquisa por texto em qualquer campos.
SELECT * FROM clientes WHERE 'Carlos' IN (nome, sobrenome, valor, desde, inadimplentes) LIMIT 10;
