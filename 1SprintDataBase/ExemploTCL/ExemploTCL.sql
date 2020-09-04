USE Vet


/* Exemplo TCL no banco de dados desenvolvido durante as aulas ( Cliníca Veterinária) */


--Iniciamos a transaction
BEGIN TRAN ;

-- Aqui damos nosso primeiro ponto de restauração para um possível ROLLBACK no comando INSERT

INSERT INTO Dono 
(Nome) VALUES ('Gustavo');
SAVE TRANSACTION SAVEPOINT1

--Confirmamos se o dado foi mesmo inserido
SELECT * FROM  Dono

-- Deletamos o dado que fora inserido anteriormente
--Criamos nosso segundo ponto de restauração, onde Nome´Gustavo' ja não existe mais

DELETE FROM Dono WHERE Nome = 'Gustavo';
SAVE TRANSACTION SAVEPOINT2

-- Confirmamos se o dado foi mesmo deletado
SELECT * FROM  Dono

-- Comando que retornará ao primeiro ponto de restauração, uma espécie de backup, onde o dado Nome'Gustavo' ainda existe
ROLLBACK TRANSACTION SAVEPOINT1

-- Conferimos se o ROLLBACK funcionou
SELECT * FROM  Dono

-- Salvamos a transaction finalizada
COMMIT TRANSACTION









