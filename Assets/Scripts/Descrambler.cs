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

	public AudioClip Mundane1;
	public AudioClip Mundane2;
	public AudioClip Mundane3;
	public AudioClip Mundane4;
	public AudioClip Distress;

	float flangeDry;
	float flangeWet;

	float echoDry;
	float echoWet;

	// Use this for initialization
	void Start () {
	}


	private void Update()
	{
		if (knob3.potValue < 2) Signal1();
		

		if (knob3.potValue < 4 && knob3.potValue > 2) Signal2();
        

		if (knob3.potValue < 6 && knob3.potValue > 4) Signal3();
        
        
		if (knob3.potValue < 8 && knob3.potValue > 6) Signal4(); 
        

		if (knob3.potValue > 8) Signal5();
        
	}
	// Update is called once per frame
	void Signal1 () {
		//Set the Clip
		waveVisualizer.audio1.clip = Mundane1;
		waveVisualizer.audio2.clip = Mundane1;

		if (waveVisualizer.audio1.isPlaying == false) waveVisualizer.audio1.Play();
        if (waveVisualizer.audio2.isPlaying == false) waveVisualizer.audio2.Play();

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
    
	void Signal2()
	{
		waveVisualizer.audio1.clip = Mundane2;
		waveVisualizer.audio2.clip = Mundane2;
		if (waveVisualizer.audio1.isPlaying == false) waveVisualizer.audio1.Play();
		if (waveVisualizer.audio2.isPlaying == false) waveVisualizer.audio2.Play();

        //Distortion (Audio Source 1)
        echoDry = knob2.potValue / 10f * 1.50f;                 //have the dry value ouvershoot 100%
        if (echoDry > 1) echoDry = 1 - (echoDry - 1);           //subtract the overshoot from 100%
        echoWet = -1 * (echoDry - 1);                           //Set wet to an inverse number to dry
        echoMixer.SetFloat("EchoDry", echoDry);
        echoMixer.SetFloat("EchoWet", echoWet);


        //Flange (Audio Source 2)
        flangeDry = knob1.potValue / 10f * 1.75f;               //have the flangedry value ouvershoot 100%
        if (flangeDry > 1) flangeDry = 1 - (flangeDry - 1);     //subtract the overshoot from 100%
        flangeWet = -1 * (flangeDry - 1);                       //Set flange wet to an inverse number to flangedry
        flangeMixer.SetFloat("FlangeDry", flangeDry);
        flangeMixer.SetFloat("FlangeWet", flangeWet);

        //print(knob1.potValue);

        //color knob 1
        if (flangeDry > 0.50) knob1LerpVal = (0.50f - flangeDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor2 = Color.Lerp(red, green, knob1LerpVal);

        //color knob 2
        if (echoDry > 0.75) knob2LerpVal = (0.75f - echoDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor1 = Color.Lerp(red, green, knob2LerpVal);
	}

	void Signal3()
    {
		waveVisualizer.audio1.clip = Mundane4;
		waveVisualizer.audio2.clip = Mundane4;
		if (waveVisualizer.audio1.isPlaying == false) waveVisualizer.audio1.Play();
        if (waveVisualizer.audio2.isPlaying == false) waveVisualizer.audio2.Play();

        //Distortion (Audio Source 1)
        echoDry = knob2.potValue / 10f * 1.25f;                 //have the dry value ouvershoot 100%
        if (echoDry > 1) echoDry = 1 - (echoDry - 1);           //subtract the overshoot from 100%
        echoWet = -1 * (echoDry - 1);                           //Set wet to an inverse number to dry
        echoMixer.SetFloat("EchoDry", echoDry);
        echoMixer.SetFloat("EchoWet", echoWet);


        //Flange (Audio Source 2)
        flangeDry = knob1.potValue / 10f * 1.50f;               //have the flangedry value ouvershoot 100%
        if (flangeDry > 1) flangeDry = 1 - (flangeDry - 1);     //subtract the overshoot from 100%
        flangeWet = -1 * (flangeDry - 1);                       //Set flange wet to an inverse number to flangedry
        flangeMixer.SetFloat("FlangeDry", flangeDry);
        flangeMixer.SetFloat("FlangeWet", flangeWet);

        //print(knob1.potValue);

        //color knob 1
        if (flangeDry > 0.25) knob1LerpVal = (0.25f - flangeDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor2 = Color.Lerp(red, green, knob1LerpVal);

        //color knob 2
        if (echoDry > 0.50) knob2LerpVal = (0.50f - echoDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor1 = Color.Lerp(red, green, knob2LerpVal);
    }

	void Signal4()
    {
		waveVisualizer.audio1.clip = Distress;
        waveVisualizer.audio2.clip = Distress;
		if (waveVisualizer.audio1.isPlaying == false) waveVisualizer.audio1.Play();
        if (waveVisualizer.audio2.isPlaying == false) waveVisualizer.audio2.Play();

        //Distortion (Audio Source 1)
        echoDry = knob2.potValue / 10f * 1.50f;                 //have the dry value ouvershoot 100%
        if (echoDry > 1) echoDry = 1 - (echoDry - 1);           //subtract the overshoot from 100%
        echoWet = -1 * (echoDry - 1);                           //Set wet to an inverse number to dry
        echoMixer.SetFloat("EchoDry", echoDry);
        echoMixer.SetFloat("EchoWet", echoWet);


        //Flange (Audio Source 2)
        flangeDry = knob1.potValue / 10f * 1.25f;               //have the flangedry value ouvershoot 100%
        if (flangeDry > 1) flangeDry = 1 - (flangeDry - 1);     //subtract the overshoot from 100%
        flangeWet = -1 * (flangeDry - 1);                       //Set flange wet to an inverse number to flangedry
        flangeMixer.SetFloat("FlangeDry", flangeDry);
        flangeMixer.SetFloat("FlangeWet", flangeWet);

        //print(knob1.potValue);

        //color knob 1
        if (flangeDry > 0.50) knob1LerpVal = (0.50f - flangeDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor2 = Color.Lerp(red, green, knob1LerpVal);

        //color knob 2
        if (echoDry > 0.25) knob2LerpVal = (0.25f - echoDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor1 = Color.Lerp(red, green, knob2LerpVal);
    }

	void Signal5()
    {
		waveVisualizer.audio1.clip = Mundane3;
        waveVisualizer.audio2.clip = Mundane3;
		if (waveVisualizer.audio1.isPlaying == false) waveVisualizer.audio1.Play();
        if (waveVisualizer.audio2.isPlaying == false) waveVisualizer.audio2.Play();

        //Distortion (Audio Source 1)
        echoDry = knob2.potValue / 10f * 1.10f;                 //have the dry value ouvershoot 100%
        if (echoDry > 1) echoDry = 1 - (echoDry - 1);           //subtract the overshoot from 100%
        echoWet = -1 * (echoDry - 1);                           //Set wet to an inverse number to dry
        echoMixer.SetFloat("EchoDry", echoDry);
        echoMixer.SetFloat("EchoWet", echoWet);


        //Flange (Audio Source 2)
        flangeDry = knob1.potValue / 10f * 1.50f;               //have the flangedry value ouvershoot 100%
        if (flangeDry > 1) flangeDry = 1 - (flangeDry - 1);     //subtract the overshoot from 100%
        flangeWet = -1 * (flangeDry - 1);                       //Set flange wet to an inverse number to flangedry
        flangeMixer.SetFloat("FlangeDry", flangeDry);
        flangeMixer.SetFloat("FlangeWet", flangeWet);

        //print(knob1.potValue);

        //color knob 1
        if (flangeDry > 0.10) knob1LerpVal = (0.10f - flangeDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor2 = Color.Lerp(red, green, knob1LerpVal);

        //color knob 2
        if (echoDry > 0.50) knob2LerpVal = (0.50f - echoDry) * -4;  //set our color lerp to begin when range is within 25%
        waveVisualizer.waveformColor1 = Color.Lerp(red, green, knob2LerpVal);
    }
}
