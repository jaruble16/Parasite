using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    public NavPatrol controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controller.hasAggro = true;
            controller.agent.speed = controller.agent.speed;// * 2;
            Debug.Log("Player Trigger Aggro");
        }
    }
}
