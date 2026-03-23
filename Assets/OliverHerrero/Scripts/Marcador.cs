using TMPro;
using UnityEngine;

public class Marcador : MonoBehaviour
{
    public static Marcador Instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
