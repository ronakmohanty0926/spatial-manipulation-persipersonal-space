clc;
% clear;
% 
% load 'Raw_Cylinder.mat';

[C_T, C_Tr, C_Tp, time] = ComputeKineticEnergy(data, 'smallShaftKey');
% C_T = C_T./1.0e4; %milliJoules

% rawCrv = [time,C_T];
% crv = curvspace(rawCrv,500);
% ke = crv(:,2);
% tm = crv(:,1);

% ke = C_T(1:50:end);
% tm = time(1:50:end);

% We sub-sample
% sampRate = 50;
% [ke,tm] = resample(C_T,time,sampRate);

% We use isChange
% [TF,slopes] = ischange(C_T,'linear','MaxNumChanges',4);
% changePts = C_T(find(TF));
% changeTime = time(find(TF));

% [idx] = findchangepts(C_T,'Statistic','linear','MaxNumChanges',10);
% changePts = C_T(idx);
% changeTime = time(idx);

[changePts, initChangePts, idx] = AnalyzeAction(C_T, time, 10, 1.0e-2);

% curvePts = zeros(length(changePts)+2,2);
% curvePts(1,2) = C_T(1,1);
% curvePts(1,1) = time(1,1);
% curvePts(end,2) = C_T(end,1);
% curvePts(end,1) = time(end,1);
% curvePts(2:(end-1),:) = changePts;

% for i = 2:length(curvePts)
%     slope(i-1,1) = ComputeSlope(curvePts(i-1,1),curvePts(i,1),curvePts(i-1,2),curvePts(i,2));
% end
% 
% [N, edges, bin] = histcounts(slope, 2);

figure;
hold on;
plot(time, C_T,'LineWidth', 2);
% plot(tm,ke,'.k');
plot(initChangePts(:,1),initChangePts(:,2),'ok', 'MarkerSize', 8, 'MarkerFaceColor', 'k');
plot(changePts(:,1),changePts(:,2),'or', 'MarkerSize', 8, 'MarkerFaceColor', 'r');
saveas(gcf,'KEAnalysis_SK2.emf');
% plot(curvePts(:,1),curvePts(:,2),'or');
% plot(changeTime,changePts,'or');
