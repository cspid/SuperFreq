using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino.Examples;

public class set5 : MonoBehaviour {

	// Use this for initialization

	float pot5Input;
	public float pot5Value;
	public Camera cam;



	void Start () {

		cam = GetComponent<Camera>();
		cam.clearFlags = CameraClearFlags.SolidColor;


	}
	
	void Update () {

		pot5Input = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA4;

		pot5Value = pot5Input/1023f;

		//transform.localScale = new Vector3(0.2f + pot5Value * 0.4f, 0.2f + pot5Value * 0.4f, 0.2f +pot5Value * 0.4f);

		//Camera.main.GetComponent().<backgroundColor> = new Color(228f/255f,234f/255f,241f/255f,0f);
		cam.backgroundColor = new Color(pot5Value, 1- pot5Value, pot5Value);

		//print ("pot Value " + pot5Value);

		//transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;s
	}
}
