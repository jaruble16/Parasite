using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastReticle : MonoBehaviour
{
    public Vector3 reticleLocation;
    public Sprite sprite1;
    public Sprite sprite2;
    void Update()
    {
        // Cast a ray from the center of the camera's location 30 units forward
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        reticleLocation = ray.GetPoint(30);

        // If the ray collides with something change the reticle to designate a "hit"
        if (Physics.Raycast(ray, out hit, 30 ))
        {
            this.GetComponent<Image>().sprite = sprite2;
            reticleLocation = hit.point;
        }

        else
        {
            this.GetComponent<Image>().sprite = sprite1;

        }
    }
}