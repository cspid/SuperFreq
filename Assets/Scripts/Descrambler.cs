using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Descrambler : MonoBehaviour {

	//public Sinewave sinewave;

	Color green = Color.green;
	Color red = Color.red;

	float knob1LerpVal;
	float knob2LerpVal;


	public AudioMixer echoMixer;   
    public AudioMixer flangeMixer;

	public WaveVisualizer waveVisualizer;

	public KnobControl knob1;
	public KnobControl knob2;
	public KnobControl knob3;
	public KnobControl knob4;
	public KnobControl knob5;
	public KnobControl knob6;

	float flangeDry;
	float flangeWet;

	float echoDry;
	float echoWet;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

        //Distortion (Audio Source 1)
        echoDry = knob2.potValue / 10f * 1.75f;                 //have the dry value ouvershoot 100%
		if (echoDry > 1) echoDry = 1 - (echoDry - 1);           //subtract the overshoot from 100%
		echoWet = -1 * (echoDry - 1);                           //Set wet to an inverse number to dry
		echoMixer.SetFloat("EchoDry", echoDry);
		echoMixer.SetFloat("EchoWet", echoWet);


		//Flange (Audio Source 2)
		flangeDry = knob1.potValue/10f * 1.25f;                 //have the flangedry value ouvershoot 100%
		if (flangeDry > 1) flangeDry = 1 - (flangeDry - 1);     //subtract the overshoot from 100%
		flangeWet = -1 * (flangeDry - 1);                       //Set flange wet to an inverse number to flangedry
		flangeMixer.SetFloat("FlangeDry", flangeDry);
		flangeMixer.SetFloat("FlangeWet", flangeWet);

		//print(knob1.potValue);

		//color knob 1
		if (flangeDry > 0.75) knob1LerpVal = (0.75f - flangeDry) * -4;  //set our color lerp to begin when range is within 25%
		waveVisualizer.waveformColor2 = Color.Lerp(red, green, knob1LerpVal);

		//color knob 2
        if (echoDry > 0.25) knob2LerpVal = (0.25f - echoDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor1 = Color.Lerp(red, green, knob2LerpVal);


	}
}
