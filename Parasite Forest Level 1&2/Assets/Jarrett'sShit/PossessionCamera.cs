using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;

public class PossessionCamera : MonoBehaviour
{
    public GameObject target;
    public string targetName;
    public GameObject player;

    public Component CharacterControlsComp;
    public Component NavPatrolComp;
    // This is exclusively for the current turtle model but the process should be applicable to the 
    // the other creatures too, we shall see ;)

    public void PossessedCamera()
    {
        Debug.Log("I AM RUNNING POSSESSED CAMERA");




        //Set active camera to Turtle camera
        target.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 12;
        

        //Set Player Character to inactive (WORKING!)
        GameObject.Find("GLBcore").SetActive(false);

        //Turn off NavPatrol + and other AI features
        target.GetComponent<NavPatrol>().enabled = false;
        target.GetComponent<NavMeshAgent>().enabled = false;

        //Turn on Player Controller for Turtle
        target.GetComponent<CharacterControls>().enabled = true;
        target.GetComponent<Rigidbody>().isKinematic = false;
        target.GetComponent<Rigidbody>().useGravity = true;
    }


    public void UnPossessedCamera()
    {
        Debug.Log("I AM RUNNING UNPOSSESSED CAMERA");

        //Set active camera to Turtle camera
        target.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 0;


        //Set Player Character to inactive (WORKING!)
        GameObject.Find("GLBcore").SetActive(true);

        //Turn off NavPatrol + and other AI features
        target.GetComponent<NavPatrol>().enabled = true;
        target.GetComponent<NavMeshAgent>().enabled = true;

        //Turn on Player Controller for Turtle
        target.GetComponent<CharacterControls>().enabled = false;
        target.GetComponent<Rigidbody>().isKinematic = true;
        target.GetComponent<Rigidbody>().useGravity = false;
    }
}
