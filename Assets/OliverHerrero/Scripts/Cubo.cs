using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Cubo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cube;
    private Vector3 spawnPoint;
    private float Rotation;
    private float time = 3.0f;

    void Start()
    {
        StartCoroutine(spawnTime(time));
    }

    // Update is called once per frame
    void Update()
    {
       
       // spawnPoint = cube.transform.localPosition + player.transform.position;
        //Rotation = player.transform.localRotation.eulerAngles.x;
    }

    IEnumerator spawnTime(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Instantiate(cube, new Vector3(Random.Range(-10,10),3f, 14f), Quaternion.identity);
        }
    }
}
