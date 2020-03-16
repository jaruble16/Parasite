using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public GameObject egg;
    public Vector3 eggLocation;
    public GameObject eggHolder;
    public RespawnActivate respawnActivate;
    public Vector3 spawnLocation;
    private Vector3 defaultSpawn;
    Collider eggCollider;

    private void Start()
    {
        defaultSpawn = new Vector3(680f, 280f, 850f);
        eggCollider = GetComponent<Collider>();
    }
    private void Update()
    {
        eggLocation = egg.transform.position;

        if (respawnActivate.eggSpawnActive == true)
        {
            spawnLocation = eggLocation;
        }
        else
        {
            spawnLocation = defaultSpawn;
            egg.transform.position = eggHolder.transform.position;
        }

        if (respawnActivate.eggSpawnActive == false)
        {
            eggCollider.enabled = eggCollider.enabled = false;
        }

        if (respawnActivate.eggSpawnActive == true)
        {
            eggCollider.enabled = eggCollider.enabled = true;
        }


    }
}
