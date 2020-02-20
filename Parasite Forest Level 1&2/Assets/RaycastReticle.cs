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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        reticleLocation = ray.GetPoint(30);

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