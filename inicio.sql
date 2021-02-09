--CREATE DATABASE stur;

--DROP raole stur;

--CREATE USER userstur4 WITH encrypted PASSWORD 'stur2021!';
--GRANT ALL PRIVILEGES ON DATABASE stur TO userstur;

begin;

CREATE TABLE imposto (
id SERIAL,
valor numeric(15,2) NOT NULL DEFAULT 0,
inscricaoimovel varchar(20) NOT NULL,
datavencimento timestamp NOT NULL,
descricao varchar(255) NOT NULL DEFAULT '',
areaconstruida numeric(15,2) NOT NULL DEFAULT 0,
areaterreno numeric(15,2) NOT NULL DEFAULT 0,
CONSTRAINT imposto_pkey PRIMARY KEY (id)
);

INSERT INTO imposto (valor, inscricaoimovel, datavencimento, descricao, areaconstruida, areaterreno)
VALUES 
(60*3.5, '30014444', '2021-2-6', '', 60, 140),
(100*3.5, '30054444', '2021-2-6', '', 100, 140),
(160*3.5, '30014334', '2021-2-6', '', 160, 340),
(60*3.5, '20013144', '2021-2-6', '', 60, 140),
(60*3.5, '40016665', '2021-2-6', '', 60, 140),
(60*3.5, '40013264', '2021-2-6', '', 60, 140),
(30*3.5, '10014477', '2021-2-6', '', 30, 100),
(60*3.5, '20014454', '2021-2-6', '', 60, 140),
(60*3.5, '10066666', '2021-2-6', '', 60, 140),
(60*3.5, '30014888', '2021-2-6', '', 60, 140),
(60*3.5, '30020009', '2021-2-6', '', 60, 140),
(60*3.5, '30004444', '2021-2-6', '', 60, 140),
(60*3.5, '30074444', '2021-2-6', '', 60, 140);

commit;
