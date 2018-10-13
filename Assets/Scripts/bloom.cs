using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino.Examples;
using UnityEngine.PostProcessing;

public class bloom : MonoBehaviour {

	// Use this for initialization
	public float bloomIntensity;
	float pot4Input;
	public float pot4Value;
	public int size = 715;
	public PostProcessingProfile ppProfile;


	void Start () {
		var bloom = ppProfile.bloom.settings;	


	}
	
	void Update () {

		pot4Input = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA3;

		pot4Value = pot4Input/102.3f;

		//transform.localScale = new Vector3(150 + pot1Value * size, 150 + pot1Value * size, 150 +pot1Value * size);


		var bloom = ppProfile.bloom.settings;
		bloom.bloom.intensity = pot4Value * bloomIntensity;
		ppProfile.bloom.settings = bloom;

		//transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
	}
}
