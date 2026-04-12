using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class EventMando : MonoBehaviour
{
    [SerializeField] private InputActionReference menuActionReference;
    [SerializeField] private GameObject menuPanel;
    public bool isActivated = false;

    public static EventMando Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        isActivated = false;
    }
    private void OnEnable()
    {
        menuActionReference.action.performed += OnMenuButtonPressed;
    }
    private void OnDisable()
    {
        menuActionReference.action.performed -= OnMenuButtonPressed;
    }
    private void OnMenuButtonPressed(InputAction.CallbackContext context)
    {
        if (SceneManager.GetActiveScene().name == "Facil" || SceneManager.GetActiveScene().name == "Dificil" || SceneManager.GetActiveScene().name == "Flechas")
        {
            if (!isActivated)
            {
                isActivated = true;
                menuPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else if (isActivated)
            {
                isActivated = false;
                menuPanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        
    }
}
