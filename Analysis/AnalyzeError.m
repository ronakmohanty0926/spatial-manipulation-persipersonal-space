function AnalyzeError(inputExcelFile, outputMatFile)

sheets = sheetnames(inputExcelFile);
sheetCount = size(sheets);
sheetCount = sheetCount(1,1);
counter = 0;
Error = [];
base_matrix = eye(4);
% disp(Shape);

while(1)
    counter = counter + 1;
    if (counter > sheetCount)
        break;
    end    
    
    time = [];
    pegPos = [];
    pegAng = [];
    holePos = [];
    holeAng = [];
    
    data = readmatrix(inputExcelFile,'Sheet',counter); 
    dataLen = length(data);
    
    disp(sheets(counter,1));
    
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
    
    AllData = [];
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
        mat_peg = trans_peg*rot_peg;
        mat_peg = mat_peg*base_matrix;

        trans_hole = BasicTranslationMatrix(PosX_hole, PosY_hole, PosZ_hole);
        rot_hole = Ry_hole*Rx_hole*Rz_hole;
        mat_hole = trans_hole*rot_hole;
        mat_hole = mat_hole*base_matrix;

        peg_axialVector = -1*mat_peg(1:3,2);
        hole_axialVector = mat_hole(1:3,2);
        
        alignmentError = ComputeAlignmentError(peg_axialVector, hole_axialVector);
        AllData(i,1) = alignmentError;
    end
    
    Error(counter,1) = min(AllData(:,1));
    disp(Error(counter,1));
end

save(outputMatFile, 'Error');

close('all');