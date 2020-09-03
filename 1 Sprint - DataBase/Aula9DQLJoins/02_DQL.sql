USE Music;


SELECT
Usuario.Nome,
Permissao.TipoPermissao
FROM Usuario
INNER JOIN Permissao ON Usuario.IdPermissao = Permissao.IdPermissao;

/* Join que junta as tabelas Usu�rio e Permissao , mostrando ao usu�rio 
    qual permiss�o cada usu�rio possui, respectivamente
*/




