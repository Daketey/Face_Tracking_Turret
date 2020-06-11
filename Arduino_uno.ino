int ledpin = 10;

void setup() 
{
  Serial.begin(9600);
  pinMode(ledpin, OUTPUT);
}

void loop() 
{
  if(Serial.read()=='Y')
   { digitalWrite(ledpin , HIGH);}
  if(Serial.read()=='N')  
    {digitalWrite(ledpin , LOW);
    }
 }
 
  
  


  
