/* DQL - JOINS*/
USE Vet;
SELECT * FROM Atendimento
SELECT 
	Pet.Nome,
	Raca.Raca
FROM Raca
	 FULL OUTER JOIN Pet ON Raca.IdRaca = Pet.IdPet;

SELECT
	Veterinario.Nome,
	Dono.Nome,
	Pet.Nome,
	Raca.Raca
FROM Atendimento
	FULL OUTER JOIN Veterinario ON Atendimento.IdVeterinario = Veterinario.IdVeterinario
	FULL OUTER JOIN Dono ON Atendimento.IdDono = Dono.IdDono
	FULL OUTER JOIN Pet ON Atendimento.IdPet = Pet.IdPet
	FULL OUTER JOIN Raca ON Atendimento.IDRacaPet = Raca.IdRaca

	/* A Tabela com joins deverá conter :
		Nome(Vet) --- Nome(Dono) --- Nome(Pet) --- Raça do Pet
	/*

	
	
	
	-- ALTER TABLE Atendimento ADD IDRacaPet INT FOREIGN KEY REFERENCES Raca(IdRaca); Comando que achei necessário




