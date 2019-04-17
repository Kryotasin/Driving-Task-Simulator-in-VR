%% Clear
clc;
clear;


%% Load the data file
 load('data/boyuan.mat');
 data = boyuan;
 
 %% Declare the variables
 
 frameNumber = [];
 
 gazeX = [];
 gazeY = [];
 gazeZ = [];
 
 handX = [];
 handY = [];
 handZ = [];
 
 targetNumber = 11;
 
 
 
 %% Read the data for the first object
 
for index =1:height(data)
    %if(data.TargetNumber(index) == targetNumber)
        frameNumber = [frameNumber, data.FrameNumber(index)];
        
        gazeX = [gazeX, data.GazeX(index)];
        gazeY = [gazeY, data.GazeY(index)];
        gazeZ = [gazeZ, data.GazeZ(index)];
        
        handX = [handX, data.HandX(index)];
        handY = [handY, data.HandY(index)];
        handZ = [handZ, data.HandZ(index)];
   % end
end

%% Plotting gaze

plot(frameNumber, gazeX);
%title('Target ' + targetNumber);

hold on;
plot(frameNumber, gazeY);
plot(frameNumber, gazeZ);
hold off;

%% Plotting Hand

figure;
plot(frameNumber, handX);
%title('Target ' + targetNumber);

hold on;
plot(frameNumber, handY);
plot(frameNumber, handZ);
hold off;


 