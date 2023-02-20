function [nPts] = SegmentKineticEnergy(kineticEnergy, time)
% function [nPts, idx] = SegmentKineticEnergy(kineticEnergy, time)

thresh_val = 50000;
method = 'linear'; % detect change in slope
[logic_array, slope] = ischange(kineticEnergy, method, 'Threshold', thresh_val);

slope_difference = zeros(length(slope),1);
for i = 2:length(slope)
    slope_difference(i,1) = slope(i,1) - slope(i-1,1);
end

temp_count = 0;
slope_thresh = 1000;
temp_idx = [];
for i = 1:length(slope_difference)
    if (abs(slope_difference(i,1)) > slope_thresh)
        temp_count = temp_count + 1;
        temp_idx(temp_count,1) = i;
    end
end

count = 0;
nPts = 0;
% idx = [];

for i = 2:length(temp_idx)
    temp = temp_idx(i,1) - temp_idx(i-1,1);
    if (temp > 10)
        count = count + 1;
        nPts = count + 1;
        idx(nPts,1) = temp_idx(i,1);
    end
end
idx(1,1) = temp_idx(1,1);


figure
hold on
plot(time, kineticEnergy)
for i = 1:length(idx)
scatter(time(idx(i,1),1),kineticEnergy(idx(i,1),1));
end