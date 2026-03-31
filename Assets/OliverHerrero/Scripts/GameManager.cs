using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public Dropdown dropdown;
    public static GameManager Instance;
    public int numberOfBlocks;
    public bool secondSable;
    public Toggle toggle;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Start()
    {
        numberOfBlocks = 20;
        SableNumber(toggle.isOn);

        toggle.onValueChanged.AddListener(SableNumber);
    }
    public void ChangeEasyMode()
    {
        SceneManager.LoadScene("Facil");
    }
    
    public void ChangeHardMode()
    {
        SceneManager.LoadScene("Dificil");
    }

    public void ChangeOptions()
    {
        int index = dropdown.value;
        switch (index)
        {
            case 0:
                numberOfBlocks = 20;
                break;
            
            case 1:
                numberOfBlocks = 15;
                break;

            case 2:
                numberOfBlocks = 10;
                break;
        }
    }
    public void SableNumber(bool activated)
    {
        Debug.Log(activated);
        if (activated == true)
        {
            secondSable = true;
        }
        else
        {
            secondSable = false;
        }
    }
}
