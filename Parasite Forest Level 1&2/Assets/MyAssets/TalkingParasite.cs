using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingParasite : MonoBehaviour
{
    public GameObject ThoughtBubble; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 void OnTriggerEnter(Collider collider)
    {
       //Check if player ran into me

        //set my text bubble active
        Debug.Log("hrrllooo");
        ThoughtBubble.SetActive(true);
        //Destroy()
    }

    private void OnTriggerExit(Collider other)
    {
        ThoughtBubble.SetActive(false);

        //TODO make bigger colider for text interaction.
    }
}
