
using UnityEngine;
using System.Collections;
using Uniduino;

#if (UNITY_3_0 || UNITY_3_0_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5)		
public class AnalogRead : Uniduino.Examples.AnalogRead { } // for unity 3.x
#endif

namespace Uniduino.Examples
{
	
	public class AnalogReadPots : MonoBehaviour {
		
		public Arduino arduino;
		
		private GameObject cube;
		
		public int pinA0 = 0;

		/*
		public int pinA1 = 1;
		public int pinA2 = 2;
		public int pinA3 = 3;
		public int pinA4 = 4;
		*/

		public int pinValueA0;

		/*public int pinValueA1;
		public int pinValueA2;
		public int pinValueA3;
		public int pinValueA4;
		*/

		void Start () {
		
			arduino = Arduino.global;
			arduino.Log = (s) => Debug.Log("Arduino: " +s);
			arduino.Setup(ConfigurePins);
			
		}
		
		void ConfigurePins( )
		{
			arduino.pinMode(pinA0, PinMode.ANALOG);

			/*arduino.pinMode(pinA1, PinMode.ANALOG);
			arduino.pinMode(pinA2, PinMode.ANALOG);
			arduino.pinMode(pinA3, PinMode.ANALOG);
			arduino.pinMode(pinA4, PinMode.ANALOG);
			*/


			arduino.reportAnalog(pinA0, 1);

			/*
			arduino.reportAnalog(pinA1, 1);
			arduino.reportAnalog(pinA2, 1);
			arduino.reportAnalog(pinA3, 1);
			arduino.reportAnalog(pinA4, 1);
			*/
		}
		
		void Update () {
			
			pinValueA0 = arduino.analogRead(pinA0);

			/*
			pinValueA1 = arduino.analogRead(pinA1);
			pinValueA2 = arduino.analogRead(pinA2);
			pinValueA3 = arduino.analogRead(pinA3);
			pinValueA4 = arduino.analogRead(pinA4);
			*/


			print (pinValueA0);

			/*
			print (pinValueA1);
			print (pinValueA2);
			print (pinValueA3);
			print (pinValueA4);
			*/
		}
	}
}


