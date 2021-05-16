using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject plasmaBullet;

    [SerializeField]
    Transform posSpawnBullet;

    Animator _animator;


    [SerializeField]
    float timeShot;

    [SerializeField]
    float timeBtwShot;

    public bool canShot;
  
    void Start()
    {
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canShot)
        {
            timeBtwShot -= Time.deltaTime;
            if (timeBtwShot <= 0)
            {
                timeBtwShot = 0;
                if (canShot)
                {
                    Instantiate(plasmaBullet, posSpawnBullet.position, Quaternion.identity);
                    _animator.SetTrigger("Shot");
                    timeBtwShot = timeShot;
                }
            }
        }
    }
}
