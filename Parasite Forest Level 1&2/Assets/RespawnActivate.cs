using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;
public class RespawnActivate : MonoBehaviour
{
    public SpawnPosition spawnPosition;
    public GameObject playerCharacter;
    public bool eggSpawnActive;
    private float timerStart;
    private float timer;
    public float holdTime;
    private bool held = false;

    // By default, there is not an egg spawn point active
    private void Start()
    {
        eggSpawnActive = false;
        playerCharacter.tag = "Player";
    }

    // When "r" is pressed the egg spawn is now active
    // If the player is dead, pressing any key will reset their tags to default and respawn them
    // If "r" is held instead of pressed the egg will return to the egg holder
    public void Update()
    {

        if (Input.GetKeyDown("r"))
        {
            timerStart = Time.time;
            timer = timerStart;
        }

        if (Input.GetKey("r") && held == false)
        {
            timer += Time.deltaTime;
            eggSpawnActive = true;

            if (timer > (timerStart + holdTime))
            {
                held = true;
                ButtonHeld();
            }
        }

        if (Input.GetKeyUp("r"))
        {
            held = false;
        }

        if (playerCharacter.tag == "Dead" && Input.anyKeyDown)
        {
            playerCharacter.transform.position = spawnPosition.spawnLocation;
            eggSpawnActive = false;
            playerCharacter.tag = "Player";
        }
    } 

    void ButtonHeld()
    {
        eggSpawnActive = false;
    }
}
