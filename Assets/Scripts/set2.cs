using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino.Examples;

public class set2 : MonoBehaviour {

	// Use this for initialization

	float pot2Input;
	public float pot2Value;



	void Start () {



	}
	
	void Update () {

		pot2Input = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA1;

		pot2Value = pot2Input/102.3f;

		transform.localScale = new Vector3(0.2f + pot2Value * 0.4f, 0.2f + pot2Value * 0.4f, 0.2f +pot2Value * 0.4f);

		//print ("pot Value " + pot2Value);

		//transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;s
	}
}
