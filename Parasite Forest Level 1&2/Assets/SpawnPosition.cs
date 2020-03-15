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


    private void Start()
    {
        defaultSpawn = new Vector3(680f, 280f, 850f);
    }
    private void Update()
    {
        eggLocation = egg.transform.position;

        if (respawnActivate.eggSpawnActive == true)
            eggLocation = spawnLocation;
        else
            spawnLocation = defaultSpawn;

    }
}
