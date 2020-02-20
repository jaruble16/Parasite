using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GrappleCam : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GrappleCamActive = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (GrappleCamActive == false && (Input.GetKeyDown(KeyCode.Space)))
        {
            gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 11;
            StartCoroutine(pauseTime());
            GrappleCamActive = true;
        }

       else if (GrappleCamActive == true && (Input.GetKeyDown(KeyCode.Space)))
        {
            gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 9;
            StartCoroutine(pauseTime());
            GrappleCamActive = false;
        }
    }

    private IEnumerator pauseTime()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1f;
    }
}
