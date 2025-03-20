-- Création de la base de données
CREATE DATABASE gestion_eleves;

-- Utilisation de la base de données
\c gestion_eleves

-- Table Eleve
CREATE TABLE Eleve (
                       id SERIAL PRIMARY KEY,
                       nom VARCHAR(100) NOT NULL,
                       prenom VARCHAR(100) NOT NULL,
                       date_naissance DATE NOT NULL,
                       adresse VARCHAR(255),
                       telephone VARCHAR(20),
                       email VARCHAR(100)
);

-- Table Classe
CREATE TABLE Classe (
                        id SERIAL PRIMARY KEY,
                        nom VARCHAR(50) NOT NULL,
                        niveau VARCHAR(20) NOT NULL
);

-- Table d'association Eleve_Classe
CREATE TABLE Eleve_Classe (
                              id_eleve INT REFERENCES Eleve(id),
                              id_classe INT REFERENCES Classe(id),
                              annee_scolaire VARCHAR(9) NOT NULL,
                              PRIMARY KEY (id_eleve, id_classe, annee_scolaire)
);

-- Table Note
CREATE TABLE Note (
                      id SERIAL PRIMARY KEY,
                      id_eleve INT REFERENCES Eleve(id),
                      matiere VARCHAR(50) NOT NULL,
                      valeur NUMERIC(4,2) NOT NULL,
                      date_evaluation DATE NOT NULL
);