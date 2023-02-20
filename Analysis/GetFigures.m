function GetFigures(inputFileName, timeOutputFileName, energyOutputFileName, changesOutputFileName,time_limit, energy_limit, changes_limit, variant)

time = readmatrix(inputFileName, 'Sheet',1);
GetFigure(time(:,1), time(:,2), time(:,3), time_limit, timeOutputFileName, variant);

energy = readmatrix(inputFileName, 'Sheet',2);
GetFigure(energy(:,1), energy(:,2), energy(:,3), energy_limit, energyOutputFileName, variant);

nChanges = readmatrix(inputFileName, 'Sheet',5);
GetFigure(nChanges(:,1), nChanges(:,2), nChanges(:,3), changes_limit, changesOutputFileName, variant);

clc;
clear;
close('all');