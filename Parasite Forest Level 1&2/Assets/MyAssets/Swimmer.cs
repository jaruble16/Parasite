using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fp;

    // Start is called before the first frame update
    void Start()
    {
        fp = gameObject.GetComponent <UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    bool IsUnderwater()
    {
        return gameObject.transform.position.y < 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUnderwater())
        {
            fp.m_Jumping = false;
            fp.m_WalkSpeed = 2;
            fp.m_RunSpeed = 5;
            fp.m_StickToGroundForce = 20f;

            if (Input.GetKey(KeyCode.Mouse1))
            {
                fp.m_MoveDir.y = 2f;
                fp.m_MoveDir.x = 2f;
            }
        }

        else
        {
            fp.m_Jumping = true;
            fp.m_WalkSpeed = 4;
            fp.m_RunSpeed = 10;
            fp.m_StickToGroundForce = 10f;
        }
    }
}
