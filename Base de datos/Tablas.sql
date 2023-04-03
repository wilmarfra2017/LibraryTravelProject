CREATE TABLE autores (
  id INT PRIMARY KEY,
  nombre VARCHAR(45),
  apellidos VARCHAR(45)
);

CREATE TABLE editoriales (
  id INT PRIMARY KEY,
  nombre VARCHAR(45),
  sede VARCHAR(45)
);

CREATE TABLE libros (
  ISBN INT PRIMARY KEY,
  editoriales_id INT FOREIGN KEY REFERENCES editoriales(id),
  titulo VARCHAR(45),
  sinopsis TEXT,
  n_paginas VARCHAR(45)
);

CREATE TABLE autores_has_libros (
  autores_id INT REFERENCES autores(id),
  libros_ISBN INT REFERENCES libros(ISBN),
  PRIMARY KEY (autores_id, libros_ISBN)
);
