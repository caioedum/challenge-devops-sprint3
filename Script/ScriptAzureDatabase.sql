-- Verificando e eliminando tabelas existentes
IF OBJECT_ID('t_usuario_odontoprev', 'U') IS NOT NULL
    DROP TABLE t_usuario_odontoprev;

IF OBJECT_ID('t_imagem_usuario_odontoprev', 'U') IS NOT NULL
    DROP TABLE t_imagem_usuario_odontoprev;

IF OBJECT_ID('t_previsao_usuario_odontoprev', 'U') IS NOT NULL
    DROP TABLE t_previsao_usuario_odontoprev;

-- Criando tabelas Odontoprev
CREATE TABLE t_usuario_odontoprev (
    usuario_id       INT IDENTITY(1,1) PRIMARY KEY,
    cpf              VARCHAR(14) UNIQUE,
    nome             VARCHAR(100),
    sobrenome        VARCHAR(255),
    data_nascimento  DATETIME,
    genero           CHAR(1),
    data_cadastro    DATETIME DEFAULT GETDATE()
);

CREATE TABLE t_imagem_usuario_odontoprev (
    imagem_usuario_id  INT IDENTITY(1,1) PRIMARY KEY,
    usuario_id         INT,
    imagem_url         VARCHAR(255),
    data_envio         DATETIME2 DEFAULT SYSDATETIME(),
    
    CONSTRAINT fk_imagem_usuario FOREIGN KEY (usuario_id)
        REFERENCES t_usuario_odontoprev (usuario_id)
);

CREATE TABLE t_previsao_usuario_odontoprev (
    previsao_usuario_id  INT IDENTITY(1,1) PRIMARY KEY,
    imagem_usuario_id    INT,
    usuario_id           INT,
    previsao_texto       VARCHAR(255),
    probabilidade        DECIMAL(5,4), -- Ajustado para maior precisão
    recomendacao         VARCHAR(255),
    data_previsao        DATETIME2 DEFAULT SYSDATETIME(),
    
    CONSTRAINT fk_previsao_imagem FOREIGN KEY (imagem_usuario_id)
        REFERENCES t_imagem_usuario_odontoprev (imagem_usuario_id),
    
    CONSTRAINT fk_previsao_usuario FOREIGN KEY (usuario_id)
        REFERENCES t_usuario_odontoprev (usuario_id)
);
