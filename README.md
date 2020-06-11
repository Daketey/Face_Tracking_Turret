# Face Detection using EmguCV and applying it to Arduino based electronics projects.

An application made using Visual Studio 2019 using Windows forms App to detect human face. Further along the line, I plan to integrate this 
application into my embeddded system/Robotics based projects to utilize it in many ways. Eye detection, facial recognition and other features are also in my plan. Currently I will be using ArduinoIDE for the electonics part and I plan on making a turret for now which might further develop onto other things as this project goes on.

Currently the libraries used are:
1. Aforge.Video (for taking video feed from my computer)
2. EmguCV 

(All libararies and packages were downlaoded using NuGet)

UPDATE:

1.Added eye detection feature.

2.Added code for arduino led blinking, which works by reciving serial input from the Face Detector.

2.Added serial port input in the main application code for sending serial data to arudino.
