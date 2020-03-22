using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour
{
    public GameObject player;
    // When the hook collides with something, do something
    void OnTriggerEnter(Collider other)
    {
        // If the collided object is tagged "Hookable", label it as hooked 
        if (other.tag == "Hookable")
        {
            player.GetComponent<GrapplingHook>().hooked = true;
            player.GetComponent<GrapplingHook>().hookedObj = other.gameObject;
        }
    }
}
