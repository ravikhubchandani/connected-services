-- SCHEMA: public

DROP SCHEMA public ;

CREATE SCHEMA public
    AUTHORIZATION root;

COMMENT ON SCHEMA public
    IS 'standard public schema';

GRANT ALL ON SCHEMA public TO PUBLIC;

GRANT ALL ON SCHEMA public TO root;

-- Table: public.Animals

-- DROP TABLE public."Animals";

CREATE TABLE public."Animals"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Animal_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE public."Animals"
    OWNER to root;
-- Static Data

insert into public."Animals" ("Name") values ('Monkey'), ('Zebra'), ('Lion'), ('Crocodile'), ('Hippo'), ('Gnu'), ('Toucan'), ('Donkey');

select * from public."Animals"