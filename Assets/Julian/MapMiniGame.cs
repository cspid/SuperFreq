using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMiniGame : MonoBehaviour {

    public GameObject Tower1;
    public GameObject Tower2;
    public GameObject Tower3;
    public GameObject Signal1GO;
    public GameObject Signal2GO;
    public GameObject Signal3GO;

    public GameObject XMark;
    public RectTransform CircleFinder;

    public KnobControl knob1;
    public KnobControl knob2;
    public KnobControl knob3;
    public KnobControl knob4;
    public KnobControl knob5;
    public KnobControl knob6;

    private Vector3 signal1;
    private Vector3 signal2;
    private Vector3 signal3;

    


    

    private float knob1float;
    private float knob2float;
    private float knob3float;
    private float knob4float;
    private float knob5float;
    private float knob6float;



    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {

        knob1.slider.minValue = -10;
        knob1.slider.maxValue = 10;

        knob2.slider.minValue = -10;
        knob2.slider.maxValue = 10;
        CircleFinder.anchoredPosition3D =  new Vector3( knob1float*25, knob2float*25, CircleFinder.anchoredPosition3D.z);


        RadioTowerSignals();
        
    }

    void RadioTowerSignals()
    {
        knob1float = knob1.potValue / 5;
        knob2float = knob2.potValue / 5;
        knob3float = knob3.potValue / 5;
        knob4float = knob4.potValue / 5;
        knob5float = knob5.potValue / 5;
        knob6float = knob6.potValue / 5;

        signal1.x = knob3float;
        signal1.y = knob3float * 2;

        signal2.x = knob4float;
        signal2.y = knob4float * 2;

        signal3.x = knob5float;
        signal3.y = knob5float * 2;

        Signal1GO.transform.localScale = signal1;
        Signal2GO.transform.localScale = signal2;
        Signal3GO.transform.localScale = signal3;
    }
}
