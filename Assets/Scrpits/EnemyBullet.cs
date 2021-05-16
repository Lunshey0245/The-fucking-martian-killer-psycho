using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Vector3 LastTargetPosition;

    private void Start()
    {
        LastTargetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(LastTargetPosition * speed * Time.deltaTime);
    }
}
