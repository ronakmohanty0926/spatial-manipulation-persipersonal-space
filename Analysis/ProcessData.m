function ProcessData(Output_FName, Shape)
% function ProcessData(pegfName, holefName, headfName, RWfName, LWfName, REfName, LEfName, RSfName, LSfName, Shape)

fileList = CreateFileList(Shape);
dataLen = length(fileList);
count = 0;

while(1)
    pegData = [];
    holeData = [];
    headData = [];
    rwData = [];
    AllData = [];
    AllData = [];
    leData = [];
    AllData = [];
    AllData = [];
    
    count = count + 1;
    if (count > dataLen)
        break;
    end    
    
    fileID = fopen(fileList(count),'r');
    disp(fileList(count));
    
    elapsedTime = {};
    pegPos = {};    
    pegAng = {};
    holeAng = {};
    holePos = {};
    headPos = {};
    headAng = {};
    rightWristPos = {};
    rightWristAng = {};
    leftWristPos = {};
    leftWristAng = {};
    rightElbowPos = {};
    rightElbowAng = {};
    leftElbowPos = {};
    leftElbowAng = {};
    rightShoulderPos = {};
    rightShoulderAng = {};
    leftShoulderPos = {};
    leftShoulderAng = {};   
    
    lineCount = 0;    
    while ~feof(fileID)        
        lineCount = lineCount + 1;
        tline = textscan(fileID, '%f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f %f');
        elapsedTime(lineCount,:) = tline(:,1);
        pegPos(lineCount,:) = tline(:,2:4);
        pegAng(lineCount,:) = tline(:,5:7);
        holePos(lineCount,:) = tline(:,8:10);        
        holeAng(lineCount,:) = tline(:,11:13);
        headPos(lineCount,:) = tline(:,14:16);
        headAng(lineCount,:) = tline(:,17:19);
        rightWristPos(lineCount,:) = tline(:,20:22);
        rightWristAng(lineCount,:) = tline(:,23:25);
        leftWristPos(lineCount,:) = tline(:,26:28);
        leftWristAng(lineCount,:) = tline(:,29:31);
        rightElbowPos(lineCount,:) = tline(:,32:34);
        rightElbowAng(lineCount,:) = tline(:,35:37);
        leftElbowPos(lineCount,:) = tline(:,38:40);
        leftElbowAng(lineCount,:) = tline(:,41:43);
        rightShoulderPos(lineCount,:) = tline(:,44:46);
        rightShoulderAng(lineCount,:) = tline(:,47:49);
        leftShoulderPos(lineCount,:) = tline(:,50:52);
        leftShoulderAng(lineCount,:) = tline(:,53:55);
    end    
    
    AllData = [];
    elapsedTime = cell2mat(elapsedTime);    
    pegPos = cell2mat(pegPos);
    pegAng = cell2mat(pegAng);
    AllData(:,1) = elapsedTime;
    AllData(:,2:4) = pegPos;
    AllData(:,5:7) = pegAng;
    
    holePos = cell2mat(holePos);    
    holeAng = cell2mat(holeAng);
    AllData(:,8:10) = holePos;
    AllData(:,11:13) = holeAng;
    
    headPos = cell2mat(headPos);
    headAng = cell2mat(headAng);
    AllData(:,14:16) = headPos;
    AllData(:,17:19) = headAng;
    
    rightWristPos = cell2mat(rightWristPos);
    rightWristAng = cell2mat(rightWristAng);
    AllData(:,20:22) = rightWristPos;
    AllData(:,23:25) = rightWristAng;
    
    leftWristPos = cell2mat(leftWristPos);
    leftWristAng = cell2mat(leftWristAng);
    AllData(:,26:28) = leftWristPos;
    AllData(:,29:31) = leftWristAng;
    
    rightElbowPos = cell2mat(rightElbowPos);
    rightElbowAng = cell2mat(rightElbowAng);
    AllData(:,32:34) = rightElbowPos;
    AllData(:,35:37) = rightElbowAng;
    
    leftElbowPos = cell2mat(leftElbowPos);
    leftElbowAng = cell2mat(leftElbowAng);
    AllData(:,38:40) = leftElbowPos;
    AllData(:,41:43) = leftElbowAng;
    
    rightShoulderPos = cell2mat(rightShoulderPos);
    rightShoulderAng = cell2mat(rightShoulderAng);
    AllData(:,44:46) = rightShoulderPos;
    AllData(:,47:49) = rightShoulderAng;
    
    leftShoulderPos = cell2mat(leftShoulderPos);
    leftShoulderAng = cell2mat(leftShoulderAng);
    AllData(:,50:52) = leftShoulderPos;
    AllData(:,53:55) = leftShoulderAng;
    writematrix(AllData, Output_FName,'Sheet',count); 
    
    fclose('all');
end