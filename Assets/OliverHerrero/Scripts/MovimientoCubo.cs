using UnityEngine;

public class MovimientoCubo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cube;
    [SerializeField] private float speed = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCameras");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        cube.transform.position = Vector3.MoveTowards(cube.transform.position, player.transform.position, step);
    }
}
