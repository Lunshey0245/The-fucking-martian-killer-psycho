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
        /*if (timeBtwShot > 0)
        {

        }*/
        IEnumerator FireAnimation()
        {
            fireShot.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            fireShot.SetActive(false);
        }
    }
}
