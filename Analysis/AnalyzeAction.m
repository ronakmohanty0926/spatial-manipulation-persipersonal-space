function [changePts, initChangePts, new_idx] = AnalyzeAction(cumKE, time, maxNumChng, threshold)

% Initial guess of change points
[idx] = findchangepts(cumKE,'Statistic','linear','MaxNumChanges',maxNumChng);
ke = cumKE(idx);
tm = time(idx);
changeLen = length(idx);

% Refine the point set
shouldIKeep = false(changeLen,1);
shouldIKeep(1) = true;
shouldIKeep(end) = true;
% count = 1;
for i = 2:changeLen-1
    p1 = [tm(i-1), ke(i-1)];
    p2 = [tm(i), ke(i)];
    p3 = [tm(i+1), ke(i+1)];
    v1 = (p2-p1)./norm(p2-p1);
    v2 = (p3-p2)./norm(p3-p2);
    disp(dot(v1,v2)-1);
    if(abs(dot(v1,v2)-1) > threshold)
        shouldIKeep(i) = true;
    end
end

initChangePts(:,1) = tm;
initChangePts(:,2) = ke;
changePts(:,1) = tm(find(shouldIKeep));
changePts(:,2) = ke(find(shouldIKeep));
new_idx = idx(find(shouldIKeep));