create database sistemamedico;
use sistemamedico;

create table funcionario(
idMedico int,
idpaciente int,
crm varchar (30) ,
rg varchar (10) not null,
cpf varchar (11) not null,
endereco text not null,
telefone varchar (11) ,
especialidade varchar (60),
login  varchar (50) not null ,
senha varchar (50) not null
);

select * from funcionario;
create table medico(
idmedico int primary key not null,
nome_medico varchar(30),
idEspecialidade varchar(60)

);

create table paciente(
idpaciente int primary key not null,
nome_paciente varchar (50) not null,
data_nascimento date not null,
rg varchar (30) not null,
endereco text null

);

create table login(
login varchar(50) primary key not null,
senha varchar(50)
);

alter table funcionario ADD constraint id_fk_medico
foreign key(idmedico) references medico (idmedico);

alter table funcionario add constraint id_fk_paciente
foreign key(idpaciente) references paciente(idpaciente);

alter table funcionario add constraint id_fk_especialidade
foreign key (especialidade) references medico(idEspecialidade);

alter table funcionario add constraint id_fk_login
foreign key (login) references login (login);

alter table funcionario add constraint id_fk_senha
foreign key (senha) references login (senha);

alter table funcionario
add column tipo_acesso varchar (10) after idpaciente;

alter table funcionario
add column idfuncionario int primary key auto_increment after idpaciente;



select * from funcionario where (idMedico is not null  && idPaciente is null)||(idMedico is null && idPaciente is not null);

delete from funcionario where (idMedico is not null  && idpaciente is not null && idfuncionario is not null )||(idMedico is null && idpaciente is null && idfuncionario is not null);
SET SQL_SAFE_UPDATES = 0;


