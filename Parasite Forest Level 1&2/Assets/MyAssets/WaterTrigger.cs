﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public UnityStandardAssets.Vehicles.Ball.BallUserControl ballUserControl;

    // Start is called before the first frame update
    void Start()
    {
        // Underwater Visual Settings
        RenderSettings.fog = false;
        RenderSettings.fogColor = new Color(0.1650943f, 1.0f, 0.6805578f, 1.0f);
        RenderSettings.fogDensity = 0.02f;
    }

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fog = true;
    }

    private void OnTriggerExit(Collider other)
    {
        RenderSettings.fog = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
