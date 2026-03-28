using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Sable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            if (Marcador.Instance.score < 20)
            {
                Destroy(other.gameObject);
                Marcador.Instance.score++;
                Marcador.Instance.scoreText.text = Marcador.Instance.score.ToString();
            }
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            if (Marcador.Instance.score < 20 && Marcador.Instance.score > 0)
            {
                Destroy(other.gameObject);
                Marcador.Instance.score--;
                Marcador.Instance.scoreText.text = Marcador.Instance.score.ToString();
            }
        }
    }
}
