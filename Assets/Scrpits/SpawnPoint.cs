using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _objectsToSpawn = new List<GameObject>();
    [SerializeField]
    private float _secondsBetweenSpawns;
    [SerializeField]
    private int minTime;
    [SerializeField]
    private int maxTime;
    [SerializeField]
    public bool isAirSpawm;
    [SerializeField]
    public Transform midSpawnPointPosition;
    [SerializeField]
    public Transform topSpawnPointPosition;

    private bool isReady = true;

    private void Update()
    {        
        if (GameController.GetGameState())
        {
            if (isReady)
            {
                isReady = false;
                StartCoroutine(GetObjects());
            }
        }

    }

    IEnumerator GetObjects()
    {
        int randomEnemyIndex = Random.Range(0, _objectsToSpawn.Count);
        int seconds = Random.Range(minTime, maxTime);

        yield return new WaitForSeconds(seconds);
        SpawnObject(_objectsToSpawn[randomEnemyIndex]);
        isReady = true;
    }

    public void SpawnObject(GameObject spawnMe)
    {
        if (!isAirSpawm)
        {
            Instantiate(spawnMe, this.transform.position, Quaternion.identity, this.transform);
        }
        else
        {
            float randomYPos = Random.Range(midSpawnPointPosition.position.y, topSpawnPointPosition.position.y);
            Vector3 newPosition = this.transform.position;
            newPosition.y = randomYPos;
            Instantiate(spawnMe, newPosition, Quaternion.identity, this.transform);
        }
    }
}
