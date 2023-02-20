function ComputeSpeedAccel(figFileName, fileName, sheetNum)
% function ComputeSpeedAccel(speedMatFileName, accelMatFileName, figFileName, fileName, sheetNum)

data = readmatrix(fileName,'Sheet',sheetNum);

dataLen = length(data(:,1));
time = data(:,1);
% pos = data(:,2:4);
pos = data(:,44:46);

speed = zeros(dataLen,2);
% accel = zeros(dataLen,2);

for i = 201:dataLen
    movX = pos(i,1) - pos(i-200,1);
    movY = pos(i,2) - pos(i-200,2);
    movZ = pos(i,3) - pos(i-200,3);
    
    timeDiff = time(i,1) - time(i-200,1);
    
    velX = movX./timeDiff;
    velY = movY./timeDiff;
    velZ = movZ./timeDiff;
    
    norm_speed = (velX^2) + (velY^2) + (velZ^2);    
    speed(i,2) = sqrt(norm_speed);
    
%     accelX = velX./timeDiff;
%     accelY = velY./timeDiff;
%     accelZ = velZ./timeDiff;
%     
%     norm_accel = (accelX^2) + (accelY^2) + (accelZ^2);    
%     accel(i,2) = sqrt(norm_accel);   
    
end
speed(i,1) = 0;
speed(:,1) = time;
% save(speedMatFileName,'speed');

% accel(i,1) = 0;
% accel(:,1) = time;
% save(accelMatFileName,'accel');

clf;
figure;
% subplot(1,2,1)
plot(speed(:,1),speed(:,2), 'LineWidth',2);
ylim([0 60]);
xlabel('Time in seconds');
ylabel('Speed in cm/s');
% subplot(1,2,2)
% plot(accel(:,1),accel(:,2));
% xlabel('Time in seconds');
% ylabel('Accel in cm/s^2');
saveas(gcf,figFileName);
    
    
    
    
    