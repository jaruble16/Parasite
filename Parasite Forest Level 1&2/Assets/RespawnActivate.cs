using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnActivate : MonoBehaviour
{
    public SpawnPosition spawnPosition;
    public GameObject playerCharacter;

    public void Update()
    {
        if (playerCharacter.tag == "Dead")
            playerCharacter.transform.position = spawnPosition.eggLocation;
    } 
}
