% function [efficiencyPeg, efficiencyHole, pathPeg, pathHole] = BatchProcess(Shape, nIterations)
function [pathdevPeg, patheffPeg, totalPegPath] = PathAnalysis(data)

dataLen = length(data(:,1));

time = data(:,1);
pegData = data(:,2:7);

% The angle data should be in the -180 to +180 range
for m = 4 : 6
    bigAngle = pegData(:,m) > 180;
    pegData(bigAngle,m) = pegData(bigAngle,m) - 360;
end

% Filter Data
fs = 1/(time(2)-time(1)); % source frequency
fc = 10;  % cutoff frequency
order = 6; % filter order
[b,a] = butter(order,fc/(fs/2));

f_pegData =  filtfilt(b,a,pegData);
pegPos = f_pegData(:,1:3);
    
% straightLineVec = zeros(dataLen,3);
% orthogonalProj = zeros(dataLen,1);
    
straightLineVec = pegPos(end,:) - pegPos(1,:);
straightLineMag = norm(straightLineVec);
    
orthogonalProj = zeros(dataLen,3);
temp = zeros(dataLen,3);

for i = 1:dataLen
    temp(i,:) = pegPos(i,:) - pegPos(1,:);        
    orthogonalProj(i,:) = (dot(pegPos(i,:),straightLineVec)./straightLineMag).*straightLineVec;
end

orthogonalProjMag = sqrt(orthogonalProj(:,1).^2 + orthogonalProj(:,2).^2 + orthogonalProj(:,3).^2);
orthogonalProjMag = sum(orthogonalProjMag);
nPts = length(pegPos);
invnPts = 1./nPts;
pathdevPeg = invnPts.*orthogonalProjMag;
    
%     temp = zeros(length(pegPos),3);
%     for i = 1:1:length(pegPos)
%         temp(i,:) = pegPos(i,:) - pegPos(1,:);
%         orthogonalProj(i,:) = norm(cross(temp(i,:),straightLineVec));
%     end
%    
%     nPts = length(pegPos);
%     invnPts = 1./nPts;
%    pathdevPeg(len,1) = invnPts.*(sum(orthogonalProj)./straightLineMag);
   
diffPeg = diff(pegPos);    
pathPeg = sqrt(diffPeg(:,1).^2 + diffPeg(:,2).^2 + diffPeg(:,3).^2);
totalPegPath = sum(pathPeg);

patheffPeg = totalPegPath./straightLineMag;
    
% fclose('all')

end

