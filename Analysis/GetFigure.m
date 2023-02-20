%specify columns for Errors
%comment out yLim for Time
function GetFigure(var1, var2, var3)
% function GetFigure(var1, var2, var3, y_limit, outputFileName, variant)
hb = figure;

a = length(var1);
b = length(var2);
c = length(var3);
% d = length(var4);


A = [a,b,c];
A = A';
A = sortrows(A);
rowlen = A(1,1);

positions = [0.05 0.075 0.1];
% positions = [0.1 0.125 0.15];
% positions = [0.1 0.15];

boxplot([var1(1:rowlen,1), var2(1:rowlen,1), var3(1:rowlen,1)],'positions',positions);
% ylim([0 10]);
% ylim([0 20]); % ChangePts
% ylim([0 75]); %Time
% ylim([0 0.03e4]); %KE

%set(gca,'Xtick',1:8,'XTickLabel',{'Thin-Convex', 'Thin-Concave', 'Fat-Convex', 'Fat-Concave', 'Flat1', 'Flat2', 'Flat3', 'Flat4'});
%set(gca,'Xtick',[1 1.25 1.5],'','','', ''); 
box off;

col = [
     186,228,179;
     116, 196, 118;     
     35, 139, 69;     
     
%      189,215,231;
%      107, 174, 214;
%      33, 113, 181;

    
%      253,204,138;
%      252, 141, 89;
%      215, 48, 31;
     
%      203,201,226;
%      158,154,200;
%      106,81,163;
     
    ];

% if strcmp(variant,'GS')
%     col = [
%      35, 139, 69;
%      116, 196, 118;
%      186,228,179;
%     ];
% elseif strcmp(variant, 'PR')
%       col = [
%      33, 113, 181;
%      107, 174, 214;
%      189,215,231;
%     ];
% elseif strcmp(variant, 'PV')
%       col = [
%      215, 48, 31;
%      252, 141, 89;
%      253,204,138;
%     ];
% end

col = col./255;
h = findobj(gca,'Tag','Box');
 for j=1:length(h)
    patch(get(h(j),'XData'),get(h(j),'YData'),col(j,:),'FaceAlpha',1.0);
 end
h = findobj(gca,'Tag','Median');
for j=1:length(h)
    line(get(h(j),'XData'),get(h(j),'YData'),'LineWidth',1.5,'Color','k');
end
h=findobj(gca,'Tag','Outliers');
set(h,'Marker','o');
set(h,'MarkerFaceColor',[0.75 0.75 0.75]);
set(h,'MarkerEdgeColor','k');

set(findobj(gcf,'LineStyle','--'),'LineStyle','-');
set(gcf,'renderer','painter');
% saveas(hb, outputFileName);
saveas(hb,'PathLen_Cylinder.emf');
% saveas(hb,'KE_GS_Cylinder.emf');
% saveas(hb,'nPts_GS_Shaftkey.emf');
clear hb;