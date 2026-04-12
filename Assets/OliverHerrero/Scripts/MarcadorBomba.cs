using UnityEngine;
using TMPro;

public class MarcadorBomba : MonoBehaviour
{
    public static MarcadorBomba Instance;
    public int bombCount = 0;
    public TextMeshProUGUI bombText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    void Start()
    {
        bombText.text = bombCount.ToString();
    }
}

