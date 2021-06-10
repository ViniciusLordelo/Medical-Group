USE SP_Medical_Group;
GO

INSERT INTO TiposUsuarios (Titulo)
VALUES ('Administrador'),
	   ('Paciente'),
	   ('Médico');
GO

INSERT INTO Usuarios (IdTipoUsuario, Email, Senha)
VALUES (1, 'adm@adm.com', 'adm123'),
	   (2, 'giih@gmail.com', 'giih123'),
	   (2, 'rodrigo@gmail.com', 'rodrigo123'),
	   (2, 'fernando@gmail.com', 'fernando123'),
GO

INSERT INTO Pacientes (IdUsuario, Nome, DataNascimento, Telefone, RG, CPF, CEP, Endereco)
VALUES (2, 'giih', '13/10/1983', '1134567654', '435225435', '94839859000', '04022000', 'R. Av. Itaberaba, 240 - Freguesia, São Paulo - SP'),
	   (3, 'rodrigo', '23/07/2001', '11987656543', '326543457', '73556944057', '01310200', 'Av. Petronio portela, 1578 - Freguesia, São Paulo - SP'),
	   (4, 'Fernando', '10/10/1978', '11972084453', '546365253', '16839338002', '04029200', 'Av. Paula ferreira , 2927 - Pirituba, São Paulo - SP'),
	  
GO

INSERT INTO Clinicas (Nome, CNPJ, RazaoSocial, HorarioAbertura, HorarioFechamento, Endereco)
VALUES ('Clínica Possarle', '86400902000130', 'SP Medical Group', '05:00', '00:00', 'Av. Barão Limeira, 532, São Paulo, SP');
GO

INSERT INTO Especialidades (Titulo)
VALUES 
	   ('Cirurgia Pediátrica'),
	   ('Pediatria'),
	   ('Psiquiatria');
GO

INSERT INTO Medicos (IdUsuario, IdClinica, IdEspecialidade, Nome, CRM, Estado)
VALUES (2, 'Ricardo Lemos', '54356', 'SP'),
	   (3, 'Roberto Possarle', '53452', 'SP'),
	   (4, 'Maria rodrigues', '65463', 'SP');
GO

INSERT INTO Situacoes (Titulo)
VALUES ('Agendada'),
	   ('Realizada'),
	   ('Cancelada');
GO

INSERT INTO Consultas (IdPaciente, IdMedico, IdSituacao, DataAgendamento)
VALUES (2, '20/01/2020  15:00'),
	   (3, '06/01/2020  10:00'),
	   (4, '07/02/2020  11:00'),
	   
GO