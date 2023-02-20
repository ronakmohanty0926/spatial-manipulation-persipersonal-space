function [alignmentOutputMatFile] = ComputeError(inputExcelFileName)
% function [alignmentError, mat_peg, mat_hole] = ComputeError(data)
% function [alignmentOutputMatFile, twistOutputMatFile] = ComputeError(inputExcelFileName)

sheets = sheetnames(inputExcelFileName);
sheetCount = size(sheets);
sheetCount = sheetCount(1,1);
counter = 0;
AllData = [];

while(1)
    counter = counter + 1;
    if (counter > sheetCount)
        break;
    end    
    
    data = readmatrix(inputExcelFileName,'Sheet',counter); 
    
    disp(sheets(counter,1));
    
    base_matrix = eye(4);
    
    pegAng = data(end-10,5:7);
    holeAng = data(end-10,11:13);
    
    PosX_peg = data(end-10,2);
    PosY_peg = data(end-10,3);
    PosZ_peg = -1.*data(end-10,4);
    
    Rx_peg = BasicRotationMatrix('X',360-pegAng(1,3));
    Ry_peg = BasicRotationMatrix('Y',360-pegAng(1,2));
    Rz_peg = BasicRotationMatrix('Z',360-pegAng(1,1));
    
    PosX_hole = data(end-10,8);
    PosY_hole = data(end-10,9);
    PosZ_hole = -1.*data(end-10,10);
    
    Rx_hole = BasicRotationMatrix('X',360-holeAng(1,3));
    Ry_hole = BasicRotationMatrix('Y',360-holeAng(1,2));
    Rz_hole = BasicRotationMatrix('Z',360-holeAng(1,1));
    
    trans_peg = BasicTranslationMatrix(PosX_peg, PosY_peg, PosZ_peg);
    rot_peg = Ry_peg*Rx_peg*Rz_peg;
%     mat_peg = rot_peg*trans_peg;
%     mat_peg = mat_peg*base_matrix;
    mat_peg = rot_peg*base_matrix;
    
    trans_hole = BasicTranslationMatrix(PosX_hole, PosY_hole, PosZ_hole);
    rot_hole = Ry_hole*Rx_hole*Rz_hole;
%     mat_hole = rot_hole*trans_hole;
%     mat_hole = mat_hole*base_matrix;
    mat_hole = rot_hole*base_matrix;
    
    peg_axialVector = -1*mat_peg(1:3,2);
    peg_axialVector = peg_axialVector./norm(peg_axialVector);
    hole_axialVector = mat_hole(1:3,2);
    hole_axialVector = hole_axialVector./norm(hole_axialVector);
    
    
    alignmentError = ComputeAlignmentError(peg_axialVector, hole_axialVector);
    AllData(counter,1) = alignmentError;
end

save(alignmentOutputMatFile,'AllData');

close('all');
    