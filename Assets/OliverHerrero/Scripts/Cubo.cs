using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Cubo : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject leftCube;
    [SerializeField] private GameObject rightCube;
    [SerializeField] private GameObject downCube;
    [SerializeField] private GameObject upCube;

    [SerializeField] private GameObject bomb;
    public Vector3 spawnPoint;
    private float time = 3.0f;
    [SerializeField] private Transform camara;
    [SerializeField] float distance = 10f;
    private float bombProbability = 0.3f;
    private Scene currentScene;
    private string sceneName;
    public Direction correctDirection;
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        StartCoroutine(spawnTime(time));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnTime(float time)
    {
        while (true)
        { 
            yield return new WaitForSeconds(time);
            Vector3 direction = camara.forward;
            direction.y = 0f;
            Vector3 position = camara.position + direction * distance;

            if (sceneName == "Facil")
            {
                GameObject cubePrefab = Instantiate(cube, position, Quaternion.identity);
                Destroy(cubePrefab, 3.5f);
            }
            if (sceneName == "Dificil")
            {
                if (Random.value > bombProbability)
                {
                    GameObject cubePrefab = Instantiate(cube, position, Quaternion.identity);
                    Destroy(cubePrefab, 3.5f);
                }
                else
                {
                    GameObject bombPrefab = Instantiate(bomb, position, Quaternion.identity);
                    Destroy(bombPrefab, 3.5f);
                }
            }

            if (sceneName == "Flechas")
            {
                Direction arrowDirection = Direction.Left;
                if (Random.value <= 0.25f)
                {
                    GameObject leftCubePrefab = Instantiate(leftCube, position, Quaternion.identity);
                    arrowDirection = Direction.Left;
                    CuboDireccion cuboDireccion = leftCubePrefab.GetComponent<CuboDireccion>();
                    cuboDireccion.direccionCorrecta = arrowDirection;
                    Destroy(leftCubePrefab, 3.5f);
                }
                else if (Random.value <= 0.5f)
                {
                    GameObject rightCubePrefab = Instantiate(rightCube, position, Quaternion.identity);
                    arrowDirection = Direction.Right;
                    CuboDireccion cuboDireccion = rightCubePrefab.GetComponent<CuboDireccion>();
                    cuboDireccion.direccionCorrecta = arrowDirection;
                    Destroy(rightCubePrefab, 3.5f);
                }
                else if (Random.value <= 0.75f)
                {
                    GameObject upCubePrefab = Instantiate(upCube, position, Quaternion.identity);
                    arrowDirection = Direction.Up;
                    CuboDireccion cuboDireccion = upCubePrefab.GetComponent<CuboDireccion>();
                    cuboDireccion.direccionCorrecta = arrowDirection;
                    Destroy(upCubePrefab, 3.5f);
                }
                else 
                {
                    GameObject downCubePrefab = Instantiate(downCube, position, Quaternion.identity);
                    arrowDirection = Direction.Down;
                    CuboDireccion cuboDireccion = downCubePrefab.GetComponent<CuboDireccion>();
                    cuboDireccion.direccionCorrecta = arrowDirection;
                    Destroy(downCubePrefab, 3.5f);
                }
              
            }
        }
    }
}
