using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    Vector3 mousePosition;
    public float speed;

    private Rigidbody rb;

    public PossessionCamera controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.LookAt(mousePosition);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.A))
        {

        }

        if(Input.GetKeyDown(KeyCode.D))
        {

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            controller.UnPossessedCamera();
        }
    }
}
