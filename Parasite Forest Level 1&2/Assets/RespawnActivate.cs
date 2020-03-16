using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;
public class RespawnActivate : MonoBehaviour
{
    public SpawnPosition spawnPosition;
    public GameObject playerCharacter;
    public bool eggSpawnActive;

    private void Start()
    {
        eggSpawnActive = false;
        playerCharacter.tag = "Player";
    }

    public void Update()
    {
        if (Input.GetKey("r") == true)
        {
            eggSpawnActive = true;
        }

        if (playerCharacter.tag == "Dead" && Input.anyKeyDown)
        {
            playerCharacter.transform.position = spawnPosition.spawnLocation;
            eggSpawnActive = false;
            playerCharacter.tag = "Player";
        }
    } 
}
