using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    public CharacterControls cc;

    // Start is called before the first frame update
    void Start()
    {
        // call script
        cc = gameObject.GetComponent<CharacterControls>();
    }

    bool IsUnderwater()
    {
        // Height of water
        return gameObject.transform.position.y < -27;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUnderwater())
        {
            // Underwater stuff
            cc.canJump = false;
            cc.speed = 5f;
            cc.gravity = 5f;
        }
        else
        {
            // change player actions back to default
            cc.canJump = true;
            cc.speed = 10f;
            cc.gravity = 10f;
        }
    }
}
