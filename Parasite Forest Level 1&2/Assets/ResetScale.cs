using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScale : MonoBehaviour
{
    void Update()
    {
       gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
