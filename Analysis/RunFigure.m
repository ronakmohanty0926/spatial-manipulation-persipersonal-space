clc;
clear;
close('all');

variant = 'GS';
shape = 'ThreePin';

inputFileName = strcat(variant,{'_All_'}, shape,{'.xlsx'});
inputFileName = cell2mat(inputFileName);

timeOutputFileName = strcat({'Time_'}, variant,{'_'}, shape,{'.emf'});
timeOutputFileName = cell2mat(timeOutputFileName);

energyOutputFileName = strcat({'KE_'}, variant,{'_'}, shape,{'.emf'});
energyOutputFileName = cell2mat(energyOutputFileName);

changesOutputFileName = strcat({'Changes_'}, variant,{'_'}, shape,{'.emf'});
changesOutputFileName = cell2mat(changesOutputFileName);

time_limit = 30;
energy_limit = 80.*1000000;
changes_limit = 100;

GetFigures(inputFileName, timeOutputFileName, energyOutputFileName, changesOutputFileName,time_limit, energy_limit, changes_limit, variant);