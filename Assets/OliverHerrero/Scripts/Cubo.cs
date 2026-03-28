using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Cubo : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject cubePrefab;
    public Vector3 spawnPoint;
    private float time = 3.0f;
    private float destinationOffsetRange = 1.5f;
    private float offset;
    [SerializeField] private Transform camara;
    [SerializeField] float distance = 10f;
    private float apparitionValue = 0.3f;
    void Start()
    {
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
            if (UnityEngine.Random.value > apparitionValue)
            {
                GameObject cubePrefab = Instantiate(cube, position, Quaternion.identity);
            }
            else
            {

            }
            Destroy(cubePrefab,3.5f);
        }
    }
}
