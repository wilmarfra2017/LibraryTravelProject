--TABLA autores:
INSERT INTO autores (id, nombre, apellidos) VALUES (1, 'Juan', 'Martínez Pérez');
INSERT INTO autores (id, nombre, apellidos) VALUES (2, 'María', 'García Rodríguez');
INSERT INTO autores (id, nombre, apellidos) VALUES (3, 'Carlos', 'Ramírez Sánchez');
INSERT INTO autores (id, nombre, apellidos) VALUES (4, 'Ana', 'Hernández López');

--TABLA editoriales:
INSERT INTO editoriales (id, nombre, sede) VALUES (1, 'Ediciones Maravilla', 'Madrid');
INSERT INTO editoriales (id, nombre, sede) VALUES (2, 'Libros Fantásticos', 'Barcelona');
INSERT INTO editoriales (id, nombre, sede) VALUES (3, 'Editorial Imaginaria', 'Valencia');

--TABLA libros:
INSERT INTO libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas) VALUES (1001, 1, 'El jardín secreto', 'La historia de un jardín mágico y sus misterios', '320');
INSERT INTO libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas) VALUES (1002, 2, 'La montaña encantada', 'Una aventura en una montaña llena de seres mágicos', '450');
INSERT INTO libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas) VALUES (1003, 3, 'La ciudad perdida', 'Un grupo de exploradores encuentra una ciudad antigua', '280');
INSERT INTO libros (ISBN, editoriales_id, titulo, sinopsis, n_paginas) VALUES (1004, 1, 'Misterio en la playa', 'Un grupo de amigos resuelve un misterio en sus vacaciones', '230');

--TABLA autores_has_libros:
INSERT INTO autores_has_libros (autores_id, libros_ISBN) VALUES (1, 1001);
INSERT INTO autores_has_libros (autores_id, libros_ISBN) VALUES (1, 1004);
INSERT INTO autores_has_libros (autores_id, libros_ISBN) VALUES (2, 1002);
INSERT INTO autores_has_libros (autores_id, libros_ISBN) VALUES (3, 1003);
