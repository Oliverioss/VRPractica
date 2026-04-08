using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
public class Sable : MonoBehaviour
{
    private Vector3 velocidad;
    [SerializeField] private GameObject leftSable;
    private Vector3 lastPos;
    private Quaternion lastRot;
    private Vector3 angularVel;
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

        lastPos = transform.position;
        lastRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        velocidad = (transform.position - lastPos) / Time.deltaTime; // La formula dvt
        lastPos = transform.position; // Sino pillariadesde la primeraposicion siempre y no iria bien

        Quaternion deltaRot = transform.rotation * Quaternion.Inverse(lastRot); // El inverse es para como poder hacer la resta de antes pero con rotaciom
        deltaRot.ToAngleAxis(out float angle, out Vector3 axis);
        angularVel = axis * (angle / Time.deltaTime); 
        lastRot = transform.rotation;

    }
    Cubo.Direction GetDireccion()
    {
        if (Mathf.Abs(velocidad.x) > Mathf.Abs(velocidad.y)) // Para saber si el movimiento es horizonatal o vertical
        {
            if (velocidad.x > 0) // Si es mayor es que viene de la derecha el movimiento
            {
                return Cubo.Direction.Right;
            }
            else
            {
               return Cubo.Direction.Left; // Si es menor es que viene de la izquierda
            }
        }
        else
        {
            if (velocidad.y > 0)// Si es mayor es que viene de arriba el movimiento
            {
                return Cubo.Direction.Up; 
            }
            else
            {
                return Cubo.Direction.Down;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala"))
        {
            if (Marcador.Instance.score < GameManager.Instance.numberOfBlocks)
            {
                AudioManager.Instance.PlayPointSound();
                Destroy(other.gameObject);
                Marcador.Instance.score++;
                Marcador.Instance.scoreText.text = Marcador.Instance.score.ToString();
            }
        }
        if (other.CompareTag("Bomb"))
        {
            if (Marcador.Instance.score < GameManager.Instance.numberOfBlocks && Marcador.Instance.score > 0)
            {
                AudioManager.Instance.PlayBombSound();
                Destroy(other.gameObject);
                Marcador.Instance.score--;
                Marcador.Instance.scoreText.text = Marcador.Instance.score.ToString();
            }
        }

        if (SceneManager.GetActiveScene().name == "Flechas")
        {
            CuboDireccion cuboDireccion = other.GetComponent<CuboDireccion>();

            float fuerza = velocidad.magnitude + angularVel.magnitude * 0.01f;
            Cubo.Direction dir = GetDireccion();
            bool acierto = cuboDireccion.Destroy(dir, fuerza);
            if (acierto)
            {
                AudioManager.Instance.PlayPointSound();
                Marcador.Instance.score++;
                Marcador.Instance.scoreText.text = Marcador.Instance.score.ToString();
            }
            else
            {
                AudioManager.Instance.PlayBombSound();
            }

        }

    }
}

