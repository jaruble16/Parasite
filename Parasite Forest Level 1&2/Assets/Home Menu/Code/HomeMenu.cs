using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    //[SerializeField] private Button _creditsButton;

    [SerializeField] private GameObject _loadingScreen;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(HandleStartPressed);
        _exitButton.onClick.AddListener(HandleExitPressed);
        //_creditsButton.onClick.AddListener(HandleCreditsPressed);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(HandleStartPressed);
        _exitButton.onClick.RemoveListener(HandleExitPressed);
        //_creditsButton.onClick.RemoveListener(HandleCreditsPressed);
    }

    void HandleStartPressed()
    {
        _loadingScreen.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void HandleExitPressed()
    {
        Application.Quit();
    }

    void HandleCreditsPressed()
    {
        Debug.LogWarning("No Credits Menu!");
    }
}
