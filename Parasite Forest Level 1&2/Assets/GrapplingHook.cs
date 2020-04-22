using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookholder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    private bool grounded;
    public static bool fired;
    public bool hooked;
    public GameObject hookedObj;

    public float maxDistance;
    private float currentDistance;

    public GrappleCam grappleCam;

    public AudioSource audioManager;


    //Jarrett Changes
    public bool Possess;
    public PossessionCamera PossessControls;
    
    private void Update()
    {
        // If not currently firing and left mouse is pressed, set to firing
        if (Input.GetMouseButton(0) && fired == false)
        {
            fired = true;
            audioManager.Play();
        }
            

        // Create a line between the origin point of the hook and where the hook is located
        if (fired)
        {
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetVertexCount(2);
            rope.SetPosition(0, hookholder.transform.position);
            rope.SetPosition(1, hook.transform.position);
        }

        // When the hook is active but has not yet collided with anything, travel forward up to a user-defined max distance
        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
                ReturnHook();
        }

        // If the hook is active and has collided with something, get the location of the collided object and move the player character towards it
        if (hooked == true && fired == true)
        {
            hook.transform.parent = hookedObj.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            this.GetComponent<Rigidbody>().useGravity = false;

            // Player can press the left mouse button to cancel out of the grapple
            if (Input.GetMouseButton(1))
                ReturnHook();

            if (distanceToHook < 5)
            {
                // As the player aproaches the target, attempt to move them upward slightly
                if (grounded == false)
                {
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 15f);
                    this.transform.Translate(Vector3.up * Time.deltaTime * 20f);
                }

                StartCoroutine("Climb");
            }
        }
        //Jarrett Note: If the hook hits a predator or prey animal we want to possess it, not move towards it
        //if (hooked == true && fired == true && Possess == true)
        //{
        //    PossessControls.PossessedCamera();
        //}

        // While the hook has not hit anything gravity is still enabled for the player
        else
        {
            hook.transform.parent = hookholder.transform;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    IEnumerator Climb()
    {
        yield return new WaitForSeconds(0.1f);
        ReturnHook();
    }
    // When the hook is inactive store it in the hook holder and do not render a line
    void ReturnHook()
    {
        hook.transform.rotation = hookholder.transform.rotation;
        hook.transform.position = hookholder.transform.position;
        fired = false;
        hooked = false;

        LineRenderer rope = hook.GetComponent<LineRenderer>();
        rope.SetVertexCount(0);
    }

    // Is the player on the ground?
    void CheckIfGrounded()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
