using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uniduino.Examples;

public class KnobControl : MonoBehaviour
{
    
    public bool useArduino = true;
	public Slider slider;
	float potInput;
    public float potValue;
	int knob;
	float yVal = -270;
	float xVal;
	float zVal = 90;




    
    void Start()
    {
		if (gameObject.name == "Knob 1") knob = 1;
		if (gameObject.name == "Knob 2") knob = 2;
		if (gameObject.name == "Knob 3") knob = 3;
		if (gameObject.name == "Knob 4") knob = 4;
		if (gameObject.name == "Knob 5") knob = 5;
		if (gameObject.name == "Knob 6") knob = 6;

		slider.minValue = 0;
		slider.maxValue = 10;



    }

	void Update()
	{
		if (useArduino == true)
		{
			if (knob == 1) potInput = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA0;
			if (knob == 2) potInput = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA1;
			if (knob == 3) potInput = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA2;
			if (knob == 4) potInput = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA3;
			if (knob == 5) potInput = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA4;
			if (knob == 6) potInput = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA5;

			potValue = potInput / 102.3f;         
		} else {
			//Ignore arduino, use sliders
			UseSlider();
	}
       


		xVal = -60 + potValue * 30;

		transform.localRotation = Quaternion.Euler(xVal, yVal, zVal);

	}

	void UseSlider(){
		print("test");
		potValue = slider.value;
	}
}
