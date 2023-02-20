function AnalyzeHeadMotion (inputExcelFile, outputExcelFile)

sheets = sheetnames(inputExcelFile);
sheetCount = size(sheets);
sheetCount = sheetCount(1,1);
counter = 0;
AllData = [];

while(1)
    counter = counter + 1;
    if (counter > sheetCount)
        break;
    end    
    
    data = readmatrix(inputExcelFile,'Sheet',counter);    
    
    disp(sheets(counter,1));
    
    [tot_energy, rot_energy, trans_energy, time] = ComputeHeadKineticEnergy(data);
    
%     AllData(counter,1) = time(end,1);
%     AllData(counter,2) = length(changePts);
    AllData(counter,1) = tot_energy(end,1);
    AllData(counter,2) = rot_energy(end,1);
    AllData(counter,3) = trans_energy(end,1);    
end

writematrix(AllData, outputExcelFile);