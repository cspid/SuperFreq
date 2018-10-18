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

    public Sprite CircleBlack;
    public Sprite CircleRed;

    private Vector3 signal1;
    private Vector3 signal2;
    private Vector3 signal3;


    private float knob1float;
    private float knob2float;
    private float knob3float;
    private float knob4float;
    private float knob5float;
    private float knob6float;

    private bool tower1Found = false;
    private bool tower2Found = false;
    private bool tower3Found = false;

    private bool signal1Found = false;
    private bool signal2Found = false;
    private bool signal3Found = false;

    private AudioSource beep;
    private AudioClip beepClip;

    private float distanceBetween1;
    private float distanceBetween2;
    private float distanceBetween3;

    private bool playingBeep1 = true;
    private bool playingBeep2 = false;
    private bool playingBeep3 = false;

    // Use this for initialization
    void Start ()
    {
        beep = this.GetComponent<AudioSource>();
        beepClip = beep.clip;
        StartCoroutine(BeepSound());
    }
	
	// Update is called once per frame
	void Update () {

        /*knob1.slider.minValue = -10;
        knob1.slider.maxValue = 10;

        knob2.slider.minValue = -10; 
        knob2.slider.maxValue = 10;
        */
        CircleFinder.anchoredPosition3D =  new Vector3( knob1float*50, knob2float*50, CircleFinder.anchoredPosition3D.z);

        Beeping();
        FindTowers();
        FindSignalSize();
        RadioTowerSignals();

        
        
    }

    void RadioTowerSignals()
    {
        knob1float = knob1.potValue/5;
        knob2float = knob2.potValue/5;
        knob3float = knob3.potValue/5;
        knob4float = knob4.potValue/5;
        knob5float = knob5.potValue/5;
        knob6float = knob6.potValue/5;

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

    void FindTowers()
    {

        //Debug.Log(knob1float*5);
        //Debug.Log(knob2float*5);

        distanceBetween1 = Vector3.Distance(CircleFinder.position, Tower1.transform.position);
        distanceBetween2 = Vector3.Distance(CircleFinder.position, Tower2.transform.position);
        distanceBetween3 = Vector3.Distance(CircleFinder.position, Tower3.transform.position);


        if (((knob1float * 5 < 9.5f) && (knob1float * 5 > 8.5f)) && ((knob2float * 5 < 6.5f) && (knob2float * 5 > 5.5f)))
        {
            //Debug.Log("tower1");
            Tower1.SetActive(true);
            tower1Found = true;
            playingBeep1 = false;
            playingBeep2 = true;
        }

        if (tower1Found == true)
        {
            if (((knob1float * 5 < 4.0f) && (knob1float * 5 > 3.0f)) && ((knob2float * 5 > 2.0f) && (knob2float * 5 < 3.0f)))
            {
                //Debug.Log("tower2");
                Tower2.SetActive(true);
                tower2Found = true;
                playingBeep2 = false;
                playingBeep3 = true;
            }
        }
        if (tower2Found == true)
        {
            if (((knob1float * 5 < 2.0f) && (knob1float * 5 > 1.0f)) && ((knob2float * 5 > 8.5f) && (knob2float * 5 < 9.5f)))
            {
               // Debug.Log("tower3");
                Tower3.SetActive(true);
                tower3Found = true;
                playingBeep3 = false;
            }
        }
    }

    void FindSignalSize()
    {
        //Debug.Log(knob3float * 5);
        //Debug.Log(knob4float * 5);
        //Debug.Log(knob5float * 5);

        if ((knob3float * 5 > 2.4f) && (knob3float * 5 < 2.8f))
        {

            Signal1GO.GetComponent<Image>().sprite = CircleRed;
            signal1Found = true;
        }
        else
        {
            Signal1GO.GetComponent<Image>().sprite = CircleBlack;
            signal1Found = false;
        }


        if ((knob4float * 5 > 3.8f) && (knob4float * 5 < 4.4f))
        {
            Signal2GO.GetComponent<Image>().sprite = CircleRed;
            signal2Found = true;
        }
        else
        {
            Signal2GO.GetComponent<Image>().sprite = CircleBlack;
            signal2Found = false;
        }

        if ((knob5float * 5 > 4.6f) && (knob5float * 5 < 5.2f))
        {
            Signal3GO.GetComponent<Image>().sprite = CircleRed;
            signal3Found = true;
        }
        else
        {
            Signal3GO.GetComponent<Image>().sprite = CircleBlack;
            signal3Found = false;
        }

        if((signal1Found == true)&&(signal2Found == true)&&(signal3Found))
        {
            XMark.SetActive(true);
        }
        else
        {
            XMark.SetActive(false);
        }
    }

    void Beeping()
    {
        
        
        
       
    }

    IEnumerator BeepSound()
    {
        while(playingBeep1)
        {
            beep.PlayOneShot(beepClip);
            yield return new WaitForSeconds(distanceBetween1 / 2);
        }
        while (playingBeep2)
        {
            beep.PlayOneShot(beepClip);
            yield return new WaitForSeconds(distanceBetween2 / 2);
        }
        while (playingBeep3)
        {
            beep.PlayOneShot(beepClip);
            yield return new WaitForSeconds(distanceBetween3 / 2);
        }
    }
}
