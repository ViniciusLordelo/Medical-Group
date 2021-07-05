USE SPMG;
GO

SELECT * FROM TiposUsuarios;
SELECT * FROM Usuarios;
SELECT * FROM Pacientes;
SELECT * FROM Clinicas;
SELECT * FROM Especialidades;
SELECT * FROM Medicos;
SELECT * FROM Situacoes;
SELECT * FROM Consultas;


SELECT COUNT(IdUsuario) FROM Usuarios;


SELECT IdUsuario, TU.Titulo AS Tipo, Email FROM Usuarios U
INNER JOIN TiposUsuarios TU
ON U.IdTipoUsuario = TU.IdTipoUsuario;


SELECT 
	IdPaciente,
	
	Nome, 

	U.Email,

	DATEDIFF(year, DataNascimento, GETDATE()) AS [Idade],

	FORMAT(DataNascimento, 'd', 'pt-br') AS [Data de Nascimento],

	Telefone,

	RG,

	CPF,

	CEP,

	Endereco

FROM Pacientes P

INNER JOIN Usuarios U

ON P.IdUsuario = U.IdUsuario;


SELECT 
	IdClinica,

	Nome,

	CNPJ,

	RazaoSocial,

	CONVERT(VARCHAR(10), HorarioAbertura, 108) AS [Horário de Abertura],

	CONVERT(VARCHAR(10), HorarioFechamento, 108) AS [Horário de Fechamento],

	Endereco

FROM Clinicas;


SELECT 
	IdMedico,

	M.Nome,

	U.Email,

	CRM,

	Estado,

	E.Titulo AS Especialidade,

	C.Nome AS [Clínica]

FROM Medicos M
INNER JOIN Usuarios U
ON M.IdUsuario = U.IdUsuario
INNER JOIN Clinicas C
ON M.IdClinica = C.IdClinica
INNER JOIN Especialidades E
ON M.IdEspecialidade = E.IdEspecialidade;


SELECT
	IdConsulta,

	P.Nome AS Paciente,

	M.Nome AS [Médico],

	S.Titulo AS [Situação],

	FORMAT(DataAgendamento, 'd', 'pt-br') AS [Data de Agendamento],

	FORMAT(DataAgendamento, 'hh:mm') AS [Horário],

	Descricao

FROM Consultas C
INNER JOIN Pacientes P
ON C.IdPaciente = P.IdPaciente
INNER JOIN Medicos M
ON C.IdMedico = M.IdMedico
INNER JOIN Situacoes S
ON C.IdSituacao = S.IdSituacao;

-- Quantidade de médicos em determinada especialidade
SELECT dbo.QuantidadeDeMedicos('Anestesiologia') AS [Quantidade de Médicos];

-- Nome e idade de um paciente de acordo com email
EXEC BuscaIdade 'henrique@gmail.com'


