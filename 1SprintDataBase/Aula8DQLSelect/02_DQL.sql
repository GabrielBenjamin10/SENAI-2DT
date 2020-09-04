USE Music

/* DQL - Data Query Language */

-- Selecionar todos os dados da tabela
SELECT * FROM Usuario;

-- Selcionar um dado espec�fico
SELECT * FROM Usuario WHERE 
	IdUsuario = 1 OR -- ||
	IdUsuario = 3;

-- Selecionar como uma BUSCA espec�ficas
-- % qualquer coisa
SELECT * FROM Usuario WHERE 
	Email LIKE '%a%' AND -- &&
	Senha LIKE '%a%';

-- Selecionar dados com algumas condi��es especiais
SELECT * FROM Permissao WHERE IdPermissao > 1 AND IdPermissao < 3;

-- Ordenar dados de forma crescente (padr�o)
SELECT * FROM Artista ORDER BY Nome;

-- Ordenar dados de forma crescente
SELECT * FROM Artista ORDER BY Nome ASC;

-- Ordenar dados de forma decrescente
SELECT * FROM Artista ORDER BY Nome DESC;

-- Selecionar dados ENTRE valores espec�ficos
--SELECT * FROM Album WHERE
	--DataLancamento BETWEEN '2019-07-05T00:00:00' AND '2020-08-05T00:00:00'