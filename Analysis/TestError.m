clc;
clear;
close('all');

data = readmatrix('GS_smallCylinder.xlsx','Sheet',55);
% data = readmatrix('GS_smallCylinder.xlsx','Sheet',55);
dataLen = length(data);
AllData = [];
base_matrix = eye(4);
time = data(:,1);
pegPos = data(:,2:4);
pegAng = data(:,5:7);
holePos = data(:,8:10);
holeAng = data(:,11:13);

% The angle data should be in the -180 to +180 range
for m = 1 : 3
    p_bigAngle = pegAng(:,m) > 180;
    h_bigAngle = holeAng(:,m) > 180;
    pegAng(p_bigAngle,m) = pegAng(p_bigAngle,m) - 360;
    holeAng(h_bigAngle,m) = holeAng(h_bigAngle,m) - 360;
end
 
% % Filter Data
% fs = 1/(time(2)-time(1)); % source frequency
% fc = 10;  % cutoff frequency
% order = 6; % filter order
% [b,a] = butter(order,fc/(fs/2));
% 
% pegPos = filtfilt(b,a,pegPos);
% pegAng = filtfilt(b,a,pegAng);
% holePos = filtfilt(b,a,holePos);
% holeAng = filtfilt(b,a,holeAng);

for i = 1:dataLen  
    mat_peg = [];
    mat_hole = [];
    PosX_peg = pegPos(i,1);
    PosY_peg = pegPos(i,2);
    PosZ_peg = pegPos(i,3);

    Rx_peg = BasicRotationMatrix('X',pegAng(i,1));
    Ry_peg = BasicRotationMatrix('Y',pegAng(i,2));
    Rz_peg = BasicRotationMatrix('Z',pegAng(i,3));

    PosX_hole = holePos(i,1);
    PosY_hole = holePos(i,2);
    PosZ_hole = holePos(i,3);

    Rx_hole = BasicRotationMatrix('X',holeAng(i,1));
    Ry_hole = BasicRotationMatrix('Y',holeAng(i,2));
    Rz_hole = BasicRotationMatrix('Z',holeAng(i,3));

    trans_peg = BasicTranslationMatrix(PosX_peg, PosY_peg, PosZ_peg);
    rot_peg = Ry_peg*Rx_peg*Rz_peg;
%     mat_peg = transrot_peg*trans_peg;
    mat_peg = trans_peg*rot_peg;
    mat_peg = mat_peg*base_matrix;
%     mat_peg = base_matrix*mat_peg;

    trans_hole = BasicTranslationMatrix(PosX_hole, PosY_hole, PosZ_hole);
    rot_hole = Ry_hole*Rx_hole*Rz_hole;
%     mat_hole = rot_hole*trans_hole;
    mat_hole = trans_hole*rot_hole;
    mat_hole = mat_hole*base_matrix;
%     mat_hole = base_matrix*mat_hole;

    peg_axialVector = -1*mat_peg(1:3,2);
%     peg_axialVector = peg_axialVector./norm(peg_axialVector);
    hole_axialVector = mat_hole(1:3,2);
%     hole_axialVector = hole_axialVector./norm(hole_axialVector);

    alignmentError = ComputeAlignmentError(peg_axialVector, hole_axialVector);
    AllData(i,1) = alignmentError;
end

% save(alignmentOutputMatFile,'AllData');

% close('all');
    