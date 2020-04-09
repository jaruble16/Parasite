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
    private GameObject eggCollideIdentify;

    // Place whatever the default spawn point should be here
    private void Start()
    {
        defaultSpawn = new Vector3(680f, 280f, 850f);
        eggCollider = GetComponent<Collider>();
    }
    
    // When egg collides with something, identify what it is
    private void OnCollisionEnter(Collision collision)
    {
        eggCollideIdentify = collision.gameObject;
    }
    private void Update()
    {

        // Get the location of the assigned game object acting as the egg
        eggLocation = egg.transform.position;

        // If the egg spawn is active, set the spawn location to the egg location, otherwise 
        // set spawn location to default and move the egg to the egg holder
        if (respawnActivate.eggSpawnActive == true)
        {
            spawnLocation = eggLocation;
        }
        else
        {
            spawnLocation = defaultSpawn;
            egg.transform.position = eggHolder.transform.position;
        }

        // If the egg spawn is not active, disable collisions on the egg so it can be stored in the egg holder
        // If it is active, re-enable collision
        if (respawnActivate.eggSpawnActive == false)
        {
            eggCollider.enabled = eggCollider.enabled = false;

        }

        if (respawnActivate.eggSpawnActive == true)
        {
            eggCollider.enabled = eggCollider.enabled = true;
        }

        // If the egg collides with something solid, stop its movement

        if (eggCollideIdentify.tag == "Hookable")
        {
            egg.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
}
