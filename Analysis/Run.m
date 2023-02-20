clc;
clear;
close('all');

% GS is Gold Standard
% PR is Pure Virtual
% PV is Physical-Virtual
AnalyzePath ('GS_smallCylinder.xlsx', 'Path_GS_smallCylinder.xlsx')

% PRsmall3PTime = readmatrix('KE_PR_smallThreePin.xlsx','DataRange','A1:A76');
% PRsmall3PChangePts = readmatrix('KE_PR_smallThreePin.xlsx','DataRange','B1:B76');
% PRsmall3PKE = readmatrix('KE_PR_smallThreePin.xlsx','DataRange','C1:C76');
% 
% PRmedium3PTime = readmatrix('KE_PR_mediumThreePin.xlsx','DataRange','A1:A76');
% PRmedium3PChangePts = readmatrix('KE_PR_mediumThreePin.xlsx','DataRange','B1:B76');
% PRmedium3PKE = readmatrix('KE_PR_mediumThreePin.xlsx','DataRange','C1:C76');
% 
% PRlarge3PTime = readmatrix('KE_PR_largeThreePin.xlsx','DataRange','A1:A76');
% PRlarge3PChangePts = readmatrix('KE_PR_largeThreePin.xlsx','DataRange','B1:B76');
% PRlarge3PKE = readmatrix('KE_PR_largeThreePin.xlsx','DataRange','C1:C76');
% 
% PVsmall3PTime = readmatrix('KE_PV_smallThreePin.xlsx','DataRange','A1:A74');
% PVsmall3PChangePts = readmatrix('KE_PV_smallThreePin.xlsx','DataRange','B1:B74');
% PVsmall3PKE = readmatrix('KE_PV_smallThreePin.xlsx','DataRange','C1:C74');
% 
% PVmedium3PTime = readmatrix('KE_PV_mediumThreePin.xlsx','DataRange','A1:A74');
% PVmedium3PChangePts = readmatrix('KE_PV_mediumThreePin.xlsx','DataRange','B1:B74');
% PVmedium3PKE = readmatrix('KE_PV_mediumThreePin.xlsx','DataRange','C1:C74');
% 
% PVlarge3PTime = readmatrix('KE_PV_largeThreePin.xlsx','DataRange','A1:A74');
% PVlarge3PChangePts = readmatrix('KE_PV_largeThreePin.xlsx','DataRange','B1:B74');
% PVlarge3PKE = readmatrix('KE_PV_largeThreePin.xlsx','DataRange','C1:C74');
% 
% GSsmall3PTime = readmatrix('KE_GS_smallThreePin.xlsx','DataRange','A1:A78');
% GSsmall3PChangePts = readmatrix('KE_GS_smallThreePin.xlsx','DataRange','B1:B78');
% GSsmall3PKE = readmatrix('KE_GS_smallThreePin.xlsx','DataRange','C1:C78');
% 
% GSmedium3PTime = readmatrix('KE_GS_mediumThreePin.xlsx','DataRange','A1:A76');
% GSmedium3PChangePts = readmatrix('KE_GS_mediumThreePin.xlsx','DataRange','B1:B76');
% GSmedium3PKE = readmatrix('KE_GS_mediumThreePin.xlsx','DataRange','C1:C76');
% 
% GSlarge3PTime = readmatrix('KE_GS_largeThreePin.xlsx','DataRange','A1:A79');
% GSlarge3PChangePts = readmatrix('KE_GS_largeThreePin.xlsx','DataRange','B1:B79');
% GSlarge3PKE = readmatrix('KE_GS_largeThreePin.xlsx','DataRange','C1:C79');