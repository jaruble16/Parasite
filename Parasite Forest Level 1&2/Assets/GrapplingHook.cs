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
    
    private void Update()
    {
        if (Input.GetMouseButton(0) && fired == false)
            fired = true;

        if (fired)
        {
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetVertexCount(2);
            rope.SetPosition(0, hookholder.transform.position);
            rope.SetPosition(1, hook.transform.position);
        }

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
                ReturnHook();
        }
        
        if (hooked == true && fired == true)
        {
            hook.transform.parent = hookedObj.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            this.GetComponent<Rigidbody>().useGravity = false;

            if (Input.GetMouseButton(1))
                ReturnHook();

            if (distanceToHook < 5)
            {
                if (grounded == false)
                {
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 15f);
                    this.transform.Translate(Vector3.up * Time.deltaTime * 20f);
                }

                StartCoroutine("Climb");
            }
        }
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
    void ReturnHook()
    {
        hook.transform.rotation = hookholder.transform.rotation;
        hook.transform.position = hookholder.transform.position;
        fired = false;
        hooked = false;

        LineRenderer rope = hook.GetComponent<LineRenderer>();
        rope.SetVertexCount(0);
    }

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
