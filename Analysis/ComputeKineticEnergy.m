function [C_T, C_Tr, C_Tp, time] = ComputeKineticEnergy(data, Shape)

dataLen = length(data(:,1));
base_matrix = eye(4);
T = 0;
Tr = 0;
Tp = 0;

C_T = zeros(dataLen,1);
C_Tr = zeros(dataLen,1);
C_Tp = zeros(dataLen,1);

time = data(:,1);
pegData = data(:,2:7);

% The angle data should be in the -180 to +180 range
for m = 4 : 6
    bigAngle = pegData(:,m) > 180;
    pegData(bigAngle,m) = pegData(bigAngle,m) - 360;
end

% Filter Data
fs = 1/(time(2)-time(1)); % source frequency
fc = 10;  % cutoff frequency
order = 6; % filter order
[b,a] = butter(order,fc/(fs/2));

f_pegData =  filtfilt(b,a,pegData);

for i = 2:dataLen
    prev_posX = f_pegData(i-1,1);
    prev_posY = f_pegData(i-1,2);
    prev_posZ = f_pegData(i-1,3);

    prev_angX = f_pegData(i-1,4);
    prev_angY = f_pegData(i-1,5);
    prev_angZ = f_pegData(i-1,6);

    T_prev = BasicTranslationMatrix(prev_posX, prev_posY, prev_posZ);
    Rx_prev = BasicRotationMatrix('X',prev_angX);
    Ry_prev = BasicRotationMatrix('Y',prev_angY);
    Rz_prev = BasicRotationMatrix('Z',prev_angZ);

    trans_prev = T_prev*Ry_prev*Rx_prev*Rz_prev; 
    mat_prev = trans_prev*base_matrix;
    mat_prev(:,2) = -1.*mat_prev(:,2);
    
    curr_posX = f_pegData(i,1);
    curr_posY = f_pegData(i,2);
    curr_posZ = f_pegData(i,3);

    curr_angX = f_pegData(i,4);
    curr_angY = f_pegData(i,5);
    curr_angZ = f_pegData(i,6);

    T_curr = BasicTranslationMatrix(curr_posX, curr_posY, curr_posZ);
    Rx_curr = BasicRotationMatrix('X',curr_angX);
    Ry_curr = BasicRotationMatrix('Y',curr_angY);
    Rz_curr = BasicRotationMatrix('Z',curr_angZ);

    trans_curr = T_curr*Ry_curr*Rx_curr*Rz_curr;
    mat_curr = trans_curr*base_matrix;
    mat_curr(:,2) = -1.*mat_curr(:,2);

    phi = ComputeTwist(mat_prev, mat_curr);

    m = GetInertiaMatrix(Shape);
    M = diag(m);

    % Kinetic energy
%     T = abs(0.5*phi'*M*phi);
%     Tr = abs(0.5*phi(1:3)'*M(1:3,1:3)*phi(1:3)); % just rotational
%     Tp = abs(0.5*phi(4:6)'*M(4:6,4:6)*phi(4:6)); % just translational
    
    % Cumulative KE
    T = T + abs(0.5*phi'*M*phi);
    Tr = Tr + abs(0.5*phi(1:3)'*M(1:3,1:3)*phi(1:3)); % just rotational
    Tp = Tp + abs(0.5*phi(4:6)'*M(4:6,4:6)*phi(4:6)); % just translational

    C_T(i,1) = T;
    C_Tr(i,1) = Tr;
    C_Tp(i,1) = Tp;        
end

% AllData(:,1) = Time;
% AllData(:,2) = C_T./(10.^7);
% save('KE_Cylinder.mat', 'AllData');

%     clf;
%     f1 = plot(Time, C_T);
%     xlabel('Time in seconds');
%     ylabel('Total Kinetic Energy');
%     saveas(f1,'TKE6_smallTwoPin_5.png')
    
%     clf;
%     f2 = plot(Time, C_Tp);
%     xlabel('Time in seconds');
%     ylabel('Translational Kinetic Energy');
%     saveas(f2,'TpKE6_largeThreePin_3.png')
%     
%     clf;
%     f3 = plot(Time, C_Tr);
%     xlabel('Time in seconds');
%     ylabel('Rotational Kinetic Energy');
%     saveas(f3,'TrKE6_largeThreePin_3.png')
end
        
        
        
        
        
    