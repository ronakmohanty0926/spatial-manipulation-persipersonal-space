function phibrac = logSE3(E)
% SE(3) logarithm
THRESH = 1e-9;
% https://pixhawk.org/_media/dev/know-how/jlblanco2010geometry3d_techrep.pdf
R = E(1:3,1:3);
cosTheta = 0.5*(trace(R)-1);
theta = acos(cosTheta);
if abs(theta) < THRESH
	phibrac = zeros(3);
else
	sinTheta = sin(theta);
	wBracket = theta/(2*sinTheta)*(R-R');
	phibrac = wBracket;
end
if size(E,2) == 4
	phibrac = [phibrac [0 0 0]'; 0 0 0 0];
	p = E(1:3,4);
	if abs(theta) < THRESH
		v = p;
	else
		V = eye(3) + (1-cosTheta)/theta^2*wBracket + (theta-sinTheta)/theta^3*wBracket*wBracket;
		v = V\p;
	end
	phibrac(1:3,4) = v;
end
end