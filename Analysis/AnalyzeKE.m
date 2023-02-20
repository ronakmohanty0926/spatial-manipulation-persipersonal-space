function AnalyzeKE(inputExcelFile, outputExcelFile, shape, maxNumChng, threshold)

clc;
clear;
close('all');

sheets = sheetnames(inputExcelFile);
sheetCount = size(sheets);
sheetCount = sheetCount(1,1);
counter = 0;
AllData = [];
disp(Shape);

while(1)
    counter = counter + 1;
    if (counter > sheetCount)
        break;
    end    
    
    data = readmatrix(inputExcelFile,'Sheet',counter);    
    
    disp(sheets(counter,1));
    
    [tot_energy, rot_energy, trans_energy, time] = ComputeKineticEnergy(data, shape);
    
    % convert from Ergs to millijoules
%     tot_energy = tot_energy./1.0e4;
%     rot_energy = rot_energy./1.0e-4;
%     trans_energy = trans_energy./1.0e-4;
    
    [changePts, new_idx] = AnalyzeAction(tot_energy, time, maxNumChng, threshold);
    
    AllData(counter,1) = time(end,1);
    AllData(counter,2) = length(changePts);
    AllData(counter,3) = tot_energy(end,1);
    AllData(counter,4) = rot_energy(end,1);
    AllData(counter,5) = trans_energy(end,1);    
end

writematrix(AllData, outputExcelFile);
    
    