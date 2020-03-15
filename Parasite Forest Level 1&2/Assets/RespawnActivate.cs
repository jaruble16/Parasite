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
    }

    public void Update()
    {
        if (BallUserControl.jump == true)
        {

        }

        if (playerCharacter.tag == "Dead" && Input.anyKeyDown)
        {
            playerCharacter.transform.position = spawnPosition.eggLocation;
        }
    } 
}
