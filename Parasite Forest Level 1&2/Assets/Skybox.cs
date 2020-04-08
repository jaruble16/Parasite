using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour
{
    public Color dayColor;
    public Color nightColor;
    public float duration;
    public Light sun;

    private void Start()
    {
       
    }

    private void Update()
    {
        // lerp progresses through 0 to 1 and back down again over a period of time sset by duration
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(dayColor, nightColor, lerp));
        // Rotate the light acting as the sun to coincide with the skybox
        sun.transform.Rotate(Time.deltaTime * ((360/duration) / 2), 0, 0);

        
    }
}