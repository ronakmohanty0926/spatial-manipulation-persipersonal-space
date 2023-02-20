function ComputerKineticEnergies(inputExcelFile, outputMatFile, Shape)

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
    
    [tot_energy, rot_energy, trans_energy, time] = ComputeKineticEnergy(data, Shape);
    
    [nPts] = SegmentKineticEnergy(tot_energy, time);
%     [nPts, idx] = SegmentKineticEnergy(tot_energy, time);
    
    AllData(counter,1) = time(end,1);
    AllData(counter,2) = tot_energy(end,1);
    AllData(counter,3) = rot_energy(end,1);
    AllData(counter,4) = trans_energy(end,1);
    AllData(counter,5) = nPts;    
end

save(outputMatFile, 'AllData')
    