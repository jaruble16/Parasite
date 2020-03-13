using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public GameObject egg;
    public Vector3 eggLocation;

    private void Update()
    {
        eggLocation = egg.transform.position;
    }
}
