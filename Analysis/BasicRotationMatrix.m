function matrix = BasicRotationMatrix(axis, angle)

matrix = eye(4);

if axis == 'X'
    matrix(2,2) = cosd(angle);
    matrix(2,3) = -sind(angle);
    matrix(3,2) = sind(angle);
    matrix(3,3) = cosd(angle);
elseif axis == 'Y'
    matrix(1,1) = cosd(angle);
    matrix(1,3) = sind(angle);
    matrix(3,1) = -sind(angle);
    matrix(3,3) = cosd(angle);
elseif axis == 'Z'
    matrix(1,1) = cosd(angle);
    matrix(1,2) = -sind(angle);
    matrix(2,1) = sind(angle);
    matrix(2,2) = cosd(angle);
end