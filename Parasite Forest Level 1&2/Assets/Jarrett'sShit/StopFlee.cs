using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFlee : MonoBehaviour
{
    public NavPatrol controller;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            controller.hasAggro = false;
            controller.agent.ResetPath();
            controller.GotoNextPoint();
        }
    }
}
