close all; clear; clc;

%% read data
time = csvread('time.csv');
counts = csvread('counts.csv');
velocities = csvread('Velocity.csv');
sights = csvread('Size.csv');
sizes = csvread('SenseRadius.csv');

%% Convert 0 to NaN
velocities(velocities == 0) = NaN;
sights(sights == 0) = NaN;
sizes(sizes == 0) = NaN;

%% Max, min, and avg
maxV = max(velocities, [], 2, 'omitnan');
minV = min(velocities, [], 2, 'omitnan');
avgV = mean(velocities, 2, 'omitnan');

maxSt = max(sights, [], 2, 'omitnan');
minSt = min(sights, [], 2, 'omitnan');
avgSt = mean(sights, 2, 'omitnan');

maxSz = max(sizes, [], 2, 'omitnan');
minSz = min(sizes, [], 2, 'omitnan');
avgSz = mean(sizes, 2, 'omitnan');

%% Plot count
figure()
subplot(2, 2, 1);
hold on;
grid on;
plot(time, counts);
title('Population');
xlabel('Time');
ylabel('Number of creatures');

%% Velocity plot
subplot(2, 2, 2);
hold on;
grid on;
plot(time, avgV);
plot(time, maxV);
plot(time, minV);

title('Velocity');
xlabel('Time');
ylabel('Velocity');

%% Sightplot
subplot(2, 2, 3);
hold on;
grid on;
plot(time, avgSt);
plot(time, maxSt);
plot(time, minSt);

title('Sight radius');
xlabel('Time');
ylabel('Sight radius');

%% Sizeplot
subplot(2, 2, 4)
hold on;
grid on;
plot(time, avgSz);
plot(time, maxSz);
plot(time, minSz);

title('Size');
xlabel('Time');
ylabel('Size');