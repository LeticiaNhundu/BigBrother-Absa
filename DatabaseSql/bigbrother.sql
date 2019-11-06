--
-- PostgreSQL database dump
--

-- Dumped from database version 11.5
-- Dumped by pg_dump version 11.5

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: poc; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA poc;


ALTER SCHEMA poc OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: emotions; Type: TABLE; Schema: poc; Owner: postgres
--

CREATE TABLE poc.emotions (
    emotion_id integer NOT NULL,
    emotion_name character varying(255)
);


ALTER TABLE poc.emotions OWNER TO postgres;

--
-- Name: person; Type: TABLE; Schema: poc; Owner: postgres
--

CREATE TABLE poc.person (
    person_id integer NOT NULL,
    abnumber character varying(10),
    name character varying(30),
    surname character varying(30)
);


ALTER TABLE poc.person OWNER TO postgres;

--
-- Name: person_emotions; Type: TABLE; Schema: poc; Owner: postgres
--

CREATE TABLE poc.person_emotions (
    id integer NOT NULL,
    emotion_fk integer,
    person_fk integer,
    percentage numeric,
    emotion_date date
);


ALTER TABLE poc.person_emotions OWNER TO postgres;

--
-- Name: team_; Type: TABLE; Schema: poc; Owner: postgres
--

CREATE TABLE poc.team_ (
    id integer NOT NULL,
    person_fk integer,
    team_fk integer
);


ALTER TABLE poc.team_ OWNER TO postgres;

--
-- Name: teams; Type: TABLE; Schema: poc; Owner: postgres
--

CREATE TABLE poc.teams (
    team_id integer NOT NULL,
    team_name character varying(255)
);


ALTER TABLE poc.teams OWNER TO postgres;

--
-- Name: emotions emotions_pkey; Type: CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.emotions
    ADD CONSTRAINT emotions_pkey PRIMARY KEY (emotion_id);


--
-- Name: person_emotions person_emotions_pkey; Type: CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.person_emotions
    ADD CONSTRAINT person_emotions_pkey PRIMARY KEY (id);


--
-- Name: person person_pkey; Type: CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.person
    ADD CONSTRAINT person_pkey PRIMARY KEY (person_id);


--
-- Name: team_ team__pkey; Type: CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.team_
    ADD CONSTRAINT team__pkey PRIMARY KEY (id);


--
-- Name: teams teams_pkey; Type: CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.teams
    ADD CONSTRAINT teams_pkey PRIMARY KEY (team_id);


--
-- Name: person_emotions person_emotions_emotion_fk_fkey; Type: FK CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.person_emotions
    ADD CONSTRAINT person_emotions_emotion_fk_fkey FOREIGN KEY (emotion_fk) REFERENCES poc.emotions(emotion_id);


--
-- Name: person_emotions person_emotions_person_fk_fkey; Type: FK CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.person_emotions
    ADD CONSTRAINT person_emotions_person_fk_fkey FOREIGN KEY (person_fk) REFERENCES poc.person(person_id);


--
-- Name: team_ team__person_fk_fkey; Type: FK CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.team_
    ADD CONSTRAINT team__person_fk_fkey FOREIGN KEY (person_fk) REFERENCES poc.person(person_id);


--
-- Name: team_ team__team_fk_fkey; Type: FK CONSTRAINT; Schema: poc; Owner: postgres
--

ALTER TABLE ONLY poc.team_
    ADD CONSTRAINT team__team_fk_fkey FOREIGN KEY (team_fk) REFERENCES poc.teams(team_id);


--
-- PostgreSQL database dump complete
--

