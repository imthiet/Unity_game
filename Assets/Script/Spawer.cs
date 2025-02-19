using System.Threading;
using UnityEngine;

public class Spawer : MonoBehaviour
{
    [SerializeField]

    private GameObject[] obstacles;

    [SerializeField]
    private Transform highPos;

    [SerializeField]
    private Transform lowPos;

    private float timer = 0;

    [SerializeField]
    private float spawnRate = 2f;

    private void SpawnObstacles()
    {
        int index = Random.Range(0, obstacles.Length);
        if (index == 0 || index == 1)
        {
            GameObject obstacle = Instantiate(obstacles[index], lowPos.position, Quaternion.identity);
        }
        else if (index == 2)
        {
            GameObject obstacle = Instantiate(obstacles[index], highPos.position, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnObstacles();
            timer = 0;
        }

    }
}
