rng(2);

% https://en.wikipedia.org/wiki/List_of_moments_of_inertia
dx = 2;
dy = 1;
dz = 3;
density = 1;
m = inertiaCuboid([dx,dy,dx],density);
M = diag(m);

% Random frames
E_wa = randE();
E_wb = randE();

% Draw frames
clf;
hold on;
axis equal;
grid on;
xlabel('X');
ylabel('Y');
zlabel('Z');
view(3);
drawAxis(mat_peg);
drawAxis(mat_hole);
% drawAxis(E_wa);
% drawAxis(E_wb);
% [F,V] = patchCuboid(E_wa,[dx,dy,dz]);
% patch('Faces',F,'Vertices',V,'FaceColor',[0.5 0 0]);
% [F,V] = patchCuboid(E_wb,[dx,dy,dz]);
% patch('Faces',F,'Vertices',V,'FaceColor',[0 0.5 0]);
% alpha(0.5);

% Compute phi
E_ab = E_wa\E_wb;
phib = logSE3(E_ab);
phi = unbrac(phib);

% Kinetic energy
T = 0.5*phi'*M*phi;
Tr = 0.5*phi(1:3)'*M(1:3,1:3)*phi(1:3); % just rotational
Tp = 0.5*phi(4:6)'*M(4:6,4:6)*phi(4:6); % just translational
fprintf('Kinetic energy: %6.2f\n',T);
fprintf('rotational:     %6.2f\n',Tr);
fprintf('translational:  %6.2f\n',Tp);

%%
function E = randE()
% Creates a random transformation matrix
[Q,R] = qr(randn(3)); %#ok<ASGLU>
if det(Q) < 0
	% Negate the Z-axis
	Q(:,3) = -Q(:,3);
end
E = [Q, randn(3,1); 0 0 0 1];
end

%%
function m = inertiaCuboid(whd,density)
% Gets the diagonal inertia of a cuboid with (width, height, depth)
if size(whd,1) < size(whd,2)
	whd = whd';
end
m = zeros(6,1);
mass = density * prod(whd);
m(1) = (1/12) * mass * whd([2,3])' * whd([2,3]);
m(2) = (1/12) * mass * whd([3,1])' * whd([3,1]);
m(3) = (1/12) * mass * whd([1,2])' * whd([1,2]);
m(4) = mass;
m(5) = mass;
m(6) = mass;
end

%%
function [xlines,ylines,zlines] = drawAxis(E,r,w)
% Draws xyz axes at E
if nargin < 3
	w = 1;
end
if nargin < 2
	r = 1;
end
x = E(1:3,1);
y = E(1:3,2);
z = E(1:3,3);
p = E(1:3,4);
xlines = [p,p+r*x];
ylines = [p,p+r*y];
zlines = [p,p+r*z];
if nargout == 0
	plot3(xlines(1,:),xlines(2,:),xlines(3,:),'r','LineWidth',w);
	plot3(ylines(1,:),ylines(2,:),ylines(3,:),'g','LineWidth',w);
	plot3(zlines(1,:),zlines(2,:),zlines(3,:),'b','LineWidth',w);
end
end

%%
function [F,V] = patchCuboid(E,whd)
% Gets the faces and vertices for a cuboid at E with (width, height, depth)
whd = whd/2;
verts = ones(4,8);
verts(1:3,1) = [-whd(1), -whd(2), -whd(3)]';
verts(1:3,2) = [ whd(1), -whd(2), -whd(3)]';
verts(1:3,3) = [-whd(1),  whd(2), -whd(3)]';
verts(1:3,4) = [ whd(1),  whd(2), -whd(3)]';
verts(1:3,5) = [-whd(1), -whd(2),  whd(3)]';
verts(1:3,6) = [ whd(1), -whd(2),  whd(3)]';
verts(1:3,7) = [-whd(1),  whd(2),  whd(3)]';
verts(1:3,8) = [ whd(1),  whd(2),  whd(3)]';
verts = E*verts;
V = verts(1:3,:)';
F = [
	1 2 4 3
	8 7 5 6
	1 2 6 5
	8 7 3 4
	1 3 7 5
	8 6 2 4
	];
end

%%
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

%%
function x = unbrac(S)
% Gets ]x[ = S, the vector corresponding to a skew symmetric matrix
if size(S,2) < 4
	x = [S(3,2); S(1,3); S(2,1)];
else
	x = [S(3,2); S(1,3); S(2,1); S(1,4); S(2,4); S(3,4)];
end
end
