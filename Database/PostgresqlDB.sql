CREATE SEQUENCE public.drink_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

CREATE TABLE public.drink
(
    id bigint NOT NULL DEFAULT nextval('drink_id_seq'::regclass),
    drink character varying(100) COLLATE pg_catalog."default" NOT NULL,
    client integer NOT NULL,
    sugar integer NOT NULL,
    mug boolean NOT NULL,
    CONSTRAINT drink_pkey PRIMARY KEY (id),
    CONSTRAINT drink_client_fkey FOREIGN KEY (client)
        REFERENCES public.client (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

CREATE SEQUENCE public.client_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;


CREATE TABLE public.client
(
    id integer NOT NULL DEFAULT nextval('client_id_seq'::regclass),
    username character varying(100) COLLATE pg_catalog."default" NOT NULL,
    email character varying(500) COLLATE pg_catalog."default" NOT NULL,
    password character varying(1000) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT client_pkey PRIMARY KEY (id)
)
