DROP TABLE IF EXISTS Etapa
;
DROP TABLE IF EXISTS CategoriaQuestao
;
DROP TABLE IF EXISTS GrupoQuestao
;
DROP TABLE IF EXISTS RespostaQuestao
;
DROP TABLE IF EXISTS AvaliacaoQuestionario
;
DROP TABLE IF EXISTS OpcaoQuestao
;
DROP TABLE IF EXISTS TipoQuestao
;
DROP TABLE IF EXISTS Questao
;
DROP TABLE IF EXISTS Questionario
;
DROP TABLE IF EXISTS Avaliacao
;
DROP TABLE IF EXISTS AreaConcentracao
;
DROP TABLE IF EXISTS CandidatoProcessoSeletivo
;
DROP TABLE IF EXISTS ProcessoSeletivo
;
DROP TABLE IF EXISTS Candidato
;
DROP TABLE IF EXISTS PerfilMenu
;
DROP TABLE IF EXISTS Menu
;
DROP TABLE IF EXISTS Perfil
;
DROP TABLE IF EXISTS Usuario
;

CREATE TABLE Etapa
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Nome VARCHAR(9),
	PRIMARY KEY (Id)
) 
;


CREATE TABLE CategoriaQuestao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Nome VARCHAR(50),
	IdGrupoQuestao INTEGER,
	PRIMARY KEY (Id),
	KEY (IdGrupoQuestao)
) 
;


CREATE TABLE GrupoQuestao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Nome VARCHAR(50),
	PRIMARY KEY (Id)
) 
;


CREATE TABLE RespostaQuestao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdQuestao INTEGER,
	IdAvaliacao INTEGER,
	ValorResposta VARCHAR(250),
	PRIMARY KEY (Id),
	KEY (IdAvaliacao),
	KEY (IdQuestao)
) 
;


CREATE TABLE AvaliacaoQuestionario
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdAvaliacao INTEGER,
	IdQuestionario INTEGER,
	PRIMARY KEY (Id),
	KEY (IdAvaliacao),
	KEY (IdQuestionario)
) 
;


CREATE TABLE OpcaoQuestao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdQuestao INTEGER,
	Descricao VARCHAR(100),
	PRIMARY KEY (Id),
	KEY (IdQuestao)
) 
;


CREATE TABLE TipoQuestao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Nome VARCHAR(20),
	PRIMARY KEY (Id)
) 
;


CREATE TABLE Questao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdEtapa INTEGER,
	Descricao VARCHAR(250),
	IdTipoQuestao INTEGER,
	IdCategoriaQuestao INTEGER,
	IdQuestionario INTEGER,
	ValorBarema DECIMAL(10),
	PRIMARY KEY (Id),
	KEY (IdCategoriaQuestao),
	KEY (IdEtapa),
	KEY (IdQuestionario),
	KEY (IdTipoQuestao)
) 
;


CREATE TABLE Questionario
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Descricao TEXT,
	Ativo BOOL,
	PRIMARY KEY (Id)
) 
;


CREATE TABLE Avaliacao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdCandidatoProcessoSeletivo INTEGER,
	IdProfessor INTEGER,
	NotaFinal DECIMAL(10),
	DataAvaliacao DATE,
	Aprovado BOOL,
	Concluida BOOL,
	PRIMARY KEY (Id),
	KEY (IdProfessor)
) 
;


CREATE TABLE AreaConcentracao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Nome VARCHAR(100),
	PRIMARY KEY (Id)
) 
;


CREATE TABLE CandidatoProcessoSeletivo
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdProcessoSeletivo INTEGER,
	IdCandidato INTEGER,
	IdAreaConcentracao INTEGER,
	TemaProjeto VARCHAR(150),
	DescricaoTema TEXT,
	PRIMARY KEY (Id),
	KEY (IdAreaConcentracao),
	KEY (IdProcessoSeletivo),
	KEY (IdCandidato)
) 
;


CREATE TABLE ProcessoSeletivo
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Titulo VARCHAR(100),
	NumeroEdital VARCHAR(20),
	Descricao TEXT,
	DataInicio DATE,
	DataFim DATE,
	Liberado BOOL,
	Ativo BOOL,
	IdUsuarioCadastro INTEGER,
	IdUsuarioLiberacao INTEGER,
	PRIMARY KEY (Id)
) 
;


CREATE TABLE Candidato
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Nome VARCHAR(70),
	CPF VARCHAR(14),
	DataNascimento DATE,
	RG VARCHAR(14),
	OrgaoExpedidor VARCHAR(15),
	CotaNegros BOOL,
	CotaIndigena BOOL,
	LinguaEstrangeira VARCHAR(50),
	Endereco VARCHAR(100),
	Bairro VARCHAR(50),
	Cidade VARCHAR(50),
	Estado VARCHAR(2),
	CEP VARCHAR(9),
	Email VARCHAR(100),
	Telefone VARCHAR(12),
	Celular VARCHAR(12),
	NecessidadesEspeciais BOOL,
	TipoNecessidade VARCHAR(20),
	Curso VARCHAR(100),
	Instituicao VARCHAR(100),
	PRIMARY KEY (Id)
) 
;


CREATE TABLE PerfilMenu
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdPerfil INTEGER,
	IdMenu INTEGER,
	PRIMARY KEY (Id),
	KEY (IdMenu),
	KEY (IdPerfil)
) 
;


CREATE TABLE Menu
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdPai INTEGER,
	Nome VARCHAR(50),
	Url VARCHAR(50),
	PRIMARY KEY (Id)
) 
;


CREATE TABLE Perfil
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Nome VARCHAR(20),
	PRIMARY KEY (Id)
) 
;


CREATE TABLE Usuario
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	IdPerfil INTEGER,
	Nome VARCHAR(70),
	Matricula VARCHAR(50),
	CPF VARCHAR(12),
	Email VARCHAR(100),
	Telefone1 VARCHAR(12),
	Telefone2 VARCHAR(12),
	DataCadastro DATE,
	Ativo BOOL DEFAULT 1,
	Senha VARCHAR(150),
	PRIMARY KEY (Id),
	KEY (IdPerfil)
) 
;





ALTER TABLE CategoriaQuestao ADD CONSTRAINT FK_CategQuest_GrpQuestao 
	FOREIGN KEY (IdGrupoQuestao) REFERENCES GrupoQuestao (Id)
;

ALTER TABLE RespostaQuestao ADD CONSTRAINT FK_RespQuest_Avaliacao 
	FOREIGN KEY (IdAvaliacao) REFERENCES Avaliacao (Id)
;

ALTER TABLE RespostaQuestao ADD CONSTRAINT FK_RespQuest_Questao 
	FOREIGN KEY (IdQuestao) REFERENCES Questao (Id)
;

ALTER TABLE AvaliacaoQuestionario ADD CONSTRAINT FK_AvalQuest_Aval 
	FOREIGN KEY (IdAvaliacao) REFERENCES Avaliacao (Id)
;

ALTER TABLE AvaliacaoQuestionario ADD CONSTRAINT FK_AvalQuest_Quest 
	FOREIGN KEY (IdQuestionario) REFERENCES Questionario (Id)
;

ALTER TABLE OpcaoQuestao ADD CONSTRAINT FK_OpcaoQuestao_Questao 
	FOREIGN KEY (IdQuestao) REFERENCES Questao (Id)
;

ALTER TABLE Questao ADD CONSTRAINT FK_Quest_CatQuest 
	FOREIGN KEY (IdCategoriaQuestao) REFERENCES CategoriaQuestao (Id)
;

ALTER TABLE Questao ADD CONSTRAINT FK_Questao_Etapa 
	FOREIGN KEY (IdEtapa) REFERENCES Etapa (Id)
;

ALTER TABLE Questao ADD CONSTRAINT FK_Questao_Questionario 
	FOREIGN KEY (IdQuestionario) REFERENCES Questionario (Id)
;

ALTER TABLE Questao ADD CONSTRAINT FK_Questao_TipoQuestao 
	FOREIGN KEY (IdTipoQuestao) REFERENCES TipoQuestao (Id)
;

ALTER TABLE Avaliacao ADD CONSTRAINT FK_Avaliacao_UsuarioProfessor 
	FOREIGN KEY (IdProfessor) REFERENCES Usuario (Id)
;

ALTER TABLE CandidatoProcessoSeletivo ADD CONSTRAINT FK_CandiProcSel_AreaConce 
	FOREIGN KEY (IdAreaConcentracao) REFERENCES AreaConcentracao (Id)
;

ALTER TABLE CandidatoProcessoSeletivo ADD CONSTRAINT FK_CandProcSel_ProcSel 
	FOREIGN KEY (IdProcessoSeletivo) REFERENCES ProcessoSeletivo (Id)
;

ALTER TABLE CandidatoProcessoSeletivo ADD CONSTRAINT FK_CandiProcSele_Cand 
	FOREIGN KEY (IdCandidato) REFERENCES Candidato (Id)
;

ALTER TABLE PerfilMenu ADD CONSTRAINT FK_PerfilMenu_Menu 
	FOREIGN KEY (IdMenu) REFERENCES Menu (Id)
;

ALTER TABLE PerfilMenu ADD CONSTRAINT FK_PerfilMenu_Perfil 
	FOREIGN KEY (IdPerfil) REFERENCES Perfil (Id)
;

ALTER TABLE Usuario ADD CONSTRAINT FK_Usuario_Perfil 
	FOREIGN KEY (IdPerfil) REFERENCES Perfil (Id)
;
