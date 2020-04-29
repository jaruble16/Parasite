using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Button _containerButton;
    private bool _isOpen;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _isOpen = false;
    }

    void OnEnable()
    {
        _containerButton.onClick.AddListener(Close);
    }

    void OnDisable()
    {
        _containerButton.onClick.RemoveListener(Close);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (_isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    void Open()
    {
        _container.SetActive(true);
        _isOpen = true;
    }

    void Close()
    {
        _container.SetActive(false);
        _isOpen = false;
    }
}
