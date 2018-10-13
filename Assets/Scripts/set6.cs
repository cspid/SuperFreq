using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino.Examples;

public class set6 : MonoBehaviour {

	// Use this for initialization
	public float rotSpeed;
	float pot6Input;
	public float pot6Value;
	//public Camera cam;



	void Start () {

		//cam = GetComponent<Camera>();
		//cam.clearFlags = CameraClearFlags.SolidColor;


	}
	
	void Update () {

		pot6Input = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA5;

		pot6Value = pot6Input/102.3f;
		transform.localRotation =  Quaternion.Euler(90, 0, pot6Value * rotSpeed);

		//transform.localScale = new Vector3(0.2f + pot5Value * 0.4f, 0.2f + pot5Value * 0.4f, 0.2f +pot5Value * 0.4f);

		//Camera.main.GetComponent().<backgroundColor> = new Color(228f/255f,234f/255f,241f/255f,0f);
		//cam.backgroundColor = new Color(pot5Value, 1- pot5Value, pot5Value);

		//print ("pot Value " + pot5Value);

		//transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;s
	}
}
