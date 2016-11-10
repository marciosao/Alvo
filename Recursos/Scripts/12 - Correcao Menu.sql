alter table menu add Ativo boolean default 1 NOT NULL;

update menu set Ativo = 0 where Id = 3;


