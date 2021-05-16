using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float timeBtwShot;
    [SerializeField]
    int timeShotMax;
    [SerializeField]
    int timeShotMin;

    [SerializeField]
    Transform shotPos;

    [SerializeField]
    GameObject bullet;
    void Start()
    {
        timeBtwShot = timeShotMax;
    }

    // Update is called once per frame
    void Update()
    {
        int timeToShot = Random.Range(timeShotMin, timeShotMax);
        timeBtwShot -= Time.deltaTime;
        if (timeBtwShot < 0)
        {
            timeBtwShot = timeToShot;
            Instantiate(bullet, shotPos.transform.position, Quaternion.identity);
        }
    }
}
