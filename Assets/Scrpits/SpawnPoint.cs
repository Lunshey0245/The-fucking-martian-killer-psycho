using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    List<GameObject> obstacles = new List<GameObject>();
    [SerializeField]
    bool ready = true;
    [SerializeField]
    float spawnObstacleDelay = 0;

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            ready = false;
            StartCoroutine(SpawnAndWait());
        }
    }

    IEnumerator SpawnAndWait()
    {        
        foreach (var obstacle in obstacles)
        {
            Instantiate(obstacle, this.transform.position, Quaternion.identity, this.transform);
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(spawnObstacleDelay);
        ready = true;
    }
}
