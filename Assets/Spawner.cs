using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstacle;
    public float[] delay;
    public bool spawnEnabled = true;

    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (spawnEnabled)
        {
            int maxSpawned = spawnPoints.Length;
            int totalSpawned = 0;

            foreach (Transform spawnPoint in spawnPoints)
            {
                bool toSpawn = Random.Range(0, 2) == 1;
                if (toSpawn && totalSpawned < maxSpawned - 1)
                {
                    Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation);
                    totalSpawned++;
                }
            }

            if (totalSpawned == 0)
            {
                Instantiate(obstacle, spawnPoints[0].position, spawnPoints[0].rotation);
            }

            float nextTimeToSpawn = Random.Range(delay[0], delay[1]);
            yield return new WaitForSeconds(nextTimeToSpawn);
        }
    }
}
