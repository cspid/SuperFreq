using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(RawImage))]
public class WaveVisualizer : MonoBehaviour
{


    public int width = 500; // texture width 
    public int height = 100; // texture height 
    Color backgroundColor = Color.black;
    public Color waveformColor1 = Color.green;
	public Color waveformColor2 = Color.green;
	//public Color waveformColor3 = Color.green;
    public int size = 2048; // size of sound segment displayed in texture

    private Color[] blank; // blank image array 
    private Texture2D texture;
    private float[] samples1; // audio samples array
	private float[] samples2; // audio samples array
	private float[] samples3; // audio samples array

	public AudioSource audio1;
	public AudioSource audio2;
	//public AudioSource audio3;


    IEnumerator Start()
    {

        // create the samples array 
        samples1 = new float[size];
		samples2 = new float[size];
		samples3 = new float[size];

        
        // create the texture and assign to the guiTexture: 
        texture = new Texture2D(width, height);

        GetComponent<RawImage>().texture = texture;

        // create a 'blank screen' image 
        blank = new Color[width * height];

        for (int i = 0; i < blank.Length; i++)
        {
            blank[i] = backgroundColor;
        }

        // refresh the display each 100mS 
        while (true)
        {
            GetCurWave();
            yield return new WaitForSeconds(0.05f);
        }
    }

    void GetCurWave()
    {
        // clear the texture 
        texture.SetPixels(blank, 0);

        // get samples from channel 0 (left) 
        audio1.GetOutputData(samples1, 0);
		audio2.GetOutputData(samples2, 0);
		//audio3.GetOutputData(samples3, 0);

        
        // draw the waveform 
        for (int i = 0; i < size; i++)
        {
            texture.SetPixel((int)(width * i / size), (int)(height * (samples1[i] + 1f) / 2f), waveformColor1);
			texture.SetPixel((int)(width * 1.3f * i / size), (int)(height * (samples2[i] + 1f) / 2f), waveformColor2);
			//texture.SetPixel((int)(width * i / size), (int)(height * (samples3[i] + 1f) / 2f), waveformColor3);
        } // upload to the graphics card 

        texture.Apply();
    }
}