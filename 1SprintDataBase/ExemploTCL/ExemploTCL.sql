USE Vet


/* Exemplo TCL no banco de dados desenvolvido durante as aulas ( Clin�ca Veterin�ria) */


--Iniciamos a transaction
BEGIN TRAN ;

-- Aqui damos nosso primeiro ponto de restaura��o para um poss�vel ROLLBACK no comando INSERT

INSERT INTO Dono 
(Nome) VALUES ('Gustavo');
SAVE TRANSACTION SAVEPOINT1

--Confirmamos se o dado foi mesmo inserido
SELECT * FROM  Dono

-- Deletamos o dado que fora inserido anteriormente
--Criamos nosso segundo ponto de restaura��o, onde Nome�Gustavo' ja n�o existe mais

DELETE FROM Dono WHERE Nome = 'Gustavo';
SAVE TRANSACTION SAVEPOINT2

-- Confirmamos se o dado foi mesmo deletado
SELECT * FROM  Dono

-- Comando que retornar� ao primeiro ponto de restaura��o, uma esp�cie de backup, onde o dado Nome'Gustavo' ainda existe
ROLLBACK TRANSACTION SAVEPOINT1

-- Conferimos se o ROLLBACK funcionou
SELECT * FROM  Dono

-- Salvamos a transaction finalizada
COMMIT TRANSACTION









