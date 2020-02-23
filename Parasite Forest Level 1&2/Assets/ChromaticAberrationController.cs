using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticAberrationController : MonoBehaviour
{
    public GrappleCam grappleCam;
    public PostProcessProfile ppProfile;
    private ChromaticAberration ca;

    void Start()
    {
        ppProfile.TryGetSettings(out ca);

        ca.intensity.value = 0;
    }

    void Update()
    {
        if (grappleCam.GrappleCamActive == true)
            ca.intensity.value = Mathf.Lerp(ca.intensity.value, 1, .5f*Time.deltaTime);

        else
            ca.intensity.value = 0;
    }
}
