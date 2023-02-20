function AnalyzePath (inputExcelFile, outputExcelFile)

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
    
    [pathdevPeg, patheffPeg, totalPegPath] = PathAnalysis(data);
    
%     AllData(counter,1) = time(end,1);
%     AllData(counter,2) = length(changePts);
    AllData(counter,1) = pathdevPeg;
    AllData(counter,2) = patheffPeg;
    AllData(counter,3) = totalPegPath;    
end

writematrix(AllData, outputExcelFile);