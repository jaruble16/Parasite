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
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(dayColor, nightColor, lerp));
        sun.transform.Rotate(Time.deltaTime * ((360/duration) / 2), 0, 0);
    }
}