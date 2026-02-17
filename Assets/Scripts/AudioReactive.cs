// UMD IMDM290 
// Instructor: Myungin Lee
// All the same Lerp but using audio

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReactive : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 200; 
    float time = 0f;
    Vector3[] initPos;
    Vector3[] startPosition, endPosition;
    float lerpFraction; // Lerp point between 0~1
    float t;

    //state 1, 2, 3, 4
    //1 - exposition                    //toby
    //2 - rising action                 //Michelle
    //3 - climax                        //toby
    //4 - falling action/conclusion     //michelle

    //0:00-0:12 - Intro     (1)
    //0:13-0:37 - part 1    (2)
    //0:37-1:01 - chorus    (3)
    //1:02-1:25 - int.      (2)
    //1:26-1:50 - part 2    (2)
    //1:51-2:15 - chorus    (3)
    //2:16-2:42 - part 3    (2)
    //2:43-3:21 - outro     (4)

    // Start is called before the first frame update
    void Start()
    {
        // Assign proper types and sizes to the variables.
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere]; // Start positions
        startPosition = new Vector3[numSphere]; 
        endPosition = new Vector3[numSphere];
        // Define target positions. Start = random, End = heart 
        for (int i =0; i < numSphere; i++){
            // Random start positions
            float r = 10f;
            startPosition[i] = new Vector3(r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f));        

            r = 3f; // radius of the circle
            // Circular end position
            endPosition[i] = new Vector3(r * Mathf.Sin(i * 2 * Mathf.PI / numSphere), r * Mathf.Cos(i * 2 * Mathf.PI / numSphere));
        }
        // Let there be spheres..
        for (int i =0; i < numSphere; i++){
            // Draw primitive elements:
            // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.CreatePrimitive.html
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            // Position
            initPos[i] = startPosition[i];
            spheres[i].transform.position = initPos[i];
            spheres[i].transform.localRotation = Quaternion.EulerAngles(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));
            spheres[i].transform.localScale = new Vector3(Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f));
            // Color
            // Get the renderer of the spheres and assign colors.
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            // HSV color space: https://en.wikipedia.org/wiki/HSL_and_HSV
            float hue = (float)i / numSphere; // Hue cycles through 0 to 1
            Color color = Color.HSVToRGB(hue, 1f, 1f); // Full saturation and brightness
            sphereRenderer.material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ***Here, we use audio Amplitude, where else do you want to use?
        // Measure Time 
        // Time.deltaTime = The interval in seconds from the last frame to the current one
        // but what if time flows according to the music's amplitude?
        //time += Time.deltaTime * AudioSpectrum.audioAmp;
        time += Time.deltaTime * AudioSpectrum.audioAmp;
        Debug.Log(AudioSpectrum.audioAmp);
        // what to update over time?

        if (Time.time < 12f)
        {
            State1();

        } else if (Time.time < 37f)
        {
            State2();

        } else if (Time.time < 61f)
        {
            State3();

        } else if (Time.time < 85f)
        {
            State2();

        } else if (Time.time < 110f)
        {
            State2();

        } else if (Time.time < 135f)
        {
            State3();

        } else if (Time.time < 162f)
        {
            State2();

        } else if (Time.time < 201f)
        {
            State4();

        }

        //lowkey you can just steal this

        // for (int i =0; i < numSphere; i++){
        //     // Lerp : Linearly interpolates between two points.
        //     // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector3.Lerp.html
        //     // Vector3.Lerp(startPosition, endPosition, lerpFraction)
            
        //     // lerpFraction variable defines the point between startPosition and endPosition (0~1)
        //     lerpFraction = Mathf.Sin(time) * 0.5f + 0.5f;

        //     // Lerp logic. Update position       
        //     t = i* 2 * Mathf.PI / numSphere;
        //     spheres[i].transform.position = Vector3.Lerp(startPosition[i], endPosition[i], lerpFraction);
        //     float scale = 1f + AudioSpectrum.audioAmp;
        //     spheres[i].transform.localScale = new Vector3(scale, 1f, 1f);
        //     spheres[i].transform.Rotate(AudioSpectrum.audioAmp, 1f, 1f);
            
        //     // Color Update over time
        //     Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
        //     float hue = (float)i / numSphere; // Hue cycles through 0 to 1
        //     Color color = Color.HSVToRGB(Mathf.Abs(hue * Mathf.Cos(time)), Mathf.Cos(AudioSpectrum.audioAmp / 10f), 2f + Mathf.Cos(time)); // Full saturation and brightness
        //     sphereRenderer.material.color = color;
        // }
    }


    private void State1()
    {
        
    }

    private void State2()
    {
        
    }
    private void State3()
    {
        
    }
    private void State4()
    {
        
    }
}
