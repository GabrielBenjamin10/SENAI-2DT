USE Vet;
GO
-- DQL - Data Query Language */
-- Para consultar dados

-- Selecionar todos os dados da tabela
SELECT * FROM Pet;

-- Selcionar um dado passando id espec�fico para consultar
SELECT * FROM Dono WHERE 
	IdDono = 3;

-- Selecionar como uma BUSCA espec�ficas
-- % qualquer coisa
SELECT * FROM Pet WHERE 
	Nome LIKE 'Pa�oca' -- &&;

-- Selecionar dados com algumas condi��es especiais
SELECT * FROM Pet WHERE IdPet > 1 AND IdPet < 3;

-- Ordenar dados de forma crescente (padr�o)
SELECT * FROM Dono ORDER BY Nome;

-- Ordenar dados de forma crescente
SELECT * FROM Veterinario ORDER BY Nome ASC;

-- Ordenar dados de forma decrescente
SELECT * FROM Veterinario ORDER BY Nome DESC;

-- Selecionar dados ENTRE valores espec�ficos
--SELECT * FROM Atendimento WHERE
	--Data BETWEEN '2020-07-05T00:00:00' AND '2020-08-05T00:00:00';