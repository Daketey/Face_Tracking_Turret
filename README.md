# Face Tracking Turret 

Have fun with a turret that constantly points your face.

<p align="center">
  <img width="800" src="https://user-images.githubusercontent.com/66672417/85195445-3471f480-b2f0-11ea-888e-d7faa74ac315.jpg">
</p>

An Application made using Visual Studio 2019 to detect a human face and point the turret in the direction of the face, aditionally 
I ve added a PIR sensor as a switch to turn on the application whenever it detects a movement. Then the turret points to the human 
face whereever it goes in the region of video feed.


### Libraries used in this project:
> [Aforge.Video](http://www.aforgenet.com/)\
> [EmguCV](http://www.emgu.com/wiki/index.php/Main_Page) 


### Guide to setting things up

#### Setting up the code:
To start things up you ll have to make a windows forms application in Visual Studio under in .Net framework. Open the form's.Designer
file and copy paste the code under [Face_Detection.Designer.cs](https://github.com/Daketey/Face-tracker-turret/blob/master/Face_Detection.Designer.cs), then double click on your forms and upload the [Face_Detection.cs](https://github.com/Daketey/Face-tracker-turret/blob/master/Face_Detection.cs) . Set up the Arduino circuit as shown in the circuit diagram below, then past the [Turret_PIR sensor.ino](https://github.com/Daketey/Face-tracker-turret/blob/master/Turret_PIR%20sensor.ino) in Arduino IDE, then upload to the board. Click start on your visual studio Application and have fun playing with the turret.

#### What components do you need?
```
1.Arduino uno
2.PIR sensor
3.2X micro servos
4.Jumper cables
5.Breadboard
```
#### Setting up the forms:

After copying the designer file, this is what it should look like
<p align="center">
<img width="700" src="https://user-images.githubusercontent.com/66672417/85195828-528d2400-b2f3-11ea-9790-d1f5a4c37c0f.jpg">
</p>

#### Arduino Circuit
<p align="center">
<img width="388" src="https://user-images.githubusercontent.com/66672417/85195125-8d8c5900-b2ed-11ea-8075-63d86b731ca4.PNG">
</p>

Stick the 2 servo as shown in the initial [image](https://user-images.githubusercontent.com/66672417/85195445-3471f480-b2f0-11ea-888e-d7faa74ac315.jpg).
