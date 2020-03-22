using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public class GrappleCam : MonoBehaviour
{
    public bool GrappleCamActive = false;

    void Update()
    {

        // When "space" is pressed, toggle whether or not the first person camera has higher priority than third person
        // Transition effects are handled automatically by cinemachine
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

    // During the camera transition, the rest of the game is frozen
    private IEnumerator pauseTime()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1f;
    }
}
