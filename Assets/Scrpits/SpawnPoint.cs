using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> _objectsToSpawn;
    [SerializeField]
    public float _secondsBetweenSpawns;

    public List<GameObject> ObjectsToSpawn 
    { 
        get { return _objectsToSpawn; } 
        set { _objectsToSpawn = value; } 
    }
    public float SecondsBetweenSpawns 
    {
        get { return _secondsBetweenSpawns; }
        set { _secondsBetweenSpawns = value; } 
    }

    private bool isReady = true;

    private void Update()
    {
        if (isReady)
        {
            isReady = false;
            StartCoroutine(GetObjects());
        }
    }

    IEnumerator GetObjects()
    {
        foreach (var oneObject in _objectsToSpawn)
        {
            SpawnObject(oneObject);
            yield return new WaitForSeconds(_secondsBetweenSpawns);
        }

        isReady = true;
    }

    public void SpawnObject(GameObject spawnMe)
    {
        Instantiate(spawnMe, this.transform.position, Quaternion.identity, this.transform);
    }
}
