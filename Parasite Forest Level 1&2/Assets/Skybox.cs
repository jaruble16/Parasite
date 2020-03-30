using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour
{
    public Color dayColor;
    public Color nightColor;
    public float duration;

    private void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(dayColor, nightColor, lerp));
    }
}
