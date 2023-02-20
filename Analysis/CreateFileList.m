function shapefileList = CreateFileList(Shape)

% tempfileList = dir(fullfile(pwd,Shape));
% tempfileList = {tempfileList.name};
% fileList = string(tempfileList);
% fileList = fileList';
% fileList = string(fileList);

tempfileList = dir(fullfile(pwd,'*FUser*'));
tempfileList = {tempfileList.name};
fileList = string(tempfileList);
fileList = fileList';

if strcmp(Shape,'smallCylinder')
    index = find(contains(fileList,'smallCylinder'));
elseif strcmp(Shape,'mediumCylinder')
    index = find(contains(fileList,'mediumCylinder'));    
elseif strcmp(Shape,'largeCylinder')
    index = find(contains(fileList,'largeCylinder'));
elseif strcmp(Shape,'smallShaftKey')
    index = find(contains(fileList,'smallShaftKey'));
elseif strcmp(Shape,'mediumShaftKey')
    index = find(contains(fileList,'mediumShaftKey'));
elseif strcmp(Shape,'largeShaftKey')
    index = find(contains(fileList,'largeShaftKey'));
elseif strcmp(Shape,'smallTwoPin')
    index = find(contains(fileList,'smallTwoPin'));
elseif strcmp(Shape,'mediumTwoPin')
    index = find(contains(fileList,'mediumTwoPin'));
elseif strcmp(Shape,'largeTwoPin')
    index = find(contains(fileList,'largeTwoPin'));
elseif strcmp(Shape,'smallThreePin')
    index = find(contains(fileList,'smallThreePin'));
elseif strcmp(Shape,'mediumThreePin')
    index = find(contains(fileList,'mediumThreePin'));
elseif strcmp(Shape,'largeThreePin')
    index = find(contains(fileList,'largeThreePin'));
else disp
end

shapefileList = fileList(index);
shapefileList = string(shapefileList);

end