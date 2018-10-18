using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMiniGame : MonoBehaviour {

    [System.Serializable]
    public class point
    {
        public int xPoint;
        public int yPoint;

        public point(int xPoint, int yPoint)
        {
            this.xPoint = xPoint;
            this.yPoint = yPoint;
        }

        public static bool isEqual(point a, point b)
        {
            if ((a.xPoint == b.xPoint) && (a.yPoint == b.yPoint))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
    private List<point> PointList;
    private List<point> WinningPointList = new List<point>
    {
        new point(0, 0),
        new point(1, 0),
        new point(2, 0),
        new point(2, 1),
        new point(2, 2),
        new point(2, 3),
        new point(2, 4),
        new point(3, 4),
        new point(4, 4),
        new point(5, 4),
        new point(6, 4),
        new point(6, 5),
        new point(6, 6),
        new point(7, 6),
        new point(8, 6),
        new point(8, 7),
        new point(8, 8),
        new point(9, 8),
        new point(9, 9),
    };

    private List<bool> ChecksList = new List<bool>();
    
    public GameObject PawnGO;
    public RectTransform Pawn;

    public Sprite PawnBlack;
    public Sprite PawnRed;
    public Sprite PawnGreen;

    public KnobControl knob1;
    public KnobControl knob2;
    public KnobControl knob3;
    public KnobControl knob4;
    public KnobControl knob5;
    public KnobControl knob6;

    private float knob1float;
    private float knob2float;
    private float knob3float;
    private float knob4float;
    private float knob5float;
    private float knob6float;

    private int xPos = 0;
    private int yPos = 0;

    private int radioStation = 0;

    private bool endpoint = false;

    private bool badpathway = false;

    private AudioSource audioSourceComponent;

    public AudioClip radioFile1;
    public AudioClip radioFile2;
    public AudioClip radioFile3;
    public AudioClip radioFile4;
    public AudioClip radioFile5;
    public AudioClip radioFile6;
    public AudioClip radioFile7;
    public AudioClip radioFile8;
    public AudioClip radioFile9;
    public AudioClip radioFile10;


    // Use this for initialization
    void Start ()
    {

        audioSourceComponent = this.GetComponent<AudioSource>();
        PointList = new List<point>();
        PointList.Add(new point(xPos, yPos));
        StartCoroutine(PlaySounds());
    }
	
	// Update is called once per frame
	void Update ()
    {
        knob1float = knob1.potValue;
        knob2float = knob2.potValue;
        knob3float = knob3.potValue;
        knob4float = knob4.potValue;
        knob5float = knob5.potValue;
        knob6float = knob6.potValue;

        RadioChannel();
        PawnPositioning();
        PawnPathway();
        //Place the pawn based on the pawn positioning function
        Pawn.anchoredPosition3D = new Vector3(xPos*10, -yPos*10, Pawn.anchoredPosition3D.z);

        
    }


    void RadioChannel()
    {
        if ((knob3.potValue > 0.0f) && (knob3.potValue < 1.0f))
        {
            
            radioStation = 0;
          
        }
        else if ((knob3.potValue > 1.0f) && (knob3.potValue < 2.0f))
        {
           
            radioStation = 1;
       
        }
        else if ((knob3.potValue > 2.0f) && (knob3.potValue < 3.0f))
        {
           
            radioStation = 2;
           
        }
        else if ((knob3.potValue > 3.0f) && (knob3.potValue < 4.0f))
        {
            
            radioStation = 3;
           
        }
        else if ((knob3.potValue > 4.0f) && (knob3.potValue < 5.0f))
        {
          
            radioStation = 4;
          
        }
        else if ((knob3.potValue > 5.0f) && (knob3.potValue < 6.0f))
        {
           
            radioStation = 5;
           
        }
        else if ((knob3.potValue > 6.0f) && (knob3.potValue < 7.0f))
        {
      
            radioStation = 6;
           
        }
        else if ((knob3.potValue > 7.0f) && (knob3.potValue < 8.0f))
        {
           
            radioStation = 7;
           
        }
        else if ((knob3.potValue > 8.0f) && (knob3.potValue < 9.0f))
        {
            
            radioStation = 8;
           
        }
        else if ((knob3.potValue > 9.0f) && (knob3.potValue < 10.0f))
        {
           
            radioStation = 9;
            
        }

       
    }

    IEnumerator PlaySounds()
    {

        if (radioStation == 0)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile1;
            audioSourceComponent.PlayOneShot(radioFile1);
            //audioSourceComponent.Play();
            yield return new WaitForSeconds(2.0f);
        }
        else if (radioStation == 1)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile2;
            audioSourceComponent.PlayOneShot(radioFile2);
            //audioSourceComponent.Play();
            yield return new WaitForSeconds(2.0f);
        }
        else if (radioStation == 2)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile3;
            audioSourceComponent.Play();
            //audioSourceComponent.PlayOneShot(radioFile3);
            yield return new WaitForSeconds(9.0f);
            
        }
        else if (radioStation == 3)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile4;
            //audioSourceComponent.Play();
            audioSourceComponent.PlayOneShot(radioFile4);
            yield return new WaitForSeconds(2.0f);
        }
        else if (radioStation == 4)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile5;
            //audioSourceComponent.Play();
            audioSourceComponent.PlayOneShot(radioFile5);
            yield return new WaitForSeconds(2.0f);
        }
        else if (radioStation == 5)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile6;
            //audioSourceComponent.Play();
            audioSourceComponent.PlayOneShot(radioFile6);
            yield return new WaitForSeconds(2.0f);
        }
        else if (radioStation == 6)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile7;
            //audioSourceComponent.Play();
            audioSourceComponent.PlayOneShot(radioFile7);
            yield return new WaitForSeconds(5.0f);
        }
        else if (radioStation == 7)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile8;
            //audioSourceComponent.Play();
            audioSourceComponent.PlayOneShot(radioFile8);
            yield return new WaitForSeconds(2.0f);
        }
        else if (radioStation == 8)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile9;
            //audioSourceComponent.Play();
            audioSourceComponent.PlayOneShot(radioFile9);
            yield return new WaitForSeconds(4.0f);
        }
        else if (radioStation == 9)
        {
            audioSourceComponent.Pause();
            audioSourceComponent.clip = radioFile10;
            //audioSourceComponent.Play();
            audioSourceComponent.PlayOneShot(radioFile10);
            yield return new WaitForSeconds(4.0f);
        }
       
        StartCoroutine(PlaySounds());
    }
    void PawnPositioning()
    {
         int tempXPos = xPos;
         int tempYPos = yPos;
        //X positioning info
        if ((knob1.potValue > 0.0f) && (knob1.potValue < 1.0f))
        {
            tempXPos = 0;
        }
        else if ((knob1.potValue > 1.0f) && (knob1.potValue < 2.0f))
        {
            tempXPos = 1;
        }
        else if ((knob1.potValue > 2.0f) && (knob1.potValue < 3.0f))
        {
            tempXPos = 2;
        }
        else if ((knob1.potValue > 3.0f) && (knob1.potValue < 4.0f))
        {
            tempXPos = 3;
        }
        else if ((knob1.potValue > 4.0f) && (knob1.potValue < 5.0f))
        {
            tempXPos = 4;
        }
        else if ((knob1.potValue > 5.0f) && (knob1.potValue < 6.0f))
        {
            tempXPos = 5;
        }
        else if ((knob1.potValue > 6.0f) && (knob1.potValue < 7.0f))
        {
            tempXPos = 6;
        }
        else if ((knob1.potValue > 7.0f) && (knob1.potValue < 8.0f))
        {
            tempXPos = 7;

        }
        else if ((knob1.potValue > 8.0f) && (knob1.potValue < 9.0f))
        {
            tempXPos = 8;
        }
        else if ((knob1.potValue > 9.0f) && (knob1.potValue < 10.0f))
        {
            tempXPos = 9;
        }





        //Y Positioning info
        if ((knob2.potValue > 0.0f) && (knob2.potValue < 1.0f))
        {
            tempYPos = 0;
        }
        else if ((knob2.potValue > 1.0f) && (knob2.potValue < 2.0f))
        {
            tempYPos = 1;
        }
        else if ((knob2.potValue > 2.0f) && (knob2.potValue < 3.0f))
        {
            tempYPos = 2;
        }
        else if ((knob2.potValue > 3.0f) && (knob2.potValue < 4.0f))
        {
            tempYPos = 3;
        }
        else if ((knob2.potValue > 4.0f) && (knob2.potValue < 5.0f))
        {
            tempYPos = 4;
        }
        else if ((knob2.potValue > 5.0f) && (knob2.potValue < 6.0f))
        {
            tempYPos = 5;
        }
        else if ((knob2.potValue > 6.0f) && (knob2.potValue < 7.0f))
        {
            tempYPos = 6;
        }
        else if ((knob2.potValue > 7.0f) && (knob2.potValue < 8.0f))
        {
            tempYPos = 7;
        }
        else if ((knob2.potValue > 8.0f) && (knob2.potValue < 9.0f))
        {
            tempYPos = 8;
        }
        else if ((knob2.potValue > 9.0f) && (knob2.potValue < 10.0f))
        {
            tempYPos = 9;
        }
       
        //Adding the position order to the list.
        if(tempXPos != xPos || tempYPos != yPos)
        {
            xPos = tempXPos;
            yPos = tempYPos;
            //Debug.Log("positionChanged");

            PointList.Add(new point(xPos, yPos));

        }
       
    }

    void PawnPathway()
    {
        PawnGO.GetComponent<Image>().sprite = PawnBlack;
        if ((xPos == 9) && (yPos == 9))
        {
            
            bool isEquals = true;

            if (PointList.Count == WinningPointList.Count)
            {
                    
                for (int i = 0; i < WinningPointList.Count; i++)
                {
                    if(point.isEqual(WinningPointList[i],PointList[i]) == false)
                    {
                        isEquals = false;
                        badpathway = true;
                        ChecksList.Add(false);
                        Debug.Log("Bad Path");
                    }
                    else
                    {
                        ChecksList.Add(true);
                        Debug.Log("Good Path");
                    }
                }
            }
            else
            {
                isEquals = false;
            }
                
            if(isEquals == true)
            {
                Debug.Log("you Win");
                PawnGO.GetComponent<Image>().sprite = PawnGreen;
            }
            else
            {
                Debug.Log("Bad Pathway");
                PawnGO.GetComponent<Image>().sprite = PawnRed;
            }
        }

       
    }
}
