using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject menuPanel;
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
    public void ResumeGame()
    {
        EventMando.Instance.isActivated = false;
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        EventMando.Instance.isActivated = false;
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
