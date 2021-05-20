using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float timeBtwShot;

    [SerializeField]
    int timeShotMin;
    [SerializeField]
    int timeShotMax;

    [SerializeField]
    Transform shotPos;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject fireShot;

    [SerializeField]
    bool isJeep;
    void Start()
    {
        timeBtwShot = timeShotMax;
        if (isJeep)
        {
            fireShot.SetActive(false);
        }
        Instantiate(bullet, shotPos.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        int timeToShot = Random.Range(timeShotMin, timeShotMax);
        timeBtwShot -= Time.deltaTime;
        if (timeBtwShot < 0)
        {
            timeBtwShot = timeToShot;
            if (isJeep)
            {
                StartCoroutine(FireAnimation());
            }
            Instantiate(bullet, shotPos.transform.position, Quaternion.identity);
        }


    }
    IEnumerator FireAnimation()
    {
        fireShot.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        fireShot.SetActive(false);
    }
}
