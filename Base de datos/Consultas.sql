SELECT 
  libros.ISBN,
  libros.titulo,
  autores.nombre AS autor_nombre,
  autores.apellidos AS autor_apellidos,
  editoriales.nombre AS editorial_nombre,
  editoriales.sede AS editorial_sede,
  libros.sinopsis,
  libros.n_paginas
FROM
  libros
JOIN
  autores_has_libros ON libros.ISBN = autores_has_libros.libros_ISBN
JOIN
  autores ON autores_has_libros.autores_id = autores.id
JOIN
  editoriales ON libros.editoriales_id = editoriales.id

------------------------------------------------------------------
