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
    private float minTime;
    [SerializeField]
    private float maxTime;
    [SerializeField]
    float timeMaxRandom;
    [SerializeField]
    public bool isAirSpawm;
    [SerializeField]
    public Transform midSpawnPointPosition;
    [SerializeField]
    public Transform topSpawnPointPosition;

    private bool isReady = true;


    private void Start()
    {
        timeMaxRandom = maxTime;
        StartCoroutine(TimeSpawnUpgrate());

    }
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
        float seconds = Random.Range(minTime, timeMaxRandom);

        yield return new WaitForSeconds(seconds);
        SpawnObject(_objectsToSpawn[randomEnemyIndex]);
        isReady = true;
    }

    IEnumerator TimeSpawnUpgrate()
    {
        while (true)
        {
            timeMaxRandom -= 0.4f;
            //maxTime = timeToUpgrate;
            yield return new WaitForSeconds(1);
            if (timeMaxRandom < maxTime / 2)
            {
                break;
            }
        }
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
