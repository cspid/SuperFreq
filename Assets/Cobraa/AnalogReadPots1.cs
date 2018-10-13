
using UnityEngine;
using System.Collections;
using Uniduino;
using UnityEngine.UI;




#if (UNITY_3_0 || UNITY_3_0_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5)     
public class AnalogRead : Uniduino.Examples.AnalogRead { } // for unity 3.x
#endif

namespace Uniduino.Examples
{

    public class AnalogReadPots1 : MonoBehaviour
    {

        public bool usingArduino;
        public Arduino arduino;

        int pinA14 = 0;
        int pinA15 = 1;
        int pinA16 = 2;
        int pinA17 = 3;
        int pinA18 = 4;
        int pinA19 = 5;
        int pin20 = 6;

        public int pinValueA14;
        public int pinValueA15;
        public int pinValueA16;
        public int pinValueA17;
        public int pinValueA18;
        public int pinValueA19;
        //public int pinValue6;

        public Text pot1;
        public Text pot2;
        public Text pot3;
        public Text pot4;
        public Text pot5;
        public Text pot6;

        void Start()
        {

            arduino = Arduino.global;
            arduino.Log = (s) => Debug.Log("Arduino: " + s);
            arduino.Setup(ConfigurePins);



            pot1.GetComponent<Text>();
            pot2.GetComponent<Text>();
            pot3.GetComponent<Text>();
            pot4.GetComponent<Text>();
            pot5.GetComponent<Text>();
            pot6.GetComponent<Text>();


        }

        void ConfigurePins()
        {
			arduino.pinMode(pinA14, PinMode.ANALOG);
            arduino.pinMode(pinA15, PinMode.ANALOG);
			arduino.pinMode(pinA16, PinMode.ANALOG);
			arduino.pinMode(pinA17, PinMode.ANALOG);
			arduino.pinMode(pinA18, PinMode.ANALOG);
			arduino.pinMode(pinA19, PinMode.ANALOG);
            //arduino.pinMode(pin6, PinMode.ANALOG);



			arduino.reportAnalog(pinA14, 1);
			arduino.reportAnalog(pinA15, 1);
			arduino.reportAnalog(pinA16, 1);
			arduino.reportAnalog(pinA17, 1);
			arduino.reportAnalog(pinA18, 1);
			arduino.reportAnalog(pinA19, 1);
            //arduino.reportAnalog(pin6, 1);

        }

        void Update()
        {

            if (usingArduino == true)
            {
				pinValueA14 = arduino.analogRead(pinA14);
				pinValueA15 = arduino.analogRead(pinA15);
				pinValueA16 = arduino.analogRead(pinA16);
				pinValueA17 = arduino.analogRead(pinA17);
				pinValueA18 = arduino.analogRead(pinA18);
				pinValueA19 = arduino.analogRead(pinA19);
                //pinValue6 = arduino.analogRead(pin6);
            }




			pot1.text = "Pot 1 - " + (pinValueA14 / 102.3);
            pot2.text = "Pot 2 - " + (pinValueA15 / 102.3);
			pot3.text = "Pot 3 - " + (pinValueA16 / 102.3);
			pot4.text = "Pot 4 - " + (pinValueA17 / 102.3);
			pot5.text = "Pot 5 - " + (pinValueA18 / 102.3);
			pot6.text = "Pot 6 - " + (pinValueA19 / 102.3);


            /*
            print ("0 " + pinValueA0 / 102.3);
            print ("1 " + pinValueA1 / 102.3);
            print ("2 " + pinValueA2 / 102.3);
            print ("3 " + pinValueA3 / 102.3);
            print ("4 " + pinValueA4 / 102.3);
            print ("5 " + pinValueA5 / 102.3);
            //print ("5 " + pinValue6);
*/
        }
    }
}


