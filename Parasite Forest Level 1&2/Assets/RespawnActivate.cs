using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;
public class RespawnActivate : MonoBehaviour
{
    public SpawnPosition spawnPosition;
    public GameObject playerCharacter;
    public bool eggSpawnActive;

    // By default, there is not an egg spawn point active
    private void Start()
    {
        eggSpawnActive = false;
        playerCharacter.tag = "Player";
    }

    // When "r" is pressed the egg spawn is now active
    // If the player is dead, pressing any key will reset their tags to default and respawn them
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
