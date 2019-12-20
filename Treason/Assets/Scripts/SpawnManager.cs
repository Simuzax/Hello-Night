using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPoints = new Transform[8];

    [SerializeField]
    GameObject[] zombies = new GameObject[3];

    float waveDelay = 3;

    float diffIncreaseDelay = 2;

    float t = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnWaves");

        StartCoroutine("IncreaseDifficulty");
    }

    IEnumerator SpawnWaves()
    {
        while (t == 1)
        {
            spawnEnemies();

            yield return new WaitForSeconds(waveDelay);
        }
    }

    IEnumerator IncreaseDifficulty()
    {
        while (t == 1)
        {
            waveDelay -= 0.1f;

            yield return new WaitForSeconds(diffIncreaseDelay);
        }
    }

    void spawnEnemies()
    {
        int spawnLocation = Random.Range(0, spawnPoints.Length);

        Vector3 position = spawnPoints[spawnLocation].position;

        GameObject z = Instantiate(zombies[Random.Range(0,3)], position, Quaternion.identity).GetComponent<GameObject>();
    }
}
