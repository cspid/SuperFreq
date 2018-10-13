
using UnityEngine;
using System.Collections;
using Uniduino;
using UnityEngine.UI;




#if (UNITY_3_0 || UNITY_3_0_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5)		
public class AnalogRead : Uniduino.Examples.AnalogRead { } // for unity 3.x
#endif

namespace Uniduino.Examples
{
	
	public class AnalogReadPots : MonoBehaviour {
		
		public bool usingArduino;
		public Arduino arduino;

		 int pinA0 = 0;
		 int pinA1 = 1;
		 int pinA2 = 2;
		 int pinA3 = 3;
		 int pinA4 = 4;
		 int pinA5 = 5;
		// int pin6 = 6;

		public int pinValueA0;
		public int pinValueA1;
		public int pinValueA2;
		public int pinValueA3;
		public int pinValueA4;
		public int pinValueA5;
		//public int pinValueA6;

		public Text pot1;
		public Text pot2;
		public Text pot3;
		public Text pot4;
		public Text pot5;
		public Text pot6;

		void Start () {
		
			arduino = Arduino.global;
			arduino.Log = (s) => Debug.Log("Arduino: " +s);
			arduino.Setup(ConfigurePins);

		

			pot1.GetComponent<Text>();
			pot2.GetComponent<Text>();
			pot3.GetComponent<Text>();
			pot4.GetComponent<Text>();
			pot5.GetComponent<Text>();
			pot6.GetComponent<Text>();

			
		}
		
		void ConfigurePins( )
		{
			arduino.pinMode(pinA0, PinMode.ANALOG);
			arduino.pinMode(pinA1, PinMode.ANALOG);
			arduino.pinMode(pinA2, PinMode.ANALOG);
			arduino.pinMode(pinA3, PinMode.ANALOG);
			arduino.pinMode(pinA4, PinMode.ANALOG);
			arduino.pinMode(pinA5, PinMode.ANALOG);
			//arduino.pinMode(pin6, PinMode.ANALOG);



			arduino.reportAnalog(pinA0, 1);
			arduino.reportAnalog(pinA1, 1);
			arduino.reportAnalog(pinA2, 1);
			arduino.reportAnalog(pinA3, 1);
			arduino.reportAnalog(pinA4, 1);
			arduino.reportAnalog(pinA5, 1);
			//arduino.reportAnalog(pin6, 1);

		}
		
		void Update () {
            
		if (usingArduino == true){
			pinValueA0 = arduino.analogRead(pinA0);
			pinValueA1 = arduino.analogRead(pinA1);
			pinValueA2 = arduino.analogRead(pinA2);
			pinValueA3 = arduino.analogRead(pinA3);
			pinValueA4 = arduino.analogRead(pinA4);
			pinValueA5 = arduino.analogRead(pinA5);
			//pinValue6 = arduino.analogRead(pin6);
		}




			pot1.text = "Pot 1 - " + (pinValueA0 / 102.3);
			pot2.text = "Pot 2 - " + (pinValueA1 / 102.3);
			pot3.text = "Pot 3 - " + (pinValueA2 / 102.3);
			pot4.text = "Pot 4 - " + (pinValueA3 / 102.3);
			pot5.text = "Pot 5 - " + (pinValueA4 / 102.3);
			pot6.text = "Pot 6 - " + (pinValueA5 / 102.3);


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


