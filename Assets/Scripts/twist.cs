using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino.Examples;

public class twist : MonoBehaviour {

	// Use this for initialization

	float pot3Input;
	public float pot3Value;

	int blendShapeCount;
	SkinnedMeshRenderer skinnedMeshRenderer;
	Mesh skinnedMesh;
	public float blendShape;

	void Awake ()
	{
		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
	}

	void Start () {

		//blendShapeCount = skinnedMesh.blendShapeCount; 

	}
	
	void Update () {

		pot3Input = GameObject.Find("Analog Read").GetComponent<AnalogReadPots>().pinValueA2;

		pot3Value = pot3Input/102.3f;

		blendShape = pot3Value * 6.5f; 


		skinnedMeshRenderer.SetBlendShapeWeight (0, blendShape);


		//print ("pot Value " + pot3Value);

	}
}
