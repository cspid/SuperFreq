using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableArduino : MonoBehaviour {

	public KnobControl knob1;
	public KnobControl knob2;
	public KnobControl knob3;
	public KnobControl knob4;
	public KnobControl knob5;
	public KnobControl knob6;

	public Toggle toggle;

	public void Disable () {
		if (toggle.isOn == true)
		{
			knob1.useArduino = true;
			knob2.useArduino = true;
			knob3.useArduino = true;
			knob4.useArduino = true;
			knob5.useArduino = true;
			knob6.useArduino = true;

		} else {
			knob1.useArduino = false;
			knob2.useArduino = false;
			knob3.useArduino = false;
			knob4.useArduino = false;
			knob5.useArduino = false;
			knob6.useArduino = false;

		}
  
      
	}
}
