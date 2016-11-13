ALTER TABLE Avaliacao add IdSituacaoAvaliacao INTEGER;

CREATE TABLE SituacaoAvaliacao
(
	Id INTEGER NOT NULL AUTO_INCREMENT,
	Situacao VARCHAR(50),
	PRIMARY KEY (Id)
);

ALTER TABLE Avaliacao ADD CONSTRAINT FK_Avaliacao_SitAvaliacao 
	FOREIGN KEY (IdSituacaoAvaliacao) REFERENCES SituacaoAvaliacao (Id);

INSERT INTO SituacaoAvaliacao(Id,Situacao) VALUES(1,'Pendente Etapa II Secretaria');
INSERT INTO SituacaoAvaliacao(Id,Situacao) VALUES(2,'Pendente Etapa II Professor');
INSERT INTO SituacaoAvaliacao(Id,Situacao) VALUES(3,'Pendente Etapa III');
INSERT INTO SituacaoAvaliacao(Id,Situacao) VALUES(4,'Concluída');