CREATE DATABASE ProjetoFinalDS_EAD;
USE ProjetoFinalDS_EAD;

CREATE TABLE Usuarios (
idUsuario INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(200) NOT NULL,
email VARCHAR(150) NOT NULL UNIQUE,
userName VARCHAR(100) NOT NULL UNIQUE,
senha VARCHAR(100) NOT NULL,
tipo VARCHAR(50) NOT NULL,
dtNascimento VARCHAR(15) NOT NULL,
sexo VARCHAR(15) NOT NULL,
telFixo VARCHAR(10) NULL,
telCelular VARCHAR(11) NULL,
endereco VARCHAR(200) NOT NULL,
numero VARCHAR(100) NOT NULL,
bairro VARCHAR(150) NOT NULL,
cidade VARCHAR(100) NOT NULL,
estado VARCHAR(50) NOT NULL,
cep VARCHAR(50) NOT NULL,
ativo varchar(10) NOT NULL,
RG VARCHAR(25) NOT NULL UNIQUE,
CPF VARCHAR(11) NOT NULL UNIQUE);

select * from Usuarios;

CREATE TABLE Produto (
idProduto INT PRIMARY KEY IDENTITY(1,1),
codBarras VARCHAR(13) NOT NULL UNIQUE,
nome VARCHAR(250) NOT NULL,
descricao VARCHAR(250) NOT NULL,
preco INT NOT NULL,
estoque INT NOT NULL,
unidade INT NOT NULL,
tipo VARCHAR(30) NOT NULL,
ativo VARCHAR(10) NOT NULL);

select * from Produto;

INSERT INTO Usuarios
(
    nome,
    email,
    userName,
    senha,
    tipo,
    dtNascimento,
    sexo,
    telFixo,
    telCelular,
    endereco,
    numero,
    bairro,
    cidade,
    estado,
    cep,
    ativo,
    RG,
    CPF
)
VALUES
(   'Marcelo Pelaes Almeida',        
    'celo.pelaes@hotmail.com',        
    'celo_almeida',        
    '123456',        
    'administrador',        
    '1984-03-08', 
    'Masculino',       
    '1133334444',        
    '11952827130',        
    'teste',
    'teste',
    'teste',
    'teste',
    'Distrito Federal - DF',
    '05892819',
    'Ativo',     
    '123456',        
    '33355588879'       
)


