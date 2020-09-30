CREATE DATABASE IF NOT EXISTS userdb;

CREATE USER IF NOT EXISTS  'cpacheco'@'%' IDENTIFIED BY 'cp@checo';

GRANT ALL PRIVILEGES ON *.* TO 'cpacheco'@'%';

FLUSH PRIVILEGES;

use userdb;
CREATE TABLE Usuario (
Codigo INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30) NOT NULL);

insert into Usuario values (1, "Usuario 1");
insert into Usuario values (2, "Usuario 2");