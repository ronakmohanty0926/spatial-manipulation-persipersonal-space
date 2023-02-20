function x = unbrac(S)
% Gets ]x[ = S, the vector corresponding to a skew symmetric matrix
if size(S,2) < 4
	x = [S(3,2); S(1,3); S(2,1)];
else
	x = [S(3,2); S(1,3); S(2,1); S(1,4); S(2,4); S(3,4)];
end
end