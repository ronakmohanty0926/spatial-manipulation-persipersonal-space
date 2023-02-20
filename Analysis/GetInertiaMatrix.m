function matrix = GetInertiaMatrix(Shape)

matrix = zeros(6,1);
density = 1.25;

if strcmp(Shape,'smallCylinder') || strcmp(Shape,'mediumCylinder') || strcmp(Shape,'largeCylinder') 
    volume = 3.53; 
    mass = 4.42; 
    matrix(1,1) = 7.73;
    matrix(2,1) = 0.55;
    matrix(3,1) = 7.73;
    matrix(4,1) = mass;
    matrix(5,1) = mass;
    matrix(6,1) = mass;
elseif strcmp(Shape, 'smallShaftKey') || strcmp(Shape, 'mediumShaftKey') || strcmp(Shape, 'largeShaftKey')
    volume = 3.75; 
    mass = 4.68; 
    matrix(1,1) = 8.26;
    matrix(2,1) = -0.64;
    matrix(3,1) = 8.18;
    matrix(4,1) = mass;
    matrix(5,1) = mass;
    matrix(6,1) = mass;
elseif strcmp(Shape, 'smallTwoPin')
    volume = 5.98; 
    mass = 7.48; 
    matrix(1,1) = 7.51;
    matrix(2,1) = -2.39;
    matrix(3,1) = 7.51;
    matrix(4,1) = mass;
    matrix(5,1) = mass;
    matrix(6,1) = mass;
elseif strcmp(Shape,'mediumTwoPin')
    volume = 7.55; 
    mass = 9.43; 
    matrix(1,1) = 9.69;
    matrix(2,1) = -3.83;
    matrix(3,1) = 9.69;
    matrix(4,1) = mass;
    matrix(5,1) = mass;
    matrix(6,1) = mass;
elseif strcmp(Shape, 'largeTwoPin')
    volume = 7.51; 
    mass = 9.39; 
    matrix(1,1) = 9.63;
    matrix(2,1) = -3.82;
    matrix(3,1) = 9.63;
    matrix(4,1) = mass;
    matrix(5,1) = mass;
    matrix(6,1) = mass;
elseif strcmp(Shape, 'smallThreePin') || strcmp(Shape, 'mediumThreePin') || strcmp(Shape, 'largeThreePin')
    volume = 15.27;
    mass = 19.08; 
    matrix(1,1) = 23.78;
    matrix(2,1) = 14.65;
    matrix(3,1) = 23.78;
    matrix(4,1) = mass;
    matrix(5,1) = mass;
    matrix(6,1) = mass;
elseif strcmp(Shape, 'head') || strcmp(Shape, 'Head')
    volume = 350.77;
    mass = 345.51; 
    matrix(1,1) = 2645.30;
    matrix(2,1) = 2645.30;
    matrix(3,1) = 2645.30;
    matrix(4,1) = mass;
    matrix(5,1) = mass;
    matrix(6,1) = mass;
end
    