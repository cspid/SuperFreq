using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableArduino : MonoBehaviour {

	public KnobControl knob1;
	public KnobControl knob2;
	public KnobControl knob3;
	public KnobControl knob4;
	public KnobControl knob5;
	public KnobControl knob6;

	bool isClicked;

	public void Disable () {
		if (knob1.useArduino == true)
		{
			knob1.useArduino = false;
		} else {
			knob1.useArduino = true;
		}

		if (knob2.useArduino == true)
        {
            knob2.useArduino = false;
        }
        else
        {
            knob2.useArduino = true;
        }

		if (knob3.useArduino == true)
        {
            knob3.useArduino = false;
        }
        else
        {
			knob3.useArduino = true;
        }

		if (knob4.useArduino == true)
        {
			knob4.useArduino = false;
        }
        else
        {
			knob4.useArduino = true;
        }

		if (knob5.useArduino == true)
        {
			knob5.useArduino = false;
        }
        else
        {
			knob5.useArduino = true;
        }

		if (knob6.useArduino == true)
        {
			knob6.useArduino = false;
        }
        else
        {
            knob6.useArduino = true;
        }
      
	}
}
