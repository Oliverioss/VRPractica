using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Sable : MonoBehaviour
{
    [SerializeField] private GameObject leftSable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance.secondSable)
        {
            leftSable.SetActive(true);
        }
        else
        {
            leftSable.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            if (Marcador.Instance.score < GameManager.Instance.numberOfBlocks)
            {
                Destroy(other.gameObject);
                Marcador.Instance.score++;
                Marcador.Instance.scoreText.text = Marcador.Instance.score.ToString();
            }
        }
        if (other.gameObject.CompareTag("Bomb"))
        {
            if (Marcador.Instance.score < GameManager.Instance.numberOfBlocks && Marcador.Instance.score > 0)
            {
                Destroy(other.gameObject);
                Marcador.Instance.score--;
                Marcador.Instance.scoreText.text = Marcador.Instance.score.ToString();
            }
        }
    }
}
