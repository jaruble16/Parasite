using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsParent : MonoBehaviour
{
    public bool isPossessed = false;
    public float health = 1000.0f;
    public float HPDecay = 1.0f;
    public float Energy = 500.0f;
    public float EPDecay = 0.5f;
    public float timer = 0.0f;
    public int seconds;
    public int timePossessed = 0;

    private void Update()
    {
    //Constant Timer

        timer += Time.deltaTime;
        seconds = (int)(timer % 60);

    //Possession Energey and Health Decay
        if(isPossessed == true)
        {
          
                for (int timePossessed = seconds; timePossessed <= seconds; timePossessed++)
                {
                    if(Energy > 0.0f)
                    {
                        Energy -= EPDecay;
                    }
                    else
                    {
                        health -= HPDecay;
                    }
                }
            
          
        }

        if(health <= 0)
        {
            Death();
        }
    }

    public void OnMouseDown()
    {
        Possess();
    }

    public void Possess()
    {
        //This would be where the player controller is attached.
        isPossessed = true;
        
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
