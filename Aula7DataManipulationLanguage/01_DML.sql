USE Vet

 --DML - Data Manipulation Language
-- Parecido com o CRUD, temos Insert, Delete e Update
-- Mas antes para observarmos esses dados temos que usar uma DQL

SELECT * FROM Dono;
SELECT * FROM Veterinario;
SELECT * FROM Pet;
SELECT * FROM Raca;
SELECT * FROM Atendimento;
SELECT * FROM Clinica;
SELECT * FROM TipoDePet;





-- Inserir Dados nas Colunas = INSERT - INTO - VALUES
-- Inserindo Dados Iniciais

INSERT INTO Dono
(Nome) VALUES ('Gabriel'), ('Miguel');

INSERT INTO Veterinario
(Nome,CRV) VALUES ('João', '5547839'), ('Maria','67478859');

INSERT INTO Pet
(Nome) VALUES ('Logan'),('Paçoca');

INSERT INTO Raca
(Raca) VALUES ('Husky Siberiano'),('Shih-tzu');

INSERT INTO TipoDePet
(TipoPet) VALUES ('Cachorro');

INSERT INTO Atendimento
(Descricao,IdVeterinario,IdDono) VALUES ('Cirurgia' , '2','2');

INSERT INTO Clinica
(Nome, Rua,CEP,Numero) VALUES ('Estima Animal' , ' Rua 06', '0994882889' , '856');


-- Atualizar Dado = UPTADE



-- Excluir Dado = DELETE
-- Exclua de Dono , onde que IdDono for igual a 2;

DELETE FROM Dono WHERE Nome='Gustavo';

--Adicionar DADOS faltantes

UPDATE Veterinario SET
IdClinica = '1'
WHERE IdVeterinario = '2';

UPDATE Pet SET
IdDono = '2'
WHERE IdPet = '2';

UPDATE Pet SET
IdRaca = '2'
WHERE IdPet = '2';

UPDATE Pet SET
IdTipoPet = '1'
WHERE IdPet = '2';




SELECT * FROM Dono;
SELECT * FROM Veterinario;
SELECT * FROM Pet;
SELECT * FROM Raca;
SELECT * FROM Atendimento;
SELECT * FROM Clinica;
SELECT * FROM TipoDePet;

