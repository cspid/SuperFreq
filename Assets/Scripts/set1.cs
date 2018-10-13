using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino.Examples;

public class set1 : MonoBehaviour {

	// Use this for initialization

	float pot1Input;
	public float pot1Value;
	public int size = 715;


	void Start () {
		


	}
	
	void Update () {

		pot1Input = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA0;

		pot1Value = pot1Input/102.3f;

		transform.localScale = new Vector3(150 + pot1Value * size, 150 + pot1Value * size, 150 +pot1Value * size);

		//print ("pot Value " + pot1Value);

		//transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
	}
}
