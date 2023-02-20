function matrix = BasicTranslationMatrix(dx, dy, dz)

matrix = eye(4);

matrix(1,4) = dx;
matrix(2,4) = dy;
matrix(3,4) = dz;