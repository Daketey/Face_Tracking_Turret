#include<Servo.h>

int inputpin= 11;
int pirstate = LOW;
int pinvalue= 0;            //setting a pin value
Servo serX;
Servo serY;
String serialData;

void setup() {
  pinMode(inputpin, INPUT);     // declare sensor as input

  serX.attach(10);
  serY.attach(6);
  Serial.begin(9600);
  Serial.setTimeout(10);
  serX.write(140);             //Default position in x axis for servo
  serY.write(50);              //Default position in y axis for servo
}
 
void loop(){
   pinvalue= digitalRead(inputpin);   // read input value from input pin
   if (pinvalue == HIGH) {            // check if the input is HIGH      
    if (pirstate == LOW) {
      // we have just turned on
      Serial.println("1");
      Serial.write(1);
      pirstate = HIGH;
    }
  } else {    
    if (pirstate == HIGH){
      // we have just turned off
      Serial.println("0");
      Serial.write(0);
      pirstate = LOW;
    }
  }
}
void serialEvent() {
  serialData = Serial.readString();
  serX.write(parseDataX(serialData));
  serY.write(parseDataY(serialData));
}

int parseDataX(String data){
  data.remove(data.indexOf("Y"));
  data.remove(data.indexOf("X"), 1);
  return data.toInt();
}

int parseDataY(String data){
  data.remove(0,data.indexOf("Y") + 1);
  return data.toInt();
}
