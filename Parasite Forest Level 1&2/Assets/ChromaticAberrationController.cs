using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticAberrationController : MonoBehaviour
{
    public GrappleCam grappleCam;
    public PostProcessProfile ppProfile;
    private ChromaticAberration ca;

    // Force the default chromatic abberation to 0
    void Start()
    {
        ppProfile.TryGetSettings(out ca);

        ca.intensity.value = 0;
    }

    // When going first person, gradually change the level of chromatic abberation and reduce it if entering third person
    void Update()
    {
        if (grappleCam.GrappleCamActive == true)
            ca.intensity.value = Mathf.Lerp(ca.intensity.value, 0.75f, .5f*Time.deltaTime);

        else
            ca.intensity.value = Mathf.Lerp(ca.intensity.value, 0, 1f * Time.deltaTime);
    }
}
