using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTargetLocation : MonoBehaviour
{
    public RaycastReticle raycastReticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = raycastReticle.reticleLocation;
    }
}
