using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour
{
    public StatsParent Possession;
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hookable")
        {
            player.GetComponent<GrapplingHook>().hooked = true;
            player.GetComponent<GrapplingHook>().hookedObj = other.gameObject;
        }

        if(other.tag == "Predator" || other.tag == "Prey")
        {

        }
    }
}
