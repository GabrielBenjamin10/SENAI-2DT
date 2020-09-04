USE Music;


SELECT
Usuario.Nome,
Permissao.TipoPermissao
FROM Usuario
INNER JOIN Permissao ON Usuario.IdPermissao = Permissao.IdPermissao;

/* Join que junta as tabelas Usuário e Permissao , mostrando ao usuário 
    qual permissão cada usuário possui, respectivamente
*/




